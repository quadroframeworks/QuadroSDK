using Quadro.Interface.Context;

namespace Quadro.Interface.Production
{
	public interface IRouteEntity
    {
        public string Name { get; }
        public FrameContextType ContextType { get; }
        public IEnumerable<IRouteStationDescription> RouteStations { get; }
    }

    public interface IRouteStationDescription
    {
        int Order { get; }
        string? StationId { get; }
        public bool QuarterTurned { get; }

    }

}
