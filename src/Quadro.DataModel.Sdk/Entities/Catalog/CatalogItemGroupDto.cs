using Quadro.Globalization.Attributes;
using Quadro.Interface.Catalog;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Catalog
{
    public class CatalogItemGroupDto : StorableGuid, ICatalogItemGroup
    {
        public string Name { get; set; } = string.Empty;

        [Unit(Base.Catalog.Unit.Percentage)]
        public double SalesMargin { get; set; }
    }
}
