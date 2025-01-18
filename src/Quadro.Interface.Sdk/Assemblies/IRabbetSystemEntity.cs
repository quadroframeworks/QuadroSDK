namespace Quadro.Interface.Assemblies
{

	public interface IRabbetSystemEntity
    {
        string Name { get; }
        IEnumerable<IRabbetSelection> Selections { get; }
    }

    public interface IRabbetSelection
    {
        string Id { get; }
        string Name { get; }
        double PartHeightLeft { get; }
        double PartHeightRight { get; }
        double PartHeightTop { get; }
        double PartHeightBottom { get; }

        double RabbetWidthZ { get; set; }

        double RabbetHeightYLeft { get; set; }
        double RabbetHeightYRight { get; set; }
        double RabbetHeightYTop { get; set; }
        double RabbetHeightYBottom { get; set; }

        string? ProfileProgramIdLeft { get; set; }
        string? ProfileProgramIdRight { get; set; }
        string? ProfileProgramIdTop { get; set; }
        string? ProfileProgramIdBottom { get; set; }
        string? SillId { get; set; }

        string ExpressionEnable { get; set; }
    }

}
