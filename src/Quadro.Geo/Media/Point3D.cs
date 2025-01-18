using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CPBase.Geo.Media
{
    [Serializable]
    public struct Point3D : IFormattable
    {
        internal double _x;

        internal double _y;

        internal double _z;

        //
        // Summary:
        //     Gets or sets the x-coordinate of this System.Windows.Media.Media3D.Point3D structure.
        //
        // Returns:
        //     The x-coordinate of this System.Windows.Media.Media3D.Point3D structure.
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
        //     Gets or sets the y-coordinate of this System.Windows.Media.Media3D.Point3D structure.
        //
        // Returns:
        //     The y-coordinate of this System.Windows.Media.Media3D.Point3D structure.
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
        //     Gets or sets the z-coordinate of this System.Windows.Media.Media3D.Point3D structure.
        //
        // Returns:
        //     The z-coordinate of this System.Windows.Media.Media3D.Point3D structure.
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
        //     Initializes a new instance of the System.Windows.Media.Media3D.Point3D structure.
        //
        // Parameters:
        //   x:
        //     The System.Windows.Media.Media3D.Point3D.X value of the new System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        //   y:
        //     The System.Windows.Media.Media3D.Point3D.Y value of the new System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        //   z:
        //     The System.Windows.Media.Media3D.Point3D.Z value of the new System.Windows.Media.Media3D.Point3D
        //     structure.
        public Point3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        //
        // Summary:
        //     Translates the System.Windows.Media.Media3D.Point3D structure by the specified
        //     amounts.
        //
        // Parameters:
        //   offsetX:
        //     The amount to change the System.Windows.Media.Media3D.Point3D.X coordinate of
        //     this System.Windows.Media.Media3D.Point3D structure.
        //
        //   offsetY:
        //     The amount to change the System.Windows.Media.Media3D.Point3D.Y coordinate of
        //     this System.Windows.Media.Media3D.Point3D structure.
        //
        //   offsetZ:
        //     The amount to change the System.Windows.Media.Media3D.Point3D.Z coordinate of
        //     this System.Windows.Media.Media3D.Point3D structure.
        public void Offset(double offsetX, double offsetY, double offsetZ)
        {
            _x += offsetX;
            _y += offsetY;
            _z += offsetZ;
        }

        //
        // Summary:
        //     Adds a System.Windows.Media.Media3D.Point3D structure to a System.Windows.Media.Media3D.Vector3D
        //     and returns the result as a System.Windows.Media.Media3D.Point3D structure.
        //
        // Parameters:
        //   point:
        //     The point to add.
        //
        //   vector:
        //     The vector to add.
        //
        // Returns:
        //     A System.Windows.Media.Media3D.Point3D structure that is the sum of point and
        //     vector.
        public static Point3D operator +(Point3D point, Vector3D vector)
        {
            return new Point3D(point._x + vector._x, point._y + vector._y, point._z + vector._z);
        }

        //
        // Summary:
        //     Adds a System.Windows.Media.Media3D.Point3D structure to a System.Windows.Media.Media3D.Vector3D
        //     and returns the result as a System.Windows.Media.Media3D.Point3D structure.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure to add.
        //
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to add.
        //
        // Returns:
        //     The sum of point and vector.
        public static Point3D Add(Point3D point, Vector3D vector)
        {
            return new Point3D(point._x + vector._x, point._y + vector._y, point._z + vector._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Vector3D structure from a System.Windows.Media.Media3D.Point3D
        //     structure and returns the result as a System.Windows.Media.Media3D.Point3D structure.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure from which to subtract vector.
        //
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to subtract from point.
        //
        // Returns:
        //     The changed System.Windows.Media.Media3D.Point3D structure, the result of subtracting
        //     vector from point.
        public static Point3D operator -(Point3D point, Vector3D vector)
        {
            return new Point3D(point._x - vector._x, point._y - vector._y, point._z - vector._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Vector3D structure from a System.Windows.Media.Media3D.Point3D
        //     structure and returns the result as a System.Windows.Media.Media3D.Point3D structure.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure from which to subtract vector.
        //
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to subtract from point.
        //
        // Returns:
        //     The difference between point and vector.
        public static Point3D Subtract(Point3D point, Vector3D vector)
        {
            return new Point3D(point._x - vector._x, point._y - vector._y, point._z - vector._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Point3D structure from a System.Windows.Media.Media3D.Point3D
        //     structure and returns the result as a System.Windows.Media.Media3D.Vector3D structure.
        //
        // Parameters:
        //   point1:
        //     The System.Windows.Media.Media3D.Point3D structure on which to perform subtraction.
        //
        //   point2:
        //     The System.Windows.Media.Media3D.Point3D structure to subtract from point1.
        //
        // Returns:
        //     A System.Windows.Media.Media3D.Vector3D structure that represents the difference
        //     between point1 and point2.
        public static Vector3D operator -(Point3D point1, Point3D point2)
        {
            return new Vector3D(point1._x - point2._x, point1._y - point2._y, point1._z - point2._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Point3D structure from a System.Windows.Media.Media3D.Point3D
        //     structure and returns the result as a System.Windows.Media.Media3D.Vector3D structure.
        //
        // Parameters:
        //   point1:
        //     The System.Windows.Media.Media3D.Point3D structure to be subtracted from.
        //
        //   point2:
        //     The System.Windows.Media.Media3D.Point3D structure to subtract from point1.
        //
        // Returns:
        //     A System.Windows.Media.Media3D.Vector3D structure that represents the difference
        //     between point1 and point2.
        public static Vector3D Subtract(Point3D point1, Point3D point2)
        {
            Vector3D result = default;
            Subtract(ref point1, ref point2, out result);
            return result;
        }

        internal static void Subtract(ref Point3D p1, ref Point3D p2, out Vector3D result)
        {
            result._x = p1._x - p2._x;
            result._y = p1._y - p2._y;
            result._z = p1._z - p2._z;
        }

        //
        // Summary:
        //     Transforms the specified System.Windows.Media.Media3D.Point3D structure by the
        //     specified System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Parameters:
        //   point:
        //     The point to transform.
        //
        //   matrix:
        //     The matrix that is used to transform point.
        //
        // Returns:
        //     The result of transforming point by using matrix.
        public static Point3D operator *(Point3D point, Matrix3D matrix)
        {
            return matrix.Transform(point);
        }

        //
        // Summary:
        //     Transforms the specified System.Windows.Media.Media3D.Point3D structure by the
        //     specified System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure to transform.
        //
        //   matrix:
        //     The System.Windows.Media.Media3D.Matrix3D structure to use for the transformation.
        //
        // Returns:
        //     A transformed System.Windows.Media.Media3D.Point3D structure, the result of transforming
        //     point by matrix.
        public static Point3D Multiply(Point3D point, Matrix3D matrix)
        {
            return matrix.Transform(point);
        }

        //
        // Summary:
        //     Converts a System.Windows.Media.Media3D.Point3D structure into a System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   point:
        //     The point to convert.
        //
        // Returns:
        //     The result of converting point.
        public static explicit operator Vector3D(Point3D point)
        {
            return new Vector3D(point._x, point._y, point._z);
        }

        //
        // Summary:
        //     Converts a System.Windows.Media.Media3D.Point3D structure into a System.Windows.Media.Media3D.Point4D
        //     structure.
        //
        // Parameters:
        //   point:
        //     The point to convert.
        //
        // Returns:
        //     The result of converting point.
        public static explicit operator Point4D(Point3D point)
        {
            return new Point4D(point._x, point._y, point._z, 1.0);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point3D structures for equality.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point3D structure to compare.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point3D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Point3D.X, System.Windows.Media.Media3D.Point3D.Y,
        //     and System.Windows.Media.Media3D.Point3D.Z coordinates of point1 and point2 are
        //     equal; otherwise, false.
        public static bool operator ==(Point3D point1, Point3D point2)
        {
            if (point1.X == point2.X && point1.Y == point2.Y)
            {
                return point1.Z == point2.Z;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point3D structures for inequality.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point3D structure to compare.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point3D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Point3D.X, System.Windows.Media.Media3D.Point3D.Y,
        //     and System.Windows.Media.Media3D.Point3D.Z coordinates of point1 and point2 are
        //     different; otherwise, false.
        public static bool operator !=(Point3D point1, Point3D point2)
        {
            return !(point1 == point2);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point3D structures for equality.
        //
        // Parameters:
        //   point1:
        //     The first System.Windows.Media.Media3D.Point3D structure to compare.
        //
        //   point2:
        //     The second System.Windows.Media.Media3D.Point3D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Point3D.X, System.Windows.Media.Media3D.Point3D.Y,
        //     and System.Windows.Media.Media3D.Point3D.Z values for point1 and point2 are equal;
        //     otherwise, false.
        public static bool Equals(Point3D point1, Point3D point2)
        {
            if (point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y))
            {
                return point1.Z.Equals(point2.Z);
            }

            return false;
        }

        //
        // Summary:
        //     Determines whether the specified object is a System.Windows.Media.Media3D.Point3D
        //     structure and if so, whether the System.Windows.Media.Media3D.Point3D.X, System.Windows.Media.Media3D.Point3D.Y,
        //     and System.Windows.Media.Media3D.Point3D.Z properties of the specified System.Object
        //     are equal to the System.Windows.Media.Media3D.Point3D.X, System.Windows.Media.Media3D.Point3D.Y,
        //     and System.Windows.Media.Media3D.Point3D.Z properties of this System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        // Parameters:
        //   o:
        //     The object to compare.
        //
        // Returns:
        //     true if the instances are equal; otherwise, false. true if o is a System.Windows.Media.Media3D.Point3D
        //     structure and if it is also identical to this System.Windows.Media.Media3D.Point3D
        //     structure; otherwise, false.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Point3D))
            {
                return false;
            }

            Point3D point = (Point3D)o;
            return Equals(this, point);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Point3D structures for equality.
        //
        // Parameters:
        //   value:
        //     The instance of System.Windows.Media.Media3D.Point3D to compare to this instance.
        //
        // Returns:
        //     true if instances are equal; otherwise, false.
        public bool Equals(Point3D value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Returns a hash code for this System.Windows.Media.Media3D.Point3D structure.
        //
        // Returns:
        //     A hash code for this System.Windows.Media.Media3D.Point3D structure.
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        //
        // Summary:
        //     Converts a System.String representation of a 3-D point into the equivalent System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        // Parameters:
        //   source:
        //     The System.String representation of the 3-D point.
        //
        // Returns:
        //     The equivalent System.Windows.Media.Media3D.Point3D structure.
        /*public static Point3D Parse(string source)
        {
            IFormatProvider invariantEnglishUS = System.Windows.Markup.TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string value = tokenizerHelper.NextTokenRequired();
            Point3D result = new Point3D(Convert.ToDouble(value, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS));
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        // Returns:
        //     A System.String containing the System.Windows.Media.Media3D.Point3D.X, System.Windows.Media.Media3D.Point3D.Y,
        //     and System.Windows.Media.Media3D.Point3D.Z values of this System.Windows.Media.Media3D.Point3D
        //     structure.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        // Parameters:
        //   provider:
        //     The culture-specific formatting information.
        //
        // Returns:
        //     A System.String containing the System.Windows.Media.Media3D.Point3D.X, System.Windows.Media.Media3D.Point3D.Y,
        //     and System.Windows.Media.Media3D.Point3D.Z values of this System.Windows.Media.Media3D.Point3D
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
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}", numericListSeparator, _x, _y, _z);
        }
    }
}
