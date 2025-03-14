namespace Quadro.Interface.Images
{
	public interface IImageEntity
    {
        string Id { get; }
        string Name { get; }
        ImageType Type { get; }
        string Data { get; }
        int Width { get; set; }
        int Height { get; set; }
    }

    public enum ImageType
    {
        Certificate = 0,
        CompanyLogo = 1,
    }
}
