using CPBase.Geo.Media;
using Quadro.Interface.Enums;
using Quadro.Interface.WireFrames;
using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Interface.Assemblies;

namespace Quadro.DataModel.Model
{
	public class CompartmentModelDto
    {
        public string? SolutionHandleId { get;set; }
        public string? SubFrameHandleId { get; set; }
        public string? FillingHandleId { get; set; }
        public bool IsSelectable { get; set; }
        public bool HasFillingIdAssigned { get; set; }
        public FillingTurnConfiguration TurnConfiguration { get; set; }
        public TurnSide TurnSide { get; set; }
        public int SubFrameIndex { get;set; }   
        public string Name { get; set; } = null!;
        public bool AllowFilling { get; set; }
        public List<CompartmentSegmentDto> Segments { get; set; } = new List<CompartmentSegmentDto>();  
    }

    public class CompartmentSegmentDto
    {
        public CompartmentSegmentDto() { }
        public int? SectionId { get; set; }
        public WireIdentifier WireId { get; set; }
        public int WireSegmentIndex { get; set; }
        public WireIdentifier ChildPartId { get; set; }
        public PartSegmentSide SegmentSide { get; set; }
        public Point3DDto SegmentStart { get; set; } = null!;
        public Point3DDto SegmentEnd { get; set; } = null!;
    }
}
