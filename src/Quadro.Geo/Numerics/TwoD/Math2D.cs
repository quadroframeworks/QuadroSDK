using CPBase.Geo.Media;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Numerics.TwoD
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


    }
}
