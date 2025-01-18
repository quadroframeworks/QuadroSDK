namespace Quadro.Interface.Colors
{
	public interface IColorDescription
    {
        string Name { get; }
        string Description { get; }
        byte A { get; }
        byte R { get; }
        byte G { get; }
        byte B { get; }
    }
}
