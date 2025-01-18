using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Drawing
{
    public class FrameDrawingHeaderDto
    {
        public int Scale { get; set; }
        public string Tag { get; set; } = null!;
        public int QuantityAsDesigned { get; set; }
        public int QuantityMirrored { get; set; }
        public Rect2DDto Bounds { get; set; } = null!;
    }
}
