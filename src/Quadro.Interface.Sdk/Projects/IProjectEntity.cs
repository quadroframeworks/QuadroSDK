namespace Quadro.Interface.Projects
{
	public interface IProjectEntity
    {
        string? CustomerId { get; set; }
        string ProjectDescription { get; set; }
        int ProjectNumber { get; set; }

		public string? DefaultColorId { get; set; }
		public string? DefaultFillingColorId { get; set; }
		public string? DefaultRawMaterialId { get; set; }
		public string? DefaultPaintSystemId { get; set; }
		public string? DefaultGlassId { get; set; }
		public bool DefaultApplySill { get; set; }
		public double DefaultMaxUValue { get; set; }

		IEnumerable<IOrderLine> Lines { get; }
        IEnumerable<IQuoteDto> Quotes { get; }
        IEnumerable<IManufacturingOrder> ManufacturingOrders { get; }
        IEnumerable<ISubOrderDto> SubOrders { get; }
    }
}