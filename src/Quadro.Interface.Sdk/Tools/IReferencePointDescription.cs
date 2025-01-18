namespace Quadro.Interface.Tools
{
	public interface IReferencePointDescription
    {
        string Id { get; }
        int Index { get; }
        string? Description { get; set; }
        double GreatestDiameter { get; set; }
        double MaxPower { get; set; }
        double RPMMax { get; set; }
        double RPMNominal { get; set; }
        double SpeedApproach { get; set; }
        double SpeedProfiling { get; set; }
        double SpeedTenoning { get; set; }
        double SpeedTurnIn { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}