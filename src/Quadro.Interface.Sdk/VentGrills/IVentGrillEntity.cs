using CPBase.Shapes;

namespace Quadro.Interface.VentGrills
{
	public interface IVentGrillEntity
    {
        string Id { get; }
        string Name { get; }
        double GlassOffsetCorrection { get; }
        double RabbetOffset { get; }
        bool IsWebReleased { get; set; }
        IEnumerable<IVentGrillVariant> Variants { get; }
        IEnumerable<IVentGrillSection> Sections { get; }
    }

    public interface IVentGrillVariant
    {
        string Id { get; }
        string? CatalogItemId { get; }
        double GlassThickness { get; }
        string? ColorId { get; }
        string? SectionId { get; }

    }

    public interface IVentGrillSection
    {
        string Id { get; }
        string Name { get; }
        double OffsetX { get; }
        double OffsetY { get; }
        IPathShape2D? OuterContour { get; }
        IEnumerable<IPathShape2D>? InnerContours { get; }
    }
}
