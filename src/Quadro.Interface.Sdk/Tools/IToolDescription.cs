using CPBase.Shapes;

namespace Quadro.Interface.Tools
{
	public interface IToolDescription
    {
        public string Id { get; }
        public int Index { get; }
        bool AllowAngle { get; set; }
        IPathShape2D Contour { get; }
        string? Description { get; set; }
        double Diameter { get; set; }
        double DiameterSubholder { get; set; }
        double HolderAngleA { get; set; }
        double HolderAngleC { get; set; }
        double HolderPosX { get; set; }
        double HolderPosY { get; set; }
        double HolderPosZ { get; set; }
        double LengthSubholder { get; set; }
        double LengthTotal { get; set; }
        double LengthUsable { get; set; }
        bool RotationCCW { get; set; }
        double StepDepth { get; set; }
        int TwinTool { get; set; }
        ToolType Type { get; set; }

        IEnumerable<IToolMappingDescription> ToolMappings { get; }
        IEnumerable<IReferencePointDescription> ReferencePoints { get; }
    }

    public enum ToolType
    {
        Undefined,
        Profiling,
        Mill,
        Drill,
        Saw,
    }
}