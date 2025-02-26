using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Projects
{
    public class SubOrderDto : StorableGuid, ISubOrderDto
	{

		[Header("Index", Globalization.Language.en)]
		[Header("Index", Globalization.Language.nl)]
		public int Index { get; set; }

		[Header("Description", Globalization.Language.en)]
		[Header("Omschrijving", Globalization.Language.nl)]
		public string? Description { get; set; }

        [JsonIgnore]
		public IEnumerable<ISubOrderLine> Lines => lines;
        [Header("Lines", Globalization.Language.en)]
        [Header("Regels", Globalization.Language.nl)]
        public List<SubOrderLineDto> lines { get; set; } = new List<SubOrderLineDto>();



	}


}
