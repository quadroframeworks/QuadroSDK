using CPBase.Geo.Media;
using CPBase.Shapes;
using Quadro.Interface.Context;
using Quadro.Interface.Enums;
using Quadro.Interface.RawFrames;

namespace Quadro.Interface.Profiles
{
	public interface ICompiledProfileStyle
    {
        FrameContextType ContextType { get; } //Target type, to be looked up in model tree
        FramePartType PartType { get; } //Applies to all parts of this type
        FrameSegmentSide FrameSegmentSide { get; } //Applies to this segment side
        string? CatalogItemId { get; }
        IList<CompiledProfilePropertySetter> Setters { get; }
    }

    public class CompiledProfilePropertySetter
    {
        public CompiledProfilePropertySetter() { }
        public bool Enabled { get; set; }
        public string SetterHandleId { get; set; } = null!;
        public string? ProfileStyleId { get; set; }
        public string? Name { get; set; }
        public ProfileProperty Property { get; set; }
        public OriginRef Reference { get; set; }
        public double Value { get; set; }
        public Point Origin { get; set; }
        public IPathShape2D? CutContour { get; set; }
    }

}
