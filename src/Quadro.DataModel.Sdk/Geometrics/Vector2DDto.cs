using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Vector2DDto:StorableGuid
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector ToVector() =>new Vector(X, Y);
        public static Vector2DDto FromPoint(Vector p)=>new Vector2DDto() { X = p.X, Y = p.Y };
    }
}
