using Quadro.Interface.Production;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Production
{
	public class RouteStationDto : StorableGuid, IRouteStation
    {
        public RouteStationDto() { }
        public string Name { get; set; } = null!;
        public int Order { get; set; }
        public string StationId { get; set; } = null!;
        public ZeroCorner ZeroCorner { get; set; }
        public bool QuarterTurned { get; set; }
        public int StationIndex { get; set; }
        public int PosIndexHorizontal { get; set; }
        public int PosIndexVertical { get; set; }
        public bool Done { get; set; }
      
    }
}
