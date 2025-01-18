using Quadro.Interface.WireFrames;
using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
    public class WireJointModelDto
    {
        public Point3DDto CuttingPoint { get; set; } = null!;
        public List<WireIdentifier> Wires { get; set; } = new List<WireIdentifier>();
    }
}
