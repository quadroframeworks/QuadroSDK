using Quadro.Base.Catalog;
using Quadro.Globalization.Attributes;

namespace Quadro.Interface.CustomProperties
{
	public interface ICustomProperty
	{
		string Name { get; set; }
		CustomPropertyType Type { get; set; }
		double DefaultValue { get; set; }
		double MinValue { get; set; }
		double MaxValue { get; set; }
		Unit Unit { get; set; }
		IList<double> PossibleValues { get; }
	}

	public enum CustomPropertyType
	{
		[EnumValue("Undefined", Globalization.Language.en)]
		[EnumValue("Undefined", Globalization.Language.nl)]
		Undefined = 0,

		[EnumValue("Main frame width", Globalization.Language.en)]
		[EnumValue("Basisbreedte", Globalization.Language.nl)]
		MainFrameWidth = 1,

		[EnumValue("Main frame height", Globalization.Language.en)]
		[EnumValue("Basishoogte", Globalization.Language.nl)]
		MainFrameHeight = 2,

		[EnumValue("Main frame custom", Globalization.Language.en)]
		[EnumValue("Basis custom", Globalization.Language.nl)]
		MainFrameCustom = 100,

		[EnumValue("Filling custom", Globalization.Language.en)]
		[EnumValue("Vakvulling custom", Globalization.Language.nl)]
		FillingCustom = 200,
	}

}
