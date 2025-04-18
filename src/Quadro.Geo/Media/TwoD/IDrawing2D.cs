using CPBase.Shapes;
using CPBase.Visual;

namespace CPBase.Geo.Media.TwoD
{
	public interface IDrawing2D
    {
        Rect GetBounds();
        void Scale(double factor, bool keepEntitySizes, double newDimensionRowSpacing);
        void Translate(Vector v);
        void Transform(Matrix m);
        IList<IPoint2DEntity> Points { get; }
        IList<IShape2DEntity> Shapes { get; }
        IList<IPath2DEntity> Paths { get; }  
        IList<ITextEntity> Texts { get; }
        IList<IDimensionEntity> Dimensions { get; }
        IList<IImageEntity> Images { get; }
    } 

    public interface I2DEntity
    {
        int Id { get; }
    }

    public interface IPoint2DEntity:I2DEntity
    {
        Point Point { get; }
        IColor Color { get; }
        double Size { get; set; }
        int ZIndex { get; }
        string Layer { get; }
        int? DimensionId { get; }
        void Scale(double factor, bool keepEntitySize);
        void Translate(Vector v);
        void Transform(Matrix m);
    }

    public interface IShape2DEntity : I2DEntity
    {
        IShape2D Shape { get; }
        IColor Color { get; set; }
        double Thickness { get; set; }
        LineStyle LineStyle { get; }
        int ZIndex { get; set; }
        string Layer { get; }
        int? DimensionId { get; }
        void Scale(double factor, bool keepEntitySize);
        void Translate(Vector v);
        void Transform(Matrix m);
    }

    public interface IPath2DEntity : I2DEntity
    {
        IPathShape2D Path { get; }
        IColor Color { get; set; }
        IBrush? FillBrush { get; }
        double Thickness { get; set; }
        LineStyle LineStyle { get; }
        int ZIndex { get; set; }
        string Layer { get; }
        int? DimensionId { get; }
        void Scale(double factor, bool keepEntitySize);
        void Translate(Vector v);
        void Transform(Matrix m);
    }

    public enum LineStyle
    {
        Solid,
        Dashed,
    }

    public interface ITextEntity : I2DEntity
    {
        string Text { get; }
        Matrix TextTransform { get; }
        IColor Color { get; set; }
        string FontName { get; }
        double FontSize { get; set; }
        TextAlign Align { get; }
        int ZIndex { get; }
        string Layer { get; }
        int? DimensionId { get; }
        void Scale(double factor, bool keepEntitySize);
        void Translate(Vector v);
        void Transform(Matrix m);
    }

    public interface IDimensionEntity:I2DEntity
    {
        int IdEntityA { get; set; }
        int? IdEntityB { get; set; }
        IColor Color { get; set; }
        string FontName { get; }
        double FontSize { get; set; }
        int ZIndex { get; }
        double LineThickness { get; set; }
        string Layer { get; }
        DimensionSide Side { get; }
        DimensionReference Reference { get; }
        int RowIndex { get; }
        void Scale(double factor, bool keepEntitySize);

    }

    public interface IImageEntity : I2DEntity
    {
        string Data { get; set; }
        Matrix ImageTransform { get; }
        Rect Box { get; set; }
        int ZIndex { get; }
        string Layer { get; }
        void Scale(double factor);
        void Translate(Vector v);
        void Transform(Matrix m);
    }

    public enum DimensionSide
    {
        Right = 0,
        Left = 1,
        Top = 2,
        Bottom = 3,
    }

    public enum DimensionReference
    {
        Outer = 0,
        Inner = 1,
    }

	public enum TextAlign
	{
		OriginTopLeft,
		OriginTopRight,
		OriginBottomLeft,
		OriginBottomRight,
		OriginCenterLeft,
		OriginCenterRight,
		OriginCenterTop,
		OriginCenterBottom,
		OriginCenter,
	}

