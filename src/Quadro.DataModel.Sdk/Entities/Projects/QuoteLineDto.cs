using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;

namespace Quadro.DataModel.Entities.Projects
{
    public class QuoteLineDto : LineBase, IQuoteOrderLine
	{
		[Header("Bom id", Globalization.Language.en)]
		[Header("Bom id", Globalization.Language.nl)]
		public string BomId { get; set; } = null!;

		[Header("Cost price", Globalization.Language.en)]
		[Header("Kostprijs", Globalization.Language.nl)]
		[Unit(Base.Catalog.Unit.Euro)]
		public double UnitCostPrice { get; set; }

		[Header("Sales price", Globalization.Language.en)]
		[Header("Verkoopprijs", Globalization.Language.nl)]
		[Unit(Base.Catalog.Unit.Euro)]
		public double UnitSalesPrice { get; set; }

		[Header("Description", Globalization.Language.en)]
		[Header("Omschrijving", Globalization.Language.nl)]
		public string Description { get; set; } = string.Empty;
	}
}
