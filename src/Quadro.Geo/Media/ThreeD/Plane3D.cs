using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CPBase.Geo.Media;

namespace CPBase.Geo.Media.ThreeD
{
    public class Plane3D
    {
        public Plane3D(Point3D origin, Vector3D normal)
        {
            Origin = origin;
            Normal = normal;
        }
        public Point3D Origin { get; private set; }
        public Vector3D Normal { get; private set; }

        public void Translate(Vector3D v)
        {
            Origin = Origin + v;
        }

        public void RotateAtOrigin(Vector3D v, double angleInDegrees)
        {
            var m = Matrix3D.Identity;
            var q = Quaternion.CreateFromAxisAngle(new Vector3(Convert.ToSingle(v.X), Convert.ToSingle(v.Y), Convert.ToSingle(v.Z)), Convert.ToSingle(M3DUtil.DegreesToRadians(angleInDegrees)));
            m.RotateAt(q, Origin);
            Normal = m.Transform(Normal);
        }

        public void Transform(Matrix3D transform)
        {
            Origin = transform.Transform(Origin);
            Normal = transform.Transform(Normal);
        }

        public Plane3D Clone()
        {
            return new Plane3D(Origin, Normal);
        }

        public Plane3D GetOffsetPlane(double offset)
        {
            var origin = Origin + (Normal * offset);
            return new Plane3D(origin, Normal);
        }
    }
}
