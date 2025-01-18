using CPBase.Geo.Media;
using CPBase.Geo.Media.TwoD;
using System.Net;
using System.Security.AccessControl;
using System.Transactions;


namespace CPBase.Shapes
{
    public interface IPathShape2D
    {
        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public IList<IShape2D> Segments { get; }
        public void AddLine(double toX, double toY);
		public void AddLine(Point toPoint);
		public void AddArc(double toX, double toY, double radius, bool isCcw, bool isLargeArc);
		public void AddArc(Point toPoint, double radius, bool isCcw, bool isLargeArc);
		public void AddArcByFillet(double toX, double toY, double cornerX, double cornerY, double radius);
		public void AddArcByFillet(Point toPoint, Point cornerPoint, double radius);
		public void AddShape(IShape2D shape);
        public Rect Bounds { get; }
        public void Translate(Vector v);
        public void Scale(double x, double y);
        void Transform(Matrix transform);
        void Reverse();
        public IPathShape2D Clone();
        public IPathShape2D GetOffsetPath(double offset);
        public IList<Point> GetDecomposedPoints(double angleprecision = 10);
    }

    public class PathShape2D:IPathShape2D
    {
        public PathShape2D(double startX, double startY) 
        {
            segments = new  List<IShape2D>();
            StartPoint = new Point(startX, startY);
            EndPoint = StartPoint;
			bounds = Rect.Empty;
        }

        public PathShape2D(Point startpoint)
        {
            segments = new List<IShape2D>();
            StartPoint = startpoint;
            EndPoint = StartPoint;
			bounds = Rect.Empty;
        }
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }
        public IList<IShape2D> Segments => segments;
        public Rect Bounds => bounds;
        private Rect bounds;

        private IList<IShape2D> segments;

        public void AddLine(double toX, double toY)
        {
            var line = new Line2D(EndPoint.X, EndPoint.Y, toX, toY);
            segments.Add(line);
            EndPoint = new Point(toX, toY);
			bounds.Union(line.Bounds);
        }
		public void AddLine(Point toPoint) => AddLine(toPoint.X, toPoint.Y);
		
		public void AddArc(double toX, double toY, double radius, bool isCcw, bool isLargeArc)
        {
            var arc = new Arc2D(EndPoint.X, EndPoint.Y, toX, toY, radius, isCcw, isLargeArc);
            segments.Add(arc);
            EndPoint = new Point(toX, toY);
			bounds.Union(arc.Bounds);
        }
		public void AddArc(Point toPoint, double radius, bool isCcw, bool isLargeArc)=>AddArc(toPoint.X, toPoint.Y, radius, isCcw, isLargeArc);
		

		public void AddShape(IShape2D shape)
        {
            segments.Add(shape);
            EndPoint = shape.ToPoint;
			bounds.Union(shape.Bounds);
        }

        public void AddArcByFillet(double toX, double toY, double cornerX, double cornerY, double radius)
        {
            var filletarc = GeometricsMath.GetFillet(EndPoint, new Point(toX, toY), new Point(cornerX, cornerY), radius);
            AddLine(filletarc.FromPoint.X, filletarc.FromPoint.Y);
            AddShape(filletarc);
        }
        public void AddArcByFillet(Point toPoint, Point cornerPoint, double radius) => AddArcByFillet(toPoint.X, toPoint.Y, cornerPoint.X, cornerPoint.Y, radius);
		

		public void Translate(Vector v)
        {
            StartPoint = StartPoint + v;
            EndPoint = EndPoint + v;
            foreach (var segment in segments)
                segment.Translate(v);
            UpdateBounds();
        }

        public void Scale(double x, double y)
        {
            StartPoint= new Point(StartPoint.X *x, StartPoint.Y*y);
            EndPoint = new Point(EndPoint.X * x, EndPoint.Y * y);
            foreach (var segment in segments)
                segment.Scale(x, y);
            UpdateBounds();

        }
        public void Transform(Matrix transform)
        {
            var xaxis = new Vector(transform.M11, transform.M12);
            var yaxis = new Vector(transform.M21, transform.M22);

            var mirrors = Vector.CrossProduct(yaxis, xaxis) > 0;

            var newsegments = new List<IShape2D>();
            foreach (var segment in segments)
            {
                if (segment is IArc2D arc)
                {
                    var newstart = transform.Transform(arc.FromPoint);
                    var newend = transform.Transform(arc.ToPoint);
                    var newarc = new Arc2D(newstart, newend, arc.Radius, mirrors ? !arc.IsCcw : arc.IsCcw, arc.IsLargeArc);
                    newsegments.Add(newarc);
                }
                else if (segment is ILine2D line)
                {
                    var newstart = transform.Transform(line.FromPoint);
                    var newend = transform.Transform(line.ToPoint);
                    newsegments.Add(new Line2D(newstart, newend));
                }
                else
                    throw new Exception($"Transformation of type {segment.GetType()} is not supported.");
            }

            this.segments.Clear();
            foreach (var segment in newsegments)
                this.segments.Add(segment);

            this.StartPoint = transform.Transform(this.StartPoint);
            this.EndPoint = transform.Transform(this.EndPoint);
            UpdateBounds();
        }

