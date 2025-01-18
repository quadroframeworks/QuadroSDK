using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
    public class SingleProfileModelDto
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string? SingleProfileId { get; set; }    //If directly from database
        public Path2DDto Shape { get; } = null!;
        public List<SingleProfilePropertyDto> Properties { get; set; } = new List<SingleProfilePropertyDto>();
    }
}
