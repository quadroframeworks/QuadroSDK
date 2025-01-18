using Quadro.Interface.Context;
using Quadro.Interface.Production;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Production
{
	public class RouteDescriptionDto : StorableGuid, IRouteEntity
    {
        public string Name { get; set; } = string.Empty;
        public FrameContextType ContextType { get; set; }
        public IEnumerable<IRouteStationDescription> RouteStations => routeStations;
        public List<RouteStationDescriptionDto> routeStations { get; set; } = new List<RouteStationDescriptionDto>();


    }

    public class RouteStationDescriptionDto : StorableGuid, IRouteStationDescription
    {
        public int Order { get; set; }
        public string? StationId { get; set; }
        public bool QuarterTurned { get; set; }
    }
}