	public class Point2DEntity : IPoint2DEntity
    {
        public Point2DEntity(Point point, IColor color, double size, int zindex = 0, string layer = "") 
        {
            Id = this.GetHashCode();
            Point = point;
            Color = color;
            Size = size;
            ZIndex = zindex;
            Layer = layer;
        }
        public int Id { get; set; }
        public Point Point { get; set; }
        public IColor Color { get; set; }
        public double Size { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; }
        public int? DimensionId { get; set; }

        public void Scale(double factor, bool keepEntitySize)
        {
            Point = new Point(Point.X * factor, Point.Y * factor);
            if (!keepEntitySize)
                Size *= factor;
        }

        public void Transform(Matrix m)
        {
            Point = m.Transform(Point);
        }

        public void Translate(Vector v)
        {
            Point += v;
        }
    }

    public class Shape2DEntity : IShape2DEntity
    {
        public Shape2DEntity(IShape2D shape, IColor color, double thickness, LineStyle lineStyle, int zindex = 0, string layer = "")
        {
            Id = this.GetHashCode();
            Shape = shape;
            Color = color;
            Thickness = thickness;
            LineStyle = lineStyle;
            ZIndex = zindex;
            Layer = layer;
        }
        public int Id { get; set; }
        public IShape2D Shape { get; set; }
        public IColor Color { get; set; }
        public double Thickness { get; set; }
        public LineStyle LineStyle { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; }
        public int? DimensionId { get; set; }

        public void Scale(double factor, bool keepEntitySize)
        {
            Shape.Scale(factor, factor);
            if (!keepEntitySize)
                Thickness *= factor;
        }

        public void Transform(Matrix m)
        {
            Shape.Transform(m);
        }

        public void Translate(Vector v)
        {
            Shape.Translate(v);
        }
    }

    public class Path2DEntity : IPath2DEntity
    {
        public Path2DEntity(IPathShape2D path, IColor color, double thickness, LineStyle lineStyle, IBrush? fillBrush = null, int zindex = 0, string layer = "")
        {
            Id = this.GetHashCode();
            Path = path;
            Color = color;
            Thickness = thickness;
            LineStyle= lineStyle;
            FillBrush = fillBrush;
            ZIndex = zindex;
            Layer = layer;
        }
        public int Id { get; set; }
        public IPathShape2D Path { get; set; } = null!; 
        public IColor Color { get; set; } = null!;
        public double Thickness { get; set; }
        public LineStyle LineStyle { get; set; }
        public IBrush? FillBrush { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; }
        public int? DimensionId { get; set; }

        public void Scale(double factor, bool keepEntitySize)
        {
            Path.Scale(factor, factor);
            if (!keepEntitySize)
                Thickness *= factor;
        }
        public void Translate(Vector v)
        {
            Path.Translate(v);
        }

        public void Transform(Matrix m)
        {
            Path.Transform(m);
        }

    }

    public class TextEntity : ITextEntity
    {
        public TextEntity(string text, Matrix transform, IColor color, string fontName, double fontSize, TextAlign align, int ZIndex = 0, string layer = "")
        {
            Id = this.GetHashCode();
            this.Text = text;
            this.TextTransform = transform;
            this.Color = color;
            this.FontName = fontName;
            this.FontSize = fontSize;
            this.Align = align;
            this.ZIndex = ZIndex;
            this.Layer = layer;

            if (Double.IsNaN(transform.OffsetX))
            {
                TextTransform = Matrix.Identity;
            }
            if (Double.IsNaN(transform.OffsetY))
            {
                TextTransform = Matrix.Identity;
            }
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public Matrix TextTransform { get; set; }
        public IColor Color { get; set; }
        public string FontName { get; set; }
        public double FontSize { get; set; }
        public TextAlign Align { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; }
        public int? DimensionId { get; set; }

        public void Scale(double factor, bool keepEntitySize)
        {
            if (!keepEntitySize)
                FontSize *= factor;

            var t = TextTransform;
            t.Scale(factor, factor);
            TextTransform = t;
        }

        public void Translate(Vector v)
        {
            var t = TextTransform;
            t.Translate(v.X, v.Y);
            TextTransform = t;
        }

        public void Transform(Matrix m)
        {
            var t = TextTransform;
            t = t * m;
            TextTransform = t;
        }
    }

