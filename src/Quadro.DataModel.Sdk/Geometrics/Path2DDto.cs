using CPBase.Geo.Media.ThreeD;
using CPBase.Geo.Media.TwoD;
using CPBase.Shapes;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Path2DDto:StorableGuid
    {
        public Path2DDto() 
        {
            Segments = new List<PathSegment2DDto>();
        }
        public Point2DDto StartPoint { get; set; } = null!;
        public List<PathSegment2DDto> Segments { get; set; }


        public PathShape2D ToPathShape2D()
        {
            var result = new PathShape2D(StartPoint.ToPoint());
            var previouspoint = StartPoint.ToPoint();
            foreach (var segment in Segments)
            {
                if (Math2D.PointsAreClose(segment.ToPoint.ToPoint(), previouspoint))
                    continue;

                if (segment.Radius != null && segment.Radius != 0.0)
                {
                    if (segment.IsCcw == null)
                        throw new Exception("IsCcw must be set in dto to create path.");

                    if (segment.Fillet == true && segment.FilletCorner != null)
                        result.AddArcByFillet(segment.ToPoint.X, segment.ToPoint.Y, segment.FilletCorner.X, segment.FilletCorner.Y, (double)segment.Radius);
                    else
                        result.AddArc(segment.ToPoint.X, segment.ToPoint.Y, (double)segment.Radius, (bool)segment.IsCcw, segment.IsLargeArc == true);
                }
                else
                {
                    result.AddLine(segment.ToPoint.X, segment.ToPoint.Y);
                }

                previouspoint = segment.ToPoint.ToPoint();
            }

            return result;
        }

        public static Path2DDto FromPathShape2D(IPathShape2D path)
        {
            var result = new Path2DDto();
            result.StartPoint = Point2DDto.FromPoint(path.StartPoint);

            foreach (var segment in path.Segments)
            {
                var newsegment = new PathSegment2DDto();
                if (segment is Arc2D arc)
                {
                    newsegment.ToPoint = Point2DDto.FromPoint(arc.ToPoint);
                    newsegment.Radius = arc.Radius;
                    newsegment.IsCcw = arc.IsCcw;
                    newsegment.IsLargeArc = arc.IsLargeArc; 
                   
                }
                else if (segment is Line2D line)
                {
                    newsegment.ToPoint = Point2DDto.FromPoint(line.ToPoint);
                }
                result.Segments.Add(newsegment);
            }

            return result;
        }
    }

    public class PathSegment2DDto:StorableGuid
    {
        public Point2DDto ToPoint { get; set; } = null!;
        public double? Radius { get; set; }
        public bool? IsCcw { get; set; }
        public bool? IsLargeArc { get; set; }
        public bool? Fillet { get; set; }
        public Point2DDto? FilletCorner { get; set; }

       
    }
}
