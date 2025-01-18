using CPBase.Geo.Media.ThreeD;
using CPBase.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.TwoD
{
    public class Triangulator2D
    {

        public static bool IsPath2DCounterClockwise(IList<Vertex2D> path)
        {

            double anglesum = 0.0;

            for (int i = 1; i < path.Count - 1; i++)
            {
                var s1 = path[i - 1];
                var s2 = path[i];
                var s3 = path[i + 1];

                Vector v1_2 = Point.Subtract(s2.Point, s1.Point);
                Vector v2_3 = Point.Subtract(s3.Point, s2.Point);

                double angle = Vector.AngleBetween(v1_2, v2_3);
                anglesum += angle;

            }

            return (anglesum > 0.0);

        }


        private static bool IsEar(Vertex2D s1, Vertex2D s2, Vertex2D s3, IList<Vertex2D> path, bool ispathcww)
        {

            Vector v1_2 = Point.Subtract(s2.Point, s1.Point);
            Vector v2_3 = Point.Subtract(s3.Point, s2.Point);

            double angle = Vector.AngleBetween(v1_2, v2_3);

            double dir = Vector.CrossProduct(v1_2, v2_3);

            bool directionsign = dir < 0.0;


            if (!(directionsign ^ ispathcww))
            {
                return false;
            }

            var t = new Triangle2D(s1.Point, s2.Point, s3.Point);


            foreach (var testsegment in path)
            {

                if (testsegment != s1 & testsegment != s2 & testsegment != s3)
                {
                    bool iswithintriangle = Math2D.IsPointWithinTriangle(testsegment.Point, t);
                    if (iswithintriangle)
                    {
                        return false;
                    }
                }
            }

            return true;


        }

        private class OuterEdge
        {
            public OuterEdge(Vertex2D v1, Vertex2D v2)
            {
                V1 = v1;
                V2 = v2;
            }
            public Vertex2D V1;
            public Vertex2D V2;

            public bool IsOnEdge(Vertex2D v1, Vertex2D v2)
            {
                return (v1 == V1 && v2 == V2) || (v1 == V2 && v2 == V1);
            }
        }
     
        public static List<VertexTriangle2D> TriangulatePath2DEarClipping(IList<Vertex2D> path)
        {
            var triangles = new List<VertexTriangle2D>();
            var temppath = new List<Vertex2D>();

            //Not add a point similar to previous added point
            foreach (var segment in path)
            {
                //Last point
                bool pointsmatch = false;
                var lastsegment = temppath.LastOrDefault();

                if (lastsegment != null)
                {
                    Point lastpoint = lastsegment.Point;
                    pointsmatch = Math2D.PointsAreClose(lastpoint, segment.Point);
                }

                if (!pointsmatch)
                {
                    var tempsegment = new Vertex2D(segment.Point);
                    temppath.Add(tempsegment);
                }
            }

            //Path may not be closed
            if (temppath.Count > 2)
            {
                if (Math2D.PointsAreClose(temppath.First().Point, temppath.Last().Point))
                {
                    temppath.RemoveAt(temppath.Count - 1);
                }
            }

            //Hold a list with outer edges
            var outeredges = new List<OuterEdge>();
            for (int i = 1; i < temppath.Count; i++)
            {
                var s1 = temppath[i - 1];
                var s2 = temppath[i];
                outeredges.Add(new OuterEdge(s1, s2));
            }
            outeredges.Add(new OuterEdge(temppath[temppath.Count - 1], temppath[0])); //Close edges

            bool ispathccw = IsPath2DCounterClockwise(temppath);
            bool earsfound = true;
            while (temppath.Count > 2 & earsfound)
            {

                Vertex2D? segmenttodelete = null;
                for (int i = 1; i < temppath.Count - 1; i++)
                {
                    var s1 = temppath[i - 1];
                    var s2 = temppath[i];
                    var s3 = temppath[i + 1];

                    if (IsEar(s1, s2, s3, temppath, ispathccw))
                    {
                        segmenttodelete = s2;

                        if (ispathccw)
                        {
                            var triangle = new VertexTriangle2D(s2, s1, s3);
                            triangles.Add(triangle);

                            triangle.IsEdge1MaterialOutside = outeredges.Any(e => e.IsOnEdge(s2, s1));
                            triangle.IsEdge2MaterialOutside = outeredges.Any(e => e.IsOnEdge(s1, s3));
                            triangle.IsEdge3MaterialOutside = outeredges.Any(e => e.IsOnEdge(s3, s2));


                            if (triangle.IsEdge1MaterialOutside == false && triangle.IsEdge2MaterialOutside == false && triangle.IsEdge3MaterialOutside == false)
                            {

                            }
                        }
                        else
                        {
                            var triangle = new VertexTriangle2D(s1, s2, s3);
                            triangles.Add(triangle);
                            triangle.IsEdge1MaterialOutside = outeredges.Any(e => e.IsOnEdge(s1, s2));
                            triangle.IsEdge2MaterialOutside = outeredges.Any(e => e.IsOnEdge(s2, s3));
                            triangle.IsEdge3MaterialOutside = outeredges.Any(e => e.IsOnEdge(s3, s1));

                            if (triangle.IsEdge1MaterialOutside == false && triangle.IsEdge2MaterialOutside == false && triangle.IsEdge3MaterialOutside == false)
                            {

                            }
                        }

                        

                        break;
                    }

                 
                }

                earsfound = false;
                if (segmenttodelete != null)
                {
                    earsfound = true;
                    temppath.Remove(segmenttodelete);
                }
            }

            foreach (var t in triangles.ToList())
            {
#warning "Dit is nodig omdat nog niet alle triangles juist zijn."
                var v1 = t.Edge1.Direction;
                var v2 = t.Edge2.Direction;

                var vector1 = new Vector3D(v1.X, v1.Y, 0);
                var vector2 = new Vector3D(v2.X, v2.Y, 0);

                var n = Vector3D.CrossProduct(vector1, vector2);

                n.Normalize();

                if (!Math3D.VectorsMatch(n, new Vector3D(0, 0, -1)))
                {
                    triangles.Remove(t);
                    triangles.Add(new VertexTriangle2D(t.V1, t.V3, t.V2) 
                    {  
                        IsEdge1MaterialOutside = t.IsEdge3MaterialOutside,
                        IsEdge2MaterialOutside = t.IsEdge2MaterialOutside,
                        IsEdge3MaterialOutside = t.IsEdge1MaterialOutside,
                    });
                }
            }

            return triangles;

        }
    }
}
