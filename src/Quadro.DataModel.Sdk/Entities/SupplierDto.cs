using Quadro.Globalization.Attributes;
using Quadro.Interface.Catalog;
using Quadro.Interface.Suppliers;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Projects
{
    public class SupplierDto : StorableGuid, ISupplierEntity
	{
		public string? ERPId { get; set; } = null!;

		[Header("Name", Globalization.Language.en)]
		[Header("Naam", Globalization.Language.nl)]
		public string Name { get; set; } = string.Empty;

        [JsonIgnore]
		public IEnumerable<ISupplierProductGroup> ProductGroups => productGroups;
        [Header("Product groups", Globalization.Language.en)]
        [Header("Productgroepen", Globalization.Language.nl)]
        public List<SupplierProductGroup> productGroups { get; set; } = new List<SupplierProductGroup>();
	}



	public class SupplierProductGroup : StorableGuid, ISupplierProductGroup
	{
		[Header("Type", Globalization.Language.en)]
		[Header("Type", Globalization.Language.nl)]
		public CatalogItemType GroupType { get; set; }

		[Header("Protocol", Globalization.Language.en)]
		[Header("Protocol", Globalization.Language.nl)]
		public string OutputProtocol { get; set; } = string.Empty;

		[Header("Preferred", Globalization.Language.en)]
		[Header("Voorkeur", Globalization.Language.nl)]
		public bool Preferred { get; set; }
	}
}
