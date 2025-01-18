using Quadro.Interface.Context;
using Quadro.Interface.Enums;
using Quadro.Interface.Production;
using Quadro.Interface.RawFrames;
using Quadro.Interface.Sills;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Production
{
	public class ProductionPartDto : StorableGuid, IProductionPartEntity
    {
        public string ManufacturingOrderId { get; set; } = null!;
        public string ProductionFrameId { get; set; } = null!;
        public string MainAssemblyModelId { get; set; } = null!;
        public string FrameItemModelId { get; set; } = null!; //Could be part, glass or plate
        public string CatalogItemName { get; set; } = null!;
        public string CatalogItemId { get; set; } = null!;
        public FrameContextType ContextType { get; set; }
        public FramePartType PartType { get; set; }
        public SillPartType SillPartType { get; set; }
        public string FrameTag { get; set; } = null!;
        public int BatchNumber { get; set; }
        public int PartIndex { get; set; }
        public ProductionPartType ProductionPartType { get; set; }
        public ProductionState State { get; set; }
        public double RawWidth { get; set; }
        public double RawHeight { get; set; }
        public double RawLength { get; set; }
        public double PlanerWidth { get; set; }
        public double PlanerHeight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public bool Mirrored { get; set; }
        public string? RawMaterialId { get; set; }
        public string? RawMaterialName { get; set; }
        public string? RawLengthMaterialId { get; set; }
        public string Barcode { get; set; } = null!;

        [JsonIgnore]
        public IEnumerable<IRouteStation> RouteStations => routeStations;
        public List<RouteStationDto> routeStations { get; set; } = new List<RouteStationDto>();

        [JsonIgnore]
        public IEnumerable<IProductMoveDescription> Moves => moves;
        public List<ProductMoveDto> moves { get; set; }= new List<ProductMoveDto>();

      
    }

  
}
