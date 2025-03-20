using Quadro.Documents;

namespace Quadro.Documents
{
    public class SchemaInfo
    {
        public SchemaInfo()
        {

        }
        public string TypeName { get; set; } = null!;
        public string EntityName { get; set; } = null!;
        public string GetSchemaEndPoint { get; set; } = null!;
        public List<NamingTranslation> Headers { get; set; } = new List<NamingTranslation>();
        public List<NamingTranslation> Categories { get; set; } = new List<NamingTranslation>();

    }
}
