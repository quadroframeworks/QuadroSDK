using Quadro.Base.Catalog;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Production;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Catalog
{
    public class WorkCenterDto : StorableGuid, IWorkCenterEntity
	{
		public string Name { get; set; } = "?";

		[Unit(Unit.Euro)]
		public double CostPerHour { get; set; }

		[Unit(Unit.Euro)]
		public double CostPerHourEmployee { get; set; }
		public int NrOfEmployees { get; set; }
		public string? ERPId { get; set; }
	}
}
