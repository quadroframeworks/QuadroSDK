using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.TwoD
{
    public class Vertex2D
    {
        public Vertex2D() { }
        public Vertex2D(Point p)
        {
            Point = p;
        }

        public Point Point;

        public Vertex2D Clone()
        {
            return new Vertex2D(this.Point);
        }
    }
}
