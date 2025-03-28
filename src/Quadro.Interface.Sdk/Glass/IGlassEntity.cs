using Quadro.Globalization.Attributes;
using Quadro.Interface.Solutions;

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
        public string? ColorId { get; set; }
        public double MaxWidth { get; set; }
        public double MaxHeight { get; set; }
        bool IsWebReleased { get; set; }
		FastSelectionGlassConfig GlassConfig { get; set; }
        double RwValue { get; set; }
        double RwCtrValue { get; set; }
        double UValue { get; set; }
        double LTAValue { get; set; }
        double ZTAValue { get; set; }
        double GValue { get; set; }
        double FireProofTime { get; set; }
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
