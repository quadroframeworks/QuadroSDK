using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CPBase.Geo.Media.ThreeD
{
    public abstract class Shape3D
    {
        public abstract Point3D StartPoint { get; }
        public abstract Point3D EndPoint { get; }


        public Rect3D Bounds
        {
            get
            {
                var bounds = Rect3D.Empty;
                if (this is Line3D line)
                {
                    bounds.Union(line.StartPoint);
                    bounds.Union(line.EndPoint);
                }
                else if (this is Arc3D arc)
                {
                    bounds.Union(arc.StartPoint);
                    bounds.Union(arc.EndPoint);

                    var centerLeft = new Point3D(arc.CenterPoint.X - arc.Radius, arc.CenterPoint.Y, arc.CenterPoint.Z);
                    var centerRight = new Point3D(arc.CenterPoint.X + arc.Radius, arc.CenterPoint.Y, arc.CenterPoint.Z);
                    var centerTop = new Point3D(arc.CenterPoint.X, arc.CenterPoint.Y + arc.Radius, arc.CenterPoint.Z);
                    var centerBottom = new Point3D(arc.CenterPoint.X, arc.CenterPoint.Y - arc.Radius, arc.CenterPoint.Z);

                    if (Math3D.PointIsOnArc(arc, centerLeft))
                        bounds.Union(centerLeft);
                    else if (Math3D.PointIsOnArc(arc, centerRight))
                        bounds.Union(centerRight);
                    else if (Math3D.PointIsOnArc(arc, centerTop))
                        bounds.Union(centerTop);
                    else if (Math3D.PointIsOnArc(arc, centerBottom))
                        bounds.Union(centerBottom);

                }
                return bounds;
            }
        }

        public abstract void Translate(Vector3D vector);
        public abstract void Transform(Matrix3D matrix);
    }
}
