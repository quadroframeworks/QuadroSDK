using Quadro.DataModel.Geometrics;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Common
{
    public class Thumbnail:StorableGuid
    {
        public Drawing2DDto? Drawing { get; set; }
        public string? Svg { get; set; }

    }
    
}
