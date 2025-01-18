using Quadro.Globalization.Attributes;

namespace Quadro.Interface.Enums
{
	public enum FrameSegmentSide
	{
		[EnumValue("Inner", Globalization.Language.en)]
		[EnumValue("Binnen", Globalization.Language.nl)]
		Inner,

		[EnumValue("Outer", Globalization.Language.en)]
		[EnumValue("Buiten", Globalization.Language.nl)]
		Outer,
	}
}
