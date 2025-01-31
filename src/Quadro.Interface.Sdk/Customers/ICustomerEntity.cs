using Quadro.Interface.Projects;

namespace Quadro.Interface.Customers
{
	public interface ICustomerEntity : IRelation
    {
        string? PriceListId { get; set; }
    }
}