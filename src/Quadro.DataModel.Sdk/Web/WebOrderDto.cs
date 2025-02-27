using Quadro.DataModel.Entities.Projects;
using Quadro.Globalization.Attributes;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Web
{
    public class WebOrderDto : StorableGuid
	{

        public WebOrderDto() { }

        [Header("User", Globalization.Language.en)]
        [Header("Gebruiker", Globalization.Language.nl)]
        public string? UserId { get; set; }

        [Header("Order number", Globalization.Language.en)]
		[Header("Ordernummer", Globalization.Language.nl)]
		public string OrderNumber { get; set; } = string.Empty;

		[Header("Description", Globalization.Language.en)]
		[Header("Omschrijving", Globalization.Language.nl)]
		public string OrderDescription { get; set; } = string.Empty;

		[Header("Customer", Globalization.Language.en)]
		[Header("Klant", Globalization.Language.nl)]
		public string? CustomerId { get; set; }

		[Header("State", Globalization.Language.en)]
		[Header("Status", Globalization.Language.nl)]
		public WebOrderState State { get; set; }

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

        [Obsolete]
		public string? DefaultBorderApplicationId { get; set; }

		[Header("Max. U-value", Globalization.Language.en)]
		[Header("Max. U-waarde", Globalization.Language.nl)]
		[Unit(Base.Catalog.Unit.Wperm2K)]
		public double DefaultMaxUValue { get; set; }

        [Header("Total price ex. vat", Globalization.Language.en)]
        [Header("Totaalprijs ex. btw", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Euro)]
        public double TotalPriceExVat { get; set; }

        [Header("Lines", Globalization.Language.en)]
		[Header("Regels", Globalization.Language.nl)]
		public List<WebOrderLine> lines { get; set; } = new List<WebOrderLine>();
	}


	public class WebOrderLine : LineBase
	{
		public string? WebFrameId { get; set; }
        public bool HasValidModel { get; set; }

        [Header("Description", Globalization.Language.en)]
		[Header("Omschrijving", Globalization.Language.nl)]
		public string Description { get; set; } = string.Empty;

        [Header("Price ex. vat", Globalization.Language.en)]
        [Header("Prijs ex. btw", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Euro)]
        public double UnitPriceExVat { get; set; }

    }

	public enum WebOrderState
	{
		Design = 0,
		ShoppingCart = 1,
		Ordered = 10,
		Production = 20,
		Shipped = 30,
		Delivered = 40,
	}

}
