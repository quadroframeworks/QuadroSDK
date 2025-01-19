using Quadro.DataModel.Geometrics;
using Quadro.Interface.Profiling;

namespace Quadro.DataModel.Model.Programs
{
	public class ProfileProgramModelDto
	{
		public string ProgramId { get; set; } = null!;
		public ProgramType Type { get; set; }
		public string Name { get; set; } = null!;
		public double ProfileHeight { get; set; }
		public bool EnableAsDesigned { get; set; }
		public bool EnableFlipped { get; set; }
		public double RabbetDepth { get; set; }
		public Path2DDto? DesignContour { get; set; }
		public List<ProgramRunModelDto> RunsAsDesigned { get; set; } = new List<ProgramRunModelDto>();
		public List<ProgramRunModelDto> RunsFlipped { get; set; } = new List<ProgramRunModelDto>();
		public AppliedProfileStyleDto? ProfileStyle { get; set; }
		public List<ProfileProgramModelDto> Contras { get; set; } = new List<ProfileProgramModelDto>();
	}
}
