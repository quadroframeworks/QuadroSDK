using CPBase.Geo.Media.TwoD;
using CPBase.Shapes;

namespace Quadro.Interface.SingleProfiles
{
	public interface ISingleProfileEntity
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }
        public double Width { get; set; }
        public double Height { get; set; }
        string? CatalogItemId { get; }
        string? ColorId { get; }
        string MaterialId { get; }
        IPathShape2D? OuterContour { get; }
        IEnumerable<IPathShape2D>? InnerContours { get; }
        IDrawing2D? Section { get; }
        IPathShape2D? ProfileCut { get; }
        IEnumerable<ISingleProfileFixPartPlacement> FixParts { get; }

    }

    public interface ISingleProfileFixPartPlacement
    {
        string? HingeAndLockItemId { get; }
        double MaxSpacing { get; }
        double CornerOffset { get; }
        FixPartCornerReference CornerReference { get; }
        double OffsetX { get; }
        double OffsetY { get; }
        double RotationA { get; }
        double RotationB { get; }
        double RotationC { get; }

    }

    public enum FixPartCornerReference
    {
        Closest,
        Furthest,
    }
}
