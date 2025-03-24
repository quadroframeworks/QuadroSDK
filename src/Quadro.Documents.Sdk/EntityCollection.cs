using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.Sdk
{
    public class EntityCollection
    {
        public List<EntityPropertyHeader> Headers { get; set; } = new List<EntityPropertyHeader>();
        public List<EntitySummary> Entities { get; set; } = new List<EntitySummary>();
    }


    public class EntityPropertyHeader
    {
        public string PropertyName { get; set; } = null!;
        public string? Unit { get; set; }
        public List<NamingTranslation> Translations { get; set; } = new List<NamingTranslation>();
    }

    public class EntitySummary
    {
        public string Id { get; set; } = null!;
        public string? FilterString { get; set; }
        public List<string?> Values { get; set; } = new List<string?>();
    }
}
