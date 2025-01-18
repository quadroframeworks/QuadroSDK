using CPBase.Geo.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Shapes
{
    public class GeometricsMath
    {

        public static Arc2D GetFillet(Point pFrom, Point pTo, Point pCorner, double radius)
        {


            //Calculate vectors of both segments
            Vector v1 = Point.Subtract(pFrom, pCorner);
            Vector v2 = Point.Subtract(pTo, pCorner);

            //Calculate angle between actual segment and next segment
            double cornerangle = Vector.AngleBetween(v1, v2);

            //Calculate length of each segment that has to be cut off
            double trimlength = Math.Abs(radius / Math.Tan((cornerangle / 2) * Math.PI / 180));

            //Copy actual line segment to create a trim vector
            Vector vtrim1 = new Vector(v1.X, v1.Y);          //This vector is v1, and is already in the trim direction
            vtrim1.Normalize();                              //Normalize so we can multiply it with a unit length
            vtrim1 = Vector.Multiply(trimlength, vtrim1);     //Multiply by trimlength to get the trim vector.

            //Do the same for the next line segment
            Vector vtrim2 = new Vector(v2.X, v2.Y);          //This vector is v1, and is already in the trim direction
            vtrim2.Normalize();                              //Normalize so we can multiply it with a unit length
            vtrim2 = Vector.Multiply(trimlength, vtrim2);     //Multiply by trimlength to get the trim vector.

            //Now we have the trim vector. If we add it to the actual point, we have the new trimmed end point of the line.
            Point trimmedpoint1 = Point.Add(pCorner, vtrim1);
            Point trimmedpoint2 = Point.Add(pCorner, vtrim2);

            //Determine side that the arc goes to
            var side = GetSideOfLine(trimmedpoint2, pFrom, pCorner);
            var isccw = side == GeometrySide.Left;
            var filletarc = new Arc2D(trimmedpoint1.X, trimmedpoint1.Y, trimmedpoint2.X, trimmedpoint2.Y, radius, isccw, false);

            return filletarc;
        }

        public static GeometrySide GetSideOfLine(Point pTest, Point pFrom, Point pTo)
        {
            var vfromto = pTo - pFrom;
            var vfromtest = pTest - pFrom;
            var cross = Vector.CrossProduct(vfromto, vfromtest);

            if (cross > 0)
                return GeometrySide.Left;
            else if (cross < 0)
                return GeometrySide.Right;
            else
                return GeometrySide.Undefined;
        }


        public enum GeometrySide
        {
            Undefined,
            Left,
            Right,
        }

        public static PathShape2D TransformPath2D(IPathShape2D path, Matrix3D transform, double z)
        {
            var points = path.GetDecomposedPoints();
            var startpoint3d = transform.Transform(new Point3D(points[0].X, points[0].Y, z));
            var result = new PathShape2D(startpoint3d.X, startpoint3d.Y);

            foreach (var point in points)
            {
                var p3d = transform.Transform(new Point3D(point.X, point.Y, z));
                result.AddLine(p3d.X, p3d.Y);
            }
            return result;
        }
    }
}
