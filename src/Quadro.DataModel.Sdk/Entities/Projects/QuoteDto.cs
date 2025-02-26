using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Projects
{
    public class QuoteDto : StorableGuid, IQuoteDto
	{
		public QuoteDto() { }

        [Header("Index", Globalization.Language.en)]
        [Header("Index", Globalization.Language.nl)]
        public int Index { get; set; }

        [Header("Name", Globalization.Language.en)]
        [Header("Naam", Globalization.Language.nl)]
        public string? Name { get; set; }

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

        [Header("Cost price", Globalization.Language.en)]
        [Header("Kostprijs", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Euro)]
        public double CostPrice { get; set; }

        [Header("Whole sale discount", Globalization.Language.en)]
        [Header("Handelskorting", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Percentage)]
        public double WholeSaleDiscount { get; set; }

        [Header("Gross sales price", Globalization.Language.en)]
        [Header("Bruto verkoopprijs", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Euro)]
        public double GrossSalesPrice { get; set; }

        [Header("Net. sales price", Globalization.Language.en)]
        [Header("Netto verkoopprijs", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Euro)]
        public double SalesPrice { get; set; }

		[JsonIgnore]
		public IEnumerable<IQuoteOrderLine> Lines => lines;

		[Header("Order lines", Globalization.Language.en)]
		[Header("Orderregels", Globalization.Language.nl)]
		public List<QuoteLineDto> lines { get; set; } = new List<QuoteLineDto>();
	}
}
