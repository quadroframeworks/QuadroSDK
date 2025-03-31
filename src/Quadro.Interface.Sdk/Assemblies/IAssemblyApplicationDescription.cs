namespace Quadro.Interface.Assemblies
{
    public interface IAssemblyApplicationDescription
    {
        string Name { get; }
        string? AssemblyGroupId { get; }
        IEnumerable<IAssemblyApplicationOption> OptionsFill { get; }
    }


    public interface IAssemblyApplicationOption
    {
        string Id { get; }
        string Name { get; }
    }

}
