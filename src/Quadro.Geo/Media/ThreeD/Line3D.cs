using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPBase.Geo.Media;

namespace CPBase.Geo.Media.ThreeD
{
    public class Line3D:Shape3D
    {
        public Line3D(Point3D startpoint, Point3D endpoint)
        {
            startPoint = startpoint;
            endPoint = endpoint;
            Direction = endpoint - startpoint;
            Direction.Normalize();
        }

        public override Point3D StartPoint => startPoint;
        private Point3D startPoint;
        public override Point3D EndPoint => endPoint;
        private Point3D endPoint;
        public Vector3D Direction { get; private set; }

        public override void Translate(Vector3D vector)
        {
            startPoint += vector;
            endPoint += vector;
        }

        public override void Transform(Matrix3D matrix)
        {
            startPoint = matrix.Transform(startPoint);
            endPoint = matrix.Transform(endPoint);
        }
    }
}
