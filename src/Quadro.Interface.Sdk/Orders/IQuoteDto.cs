using Quadro.Globalization.Attributes;

namespace Quadro.Interface.Orders
{
	public interface IQuoteDto
    {
        string? ERPCreationDate { get; set; }
        string? ERPId { get; set; }
        string? ERPLink { get; set; }
        string? ERPName { get; set; }
		double WholeSaleDiscount { get; set; }
		double SalesPrice { get; set; }

		IEnumerable<IQuoteOrderLine> Lines { get; }
    }
}