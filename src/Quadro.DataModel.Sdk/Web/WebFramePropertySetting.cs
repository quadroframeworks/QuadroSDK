using Quadro.Globalization.Attributes;
using Quadro.Interface.CustomProperties;
using Quadro.Interface.Solutions;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Solutions
{
    public class WebFramePropertySetting : StorableGuid, IWebFramePropertySetting
	{
		public WebFramePropertySetting() { }

		[Header("Property", Globalization.Language.en)]
		[Header("Eigenschap", Globalization.Language.nl)]
		public string PropertyName { get; set; } = null!;

		[Header("Value", Globalization.Language.en)]
		[Header("Waarde", Globalization.Language.nl)]
		public double Value { get; set; }

		[Header("Min. value", Globalization.Language.en)]
		[Header("Min. waarde", Globalization.Language.nl)]
		public double MinValue { get; set; }

		[Header("Max. value", Globalization.Language.en)]
		[Header("Max. waarde", Globalization.Language.nl)]
		public double MaxValue { get; set; }

	}
}
