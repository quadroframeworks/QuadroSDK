using Quadro.Base.Catalog;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Catalog;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Entities.Catalog
{

    public class WorkProcessTime : StorableGuid, IWorkProcessTime
	{
		public string? WorkCenterId { get; set; }

		[Unit(Unit.s)]
		public double UnitProcessTime { get; set; }
		public string? ERPId { get; set; }
	}
}
