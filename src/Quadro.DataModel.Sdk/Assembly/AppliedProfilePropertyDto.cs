using CPBase.Geo.Media;
using Quadro.Interface.Profiles;
using Quadro.DataModel.Geometrics;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Model
{
	public class AppliedProfilePropertyDto : IAppliedProfileProperty
    {
        public AppliedProfilePropertyDto() { }
        public string SetterHandleId { get; set; } = null!;
        public string? ProfileStyleId { get; set; }
        public string? Name { get; set; }
        public ProfileProperty Property { get; set; }
        public OriginRef Reference { get; set; }
        public double Value { get; set; }

        [JsonIgnore]
        public Point Origin => origin.ToPoint();
        public Point2DDto origin { get; set; } = null!;
        public Path2DDto? CutContour { get; set; }
       
    }
}
