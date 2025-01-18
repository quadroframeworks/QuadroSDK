namespace Quadro.Interface.Production
{
	public interface IRouteStation
    {
        string Name { get; }
        int Order { get; }
        string StationId { get; }
        public ZeroCorner ZeroCorner { get; }
        public bool QuarterTurned { get; }
        int StationIndex { get; }
        int PosIndexHorizontal { get; }
        int PosIndexVertical { get; }
        bool Done { get; }

    }
}
