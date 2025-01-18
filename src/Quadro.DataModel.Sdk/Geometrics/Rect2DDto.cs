using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Rect2DDto : StorableGuid
    {
        public Point2DDto Location { get; set; } = null!;
        public double SizeX { get; set; }
        public double SizeY { get; set; }

        public static Rect2DDto FromRect(Rect rect)
        {
            return new Rect2DDto()
            {
                Location = Point2DDto.FromPoint(rect.Location),
                SizeX = rect.Width,
                SizeY = rect.Height,
            };
        }

        public Rect ToRect()
        {
            return new Rect(Location.ToPoint(), new Size(SizeX, SizeY));   
        }
    }
}
