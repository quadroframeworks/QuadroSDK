using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Point2DDto:StorableGuid
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point ToPoint() =>new Point(X, Y);
        public static Point2DDto FromPoint(Point p)=>new Point2DDto() { X = p.X, Y = p.Y };
    }
}
