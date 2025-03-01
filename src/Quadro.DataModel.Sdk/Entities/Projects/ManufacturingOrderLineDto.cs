using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;

namespace Quadro.DataModel.Entities.Projects
{
    public class ManufacturingOrderLineDto : LineBase, IManufacturingOrderLine
	{
		[Header("Bom id", Globalization.Language.en)]
		[Header("Bom id", Globalization.Language.nl)]
		public string? BomId { get; set; }

		[Header("State", Globalization.Language.en)]
		[Header("Status", Globalization.Language.nl)]
		public ManufacturingState State { get; set; }

		[Header("Delivery id", Globalization.Language.en)]
		[Header("Levering id", Globalization.Language.nl)]
		public string? DeliveryId { get; set; }

		[Header("Delivery index", Globalization.Language.en)]
		[Header("Levering index", Globalization.Language.nl)]
		public int DeliveryIndex { get; set; }
	}
}
