using CPBase.Shapes;
using Quadro.Interface.CustomProperties;
using Quadro.Interface.Enums;
using Quadro.Interface.Profiles;

namespace Quadro.Interface.HingeAndLock
{
	public interface IHingeAndLockItemEntity: ICustomizable
    {
        string Id { get; }
        string Name { get; }
        string? CatalogItemId { get; set; }
        PartGroup Group { get; }
        public bool Draw2D { get; }
        public bool Draw3D { get; }
        public bool DrawWorkBook { get; }
        IEnumerable<IHingeAndLockItemInstance> Instances { get; }
        IEnumerable<IExtrusion> Extrusions { get; }
    }

    public interface IHingeAndLockItemInstance
    {
        string Id { get; }
        string? CatalogItemId { get; set; }
        IEnumerable<IPropertySetting> Settings { get; }
    }

    public interface IExtrusion
    {
        string Id { get; }
        ExtrusionType Type { get; }
        ExtrusionTarget Target { get; }
        string? ParameterLength { get; }
        string? ParameterWidth { get; }
        string? ParameterHeight { get; }
        string? ParameterRadius { get; }
        BasicShapeType Shape { get; }
        IPathShape2D? FreeShape { get; }

        string? ExpressionOffsetX { get; set; }
        string? ExpressionOffsetY { get; set; }
        string? ExpressionOffsetZ { get; set; }
        string? ExpressionRotationA { get; set; }
        string? ExpressionRotationB { get; set; }
        string? ExpressionRotationC { get; set; }
        bool IsOperation { get; }
        string? CatalogItemId { get; }
        double OperationOutlineOffset { get; }
        double OperationDepthOffset { get; }
    }



    public enum PartGroup
    {
        Undefined = 0,
        Hinge = 1,
        Lock = 2,
        LockPlate = 3,
        LockHolder = 4,
        FixPart = 5,
        Handle = 6,
#warning Hier nog veel types toe te voegen
    }


    public enum HingeAndLockPartType
    {
        Fixed,
        Dynamic,
    }

    public enum ExtrusionType
    {
        Cut = 0,
        Extrude = 1,
    }

    public enum ExtrusionTarget
    {
        ByPlacementReference,
        Local,
        Ancestor,
    }

}
