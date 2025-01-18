using CPBase.Shapes;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Geometrics
{
	public class Arc2DDto:StorableGuid
    {
        public Point2DDto FromPoint { get; set; } = null!;
        public Point2DDto ToPoint { get; set; } = null!;
        public Point2DDto Center { get; set; } = null!;
        public double Radius { get; set; }
        public bool IsCcw { get; set; }
        public bool IsLargeArc { get; set; }

        public Arc2D ToArc2D()
        {
            return new Arc2D(FromPoint.ToPoint(), ToPoint.ToPoint(), Center.ToPoint());
        }

        public static Arc2DDto FromArc2D(IArc2D arc) => new Arc2DDto()
        {
            FromPoint = Point2DDto.FromPoint(arc.FromPoint),
            ToPoint = Point2DDto.FromPoint(arc.ToPoint),
            Center = Point2DDto.FromPoint(arc.Center),
            Radius = arc.Radius,
            IsCcw = arc.IsCcw,
            IsLargeArc = arc.IsLargeArc
        };
    }
}
