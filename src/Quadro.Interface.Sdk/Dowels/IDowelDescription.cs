namespace Quadro.Interface.Dowels
{
	public interface IDowelDescription
    {
        string Id { get; }
        string? CatalogItemId { get; }
        string Name { get; }
        double Diameter { get; }
        double Length { get; }
        bool IsPlugTec { get; }

    }
}
