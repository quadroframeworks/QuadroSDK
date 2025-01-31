namespace Quadro.Interface.Orders
{
	public interface IManufacturingOrder
    {
        string Id { get; }
		public int BatchNumber { get; set; }
		string? ERPCreationDate { get; set; } //For ERP to fill
        string? ERPId { get; set; } //For ERP to fill
        string? ERPLink { get; set; } //For ERP to fill
        string? ERPName { get; set; } //For ERP to fill
        string? ProductionId { get; set; } //For production management to fill
		public string? SubOrderId { get; set; }
		public int SubOrderIndex { get; set; }
		IEnumerable<IManufacturingOrderLine> Lines { get; }

    }
}