using CPBase.Geo.Media;
using System.Numerics;


namespace CPBase.Geo.Numerics.ThreeD
{
    public static class Math3D
    {

        public static bool IsPointAtSideOfVertices(Vector3 P1, Vector3 P2, Vector3 P3, Vector3 p)
        {
            Vector3 vAC = Vector3.Subtract(P3, P1);
            Vector3 vBC = Vector3.Subtract(P2, P1);
            Vector3 normal = Vector3.Cross(vAC, vBC);
            Vector3 vCtoP = Vector3.Subtract(p, P1);
            float val = Vector3.Dot(normal, vCtoP);
            return val > 0.00000001;
        }

        public static bool IsPointAtSideOfPlane(Vector3 planeOrigin, Vector3 planeNormal, Vector3 p)
        {
            Vector3 vCtoP = Vector3.Subtract(p, planeOrigin);
            float val = Vector3.Dot(planeNormal, vCtoP);
            return val > 0.00000001;
        }

        public static float DistanceBetweenLineAndPoint(Vector3 linestart, Vector3 lineend, Vector3 p)
        {
            Vector3 v1 = Vector3.Subtract(lineend, linestart);
            Vector3 v2 = Vector3.Subtract(linestart, p);
            Vector3 denom = Vector3.Subtract(lineend, linestart);
            Vector3 nom = Vector3.Cross(v1, v2);
            float distance = nom.Length() / denom.Length();
            return distance;
        }


        public static float DistanceBetweenPointAndPlanes(Vector3 planeorigin, Vector3 planenormal, Vector3 p)
        {
            Vector3 normal = planenormal;
            Vector3 vCtoP = Vector3.Subtract(p, planeorigin);
            float val = Vector3.Dot(normal, vCtoP) / normal.Length();
            return val;
        }


        public static Vector3? ComputeIntersectLinePlane(Vector3 lineOrigin, Vector3 lineDir, Vector3 planeOrigin, Vector3 planeNormal)
        {
            float distance = Vector3.Dot(Vector3.Subtract(planeOrigin, lineOrigin), planeNormal) / Vector3.Dot(lineDir, planeNormal);

            if (float.IsInfinity(distance))
                return null;

            if (float.IsNaN(distance))
                return null;

            var pint = Vector3.Add(lineOrigin, Vector3.Multiply(distance, lineDir));
            return pint;

        }

        public static Vector3 RotateVector(Vector3 v, Vector3 axis, float angleInDegrees)
        {
            var matrix = Matrix4x4.Identity;
            Quaternion quaternion = Quaternion.CreateFromAxisAngle(axis, Convert.ToSingle(Num3DUtil.DegreesToRadians(angleInDegrees)));
            var result = Vector3.TransformNormal(v, Matrix4x4.CreateFromQuaternion(quaternion));
            return result;
        }

        public static bool PointAreClose(Vector3 pA, Vector3 pB, float tolerance = 0.1f)
        {
            return AreClose(pA.X, pB.X, tolerance) && AreClose(pA.Y, pB.Y, tolerance) && AreClose(pA.Z, pB.Z, tolerance);
        }

        private static bool AreClose(float valA, float valB, float tolerance)
        {
            return Math.Abs(valA - valB) <= tolerance;
        }

    }
}
