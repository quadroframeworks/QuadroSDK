using Quadro.Interface.Context;
using Quadro.Interface.Enums;
using Quadro.Interface.Profiles;
using Quadro.Interface.RawFrames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
	public class AppliedProfileStyleDto
    {
        public FrameContextType ContextType { get; set; }
        public FramePartType PartType { get; set; }
        public FrameSegmentSide FrameSegmentSide { get; set; }
        public string? CatalogItemId { get; set; }
        public IList<AppliedProfilePropertyDto> Setters { get; set; } = new List<AppliedProfilePropertyDto>();
    }
}
