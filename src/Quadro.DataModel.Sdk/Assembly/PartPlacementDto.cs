using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Interface.RawFrames;

namespace Quadro.DataModel.Model
{
	public class PartPlacementDto
    {
        public PartPlacementDto() { }
        public Matrix3DDto PartToFrameTransform { get; set; } = null!;
        public PartIdentifier FramePartId { get; set; }

    }
}
