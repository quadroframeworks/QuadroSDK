using System.Numerics;

namespace CPBase.Geo.Numerics.ThreeD
{
    public class Plane3D
    {
        public Plane3D(Vector3 origin, Vector3 normal)
        {
            Origin = origin;
            Normal = normal;
        }
        public Vector3 Origin { get; private set; }
        public Vector3 Normal { get; private set; }

        public void Translate(Vector3 v)
        {
            Origin = Origin + v;
        }

        public void RotateAtOrigin(Vector3 v, float angleInDegrees)
        {
            Normal = Vector3.TransformNormal(Normal, Matrix4x4.CreateFromAxisAngle(v, Num3DUtil.DegreesToRadians(angleInDegrees)));
        }

        public void Transform(Matrix4x4 transform)
        {
            Origin = Vector3.Transform(Origin, transform);
            Normal = Vector3.TransformNormal(Normal, transform);
        }

        public Plane3D Clone()
        {
            return new Plane3D(Origin, Normal);
        }
    }
}
