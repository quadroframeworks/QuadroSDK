using Quadro.Interface.RawFrames;

namespace Quadro.Interface.WireFrames
{
	public interface IWireConstraint
    {
        ConstraintType ConstraintType { get; }

        FramePartType WireTypeA { get; set; }
        int WireIndexA { get; set; }
        WireAnchor WireAnchorA { get; set; }
        FramePartType WireTypeB { get; set; }
        int WireIndexB { get; set; }
        WireAnchor WireAnchorB { get; set; }

    }

    public interface ICustomizableConstraint : IWireConstraint
    {
      
    }

    public enum WireAnchor
    {
        Start,
        End,
    }

    public enum ConstraintType
    {
        Coincident,
        WireSnapToLine,
        Vertical,
        Horizontal,
        Parameter,
        ParameterOffset,
    }

    public interface IWireCoincidentPointsConstraint : IWireConstraint
    {
        WireIdentifier WireAId { get; }
        WireAnchor AnchorA { get; }
        WireIdentifier WireBId { get;  }
        WireAnchor AnchorB { get;  }
    }

    public interface IWireSnapToLineConstraint : IWireConstraint
    {
        WireIdentifier PointWireId { get; }
        WireAnchor Anchor { get; }
        WireIdentifier LineWireId { get; }
    }


    public interface IWireVerticalConstraint : IWireConstraint
    {
        WireIdentifier WireId { get; }
    }


    public interface IWireHorizontalConstraint : IWireConstraint
    {
        WireIdentifier WireId { get; }
    }


    public interface IWireParameterConstraint : ICustomizableConstraint
    {
        WireIdentifier WireId { get; }
        WireAnchor Anchor { get; }
        string ParameterX { get; }
        string ParameterY { get; }
    }

    public interface IWireParameterOffsetConstraint : ICustomizableConstraint
    {
        WireIdentifier WireId { get; }
        WireAnchor Anchor { get; }
        WireIdentifier WireBId { get; }
        WireAnchor AnchorB { get; }
        string ParameterX { get; }
        string ParameterY { get; }
    }

}
