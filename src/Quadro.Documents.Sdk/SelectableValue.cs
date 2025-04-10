using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents
{
    public class SelectableValue
    {
        public SelectableValue() { }
        public static SelectableValue FromEnumValue(object enumvalue) => new SelectableValue(enumvalue);
        private SelectableValue(object enumvalue)
        {
            Value = ((int)enumvalue).ToString();
            Description = enumvalue.ToString()!;
        }


        public SelectableValue(string value, string description) 
        { 
            Value = value;
            Description = description;
        }

		public SelectableValue(string value, string description, string filterstring)
		{
			Value = value;
			Description = description;
            FilterString = filterstring;
		}

		public string Description { get; set; } = null!;
        public string? Value { get; set; }
        public string? FilterString { get; set; }
        public string? ThumbnailId { get; set; }
        public List<EnumTranslation>? Translations { get; set; }

    }

    public class SelectableValueCollection
    {
        public SelectableValueCollection() { }
        public List<SelectableValue> Values { get; set; } = new List<SelectableValue>();
        public string? ThumbnailEndpoint { get; set; }
    }
}
