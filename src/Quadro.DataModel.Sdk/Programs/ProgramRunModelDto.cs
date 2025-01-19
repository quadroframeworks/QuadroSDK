using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model.Programs
{
	public class ProgramRunModelDto
	{
		public string ProgramRunId { get; set; } = null!;
		public int Order { get; set; }
		public Matrix2DDto RunToProgramTransform { get; set; } = null!;
		public Matrix2DDto ToolToRunTransform { get; set; } = null!;
		public ToolModelDto Tool { get; set; } = null!;
	}
}
