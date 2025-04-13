using Quadro.Interface.Context;
using Quadro.Interface.CustomProperties;

namespace Quadro.Interface.RawFrames
{
	public interface IRawFrameEntity : ICustomizable
    {
        string Id { get; }
        string Name { get; }
        string WireFrameId { get; }
        bool AllowFilling { get; }
        bool AllowSill { get; }
        FrameContextType ContextType { get; } //Used for filtering
        IEnumerable<IPartConfiguration> Parts { get; }
        IEnumerable<IPartConfiguration> AdditionalParts { get; }
        IEnumerable<IRawFrameFilling> Fillings { get; }
    }

  


}
