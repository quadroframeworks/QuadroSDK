using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.TwoD
{
    public interface IPoint2D
    {
        double X { get; set; }
        double Y { get; set; }
    }
    

    public class Point2D : IPoint2D
    {
        public Point2D(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
