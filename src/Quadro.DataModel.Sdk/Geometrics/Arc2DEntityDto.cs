using CPBase.Geo.Media.TwoD;
using CPBase.Shapes;
using Quadro.DataModel.Common;

namespace Quadro.DataModel.Geometrics
{
	public class Arc2DEntityDto
    {
        public int Id { get; set; }
        public int? DimensionId { get; set; }
        public Arc2DDto Arc { get; set; } = null!;
        public ColorDto LineColor { get; set; } = null!;
        public double LineThickness { get; set; }
        public LineStyle LineStyle { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; } = string.Empty;

        public IShape2DEntity ToShape2DEntity() => new Shape2DEntity(Arc.ToArc2D(), LineColor.ToUniversalColor(), LineThickness, LineStyle, ZIndex, Layer)
        {
            Id = this.Id,
            DimensionId = this.DimensionId
        };
        public static Arc2DEntityDto FromArc2DEntity(IShape2DEntity shape) => new Arc2DEntityDto()
        {
            Id = shape.Id,
            DimensionId = shape.DimensionId,
            LineColor = ColorDto.FromColor(shape.Color),
            LineThickness = shape.Thickness,
            LineStyle = shape.LineStyle,
            Arc = Arc2DDto.FromArc2D((Arc2D)shape.Shape),
            ZIndex = shape.ZIndex,
            Layer = shape.Layer
        };
    }
}
