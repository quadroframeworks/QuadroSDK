using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Assembly
{
    public class PurchasedDoorModelDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public List<int> SectionIds { get; set; } = new List<int>();
        public string? DescriptionId { get; set; }
        public string? CatalogItemId { get; set; }
        public double Thickness { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double SurfaceArea { get; set; }
        public Rect3DDto Bounds { get; set; } = null!;
        public WireFrameModelDto WireFrame { get; set; } = null!;
        public Matrix3DDto DoorToFrameTransform { get; set; } = null!;
    }
}
