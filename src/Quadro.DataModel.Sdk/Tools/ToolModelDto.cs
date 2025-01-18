using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model.Tools
{
    public class ToolModelDto
    {
        public string ToolId { get; set; } = null!;
        public int Index { get; set; } 
        public Path2DDto Contour { get; set; } = null!;
        public List<ReferencePointModelDto> ReferencePoints { get; set; }   = new List<ReferencePointModelDto>();
        public List<ToolMappingModelDto> ToolMappings { get; set; } = new List<ToolMappingModelDto>();

    }
}
