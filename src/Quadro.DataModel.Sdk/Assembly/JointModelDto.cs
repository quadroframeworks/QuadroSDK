using Quadro.DataModel.Geometrics;
using Quadro.Interface.Enums;
using Quadro.Interface.RawFrames;
using Quadro.Interface.WireFrames;

namespace Quadro.DataModel.Model
{
	public class JointModelDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public WireIdentifier LocalWireId { get; set; }
        public WireIdentifier NeighbourWireId { get; set; }
        public PartIdentifier LocalPartId { get; set; }
        public PartIdentifier NeighbourPartId { get; set; }
        public Plane3DDto FurthestPlanePartSpace { get; set; } = null!;
        public Plane3DDto ClosestPlanePartSpace { get; set; } = null!;
    }

    public class LJointModelDto:JointModelDto
    {
        public PartSegmentSide LocalSide { get; set; }
        public PartSegmentSide NeighbourSide { get; set; }
        public WireAnchor LocalAnchor { get; set; }
        public WireAnchor NeighbourAnchor { get; set; }
        public int LocalSegmentId { get; set; }
        public int NeighbourSegmentId { get; set; }
    }

    public class LJointExtendedModelDto : LJointModelDto
    {

    }

    public class LJointEndModelDto : LJointModelDto
    {
        public Matrix3DDto JointToPartTransform { get; set; } = null!;
        public DowelSectionModelDto? DowelSection { get; set; }
    }

    public class TJointExtendedModelDto : JointModelDto
    {
        public double ProfileWidth { get; set; }
        public Plane3DDto JointPlaneRight { get; set; } = null!;
        public Plane3DDto JointPlaneLeft { get; set; } = null!;
        public Matrix3DDto JointToPartTransform { get; set; } = null!;
        public WireAnchor NeighbourAnchor { get; set; }
        public PartSegmentSide LocalSide { get; set; }
        public int LocalSegmentTowardsStartId { get; set; }
        public int LocalSegmentTowardsEndId { get; set; }
        public int NeighbourSegmentId { get; set; }
        public string? RabbetSwitchProgramId { get; set; }
        public double RabbetSwitchWidth { get; set; }
        public bool RabbetSwitchMirrored { get; set; }
    }

    public class TJointEndModelDto : JointModelDto
    {
        public WireAnchor LocalAnchor { get; set; }
        public PartSegmentSide NeighbourSide { get; set; }
        public int NeighbourSegmentTowardsStartId { get; set; }
        public int NeighbourSegmentTowardsEndId { get; set; }
        public int LocalSegmentId { get; set; }
        public Matrix3DDto JointToPartTransform { get; set; } = null!;
        public DowelSectionModelDto? DowelSection { get; set; }
    }


    public class DowelJointModelDto : JointModelDto
    {
        public WireAnchor LocalAnchor { get; set; }
        public Matrix3DDto JointToPartTransform { get; set; } = null!;
        public DowelSectionModelDto? DowelSection { get; set; }
    }
}
