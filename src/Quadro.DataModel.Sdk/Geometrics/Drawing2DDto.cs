using CPBase.Geo.Media.TwoD;
using CPBase.Shapes;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Drawing2DDto : StorableGuid
    {
        public Drawing2DDto() 
        {

        }

        public string? Name { get; set; }
        public List<Point2DEntityDto> Points { get; set; } = new List<Point2DEntityDto>();
        public List<Line2DEntityDto> Lines { get; set; } = new List<Line2DEntityDto>();
        public List<Arc2DEntityDto> Arcs { get; set; } = new List<Arc2DEntityDto>();
        public List<Path2DEntityDto> Paths { get; set; } = new List<Path2DEntityDto>();
        public List<TextEntityDto> Texts { get; set; } = new List<TextEntityDto>();
        public List<DimensionEntityDto> Dimensions { get; set;} = new List<DimensionEntityDto>();
        public List<ImageEntityDto> Images { get; set; } = new List<ImageEntityDto>();

        public Drawing2D ToDrawing2D()
        {
            var result = new Drawing2D();
            foreach (var p in Points)
                result.Points.Add(p.ToPoint2DEntity());

            foreach (var line in Lines)
                result.Shapes.Add(line.ToShape2DEntity());

            foreach (var arc in Arcs)
                result.Shapes.Add(arc.ToShape2DEntity());

            foreach (var path in Paths)
                result.Paths.Add(path.ToPath2DEntity());

            foreach (var text in Texts)
                result.Texts.Add(text.ToTextEntity());

            foreach (var image in Images)
                result.Images.Add(image.ToImageEntity());

            foreach (var dimension in Dimensions)
                result.Dimensions.Add(dimension.ToDimensionEntity());

            return result;
           
        }

        public static Drawing2DDto FromDrawing2D(IDrawing2D drawing)
        {
            var result = new Drawing2DDto();
            result.Points.AddRange(drawing.Points.Select(p => Point2DEntityDto.FromPoint2DEntity(p)));
            result.Lines.AddRange(drawing.Shapes.Where(s => s.Shape is ILine2D).Select(l => Line2DEntityDto.FromLine2DEntity(l)));
            result.Arcs.AddRange(drawing.Shapes.Where(s => s.Shape is IArc2D).Select(l => Arc2DEntityDto.FromArc2DEntity(l)));
            result.Paths.AddRange(drawing.Paths.Select(p=>Path2DEntityDto.FromPath2DEntity(p)));
            result.Texts.AddRange(drawing.Texts.Select(t => TextEntityDto.FromTextEntity(t)));
            result.Images.AddRange(drawing.Images.Select(i=> ImageEntityDto.FromImageEntity(i)));
            result.Dimensions.AddRange(drawing.Dimensions.Select(d => DimensionEntityDto.FromDimensionEntity(d)));
            return result;
        }
    }
}
