using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Size2DDto : StorableGuid
    {
        public double SizeX { get; set; }
        public double SizeY { get; set; }

        public static Size2DDto FromSize(Size size)
        {
            return new Size2DDto()
            {
                SizeX = size.Width,
                SizeY = size.Height
            };
        }

        public Size ToRect3D()
        {
            return new Size(SizeX, SizeY);   
        }
    }
}
