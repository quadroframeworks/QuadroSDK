using CPBase.Shapes;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Line2DDto : StorableGuid
    {
        public Point2DDto FromPoint { get; set; } = null!;
        public Point2DDto ToPoint { get; set; } = null!;

        public Line2D ToLine2D()=>new Line2D(FromPoint.ToPoint(), ToPoint.ToPoint());

        public static Line2DDto FromLine2D(ILine2D line) => new Line2DDto() { FromPoint = Point2DDto.FromPoint(line.FromPoint), 
                                                                            ToPoint = Point2DDto.FromPoint(line.ToPoint) };
    }
}
