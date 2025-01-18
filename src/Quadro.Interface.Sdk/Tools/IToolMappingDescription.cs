using Quadro.Interface.Profiles;

namespace Quadro.Interface.Tools
{
	public interface IToolMappingDescription
    {
        string Id { get; }
        ProfileProperty Property { get; set; }
        ToolMappingOriginRef OriginRef { get; set; }
        bool Flipped { get; set; }
        bool FlipRefPoint { get; set; }
        string? RefPointId { get; set; }
        string? ProfileStyleId { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double Angle { get; set; }
        double ValueFrom { get; set; }
        double ValueTo { get; set; }
    }

    public enum ToolMappingOriginRef
    {
        Origin = 0,
        ShapeBottom = 1,
        ShapeTop = 2,
    }
}