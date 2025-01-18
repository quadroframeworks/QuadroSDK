using CPBase.Geo.Media;

namespace Quadro.Interface.Profiles
{
	public interface IAppliedProfileProperty
    {
        public string SetterHandleId { get; }
        string? ProfileStyleId { get; }
        string? Name { get; }
        Point Origin { get; }
        ProfileProperty Property { get; set; }
        OriginRef Reference { get; set; }
        double Value { get; set; }
    }
}