using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;

namespace Quadro.DataModel.Entities.Projects
{
    public class OrderLineDto : LineBase, IOrderLine
	{
		public OrderLineDto() { }


		[Header("Solution id", Globalization.Language.en)]
		[Header("Configuratie id", Globalization.Language.nl)]
		public string SolutionId { get; set; } = null!;

		[Header("Selected for quote", Globalization.Language.en)]
		[Header("Selectie voor offerte", Globalization.Language.nl)]
		public bool IsSelectedForQuote { get; set; }

		[Header("Description", Globalization.Language.en)]
		[Header("Omschrijving", Globalization.Language.nl)]
		public string Description { get; set; } = string.Empty;
	}
}
