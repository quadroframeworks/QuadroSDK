using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.Filtering
{
	public class FilterProperty
	{
		public int Index { get; set; }
		public string PropertyName { get; set; } = null!;
		public bool IsEnum { get; set; }
		public List<EnumTranslation>? EnumHeaders { get; set; }
	}
}
