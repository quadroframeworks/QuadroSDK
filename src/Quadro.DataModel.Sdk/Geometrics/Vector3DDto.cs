using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Vector3DDto : StorableGuid
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D ToVector3D() =>new Vector3D(X, Y, Z);
        public static Vector3DDto FromVector3D(Vector3D p)=>new Vector3DDto() { X = p.X, Y = p.Y, Z= p.Z };
    }
}
