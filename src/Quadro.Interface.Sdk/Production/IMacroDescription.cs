namespace Quadro.Interface.Production
{
	public interface IMacroDescription
    {
        public string Name { get; }
        public MacroType MacroType { get; }
        public MacroShapeType Shape { get; }

    }

    public enum MacroType
    {
        Any = 0,
        Profiling = 10,
        Contra = 20,
        HingeAndLock = 30,
        TJointExt = 40,
        TJointEnd = 41,
        LJointExt = 42,
        LJointEnd = 43,
        DowelHole = 44,
        PlugTec = 50,
        FixPart = 60,
        FramePart = 70,
        Frame = 80,
    }

    public enum MacroShapeType
    {
        Line,
        Arc,
        Square,
        Rounded,
        RoundedHalf,
        Cylinder,
        Free,
        HalfMoonTopLeft,
        HalfMoonBottomLeft,
        HalfMoonBottomRight,
        HalfMoonTopRight,
        PlugTecInner,
        PlugTecOuter,
    }
}
