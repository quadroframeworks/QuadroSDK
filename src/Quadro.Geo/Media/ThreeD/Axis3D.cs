using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPBase.Geo.Media;

namespace CPBase.Geo.Media.ThreeD
{
    public class Axis3D
    {
        public Axis3D() { }
        public Axis3D(Point3D origin, Vector3D direction)
        {
            Origin = origin;
            Direction = direction;
        }
        public Point3D Origin { get; set; }
        public Vector3D Direction { get; set; }
    }
}
