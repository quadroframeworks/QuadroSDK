using Quadro.Interface.Bom;
using Quadro.Interface.Common;
using Quadro.DataModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Bom
{
	public class BomModelDto : StorableGuid, IBom
    {
        public BomModelDto() { }
        [JsonIgnore]
        public IProjectHeader? ProjectHeader => projectHeader;
        public ProjectHeader? projectHeader { get; set; }

        public string Tag { get; set; } = null!;

        [JsonIgnore]
        public IEnumerable<IBomItem> Items => items;
        public List<BomItemModelDto> items { get; set; } = new List<BomItemModelDto>();
        public double TotalCostPrice { get; set; }
		public double TotalSalesPrice { get; set; }
		public TimeSpan TotalProductionTime { get; set; }
    }
}
