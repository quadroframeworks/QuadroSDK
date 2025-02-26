namespace Quadro.Interface.Glass
{
	public interface IGlassEntity
    {
        string Id { get; }
        string? CatalogItemId { get; }
        string Name { get; }
        double Thickness { get; }
        string LayerString { get; set; }
        string? GlassGroupId { get; set; }
        bool IsWebReleased { get; set; }
        bool Hardened { get; set; }
        bool Laminated { get; set; }
        double UValue { get; set; }
        double LTAValue { get; set; }
        double ZTAValue { get; set; }
        double GValue { get; set; }
        IEnumerable<IGlassLayer> Layers { get; }
    }

    public interface IGlassLayer
    {
        double Thickness { get; }
        GlassLayerType Type { get; }
    }

    public enum GlassLayerType
    {
        Glass = 0,
        Gas = 100,
        Laminate = 200,
    }
}
