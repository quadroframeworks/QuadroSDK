using Quadro.Interface.Context;
using Quadro.Interface.CustomProperties;

namespace Quadro.Interface.RawFrames
{
	public interface IRawFrameEntity : ICustomizable
    {
        string Id { get; }
        string Name { get; }
        string WireFrameId { get; }
        FrameContextType ContextType { get; } //Used for filtering
        IEnumerable<IFramePartDescription> Parts { get; }
    }

    public interface IRawFrameConfiguration : IRawFrameEntity
    {
        IEnumerable<IFramePartDescription> AdditionalParts { get; }
    }


}
