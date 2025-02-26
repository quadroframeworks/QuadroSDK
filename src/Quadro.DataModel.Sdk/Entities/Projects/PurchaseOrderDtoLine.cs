using Quadro.Base.Catalog;
using Quadro.Interface.Projects;

namespace Quadro.DataModel.Entities.Projects
{
    public class PurchaseOrderDtoLine : IPurchaseOrderLine
	{
		public string CatalogItemId { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public Unit Unit { get; set; }
		public double Quantity { get; set; }
	}
}
