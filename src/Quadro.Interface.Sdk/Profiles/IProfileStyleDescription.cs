using CPBase.Shapes;

namespace Quadro.Interface.Profiles
{
	public interface IProfileStyleDescription
    {
        string Id { get; }
        string Name { get; }
        string? CatalogItemId { get; set; }
        ProfileProperty Property { get; }
        IPathShape2D Shape { get; }

    }
}
