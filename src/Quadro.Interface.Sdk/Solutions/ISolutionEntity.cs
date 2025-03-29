using Quadro.Globalization.Attributes;
using Quadro.Interface.Assemblies;
using Quadro.Interface.CustomProperties;
using Quadro.Interface.Enums;
using Quadro.Interface.Projects;
using Quadro.Interface.RawFrames;
using Quadro.Interface.WireFrames;

namespace Quadro.Interface.Solutions
{

	public interface ISolutionHandle
    {
        string Id { get; set; }
    }
    public interface ISolutionEntity : ISolutionHandle, ICustomizable
    {
        string Name { get; set; }
        string WireFrameId { get; set; }
        string MainAssemblyId { get; set; }
		string? BorderAssemblyGroupId { get; set; }
		string? BorderApplicationId { get; set; }
        string? BorderAssemblyId { get; set; }
        string? BorderRabbetSelectionId { get; set; }
        string? RawMaterialId { get; set; }
        string? PaintSystemId { get; set; }
        string? ColorId { get; set; }
        string? SillId { get; set; }
        FrameSolutionStatus Status { get; set; }
        IEnumerable<IPartConfiguration> PartConfigurations { get; }
        IEnumerable<IAdditionalPart> AdditionalParts { get; }
        IEnumerable<ISolutionFilling> Fillings { get; }
		IEnumerable<ISubFrameWork> SubFrameWorks { get; }
		IEnumerable<IOperationSetPlacement> OperationSets { get; }
        IEnumerable<ICertificateTest> CertificateTests { get; }

    }

    public interface IWebFramePropertySetting
    {
        string PropertyName { get; set; }
        double Value { get; set; }
    }

    public interface IAdditionalPart
    {
        string Id { get; }
        AdditionalPartOrientation Orientation { get; set; }
        double Position { get; set; }
        IEnumerable<WireIdentifier> BoundingWires { get; }

    }

    public enum AdditionalPartOrientation
    {
        [EnumValue("Horizontal", Globalization.Language.en)]
        [EnumValue("Horizontaal", Globalization.Language.nl)]
        Horizontal,
        [EnumValue("Vertical", Globalization.Language.en)]
        [EnumValue("Verticaal", Globalization.Language.nl)]
        Vertical,
    }

    public interface ISolutionFilling : ISolutionHandle, ICustomizable
    {
        string? Name { get; }

        string? AssemblyGroupId { get; set; }
        string? AssemblyApplicationId { get; set; }
        string? FillingAssemblyId { get; set; }
        string? PlacementOptionId { get; set; }
        string? PurchasedDoorId { get; set; }
        string? RabbetSelectionId { get; set; }
        public FastSelectionRodConfig RodConfig { get; set; }
        AssemblyFillingType Type { get; set; }
        string? PaintSystemId { get; set; }
        string? ColorId { get; set; }
        string? GlassId { get; set; }
        string? VentGrillId { get; set; }
        string? VentGrillColorId { get; set; }
        FillingTurnConfiguration TurnConfiguration { get; set; }
        TurnSide TurnSide { get; set; }
        bool AllowVentGrill { get; set; }
        IEnumerable<IPartConfiguration> PartConfigurations { get; }
        IEnumerable<IOperationSetPlacement> OperationSets { get; }
        ICompartmentDescription Compartment { get; }
        IEnumerable<ISolutionFilling> Fillings { get; }
    }

    public interface ICompartmentDescription
    {
        string Name { get; }
        int SubFrameIndex { get; }
        IEnumerable<IWireLink> BoundingWires { get; }
    }

    public interface IWireLink
    {
        FramePartType Type { get; set; }
        int Index { get; set; }
        FramePartType ChildPartType { get; set; }
        int ChildPartIndex { get; set; }
    }

    public interface ISubFrameWork
    {
		SubFrameWorkSide Side { get; }
        double Width { get; }
		double Height { get; }
        double OffsetZ { get; }
		double OffsetBottom { get; }
		double OffsetTop { get; }
		double OffsetLeft { get; }
		double OffsetRight { get; }
        string? FrameWorkAssemblyId { get; }
	}

    public enum SubFrameWorkSide
    {
        Bottom = 0,
        Top = 1,
        Left = 2,
        Right = 3,
    }

    public enum FrameSolutionStatus
    {
        [EnumValue("Design", Globalization.Language.en)]
        [EnumValue("Ontwerp", Globalization.Language.nl)]
        Design,
        [EnumValue("Locked", Globalization.Language.en)]
        [EnumValue("Op slot", Globalization.Language.nl)]
        Locked,
        [EnumValue("In production", Globalization.Language.en)]
        [EnumValue("In productie", Globalization.Language.nl)]
        InProduction,
    }


    public enum FastSelectionRodConfig
    {
        [EnumValue("None", Globalization.Language.en)]
        [EnumValue("Geen", Globalization.Language.nl)]
        None = 0,

        [EnumValue("Solid rods", Globalization.Language.en)]
        [EnumValue("Massief", Globalization.Language.nl)]
        RealRods = 1,

        [EnumValue("Glue rods", Globalization.Language.en)]
        [EnumValue("Plakroeden", Globalization.Language.nl)]
        GlueRods = 2,

        [EnumValue("Wiener sprossen", Globalization.Language.en)]
        [EnumValue("Wiener sprossen", Globalization.Language.nl)]
        Sprossen = 3,
    }

    public enum FastSelectionGlassConfig
    {
        [EnumValue("Normal", Globalization.Language.en)]
        [EnumValue("Normaal", Globalization.Language.nl)]
        Normal = 0,

        [EnumValue("Laminated indoors", Globalization.Language.en)]
        [EnumValue("Binnen gelaagd", Globalization.Language.nl)]
        LaminatedIndoors = 1,

		[EnumValue("Laminated outdoors", Globalization.Language.en)]
		[EnumValue("Buiten gelaagd", Globalization.Language.nl)]
		LaminatedOutdoors = 2,

		[EnumValue("Laminated indoors/outdoors", Globalization.Language.en)]
		[EnumValue("Binnen/buiten gelaagd", Globalization.Language.nl)]
		LaminatedBoth = 3,

		[EnumValue("Hardened", Globalization.Language.en)]
        [EnumValue("Gehard", Globalization.Language.nl)]
        Hardened = 10,
    }

}
