using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Rect3DDto : StorableGuid
    {
        public Point3DDto Location { get; set; } = null!;
        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }

        public static Rect3DDto FromRect3D(Rect3D rect3D)
        {
            return new Rect3DDto()
            {
                Location = Point3DDto.FromPoint3D(rect3D.Location),
                SizeX = rect3D.Size.X,
                SizeY = rect3D.Size.Y,
                SizeZ = rect3D.Size.Z
            };
        }

        public Rect3D ToRect3D()
        {
            return new Rect3D(Location.ToPoint3D(), new Size3D(SizeX, SizeY, SizeZ));   
        }
    }
}
