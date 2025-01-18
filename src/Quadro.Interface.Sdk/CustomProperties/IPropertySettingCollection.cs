namespace Quadro.Interface.CustomProperties
{
	public interface IPropertySettingCollection : IList<ICustomPropertySetting>
    {
        double GetValue(string? expression);
        bool GetCondition(string? expression);
        void SetValue(string name, double value);
        void AddProperties(IEnumerable<ICustomProperty> properties);
    }
}
