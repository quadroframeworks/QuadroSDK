using Quadro.Globalization.Attributes;

namespace Quadro.Interface.Orders
{
	public interface IQuoteDto
    {
		public int Index { get; set; }
		public string? Name { get; set; }
		string? ERPCreationDate { get; set; }
        string? ERPId { get; set; }
        string? ERPLink { get; set; }
        string? ERPName { get; set; }
		double CostPrice { get; set; }
		double WholeSaleDiscount { get; set; }
		double GrossSalesPrice { get; set; }
		double SalesPrice { get; set; }

		IEnumerable<IQuoteOrderLine> Lines { get; }
    }
}