using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public class Point3DCollection : List<Point3D>
    {
        public Point3DCollection() { }

		public Point3DCollection(IEnumerable<Point3D> collection) : base(collection)
		{
		}

		public void Transform(Matrix3D m)
        {
            var newpoints = new List<Point3D>();
            foreach (var p in this)
            {
                newpoints.Add(m.Transform(p));
            }
            Clear();
            foreach (var p in newpoints)
            {
                Add(p);
            }
        }
    }
}
