using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Projects
{
    public class LineBase : StorableGuid, ILineBase
	{

		[Header("Tag", Globalization.Language.en)]
		[Header("Merk", Globalization.Language.nl)]
		public string Tag { get; set; } = string.Empty;

		[Header("ERP id as designed", Globalization.Language.en)]
		[Header("ERP id getekend", Globalization.Language.nl)]
		public string? ERPIdAsDesigned { get; set; }

		[Header("ERP id mirrored", Globalization.Language.en)]
		[Header("ERP id gespiegeld", Globalization.Language.nl)]
		public string? ERPIdMirrored { get; set; }

		[Header("Quantity as designed", Globalization.Language.en)]
		[Header("Aantal getekend", Globalization.Language.nl)]
		public int QuantityAsDesigned { get; set; }

		[Header("Quantity mirrored", Globalization.Language.en)]
		[Header("Aantal gespiegeld", Globalization.Language.nl)]
		public int QuantityMirrored { get; set; }
	}
}
