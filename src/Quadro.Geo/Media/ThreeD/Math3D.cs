using System.Numerics;

namespace CPBase.Geo.Media.ThreeD
{
	public static partial class Math3D
    {

     
        public static Vector3D PerpendicularVectorFromLineToPoint(Point3D linestart, Vector3D linedirection, Point3D p)
        {

            var intersect = ComputeIntersectLinePlane(linestart, linedirection, p, linedirection);
            if (intersect == null)
                throw new Exception();

            var result = p - intersect.Value;
            result.Normalize();
            return result;

        }
        public static double DistanceBetweenLineAndPoint(Point3D linestart, Vector3D linedirection, Point3D p)
        {
            Vector3D v1 = linedirection;
            Vector3D v2 = Point3D.Subtract(linestart, p);
            Vector3D nom = Vector3D.CrossProduct(v1, v2);
            double distance = nom.Length / linedirection.Length;
            return distance;
        }

        public static double DistanceBetweenLineAndPoint(Point3D linestart, Point3D lineend, Point3D p)
        {
            Vector3D v1 = Point3D.Subtract(lineend, linestart);
            Vector3D v2 = Point3D.Subtract(linestart, p);
            Vector3D denom = Point3D.Subtract(lineend, linestart);
            Vector3D nom = Vector3D.CrossProduct(v1, v2);
            double distance = nom.Length / denom.Length;
            return distance;
        }


        public static double DistanceBetweenPointAndPlane(Point3D planeorigin, Vector3D planenormal, Point3D p)
        {
            Vector3D normal = planenormal;
            Vector3D vCtoP = Point3D.Subtract(p, planeorigin);
            double val = Vector3D.DotProduct(normal, vCtoP) / normal.Length;
            return val;
        }

        public static double DistanceBetweenPointAndTriangle(Triangle3D triangle, Point3D p)
        {
            return DistanceBetweenPointAndPlane(triangle.P1, triangle.Normal, p);
        }

        public static double DistanceBetweenLineAndPlane(Plane3D plane, Point3D p)
        {
            return DistanceBetweenPointAndPlane(plane.Origin, plane.Normal, p);
        }


        public static Axis3D? ComputeIntersectPlanePlane(Point3D planeOriginA, Vector3D planeNormalA, Point3D planeOriginB, Vector3D planeNormalB)
        {
            var dir = Vector3D.CrossProduct(planeNormalA, planeNormalB);
            var det = dir.LengthSquared;

            if (det == 0.0) //Planes parallel
                return null;

            var dA = DistanceBetweenPointAndPlane(planeOriginA, planeNormalA, new Point3D());
            var dB = DistanceBetweenPointAndPlane(planeOriginB, planeNormalB, new Point3D());

            var intersection = (Vector3D.CrossProduct(dir, planeNormalB) * dA) + (Vector3D.CrossProduct(planeNormalA, dir) * dB) / det;

            dir.Normalize();

            return new Axis3D(new Point3D(intersection.X, intersection.Y, intersection.Z), dir);

        }

        public static Point3D? ComputeIntersectLinePlane(Point3D lineOrigin, Vector3D lineDir, Point3D planeOrigin, Vector3D planeNormal)
        {
            double distance = Vector3D.DotProduct(Point3D.Subtract(planeOrigin, lineOrigin), planeNormal) / Vector3D.DotProduct(lineDir, planeNormal);

            if (double.IsInfinity(distance))
                return null;

            if (double.IsNaN(distance))
                return null;

            var pint = Point3D.Add(lineOrigin, Vector3D.Multiply(distance, lineDir));
            return pint;

        }

