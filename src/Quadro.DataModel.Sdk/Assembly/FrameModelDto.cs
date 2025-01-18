using Quadro.Interface.Assemblies;
using Quadro.Interface.Context;
using Quadro.Interface.Enums;
using Quadro.Interface.HingeAndLock;

namespace Quadro.DataModel.Model
{
	public class FrameModelDto
    {
        public FrameModelDto() { }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public int SubFrameIndex { get; set; }
        public bool IsBase { get; set; }
        public FillingSide FillingSide { get; set; }
        public FillingTurnConfiguration TurnConfiguration { get; set; }
        public TurnSide TurnSide { get; set; }
        public PaintSystemModelDto? PaintSystem { get; set; }
        public FrameContextType ContextType { get; set; }
        public WireFrameModelDto WireFrame { get; set; } = null!;
        public List<FramePartModelDto> FrameParts { get; set; } = new List<FramePartModelDto>();
        public List<FixPartModelDto> FixParts { get; set; } = new List<FixPartModelDto>();
        public List<FrameOperationModelDto> Operations { get; set; }= new List<FrameOperationModelDto>();
        public List<CompartmentDto> Compartments { get; set; } = new List<CompartmentDto>();

    }
}
