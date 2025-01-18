namespace Quadro.Documents
{

    public class TypeDescription
    {
        public string FullTypeName { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public List<PropertyDescription> Properties { get; set; } = new List<PropertyDescription>();
        public List<ActionDescription> Actions { get; set; } = new List<ActionDescription>();
    }


}