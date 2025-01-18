using Quadro.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quadro.Documents
{
    public class NamingTranslation:ITranslationText
    {
        public Language Language { get; set; }
        public string Translation { get; set; } = null!;

    }
    public class EnumTranslation : NamingTranslation
    {
        public string Description { get; set; } = null!;
    }
}
