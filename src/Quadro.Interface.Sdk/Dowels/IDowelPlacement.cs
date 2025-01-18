namespace Quadro.Interface.Dowels
{
	public interface IDowelPlacement
    {
        string? DowelId { get; }
        double X { get; }
        double Y { get; }
        double Z { get; }
        double PlugTecWidth { get; }
        DowelHorizontalReference RefHorizontal { get; }
        DowelVerticalReference RefVertical { get; }
        PlugTecWidthReference RefPlugTec { get; }
        bool SetZAuto { get; }
    }

    public enum DowelHorizontalReference
    {
        Left = 0,
        Right = 1,
        Mid = 2,
        ValidMid = 3,
        ProfileMid = 4,
    }

    public enum DowelVerticalReference
    {
        Bottom = 0,
        Top = 1,
        Mid = 2,
        ValidMid = 3,
        ValidTop = 4,
        ValidBottom = 5,
    }

    public enum PlugTecWidthReference
    {
        Fixed = 0,
        ValidBounds = 1,
        ProfileBounds = 2,
    }
}