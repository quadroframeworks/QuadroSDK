using Quadro.Globalization.Attributes;

namespace Quadro.Interface.Enums
{
	public enum FillingSide
	{
		[EnumValue("Indoors", Globalization.Language.en)]
		[EnumValue("Binnen", Globalization.Language.nl)]
		Indoors,

		[EnumValue("Outdoors", Globalization.Language.en)]
		[EnumValue("Buiten", Globalization.Language.nl)]
		Outdoors,
	}

	public enum TurnSide
	{
		[EnumValue("Both", Globalization.Language.en)]
		[EnumValue("Beide", Globalization.Language.nl)]
		Both,

		[EnumValue("Left", Globalization.Language.en)]
		[EnumValue("Links", Globalization.Language.nl)]
		Left,

		[EnumValue("Right", Globalization.Language.en)]
		[EnumValue("Rechts", Globalization.Language.nl)]
		Right,
	}
}
