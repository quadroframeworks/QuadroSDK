namespace Quadro.Interface.Orders
{
	public interface IDelivery
    {
        string Id { get; }
        int Index { get; set; }
        string? Description { get; set; }
        string? ERPCreationDate { get; set; }
        string? ERPId { get; set; }
        string? ERPLink { get; set; }
        string? ERPName { get; set; }
        IEnumerable<IDeliveryLineDto> Lines { get; }
    }
}