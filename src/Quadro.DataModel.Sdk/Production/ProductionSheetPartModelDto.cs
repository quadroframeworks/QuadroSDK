using Quadro.DataModel.Geometrics;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Production
{
	public class ProductionSheetPartModelDto : StorableGuid
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Thickness { get; set; }
        public List<Shape3DDto> BoundShapes { get; set; } = new List<Shape3DDto>();
        public Rect3DDto Bounds { get; set; } = null!;
    }
}
