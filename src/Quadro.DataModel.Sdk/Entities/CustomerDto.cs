using Quadro.Globalization.Attributes;
using Quadro.Interface.Customers;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Customers
{
    public class CustomerDto : StorableGuid, ICustomerEntity
    {
        public string? ERPId { get; set; }

        [Header("Name", Globalization.Language.en)]
        [Header("Naam", Globalization.Language.nl)]
        public string Name { get; set; } = string.Empty;

        public string? PriceListId { get; set; }
    }
}
