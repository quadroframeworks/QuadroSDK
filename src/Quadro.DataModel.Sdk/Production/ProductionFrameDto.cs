using Quadro.Interface.Enums;
using Quadro.Interface.Production;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quadro.DataModel.Production
{
	public class ProductionFrameDto : StorableGuid, IProductionFrameEntity
    {
        public string Tag { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public int BatchNumber { get; set; }
        public int FrameIndex { get; set; }
        public ProductionState State { get; set; }
        public string MainAssemblyModelId { get; set; } = null!;
        public string ManufacturingOrderId { get; set; } = null!;
        public bool Mirrored { get; set; }

        [JsonIgnore]
        public IEnumerable<IRouteStation> RouteStations => routeStations;
        public List<RouteStationDto> routeStations { get; set; } = new List<RouteStationDto>();

        [JsonIgnore]
        public IEnumerable<IProductMoveDescription> Moves => moves;
        public List<ProductMoveDto> moves { get; set; } = new List<ProductMoveDto>();

      
    }
}
