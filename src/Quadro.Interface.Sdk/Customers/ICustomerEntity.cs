using Quadro.Interface.Orders;

namespace Quadro.Interface.Customers
{
	public interface ICustomerEntity : IRelation
    {
        string? PriceListId { get; set; }
    }
}