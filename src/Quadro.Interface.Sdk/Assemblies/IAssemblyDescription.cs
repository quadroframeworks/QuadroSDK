using Quadro.Globalization.Attributes;
using Quadro.Interface.Context;
using Quadro.Interface.CustomProperties;
using Quadro.Interface.Enums;
using Quadro.Interface.Profiles;
using Quadro.Interface.Solutions;
using Quadro.Interface.WireFrames;

namespace Quadro.Interface.Assemblies
{

	public interface IAssemblyDescription : ICustomizable
    {
        string Id { get; }
        string Name { get; set; }
        string? WireFrameId { get; } //Used for filtering, subframes must be of this wire frame type
        AssemblyType AssemblyType { get; }
        AssemblyContentType ContentType { get; }
        string? AssemblyGroupId { get; set; }
        string? AssemblyApplicationId { get; set; }
        double RabbetSpacingZ { get; }
        string BottomOffset { get; }
        string? CatalogItemId { get; set; }
        double TestPartHeightAncestor { get; }
        string? TestPlacementOptionId { get; set; }
        string? TestHingAndLockOptionId { get; set; }
        string? TestPurchasedDoorId { get; set; }
        string? TestRabbetSelectionId { get; }
        string? TestSillId { get; }
        IEnumerable<IParentRabbetReference> Rabbets { get; }
        IEnumerable<ISubFramePlacement> SubFrames { get; }
        IEnumerable<IOperationSetPlacement> OperationSets { get; }
        IEnumerable<IRabbetSelectionFilter> RabbetSelectionFilters { get; }
    }
    public interface IMainAssemblyDescription : IAssemblyDescription
    {


    }


    public interface IFillingAssemblyDescription : IAssemblyDescription
    {
        FrameContextType AncestorContextType { get; } //Used for filtering and more. This filling can only be applied to this ancestor
        string? RabbetSystemId { get; }
        string? ExpressionEnable { get; }
        FillingTurnConfiguration TurnConfiguration { get; set; }
        TurnSide TurnSide { get; set; }
        MultiCompartmentMode MultiCompartmentMode { get; }
        int NrOfMultiCompartments { get; }
        IEnumerable<IMultiCompartmentDivider> Dividers { get; }
    }

    public interface IBorderAssemblyDescription : IAssemblyDescription
    {
        string? RabbetSystemId { get; }
        string? ExpressionEnable { get; }
    }

    public interface ISubFrameWorkAssemblyDescription : IAssemblyDescription
	{
		string? ExpressionEnable { get; }
	}

    public interface IAssemblyFilling
    {
        string Id { get; }
        string SubFramePlacementId { get; }
        string? Name { get; }
        AssemblyFillingType Type { get; }
		public string? AssemblyGroupId { get; set; }
		public string? AssemblyApplicationId { get; set; }
		public string? FillingAssemblyId { get; set; }
		public string? RabbetSelectionId { get; set; }
		FillingTurnConfiguration TurnConfiguration { get; set; }
        TurnSide TurnSide { get; set; }
        ICompartmentDescription Compartment { get; }

    }





	public enum AssemblyType
    {
        [EnumValue("Main frame", Globalization.Language.en)]
        [EnumValue("Basisframe", Globalization.Language.nl)]
        MainFrame,
        [EnumValue("Border", Globalization.Language.en)]
        [EnumValue("Spouwlatten", Globalization.Language.nl)]
        Border,
        [EnumValue("Filling", Globalization.Language.en)]
        [EnumValue("Vakvulling", Globalization.Language.nl)]
        Filling,
		[EnumValue("Framework", Globalization.Language.en)]
		[EnumValue("Rekwerk", Globalization.Language.nl)]
		FrameWork,
	}

