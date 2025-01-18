using CPBase.Geo.Media.ThreeD;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Axis3DDto : StorableGuid
    {
        public Point3DDto Origin { get; set; } = null!;
        public Vector3DDto Direction { get; set; } = null!;

        public Axis3D ToAxis3D() => new Axis3D(Origin.ToPoint3D(), Direction.ToVector3D());
        public static Axis3DDto FromAxis3D(Axis3D axis3D)
        {
            return new Axis3DDto()
            {
                Origin = Point3DDto.FromPoint3D(axis3D.Origin),
                Direction = Vector3DDto.FromVector3D(axis3D.Direction),
            };
        }
    }

   
}
