using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
    public class HalfProfileModelDto
    {
        public double Height { get; set; }
        public string? SingleProfileId { get; set; }    //If directly from database
        public Path2DDto Shape { get; set; } = null!;
        public List<HalfProfilePropertyDto> Properties { get; set; } = new List<HalfProfilePropertyDto>();
    }
}
