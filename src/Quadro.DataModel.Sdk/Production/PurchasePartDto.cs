using Quadro.Base.Catalog;
using Quadro.Interface.Catalog;
using Quadro.Interface.Enums;
using Quadro.Interface.Production;
using Quadro.Interface.Sills;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Production
{
	public class PurchasePartDto : StorableGuid, IPurchasePartDescription
    {
        public PurchasePartDto() { }
        public bool SelectedForPo { get; set; }
        public string ManufacturingOrderId { get; set; } = null!;
        public string? ProductionFrameId { get; set; }
        public string? MainAssemblyModelId { get; set; }
        public string? FrameItemModelId { get; set; }  //Could be frame part, glass or plate
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string FrameTag { get; set; } = null!;
        public string? SupplierId { get; set; }
        public CatalogItemType Type { get; set; }
        public StockType StockType { get; set; }
        public ProductionPartType PartType { get; set; }
        public SillPartType SillPartType { get; set; }
        public Unit Unit { get; set; }
        public double Quantity { get; set; }
        public string CatalogItemId { get; set; } = null!;
        public bool Mirrored { get; set; }
    }
}
