namespace Quadro.Interface.Production
{
	public interface IProductMoveDescription
    {
        string? ProductionFrameId { get; }
        string? ProductionPartId { get; }
        string FromStationId { get; }
        string ToStationId { get; }
    }

  
}
