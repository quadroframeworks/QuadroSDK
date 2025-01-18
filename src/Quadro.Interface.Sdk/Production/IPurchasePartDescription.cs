using Quadro.Base.Catalog;
using Quadro.Interface.Catalog;
using Quadro.Interface.Enums;
using Quadro.Interface.Sills;

namespace Quadro.Interface.Production
{
	public interface IPurchasePartDescription
    {
        public bool SelectedForPo { get; set; }
        public string ManufacturingOrderId { get; set; }
        public string? ProductionFrameId { get; }
        public string? MainAssemblyModelId { get; } 
        public string? FrameItemModelId { get; }
        public string Name { get;}
        public string Description { get; }
        public string FrameTag { get; }
        public ProductionPartType PartType { get; }
        public SillPartType SillPartType { get; }
        string? SupplierId { get; }
        public CatalogItemType Type { get;}
        public StockType StockType { get; }
        public Unit Unit { get; }
        public double Quantity { get; }
        public bool Mirrored { get; }
        string CatalogItemId { get; }

    }
}
