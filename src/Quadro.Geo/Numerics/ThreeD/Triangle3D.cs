

using System.Numerics;

namespace CPBase.Geo.Numerics.ThreeD
{
    public class Triangle3D
    {


        public Triangle3D(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;

            Edge1 = new Line3D(p1, p2);
            Edge2 = new Line3D(p2, p3);
            Edge3 = new Line3D(p3, p1);

            Bounds = Rect3D.Empty;
            Bounds = Rect3D.Union(Bounds, p1);
            Bounds = Rect3D.Union(Bounds, p2);
            Bounds = Rect3D.Union(Bounds, p3);

            float centroidx = (p1.X + p2.X + p3.X) / 3;
            float centroidy = (p1.Y + p2.Y + p3.Y) / 3;
            float centroidz = (p1.Z + p2.Z + p3.Z) / 3;

            Centroid = new Vector3(centroidx, centroidy, centroidz);

            Normal = Vector3.Cross(Edge1.Direction, Edge3.Direction);
            Normal = Vector3.Normalize(Normal);
            
        }

        public Vector3 P1 { get; }
        public Vector3 P2 { get; }
        public Vector3 P3 { get; }

        public Line3D Edge1 { get; }
        public Line3D Edge2 { get; }
        public Line3D Edge3 { get; }

        public Rect3D Bounds { get; }
        public Vector3 Centroid { get; }
        public Vector3 Normal { get; }


    }
}