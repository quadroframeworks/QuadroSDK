using Quadro.Interface.Sills;

namespace Quadro.Interface.RawFrames
{
	public interface IPartConfiguration
	{
		string Id { get; }
		FramePartType Type { get; }
		int PartIndex { get; }
		int WireIndex { get; }
		SillPartType SillPartType { get; set; }
		bool IsDistributedPart { get; set; }
		string? PartDistributionId { get; set; }
		bool IsAdditionalPart { get; set; }
		string? AdditionalPartId { get; set; }
		int SubFrameIndex { get; }
		string? SingleProfileId { get; set; }
		string? ContraProgramIdStart { get; set; }
		string? ContraProgramIdEnd { get; set; }
		string? ProfilingProgramIdOuter { get; set; }
		string? ProfilingProgramIdInner { get; set; }
		string? DowelProgramIdStart { get; set; }
		string? DowelProgramIdEnd { get; set; }
		string? CatalogItemId { get; set; }
		string? ColorId { get; set; }
		string? RawMaterialId { get; set; }
		WireAlignment WireAlignment { get; set; }
		bool SnapToOutside { get; set; }
		double Width { get; set; }
		double Height { get; set; }
		double WireOffsetX { get; set; }
		double WireOffsetY { get; set; }
		double WireOffsetZ { get; set; }
		double WireRotationA { get; set; }
		double WireRotationB { get; set; }
		double WireRotationC { get; set; }
		bool DoFlip { get; set; }
		bool DoMirror { get; set; }
		IEnumerable<IFramePartEnding> StartDescriptions { get; }
		IEnumerable<IFramePartEnding> EndDescriptions { get; }
	}
}