    public class DimensionEntity : IDimensionEntity
    {
        public DimensionEntity(int entityA, int? entityB, DimensionSide side, DimensionReference reference, int rowIndex, IColor color, string fontName, double fontSize, double lineThickness, int zIndex =0, string layer = "")
        {
            Id = this.GetHashCode();
            this.IdEntityA = entityA;
            this.IdEntityB = entityB;
            this.Color = color;
            this.FontName = fontName;
            this.FontSize = fontSize;
            this.LineThickness = lineThickness;
            this.ZIndex = zIndex;
            this.Layer = layer;
            this.Side = side;
            this.Reference = reference;
            this.RowIndex = rowIndex;
        }
        public int Id { get; set; }
        public int IdEntityA { get; set; }
        public int? IdEntityB { get; set; }
        public IColor Color { get; set; }
        public string FontName { get; set; }
        public double FontSize { get; set; }
        public double LineThickness { get; set; }
        public int ZIndex { get; set; }
        public string Layer { get; set; }
        public DimensionSide Side { get; set; }
        public DimensionReference Reference { get; set; }
        public int RowIndex { get; set; }

        public void Scale(double factor, bool keepEntitySize)
        {
            FontSize *= factor;
            if (!keepEntitySize)
                LineThickness *= factor;
        }

    }

    public class ImageEntity:IImageEntity
    {
        public ImageEntity(string data, Matrix transform, Rect box, int ZIndex = 0, string layer = "")
        {
            Id = this.GetHashCode();
            this.Data = data;
            this.Box = box;
            this.ImageTransform = transform;
            this.ZIndex = ZIndex;
            this.Layer = layer;
        }
        public int Id { get; set; }
        public string Data { get; set; }
        public Matrix ImageTransform { get; set; }
        public Rect Box { get; set; }
        public int ZIndex { get; set; }
        public  string Layer { get; set; }

        public void Scale(double factor)
        {
            var t = ImageTransform;
            t.Scale(factor, factor);
            ImageTransform = t;
        }

        public void Translate(Vector v)
        {
            var t = ImageTransform;
            t.Translate(v.X, v.Y);
            ImageTransform = t;
        }

        public void Transform(Matrix m)
        {
            var t = ImageTransform;
            t = t * m;
            ImageTransform = t;
        }
    }

    public class Drawing2D : IDrawing2D
    {
        public Drawing2D()
        {
        }

        public IList<IPoint2DEntity> Points { get; } = new List<IPoint2DEntity>();
        public IList<IShape2DEntity> Shapes { get; } = new List<IShape2DEntity>();
        public IList<IPath2DEntity> Paths { get; } = new List<IPath2DEntity>();
        public IList<ITextEntity> Texts { get; } = new List<ITextEntity>();
        public IList<IDimensionEntity> Dimensions { get; } = new List<IDimensionEntity>();
        public IList<IImageEntity> Images { get; } = new List<IImageEntity>();

        public void AddDrawing(IDrawing2D drawing)
        {
            foreach (var p in drawing.Points)
                Points.Add(p);

            foreach (var s in drawing.Shapes)
                Shapes.Add(s);

            foreach (var p in drawing.Paths)
                Paths.Add(p);

            foreach (var t in drawing.Texts)
                Texts.Add(t);

            foreach (var d in drawing.Dimensions)
                Dimensions.Add(d);

            foreach (var i in drawing.Images)
                Images.Add(i);
        }

