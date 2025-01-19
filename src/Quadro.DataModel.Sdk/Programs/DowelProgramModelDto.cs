using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model.Programs
{
	public class DowelProgramModelDto
	{
		public string ProgramId { get; set; } = null!;
		public string Name { get; set; } = null!;
		public double ProfileWidth { get; set; }
		public double ProfileHeight { get; set; }
		public double DefaultDowelDiameter { get; set; }
		public Path2DDto ProfileRight { get; set; } = null!;
		public Path2DDto ProfileLeft { get; set; } = null!;
		public Path2DDto CrossSection { get; set; } = null!;
		public Path2DDto? CrossSectionXJoint { get; set; }
		public List<Path2DDto> ValidDowelBounds { get; set; } = new List<Path2DDto>();
		public List<DowelPlacementModelDto> Dowels { get; set; } = new List<DowelPlacementModelDto> { };
	}
}
