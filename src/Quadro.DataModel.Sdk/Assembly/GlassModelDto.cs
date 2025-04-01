using Quadro.DataModel.Common;
using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
    public class GlassModelDto
    {
        public GlassModelDto() { }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? SubFrameHandleId { get; set; }
        public List<int> SectionIds { get; set; } = new List<int>();
        public string DescriptionId { get; set; } = null!;
        public string? GlassName { get; set; }
        public string? CatalogItemId { get; set; }
        public double Thickness { get; set; }
        public double SurfaceArea { get; set; }
        public Rect3DDto Bounds { get; set; } = null!;
        public WireFrameModelDto WireFrame { get; set; } = null!;
        public Matrix3DDto GlassToFrameTransform { get; set; } = null!;
    }
}
