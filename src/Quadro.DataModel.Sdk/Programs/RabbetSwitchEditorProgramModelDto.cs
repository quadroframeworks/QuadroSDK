using Quadro.DataModel.Geometrics;
using Quadro.Interface.Programs;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Model.Programs
{

	public class RabbetSwitchProgramModelDto : StorableGuid
	{
		public string ProgramId { get; set; } = null!;
		public string Name { get; set; } = null!;
		public double ProfileWidth { get; set; }
		public double ProfileHeight { get; set; }
		public bool IsMirrored { get; set; }
		public List<RabbetSwitchOperationModelDto> OperationsExt { get; set; } = new List<RabbetSwitchOperationModelDto>();
		public List<RabbetSwitchOperationModelDto> OperationsEnd { get; set; } = new List<RabbetSwitchOperationModelDto>();

	}

	//Note that the whole program editor is in joint space
	public class RabbetSwitchEditorProgramModelDto : RabbetSwitchProgramModelDto
	{
		public Matrix3DDto ExtLeftTransform { get; set; } = null!;
		public Matrix3DDto ExtRightTransform { get; set; } = null!;
		public Matrix3DDto EndTransform { get; set; } = null!;
		public Path2DDto CrossSectionExtLeft { get; set; } = null!;
		public Path2DDto CrossSectionExtRight { get; set; } = null!;
		public Path2DDto CrossSectionEnd { get; set; } = null!;
		public Path2DDto AlternativeContraShape { get; set; } = null!;
		public List<RabbetSwitchRunModelDto> ProfilingsRight { get; set; } = new List<RabbetSwitchRunModelDto>();
		public List<RabbetSwitchRunModelDto> ProfilingsLeft { get; set; } = new List<RabbetSwitchRunModelDto>();

	}

	public class RabbetSwitchOperationModelDto : StorableGuid
	{
		public double Width { get; set; }
		public double Height { get; set; }
		public double Length { get; set; }
		public double Radius { get; set; }
		public int ToolIndex { get; set; }
		public int RefPointIndex { get; set; }
		public Rect3DDto Bounds { get; set; } = null!;
		public RabbetSwitchShapeType ShapeType { get; set; }
		public Path2DDto Shape { get; set; } = null!;
		public Matrix3DDto Transform { get; set; } = null!;
	}

	public class RabbetSwitchRunModelDto : StorableGuid
	{
		public int RunIndex { get; set; }
		public int? ToolIndex { get; set; }
		public int? RefPointIndex { get; set; }
		public Matrix3DDto RunTransform { get; set; } = null!;      //Run transform is transform within test part space, which is orientated like the joint transform, but rotated/translated
		public Point3DDto StartPoint { get; set; } = null!;
		public Point3DDto EndPoint { get; set; } = null!;
	}
}
