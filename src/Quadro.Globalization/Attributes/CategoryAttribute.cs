using Quadro.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public class CategoryAttribute:Attribute
    {
        public CategoryAttribute(string text, Language language)
        {
            Text = text;
            Language = language;
        }
        public string Text { get; }
        public Language Language { get; }
    }
}
