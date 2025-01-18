using Quadro.DataModel.Common;
using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
    public class VentGrillModelDto
    {
        public string Name { get; set; }
        public string VariantId { get; set; } = null!;
        public string DescriptionId { get; set; } = null!;
        public double Length { get; set; }
        public ColorDto? Color { get; set; }
        public Path2DDto CrossSection { get; set; } = null!;
        public List<Path2DDto> CrossSectionsInner { get; set; } = new List<Path2DDto>();
        public Matrix3DDto VentGrillToFrameTransform { get; set; } = null!;
    }
}
