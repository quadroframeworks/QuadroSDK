namespace Quadro.Interface.Assemblies
{
    public interface IAssemblyApplicationDescription
    {
        string Name { get; }
        string? AssemblyGroupId { get; }
        IEnumerable<IAssemblyApplicationFillingOption> OptionsFill { get; }
        IEnumerable<IAssemblyApplicationHingeAndLockOption> OptionsHl { get; }
    }


    public interface IAssemblyApplicationFillingOption
    {
        string Id { get; }
        string Name { get; }
        bool IsPurchasedDoor { get; set; }
    }

    public interface IAssemblyApplicationHingeAndLockOption
    {
        string Id { get; }
        string Name { get; }
    }
}