        public static IEnumerable<Point3D>? ComputeIntersectArcPlane(Arc3D arc, Point3D planeOrigin, Vector3D planeNormal)
        {
            var arcplaneorg = arc.CenterPoint;
            var arcnormal = arc.Normal;

            var intline = ComputeIntersectPlanePlane(arcplaneorg, arcnormal, planeOrigin, planeNormal);
            if (intline == null) //Planes parallel
                return null;

            var perpint = ComputeIntersectLinePlane(intline.Origin, intline.Direction, arc.CenterPoint, intline.Direction);
            if (perpint == null) return null; //This will never happen

            var dist = (perpint.Value - arc.CenterPoint).Length;

            if (dist > arc.Radius)
                return null;

            var distalongint = Math.Sqrt(Math.Pow(arc.Radius, 2) - Math.Pow(dist, 2));

            var p1 = perpint.Value + intline.Direction * distalongint;
            var p2 = perpint.Value - intline.Direction * distalongint;

            return new List<Point3D>() { p1, p2 };
        }

        public static Point3D? ComputeClosestIntersectArcPlane(Arc3D arc, Point3D planeOrigin, Vector3D planeNormal, Point3D testPoint)
        {
            var intersections = ComputeIntersectArcPlane(arc, planeOrigin, planeNormal) as List<Point3D>;
            if (intersections == null) return null;

            var d1 = (intersections[0] - testPoint).Length;
            var d2 = (intersections[1] - testPoint).Length;

            if (d1 < d2)
                return intersections[0];
            else
                return intersections[1];

        }


        public static Vector3D RotateVector(Vector3D v, Vector3D axis, double angleInDegrees)
        {
            Matrix3D matrix = Matrix3D.Identity;
            Quaternion quaternion = Quaternion.CreateFromAxisAngle(new Vector3(Convert.ToSingle(axis.X), Convert.ToSingle(axis.Y), Convert.ToSingle(axis.Z)), Convert.ToSingle(M3DUtil.DegreesToRadians(angleInDegrees)));
            matrix.Rotate(quaternion);
            return matrix.Transform(v);
        }

        public static bool PointAreClose(Point3D pA, Point3D pB, double tolerance = 0.01)
        {
            return AreClose(pA.X, pB.X, tolerance) && AreClose(pA.Y, pB.Y, tolerance) && AreClose(pA.Z, pB.Z, tolerance);
        }

        private static bool AreClose(double valA, double valB, double tolerance)
        {
            return Math.Abs(valA - valB) <= tolerance;
        }

        public static bool VectorsMatch(Vector3D p1, Vector3D p2, double tolerance = 0.01)
        {

            Vector3D diff = Vector3D.Subtract(p1, p2);
            diff.X = Math.Abs(diff.X);
            diff.Y = Math.Abs(diff.Y);
            diff.Z = Math.Abs(diff.Z);

            return (diff.X < tolerance) & (diff.Y < tolerance) & (diff.Z < tolerance);
        }
        public static bool IsPointAtSideOfVertices(Point3D p1, Point3D p2, Point3D p3, Point3D p)
        {
            var vAC = p3 - p1;
            var vBC = p2 - p1;
            var normal = Vector3D.CrossProduct(vAC, vBC);
            var vCtoP = p - p1;
            double val = Vector3D.DotProduct(normal, vCtoP);
            return val > 0.00000001;
        }

        public static bool IsPointAtSideOfPlane(Point3D planeOrigin, Vector3D planeNormal, Point3D p)
        {
            var vCtoP = p - planeOrigin;
            double val = Vector3D.DotProduct(planeNormal, vCtoP);
            return val > 0.00000001;
        }

        public static bool IsPointAtSideOfTriangle(Triangle3D triangle, Point3D p)
        {
            return IsPointAtSideOfVertices(triangle.P1, triangle.P2, triangle.P3, p);
        }

        public static bool IsPointWithinLine(Point3D p, Line3D line)
        {
            var dist_s = p - line.StartPoint;
            var dist_e = line.EndPoint - p;
            var dist_s_e = line.EndPoint - line.StartPoint;

            return (dist_s.Length <= (dist_s_e.Length + 0.00000001) && dist_e.Length <= (dist_s_e.Length + 0.00000001));
        }


