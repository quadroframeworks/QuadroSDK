using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public static class Util2D
    {
        public static Point? ComputeLineIntersection(Point p1, Vector v1, Point p2, Vector v2)
        {
            Vector startdiff = Point.Subtract(p2, p1);
            double dir1xdir2 = Vector.CrossProduct(v1, v2);

            if (dir1xdir2 == 0)
                return null;

            double t = Vector.CrossProduct(startdiff, v2) / dir1xdir2;

            var pint = Point.Add(p1, Vector.Multiply(v1, t));
            return pint;
        }
    }
}
