namespace Quadro.Interface.Orders
{

	public interface ILineBase
    {
		public string? ERPIdAsDesigned { get; set; }
		public string? ERPIdMirrored { get; set; }
		int QuantityAsDesigned { get; set; }
        int QuantityMirrored { get; set; }
        string Tag { get; set; }
    }

    public interface IOrderLine : ILineBase
    {
        string SolutionId { get; set; }
        bool IsSelectedForQuote { get; set; }
        string Description { get; set; }
    }

    public interface IQuoteOrderLine : ILineBase
    {
        string BomId { get; set; }
        double CostPrice { get; set; }
        double SalesPrice { get; set; }
        string Description { get; set; }
    }

    public interface IManufacturingOrderLine : ILineBase
    {
        ProductionState State { get;set; }
        string? BomId { get; set; }
        string DeliveryId { get; set; } 
        int DeliveryIndex { get; set; }
    }

    public interface ISubOrderLine : ILineBase
    {

    }

    public interface IDeliveryLineDto : ILineBase
    {

    }

    public enum ProductionState
    {
        Design,
        Published,
        Finished,
    }
}