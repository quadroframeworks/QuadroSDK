using Quadro.Globalization;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HeaderAttribute:Attribute
    {
        public HeaderAttribute(string text, Language language)
        {
            Text = text;
            Language = language;
        }
        public string Text { get; }
        public Language Language { get; }
    }
}
