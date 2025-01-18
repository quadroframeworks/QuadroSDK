namespace Quadro.Interface.Orders
{
	public interface IQuoteDto
    {
        string? ERPCreationDate { get; set; }
        string? ERPId { get; set; }
        string? ERPLink { get; set; }
        string? ERPName { get; set; }
        IEnumerable<IQuoteOrderLine> Lines { get; }
    }
}