using Quadro.Interface.Catalog;
using Quadro.Interface.Orders;

namespace Quadro.Interface.Suppliers
{
	public interface ISupplierEntity : IRelation
    {
        IEnumerable<ISupplierProductGroup> ProductGroups { get; }
    }

    public interface ISupplierProductGroup
    {
        CatalogItemType GroupType { get; set; }
        string OutputProtocol { get; set; }
        bool Preferred { get; set; }
    }
}