    public enum AssemblyContentType
    {
        [EnumValue("Border", Globalization.Language.en)]
        [EnumValue("Spouwlatten", Globalization.Language.nl)]
        Border,
        [EnumValue("Frame", Globalization.Language.en)]
        [EnumValue("Kozijn", Globalization.Language.nl)]
        Frame,
        [EnumValue("Window", Globalization.Language.en)]
        [EnumValue("Raam", Globalization.Language.nl)]
        Window,
        [EnumValue("Door", Globalization.Language.en)]
        [EnumValue("Deur", Globalization.Language.nl)]
        Door,
        [EnumValue("Glass", Globalization.Language.en)]
        [EnumValue("Glas", Globalization.Language.nl)]
        Glass,
        [EnumValue("Plate", Globalization.Language.en)]
        [EnumValue("Plaat", Globalization.Language.nl)]
        Plate,
		[EnumValue("Framework", Globalization.Language.en)]
		[EnumValue("Rekwerk", Globalization.Language.nl)]
		Framework,
	}

    public enum AssemblyFillingType
    {
        [EnumValue("No filling", Globalization.Language.en)]
        [EnumValue("Geen", Globalization.Language.nl)]
        NoFilling = 0,
        [EnumValue("Glass", Globalization.Language.en)]
        [EnumValue("Glasvak", Globalization.Language.nl)]
        Glass = 100,
        [EnumValue("Fixed by assembly", Globalization.Language.en)]
        [EnumValue("Vast door samenstelling", Globalization.Language.nl)]
        ByAssembly = 200,
        [EnumValue("By user", Globalization.Language.en)]
        [EnumValue("Door gebruiker", Globalization.Language.nl)]
        ByUser = 300,
    }

    public interface ISubFramePlacement
    {
        string Id { get; }
        bool IsBase { get; }
        int SubFrameIndex { get; }
        SubFrameType SubFrameType { get; }
        FrameContextType ContextType { get; } //Used for filtering
        bool IsLocked { get; }
        bool FlipFillingSide { get; }
        bool IsSubCompartment { get; set; }
        int MultiCompartmentIndex { get; set; }
        bool AllowFilling { get; set; }
        bool AllowVentGrill { get; set; }
        bool AllowSill { get; set; }
        double WireOffsetZ { get; }
        public string? OuterMillingId { get; set; }
        string? PlateId { get; set; }
        string? DowelApplicationId { get; }
        IEnumerable<IPlacementOption> Options { get; }
        IEnumerable<IWireOffset> WireOffsets { get; }
        IEnumerable<IProfileStyle> ProfileStyles { get; }
    }

    public interface IPlacementOption
    {
        string? OptionId { get; }
        bool IsPurchasedDoor { get; }

        //Depending on type, one of these has a value
        string? RawFrameId { get; }
        string? HingeAndLockId { get; set; }
    }

    public interface IParentRabbetReference
    {
        string Id { get; }
        double SpacingY { get; }
        WireIdentifier WireId { get; }

    }

    public interface IProfileProgramSetter
    {
        double PartHeight { get; }
        public string? SillId { get; set; }
        string? ProfileProgramIdAncestor { get; }
    }

    public interface IWireOffset
    {
        string Id { get; }
        double OffsetY { get; }
        WireIdentifier WireId { get; }
    }

    public interface IMultiCompartmentDivider
    {
        int Index { get; }
        double Offset { get; }
    }

    public interface IRabbetReferencePoint
    {
        ReferencePointType Type { get; }
        double X { get; set; }
        double Y { get; set; }
    }

    public interface IRabbetSelectionFilter
    {
		public string? RabbetSelectionId { get; set; }
		public string? RabbetSelectionName { get; set; }
		public bool Allowed { get; set; }
	}

    public enum ReferencePointType
    {
        [EnumValue("Inside edge", Globalization.Language.en)]
        [EnumValue("Binnenrand", Globalization.Language.nl)]
        InsideEdge,
        [EnumValue("Outside edge", Globalization.Language.en)]
        [EnumValue("Buitenrand", Globalization.Language.nl)]
        OutsideEdge,
    }

