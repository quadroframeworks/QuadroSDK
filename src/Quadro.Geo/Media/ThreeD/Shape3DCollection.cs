using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media.ThreeD
{
    public class Shape3DCollection:List<Shape3D>
    {
        public Shape3DCollection()
        {
            bounds = Rect3D.Empty;
        }
        public new void Add(Shape3D shape)
        {
            base.Add(shape);
            bounds.Union(shape.Bounds);
        }

        public new void Remove(Shape3D shape)
        {
            base.Remove(shape);
            bounds = Rect3D.Empty;
            foreach (var t in this)
                bounds.Union(t.Bounds);
        }

        public new void AddRange(IEnumerable<Shape3D> collection)
        {
            foreach (var t in collection)
                this.Add(t);
        }

        public new void Clear()
        {
            base.Clear();
            bounds = Rect3D.Empty;
        }

        public new void RemoveAll(Predicate<Shape3D> match)
        {
            base.RemoveAll(match);
            bounds = Rect3D.Empty;
            foreach (var s in this)
                bounds.Union(s.Bounds);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            bounds = Rect3D.Empty;
            foreach (var s in this)
                bounds.Union(s.Bounds);
        }


        public Rect3D Bounds => bounds;
        private Rect3D bounds;
    }
}
