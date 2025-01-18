using Quadro.Interface.Enums;
using Quadro.Interface.RawFrames;
using Quadro.Interface.Sills;

namespace Quadro.Interface.Production
{
	public interface IProductionPartEntity
    {
        public string Id { get; }
        public string ManufacturingOrderId { get; }
        public string ProductionFrameId { get; }
        public string MainAssemblyModelId { get; }
        public string FrameItemModelId { get; }       //Could be part, glass or plate     
        public string CatalogItemName { get; }
        public string CatalogItemId { get; }
        public ProductionState State { get; }
        public FramePartType PartType { get; }
        public SillPartType SillPartType { get; }
        public ProductionPartType ProductionPartType { get; }
        public string FrameTag { get; }
        public int BatchNumber { get; }
        public int PartIndex { get; }
        public double RawWidth { get; }
        public double RawHeight { get; }
        public double RawLength { get; }
        public double PlanerWidth { get; }
        public double PlanerHeight { get; }
        public double Width { get; }
        public double Height { get; }
        public double Length { get; }
        public bool Mirrored { get; }
        public string? RawMaterialId { get; }
        public string? RawMaterialName { get; set; }
        public string? RawLengthMaterialId { get; }
        public string Barcode { get; }
        public IEnumerable<IRouteStation> RouteStations { get; }
        public IEnumerable<IProductMoveDescription> Moves { get; }
    }


}
