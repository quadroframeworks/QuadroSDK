using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Drawing
{
    public class CompartmentDrawingHeaderDto
    {
        public int Scale { get; set; }
        public string Tag { get; set; } = null!;
        public string Compartment { get; set; } = null!;
        public Rect2DDto Bounds { get; set; } = null!;
    }
}
