namespace Quadro.Interface.Images
{
	public interface IImageEntity
    {
        string Id { get; }
        string Name { get; }
        string Data { get; }
        int Width { get; set; }
        int Height { get; set; }
    }
}
