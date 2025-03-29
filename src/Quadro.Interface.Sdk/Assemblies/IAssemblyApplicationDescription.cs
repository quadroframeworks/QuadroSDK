namespace Quadro.Interface.Assemblies
{
    public interface IAssemblyApplicationDescription
    {
        string Name { get; }
        string? AssemblyGroupId { get; }
        IEnumerable<IAssemblyApplicationOption> Options { get; }
    }


    public interface IAssemblyApplicationOption
    {
        string Id { get; }
        string Name { get; }
    }

}
