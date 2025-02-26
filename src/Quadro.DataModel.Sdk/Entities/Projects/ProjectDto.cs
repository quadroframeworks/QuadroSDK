using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Projects
{
    public class ProjectDto : StorableGuid, IProjectEntity
	{
		public ProjectDto() { }

		[Header("Project number", Globalization.Language.en)]
		[Header("Projectnummer", Globalization.Language.nl)]
		public int ProjectNumber { get; set; }

		[Header("Description", Globalization.Language.en)]
		[Header("Omschrijving", Globalization.Language.nl)]
		public string ProjectDescription { get; set; } = string.Empty;

		[Header("Customer", Globalization.Language.en)]
		[Header("Klant", Globalization.Language.nl)]
		public string? CustomerId { get; set; }

        [Header("Color", Globalization.Language.en)]
        [Header("Kleur", Globalization.Language.nl)]
        public string? DefaultColorId { get; set; }

        [Header("Filling color", Globalization.Language.en)]
        [Header("Kleur vakvullingen", Globalization.Language.nl)]
        public string? DefaultFillingColorId { get; set; }

        [Header("Material", Globalization.Language.en)]
        [Header("Materiaal", Globalization.Language.nl)]
        public string? DefaultRawMaterialId { get; set; }

        [Header("Paint system", Globalization.Language.en)]
        [Header("Verfsysteem", Globalization.Language.nl)]
        public string? DefaultPaintSystemId { get; set; }

        [Header("Glass", Globalization.Language.en)]
        [Header("Glas", Globalization.Language.nl)]
        public string? DefaultGlassId { get; set; }

        [Header("Sill", Globalization.Language.en)]
        [Header("Onderdorpel", Globalization.Language.nl)]
        public bool DefaultApplySill { get; set; }

        [Header("Max. U-value", Globalization.Language.en)]
        [Header("Max. U-waarde", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Wperm2K)]
        public double DefaultMaxUValue { get; set; }

        [JsonIgnore]
		public IEnumerable<IOrderLine> Lines => lines;
		[Header("Order lines", Globalization.Language.en)]
		[Header("Orderregels", Globalization.Language.nl)]
		public List<OrderLineDto> lines { get; set; } = new List<OrderLineDto>();

		[JsonIgnore]
		public IEnumerable<IQuoteDto> Quotes => quotes;
		[Header("Quotes", Globalization.Language.en)]
		[Header("Offertes", Globalization.Language.nl)]
		public List<QuoteDto> quotes { get; set; } = new List<QuoteDto>();

        [JsonIgnore]
        public IEnumerable<ISubOrderDto> SubOrders => subOrders;
        [Header("Sub orders", Globalization.Language.en)]
        [Header("Deelorders", Globalization.Language.nl)]
        public List<SubOrderDto> subOrders { get; set; } = new List<SubOrderDto>();

        [JsonIgnore]
		public IEnumerable<IManufacturingOrder> ManufacturingOrders => manufacturingOrders;
		[Header("Manufacturing orders", Globalization.Language.en)]
		[Header("Werkorders", Globalization.Language.nl)]
		public List<ManufacturingOrderDto> manufacturingOrders { get; set; } = new List<ManufacturingOrderDto>();


        [JsonIgnore]
        public IEnumerable<IDelivery> Deliveries => deliveries;
        [Header("Deliveries", Globalization.Language.en)]
        [Header("Leveringen", Globalization.Language.nl)]
        public List<DeliveryDto> deliveries { get; set; } = new List<DeliveryDto>();
    }
}
