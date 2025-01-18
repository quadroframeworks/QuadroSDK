using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Point4D : IFormattable
    {
        internal double _x;

        internal double _y;

        internal double _z;

        internal double _w;

        //
        // Summary:
        //     Gets or sets the System.Windows.Media.Media3D.Point4D.X component of this System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Point4D.X component of this System.Windows.Media.Media3D.Point4D
        //     structure. The default value is 0.
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
        //     Gets or sets the System.Windows.Media.Media3D.Point4D.Y component of this System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Point4D.Y component of this System.Windows.Media.Media3D.Point4D
        //     structure. The default value is 0.
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
        //     Gets or sets the System.Windows.Media.Media3D.Point4D.Z component of this System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Point4D.Z component of this System.Windows.Media.Media3D.Point4D
        //     structure. The default value is 0.
        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the System.Windows.Media.Media3D.Point4D.W component of this System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Point4D.W component of this System.Windows.Media.Media3D.Point4D
        //     structure. The default value is 0.
        public double W
        {
            get
            {
                return _w;
            }
            set
            {
                _w = value;
            }
        }

        //
        // Summary:
        //     Initializes a new instance of a System.Windows.Media.Media3D.Point4D structure.
        //
        // Parameters:
        //   x:
        //     The x-coordinate of the new System.Windows.Media.Media3D.Point4D structure.
        //
        //   y:
        //     The y-coordinate of the new System.Windows.Media.Media3D.Point4D structure.
        //
        //   z:
        //     The z-coordinate of the new System.Windows.Media.Media3D.Point4D structure.
        //
        //   w:
        //     The w-coordinate of the new System.Windows.Media.Media3D.Point4D structure.
        public Point4D(double x, double y, double z, double w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        //
        // Summary:
        //     Translates the System.Windows.Media.Media3D.Point4D structure by the specified
        //     amounts.
        //
        // Parameters:
        //   deltaX:
        //     The amount to offset the System.Windows.Media.Media3D.Point4D.X coordinate of
        //     this System.Windows.Media.Media3D.Point4D structure.
        //
        //   deltaY:
        //     The amount to offset the System.Windows.Media.Media3D.Point4D.Y coordinate of
        //     this System.Windows.Media.Media3D.Point4D structure.
        //
        //   deltaZ:
        //     The amount to offset the System.Windows.Media.Media3D.Point4D.Z coordinate of
        //     this System.Windows.Media.Media3D.Point4D structure.
        //
        //   deltaW:
        //     The amount to offset the System.Windows.Media.Media3D.Point4D.W coordinate of
        //     this System.Windows.Media.Media3D.Point4D structure.
        public void Offset(double deltaX, double deltaY, double deltaZ, double deltaW)
        {
            _x += deltaX;
            _y += deltaY;
            _z += deltaZ;
            _w += deltaW;
        }

        //
        // Summary:
        //     Adds a System.Windows.Media.Media3D.Point4D structure to a System.Windows.Media.Media3D.Point4D.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point4D structure to add.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point4D structure to add.
        //
        // Returns:
        //     Returns the sum of point1 and point2.
        public static Point4D operator +(Point4D point1, Point4D point2)
        {
            return new Point4D(point1._x + point2._x, point1._y + point2._y, point1._z + point2._z, point1._w + point2._w);
        }

        //
        // Summary:
        //     Adds a System.Windows.Media.Media3D.Point4D structure to a System.Windows.Media.Media3D.Point4D.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point4D structure to add.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point4D structure to add.
        //
        // Returns:
        //     Returns the sum of point1 and point2.
        public static Point4D Add(Point4D point1, Point4D point2)
        {
            return new Point4D(point1._x + point2._x, point1._y + point2._y, point1._z + point2._z, point1._w + point2._w);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Point4D structure from a System.Windows.Media.Media3D.Point4D
        //     structure and returns the result as a System.Windows.Media.Media3D.Point4D structure.
        //
        // Parameters:
        //   point1:
        //     The System.Windows.Media.Media3D.Point4D structure to be subtracted from.
        //
        //   point2:
        //     The System.Windows.Media.Media3D.Point4D structure to subtract from point1.
        //
        // Returns:
        //     Returns the difference between point1 and point2.
        public static Point4D operator -(Point4D point1, Point4D point2)
        {
            return new Point4D(point1._x - point2._x, point1._y - point2._y, point1._z - point2._z, point1._w - point2._w);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Point4D structure from a System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Parameters:
        //   point1:
        //     The System.Windows.Media.Media3D.Point4D structure to be subtracted from.
        //
        //   point2:
        //     The System.Windows.Media.Media3D.Point4D structure to subtract from point1.
        //
        // Returns:
        //     Returns the difference between point1 and point2.
        public static Point4D Subtract(Point4D point1, Point4D point2)
        {
            return new Point4D(point1._x - point2._x, point1._y - point2._y, point1._z - point2._z, point1._w - point2._w);
        }

        //
        // Summary:
        //     Transforms the specified System.Windows.Media.Media3D.Point4D structure by the
        //     specified System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Media.Media3D.Point4D structure to transform.
        //
        //   matrix:
        //     The transformation System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Returns:
        //     Returns the result of transforming point and matrix.
        public static Point4D operator *(Point4D point, Matrix3D matrix)
        {
            return matrix.Transform(point);
        }

        //
        // Summary:
        //     Transforms the specified System.Windows.Media.Media3D.Point4D structure by the
        //     specified System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Media.Media3D.Point4D structure to transform.
        //
        //   matrix:
        //     The transformation System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Returns:
        //     Returns the result of transforming point and matrix.
        public static Point4D Multiply(Point4D point, Matrix3D matrix)
        {
            return matrix.Transform(point);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point4D structures for equality.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point4D structure to compare.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point4D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Point4D.X, System.Windows.Media.Media3D.Point4D.Y,
        //     and System.Windows.Media.Media3D.Point4D.Z coordinates of point4D1 and point4D2
        //     are equal; otherwise, false.
        public static bool operator ==(Point4D point1, Point4D point2)
        {
            if (point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z)
            {
                return point1.W == point2.W;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point4D structures for inequality.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point4D structure to compare.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point4D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Point4D.X, System.Windows.Media.Media3D.Point4D.Y,
        //     System.Windows.Media.Media3D.Point4D.Z, and System.Windows.Media.Media3D.Point4D.W
        //     coordinates of point4D1 and point4D2 are different; otherwise, false.
        public static bool operator !=(Point4D point1, Point4D point2)
        {
            return !(point1 == point2);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point4D structures for equality.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point4D structure to compare.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point4D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Point4D.X, System.Windows.Media.Media3D.Point4D.Y,
        //     and System.Windows.Media.Media3D.Point4D.Z components of point3D1 and point3D2
        //     are equal; false otherwise.
        public static bool Equals(Point4D point1, Point4D point2)
        {
            if (point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y) && point1.Z.Equals(point2.Z))
            {
                return point1.W.Equals(point2.W);
            }

            return false;
        }

        //
        // Summary:
        //     Determines whether the specified System.Object is a System.Windows.Media.Media3D.Point4D
        //     structure and if the System.Windows.Media.Media3D.Point4D.X, System.Windows.Media.Media3D.Point4D.Y,
        //     System.Windows.Media.Media3D.Point4D.Z, and System.Windows.Media.Media3D.Point4D.W
        //     properties of the specified System.Object are equal to the System.Windows.Media.Media3D.Point4D.X,
        //     System.Windows.Media.Media3D.Point4D.Y, System.Windows.Media.Media3D.Point4D.Z,
        //     and System.Windows.Media.Media3D.Point4D.W properties of this System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Parameters:
        //   o:
        //     The object to compare.
        //
        // Returns:
        //     true if instances are equal; otherwise, false. true if o (the passed System.Object)
        //     is a System.Windows.Media.Media3D.Point4D structure and is identical with this
        //     System.Windows.Media.Media3D.Point4D structure; false otherwise.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Point4D))
            {
                return false;
            }

            Point4D point = (Point4D)o;
            return Equals(this, point);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point4D structures for equality.
        //
        // Parameters:
        //   value:
        //     The instance of Point4D to compare to this instance.
        //
        // Returns:
        //     true if instances are equal; otherwise, false.
        public bool Equals(Point4D value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Returns a hash code for this System.Windows.Media.Media3D.Point4D structure.
        //
        // Returns:
        //     Returns a hash code for this System.Windows.Media.Media3D.Point4D structure.
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        //
        // Summary:
        //     Converts a System.String representation of a point4D structure into the equivalent
        //     System.Windows.Media.Media3D.Point4D structure.
        //
        // Parameters:
        //   source:
        //     The System.String representation of the point4D structure.
        //
        // Returns:
        //     Returns the equivalent System.Windows.Media.Media3D.Point4D structure.
        /*public static Point4D Parse(string source)
        {
            IFormatProvider invariantEnglishUS = System.Windows.Markup.TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string value = tokenizerHelper.NextTokenRequired();
            Point4D result = new Point4D(Convert.ToDouble(value, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS));
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Returns:
        //     Returns a System.String containing the System.Windows.Media.Media3D.Point4D.X,
        //     System.Windows.Media.Media3D.Point4D.Y, System.Windows.Media.Media3D.Point4D.Z,
        //     and System.Windows.Media.Media3D.Point4D.W values of this System.Windows.Media.Media3D.Point4D
        //     structure.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Parameters:
        //   provider:
        //     Culture-specific formatting information.
        //
        // Returns:
        //     Returns a System.String containing the System.Windows.Media.Media3D.Point4D.X,
        //     System.Windows.Media.Media3D.Point4D.Y, System.Windows.Media.Media3D.Point4D.Z,
        //     and System.Windows.Media.Media3D.Point4D.W values of this System.Windows.Media.Media3D.Point4D
        //     structure.
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
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}{0}{4:" + format + "}", numericListSeparator, _x, _y, _z, _w);
        }
    }
}
