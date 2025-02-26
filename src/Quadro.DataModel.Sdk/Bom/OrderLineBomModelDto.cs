using Quadro.DataModel.Bom;
using Quadro.DataModel.Model;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Entities.Projects
{
	public class OrderLineBomModelDto : StorableGuid
	{
		public OrderLineBomModelDto()
		{

		}
		public BomModelDto BomAsDesigned { get; set; } = null!;
		public BomModelDto BomMirrored { get; set; } = null!;
		public MainAssemblyModelDto Model { get; set; } = null!;
	}
}
