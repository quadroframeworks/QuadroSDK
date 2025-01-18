namespace Quadro.Interface.Programs
{
	public interface IRabbetSwitchOperation
    {
        RabbetSwitchAlign Alignment { get; }
        RabbetSwitchShapeType Shape { get; }
        double Width { get; }
        double Height { get; }
        double OffsetX { get; }
        double OffsetY { get; }
        double OffsetZ { get; }
        double OffsetLeft { get; }
        double OffsetBottom { get; }
        double OffsetRight { get; }
        double OffsetTop { get; }
        double Rotation { get; }
        double Radius { get; }
        double Depth { get; }
    }

    public enum RabbetSwitchAlign
    {
       ByDimension = 0,
       LeftTop = 1,
       LeftBottom = 2,
       RightBottom = 3,
       RightTop = 4,
       LeftCenter = 5,
       BottomCenter = 6,
       RightCenter = 7,
       TopCenter = 8,
       Center = 9,
    }

    public enum RabbetSwitchShapeType
    {
        Rounded = 0,
        RoundedHalf = 1,
        Cylinder = 2,
        HalfMoonTopLeft = 3,
        HalfMoonBottomLeft = 4,
        HalfMoonBottomRight = 5,
        HalfMoonTopRight = 6,
    }
}
