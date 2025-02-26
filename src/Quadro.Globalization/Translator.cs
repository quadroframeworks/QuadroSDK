using Quadro.Base.Catalog;
using Quadro.Globalization.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization
{
    public class Translator
    {
        public CultureInfo CurrentCulture { get; private set; } = new CultureInfo("en-US");
        
        public Language CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                currentLanguage = value;
                switch (currentLanguage)
                {
                    case Language.en:
                        CurrentCulture = new CultureInfo("en-US");
                        break;
                    case Language.nl:
                        CurrentCulture = new CultureInfo("nl-NL");
                        break;
                }
                CurrentLanguageChanged?.Invoke(this, EventArgs.Empty);
            }
           
        }
        private Language currentLanguage = Language.en;
        public event EventHandler? CurrentLanguageChanged;
        public string Translate(ITranslatable translatable)
        {

            var result = translatable.Translate(currentLanguage);
            return result;
        }

        public string? Translate(IEnumerable<ITranslationText> possibletexts)
        {
            var result = possibletexts.SingleOrDefault(t => t.Language == currentLanguage);
            if (result == null)
                result = possibletexts.FirstOrDefault();
            return result?.Translation;
        }

        public string? TranslateUnit(Unit unit)
        {
            if (unit == Unit.Unknown)
                return null;
            else if (unit == Unit.Piece)
                return null;
            else if (unit == Unit.Euro)
                return "€";
            else if (unit == Unit.Percentage)
                return "%";

            var cached = unitTranslations.TryGetValue(unit, out string? unitTranslation);
            if (!cached)
            {
                unitTranslation = unit.ToString();
                unitTranslations.Add(unit, unitTranslation);
            }
            return unitTranslation;
        }

        private Dictionary<Unit, string> unitTranslations = new Dictionary<Unit, string>();


        public string? TranslateEnum<T>(T enumvalue, Language language) where T : struct
        {


            var enumtype = typeof(T);

            var enummember = enumtype.GetMember(enumvalue.ToString()!);
            var attributes = enummember[0].GetCustomAttributes(typeof(EnumValueAttribute), false);
            foreach (var attribute in attributes.OfType<EnumValueAttribute>())
            {
                if (attribute.Language != language)
                    continue;

                return attribute.Text;
            }

            return enumvalue.ToString();

        }
    }
}
