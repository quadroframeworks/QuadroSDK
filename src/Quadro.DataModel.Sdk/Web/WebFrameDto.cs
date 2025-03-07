﻿using Quadro.DataModel.Entities.Solutions;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Assemblies;
using Quadro.Interface.Enums;
using Quadro.Interface.Solutions;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Web
{
    public class WebFrameDto : StorableGuid
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

        [Header("Border group", Globalization.Language.en)]
        [Header("Spouwlatten groep", Globalization.Language.nl)]
        public string? BorderAssemblyGroupId { get; set; }

        [Header("Border", Globalization.Language.en)]
		[Header("Spouwlatten", Globalization.Language.nl)]
		public string? BorderApplicationId { get; set; }

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

		[Header("Configuration", Globalization.Language.en)]
		[Header("Configuratie", Globalization.Language.nl)]
		public FillingTurnConfiguration TurnConfiguration { get; set; }

		[Header("Turn side", Globalization.Language.en)]
		[Header("Draairichting", Globalization.Language.nl)]
		public TurnSide TurnSide { get; set; }

		[Header("Width", Globalization.Language.en)]
		[Header("Breedte", Globalization.Language.nl)]
		public double Width { get; set; }

		[Header("Height", Globalization.Language.en)]
		[Header("Hoogte", Globalization.Language.nl)]
		public double Height { get; set; }

		[Header("Filling group", Globalization.Language.en)]
		[Header("Vullinggroep", Globalization.Language.nl)]
		public string? AssemblyGroupId { get; set; }

		[Header("Filling", Globalization.Language.en)]
		[Header("Vakvulling", Globalization.Language.nl)]
		public string? AssemblyApplicationId { get; set; }

		[Header("Glass", Globalization.Language.en)]
		[Header("Glas", Globalization.Language.nl)]
		public string? GlassApplicationId { get; set; }

		[Header("Glass type", Globalization.Language.en)]
		[Header("Glas type", Globalization.Language.nl)]
		public FastSelectionGlassConfig GlassConfig { get; set; }

		[Header("Vent grill", Globalization.Language.en)]
		[Header("Ventilatierooster", Globalization.Language.nl)]
		public string? VentGrillId { get; set; }

		[Header("Vent grill color", Globalization.Language.en)]
		[Header("Roosterkleur", Globalization.Language.nl)]
		public string? VentGrillColorId { get; set; }

		[Header("Rod config", Globalization.Language.en)]
		[Header("Roedes", Globalization.Language.nl)]
		public FastSelectionRodConfig RodConfig { get; set; }

		[Header("Input priority", Globalization.Language.en)]
		[Header("Ingave prioriteit", Globalization.Language.nl)]
		public int InputPriority { get; set; }

		[Header("Properties", Globalization.Language.en)]
		[Header("Eigenschappen", Globalization.Language.nl)]
		public List<WebFramePropertySetting> Properties { get; set; } = new List<WebFramePropertySetting>();
	}

}
