using Quadro.DataModel.Common;
using Quadro.DataModel.Geometrics;
using Quadro.Interface.RawFrames;
using Quadro.Interface.WireFrames;

namespace Quadro.DataModel.Model
{
	public class FramePartModelDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Hash { get; set; }
        public string? Name { get; set; }
        public string? SubFrameHandleId { get; set; }
        public string? PartConfigHandleId { get; set; }
        public string? WireOffsetHandleId { get; set; }
        public string? RabbetHandleId { get; set; }
        public PartInfoDto PartConfiguration { get; set; } = null!;
        public FramePartProfileConfig ProfileType { get; set; }
        public PartIdentifier PartId { get; set; }
        public WireIdentifier WireId { get; set; }
        public List<PartSegmentModelDto> Segments { get; set; } = new List<PartSegmentModelDto> { };
        public List<PartEndingSegmentModelDto> StartSegments { get; set; }= new List<PartEndingSegmentModelDto>() { };
        public List<PartEndingSegmentModelDto> EndSegments { get; set; } = new List<PartEndingSegmentModelDto>() { };
        public List<TJointExtendedModelDto> TJointsExtended { get; set; } = new List<TJointExtendedModelDto> { };
        public List<PartOperationModelDto> Operations { get; set; } = new List<PartOperationModelDto> { };
        public Matrix3DDto PartToWireTransform { get; set; } = null!;
        public Matrix3DDto PartToFrameTransform { get; set; } = null!;
        public Matrix3DDto WireToPartTransform { get; set; } = null!;
        public Matrix3DDto FrameToPartTransform { get; set; } = null!;
        public double ActualHeight { get; set; }
        public double ActualWidth { get; set; }
        public List<Shape3DDto> BoundShapesStart { get; set; } = new List<Shape3DDto>();
        public List<Shape3DDto> BoundShapesEnd { get; set; } = new List<Shape3DDto>();
        public List<Shape3DDto> BoundShapesRight { get; set; } = new List<Shape3DDto>();
        public List<Shape3DDto> BoundShapesLeft { get; set; }= new List<Shape3DDto>();
        public Rect3DDto Bounds { get; set; } = null!;
        public bool AllProgramsAppliedAsDesigned { get; set; }
        public bool AllProgramsAppliedAsFlipped { get; set; }
        public ColorDto? Color { get; set; }
    }
}


