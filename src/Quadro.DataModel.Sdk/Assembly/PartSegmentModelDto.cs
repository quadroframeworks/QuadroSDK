using Quadro.Interface.Enums;
using Quadro.Interface.WireFrames;
using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
    public class PartSegmentModelDto
    {
        public PartSegmentModelDto() { }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? SubFrameHandleId { get; set; }
        public string? PartConfigHandleId { get; set; }
        public string? WireOffsetHandleId { get; set; }
        public string? RabbetHandleId { get; set; }
        public List<int> SectionIds { get; set; } = new List<int>();
        public double ActualHeight { get; set; }
        public double ActualWidth { get; set; }
        public double Length { get; set; }
        public WireIdentifier WireId { get; set; }
        public int WireSegmentIndex { get; set; }
        public bool IsArc { get; set; }
        public bool IsArcCcw { get; set; }
        public Point3DDto StartPointOnWire { get; set; } = null!;
        public Point3DDto EndPointOnWire { get; set; } = null!;
        public JointModelDto? StartJoint { get; set; }
        public JointModelDto? EndJoint { get; set; }
        public Matrix3DDto SegmentToPartTransform { get; set; } = null!;
        public Matrix3DDto SegmentToFrameTransform { get; set; } = null!;
        public Matrix3DDto? SegmentLeftToPartTransform { get; set; } = null!;
        public Matrix3DDto? SegmentLeftToFrameTransform { get; set; } = null!;
        public Path2DDto CrossSection { get; set; } = null!;
        public List<Path2DDto> CrossSectionsInner { get; set; } = new List<Path2DDto>();
        public Path2DDto? ContourLeft { get; set; }= null!;
        public Path2DDto? ContourRight {  get; set; } = null!;
        public Shape3DDto? ArcRight { get; set; }
        public Shape3DDto? ArcLeft { get; set; }
        public string? ProfileProgramIdLeft { get; set; }
        public string? ProfileProgramNameLeft { get; set; }
        public string? ProfileProgramIdRight { get; set; }
        public string? ProfileProgramNameRight { get; set; }
        public bool ProgramsFlipped { get; set; }
        public string? SingleProfileId { get; set; }
        public string? SingleProfileName { get; set; }
        public List<AppliedProfileStyleDto> AppliedStyles { get; set; } = new List<AppliedProfileStyleDto>();

    }
}
