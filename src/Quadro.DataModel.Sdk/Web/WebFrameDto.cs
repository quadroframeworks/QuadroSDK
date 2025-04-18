using Quadro.DataModel.Entities.Solutions;
using Quadro.DataModel.Model;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Assemblies;
using Quadro.Interface.Enums;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Web
{
    public class WebFrameDto : StorableGuid, IWebFrameDto
    {
        public WebFrameDto() { }

        [Header("Web order", Globalization.Language.en)]
        [Header("Weborder", Globalization.Language.nl)]
        public string WebOrderId { get; set; } = null!;

        [Header("State", Globalization.Language.en)]
        [Header("Status", Globalization.Language.nl)]
        public WebOrderState WebOrderState { get; set; }

        [Header("Tag", Globalization.Language.en)]
        [Header("Merk", Globalization.Language.nl)]
        public string Tag { get; set; } = null!;

        [Header("Base model", Globalization.Language.en)]
        [Header("Basismodel", Globalization.Language.nl)]
        public string? SolutionModelId { get; set; }

        [Header("Decoration", Globalization.Language.en)]
        [Header("Decoratie", Globalization.Language.nl)]
        public string? DecorationGroupId { get; set; }

        [Header("Part height", Globalization.Language.en)]
        [Header("Basismaat", Globalization.Language.nl)]
        public string? PartHeightId { get; set; }

        [Header("Description", Globalization.Language.en)]
        [Header("Omschrijving", Globalization.Language.nl)]
        public string Description { get; set; } = string.Empty;

        [Header("Color", Globalization.Language.en)]
        [Header("Kleur", Globalization.Language.nl)]
        public string? ColorId { get; set; }

        [Header("Filling color", Globalization.Language.en)]
        [Header("Kleur vakvullingen", Globalization.Language.nl)]
        public string? FillingColorId { get; set; }

        [Header("Material", Globalization.Language.en)]
        [Header("Materiaal", Globalization.Language.nl)]
        public string? RawMaterialId { get; set; }

        [Header("Paint system", Globalization.Language.en)]
        [Header("Verfsysteem", Globalization.Language.nl)]
        public string? PaintSystemId { get; set; }

        [Header("Glass", Globalization.Language.en)]
        [Header("Glas", Globalization.Language.nl)]
        public string? GlassGroupId { get; set; }

        [Header("Sill", Globalization.Language.en)]
        [Header("Onderdorpel", Globalization.Language.nl)]
        public bool ApplySill { get; set; }

        [Header("Border", Globalization.Language.en)]
        [Header("Spouwlatten", Globalization.Language.nl)]
        public bool ApplyBorder { get; set; }

        [Header("Max. U-value", Globalization.Language.en)]
        [Header("Max. U-waarde", Globalization.Language.nl)]
        [Unit(Base.Catalog.Unit.Wperm2K)]
        public double MaxUValue { get; set; }

        [Header("Properties", Globalization.Language.en)]
        [Header("Eigenschappen", Globalization.Language.nl)]
        public List<WebFramePropertySetting> Properties { get; set; } = new List<WebFramePropertySetting>();

        [Header("Fillings", Globalization.Language.en)]
        [Header("Vakvullingen", Globalization.Language.nl)]
        public List<WebFrameFillingDto> Fillings { get; set; } = new List<WebFrameFillingDto>();

    }

    public class WebFrameFillingDto : StorableGuid
	{
		public WebFrameFillingDto() { }

		[Header("Compartment", Globalization.Language.en)]
		[Header("Vak", Globalization.Language.nl)]
		public string Compartment { get; set; } = null!;

		[Header("Turn side", Globalization.Language.en)]
		[Header("Draairichting", Globalization.Language.nl)]
		public TurnSide TurnSide { get; set; }

		[Header("Width", Globalization.Language.en)]
		[Header("Breedte", Globalization.Language.nl)]
		public double Width { get; set; }

		[Header("Height", Globalization.Language.en)]
		[Header("Hoogte", Globalization.Language.nl)]
		public double Height { get; set; }

        [Header("Is glass filling", Globalization.Language.en)]
        [Header("Is glasvulling", Globalization.Language.nl)]
        public bool IsGlassFilling { get; set; }


		[Header("Filling group", Globalization.Language.en)]
		[Header("Vullinggroep", Globalization.Language.nl)]
		public string? AssemblyGroupId { get; set; }

        [Header("Filling option", Globalization.Language.en)]
        [Header("Vuloptie", Globalization.Language.nl)]
        public string? AssemblyFillingOptionId { get; set; }

        [Header("Glass filling option", Globalization.Language.en)]
        [Header("Vuloptie glas", Globalization.Language.nl)]
        public string? GlassFillingOptionId { get; set; }

        [Header("Purchased door", Globalization.Language.en)]
        [Header("Koopdeur", Globalization.Language.nl)]
        public string? PurchasedDoorId { get; set; }

        [Header("Use safety glass", Globalization.Language.en)]
		[Header("Veiligheidsglas", Globalization.Language.nl)]
		public bool UseSafetyGlass { get; set; }

		[Header("Vent grill", Globalization.Language.en)]
		[Header("Ventilatierooster", Globalization.Language.nl)]
		public string? VentGrillId { get; set; }

		[Header("Vent grill color", Globalization.Language.en)]
		[Header("Roosterkleur", Globalization.Language.nl)]
		public string? VentGrillColorId { get; set; }

		[Header("Input priority", Globalization.Language.en)]
		[Header("Ingave prioriteit", Globalization.Language.nl)]
		public int InputPriority { get; set; }

		[Header("Properties", Globalization.Language.en)]
		[Header("Eigenschappen", Globalization.Language.nl)]
		public List<WebFramePropertySetting> Properties { get; set; } = new List<WebFramePropertySetting>();
	}

}
