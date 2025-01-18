namespace Quadro.Interface.Dowels
{
	public interface IDowelProgramDescription
    {
        string Id { get; }
        string Name { get; set; }
        string? DowelApplicationId { get; }

        double TestProfileWidth { get; }
        double TestProfileHeight { get; }

        string? TestProgramIdLeft { get; set; }
        string? TestProgramIdRight { get; set; }

        string? TestProgramIdLeftXJoint { get; set; }
        string? TestProgramIdRightXJoint { get; set; }

        double ContraBottomHeight { get; set; }

        IEnumerable<IDowelPlacement> DowelPlacements { get; }
    }

    public enum DowelProgramReference
    {
        Mid,
        Left,
        Right,
    }
}