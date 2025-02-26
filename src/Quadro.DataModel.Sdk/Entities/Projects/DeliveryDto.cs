using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Projects
{
    public class DeliveryDto : StorableGuid, IDelivery
	{
		public DeliveryDto() { }

		[Header("Index", Globalization.Language.en)]
		[Header("Index", Globalization.Language.nl)]
		public int Index { get; set; }

		[Header("Description", Globalization.Language.en)]
		[Header("Omschrijving", Globalization.Language.nl)]
		public string? Description { get; set; }

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

        [JsonIgnore]
		public IEnumerable<IDeliveryLineDto> Lines => lines;

        [Header("Lines", Globalization.Language.en)]
        [Header("Regels", Globalization.Language.nl)]
        public List<DeliveryLineDto> lines { get; set; } = new List<DeliveryLineDto>();

	}
}
