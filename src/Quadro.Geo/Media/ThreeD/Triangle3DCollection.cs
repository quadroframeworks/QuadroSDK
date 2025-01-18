using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.ThreeD
{
    public class Triangle3DCollection : List<Triangle3D>
    {
        public Triangle3DCollection()
        {
            bounds = Rect3D.Empty;
        }
        public new void Add(Triangle3D triangle)
        {
            base.Add(triangle);
            bounds.Union(triangle.Bounds);
        }

        public new void Remove(Triangle3D triangle)
        {
            base.Remove(triangle);
            bounds = Rect3D.Empty;
            foreach (var t in this)
                bounds.Union(t.Bounds);
        }

        public new void AddRange(IEnumerable<Triangle3D> collection)
        {
            foreach (var t in collection)
                this.Add(t);
        }

        public new void Clear()
        {
            base.Clear();
            bounds = Rect3D.Empty;
        }

        public new void RemoveAll(Predicate<Triangle3D> match)
        {
            base.RemoveAll(match);
            bounds = Rect3D.Empty;
            foreach (var t in this)
                bounds.Union(t.Bounds);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            bounds = Rect3D.Empty;
            foreach (var t in this)
                bounds.Union(t.Bounds);
        }

        public void Transform(Matrix3D m)
        {
            foreach (var t in this)
                t.Transform(m);

            bounds = Rect3D.Empty;

            foreach (var t in this)
                bounds.Union(t.Bounds);
        }

        public Rect3D Bounds => bounds;
        private Rect3D bounds;
    }
}
