namespace Quadro.Interface.Coating
{
	public interface IPaintEntity
    {
        string Name { get; }
        PaintType Type { get; }
        IEnumerable<IPaintItemDescription> PaintItems { get; }
    }

    public interface IPaintItemDescription
    {
        string TopLayerColorId { get; }
        string? CatalogItemId { get; }
    }

    public enum PaintType
    {
        Primer,
        PreCoat,
        TopCoat,
    }

}