        public void Scale(double factor, bool keepEntitySizes, double newDimensionRowSpacing)
        {

            foreach (var p in Points)
                p.Scale(factor, keepEntitySizes);

            foreach (var s in Shapes)
                s.Scale(factor, keepEntitySizes);

            foreach (var p in Paths)
                p.Scale(factor, keepEntitySizes);

            foreach (var t in Texts)
                t.Scale(factor, keepEntitySizes);

            foreach (var d in Dimensions)
            {
                d.Scale(factor, keepEntitySizes);

                var dimtrans = ComputeInvertedScaleDimTranslation(d, factor, newDimensionRowSpacing);
                foreach (var dimshape in Shapes.Where(s => s.DimensionId == d.Id))
                    dimshape.Translate(dimtrans);

                foreach (var dimtext in Texts.Where(s => s.DimensionId == d.Id))
                    dimtext.Translate(dimtrans);
            }

            foreach (var i in Images)
                i.Scale(factor);

        }

        private Vector ComputeInvertedScaleDimTranslation(IDimensionEntity dim, double scaleFactor, double newDimensionRowSpacing)
        {

            var dimsizeorg = dimensionRowSpacing * (dim.RowIndex + 1);
            var dimsizeorgscaled = dimsizeorg * scaleFactor;
            var invsize = newDimensionRowSpacing - dimsizeorgscaled;

            switch (dim.Side)
            {
                case DimensionSide.Right:
                    return new Vector(invsize, 0);
                case DimensionSide.Left:
                    return new Vector(-invsize, 0);
                case DimensionSide.Top:
                    return new Vector(0, invsize);
                case DimensionSide.Bottom:
                    return new Vector(0, -invsize);
            }
            throw new Exception($"Dimension side {dim.Side} not implemented.");

        }

        public void Translate(Vector v)
        {
            foreach (var p in Points)
                p.Translate(v); 

            foreach (var s in Shapes)
                s.Translate(v);

            foreach (var p in Paths)
                p.Translate(v);

            foreach (var t in Texts)
                t.Translate(v);

            foreach (var i in Images)
                i.Translate(v);
        }

        public void Transform(Matrix m)
        {
            foreach (var p in Points)
                p.Transform(m);

            foreach (var s in Shapes)
                s.Transform(m);

            foreach (var p in Paths)
                p.Transform(m);

            foreach (var t in Texts)
                t.Transform(m);

            foreach (var i in Images)
                i.Transform(m);

        }

        public Rect GetBounds()
        {
            var drawingbounds = Rect.Empty;

            foreach (var point in Points)
                drawingbounds.Union(point.Point);

            foreach (var shape in Shapes)
                drawingbounds.Union(shape.Shape.Bounds);

            foreach (var path in Paths)
                drawingbounds.Union(path.Path.Bounds);
            return drawingbounds;
        }
        public void RenderDimensions(IColor dimensionColor)
        {
            var drawingbounds = GetBounds();

            //Remove dimensions
            foreach (var point in Points.Where(p => p.DimensionId != null).ToList())
                Points.Remove(point);

            foreach (var shape in Shapes.Where(p => p.DimensionId != null).ToList())
                Shapes.Remove(shape);

            foreach (var path in Paths.Where(p => p.DimensionId != null).ToList())
                Paths.Remove(path);

            foreach (var dimension in Dimensions)
            {
                RenderDimension(dimension, drawingbounds);
            }
        }


        private static double dimensionRowSpacing = 200.0;
        private static double dimensionCapLength = 30.0;

