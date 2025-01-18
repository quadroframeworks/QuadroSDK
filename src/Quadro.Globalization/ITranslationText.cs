using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Globalization
{
    public interface ITranslationText
    {
        Language Language { get; set; }
        string Translation { get; set; }
    }
}
