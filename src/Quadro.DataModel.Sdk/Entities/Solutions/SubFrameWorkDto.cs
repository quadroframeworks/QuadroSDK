using Quadro.Interface.Solutions;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Entities.Solutions
{
    public class SubFrameWorkDto : StorableGuid, ISubFrameWork
    {
        public SubFrameWorkSide Side { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double OffsetZ { get; set; }
        public double OffsetBottom { get; set; }
        public double OffsetTop { get; set; }
        public double OffsetLeft { get; set; }
        public double OffsetRight { get; set; }
        public string? FrameWorkAssemblyId { get; set; }
    }
}
