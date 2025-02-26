namespace Quadro.Interface.Orders
{
	public interface ISubOrderDto
    {
        public IEnumerable<ISubOrderLine> Lines { get; }
    }
}
