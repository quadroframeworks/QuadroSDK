using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.ThreeD.Models
{
    public interface IMesh3D
    {
        IEnumerable<Triangle3D> Triangles { get; }
        void Transform(Matrix3D m);
    }
}
