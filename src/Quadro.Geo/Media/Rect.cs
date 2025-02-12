﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Rect : IFormattable
    {
        internal double _x;

        internal double _y;

        internal double _width;

        internal double _height;

        private static readonly Rect s_empty = CreateEmptyRect();

        //
        // Summary:
        //     Gets a special value that represents a rectangle with no position or area.
        //
        // Returns:
        //     The empty rectangle, which has System.Windows.Rect.X and System.Windows.Rect.Y
        //     property values of System.Double.PositiveInfinity, and has System.Windows.Rect.Width
        //     and System.Windows.Rect.Height property values of System.Double.NegativeInfinity.
        public static Rect Empty => s_empty;

        //
        // Summary:
        //     Gets a value that indicates whether the rectangle is the System.Windows.Rect.Empty
        //     rectangle.
        //
        // Returns:
        //     true if the rectangle is the System.Windows.Rect.Empty rectangle; otherwise,
        //     false.
        public bool IsEmpty => _width < 0.0;

        //
        // Summary:
        //     Gets or sets the position of the top-left corner of the rectangle.
        //
        // Returns:
        //     The position of the top-left corner of the rectangle. The default is (0, 0).
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     System.Windows.Rect.Location is set on an System.Windows.Rect.Empty rectangle.
        public Point Location
        {
            get
            {
                return new Point(_x, _y);
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }

                _x = value._x;
                _y = value._y;
            }
        }

        //
        // Summary:
        //     Gets or sets the width and height of the rectangle.
        //
        // Returns:
        //     A System.Windows.Size structure that specifies the width and height of the rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     System.Windows.Rect.Size is set on an System.Windows.Rect.Empty rectangle.
        public Size Size
        {
            get
            {
                if (IsEmpty)
                {
                    return Size.Empty;
                }

                return new Size(_width, _height);
            }
            set
            {
                if (value.IsEmpty)
                {
                    this = s_empty;
                    return;
                }

                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }

                _width = value._width;
                _height = value._height;
            }
        }

        //
        // Summary:
        //     Gets or sets the x-axis value of the left side of the rectangle.
        //
        // Returns:
        //     The x-axis value of the left side of the rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     System.Windows.Rect.X is set on an System.Windows.Rect.Empty rectangle.
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }

                _x = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the y-axis value of the top side of the rectangle.
        //
        // Returns:
        //     The y-axis value of the top side of the rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     System.Windows.Rect.Y is set on an System.Windows.Rect.Empty rectangle.
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }

                _y = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the width of the rectangle.
        //
        // Returns:
        //     A positive number that represents the width of the rectangle. The default is
        //     0.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     System.Windows.Rect.Width is set to a negative value.
        //
        //   T:System.InvalidOperationException:
        //     System.Windows.Rect.Width is set on an System.Windows.Rect.Empty rectangle.
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size_WidthCannotBeNegative");
                }

                _width = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the height of the rectangle.
        //
        // Returns:
        //     A positive number that represents the height of the rectangle. The default is
        //     0.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     System.Windows.Rect.Height is set to a negative value.
        //
        //   T:System.InvalidOperationException:
        //     System.Windows.Rect.Height is set on an System.Windows.Rect.Empty rectangle.
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size_HeightCannotBeNegative");
                }

                _height = value;
            }
        }

        //
        // Summary:
        //     Gets the x-axis value of the left side of the rectangle.
        //
        // Returns:
        //     The x-axis value of the left side of the rectangle.
        public double Left => _x;

        //
        // Summary:
        //     Gets the y-axis position of the top of the rectangle.
        //
        // Returns:
        //     The y-axis position of the top of the rectangle.
        public double Bottom => _y;

        //
        // Summary:
        //     Gets the x-axis value of the right side of the rectangle.
        //
        // Returns:
        //     The x-axis value of the right side of the rectangle.
        public double Right
        {
            get
            {
                if (IsEmpty)
                {
                    return double.NegativeInfinity;
                }

                return _x + _width;
            }
        }

        //
        // Summary:
        //     Gets the y-axis value of the bottom of the rectangle.
        //
        // Returns:
        //     The y-axis value of the bottom of the rectangle. If the rectangle is empty, the
        //     value is System.Double.NegativeInfinity .
        public double Top
        {
            get
            {
                if (IsEmpty)
                {
                    return double.NegativeInfinity;
                }

                return _y + _height;
            }
        }

        //
        // Summary:
        //     Gets the position of the top-left corner of the rectangle.
        //
        // Returns:
        //     The position of the top-left corner of the rectangle.
        public Point TopLeft => new Point(Left, Top);

        //
        // Summary:
        //     Gets the position of the top-right corner of the rectangle.
        //
        // Returns:
        //     The position of the top-right corner of the rectangle.
        public Point TopRight => new Point(Right, Top);

        //
        // Summary:
        //     Gets the position of the bottom-left corner of the rectangle
        //
        // Returns:
        //     The position of the bottom-left corner of the rectangle.
        public Point BottomLeft => new Point(Left, Bottom);

        //
        // Summary:
        //     Gets the position of the bottom-right corner of the rectangle.
        //
        // Returns:
        //     The position of the bottom-right corner of the rectangle.
        public Point BottomRight => new Point(Right, Bottom);

        //
        // Summary:
        //     Compares two rectangles for exact equality.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     true if the rectangles have the same System.Windows.Rect.Location and System.Windows.Rect.Size
        //     values; otherwise, false.
        public static bool operator ==(Rect rect1, Rect rect2)
        {
            if (rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width)
            {
                return rect1.Height == rect2.Height;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two rectangles for inequality.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     true if the rectangles do not have the same System.Windows.Rect.Location and
        //     System.Windows.Rect.Size values; otherwise, false.
        public static bool operator !=(Rect rect1, Rect rect2)
        {
            return !(rect1 == rect2);
        }

        //
        // Summary:
        //     Indicates whether the specified rectangles are equal.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     true if the rectangles have the same System.Windows.Rect.Location and System.Windows.Rect.Size
        //     values; otherwise, false.
        public static bool Equals(Rect rect1, Rect rect2)
        {
            if (rect1.IsEmpty)
            {
                return rect2.IsEmpty;
            }

            if (rect1.X.Equals(rect2.X) && rect1.Y.Equals(rect2.Y) && rect1.Width.Equals(rect2.Width))
            {
                return rect1.Height.Equals(rect2.Height);
            }

            return false;
        }

        //
        // Summary:
        //     Indicates whether the specified object is equal to the current rectangle.
        //
        // Parameters:
        //   o:
        //     The object to compare to the current rectangle.
        //
        // Returns:
        //     true if o is a System.Windows.Rect and has the same System.Windows.Rect.Location
        //     and System.Windows.Rect.Size values as the current rectangle; otherwise, false.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Rect))
            {
                return false;
            }

            Rect rect = (Rect)o;
            return Equals(this, rect);
        }

        //
        // Summary:
        //     Indicates whether the specified rectangle is equal to the current rectangle.
        //
        // Parameters:
        //   value:
        //     The rectangle to compare to the current rectangle.
        //
        // Returns:
        //     true if the specified rectangle has the same System.Windows.Rect.Location and
        //     System.Windows.Rect.Size values as the current rectangle; otherwise, false.
        public bool Equals(Rect value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Creates a hash code for the rectangle.
        //
        // Returns:
        //     A hash code for the current System.Windows.Rect structure.
        public override int GetHashCode()
        {
            if (IsEmpty)
            {
                return 0;
            }

            return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }

        //
        // Summary:
        //     Creates a new rectangle from the specified string representation.
        //
        // Parameters:
        //   source:
        //     The string representation of the rectangle, in the form "x, y, width, height".
        //
        // Returns:
        //     The resulting rectangle.
        /*public static Rect Parse(string source)
        {
            IFormatProvider invariantEnglishUS = TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string text = tokenizerHelper.NextTokenRequired();
            Rect result = ((!(text == "Empty")) ? new Rect(Convert.ToDouble(text, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS)) : Empty);
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Returns a string representation of the rectangle.
        //
        // Returns:
        //     A string representation of the current rectangle. The string has the following
        //     form: "System.Windows.Rect.X,System.Windows.Rect.Y,System.Windows.Rect.Width,System.Windows.Rect.Height".
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Returns a string representation of the rectangle by using the specified format
        //     provider.
        //
        // Parameters:
        //   provider:
        //     Culture-specific formatting information.
        //
        // Returns:
        //     A string representation of the current rectangle that is determined by the specified
        //     format provider.
        public string ToString(IFormatProvider provider)
        {
            return ConvertToString(null, provider);
        }

        //
        // Summary:
        //     Formats the value of the current instance using the specified format.
        //
        // Parameters:
        //   format:
        //     The format to use.-or- A null reference (Nothing in Visual Basic) to use the
        //     default format defined for the type of the System.IFormattable implementation.
        //
        //   provider:
        //     The provider to use to format the value.-or- A null reference (Nothing in Visual
        //     Basic) to obtain the numeric format information from the current locale setting
        //     of the operating system.
        //
        // Returns:
        //     A string representation of the rectangle.
        string IFormattable.ToString(string format, IFormatProvider provider)
        {
            return ConvertToString(format, provider);
        }

        internal string ConvertToString(string format, IFormatProvider provider)
        {
            if (IsEmpty)
            {
                return "Empty";
            }

            char numericListSeparator = ':';// TokenizerHelper.GetNumericListSeparator(provider);
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}{0}{4:" + format + "}", numericListSeparator, _x, _y, _width, _height);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that has the
        //     specified top-left corner location and the specified width and height.
        //
        // Parameters:
        //   location:
        //     A point that specifies the location of the top-left corner of the rectangle.
        //
        //   size:
        //     A System.Windows.Size structure that specifies the width and height of the rectangle.
        public Rect(Point location, Size size)
        {
            if (size.IsEmpty)
            {
                this = s_empty;
                return;
            }

            _x = location._x;
            _y = location._y;
            _width = size._width;
            _height = size._height;
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that has the
        //     specified x-coordinate, y-coordinate, width, and height.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the top-left corner of the rectangle.
        //
        //   y:
        //     The y-coordinate of the top-left corner of the rectangle.
        //
        //   width:
        //     The width of the rectangle.
        //
        //   height:
        //     The height of the rectangle.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     width is a negative value.-or- height is a negative value.
        public Rect(double x, double y, double width, double height)
        {
            if (width < 0.0 || height < 0.0)
            {
                throw new ArgumentException("Size_WidthAndHeightCannotBeNegative");
            }

            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that is exactly
        //     large enough to contain the two specified points.
        //
        // Parameters:
        //   point1:
        //     The first point that the new rectangle must contain.
        //
        //   point2:
        //     The second point that the new rectangle must contain.
        public Rect(Point point1, Point point2)
        {
            _x = Math.Min(point1._x, point2._x);
            _y = Math.Min(point1._y, point2._y);
            _width = Math.Max(Math.Max(point1._x, point2._x) - _x, 0.0);
            _height = Math.Max(Math.Max(point1._y, point2._y) - _y, 0.0);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that is exactly
        //     large enough to contain the specified point and the sum of the specified point
        //     and the specified vector.
        //
        // Parameters:
        //   point:
        //     The first point the rectangle must contain.
        //
        //   vector:
        //     The amount to offset the specified point. The resulting rectangle will be exactly
        //     large enough to contain both points.
        public Rect(Point point, Vector vector)
            : this(point, point + vector)
        {
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Rect structure that is of the
        //     specified size and is located at (0,0).
        //
        // Parameters:
        //   size:
        //     A System.Windows.Size structure that specifies the width and height of the rectangle.
        public Rect(Size size)
        {
            if (size.IsEmpty)
            {
                this = s_empty;
                return;
            }

            _x = _y = 0.0;
            _width = size.Width;
            _height = size.Height;
        }

        //
        // Summary:
        //     Indicates whether the rectangle contains the specified point.
        //
        // Parameters:
        //   point:
        //     The point to check.
        //
        // Returns:
        //     true if the rectangle contains the specified point; otherwise, false.
        public bool Contains(Point point)
        {
            return Contains(point._x, point._y);
        }

        //
        // Summary:
        //     Indicates whether the rectangle contains the specified x-coordinate and y-coordinate.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the point to check.
        //
        //   y:
        //     The y-coordinate of the point to check.
        //
        // Returns:
        //     true if (x, y) is contained by the rectangle; otherwise, false.
        public bool Contains(double x, double y)
        {
            if (IsEmpty)
            {
                return false;
            }

            return ContainsInternal(x, y);
        }

        //
        // Summary:
        //     Indicates whether the rectangle contains the specified rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to check.
        //
        // Returns:
        //     true if rect is entirely contained by the rectangle; otherwise, false.
        public bool Contains(Rect rect)
        {
            if (IsEmpty || rect.IsEmpty)
            {
                return false;
            }

            if (_x <= rect._x && _y <= rect._y && _x + _width >= rect._x + rect._width)
            {
                return _y + _height >= rect._y + rect._height;
            }

            return false;
        }

        //
        // Summary:
        //     Indicates whether the specified rectangle intersects with the current rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to check.
        //
        // Returns:
        //     true if the specified rectangle intersects with the current rectangle; otherwise,
        //     false.
        public bool IntersectsWith(Rect rect)
        {
            if (IsEmpty || rect.IsEmpty)
            {
                return false;
            }

            if (rect.Left <= Right && rect.Right >= Left && rect.Bottom <= Top)
            {
                return rect.Top >= Bottom;
            }

            return false;
        }

        //
        // Summary:
        //     Finds the intersection of the current rectangle and the specified rectangle,
        //     and stores the result as the current rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to intersect with the current rectangle.
        public void Intersect(Rect rect)
        {
            if (!IntersectsWith(rect))
            {
                this = Empty;
                return;
            }

            double num = Math.Max(Left, rect.Left);
            double num2 = Math.Max(Bottom, rect.Bottom);
            _width = Math.Max(Math.Min(Right, rect.Right) - num, 0.0);
            _height = Math.Max(Math.Min(Top, rect.Top) - num2, 0.0);
            _x = num;
            _y = num2;
        }

        //
        // Summary:
        //     Returns the intersection of the specified rectangles.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to compare.
        //
        //   rect2:
        //     The second rectangle to compare.
        //
        // Returns:
        //     The intersection of the two rectangles, or System.Windows.Rect.Empty if no intersection
        //     exists.
        public static Rect Intersect(Rect rect1, Rect rect2)
        {
            rect1.Intersect(rect2);
            return rect1;
        }

        //
        // Summary:
        //     Expands the current rectangle exactly enough to contain the specified rectangle.
        //
        // Parameters:
        //   rect:
        //     The rectangle to include.
        public void Union(Rect rect)
        {
            if (IsEmpty)
            {
                this = rect;
            }
            else if (!rect.IsEmpty)
            {
                double num = Math.Min(Left, rect.Left);
                double num2 = Math.Min(Bottom, rect.Bottom);
                if (rect.Width == double.PositiveInfinity || Width == double.PositiveInfinity)
                {
                    _width = double.PositiveInfinity;
                }
                else
                {
                    double num3 = Math.Max(Right, rect.Right);
                    _width = Math.Max(num3 - num, 0.0);
                }

                if (rect.Height == double.PositiveInfinity || Height == double.PositiveInfinity)
                {
                    _height = double.PositiveInfinity;
                }
                else
                {
                    double num4 = Math.Max(Top, rect.Top);
                    _height = Math.Max(num4 - num2, 0.0);
                }

                _x = num;
                _y = num2;
            }
        }

        //
        // Summary:
        //     Creates a rectangle that is exactly large enough to contain the two specified
        //     rectangles.
        //
        // Parameters:
        //   rect1:
        //     The first rectangle to include.
        //
        //   rect2:
        //     The second rectangle to include.
        //
        // Returns:
        //     The resulting rectangle.
        public static Rect Union(Rect rect1, Rect rect2)
        {
            rect1.Union(rect2);
            return rect1;
        }

        //
        // Summary:
        //     Expands the current rectangle exactly enough to contain the specified point.
        //
        // Parameters:
        //   point:
        //     The point to include.
        public void Union(Point point)
        {
            Union(new Rect(point, point));
        }

        //
        // Summary:
        //     Creates a rectangle that is exactly large enough to include the specified rectangle
        //     and the specified point.
        //
        // Parameters:
        //   rect:
        //     The rectangle to include.
        //
        //   point:
        //     The point to include.
        //
        // Returns:
        //     A rectangle that is exactly large enough to contain the specified rectangle and
        //     the specified point.
        public static Rect Union(Rect rect, Point point)
        {
            rect.Union(new Rect(point, point));
            return rect;
        }

        //
        // Summary:
        //     Moves the rectangle by the specified vector.
        //
        // Parameters:
        //   offsetVector:
        //     A vector that specifies the horizontal and vertical amounts to move the rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Offset(Vector offsetVector)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Rect_CannotCallMethod");
            }

            _x += offsetVector._x;
            _y += offsetVector._y;
        }

        //
        // Summary:
        //     Moves the rectangle by the specified horizontal and vertical amounts.
        //
        // Parameters:
        //   offsetX:
        //     The amount to move the rectangle horizontally.
        //
        //   offsetY:
        //     The amount to move the rectangle vertically.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Offset(double offsetX, double offsetY)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Rect_CannotCallMethod");
            }

            _x += offsetX;
            _y += offsetY;
        }

        //
        // Summary:
        //     Returns a rectangle that is offset from the specified rectangle by using the
        //     specified vector.
        //
        // Parameters:
        //   rect:
        //     The original rectangle.
        //
        //   offsetVector:
        //     A vector that specifies the horizontal and vertical offsets for the new rectangle.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     rect is System.Windows.Rect.Empty.
        public static Rect Offset(Rect rect, Vector offsetVector)
        {
            rect.Offset(offsetVector.X, offsetVector.Y);
            return rect;
        }

        //
        // Summary:
        //     Returns a rectangle that is offset from the specified rectangle by using the
        //     specified horizontal and vertical amounts.
        //
        // Parameters:
        //   rect:
        //     The rectangle to move.
        //
        //   offsetX:
        //     The horizontal offset for the new rectangle.
        //
        //   offsetY:
        //     The vertical offset for the new rectangle.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     rect is System.Windows.Rect.Empty.
        public static Rect Offset(Rect rect, double offsetX, double offsetY)
        {
            rect.Offset(offsetX, offsetY);
            return rect;
        }

        //
        // Summary:
        //     Expands the rectangle by using the specified System.Windows.Size, in all directions.
        //
        // Parameters:
        //   size:
        //     Specifies the amount to expand the rectangle. The System.Windows.Size structure's
        //     System.Windows.Size.Width property specifies the amount to increase the rectangle's
        //     System.Windows.Rect.Left and System.Windows.Rect.Right properties. The System.Windows.Size
        //     structure's System.Windows.Size.Height property specifies the amount to increase
        //     the rectangle's System.Windows.Rect.Top and System.Windows.Rect.Bottom properties.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Inflate(Size size)
        {
            Inflate(size._width, size._height);
        }

        //
        // Summary:
        //     Expands or shrinks the rectangle by using the specified width and height amounts,
        //     in all directions.
        //
        // Parameters:
        //   width:
        //     The amount by which to expand or shrink the left and right sides of the rectangle.
        //
        //   height:
        //     The amount by which to expand or shrink the top and bottom sides of the rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     This method is called on the System.Windows.Rect.Empty rectangle.
        public void Inflate(double width, double height)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Rect_CannotCallMethod");
            }

            _x -= width;
            _y -= height;
            _width += width;
            _width += width;
            _height += height;
            _height += height;
            if (!(_width >= 0.0) || !(_height >= 0.0))
            {
                this = s_empty;
            }
        }

        //
        // Summary:
        //     Returns the rectangle that results from expanding the specified rectangle by
        //     the specified System.Windows.Size, in all directions.
        //
        // Parameters:
        //   rect:
        //     The System.Windows.Rect structure to modify.
        //
        //   size:
        //     Specifies the amount to expand the rectangle. The System.Windows.Size structure's
        //     System.Windows.Size.Width property specifies the amount to increase the rectangle's
        //     System.Windows.Rect.Left and System.Windows.Rect.Right properties. The System.Windows.Size
        //     structure's System.Windows.Size.Height property specifies the amount to increase
        //     the rectangle's System.Windows.Rect.Top and System.Windows.Rect.Bottom properties.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     rect is an System.Windows.Rect.Empty rectangle.
        public static Rect Inflate(Rect rect, Size size)
        {
            rect.Inflate(size._width, size._height);
            return rect;
        }

        //
        // Summary:
        //     Creates a rectangle that results from expanding or shrinking the specified rectangle
        //     by the specified width and height amounts, in all directions.
        //
        // Parameters:
        //   rect:
        //     The System.Windows.Rect structure to modify.
        //
        //   width:
        //     The amount by which to expand or shrink the left and right sides of the rectangle.
        //
        //   height:
        //     The amount by which to expand or shrink the top and bottom sides of the rectangle.
        //
        // Returns:
        //     The resulting rectangle.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     rect is an System.Windows.Rect.Empty rectangle.
        public static Rect Inflate(Rect rect, double width, double height)
        {
            rect.Inflate(width, height);
            return rect;
        }

        //
        // Summary:
        //     Returns the rectangle that results from applying the specified matrix to the
        //     specified rectangle.
        //
        // Parameters:
        //   rect:
        //     A rectangle that is the basis for the transformation.
        //
        //   matrix:
        //     A matrix that specifies the transformation to apply.
        //
        // Returns:
        //     The rectangle that results from the operation.
        public static Rect Transform(Rect rect, Matrix matrix)
        {
            MatrixUtil.TransformRect(ref rect, ref matrix);
            return rect;
        }

        //
        // Summary:
        //     Transforms the rectangle by applying the specified matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix that specifies the transformation to apply.
        public void Transform(Matrix matrix)
        {
            MatrixUtil.TransformRect(ref this, ref matrix);
        }

        //
        // Summary:
        //     Multiplies the size of the current rectangle by the specified x and y values.
        //
        // Parameters:
        //   scaleX:
        //     The scale factor in the x-direction.
        //
        //   scaleY:
        //     The scale factor in the y-direction.
        public void Scale(double scaleX, double scaleY)
        {
            if (!IsEmpty)
            {
                _x *= scaleX;
                _y *= scaleY;
                _width *= scaleX;
                _height *= scaleY;
                if (scaleX < 0.0)
                {
                    _x += _width;
                    _width *= -1.0;
                }

                if (scaleY < 0.0)
                {
                    _y += _height;
                    _height *= -1.0;
                }
            }
        }

        private bool ContainsInternal(double x, double y)
        {
            if (x >= _x && x - _width <= _x && y >= _y)
            {
                return y - _height <= _y;
            }

            return false;
        }

        private static Rect CreateEmptyRect()
        {
            Rect result = default;
            result._x = double.PositiveInfinity;
            result._y = double.PositiveInfinity;
            result._width = double.NegativeInfinity;
            result._height = double.NegativeInfinity;
            return result;
        }
    }
}
