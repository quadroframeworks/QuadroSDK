namespace Quadro.Interface.CustomProperties
{
	public interface ICustomPropertySetting
    {
        string FullName { get; }
        ICustomProperty Property { get; }
        double Value { get; set; }
    }
}
