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
    public class DimensionEntityDto
    {
        public int Id { get; set; }
        public int IdEntityA { get; set; }
        public int? IdEntityB { get; set; }
        public ColorDto Color { get; set; } = null!;
        public string FontName { get; set; } = null!;
        public double FontSize { get; set; }
        public double LineThickness { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; } = null!;
        public DimensionSide Side { get; set; }
        public DimensionReference Reference { get; set; }
        public int RowIndex { get; set; }

        public IDimensionEntity ToDimensionEntity() => new DimensionEntity(IdEntityA, IdEntityB, Side, Reference, RowIndex, Color.ToUniversalColor(), FontName, FontSize, LineThickness, ZIndex, Layer)
        {
            Id = this.Id
        };

        public static DimensionEntityDto FromDimensionEntity(IDimensionEntity dimension)
            => new DimensionEntityDto()
            {
                Id = dimension.Id,
                IdEntityA = dimension.IdEntityA,
                IdEntityB = dimension.IdEntityB,
                Side = dimension.Side,
                Reference = dimension.Reference,
                RowIndex = dimension.RowIndex,
                Color = ColorDto.FromColor(dimension.Color),
                FontName = dimension.FontName,
                FontSize = dimension.FontSize,
                Layer = dimension.Layer,
                LineThickness = dimension.LineThickness,
                ZIndex = dimension.ZIndex,
            };


    }
}
