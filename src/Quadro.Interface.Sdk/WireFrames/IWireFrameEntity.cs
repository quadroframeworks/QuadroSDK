using Quadro.Interface.CustomProperties;

namespace Quadro.Interface.WireFrames
{

	public interface IWireFrameEntity : ICustomizable
    {
        string Id { get; }
        string Name { get; }
        IEnumerable<IWireDescription> Wires { get; }
        IEnumerable<IWireConstraint> Constraints { get; }

    }



}
