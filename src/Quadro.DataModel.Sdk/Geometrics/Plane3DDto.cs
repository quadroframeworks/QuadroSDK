using CPBase.Geo.Media.ThreeD;

namespace Quadro.DataModel.Geometrics
{
	public class Plane3DDto
    {
        public Point3DDto Origin { get; set; } = null!;
        public Vector3DDto Normal { get; set; } = null!;

        public Plane3D ToPlane3D()=>new Plane3D(Origin.ToPoint3D(), Normal.ToVector3D());
        public static Plane3DDto FromPlane3D(Plane3D plane3D)
        {
            return new Plane3DDto()
            {
                Origin = Point3DDto.FromPoint3D(plane3D.Origin),
                Normal = Vector3DDto.FromVector3D(plane3D.Normal),
            };
        }
        
    }
}
