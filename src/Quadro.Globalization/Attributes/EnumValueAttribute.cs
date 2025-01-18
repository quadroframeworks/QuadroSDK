using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EnumValueAttribute:Attribute
    {
        public EnumValueAttribute(string text, Language language)
        {
            Text = text;
            Language = language;
        }
        public string Text { get; }
        public Language Language { get; }
    }
}