        private void RenderDimension(IDimensionEntity dimension, Rect drawingbounds)
        {
            var entityA = LookupEntity(dimension.IdEntityA);
            var entityB = LookupEntity(dimension.IdEntityB);


            if (entityA is IShape2DEntity shapeA && shapeA.Shape is ILine2D lineA)
            {
                if (entityB is IShape2DEntity shapeB && shapeB.Shape is ILine2D lineB)
                {
                    var distance = Math2D.DistanceBetweenLineAndPoint(lineA.FromPoint, lineA.ToPoint, lineB.FromPoint);
                    var linedirA = lineA.ToPoint - lineA.FromPoint;
                    var linedirB = lineB.ToPoint - lineB.FromPoint;
                    linedirA.Normalize();
                    linedirB.Normalize();


                    AddDimension(lineA.FromPoint, lineB.FromPoint, linedirA, linedirB, drawingbounds, distance, dimension);

                }
            }
            else if (entityA is IPath2DEntity pathA && entityB is IPath2DEntity pathB)
            {
                var boundsA = pathA.Path.Bounds;
                var boundsB = pathB.Path.Bounds;

                var horizontaldim = dimension.Side == DimensionSide.Top || dimension.Side == DimensionSide.Bottom;

                
                if (horizontaldim && dimension.Reference == DimensionReference.Outer)
                {
                    var left = Math.Min(boundsA.Left, boundsB.Left);
                    var right = Math.Max(boundsA.Right, boundsB.Right);
                    var distance = right - left;
                    AddDimension(new Point(left, 0.0), new Point(right, 0.0), new Vector(0, 1), new Vector(0, 1), drawingbounds, distance, dimension);
                }
                else if (horizontaldim && dimension.Reference == DimensionReference.Inner)
                {
                    var left = Math.Min(boundsA.Right, boundsB.Right);
                    var right = Math.Max(boundsA.Left, boundsB.Left);
                    var distance = right - left;
                    AddDimension(new Point(left, 0.0), new Point(right, 0.0), new Vector(0, 1), new Vector(0, 1), drawingbounds, distance, dimension);
                }
                else if (!horizontaldim && dimension.Reference == DimensionReference.Outer)
                {
                    var bottom = Math.Min(boundsA.Bottom, boundsB.Bottom);
                    var top = Math.Max(boundsA.Top, boundsB.Top);
                    var distance = top - bottom;
                    AddDimension(new Point(0.0, top), new Point(0.0, bottom), new Vector(1, 0), new Vector(1, 0), drawingbounds, distance, dimension);
                }
                else if (!horizontaldim && dimension.Reference == DimensionReference.Inner)
                {
                    var bottom = Math.Min(boundsA.Top, boundsB.Top);
                    var top = Math.Max(boundsA.Bottom, boundsB.Bottom);
                    var distance = top - bottom;
                    AddDimension(new Point(0.0, top), new Point(0.0, bottom), new Vector(1, 0), new Vector(1, 0), drawingbounds, distance, dimension);
                }
            }
            else if (entityA is IPath2DEntity path)
            {
                var bounds = path.Path.Bounds;
                var horizontaldim = dimension.Side == DimensionSide.Top || dimension.Side == DimensionSide.Bottom;

                if (horizontaldim)
                {
                    var left = bounds.Left;
                    var right = bounds.Right;
                    var distance = right - left;
                    AddDimension(new Point(left, 0.0), new Point(right, 0.0), new Vector(0, 1), new Vector(0, 1), drawingbounds, distance, dimension);
                }
                else if (!horizontaldim)
                {
                    var bottom = bounds.Bottom;
                    var top = bounds.Top;
                    var distance = top - bottom;
                    AddDimension(new Point(0.0, top), new Point(0.0, bottom), new Vector(1, 0), new Vector(1, 0), drawingbounds, distance, dimension);
                }

            }
           
        }

