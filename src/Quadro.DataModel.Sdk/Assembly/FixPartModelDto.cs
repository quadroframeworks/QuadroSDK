using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
    public class FixPartModelDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string DescriptionId { get; set; } = null!;
        public Rect3DDto? Bounds { get; set; }
        public List<PartPlacementDto> Placements { get; set; } = new List<PartPlacementDto>();
        public List<HingeAndLockExtrusionDto> Extrusions { get; set; } = new List<HingeAndLockExtrusionDto>();
    }
}
