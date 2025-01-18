namespace Quadro.Interface.Profiles
{
	public interface IPropertySetting
    {
        string PropertyName { get; }
        double Value { get; set; }
    }
}
