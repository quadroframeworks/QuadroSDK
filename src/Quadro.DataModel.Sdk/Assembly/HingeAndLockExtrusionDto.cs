using Quadro.Interface.HingeAndLock;
using Quadro.DataModel.Geometrics;
using Quadro.Interface.Enums;

namespace Quadro.DataModel.Model
{
	public class HingeAndLockExtrusionDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string DescriptionId { get; set; } = null!;
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Radius { get; set; }
        public bool IsOperation { get; set; }
        public Rect3DDto Bounds { get; set; } = null!;
        public BasicShapeType BasicShapeType { get; set; }
        public ExtrusionType ExtrusionType { get; set; }
        public ExtrusionTarget Target { get; set; }
        public Path2DDto Shape { get; set; } = null!;
        public Matrix3DDto Transform { get; set; } = null!;
    }
}
