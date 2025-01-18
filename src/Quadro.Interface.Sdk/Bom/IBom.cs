using Quadro.Interface.Common;

namespace Quadro.Interface.Bom
{
	public interface IBom
    {
        IProjectHeader? ProjectHeader { get; }
        IEnumerable<IBomItem> Items { get; }
    }
}
