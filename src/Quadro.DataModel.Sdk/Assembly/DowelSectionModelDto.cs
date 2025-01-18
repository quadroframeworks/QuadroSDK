using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
	public class DowelSectionModelDto
    {
        public string? DowelApplicationId { get; set; } = null!;
        public List<Path2DDto> ValidDowelBounds { get; set; } = new List<Path2DDto>();
        public List<DowelModelDto> Dowels { get; set; } = new List<DowelModelDto>();
    }
}
