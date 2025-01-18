namespace Quadro.Interface.Plate
{
	public interface IPlateEntity
    {
        string Id { get; }
        string Name { get; }
        string? CatalogItemId { get; }
        double Thickness { get; }
    }
}
