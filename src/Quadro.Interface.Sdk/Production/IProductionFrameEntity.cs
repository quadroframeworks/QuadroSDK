using Quadro.Interface.Enums;

namespace Quadro.Interface.Production
{
	public interface IProductionFrameEntity
    {
        public string Id { get; }
        public string Tag { get; }
        public int BatchNumber { get; }
        public int FrameIndex { get; }
        public string? Name { get; }
        public ProductionState State { get; }
        public string ManufacturingOrderId { get; }
        public string MainAssemblyModelId { get; }
        public bool Mirrored { get; }
        public IEnumerable<IRouteStation> RouteStations { get; }
        public IEnumerable<IProductMoveDescription> Moves { get; }

    }
}
