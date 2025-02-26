using Quadro.Interface.Catalog;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Catalog
{
    public class CatalogSubItem : StorableGuid, ICatalogSubItem
    {
        public string? CatalogItemId { get; set; }
        public bool EnableRange { get; set; }
        public double QuantityFrom { get; set; }
        public double QuantityTo { get; set; }
    }
}
