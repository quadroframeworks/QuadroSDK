using Quadro.DataModel.Geometrics;
using Quadro.Interface.Enums;
using Quadro.Interface.Profiles;

namespace Quadro.DataModel.Model
{
	public class SingleProfilePropertyDto
    {
        public ProfileProperty Property { get; set; }
        public Point2DDto Origin { get; set; } = null!;
        public Path2DDto? Shape { get; set; }
        public OriginRef Reference { get; set; }
        public PartSegmentSide SegmentSide { get; set; }

    }
}
