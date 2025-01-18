using Quadro.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Common
{
    public class ProjectHeader:IProjectHeader
    {
        public ProjectHeader() { }
        public string ProjectName { get; set; } = null!;
        public string ProjectNumber { get; set; } = null!;
        public string Customer { get; set; } = null!;
    }
}
