using CPBase.Geo.Media;
using CPBase.Geo.Media.ThreeD;

namespace Quadro.Interface.FrameOperations
{
	public interface IOperationEntity
    {
        int Index { get; }
    }
    public interface IOperationPointEntity:IOperationEntity
    {
        Point3D Point { get; }
    }

    public interface IOperationAxisEntity : IOperationEntity
    {
        Axis3D Axis { get; }
    }

    public interface IOperationPlaneEntity : IOperationEntity
    {
        Plane3D Plane { get; }
    }
}
