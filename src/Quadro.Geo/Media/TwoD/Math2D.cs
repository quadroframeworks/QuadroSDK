using CPBase.Geo.Media;
using CPBase.Shapes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.TwoD
{
    public static class Math2D
    {

        //Rotates vector around origin.
        public static Vector RotateVector(Vector v, double degrees, bool ccw)
        {
            var radians = M3DUtil.DegreesToRadians(degrees);

            if (!ccw)
            {
                radians = -radians;
            }

            double newX = v.X * Math.Cos(radians) - v.Y * Math.Sin(radians);
            double newY = v.Y * Math.Cos(radians) + v.X * Math.Sin(radians);
            v.X = newX;
            v.Y = newY;
            return v;

        }

        public static Point? ComputeIntersectTwoLines(Point pA, Vector vA, Point pB, Vector vB)
        {

            Point? result = null;

            //Calculate the direction vector of each line
            Vector startdiff = Point.Subtract(pB, pA);
            double dir1xdir2 = Vector.CrossProduct(vA, vB);

            //If cross product is zero, lines are parallel
            if (dir1xdir2 == 0.0)
                return null;

            //If not parallel, they intersect
            double t = Vector.CrossProduct(startdiff, vB) / dir1xdir2;

            //Intersection at startpoint1 + t*dir1
            result = Point.Add(pA, Vector.Multiply(vA, t));

            return result;
        }

        public static IEnumerable<Point>? ComputeIntersectLineArc(Point pLine, Vector vLine, Point pCenter, double radius)
        {
            vLine.Normalize();
            var pmid = ComputeIntersectTwoLines(pCenter, new Vector(vLine.Y, vLine.X), pLine, vLine);
            if (pmid == null)
                return null;

            var vmid = pmid - pCenter;
            if (vmid == null)
                return null;

            var midtoarc = vmid.Value.Length;
            if (midtoarc > radius)
                return null;

            var intLength = Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(midtoarc, 2));
            var intersectA = pmid.Value + (vLine * intLength);
            var intersectB = pmid.Value - (vLine * intLength);
            var result = new List<Point>
            {
                intersectA,
                intersectB
            };
            return result;
        }

        public static Point? ComputeClosestIntersectLineArc(Point pLine, Vector vLine, Point pCenter, double radius, Point testPoint)
        {
            var intersections = ComputeIntersectLineArc(pLine, vLine, pCenter, radius) as List<Point>;
            if (intersections == null) return null;

            var d1 = (intersections[0] - testPoint).Length;
            var d2 = (intersections[1] - testPoint).Length;

            if (d1 < d2)
                return intersections[0];
            else
                return intersections[1];

        }

        public static bool IsOnLineSegment(Point pStart, Point pEnd, Point pTest, double tolerance = 0.1)
        {
            var distparallel = DistanceBetweenLineAndPoint(pStart, pEnd, pTest);
            if (distparallel > tolerance)
                return false;

            var distStart = (pTest - pStart).Length;
            var distEnd = (pTest - pEnd).Length;
            var length = (pEnd - pStart).Length;

            var result = distStart <= length + tolerance && distEnd <= length + tolerance;
            return result;
        }

        public static double DistanceBetweenLineAndPoint(Point pStart, Point pEnd, Point pTest)
        {
            Vector v1 = Point.Subtract(pEnd, pStart);
            Vector v2 = Point.Subtract(pStart, pTest);
            Vector denom = Point.Subtract(pEnd, pStart);
            double nom = Vector.CrossProduct(v1, v2);
            double distance = Math.Abs(nom / denom.Length);
            return distance;
        }

        public static double DistanceBetweenLineAndPoint(Point pStart, Vector vDir, Point pTest)
        {
            Vector v1 = vDir;
            Vector v2 = Point.Subtract(pStart, pTest);
            Vector denom = vDir;
            double nom = Vector.CrossProduct(v1, v2);
            double distance = Math.Abs(nom / denom.Length);
            return distance;
        }

        public static bool PointsAreClose(Point p1, Point p2, double tolerance = 0.00001)
        {

                Vector diff = Point.Subtract(p1, p2);
                diff.X = Math.Abs(diff.X);
                diff.Y = Math.Abs(diff.Y);

                return (diff.X < tolerance) & (diff.Y < tolerance);
           
        }

        public static bool IsPointWithinTriangle(Point p, Triangle2D t)
        {
            var A = t.P1;
            var B = t.P2;
            var C = t.P3;

            double w1 = ((B.Y - C.Y) * (p.X - C.X) + (C.X - B.X) * (p.Y - C.Y)) /
                       ((B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y));

            double w2 = ((C.Y - A.Y) * (p.X - C.X) + (A.X - C.X) * (p.Y - C.Y)) /
                           ((B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y));

            double w3 = 1 - w1 - w2;

            return (w1 >= 0 && w2 >= 0 && w3 >= 0 && w1 <= 1 && w2 <= 1 && w3 <= 1);

        }


        public static Rect TransformBounds(Rect bounds, Matrix transform)
        {
            var p1 = new Point(bounds.X, bounds.Y);
            var p2 = new Point(bounds.X + bounds.Width, bounds.Y);
            var p3 = new Point(bounds.X, bounds.Y + bounds.Height);
            var p4 = new Point(bounds.X + bounds.Width, bounds.Y + bounds.Height);


            var p1_trans = transform.Transform(p1);
            var p2_trans = transform.Transform(p2);
            var p3_trans = transform.Transform(p3);
            var p4_trans = transform.Transform(p4);

            var result = Rect.Empty;
            result.Union(p1_trans);
            result.Union(p2_trans);
            result.Union(p3_trans);
            result.Union(p4_trans);
            return result;
        }

    }
}