    public enum SubFrameType
    {
        [EnumValue("Parts frame", Globalization.Language.en)]
        [EnumValue("Onderdeelframe", Globalization.Language.nl)]
        PartsFrame,
        [EnumValue("Glass", Globalization.Language.en)]
        [EnumValue("Glas", Globalization.Language.nl)]
        Glass,
        [EnumValue("Plate", Globalization.Language.en)]
        [EnumValue("Plaat", Globalization.Language.nl)]
        Plate,
        [EnumValue("Hinge and lock", Globalization.Language.en)]
        [EnumValue("Hang en sluit", Globalization.Language.nl)]
        HingeAndLock,
    }

    public interface IOperationSetPlacement
    {
        string FrameOperationSetId { get; }
    }


    public enum FillingTurnConfiguration
    {

        [EnumValue("Free", Globalization.Language.en)]
        [EnumValue("Vrij", Globalization.Language.nl)]
        Free = 0,

        [EnumValue("Fixed indoors", Globalization.Language.en)]
        [EnumValue("Vast glas binnen", Globalization.Language.nl)]
        FixedIndoors = 5,
        [EnumValue("Fixed outdoors", Globalization.Language.en)]
        [EnumValue("Vast glas buiten", Globalization.Language.nl)]
        FixedOutdoors = 10,

        [EnumValue("Turn indoors", Globalization.Language.en)]
        [EnumValue("Binnendraaidend", Globalization.Language.nl)]
        TurnSideIndoors = 20,
        [EnumValue("Turn outdoors", Globalization.Language.en)]
        [EnumValue("Buitendraaiend", Globalization.Language.nl)]
        TurnSideOutdoors = 30,

        [EnumValue("Turn top", Globalization.Language.en)]
        [EnumValue("Uitzet", Globalization.Language.nl)]
        TurnTop = 60,

        [EnumValue("Fall", Globalization.Language.en)]
        [EnumValue("Val", Globalization.Language.nl)]
        Fall = 70,

        [EnumValue("Turn/fall", Globalization.Language.en)]
        [EnumValue("Draaival", Globalization.Language.nl)]
        TurnFall = 90,

        [EnumValue("Slide", Globalization.Language.en)]
        [EnumValue("Schuif", Globalization.Language.nl)]
        Slide = 110,

        [EnumValue("Revolve", Globalization.Language.en)]
        [EnumValue("Klap", Globalization.Language.nl)]
        Revolve = 130,

        [EnumValue("Double indoors", Globalization.Language.en)]
        [EnumValue("Stolp binnen", Globalization.Language.nl)]
        DoubleIndoors = 1000,

        [EnumValue("Double outdoors", Globalization.Language.en)]
        [EnumValue("Stolp buiten", Globalization.Language.nl)]
        DoubleOutdoors = 1010,

        [EnumValue("Multi", Globalization.Language.en)]
        [EnumValue("Meervoudig", Globalization.Language.nl)]
        Multi = 1020,
    }

    public enum DistributionTrigger
    {
        [EnumValue("Off", Globalization.Language.en)]
        [EnumValue("Uit", Globalization.Language.nl)]
        Off = 0,

        [EnumValue("On", Globalization.Language.en)]
        [EnumValue("Aan", Globalization.Language.nl)]
        On = 1,

        [EnumValue("Solid rods", Globalization.Language.en)]
        [EnumValue("Massief", Globalization.Language.nl)]
        WhenRealRods = 2,

        [EnumValue("Glue rods", Globalization.Language.en)]
        [EnumValue("Plakroeden", Globalization.Language.nl)]
        WhenGlueRods = 3,

        [EnumValue("Wiener sprossen", Globalization.Language.en)]
        [EnumValue("Wiener sprossen", Globalization.Language.nl)]
        WhenSprossen = 4,
    }

    public enum MultiCompartmentMode
    {
        [EnumValue("None", Globalization.Language.en)]
        [EnumValue("Geen", Globalization.Language.nl)]
        None,
        [EnumValue("Vertical", Globalization.Language.en)]
        [EnumValue("Verticaal", Globalization.Language.nl)]
        Vertical,
        [EnumValue("Horizontal", Globalization.Language.en)]
        [EnumValue("Horizontaal", Globalization.Language.nl)]
        Horizontal,
    }


}
