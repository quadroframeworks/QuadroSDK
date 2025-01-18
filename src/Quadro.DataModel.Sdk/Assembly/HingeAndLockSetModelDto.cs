using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
    public class HingeAndLockSetModelDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public List<int> SectionIds { get; set; } = new List<int>();
        public string DescriptionId { get; set; } = null!;
        public WireFrameModelDto WireFrame { get; set; } = null!;
        public WireFrameModelDto AncestorWireFrame { get; set; } = null!;
        public List<HingeAndLockPartModelDto> HingeAndLockParts { get; set; } = new List<HingeAndLockPartModelDto>();


    }
}