        public void Reverse()
        {
            var newstartpoint = this.EndPoint;
            var newendpoint = this.StartPoint;

            var newsegments = new List<IShape2D>();
            foreach (var segment in segments.Reverse())
            {
                if (segment is IArc2D arc)
                {
                    var newstart = arc.ToPoint;
                    var newend = arc.FromPoint;
                    var newarc = new Arc2D(newstart, newend, arc.Radius, !arc.IsCcw, arc.IsLargeArc);
                    newsegments.Add(newarc);
                }
                else if (segment is ILine2D line)
                {
                    var newstart = line.ToPoint;
                    var newend = line.FromPoint;
                    newsegments.Add(new Line2D(newstart, newend));
                }
                else
                    throw new Exception($"Transformation of type {segment.GetType()} is not supported.");
            }


            this.segments.Clear();
            foreach (var segment in newsegments)
                this.segments.Add(segment);

            this.StartPoint = newstartpoint;
            this.EndPoint = newendpoint;

            UpdateBounds();
        }
		public IList<Point> GetDecomposedPoints(double precisionangle = 10.0)
		{
			var points = new List<Point>();
            points.Add(StartPoint);
            foreach (var segment in segments)
            {
                if (segment is IArc2D arc)
                {
                    var vstart = arc.FromPoint - arc.Center;
                    var vend = arc.ToPoint - arc.Center;
                    var angle = Math.Abs(Vector.AngleBetween(vstart, vend));
                    if (arc.IsLargeArc)
                        angle += 180.0;

                    var nrofpoints = Math.Ceiling(angle / precisionangle);
                    var anglestep = angle / nrofpoints;
                    for (int i= 1; i <= nrofpoints; i++)
                    {
                        var rotation = i * anglestep;
                        var vinsert = Math2D.RotateVector(vstart, rotation, arc.IsCcw);
                        points.Add(arc.Center + vinsert);
                    }
                }
                else
                    points.Add(segment.ToPoint);
            }
            return points;
		}

        public IPathShape2D Clone()
        {
            var clone = new PathShape2D(this.StartPoint);
            foreach (var segment in segments)
            {
                clone.segments.Add(segment.Clone());
            }
            clone.UpdateBounds();
            return clone;
        }

        private void UpdateBounds()
        {
            bounds = Rect.Empty;
            foreach (var segment in this.Segments)
                bounds.Union(segment.Bounds);
        }

        public IPathShape2D GetOffsetPath(double offset)
        {
            if (this.segments.Count == 0)
                throw new ArgumentException("Cannot create offset path if there are no segments.");

            var newshapes = new List<IShape2D>();

            foreach (var segment in this.segments)
            {
                if (segment is ILine2D line)
                {
                    var dir = line.ToPoint - line.FromPoint;
                    dir.Normalize();
                    var tangentdir = Math2D.RotateVector(dir, 90, false);
                    var tangentoffset = tangentdir * offset;
                    var offsetline = new Line2D(line.FromPoint + tangentoffset, line.ToPoint + tangentoffset);
                    newshapes.Add(offsetline);
                }
                else if (segment is IArc2D arc)
                {
                    var offsetradius = arc.IsCcw ? arc.Radius + offset : arc.Radius - offset;
                    var startoffset = arc.IsCcw ? arc.Center - arc.FromPoint : arc.FromPoint - arc.Center;
                    var endoffset = arc.IsCcw ? arc.Center - arc.ToPoint : arc.ToPoint - arc.Center;
                    startoffset.Normalize();
                    endoffset.Normalize();
                    startoffset *= offset;
                    endoffset *= offset;
                    var offsetarc = new Arc2D(arc.FromPoint + startoffset, arc.ToPoint + endoffset, offsetradius, arc.IsCcw, arc.IsLargeArc);
                    newshapes.Add(offsetarc);
                }
            }


            PathShape2D result = null!;
          
            for (int i =  0; i < newshapes.Count; i++)
            {
                var previousshape = i==0? newshapes.Last() : newshapes[i - 1];
                var currentshape = newshapes[i];
                var nextshape = i == newshapes.Count - 1 ? newshapes.First() : newshapes[i+1];

                var intersectionstart = GetIntersection(previousshape, currentshape);
                var intersectionend = GetIntersection(currentshape, nextshape);

                if (result == null)
                    result = new PathShape2D(intersectionstart);

                if (currentshape is ILine2D currentline)
                {
                    var line = new Line2D(intersectionstart, intersectionend);
                    result.AddShape(line);
                }
                else if (currentshape is IArc2D currentarc)
                {
                    var arc = new Arc2D(intersectionstart, intersectionend, currentarc.Radius, currentarc.IsCcw, currentarc.IsLargeArc);
                    result.AddShape(arc);
                }
            }

            return result;
        }

        private Point GetIntersection(IShape2D shapeA, IShape2D shapeB)
        {

            var lineA = shapeA as ILine2D;
            var arcA = shapeA as IArc2D;

            var lineB = shapeB as ILine2D;
            var arcB = shapeB as IArc2D;

            if (lineA != null && lineB != null)
            {
                var linelineintersect = Math2D.ComputeIntersectTwoLines(lineA.FromPoint, lineA.ToPoint - lineA.FromPoint, lineB.FromPoint, lineB.ToPoint - lineB.FromPoint);
                if (linelineintersect != null)
                    return linelineintersect.Value;
                else
                    return lineB.FromPoint;
            }
            else if (lineA != null && arcB != null)
            {
                var linearcintersects = Math2D.ComputeClosestIntersectLineArc(lineA.FromPoint, lineA.ToPoint - lineA.FromPoint, arcB.Center, arcB.Radius, arcB.FromPoint);
                if (linearcintersects != null)
                    return linearcintersects.Value;
                else
                    return arcB.FromPoint;
            }
            else if (lineB != null && arcA != null)
            {
                var linearcintersects = Math2D.ComputeClosestIntersectLineArc(lineB.FromPoint, lineB.ToPoint - lineB.FromPoint, arcA.Center, arcA.Radius, lineB.FromPoint);
                if (linearcintersects != null)
                    return linearcintersects.Value;
                else
                    return lineB.FromPoint;
            }
            else
                throw new NotImplementedException("Arc-arc intersection not implemented.");

        }
    }
}