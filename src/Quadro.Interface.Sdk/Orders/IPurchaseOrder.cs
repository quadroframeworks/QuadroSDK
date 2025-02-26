using Quadro.Base.Catalog;

namespace Quadro.Interface.Orders
{
	public interface IPurchaseOrder
    {
        string Id { get; }
        string? ERPCreationDate { get; set; } //For ERP to fill
        string? ERPId { get; set; } //For ERP to fill
        string? ERPLink { get; set; } //For ERP to fill
        string? ERPName { get; set; } //For ERP to fill
        string ERPSupplierId { get; }
        IEnumerable<IPurchaseOrderLine> Lines { get; }
    }

    public interface IPurchaseOrderLine
    {
        string CatalogItemId { get; set; }  
        string Name { get; set; }
        string Description { get; set; }
        public Unit Unit { get; }
        public double Quantity { get; }
    }
}
