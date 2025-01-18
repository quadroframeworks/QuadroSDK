using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Point3DDto : StorableGuid
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D ToPoint3D() =>new Point3D(X, Y, Z);
        public static Point3DDto FromPoint3D(Point3D p)=>new Point3DDto() { X = p.X, Y = p.Y, Z= p.Z };
    }
}
