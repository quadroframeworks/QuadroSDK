using Quadro.DataModel.Entities.Assemblies;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Frames;
using Quadro.Interface.Solutions;
using Quadro.Interface.WireFrames;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Solutions
{
	public class AdditionalPartDto : PartConfigurationDto, IAdditionalPart
	{
		public AdditionalPartDto() { }

		[Header("Orientation", Globalization.Language.en)]
		[Header("Orientatie", Globalization.Language.nl)]
		public AdditionalPartOrientation Orientation { get; set; }

		[Header("Position", Globalization.Language.en)]
		[Header("Positie", Globalization.Language.nl)]
		public double Position { get; set; }

		[JsonIgnore]
		public IEnumerable<WireIdentifier> BoundingWires => boundingWires.Select(b => new WireIdentifier(b.Type, b.Index)).ToList();

		[Header("Bounding wires", Globalization.Language.en)]
		[Header("Grensdraden", Globalization.Language.nl)]
		public List<WireLink> boundingWires { get; set; } = new List<WireLink>();

	}
}
