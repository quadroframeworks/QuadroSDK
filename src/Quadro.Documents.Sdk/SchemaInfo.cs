using Quadro.Documents;

namespace Quadro.Documents
{
    public class SchemaInfo
    {
        public string EndPoint { get; set; } = null!;
        public List<NamingTranslation> Headers { get; set; } = new List<NamingTranslation>();
        public List<NamingTranslation> Categories { get; set; } = new List<NamingTranslation>();

    }
}
