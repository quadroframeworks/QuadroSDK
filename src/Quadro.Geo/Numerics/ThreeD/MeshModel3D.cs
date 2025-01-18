namespace CPBase.Geo.Numerics.ThreeD
{
    public class MeshModel3D
    {
        public MeshModel3D()
        {
            Triangles = new Triangle3DCollection();
        }
        public Triangle3DCollection Triangles { get; set; }

    }
}
