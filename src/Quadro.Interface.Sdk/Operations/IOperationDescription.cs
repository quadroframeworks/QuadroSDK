using CPBase.Shapes;
using Quadro.Interface.Enums;

namespace Quadro.Interface.Operations
{
	public interface IOperationDescription
    {
        string Id { get; }
        string? CatalogItemId { get; }
        string Name { get; }
        OperationType Type { get; }
        FrameAnchor OriginAnchor { get; }
        OperationDirection Direction { get; }
        FrameAnchor EndAnchor { get; }
        bool LengthByEndPlane { get; }
        string? ParameterLength { get; }
        string? ParameterWidth { get; }
        string? ParameterHeight { get; }
        string? ParameterRadius { get; }
        BasicShapeType Shape { get; }
        IPathShape2D? CustomShape { get; }
    }

    public enum OperationType
    {
        Drilling,
        Pocket,
        Profiling,
        Contra,
    }

    public enum OperationDirection
    {
        Left,
        Bottom,
        Right,
        Top,
    }

    public enum OperationShape
    {
        Square,
        Rounded,
        RoundedHalf,
        Cylinder,
        Custom,

    }
}
