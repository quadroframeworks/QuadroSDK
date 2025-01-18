using CPBase.Geo.Media;
using Quadro.Interface.WireFrames;
using Quadro.DataModel.Geometrics;
using Quadro.Interface.RawFrames;

namespace Quadro.DataModel.Model
{
	public class WireModelDto
    {
        public WireIdentifier WireId { get; set; }
        public FramePartType Type { get; set; }
        public Point3DDto StartPoint { get; set; } = null!;
        public Point3DDto EndPoint { get; set; } = null!;
        public double Radius { get; set; }
        public bool IsCcw { get; set; }
        public Shape3DDto Shape { get; set; } = null!;
        public Matrix3DDto WireToFrameTransform { get; set; } = null!;
        public Matrix3DDto FrameToWireTransform { get; set; } = null!;
    }
}
