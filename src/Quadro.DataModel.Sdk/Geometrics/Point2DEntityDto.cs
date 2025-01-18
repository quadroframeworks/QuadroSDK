using CPBase.Geo.Media.TwoD;
using CPBase.Visual;
using Quadro.DataModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
    public class Point2DEntityDto
    {
        public int Id { get; set; }
        public int? DimensionId { get; set; }
        public Point2DDto Point { get; set; } = null!;
        public ColorDto PointColor { get; set; } = null!;
        public double PointSize { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; } = string.Empty;
        public IPoint2DEntity ToPoint2DEntity() => new Point2DEntity(Point.ToPoint(), PointColor.ToUniversalColor(), PointSize, ZIndex, Layer)
        {
             Id = this.Id,
             DimensionId = this.DimensionId,
        };
        public static Point2DEntityDto FromPoint2DEntity(IPoint2DEntity point) => new Point2DEntityDto()
        {
            Id = point.Id,
            DimensionId = point.DimensionId,
            PointColor = ColorDto.FromColor(point.Color),
            PointSize = point.Size,
            Point = Point2DDto.FromPoint(point.Point),
            ZIndex = point.ZIndex,
            Layer = point.Layer,
        };
    }
}
