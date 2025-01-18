using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.TwoD
{
    public class Edge2D
    {
        public Edge2D(Point startpoint, Point endpoint)
        {
            StartPoint = startpoint;
            EndPoint = endpoint;
            Direction = endpoint - startpoint;
            Direction.Normalize();
        }

        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public Vector Direction { get; }
    }
}
