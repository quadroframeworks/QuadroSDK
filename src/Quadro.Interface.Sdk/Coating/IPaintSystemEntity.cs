namespace Quadro.Interface.Coating
{
	public interface IPaintSystemEntity
    {
        string Name { get; }
        string? PrimerId { get; }
        double LayerThicknessPrimer { get; } //In micrometers
        int NrOfLayersPrimer { get; }
        string? PreCoatId { get; }
        double LayerThicknessPreCoat { get; } //In micrometers
        int NrOfLayersPreCoat { get; }
        string? TopCoatId { get; }
        double LayerThicknessTopCoat { get; } //In micrometers
        int NrOfLayersTopCoat { get; }
        bool IsWebReleased { get; }
    }
}
