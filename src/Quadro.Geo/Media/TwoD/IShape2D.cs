using CPBase.Geo.Media;
using CPBase.Geo.Media.TwoD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Shapes
{
    public interface IShape2D
    {
        Point ToPoint { get; }
        Point FromPoint { get; }
        Rect Bounds { get; }
        void Translate(Vector v);
        void Transform(Matrix m);
        void Scale(double x, double y);
        IShape2D Clone();
    }

    public interface ILine2D: IShape2D
    {

    }
    public interface IArc2D: IShape2D
    {
        double Radius { get; }
        bool IsCcw { get; }
        bool IsLargeArc { get; }
        Point Center { get; }
    }
    public class Line2D: ILine2D
    {
        public Line2D(Point from,  Point to)
        {
            FromPoint = from;
            ToPoint = to;
            UpdateBounds();
        }
        public Line2D(double fromX, double fromY, double toX, double toY)
        {
            FromPoint = new Point(fromX, fromY);
            ToPoint = new Point(toX, toY);
            UpdateBounds();
        }

        public Point FromPoint { get; private set; }
        public Point ToPoint { get; private set; }
        public Rect Bounds => bounds;
        private Rect bounds;
        public void Translate(Vector v)
        {
            FromPoint = FromPoint + v;
            ToPoint = ToPoint + v;
            UpdateBounds();
        }

        public void Scale(double x, double y)
        {
            FromPoint = new Point(FromPoint.X * x, FromPoint.Y * y);
            ToPoint = new Point(ToPoint.X * x, ToPoint.Y * y);
            UpdateBounds();
        }

        public void Transform(Matrix m)
        {
            FromPoint = m.Transform(FromPoint);
            ToPoint = m.Transform(ToPoint);
            UpdateBounds();
        }

        private void UpdateBounds()
        {
			bounds = Rect.Empty;
			bounds.Union(FromPoint);
			bounds.Union(ToPoint);
        }
        
        public IShape2D Clone()
        {
            return new Line2D(FromPoint, ToPoint);
        }
        public override string ToString()=> $"Line2D from {FromPoint} to {ToPoint}";

    
    }

    public class Arc2D : IArc2D
    {
        public Arc2D(double fromX, double fromY, double toX, double toY, double radius, bool isCcw, bool isLargeArc) 
        {
            FromPoint = new Point(fromX, fromY);
            ToPoint = new Point(toX, toY);
            Radius = radius;
            IsCcw = isCcw;
            IsLargeArc = isLargeArc;
            ComputeCenterPoint();
            UpdateBounds();
        }

        public Arc2D(Point from, Point to, double radius, bool isCcw, bool isLargeArc)
        {
            FromPoint = from;
            ToPoint = to;
            Radius = radius;
            IsCcw = isCcw;
            IsLargeArc = isLargeArc;
            ComputeCenterPoint();
            UpdateBounds();
        }


        public Arc2D(double fromX, double fromY, double toX, double toY, double centerX, double centerY)
        {
            FromPoint = new Point(fromX, fromY);
            ToPoint = new Point(toX, toY);
            Center = new Point(centerX, centerY);
            Radius = (ToPoint - Center).Length;
            IsCcw = Vector.CrossProduct(ToPoint - Center, FromPoint - Center) < 0;
#warning Gokje, checken of richting klopt
            IsLargeArc = false;
            UpdateBounds();
        }

        public Arc2D(Point from, Point to, Point center)
        {
            FromPoint = from;
            ToPoint = to;
            Center = center;
            Radius = (ToPoint - Center).Length;
            IsCcw = Vector.CrossProduct(ToPoint - Center, FromPoint - Center) < 0;
#warning Aangepast, maar is dit nu goed?
            IsLargeArc = false;
            UpdateBounds();
        }

        public Point FromPoint { get; private set; }
        public Point ToPoint { get; private set; }
        public Point Center { get; private set; }
        public double Radius { get; private set; }
        public bool IsCcw { get; private set; }
        public bool IsLargeArc { get; private set; }
        public Rect Bounds => bounds;
        private Rect bounds;

        public void Translate(Vector v)
        {
            FromPoint = FromPoint + v;
            ToPoint = ToPoint + v;
            Center = Center + v;
            UpdateBounds();
        }

        public void Scale(double x, double y)
        {
            FromPoint = new Point(FromPoint.X * x, FromPoint.Y * y);
            ToPoint = new Point(ToPoint.X * x, ToPoint.Y * y);
            Center = new Point(Center.X * x, Center.Y * y);
            Radius *= x;
            UpdateBounds();
        }

        public void Transform(Matrix m)
        {
            var xaxis = new Vector(m.M11, m.M12);
            var yaxis = new Vector(m.M21, m.M22);

            var mirrors = Vector.CrossProduct(yaxis, xaxis) > 0;

            if (mirrors)
                this.IsCcw = !this.IsCcw;

            FromPoint = m.Transform(FromPoint);
            ToPoint = m.Transform(ToPoint);
            Center = m.Transform(Center);
            UpdateBounds();
        }

        public override string ToString() => $"Arc2D from {FromPoint} to {ToPoint}, radius {Radius}, is ccw {IsCcw}, is large {IsLargeArc}";


        private void UpdateBounds()
        {
			bounds = Rect.Empty;
            bounds.Union(FromPoint);
            bounds.Union(ToPoint);
#warning Dit zijn nog niet de echte bounds.
            //bounds.Union(new Point(Center.X - Radius, Center.Y - Radius));
            //bounds.Union(new Point(Center.X + Radius, Center.Y + Radius));

        }

        private void ComputeCenterPoint()
        {
            Vector vfromto = ToPoint - FromPoint;
            Point midpoint = FromPoint + (vfromto / 2);

            //Get tangent unit vector from midpoint to center point.
            Vector tocenter = Math2D.RotateVector(vfromto, 90.0, IsCcw);
            tocenter.Normalize();

            //Invert that vector to centerpoint if large arc
            if (IsLargeArc)
                tocenter.Negate();

            //Length to center from midpoint is done with pythagoras (A = SQRT(C^2 - B^2))
            double midpointtocenter = Math.Sqrt(Math.Abs(Math.Pow(Radius, 2) - Math.Pow(vfromto.Length / 2, 2)));
            tocenter = Vector.Multiply(midpointtocenter, tocenter);

            Center = Point.Add(midpoint, tocenter);

        }

        public IShape2D Clone()
        {
            return new Arc2D(FromPoint, ToPoint, Radius, IsCcw, IsLargeArc)
            {
                 
            };
        }

    }
}
