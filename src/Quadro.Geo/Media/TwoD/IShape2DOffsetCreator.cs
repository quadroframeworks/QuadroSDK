using CPBase.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.TwoD
{
    public interface IShape2DOffsetCreator
    {
        IEnumerable<IPathShape2D> CreateOffsetShape(IPathShape2D shape, double offset);
    }
}
