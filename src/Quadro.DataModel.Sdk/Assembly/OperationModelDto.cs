using CPBase.Shapes;
using Quadro.Interface.Operations;
using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Interface.FrameOperations;
using Quadro.Interface.Enums;

namespace Quadro.DataModel.Model
{
	public abstract class OperationModelDto
    {
        public OperationModelDto() { }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Radius { get; set; }
        public Rect3DDto Bounds { get; set; } = null!;
        public Path2DDto Shape { get; set; } = null!;
    }

    public class PartOperationModelDto : OperationModelDto
    {
        public BasicShapeType ShapeType { get; set; }
        public Matrix3DDto OperationToPartTransform { get; set; } = null!;
    }


    public class FrameOperationSetModelDto
    {
        public string Name { get; set; } = null!;
        public List<FrameOpEntityDto> Entities { get; set; } = new List<FrameOpEntityDto>();
        public List<FrameOperationModelDto> Operations { get; set; } = new List<FrameOperationModelDto>();
    }
    public class FrameOpEntityDto
    {
        public int Index { get; set; }
        public Point3DDto? Point { get; set; }
        public Axis3DDto? Axis { get; set; }
        public Plane3DDto? Plane { get; set; }
    }
    public class FrameOperationModelDto : OperationModelDto
    {
        public FrameOperationModelDto() { }
        public string Name { get; set; } = null!;
        public FrameOperationShapeType ShapeType { get; set; }
        public List<Matrix3DDto> OperationToFrameTransforms { get; set; } = new List<Matrix3DDto>();
    }
}
