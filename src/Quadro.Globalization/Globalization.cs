using Quadro.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization
{
    public class StaticTranslator
    {
        public static Translator Instance { get; } = new Translator();

    }

    
}
