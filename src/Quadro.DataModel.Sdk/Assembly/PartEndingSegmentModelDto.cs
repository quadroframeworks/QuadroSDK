using Quadro.DataModel.Geometrics;
using Quadro.Interface.Enums;
using Quadro.Interface.RawFrames;
using Quadro.Interface.WireFrames;

namespace Quadro.DataModel.Model
{
	public class PartEndingSegmentModelDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public WireAnchor Anchor { get; set; }
        public string? JointId { get; set; }
        public PartSegmentSide? NeighbourSide { get; set; }
        public Path2DDto Shape { get; set; } = null!;
        public Matrix3DDto SegmentToPartTransform { get; set; } = null!;
        public Matrix3DDto SegmentToFrameTransform { get; set; } = null!;
        public Plane3DDto BoundPlane { get; set; } = null!;
        public double BoundOffset { get; set; }
        public bool IsArc { get; set; }
        public Shape3DDto? BoundArcTop { get; set; }
        public Shape3DDto? BoundArcBottom { get; set; }
        public EndingType EndingType { get; set; }
        public string? ContraProgramId { get; set; }
        public string? ContraProgramName { get; set; }
        public bool ProgramsFlipped { get; set; }
        public List<LJointEndModelDto> LJointsEnd { get; set; } = new List<LJointEndModelDto> { };
        public List<LJointExtendedModelDto> LJointsExtended { get; set; } = new List<LJointExtendedModelDto> { };
        public List<TJointEndModelDto> TJointsEnd { get; set; } = new List<TJointEndModelDto> { };
        public List<DowelJointModelDto> DowelJoints { get; set; } = new List<DowelJointModelDto> { };

    }
}
