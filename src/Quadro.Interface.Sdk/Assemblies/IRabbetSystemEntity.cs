using Quadro.Interface.Context;

namespace Quadro.Interface.Assemblies
{

	public interface IRabbetSystemEntity
    {
        string Id { get; }
        string Name { get; }
        FrameContextType ContextType { get; }
        FillingTurnConfiguration TurnConfig { get; }
        IEnumerable<IRabbetSelection> Selections { get; }
    }

    public interface IRabbetSelection
    {
        string Id { get; }
        string Name { get; }
        string? ProfileProgramIdLeft { get; set; }
        string? ProfileProgramIdRight { get; set; }
        string? ProfileProgramIdTop { get; set; }
        string? ProfileProgramIdBottom { get; set; }
        string? SillId { get; set; }
        string ExpressionEnable { get; set; }
    }

}
