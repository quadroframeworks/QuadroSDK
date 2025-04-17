using Quadro.Interface.RawFrames;
using Quadro.Interface.Solutions;
using Quadro.Interface.WireFrames;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quadro.DataModel.Entities.Solutions
{
	public class CompartmentDto : StorableGuid, ICompartmentDescription
	{
		public CompartmentDto() { }
		public string Name { get; set; } = null!;
		public int SubFrameIndex { get; set; }
		public string SubFramePlacementId { get; set; } = null!;
		[JsonIgnore]
		public IEnumerable<IWireLink> BoundingWires => boundingWires;
		public List<WireLink> boundingWires { get; set; } = new List<WireLink>();


	}

	public class WireLink : StorableGuid, IWireLink
	{
		public WireLink() { }
		public FramePartType Type { get; set; }
		public int Index { get; set; }
		public FramePartType ChildPartType { get; set; }
		public int ChildPartIndex { get; set; }
	}
}
