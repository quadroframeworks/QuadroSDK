using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model.Tools
{
    public class ReferencePointModelDto
    {
        public string RefPointId { get; set; } = null!;
        public int Index { get; set; }
        public Point2DDto Position { get; set; } = null!;
        public Matrix2DDto RefPointToToolTransform { get; set; } = null!;
    }
}
