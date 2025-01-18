using CPBase.Geo.Media.TwoD;
using Quadro.DataModel.Common;

namespace Quadro.DataModel.Geometrics
{
    public class Path2DEntityDto
    {
        public int Id { get; set; }
        public int? DimensionId { get; set; }
        public Path2DDto Path { get; set; } = null!;
        public ColorDto LineColor { get; set; } = null!;
        public ColorDto? FillBrush { get; set; }
        public double LineThickness { get; set; }
        public LineStyle LineStyle { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; } = string.Empty;

        public IPath2DEntity ToPath2DEntity() => new Path2DEntity(Path.ToPathShape2D(),
            LineColor.ToUniversalColor(), LineThickness, LineStyle, FillBrush?.ToUniversalBrush(), ZIndex, Layer)
        {
            Id = this.Id,
            DimensionId = this.DimensionId,
        };
        public static Path2DEntityDto FromPath2DEntity(IPath2DEntity path) => new Path2DEntityDto()
        {
            Id = path.Id,
            DimensionId = path.DimensionId,
            LineColor = ColorDto.FromColor(path.Color),
            FillBrush = path.FillBrush == null ? null : ColorDto.FromBrush(path.FillBrush),
            LineThickness = path.Thickness,
            LineStyle = path.LineStyle,
            Path = Path2DDto.FromPathShape2D(path.Path),
            ZIndex = path.ZIndex,
            Layer = path.Layer
        };
    }
}