        public static bool IsPointWithinTriangleBarycentric(Point3D p, Triangle3D t)
        {


            Vector3D u = Point3D.Subtract(t.P2, t.P1);
            Vector3D v = Point3D.Subtract(t.P3, t.P1);
            Vector3D w = Point3D.Subtract(p, t.P1);

            Vector3D v_crossW = Vector3D.CrossProduct(v, w);
            Vector3D v_crossU = Vector3D.CrossProduct(v, u);


            double check1 = Vector3D.DotProduct(v_crossW, v_crossU);


            if (check1 < -0.00001) { return false; };


            Vector3D u_crossW = Vector3D.CrossProduct(u, w);
            Vector3D v_crossV = Vector3D.CrossProduct(u, v);


            double check2 = Vector3D.DotProduct(u_crossW, v_crossV);


            if (check2 < -0.00001) { return false; };

            double denom = v_crossV.Length;

            double a = v_crossW.Length / denom;
            double b = u_crossW.Length / denom;
            double c = 1 - a - b;

            return (a + b <= 1.00001);


        }

        public static bool VectorDirectionOpposite(Vector3D v1, Vector3D v2)
        {

            double angle = Math.Abs(Vector3D.AngleBetween(v1, v2));

            if (angle > 90)
            {
                return true;
            }
            return false;

        }

        public static double AngleBetweenAbs(Vector3D v1, Vector3D v2, Vector3D refnormal)
        {
            var angle = Vector3D.AngleBetween(v1, v2);
            var normal = Vector3D.CrossProduct(v1, v2);
            var donegate = Math3D.VectorDirectionOpposite(normal, refnormal);
            if (donegate)
                angle = -angle;

            return angle;
        }

        public static bool PointIsOnArc(Arc3D arc, Point3D p, double tolerance = 0.01)
        {
            if (arc.IsLargeArc)
                throw new NotImplementedException("Cannot test if point is on arc if arc is large arc.");

            var dirp = p - arc.CenterPoint;
            if (Math.Abs(dirp.Length - arc.Radius) > tolerance)
                return false;

            var dir_start = arc.StartPoint - arc.CenterPoint;
            var dir_end = arc.EndPoint - arc.CenterPoint;

            var angletotal = AngleBetweenAbs(dir_start, dir_end, arc.Normal);
            var angletest = AngleBetweenAbs(dir_start, dirp, arc.Normal);

            return angletest < (angletotal+ tolerance) & angletest > -tolerance;
            
        }
        public static Rect3D TransformBounds(Rect3D bounds, Matrix3D transform)
        {
            var p1 = new Point3D(bounds.X, bounds.Y, bounds.Z);
            var p2 = new Point3D(bounds.X + bounds.SizeX, bounds.Y, bounds.Z);
            var p3 = new Point3D(bounds.X, bounds.Y + bounds.SizeY, bounds.Z);
            var p4 = new Point3D(bounds.X + bounds.SizeX, bounds.Y + bounds.SizeY, bounds.Z);

            var p5 = new Point3D(bounds.X, bounds.Y, bounds.Z + bounds.SizeZ);
            var p6 = new Point3D(bounds.X + bounds.SizeX, bounds.Y, bounds.Z + bounds.SizeZ);
            var p7 = new Point3D(bounds.X, bounds.Y + bounds.SizeY, bounds.Z + bounds.SizeZ);
            var p8 = new Point3D(bounds.X + bounds.SizeX, bounds.Y + bounds.SizeY, bounds.Z + bounds.SizeZ);

            var p1_trans = transform.Transform(p1);
            var p2_trans = transform.Transform(p2);
            var p3_trans = transform.Transform(p3);
            var p4_trans = transform.Transform(p4);

            var p5_trans = transform.Transform(p5);
            var p6_trans = transform.Transform(p6);
            var p7_trans = transform.Transform(p7);
            var p8_trans = transform.Transform(p8);

            var result = Rect3D.Empty;
            result.Union(p1_trans);
            result.Union(p2_trans);
            result.Union(p3_trans);
            result.Union(p4_trans);

            result.Union(p5_trans);
            result.Union(p6_trans);
            result.Union(p7_trans);
            result.Union(p8_trans);
            return result;
        }
    }
}
