using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
	public class PlateModelDto
    {
        public PlateModelDto() { }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public List<int> SectionIds { get; set; } = new List<int>();
        public string DescriptionId { get; set; } = null!;
        public string? CatalogItemId { get; set; }
        public double Thickness { get; set; }
        public double SurfaceArea { get; set; }
        public Rect3DDto Bounds { get; set; } = null!;
        public WireFrameModelDto WireFrame { get; set; } = null!;
        public Matrix3DDto PlateToFrameTransform { get; set; } = null!;
    }
}
