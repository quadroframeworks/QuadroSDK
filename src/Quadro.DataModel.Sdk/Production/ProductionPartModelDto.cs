using Quadro.DataModel.Common;
using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using Quadro.Interface.Enums;
using Quadro.Interface.Production;
using Quadro.Interface.RawFrames;
using Quadro.Interface.WireFrames;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Production
{
	public class ProductionPartModelDto:StorableGuid
    {
        public string? Hash { get; set; }
        public string? Name { get; set; }
        public PartInfoDto PartConfiguration { get; set; } = null!;
        public PartIdentifier PartId { get; set; }
        public List<ProductionPartSegmentModelDto> Segments { get; set; } = new List<ProductionPartSegmentModelDto> { };
        public List<ProductionPartEndingSegmentModelDto> StartSegments { get; set; } = new List<ProductionPartEndingSegmentModelDto>() { };
        public List<ProductionPartEndingSegmentModelDto> EndSegments { get; set; } = new List<ProductionPartEndingSegmentModelDto>() { };
        public List<ProductionOperationModelDto> Operations { get; set; } = new List<ProductionOperationModelDto> { };
        public double Height { get; set; }
        public double Width { get; set; }
        public List<Shape3DDto> BoundShapesStart { get; set; } = new List<Shape3DDto>();
        public List<Shape3DDto> BoundShapesEnd { get; set; } = new List<Shape3DDto>();
        public List<Shape3DDto> BoundShapesRight { get; set; } = new List<Shape3DDto>();
        public List<Shape3DDto> BoundShapesLeft { get; set; } = new List<Shape3DDto>();
        public Rect3DDto Bounds { get; set; } = null!;
        public bool FlipApplied { get; set; }
        public ColorDto? Color { get; set; }
        public List<ProducablityMessage> Messages { get; set; } = new List<ProducablityMessage>();
       
    }

    public class ProducablityMessage
    {
        public ProducablityMessage() { }
        public ProducablityMessage(string message, ProducablityMessageSeverity severity)
        {
            this.Message = message;
            this.Severity = severity;
        }
        public string Message { get; set; } = null!;
        public ProducablityMessageSeverity Severity { get; set; }
    }

    public enum ProducablityMessageSeverity
    {
        Message,
        Warning,
        Error,
    }

    public class ProductionPartSegmentModelDto : StorableGuid
    {
        public List<int> SectionIds { get; set; } = new List<int>();
        public double ActualHeight { get; set; }
        public double ActualWidth { get; set; }
        public double Length { get; set; }
        public int WireSegmentIndex { get; set; }
        public bool IsArc { get; set; }
        public bool IsArcCcw { get; set; }
        public Matrix3DDto SegmentToPartTransform { get; set; } = null!;
        public Matrix3DDto? SegmentLeftToPartTransform { get; set; } = null!;
        public Path2DDto CrossSection { get; set; } = null!;
        public List<Path2DDto> CrossSectionsInner { get; set; } = new List<Path2DDto>();
        public Path2DDto? ContourLeft { get; set; } = null!;
        public Path2DDto? ContourRight { get; set; } = null!;
        public Shape3DDto? ArcRight { get; set; }
        public Shape3DDto? ArcLeft { get; set; }
        public string? ProfileProgramIdLeft { get; set; }
        public string? ProfileProgramNameLeft { get; set; }
        public string? ProfileProgramIdRight { get; set; }
        public string? ProfileProgramNameRight { get; set; }
        public bool ProgramsFlipped { get; set; }
        public List<AppliedProfileStyleDto> AppliedStyles { get; set; } = new List<AppliedProfileStyleDto>();
    }


    public class ProductionPartEndingSegmentModelDto:StorableGuid
    {
        public WireAnchor Anchor { get; set; }
        public string? JointId { get; set; }
        public PartSegmentSide? NeighbourSide { get; set; }
        public Path2DDto Shape { get; set; } = null!;
        public Matrix3DDto SegmentToPartTransform { get; set; } = null!;
        public Plane3DDto BoundPlane { get; set; } = null!;
        public double BoundOffset { get; set; }
        public bool IsArc { get; set; }
        public Shape3DDto? BoundArcTop { get; set; }
        public Shape3DDto? BoundArcBottom { get; set; }
        public EndingType EndingType { get; set; }
        public string? ContraProgramId { get; set; }
        public string? ContraProgramName { get; set; }
        public bool ProgramsFlipped { get; set; }
    }

    public class ProductionOperationModelDto
    {
        public ProductionOperationModelDto() { }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Index { get; set; }
        public string ToolId { get; set; } = null!;
        public int ToolIndex { get; set; } 
        public string RefPointId { get; set; } = null!;
        public int RefPointIndex { get; set; }
        public MacroType MacroType { get; set; }
        public MacroShapeType Shape { get; set; }
        public int SegmentIndex { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Radius { get; set; }
        public Point3DDto StartPoint { get; set; } = null!; //In operation space
        public Point3DDto EndPoint { get; set; } = null!; //In operation space
        public Rect3DDto Bounds { get; set; } = null!;  //In operation space
        public Matrix3DDto OperationToPartTransform { get; set; } = null!;
    }

    public class ProductionRouteStationDto
    {
        public int Order { get; set; }
        public string StationId { get; set; } = null!;
        public ZeroCorner ZeroCorner { get; set; }
        public bool QuarterTurned { get; set; }
        public Matrix3DDto PartToMachineTransform { get; set; } = null!;
    }
}
