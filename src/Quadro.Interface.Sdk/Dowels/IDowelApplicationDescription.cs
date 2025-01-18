namespace Quadro.Interface.Dowels
{

	public interface IDowelApplicationDescription
    {
        string Id { get; set; }
        string? CatalogItemId { get; }
        public string Description { get; set; }
        DowelApplicationMode Mode { get; }
        string? SemiAutoDowelProgramId { get; }
        string DowelId { get; }
        double HoleDepthSpacing { get; } //Per side
        double HoleDiameterSpacing { get; }
        double SideCoverMin { get; }
        double SideCoverMax { get; }
        double ContraCoverMin { get; }
        double ContraOffsetMax { get; }
        double ContraRabbetOffset { get; set; }
        bool AllowSnapToRabbet { get; set; }
        bool AvoidRabbet { get; set; }
        IEnumerable<IDowelApplicationProgram> Programs { get; }

    }

    public enum DowelApplicationMode
    {
        FullAuto = 0,
        SemiAuto = 1,
    }

    public interface IDowelApplicationProgram
    {
        string? ProgramIdLeft { get; }
        string? ProgramIdRight { get; }
        string? ProgramIdLeftXJoint { get; }
        string? ProgramIdRightXJoint { get; }
        string? ProgramIdContra { get; }
        string? DowelProgramId { get; }
        bool Checked { get; set; }
    }


}
