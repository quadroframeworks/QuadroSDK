using Quadro.Base.Catalog;
using Quadro.Interface.Bom;
using Quadro.Interface.Catalog;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Bom
{
    public class BomItemModelDto : IBomItem
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? CatalogItemId { get; set;}
        public string? CataLogItemErpId { get; set; }
        public CatalogItemType Type { get; set; }
		public StockType StockType { get; set; }
		public double Quantity { get; set; }
		public Unit Unit { get; set; }
		public double TotalCostPrice { get; set; }
        public double TotalSalesPrice { get; set; }
        public TimeSpan TotalProductionTime { get; set; }


		[JsonIgnore]
        public IEnumerable<IBomItemWorkCenterTime> WorkCenterTimes => workCentertimes;
        public List<WorkCenterTime> workCentertimes { get; set; } = new List<WorkCenterTime>();

        [JsonIgnore]
        public IEnumerable<IBomItem> Children => children;
        public List<BomItemModelDto> children { get; set; } = new List<BomItemModelDto>();

     
    }

    public class WorkCenterTime : IBomItemWorkCenterTime
    {
        public string WorkCenterId { get; set; } = null!;
        public string WorkCenter { get; set; } = null!;
        public TimeSpan ProductionTime { get; set; }
    }
}
