using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model.Tools
{
    public class ToolMappingModelDto
    {
        public string ToolMappingId { get; set; } = null!;
        public Point2DDto Position { get; set; } = null!;
        public Path2DDto? Contour { get; set; } = null!;
        public Matrix2DDto MappingToToolTransform { get; set; } = null!;

    }
}
