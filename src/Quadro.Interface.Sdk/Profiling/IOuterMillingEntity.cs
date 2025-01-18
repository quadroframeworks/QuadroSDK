namespace Quadro.Interface.Profiling
{
	public interface IOuterMillingEntity
    {
        string? Name { get; }
        double Height { get; set; }
        string? ProfileProgramIdLeft { get; set; }
        string? ProfileProgramIdRight { get; set; }
        string? ProfileProgramIdTop { get; set; }
        string? ProfileProgramIdBottom { get; set; }

    }
}
