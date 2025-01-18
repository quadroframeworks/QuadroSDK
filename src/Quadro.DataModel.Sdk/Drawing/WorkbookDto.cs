using Quadro.DataModel.Common;
using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Drawing
{
    public class WorkbookDto
    {
        public ProjectHeader? ProjectHeader { get; set; }
        public List<WorkbookPageDto> Pages { get; set; } = new List<WorkbookPageDto>();
    }


    public class WorkbookPageDto
    {
        public Size2DDto PaperSize { get; set; } = null!;
        public Drawing2DDto Header { get; set; } = null!;
        public List<Drawing2DDto> Drawings { get; set; } = new List<Drawing2DDto>();

    }
}
