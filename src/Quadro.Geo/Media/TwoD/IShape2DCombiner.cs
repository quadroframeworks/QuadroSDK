using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Shapes
{
    public interface IShape2DCombiner
    {
        IEnumerable<IPathShape2D> Union(IPathShape2D subject, IEnumerable<IPathShape2D> paths);
        IEnumerable<IPathShape2D> Intersect(IPathShape2D subject, IEnumerable<IPathShape2D> paths);
        IEnumerable<IPathShape2D> Xor(IPathShape2D subject, IEnumerable<IPathShape2D> paths);
        IEnumerable<IPathShape2D> Exclude(IPathShape2D subject, IEnumerable<IPathShape2D> paths);
    }
}
