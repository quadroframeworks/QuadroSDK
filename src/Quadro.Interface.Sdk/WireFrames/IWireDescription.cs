using Quadro.Interface.RawFrames;

namespace Quadro.Interface.WireFrames
{

	public interface IWireDescription
    {
        WireIdentifier WireId { get; }
        string ParameterRadius { get; }
        bool IsCcw { get; }
    }

    public struct WireIdentifier : IEquatable<WireIdentifier>
    {
        public WireIdentifier(FramePartType type, int index)
        {
            Type = type;
            TypeIndex = index;
        }
        public FramePartType Type { get; set; }
        public int TypeIndex { get; set; }

        public string Id => $"{Type}.{TypeIndex}";
        public bool Equals(WireIdentifier other) => Type == other.Type && Id == other.Id;
        public static bool operator ==(WireIdentifier idLeft, WireIdentifier idRight) => idLeft.Equals(idRight);
        public static bool operator !=(WireIdentifier idLeft, WireIdentifier idRight) => !idLeft.Equals(idRight);
        public override bool Equals(object? obj)
        {
            return obj is WireIdentifier && Equals((WireIdentifier)obj);
        }
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => Id;
        public static WireIdentifier Parse(string s)
        {
            var items = s.Split('.');
            var type = Enum.Parse<FramePartType>(items[0]);
            var typeIndex = Int32.Parse(items[1]);
            return new WireIdentifier(type, typeIndex);
        }


    }



}
