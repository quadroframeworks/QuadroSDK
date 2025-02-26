using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Projects
{
    public class ManufacturingOrderDto : StorableGuid, IManufacturingOrder
	{

        public ManufacturingOrderDto() { }

        [Header("Batch number", Globalization.Language.en)]
        [Header("Batchnummer", Globalization.Language.nl)]
        public int BatchNumber { get; set; }

		[Header("ERP name", Globalization.Language.en)]
		[Header("ERP naam", Globalization.Language.nl)]
		public string? ERPName { get; set; }

		[Header("ERP id", Globalization.Language.en)]
		[Header("ERP id", Globalization.Language.nl)]
		public string? ERPId { get; set; }

		[Header("ERP link", Globalization.Language.en)]
		[Header("ERP link", Globalization.Language.nl)]
		public string? ERPLink { get; set; }

		[Header("ERP creation date", Globalization.Language.en)]
		[Header("ERP aanmaak datum", Globalization.Language.nl)]
		public string? ERPCreationDate { get; set; }

		[Header("Production id", Globalization.Language.en)]
		[Header("Productie id", Globalization.Language.nl)]
		public string? ProductionId { get; set; }

        [Header("Sub order", Globalization.Language.en)]
        [Header("Deelorder", Globalization.Language.nl)]
        public string? SubOrderId { get; set; }

        [Header("Sub order index", Globalization.Language.en)]
        [Header("Deelorder index", Globalization.Language.nl)]
        public int SubOrderIndex { get; set; }

        [JsonIgnore]
		public IEnumerable<IManufacturingOrderLine> Lines => lines;
		[Header("Order lines", Globalization.Language.en)]
		[Header("Orderregels", Globalization.Language.nl)]
		public List<ManufacturingOrderLineDto> lines { get; set; } = new List<ManufacturingOrderLineDto>();
	}
}
