using Quadro.Interface.RawFrames;
using Quadro.Interface.Sills;

namespace Quadro.DataModel.Common
{

	public class PartInfoDto
    {
        public PartInfoDto() { }
        public FramePartType Type { get; set; }
        public int PartIndex { get; set; }
        public int WireIndex { get; set; }
        public SillPartType SillPartType { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double WireOffsetX { get; set; }
        public double WireOffsetY { get; set; }
        public double WireOffsetZ { get; set; }
        public double WireRotationA { get; set; }
        public double WireRotationB { get; set; }
        public double WireRotationC { get; set; }
        public bool DoFlip { get; set; }
        public bool DoMirror { get; set; }
        public bool IsDistributedPart { get; set; }
        public string? PartDistributionId { get; set; }
        public bool IsAdditionalPart { get; set; }
        public string? AdditionalPartId { get; set; }
        public int SubFrameIndex { get; set; }
        public WireAlignment WireAlignment { get; set; }
        public bool SnapToOutside { get; set; }
        public string? SingleProfileId { get; set; }
        public string? ContraProgramIdStart { get; set; }
        public string? ContraProgramIdEnd { get; set; }
        public string? ProfilingProgramIdOuter { get; set; }
        public string? ProfilingProgramIdInner { get; set; }
        public string? DowelProgramIdStart { get; set; }
        public string? DowelProgramIdEnd { get; set; }
        public string? CatalogItemId { get; set; }
        public string? ColorId { get; set; }
        public string? RawMaterialId { get; set; }


    }
}
