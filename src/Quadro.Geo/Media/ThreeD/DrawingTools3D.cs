using CPBase.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.ThreeD
{
    public static class DrawingTools3D
    {

        public static IShape2D TransformShape3DTo2D(Shape3D shape3d, Matrix3D transform)
        {
            if (shape3d is Line3D line)
            {
                var startpoint = transform.Transform(line.StartPoint);
                var endpoint = transform.Transform(line.EndPoint);
                return new Line2D(new Point(startpoint.X, startpoint.Y), new Point(endpoint.X, endpoint.Y));

            }
            else if (shape3d is Arc3D arc)
            {
                var arctransformed = arc.GetTransformedArc(transform);
                return new Arc2D(new Point(arctransformed.StartPoint.X, arctransformed.StartPoint.Y),
                                 new Point(arctransformed.EndPoint.X, arctransformed.EndPoint.Y),
                                 arctransformed.Radius,
                                 arctransformed.IsCcw,
                                 arctransformed.IsLargeArc);
            }
            else
                throw new NotImplementedException($"Shape of type {shape3d.GetType()} not implemented.");
        }
    }
}
