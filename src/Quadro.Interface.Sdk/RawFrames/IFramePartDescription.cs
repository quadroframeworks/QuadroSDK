using Quadro.Interface.Sills;
using Quadro.Interface.WireFrames;

namespace Quadro.Interface.RawFrames
{
	public interface IFramePartDescription
	{
		public string Id { get; }
		PartIdentifier PartId { get; }
		WireIdentifier WireId { get; }
		public SillPartType SillPartType { get; }
		string? CatalogItemId { get; }
		string? ColorId { get; }
		WireAlignment Alignment { get; }
		double DesignWidth { get; } //Actual width is specified in context
		double DesignHeight { get; } //Actual height is specified in context
		FramePartProfileConfig ProfileConfig { get; }
		double WireOffsetY { get; }
		double WireOffsetZ { get; }
		bool SnapToOutside { get; }
		bool IsSecondary { get; }
		IEnumerable<IFramePartEnding> StartDescriptions { get; }
		IEnumerable<IFramePartEnding> EndDescriptions { get; }
	}

	public enum FramePartType
	{
		Undefined = 0,
		Left = 1,
		Right = 2,
		Bottom = 3,
		Top = 4,
		MidVertical = 5,
		MidHorizontal = 6,
	}

	public enum FramePartProfileConfig
	{
		TwoHalfProfiles,
		SingleProfile,
	}

	public struct PartIdentifier : IEquatable<PartIdentifier>
	{
		public PartIdentifier(FramePartType type, int index)
		{
			Type = type;
			TypeIndex = index;
		}

		public FramePartType Type { get; set; }
		public int TypeIndex { get; set; }
		public string Id => $"{Type}.{TypeIndex}";
		public bool Equals(PartIdentifier other) => Type == other.Type && Id == other.Id;
		public static bool operator ==(PartIdentifier idLeft, PartIdentifier idRight) => idLeft.Equals(idRight);
		public static bool operator !=(PartIdentifier idLeft, PartIdentifier idRight) => !idLeft.Equals(idRight);
		public override bool Equals(object? obj)
		{
			return obj is PartIdentifier && Equals((PartIdentifier)obj);
		}
		public override int GetHashCode() => base.GetHashCode();

		public override string ToString() => Id;

		public static PartIdentifier Parse(string s)
		{
			var items = s.Split('.');
			var type = Enum.Parse<FramePartType>(items[0]);
			var typeIndex = int.Parse(items[1]);
			return new PartIdentifier(type, typeIndex);
		}


	}

	public enum WireAlignment
	{
		Mid = 0,//Wire is positioned in center of part
		Left = 1,//Part is positioned left of wire
		Right = 2,//Part is positioned right of wire
		Origin = 3,//Part is positions by sketch origin
	}



}
