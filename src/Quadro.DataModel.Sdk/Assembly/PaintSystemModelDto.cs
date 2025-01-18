using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
    public class PaintSystemModelDto
    {
        public string Name { get; set; } = string.Empty;
        public PaintModelDto? Primer { get; set; }
        public PaintModelDto? PreCoat { get; set; }
        public PaintModelDto? TopCoat { get; set; }

    }
}