        private void AddDimension(Point dimOrgA, Point dimOrgB, Vector linedirA, Vector linedirB, Rect drawingbounds, double distance, IDimensionEntity dimension)
        {
            if (distance < 0.01)
                return;

            var dimrow = GetDimensionRow(dimension.Side, dimension.RowIndex, drawingbounds);
            var dimdir = dimrow.ToPoint - dimrow.FromPoint;
            dimdir.Normalize();

            var intersectionAn = Math2D.ComputeIntersectTwoLines(dimrow.FromPoint, dimdir, dimOrgA, linedirA);
            var intersectionBn = Math2D.ComputeIntersectTwoLines(dimrow.FromPoint, dimdir, dimOrgB, linedirB);

            if (intersectionAn == null)
                return;

            if (intersectionBn == null)
                return;

            var intersectionA = intersectionAn.Value;
            var intersectionB = intersectionBn.Value;

            var halfcap = dimensionCapLength / 2;
            var midpoint = intersectionA + ((intersectionB - intersectionA) / 2);
            var linecapA = new Line2D(intersectionA - (linedirA * halfcap), intersectionA + (linedirA * halfcap));
            var linecapB = new Line2D(intersectionB - (linedirB * halfcap), intersectionB + (linedirB * halfcap));
            var dimlineAB = new Line2D(intersectionA, intersectionB);
            Shapes.Add(CreateEntityByDimension(linecapA, dimension));
            Shapes.Add(CreateEntityByDimension(linecapB, dimension));
            Shapes.Add(CreateEntityByDimension(dimlineAB, dimension));

            var texttransform = Matrix.Identity;
            texttransform.Translate(midpoint.X, midpoint.Y);
            var align = TextAlign.OriginCenter;
            switch (dimension.Side)
            {
                case DimensionSide.Right:
                    align = TextAlign.OriginCenterLeft;
                    break;
                case DimensionSide.Left:
                    align = TextAlign.OriginCenterRight;
                    break;
                case DimensionSide.Top:
                    align = TextAlign.OriginCenterBottom;
                    break;
                case DimensionSide.Bottom:
                    align = TextAlign.OriginCenterTop;
                    break;
            }
            var dimtext = new TextEntity(Math.Round(distance, 1).ToString(), texttransform, dimension.Color, dimension.FontName, dimension.FontSize, align, dimension.ZIndex, dimension.Layer);
            dimtext.DimensionId = dimension.Id;
            Texts.Add(dimtext);
        }

        private IShape2DEntity CreateEntityByDimension(ILine2D line, IDimensionEntity dimension)
        {
            var result = new Shape2DEntity(line, dimension.Color, dimension.LineThickness, LineStyle.Solid, dimension.ZIndex, dimension.Layer);
            result.DimensionId = dimension.Id;
            return result;
        }

        private I2DEntity? LookupEntity(int? id)
        {
            if (id == null)
                return null;

            I2DEntity? result = Points.SingleOrDefault(p => p.Id == id);
            if (result == null)
                result = Shapes.SingleOrDefault(s => s.Id == id);
            if (result == null)
                result = Paths.SingleOrDefault(s => s.Id == id);

            return result;
        }

        private ILine2D GetDimensionRow(DimensionSide side, int rowIndex, Rect drawingBounds)
        {

            var offset = (dimensionRowSpacing * (rowIndex + 1));
            switch (side)
            {
                case DimensionSide.Right:
                    {
                        var sp = new Point(drawingBounds.Right + offset, drawingBounds.Bottom);
                        var ep = new Point(drawingBounds.Right + offset, drawingBounds.Top);
                        return new Line2D(sp, ep);
                    }        
                case DimensionSide.Left:
                    {
                        var sp = new Point(drawingBounds.Left - offset, drawingBounds.Bottom);
                        var ep = new Point(drawingBounds.Left - offset, drawingBounds.Top);
                        return new Line2D(sp, ep);
                    }
                case DimensionSide.Top:
                    {
                        var sp = new Point(drawingBounds.Left, drawingBounds.Top + offset);
                        var ep = new Point(drawingBounds.Right, drawingBounds.Top + offset);
                        return new Line2D(sp, ep);
                    }
                case DimensionSide.Bottom:
                    {
                        var sp = new Point(drawingBounds.Left, drawingBounds.Bottom - offset);
                        var ep = new Point(drawingBounds.Right, drawingBounds.Bottom - offset);
                        return new Line2D(sp, ep);
                    }
            }
            throw new NotImplementedException($"Dimension side {side} not supported.");
        }


    }
}
