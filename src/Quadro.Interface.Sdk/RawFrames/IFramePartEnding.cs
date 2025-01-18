using Quadro.Interface.WireFrames;

namespace Quadro.Interface.RawFrames
{
	public interface IFramePartEnding
	{
		EndingType EndingType { get; }
		double Offset { get; }
		WireAnchor Side { get; set; }
		FramePartType JointPartType { get; set; }
		int JointPartIndex { get; set; }
	}

	public interface IFramePartOffsetEnding : IFramePartEnding
	{
		WireAnchor OffsetAnchor { get; }
		double AngleB { get; }
		double AngleC { get; }
	}

	public interface IFramePartExtendToEnding : IFramePartEnding
	{
		PartIdentifier JointPartId { get; }
		JointPartPlaneType PlaneType { get; }
	}

	public interface IFramePartMitreEnding : IFramePartEnding
	{
		PartIdentifier JointPartId { get; }
	}

	public enum JointPartPlaneType
	{
		Closest,
		Furthest,
	}

	public enum EndingType
	{
		Offset,
		ExtendTo,
		Mitre,
	}
}
