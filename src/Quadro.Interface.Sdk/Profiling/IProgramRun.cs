namespace Quadro.Interface.Profiling
{
	public interface IProgramRun
    {
        string Id { get; }
        double Angle { get; set; }
        bool FlipRefPoint { get; set; }
        int Order { get; set; }
        string? RefPointId { get; set; }
        string? ToolId { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}