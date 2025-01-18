using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.ThreeD
{
    public class Triangle3D
    {


        public Triangle3D(Point3D p1, Point3D p2, Point3D p3)
        {
            Update(p1,p2,p3);
            IsMaterialOutside = false;
        }

        public Point3D P1 { get; private set; }
        public Point3D P2 { get; private set; }
        public Point3D P3 { get; private set; }

        public Line3D Edge1 { get; private set; }
        public Line3D Edge2 { get; private set; }
        public Line3D Edge3 { get; private set; }

        public Rect3D Bounds { get; private set; }
        public Point3D Centroid { get; private set; }
        public Vector3D Normal { get; private set; }

        public Boolean IsMaterialOutside { get; set; }

        public void Transform(Matrix3D m)
        {
            var p1 = m.Transform(P1);
            var p2 = m.Transform(P2);
            var p3 = m.Transform(P3);
            Update(p1, p2, p3);
        }

        private void Update(Point3D p1, Point3D p2, Point3D p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;

            Edge1 = new Line3D(p1, p2);
            Edge2 = new Line3D(p2, p3);
            Edge3 = new Line3D(p3, p1);

            var bounds = Rect3D.Empty;
            bounds = Rect3D.Union(bounds, p1);
            bounds = Rect3D.Union(bounds, p2);
            bounds = Rect3D.Union(bounds, p3);
            Bounds = bounds;

            double centroidx = (p1.X + p2.X + p3.X) / 3;
            double centroidy = (p1.Y + p2.Y + p3.Y) / 3;
            double centroidz = (p1.Z + p2.Z + p3.Z) / 3;

            Centroid = new Point3D(centroidx, centroidy, centroidz);

            var n = Vector3D.CrossProduct(Edge1.Direction, Edge3.Direction);
            n.Normalize();
            Normal = n;
        }

    }
}