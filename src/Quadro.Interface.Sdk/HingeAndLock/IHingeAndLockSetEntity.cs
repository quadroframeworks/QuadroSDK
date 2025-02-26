using Quadro.Interface.Context;
using Quadro.Interface.CustomProperties;
using Quadro.Interface.Enums;
using Quadro.Interface.Profiles;

namespace Quadro.Interface.HingeAndLock
{
	public interface IHingeAndLockSetEntity : ICustomizable
    {
        string Id { get; }
        string Name { get; }
        string? Description { get; }
        string? DefaultStyle { get; set; }
        public double OffsetLeft { get; set; }
        public double OffsetBottom { get; set; }
        public double OffsetRight { get; set; }
        public double OffsetTop { get; set; }
        double TestWidth { get; }
        double TestHeight { get; }
        double TestOffsetXRabbet { get; }
        double TestOffsetYRabbet { get; }
        double TestOffsetZ { get; }
        FrameContextType ContextType { get; }               //Used for filtering (refers to subrame)
        OpeningType OpeningType { get; }                    //Used for filtering (refers to subrame)
        TurnSide TestSide { get; set; }
        IList<IHingeAndLockPlacement> Placements { get; }
        IEnumerable<IProfileStyle> ProfileStyles { get; }
    }

    public interface IHingeAndLockPlacement
    {
        string Id { get; }
        string PartId { get; }
        string? InstanceId { get; }
        RestrictionRange RestrictionRange { get; }
        double RangeFromHeight { get; }
        double RangeToHeight { get; }
        double RangeFromWidth { get; }
        double RangeToWidth { get; }
        string ExpressionEnable { get; set; }
        TurnSide TurnSide { get; set; }
        FillingSide FillingSide { get; set; }
        FrameReference FrameReference { get; set; }
        string? ExpressionCutA { get; set; }
        string? ExpressionCutB { get; set; }
        string? ExpressionMoveB { get; set; }
        OpeningType OpeningType { get; set; }
        CutReference CutReference { get; set; }
    }

    public interface IFixedHingeAndLockPlacement : IHingeAndLockPlacement
    {
        FrameAnchor Anchor { get; }
        string? ExpressionOffsetX { get; set; }
        string? ExpressionOffsetY { get; set; }
        string? ExpressionOffsetZ { get; set; }
        string? ExpressionRotationA { get; set; }
        string? ExpressionRotationB { get; set; }
        string? ExpressionRotationC { get; set; }
    }

    public interface IDynamicHingeAndLockPlacement : IHingeAndLockPlacement
    {
        FrameAnchor AnchorA { get; }
        FrameAnchor AnchorB { get; }
        string? ExpressionOffsetXAnchorA { get; set; }
        string? ExpressionOffsetYAnchorA { get; set; }
        string? ExpressionOffsetZAnchorA { get; set; }
        string? ExpressionOffsetXAnchorB { get; set; }
        string? ExpressionOffsetYAnchorB { get; set; }
        string? ExpressionOffsetZAnchorB { get; set; }
    }


    public enum RestrictionRange
    {
        Always,
        RabbetWidth,
        RabbetHeight,
        RabbetWidthAndHeight,
        Expression,
    }


    public enum FrameReference
    {
        Local,
        Ancestor,
        AncestorCompartment,
    }


    public enum CutReference
    {
        Auto,
        Length,
        Width,
        Height,
    }

    public enum OpeningType
    {
        Single,
        Active,
        Passive,
    }


}
