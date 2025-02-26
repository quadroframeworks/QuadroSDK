using Quadro.Interface.Projects;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Projects
{
    public class PurchaseOrderDto : StorableGuid, IPurchaseOrder
	{
		public string? ERPCreationDate { get; set; }
		public string? ERPId { get; set; }
		public string? ERPLink { get; set; }
		public string? ERPName { get; set; }
		public string ERPSupplierId { get; set; } = null!;

		[JsonIgnore]
		public IEnumerable<IPurchaseOrderLine> Lines => lines;
		public List<PurchaseOrderDtoLine> lines { get; set; } = new List<PurchaseOrderDtoLine>();
	}


}
