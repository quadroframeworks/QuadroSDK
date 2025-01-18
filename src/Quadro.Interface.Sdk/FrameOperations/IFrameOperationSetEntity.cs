using Quadro.Interface.CustomProperties;

namespace Quadro.Interface.FrameOperations
{
	public interface IFrameOperationSetEntity : ICustomizable
    {
        string Name { get; }
        string Script { get; }
        string? TestAssemblyId { get; }
        IEnumerable<IOperationEntityDescription> Entities { get; }
        IEnumerable<IFrameOperationDescription> Operations { get; }
    }


    public interface IFrameOperationDescription
    {
        string Name { get; }
        OperationCondition Condition { get; }
        FrameOperationShapeType ShapeType { get; }
        string? PlaneZeroId { get; }
        string? PlaneBackId { get; }
        string PlaneLeftId { get; }
        string PlaneRightId { get; }
        string? PlaneTopId { get; }
        string? PlaneBottomId { get; }
        string? CenterAxisZeroId { get; }
        string? CenterAxisBackId { get; }
        string ExpressionWidth { get; }
        string ExpressionHeight { get; }
        string ExpressionDepth { get; }
        string ExpressionRadius { get; }
        PatternDistribution Pattern { get; }
        string ExpressionMaxSpacing { get; }
        string ExpressionEndOffset { get; }

    }

    public enum FrameOperationShapeType
    {
        Square,
        Rounded,
        RoundedHalf,
        Cylinder,
        Free,
    }

    public enum OperationCondition
    {
        On,
        Off,
        IsLeftBottomTJoint,
        IsRightBottomTJoint,
        IsRightTopTJoint,
        IsLeftTopTJoint,
        IsLeftBottomLJoint,
        IsRightBottomLJoint,
        IsRightTopLJoint,
        IsLeftTopLJoint,
    }

    public enum PatternDistribution
    {
        SingleCenter, //Center axis
        ByBounds, //6 planes needed
        HorizontalPattern,
        VerticalPattern,
        TwoDirectionalPattern,
    }

    public interface IOperationEntityDescription
    {
        string Id { get; }
        int Index { get; }
        OperationEntityType Type { get; }
        EntityReferenceType Reference { get; }
        EntityAnchor Anchor { get; }
        EntityAxisFromWireFrame AxisWire { get; }
        EntityAxisFromPart AxisPart { get; }
        EntityPlaneFromWireFrame PlaneWire { get; }
        EntityPlaneFromPart PlanePart { get; }
        ProfileStyleReference ProfileStyleRef { get; }
        string? ProfileStyleId { get; }
        int SubFrameIndex { get; }
        string ExpressionX { get; }
        string ExpressionY { get; }
        string ExpressionZ { get; }
        string ExpressionRotation { get; }
        string? ReferenceEntityAId { get; }
        string? ReferenceEntityBId { get; }
        string? RotationAxisId { get; }
    }

    public enum OperationEntityType
    {
        Point,
        Axis,
        Plane,
        Matrix,
    }

    public enum EntityReferenceType
    {
        Fixed,
        ByIntersection, //Planes only
        ByTwoPoints, //Axis only
        ByPointAxis, //Planes only
        RabbetFrameAnchor, //From local wire frame
        BaseFrameAnchor,  //From local wire frame
        SubFrameAnchor, //From local wire frame
        LocalPart, //From part
        AncestorPart,//From part
        LocalProfileStyleAxis, //From part
        AncestorProfileStyleAxis,
    }

    public enum EntityAnchor
    {
        TopLeft,
        BottomLeft,
        BottomRight,
        TopRight,
        CenterLeft,
        CenterBottom,
        CenterRight,
        CenterTop,
        Center,
    }

    public enum EntityAxisFromWireFrame
    {
        Left,
        Bottom,
        Right,
        Top,
        CenterVertical,
        CenterHorizontal,
    }

    public enum EntityAxisFromPart
    {
        LeftInnerInside,
        LeftOuterInside,
        LeftInnerOutside,
        LeftOuterOutside,
        BottomInnerInside,
        BottomOuterInside,
        BottomInnerOutside,
        BottomOuterOutside,
        RightInnerInside,
        RightOuterInside,
        RightInnerOutside,
        RightOuterOutside,
        TopInnerInside,
        TopOuterInside,
        TopInnerOutside,
        TopOuterOutside,
    }

    public enum EntityPlaneFromWireFrame
    {
        Left,
        Bottom,
        Right,
        Top,
        CenterVertical,
        CenterHorizontal,
    }


    public enum EntityPlaneFromPart
    {
        LeftInner,
        LeftOuter,
        BottomInner,
        BottomOuter,
        RightInner,
        RightOuter,
        TopInner,
        TopOuter,
        Inside,
        Outside,
    }



    public enum ProfileStyleReference
    {
        LeftInner,
        BottomInner,
        RightInner,
        TopInner,
        LeftOuter,
        BottomOuter,
        RightOuter,
        TopOuter,
    }
}
