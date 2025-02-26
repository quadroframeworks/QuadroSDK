﻿using Quadro.Globalization.Attributes;
using Quadro.Interface.Context;
using Quadro.Interface.CustomProperties;
using Quadro.Interface.Enums;
using Quadro.Interface.Profiles;
using Quadro.Interface.RawFrames;
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
        double RabbetOffsetZ { get; }
        double RabbetSpacingZ { get; }
        string BottomOffset { get; }
        string? CatalogItemId { get; set; }
        string? TestRabbetSelectionId { get; }
        public string? TestSillId { get; }
        FastSelectionRodConfig TestRodConfig { get; set; }
        IEnumerable<IParentRabbetReference> Rabbets { get; }
        IEnumerable<ISubFramePlacement> SubFrames { get; }
        IEnumerable<IPartConfiguration> PartConfigurations { get; }
        IEnumerable<IOperationSetPlacement> OperationSets { get; }
        IEnumerable<IAssemblyFilling> Fillings { get; }
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


    public interface IAssemblyFilling
    {
        string Id { get; }
        string SubFramePlacementId { get; }
        string? Name { get; }
        AssemblyFillingType Type { get; }
        string? AssemblyApplicationId { get; }
        string? GlassApplicationId { get; }
        string? FillingAssemblyId { get; set; }
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
    }

    public enum AssemblyFillingType
    {
        [EnumValue("Undefined", Globalization.Language.en)]
        [EnumValue("Geen", Globalization.Language.nl)]
        Undefined = 0,
        [EnumValue("Glass", Globalization.Language.en)]
        [EnumValue("Glasvak", Globalization.Language.nl)]
        Glass = 1,
        [EnumValue("Plate", Globalization.Language.en)]
        [EnumValue("Plaatvak", Globalization.Language.nl)]
        Plate = 2,
        [EnumValue("Window", Globalization.Language.en)]
        [EnumValue("Raamvak", Globalization.Language.nl)]
        Window = 10,
        [EnumValue("Door", Globalization.Language.en)]
        [EnumValue("Deurvak", Globalization.Language.nl)]
        Door = 11,
        [EnumValue("Glass or window", Globalization.Language.en)]
        [EnumValue("Glas- of raamvak", Globalization.Language.nl)]
        GlassOrWindow = 20,
        [EnumValue("Glass or door", Globalization.Language.en)]
        [EnumValue("Glas- of deurvak", Globalization.Language.nl)]
        GlassOrDoor = 21,
        [EnumValue("By assembly", Globalization.Language.en)]
        [EnumValue("Door samenstelling", Globalization.Language.nl)]
        ByAssembly = 100,
        [EnumValue("By user", Globalization.Language.en)]
        [EnumValue("Door gebruiker", Globalization.Language.nl)]
        ByUser = 101,
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

        //Depending on type, one of these has a value
        string? RawFrameId { get; }
        string? GlassId { get; set; }
        string? PlateId { get; set; }
        string? HingeAndLockId { get; set; }
        bool AllowFilling { get; set; }
        bool AllowVentGrill { get; set; }
        bool AllowSill { get; set; }
        double WireOffsetZ { get; }
        public string? OuterMillingId { get; set; }
        string? DowelApplicationId { get; }
        IEnumerable<IWireOffset> WireOffsets { get; }
        IPartDistribution PartDistribution { get; }
        IEnumerable<IProfileStyle> ProfileStyles { get; }
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

    public interface IPartDistribution
    {
        string Id { get; }
        bool IsDynamic { get; set; }
        DistributionTrigger EnableDistribution { get; set; }
        string NrHorizontal { get; set; }
        string NrVertical { get; set; }
        bool ExtendVertical { get; set; }
        string? DynamicContraId { get; set; }
        string? DynamicSideProfileId { get; set; }
        string? DynamicMidProfileId { get; set; }
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
