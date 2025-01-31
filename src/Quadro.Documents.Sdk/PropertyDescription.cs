using Quadro.Base.Catalog;
using System.Text.Json.Serialization;

namespace Quadro.Documents
{
	public class PropertyDescription
    {
        public PropertyDescription() { }

        public List<NamingTranslation> Headers { get; set; } = new List<NamingTranslation>();
        public List<NamingTranslation> Categories { get; set; } = new List<NamingTranslation>();
        public string Header { get; set; } = null!;
        public string PropertyName { get; set; } = null!;
        public int DisplayIndex { get; set; }
        public DisplayType DisplayType { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; } = ExperienceLevel.Basic;
        public bool IsExpression { get; set; }
        public bool IsScript { get; set; }
        public bool IsImage { get; set; }
        public Unit Unit { get; set; }
        public string Type { get; set; } = null!;
        public double? MinValue { get; set; } = null;
        public double? MaxValue { get; set; } = null;
        public bool AllowNull { get; set; }
        public bool IsReadonly { get; set; } = false;
        public bool IsEnum { get; set; }
        public bool IsColumnVisible { get; set; } = true;
        public bool ShowColumnActionOnly { get; set; } = false;
		public ValueType ValueType { get; set; }
        public SelectableValueCollection? EnumValues { get; set; }
        public PropertySelectionType SelectionType { get; set; }
        public string? SelectableItemsEndpoint { get; set; }
        public string ValueEndpoint { get; set; } = null!;
        public List<ActionDescription> Actions { get; set; } = new List<ActionDescription>();

        [JsonIgnore]
        public Func<DataDocument, DataInstance, bool>? IsVisibleCondition { get; set; }

        [JsonIgnore]
        public Func<DataDocument, DataInstance, SelectableValueCollection>? SelectableItemsSelector { get; set; }

        [JsonIgnore]
        public Func<DataDocument, DataInstance, ValueProperty, bool>? Validator { get; set; }

    }

    public enum ValueType
    {
        Value,
        Object,
        List,
    }

    public enum PropertySelectionType
    {
        SingleValue,
        StaticMultiValue,
        DynamicMultiValue,
    }

    public enum DisplayType
    {
        Value = 0,
        Name = 1,
        Description=2,
        Id = 3,
    }

    public enum ExperienceLevel
    {
        Basic = 0,
        Advanced = 1,
        Admin = 2,
    }
}
