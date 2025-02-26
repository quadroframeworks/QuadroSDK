using Quadro.Documents.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents
{

	/// <summary>
	/// Represents the schema definition and configuration settings for the data types supported by the corresponding data model. 
	/// This class is designed to define the structure, endpoints, and related metadata for interacting with a specific data model in the Quadro system.
    /// It is used in systems that support dynamic data modeling and interaction through the Quadro API.
    /// Actions can be defined directly in this schema, but also in the type descriptions, and even in the property definitions within it. 
    /// An action is always performed on the object where it is defined in.
	/// </summary>
	public class DataTypeSchema
    {
        public string ControllerBaseUri { get; set; } = null!;
        public string GetSchemaEndPoint { get; set; } = null!;
        public string GetSelectableValuesEndPoint { get; set; } = null!;
        public string GetItemsEndPoint { get; set; } = null!;
        public string GetVariantsEndPoint { get; set; } = null!;
		public string GetFilterTreeEndPoint { get; set; } = null!;
		public string SetValueEndPoint { get; set; } = null!;
        public string ValidateEndPoint { get; set; } = null!;
        public string CommitEndPoint { get; set; } = null!;
        public string? DataModelEndPoint {  get; set; }
        public bool SupportsVariants { get; set; }
        public bool SupportsProjectSpecifics { get; set; }
        public bool SupportsFiltering { get; set; }
        public List<NamingTranslation> Headers { get; set; } = new List<NamingTranslation>();
        public List<NamingTranslation> Categories { get; set; } = new List<NamingTranslation>();
        public List<TypeDescription> Types { get; set; } = new List<TypeDescription>();
        public List<ActionDescription> Actions { get; set; } = new List<ActionDescription>();
        public List<FilterProperty> FilterProperties { get; set; } = new List<FilterProperty>(); 
    }

    
}
