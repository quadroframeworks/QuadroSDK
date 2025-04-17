using Quadro.Globalization.Attributes;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Solutions
{
    public class DecorationGroupDto : StorableGuid
    {
        public string Name { get; set; } = string.Empty;
        public List<DecorationContext> decorationContexts { get; set; } = new List<DecorationContext>();
    }

    public class DecorationContext : StorableGuid
    {
        public string? AssemblyGroupId { get; set; }
        public string? FillingApplicationId { get; set; }
        public string? GlassApplicationId { get; set; }

        [Header("Fast selections", Globalization.Language.en)]
        [Header("Snelselecties", Globalization.Language.nl)]
        public List<AssemblyFastSelection> fastSelections { get; set; } = new List<AssemblyFastSelection>();
    }

    public class AssemblyFastSelection : StorableGuid
    {
        public double MinGlassThickness { get; set; }
        public double MaxGlassThickness { get; set; }
        public string? FillingAssemblyId { get; set; }
        public string? RabbetSystemId { get; set; }
        public string? GlassAssemblyId { get; set; }
        public string? GlassRabbetSystemId { get; set; }
        public double CalcMaxGlassThickness { get; set; }
        public double CalcMinFillingRabbetWidth { get; set; }
        public double CalcMinGlassRabbetWidth { get; set; }

    }
}
