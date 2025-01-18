using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
    public class HingeAndLockPartModelDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string DescriptionId { get; set; } = null!;
        public string? PlacementHandleId { get; set; }
        public bool Draw2D { get; set; }
        public bool Draw3D { get; set; }
        public bool DrawWorkBook { get; set; }
        public Rect3DDto Bounds { get; set; } = null!;
        public Matrix3DDto PartToFrameTransform { get; set; } = null!;
        public Matrix3DDto FrameToPartTransform { get; set; } = null!;
        public List<HingeAndLockExtrusionDto> Extrusions { get; set; } = new List<HingeAndLockExtrusionDto>();
    }
}
