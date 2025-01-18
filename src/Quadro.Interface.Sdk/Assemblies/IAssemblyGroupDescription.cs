namespace Quadro.Interface.Assemblies
{
	public interface IAssemblyGroupDescription
    {
        string Name { get; }
        AssemblyType AssemblyType { get; set; }
        AssemblyContentType ContentType { get; set; }
        FillingTurnConfiguration TurnConfiguration { get; set; }
    }
}
