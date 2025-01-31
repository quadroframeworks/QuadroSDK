namespace Quadro.Interface.Orders
{
	public interface IProjectEntity
    {
        string? CustomerId { get; set; }
        string ProjectDescription { get; set; }
        int ProjectNumber { get; set; }
        IEnumerable<IOrderLine> Lines { get; }
        IEnumerable<IQuoteDto> Quotes { get; }
        IEnumerable<IManufacturingOrder> ManufacturingOrders { get; }
        IEnumerable<ISubOrderDto> SubOrders { get; }
    }
}