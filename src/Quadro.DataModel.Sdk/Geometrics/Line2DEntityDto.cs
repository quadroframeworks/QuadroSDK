using CPBase.Geo.Media.TwoD;
using CPBase.Shapes;
using Quadro.DataModel.Common;

namespace Quadro.DataModel.Geometrics
{
    public class Line2DEntityDto
    {
        public int Id { get; set; }
        public int? DimensionId { get; set; }
        public Line2DDto Line { get; set; } = null!;
        public ColorDto LineColor { get; set; } = null!;
        public double LineThickness { get; set; }
        public LineStyle LineStyle { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; } = string.Empty;
        public IShape2DEntity ToShape2DEntity() => new Shape2DEntity(Line.ToLine2D(), LineColor.ToUniversalColor(), LineThickness, LineStyle, ZIndex, Layer)
        {
            Id = this.Id,
            DimensionId = this.DimensionId,
        };
        public static Line2DEntityDto FromLine2DEntity(IShape2DEntity shape) => new Line2DEntityDto()
        {
            Id = shape.Id,
            DimensionId = shape.DimensionId,
            LineColor = ColorDto.FromColor(shape.Color),
            LineThickness = shape.Thickness,
            LineStyle = shape.LineStyle,
            Line = Line2DDto.FromLine2D((Line2D)shape.Shape),
            ZIndex = shape.ZIndex,
            Layer = shape.Layer,
        };
    }
}
