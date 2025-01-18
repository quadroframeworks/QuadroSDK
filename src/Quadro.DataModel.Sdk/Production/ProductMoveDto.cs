using Quadro.Interface.Production;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Production
{
	public class ProductMoveDto : StorableGuid, IProductMoveDescription
    {
        public string? ProductionFrameId { get; set; }
        public string? ProductionPartId { get; set; }
        public string FromStationId { get; set; } = null!;
        public string ToStationId { get; set; } = null!;
    }
}
