using Quadro.Globalization.Attributes;
using Quadro.Interface.Context;
using Quadro.Interface.Enums;
using Quadro.Interface.RawFrames;

namespace Quadro.Interface.Profiles
{
	public interface IProfilePropertySetter
	{
		string Id { get; }
		bool Enabled { get; }
		string? ProfileStyleId { get; }
		ProfileProperty Property { get; }
		OriginRef Reference { get; }
		double Value { get; }
		double OffsetX { get; set; }
		double OffsetY { get; set; }
		string? ValueDescription { get; set; }
		bool IsGenerated { get; }

	}

	public interface IProfileStyle
	{
		FrameContextType ContextType { get; } //Target type, to be looked up in model tree
		FramePartType PartType { get; set; } //Applies to all parts of this type
		FrameSegmentSide FrameSegmentSide { get; } //Applies to this segment side
		string? CatalogItemId { get; }
		IEnumerable<IProfilePropertySetter> Setters { get; }
	}

	public enum ProfileProperty
	{
		[EnumValue("Undefined", Globalization.Language.en)]
		[EnumValue("Geen", Globalization.Language.nl)]
		None = 0,

		[EnumValue("Profile angle", Globalization.Language.en)]
		[EnumValue("Profielhoek", Globalization.Language.nl)]
		ProfileAngle = 1,       //Value is angle

		[EnumValue("Rabbet indoors", Globalization.Language.en)]
		[EnumValue("Binnensponning", Globalization.Language.nl)]
		RabbetIndoors = 10,     //Value is angle
		[EnumValue("Rabbet outdoors", Globalization.Language.en)]
		[EnumValue("Buitensponning", Globalization.Language.nl)]
		RabbetOutdoors = 11,    //Value is angle

		[EnumValue("Notch L outside", Globalization.Language.en)]
		[EnumValue("Keep L buiten", Globalization.Language.nl)]
		NotchLOutside = 50,
		[EnumValue("Notch L inside", Globalization.Language.en)]
		[EnumValue("Keep L binnen", Globalization.Language.nl)]
		NotchLInside = 51,
		[EnumValue("Notch U", Globalization.Language.en)]
		[EnumValue("Keep U", Globalization.Language.nl)]
		NotchU = 52,            //Value is notch height

		[EnumValue("Radius outdoors", Globalization.Language.en)]
		[EnumValue("Buitenradius", Globalization.Language.nl)]
		RadiusOutdoors = 100,   //Value is radius
		[EnumValue("Radius indoors", Globalization.Language.en)]
		[EnumValue("Binnenradius", Globalization.Language.nl)]
		RadiusIndoors = 101,    //Value is radius
		[EnumValue("Radius dam", Globalization.Language.en)]
		[EnumValue("Damradius", Globalization.Language.nl)]
		RadiusDam = 102,        //Value is radius

		[EnumValue("Hinge & lock", Globalization.Language.en)]
		[EnumValue("Hang- & sluitwerk", Globalization.Language.nl)]
		HingeAndLock = 150,

		[EnumValue("Seal", Globalization.Language.en)]
		[EnumValue("Kader", Globalization.Language.nl)]
		Seal = 200,
		[EnumValue("Waterhole", Globalization.Language.en)]
		[EnumValue("Waterhol", Globalization.Language.nl)]
		Waterhole = 201,
		[EnumValue("Venthole", Globalization.Language.en)]
		[EnumValue("Ventiatiehol", Globalization.Language.nl)]
		Venthole = 202,
		[EnumValue("Decoration", Globalization.Language.en)]
		[EnumValue("Decoratie", Globalization.Language.nl)]
		Decoration = 203,

		[EnumValue("Contra decoration", Globalization.Language.en)]
		[EnumValue("Contradecoratie", Globalization.Language.nl)]
		ContraDecoration = 300,

		[EnumValue("Custom", Globalization.Language.en)]
		[EnumValue("Custom", Globalization.Language.nl)]
		Custom = 1000,

	}

	public enum OriginRef
	{
		[EnumValue("No origin", Globalization.Language.en)]
		[EnumValue("Geen", Globalization.Language.nl)]
		NoOrigin = 0,

		[EnumValue("Outside edge", Globalization.Language.en)]
		[EnumValue("Buitenrand", Globalization.Language.nl)]
		OutsideEdge = 1,

		[EnumValue("Inside edge", Globalization.Language.en)]
		[EnumValue("Binnenrand", Globalization.Language.nl)]
		InsideEdge = 2,

		[EnumValue("Rabbet corner", Globalization.Language.en)]
		[EnumValue("Sponninghoek", Globalization.Language.nl)]
		Rabbet = 50,

		[EnumValue("Outside rabbet edge", Globalization.Language.en)]
		[EnumValue("Sponningrand buiten", Globalization.Language.nl)]
		OutsideRabbet = 51,

		[EnumValue("Inside rabbet edge", Globalization.Language.en)]
		[EnumValue("Sponningrand binnen", Globalization.Language.nl)]
		InsideRabbet = 52,

		[EnumValue("Dam", Globalization.Language.en)]
		[EnumValue("Dam", Globalization.Language.nl)]
		Dam = 53,

		[EnumValue("Setting wire", Globalization.Language.en)]
		[EnumValue("Draadmodel", Globalization.Language.nl)]
		SettingWire = 100,

		[EnumValue("Part", Globalization.Language.en)]
		[EnumValue("Onderdeel", Globalization.Language.nl)]
		SettingPart = 101,

		[EnumValue("Parent part", Globalization.Language.en)]
		[EnumValue("Ouderlijk onderdeel", Globalization.Language.nl)]
		ParentPart = 110,

		[EnumValue("Parent wire", Globalization.Language.en)]
		[EnumValue("Ouderlijk draadmodel", Globalization.Language.nl)]
		ParentWire = 111,
	}
}
