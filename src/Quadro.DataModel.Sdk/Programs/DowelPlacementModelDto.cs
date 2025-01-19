using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model.Programs
{
	public class DowelPlacementModelDto
	{
		public string? DowelId { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public double Diameter { get; set; }
		public double PlugTecWidth { get; set; }
		public bool IsPlugTec { get; set; }
	}
}
