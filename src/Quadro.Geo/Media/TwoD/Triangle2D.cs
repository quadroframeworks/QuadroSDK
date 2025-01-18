using CPBase.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.TwoD
{
    public class Triangle2D
    {
        public Triangle2D(Point p1, Point p2, Point p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;

            Edge1 = new Edge2D(p1, p2);
            Edge2 = new Edge2D(p2, p3);
            Edge3 = new Edge2D(p3, p1);

        }
        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }

        public Edge2D Edge1 { get; set; }
        public Edge2D Edge2 { get; set; }
        public Edge2D Edge3 { get; set; }

        public bool IsEdge1MaterialOutside { get; set; }
        public bool IsEdge2MaterialOutside { get; set; }
        public bool IsEdge3MaterialOutside { get; set; }

    }

    public class VertexTriangle2D:Triangle2D
    {
        public VertexTriangle2D(Vertex2D v1, Vertex2D v2, Vertex2D v3):base(v1.Point, v2.Point, v3.Point)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }

        public Vertex2D V1 { get; }
        public Vertex2D V2 { get; }
        public Vertex2D V3 { get; }

    }
}
