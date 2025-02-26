using Quadro.Base.Catalog;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Catalog;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Catalog
{

    public class CatalogItemDto : StorableGuid, ICatalogItemDescription, IStorable
	{
		public CatalogItemDto() { }
        public string? CatalogItemGroupId { get; set; }
        public CatalogItemType Type { get; set; }
		public StockType StockType { get; set; }
		public Unit Unit { get; set; }
		public string Name { get; set; } = "?";
		public string Description { get; set; } = "";
        public bool ForceQuantityOne { get; set; }

        [Unit(Unit.Euro)]
		public double UnitCost { get; set; }

		[Unit(Unit.Percentage)]
		public double WastePercentage { get; set; }

        public string? Color { get; set; }
		public string? ERPId { get; set; }

		[JsonIgnore]
		public IEnumerable<IWorkProcessTime> ProcessTimes => processTimes;
		public List<WorkProcessTime> processTimes { get; set; } = new List<WorkProcessTime>();

        [JsonIgnore]
        public IEnumerable<ICatalogSubItem> SubItems => subItems;
        public List<CatalogSubItem> subItems { get; set; } = new List<CatalogSubItem>();

        public override string ToString() => $"{Name}";

	}


}
