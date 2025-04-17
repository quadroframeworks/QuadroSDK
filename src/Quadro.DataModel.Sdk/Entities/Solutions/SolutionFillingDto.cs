using Quadro.DataModel.CustomProperties;
using Quadro.DataModel.Entities.Assemblies;
using Quadro.Documents.Attributes;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Assemblies;
using Quadro.Interface.Enums;
using Quadro.Interface.RawFrames;
using Quadro.Interface.Solutions;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Entities.Solutions
{
	public class SolutionFillingDto : Customizable, ISolutionFilling
	{
		public SolutionFillingDto()
		{
		}

		[Header("Compartment", Globalization.Language.en)]
		[Header("Vak", Globalization.Language.nl)]
		public string? Name { get; set; }

		[Header("Configuration", Globalization.Language.en)]
		[Header("Configuratie", Globalization.Language.nl)]
		public FillingTurnConfiguration TurnConfiguration { get; set; }

		[Header("Turn side", Globalization.Language.en)]
		[Header("Draairichting", Globalization.Language.nl)]
		public TurnSide TurnSide { get; set; }

        [Header("Is glass filling", Globalization.Language.en)]
        [Header("Is glasvulling", Globalization.Language.nl)]
        public bool IsGlassFilling { get; set; }

		[Header("Filling group", Globalization.Language.en)]
		[Header("Vullinggroep", Globalization.Language.nl)]
		public string? AssemblyGroupId { get; set; }

		[Header("Filling application", Globalization.Language.en)]
		[Header("Toepassing vulling", Globalization.Language.nl)]
		public string? AssemblyApplicationId { get; set; }

		[Header("Filling assembly", Globalization.Language.en)]
		[Header("Vulsamenstelling", Globalization.Language.nl)]
		public string? FillingAssemblyId { get; set; }

        [Header("Filling option", Globalization.Language.en)]
        [Header("Vuloptie", Globalization.Language.nl)]
        public string? PlacementOptionId { get; set; }

        [Header("Hinge and lock option", Globalization.Language.en)]
        [Header("Hang- en sluitwerkoptie", Globalization.Language.nl)]
        public string? HingeAndLockOptionId { get; set; }

        [Header("Purchased door", Globalization.Language.en)]
        [Header("Koopdeur", Globalization.Language.nl)]
        public string? PurchasedDoorId { get; set; }

        [Header("Rabbet system", Globalization.Language.en)]
        [Header("Sponningsysteem", Globalization.Language.nl)]
        public string? RabbetSystemId { get; set; }

        [Header("Raw material", Globalization.Language.en)]
		[Header("Ruw materiaal", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		public string? RawMaterialId { get; set; }

		[Header("Glass", Globalization.Language.en)]
		[Header("Glas", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		public string? GlassId { get; set; }

		[Header("Vent grill", Globalization.Language.en)]
		[Header("Ventilatierooster", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		public string? VentGrillId { get; set; }

		[Header("Vent grill color", Globalization.Language.en)]
		[Header("Kleur rooster", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		public string? VentGrillColorId { get; set; }

		[Header("Coating", Globalization.Language.en)]
		[Header("Coating", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		public string? PaintSystemId { get; set; }

		[Header("Color", Globalization.Language.en)]
		[Header("Kleur", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		public string? ColorId { get; set; }

		[Header("Parent type", Globalization.Language.en)]
		[Header("Vooroudertype", Globalization.Language.nl)]
		public AssemblyContentType ParentAssemblyType { get; set; }

		[Header("Allow vent grill", Globalization.Language.en)]
		[Header("Ventilatierooster toestaan", Globalization.Language.nl)]
		[Category("Web", Globalization.Language.en)]
		[Category("Web", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public bool AllowVentGrill { get; set; }

		[JsonIgnore]
		public ICompartmentDescription Compartment => compartment;

		[Header("Compartment", Globalization.Language.en)]
		[Header("Compartiment", Globalization.Language.nl)]
		[DisplayIndex(103)]
		public CompartmentDto compartment { get; set; } = null!;

		[JsonIgnore]
		public IEnumerable<IPartConfiguration> PartConfigurations => partConfigurations;
		[Header("Parts", Globalization.Language.en)]
		[Header("Onderdelen", Globalization.Language.nl)]
		[DisplayIndex(100)]
		public List<PartConfigurationDto> partConfigurations { get; set; } = new List<PartConfigurationDto>();

		[JsonIgnore]
		public IEnumerable<IOperationSetPlacement> OperationSets => operationSets;
		[Header("Operation sets", Globalization.Language.en)]
		[Header("Bewerkingen", Globalization.Language.nl)]
		[DisplayIndex(101)]
		public List<FrameOperationSetPlacement> operationSets { get; set; } = new List<FrameOperationSetPlacement>();

		[JsonIgnore]
		public IEnumerable<ISolutionFilling> Fillings => fillings;
		[Header("Fillings", Globalization.Language.en)]
		[Header("Vullingen", Globalization.Language.nl)]
		[DisplayIndex(102)]
		public List<SolutionFillingDto> fillings { get; set; } = new List<SolutionFillingDto>();
    }
}
