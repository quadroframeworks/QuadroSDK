using Quadro.Interface.Enums;

namespace Quadro.Interface.HingeAndLock
{
	public interface ICompiledExtrusion
    {
        IExtrusion Description { get; }
        ExtrusionType Type { get; }
        double Length { get; }
        double Width { get; }
        double Height { get; }
        double Radius { get; }
        BasicShapeType Shape { get; }
        double OffsetX { get; }
        double OffsetY { get; }
        double OffsetZ { get; }
        double RotationA { get; }
        double RotationB { get; }
        double RotationC { get; }
        bool IsOperation { get; }
        double OperationOutlineOffset { get; }
        double OperationDepthOffset { get; }
    }
}
