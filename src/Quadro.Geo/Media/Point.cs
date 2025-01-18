using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Point : IFormattable
    {
        internal double _x;

        internal double _y;

        //
        // Summary:
        //     Gets or sets the System.Windows.Point.X-coordinate value of this System.Windows.Point
        //     structure.
        //
        // Returns:
        //     The System.Windows.Point.X-coordinate value of this System.Windows.Point structure.
        //     The default value is 0.
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the System.Windows.Point.Y-coordinate value of this System.Windows.Point.
        //
        // Returns:
        //     The System.Windows.Point.Y-coordinate value of this System.Windows.Point structure.
        //     The default value is 0.
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        //
        // Summary:
        //     Compares two System.Windows.Point structures for equality.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Point structure to compare.
        //
        //   point2:
        //     The second System.Windows.Point structure to compare.
        //
        // Returns:
        //     true if both the System.Windows.Point.X and System.Windows.Point.Y coordinates
        //     of point1 and point2 are equal; otherwise, false.
        public static bool operator ==(Point point1, Point point2)
        {
            if (point1.X == point2.X)
            {
                return point1.Y == point2.Y;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two System.Windows.Point structures for inequality.
        //
        // Parameters:
        //   point1:
        //     The first point to compare.
        //
        //   point2:
        //     The second point to compare.
        //
        // Returns:
        //     true if point1 and point2 have different System.Windows.Point.X or System.Windows.Point.Y
        //     coordinates; false if point1 and point2 have the same System.Windows.Point.X
        //     and System.Windows.Point.Y coordinates.
        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }

        //
        // Summary:
        //     Compares two System.Windows.Point structures for equality.
        //
        // Parameters:
        //   point1:
        //     The first point to compare.
        //
        //   point2:
        //     The second point to compare.
        //
        // Returns:
        //     true if point1 and point2 contain the same System.Windows.Point.X and System.Windows.Point.Y
        //     values; otherwise, false.
        public static bool Equals(Point point1, Point point2)
        {
            if (point1.X.Equals(point2.X))
            {
                return point1.Y.Equals(point2.Y);
            }

            return false;
        }

        //
        // Summary:
        //     Determines whether the specified System.Object is a System.Windows.Point and
        //     whether it contains the same coordinates as this System.Windows.Point.
        //
        // Parameters:
        //   o:
        //     The System.Object to compare.
        //
        // Returns:
        //     true if o is a System.Windows.Point and contains the same System.Windows.Point.X
        //     and System.Windows.Point.Y values as this System.Windows.Point; otherwise, false.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Point))
            {
                return false;
            }

            Point point = (Point)o;
            return Equals(this, point);
        }

        //
        // Summary:
        //     Compares two System.Windows.Point structures for equality.
        //
        // Parameters:
        //   value:
        //     The point to compare to this instance.
        //
        // Returns:
        //     true if both System.Windows.Point structures contain the same System.Windows.Point.X
        //     and System.Windows.Point.Y values; otherwise, false.
        public bool Equals(Point value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Returns the hash code for this System.Windows.Point.
        //
        // Returns:
        //     The hash code for this System.Windows.Point structure.
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        //
        // Summary:
        //     Constructs a System.Windows.Point from the specified System.String.
        //
        // Parameters:
        //   source:
        //     A string representation of a point.
        //
        // Returns:
        //     The equivalent System.Windows.Point structure.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     source is not composed of two comma- or space-delimited double values.
        //
        //   T:System.InvalidOperationException:
        //     source does not contain two numbers.-or- source contains too many delimiters.
        /*public static Point Parse(string source)
        {
            IFormatProvider invariantEnglishUS = TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string value = tokenizerHelper.NextTokenRequired();
            Point result = new Point(Convert.ToDouble(value, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS));
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Point.
        //
        // Returns:
        //     A System.String containing the System.Windows.Point.X and System.Windows.Point.Y
        //     values of this System.Windows.Point structure.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Point.
        //
        // Parameters:
        //   provider:
        //     Culture-specific formatting information.
        //
        // Returns:
        //     A System.String containing the System.Windows.Point.X and System.Windows.Point.Y
        //     values of this System.Windows.Point structure.
        public string ToString(IFormatProvider provider)
        {
            return ConvertToString(null, provider);
        }

        //
        // Summary:
        //     This member supports the Windows Presentation Foundation (WPF) infrastructure
        //     and is not intended to be used directly from your code. For a description of
        //     this member, see System.IFormattable.ToString(System.String,System.IFormatProvider).
        //
        // Parameters:
        //   format:
        //     The string specifying the format to use. -or- null to use the default format
        //     defined for the type of the System.IFormattable implementation.
        //
        //   provider:
        //     The IFormatProvider to use to format the value. -or- null to obtain the numeric
        //     format information from the current locale setting of the operating system.
        //
        // Returns:
        //     A string containing the value of the current instance in the specified format.
        string IFormattable.ToString(string format, IFormatProvider provider)
        {
            return ConvertToString(format, provider);
        }

        internal string ConvertToString(string format, IFormatProvider provider)
        {
            char numericListSeparator = ':';// TokenizerHelper.GetNumericListSeparator(provider);
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", new object[3] { numericListSeparator, _x, _y });
        }

        //
        // Summary:
        //     Creates a new System.Windows.Point structure that contains the specified coordinates.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the new System.Windows.Point structure.
        //
        //   y:
        //     The y-coordinate of the new System.Windows.Point structure.
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        //
        // Summary:
        //     Offsets a point's System.Windows.Point.X and System.Windows.Point.Y coordinates
        //     by the specified amounts.
        //
        // Parameters:
        //   offsetX:
        //     The amount to offset the point's System.Windows.Point.X coordinate.
        //
        //   offsetY:
        //     The amount to offset thepoint's System.Windows.Point.Y coordinate.
        public void Offset(double offsetX, double offsetY)
        {
            _x += offsetX;
            _y += offsetY;
        }

        //
        // Summary:
        //     Translates the specified System.Windows.Point by the specified System.Windows.Vector
        //     and returns the result.
        //
        // Parameters:
        //   point:
        //     The point to translate.
        //
        //   vector:
        //     The amount by which to translate point.
        //
        // Returns:
        //     The result of translating the specified point by the specified vector.
        public static Point operator +(Point point, Vector vector)
        {
            return new Point(point._x + vector._x, point._y + vector._y);
        }

        //
        // Summary:
        //     Adds a System.Windows.Vector to a System.Windows.Point and returns the result
        //     as a System.Windows.Point structure.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Point structure to add.
        //
        //   vector:
        //     The System.Windows.Vector structure to add.
        //
        // Returns:
        //     Returns the sum of point and vector.
        public static Point Add(Point point, Vector vector)
        {
            return new Point(point._x + vector._x, point._y + vector._y);
        }

        //
        // Summary:
        //     Subtracts the specified System.Windows.Vector from the specified System.Windows.Point
        //     and returns the resulting System.Windows.Point.
        //
        // Parameters:
        //   point:
        //     The point from which vector is subtracted.
        //
        //   vector:
        //     The vector to subtract from point1
        //
        // Returns:
        //     The difference between point and vector.
        public static Point operator -(Point point, Vector vector)
        {
            return new Point(point._x - vector._x, point._y - vector._y);
        }

        //
        // Summary:
        //     Subtracts the specified System.Windows.Vector from the specified System.Windows.Point
        //     and returns the resulting System.Windows.Point.
        //
        // Parameters:
        //   point:
        //     The point from which vector is subtracted.
        //
        //   vector:
        //     The vector to subtract from point.
        //
        // Returns:
        //     The difference between point and vector.
        public static Point Subtract(Point point, Vector vector)
        {
            return new Point(point._x - vector._x, point._y - vector._y);
        }

        //
        // Summary:
        //     Subtracts the specified System.Windows.Point from another specified System.Windows.Point
        //     and returns the difference as a System.Windows.Vector.
        //
        // Parameters:
        //   point1:
        //     The point from which point2 is subtracted.
        //
        //   point2:
        //     The point to subtract from point1.
        //
        // Returns:
        //     The difference between point1 and point2.
        public static Vector operator -(Point point1, Point point2)
        {
            return new Vector(point1._x - point2._x, point1._y - point2._y);
        }

        //
        // Summary:
        //     Subtracts the specified System.Windows.Point from another specified System.Windows.Point
        //     and returns the difference as a System.Windows.Vector.
        //
        // Parameters:
        //   point1:
        //     The point from which point2 is subtracted.
        //
        //   point2:
        //     The point to subtract from point1.
        //
        // Returns:
        //     The difference between point1 and point2.
        public static Vector Subtract(Point point1, Point point2)
        {
            return new Vector(point1._x - point2._x, point1._y - point2._y);
        }

        //
        // Summary:
        //     Transforms the specified System.Windows.Point by the specified System.Windows.Media.Matrix.
        //
        // Parameters:
        //   point:
        //     The point to transform.
        //
        //   matrix:
        //     The transformation matrix.
        //
        // Returns:
        //     The result of transforming the specified point using the specified matrix.
        public static Point operator *(Point point, Matrix matrix)
        {
            return matrix.Transform(point);
        }

        //
        // Summary:
        //     Transforms the specified System.Windows.Point structure by the specified System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   point:
        //     The point to transform.
        //
        //   matrix:
        //     The transformation matrix.
        //
        // Returns:
        //     The transformed point.
        public static Point Multiply(Point point, Matrix matrix)
        {
            return matrix.Transform(point);
        }

        //
        // Summary:
        //     Creates a System.Windows.Size structure with a System.Windows.Size.Width equal
        //     to this point's System.Windows.Point.X value and a System.Windows.Size.Height
        //     equal to this point's System.Windows.Point.Y value.
        //
        // Parameters:
        //   point:
        //     The point to convert.
        //
        // Returns:
        //     A System.Windows.Size structure with a System.Windows.Size.Width equal to this
        //     point's System.Windows.Point.X value and a System.Windows.Size.Height equal to
        //     this point's System.Windows.Point.Y value.
        public static explicit operator Size(Point point)
        {
            return new Size(Math.Abs(point._x), Math.Abs(point._y));
        }

        //
        // Summary:
        //     Creates a System.Windows.Vector structure with an System.Windows.Vector.X value
        //     equal to the point's System.Windows.Point.X value and a System.Windows.Vector.Y
        //     value equal to the point's System.Windows.Point.Y value.
        //
        // Parameters:
        //   point:
        //     The point to convert.
        //
        // Returns:
        //     A vector with an System.Windows.Vector.X value equal to the point's System.Windows.Point.X
        //     value and a System.Windows.Vector.Y value equal to the point's System.Windows.Point.Y
        //     value.
        public static explicit operator Vector(Point point)
        {
            return new Vector(point._x, point._y);
        }
    }
}