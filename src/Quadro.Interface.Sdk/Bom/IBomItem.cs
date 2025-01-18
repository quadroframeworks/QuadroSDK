using Quadro.Base.Catalog;
using Quadro.Interface.Catalog;

namespace Quadro.Interface.Bom
{
	public interface IBomItem
    {
        CatalogItemType Type { get; }
        string Name { get; }    
        string Description { get; }
		string? CatalogItemId { get; }
		string? CataLogItemErpId { get; }
		public StockType StockType { get; }
		public double Quantity { get; }
		public Unit Unit { get; set; }
		double TotalCostPrice { get; }
		TimeSpan TotalProductionTime { get; }
		IEnumerable<IBomItemWorkCenterTime> WorkCenterTimes { get; }
        IEnumerable<IBomItem> Children { get; }
    }

    public interface IBomItemWorkCenterTime
    {
        string WorkCenterId { get; }
        string WorkCenter { get; }
        TimeSpan ProductionTime { get; }
    }
}
