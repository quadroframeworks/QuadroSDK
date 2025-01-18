using CPBase.Geo.Media.TwoD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
    public class ImageEntityDto
    {
        public int Id { get; set; }
        public string Data { get; set; } = null!;
        public Matrix2DDto Transform { get; set; } = null!;
        public Rect2DDto Box { get; set; } = null!;
        public int ZIndex { get; set; }
        public string Layer { get; set; } = null!;

        public IImageEntity ToImageEntity() => new ImageEntity(Data, Transform.ToMatrix2D(), Box.ToRect(), ZIndex, Layer)
        {
            Id = this.Id,
        };


        public static ImageEntityDto FromImageEntity(IImageEntity imageEntity) =>
            new ImageEntityDto()
            {
                Id = imageEntity.Id,
                Data = imageEntity.Data,
                Layer = imageEntity.Layer,
                Transform = Matrix2DDto.FromMatrix2D(imageEntity.ImageTransform),
                Box = Rect2DDto.FromRect(imageEntity.Box),
                ZIndex = imageEntity.ZIndex,
            };

    }
}
