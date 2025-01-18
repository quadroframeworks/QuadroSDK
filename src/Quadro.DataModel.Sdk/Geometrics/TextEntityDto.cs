using CPBase.Geo.Media.TwoD;
using Quadro.DataModel.Common;

namespace Quadro.DataModel.Geometrics
{
	public class TextEntityDto
    {
        public int Id { get; set; }
        public int? DimensionId { get; set; }
        public string Text { get; set; } = null!;
        public Matrix2DDto Transform { get; set; } = null!;
        public ColorDto Color { get; set; } = null!;
        public string FontName { get; set; } = null!;
        public double FontSize { get; set; }
        public TextAlign Align { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; } = null!;

        public ITextEntity ToTextEntity()=>new TextEntity(Text, Transform.ToMatrix2D(), Color.ToUniversalColor(), FontName, FontSize,Align, ZIndex, Layer)
        {
            Id = this.Id,
            DimensionId = this.DimensionId,
        };


        public static TextEntityDto FromTextEntity(ITextEntity textEntity) =>
            new TextEntityDto()
            {
                Id = textEntity.Id,
                DimensionId = textEntity.DimensionId,
                Text = textEntity.Text,
                Color = ColorDto.FromColor(textEntity.Color),
                FontName = textEntity.FontName,
                FontSize = textEntity.FontSize,
                Align = textEntity.Align,
                Layer = textEntity.Layer,
                Transform = Matrix2DDto.FromMatrix2D(textEntity.TextTransform),
                ZIndex = textEntity.ZIndex,
            };


    }
}
