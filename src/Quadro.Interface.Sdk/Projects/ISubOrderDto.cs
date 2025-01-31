namespace Quadro.Interface.Projects
{
	public interface ISubOrderDto
    {
        public IEnumerable<ISubOrderLine> Lines { get; }
    }
}
