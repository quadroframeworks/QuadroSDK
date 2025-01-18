using System.Numerics;

namespace CPBase.Geo.Numerics.ThreeD
{
    public class Line3D
    {
        public Line3D(Vector3 startpoint, Vector3 endpoint)
        {
            StartPoint = startpoint;
            EndPoint = endpoint;
        }

        public Vector3 StartPoint { get; set; }
        public Vector3 EndPoint { get; set; }
        public Vector3 Direction => EndPoint - StartPoint;
    }
}
