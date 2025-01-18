using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Vector3D : IFormattable
    {
        internal double _x;

        internal double _y;

        internal double _z;

        //
        // Summary:
        //     Gets the length of this System.Windows.Media.Media3D.Vector3D structure.
        //
        // Returns:
        //     The length of this System.Windows.Media.Media3D.Vector3D structure.
        public double Length => Math.Sqrt(_x * _x + _y * _y + _z * _z);

        //
        // Summary:
        //     Gets the square of the length of this System.Windows.Media.Media3D.Vector3D structure.
        //
        // Returns:
        //     The square of the length of this System.Windows.Media.Media3D.Vector3D structure.
        public double LengthSquared => _x * _x + _y * _y + _z * _z;

        //
        // Summary:
        //     Gets or sets the System.Windows.Media.Media3D.Vector3D.X component of this System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Vector3D.X component of this System.Windows.Media.Media3D.Vector3D
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
        //     Gets or sets the System.Windows.Media.Media3D.Vector3D.Y component of this System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Vector3D.Y component of this System.Windows.Media.Media3D.Vector3D
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
        //     Gets or sets the System.Windows.Media.Media3D.Vector3D.Z component of this System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Vector3D.Z component of this System.Windows.Media.Media3D.Vector3D
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
        //     Initializes a new instance of a System.Windows.Media.Media3D.Vector3D structure.
        //
        // Parameters:
        //   x:
        //     The new System.Windows.Media.Media3D.Vector3D structure's System.Windows.Media.Media3D.Vector3D.X
        //     value.
        //
        //   y:
        //     The new System.Windows.Media.Media3D.Vector3D structure's System.Windows.Media.Media3D.Vector3D.Y
        //     value.
        //
        //   z:
        //     The new System.Windows.Media.Media3D.Vector3D structure's System.Windows.Media.Media3D.Vector3D.Z
        //     value.
        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        //
        // Summary:
        //     Normalizes the specified System.Windows.Media.Media3D.Vector3D structure.
        public void Normalize()
        {
            double num = Math.Abs(_x);
            double num2 = Math.Abs(_y);
            double num3 = Math.Abs(_z);
            if (num2 > num)
            {
                num = num2;
            }

            if (num3 > num)
            {
                num = num3;
            }

            _x /= num;
            _y /= num;
            _z /= num;
            double num4 = Math.Sqrt(_x * _x + _y * _y + _z * _z);
            this /= num4;
        }

        //
        // Summary:
        //     Retrieves the angle required to rotate the first specified System.Windows.Media.Media3D.Vector3D
        //     structure into the second specified System.Windows.Media.Media3D.Vector3D structure.
        //
        // Parameters:
        //   vector1:
        //     The first System.Windows.Media.Media3D.Vector3D structure to evaluate.
        //
        //   vector2:
        //     The second System.Windows.Media.Media3D.Vector3D structure to evaluate.
        //
        // Returns:
        //     The angle in degrees needed to rotate vector1 into vector2.
        public static double AngleBetween(Vector3D vector1, Vector3D vector2)
        {
            vector1.Normalize();
            vector2.Normalize();
            double num = DotProduct(vector1, vector2);
            double radians = !(num < 0.0) ? 2.0 * Math.Asin((vector1 - vector2).Length / 2.0) : Math.PI - 2.0 * Math.Asin((-vector1 - vector2).Length / 2.0);
            return M3DUtil.RadiansToDegrees(radians);
        }

        //
        // Summary:
        //     Negates a System.Windows.Media.Media3D.Vector3D structure.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to negate.
        //
        // Returns:
        //     A System.Windows.Media.Media3D.Vector3D structure with System.Windows.Media.Media3D.Vector3D.X,
        //     System.Windows.Media.Media3D.Vector3D.Y, and System.Windows.Media.Media3D.Vector3D.Z
        //     values opposite of the System.Windows.Media.Media3D.Vector3D.X, System.Windows.Media.Media3D.Vector3D.Y,
        //     and System.Windows.Media.Media3D.Vector3D.Z values of vector.
        public static Vector3D operator -(Vector3D vector)
        {
            return new Vector3D(0.0 - vector._x, 0.0 - vector._y, 0.0 - vector._z);
        }

        //
        // Summary:
        //     Negates a System.Windows.Media.Media3D.Vector3D structure.
        public void Negate()
        {
            _x = 0.0 - _x;
            _y = 0.0 - _y;
            _z = 0.0 - _z;
        }

        //
        // Summary:
        //     Adds two System.Windows.Media.Media3D.Vector3D structures and returns the result
        //     as a System.Windows.Media.Media3D.Vector3D structure.
        //
        // Parameters:
        //   vector1:
        //     The first System.Windows.Media.Media3D.Vector3D structure to add.
        //
        //   vector2:
        //     The second System.Windows.Media.Media3D.Vector3D structure to add.
        //
        // Returns:
        //     The sum of vector1 and vector2.
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x + vector2._x, vector1._y + vector2._y, vector1._z + vector2._z);
        }

        //
        // Summary:
        //     Adds two System.Windows.Media.Media3D.Vector3D structures and returns the result
        //     as a System.Windows.Media.Media3D.Vector3D structure.
        //
        // Parameters:
        //   vector1:
        //     The first System.Windows.Media.Media3D.Vector3D structure to add.
        //
        //   vector2:
        //     The second System.Windows.Media.Media3D.Vector3D structure to add.
        //
        // Returns:
        //     The sum of vector1 and vector2.
        public static Vector3D Add(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x + vector2._x, vector1._y + vector2._y, vector1._z + vector2._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Vector3D structure from a System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   vector1:
        //     The System.Windows.Media.Media3D.Vector3D structure to be subtracted from.
        //
        //   vector2:
        //     The System.Windows.Media.Media3D.Vector3D structure to subtract from vector1.
        //
        // Returns:
        //     The result of subtracting vector2 from vector1.
        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x - vector2._x, vector1._y - vector2._y, vector1._z - vector2._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Vector3D structure from a System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   vector1:
        //     The System.Windows.Media.Media3D.Vector3D structure to be subtracted from.
        //
        //   vector2:
        //     The System.Windows.Media.Media3D.Vector3D structure to subtract from vector1.
        //
        // Returns:
        //     The result of subtracting vector2 from vector1.
        public static Vector3D Subtract(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x - vector2._x, vector1._y - vector2._y, vector1._z - vector2._z);
        }

        //
        // Summary:
        //     Translates the specified System.Windows.Media.Media3D.Point3D structure by the
        //     specified System.Windows.Media.Media3D.Vector3D structure and returns the result
        //     as a System.Windows.Media.Media3D.Point3D structure.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure used to translate the specified
        //     System.Windows.Media.Media3D.Point3D structure.
        //
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure to be translated.
        //
        // Returns:
        //     The result of translating point by vector.
        public static Point3D operator +(Vector3D vector, Point3D point)
        {
            return new Point3D(vector._x + point._x, vector._y + point._y, vector._z + point._z);
        }

        //
        // Summary:
        //     Translates the specified System.Windows.Media.Media3D.Point3D structure by the
        //     specified System.Windows.Media.Media3D.Vector3D structure and returns the result
        //     as a System.Windows.Media.Media3D.Point3D structure.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure used to translate the specified
        //     System.Windows.Media.Media3D.Point3D structure.
        //
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure to be translated.
        //
        // Returns:
        //     The result of translating point by vector.
        public static Point3D Add(Vector3D vector, Point3D point)
        {
            return new Point3D(vector._x + point._x, vector._y + point._y, vector._z + point._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Point3D structure from a System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to be subtracted from.
        //
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure to subtract from vector.
        //
        // Returns:
        //     The result of subtracting point from vector.
        public static Point3D operator -(Vector3D vector, Point3D point)
        {
            return new Point3D(vector._x - point._x, vector._y - point._y, vector._z - point._z);
        }

        //
        // Summary:
        //     Subtracts a System.Windows.Media.Media3D.Point3D structure from a System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to be subtracted from.
        //
        //   point:
        //     The System.Windows.Media.Media3D.Point3D structure to subtract from vector.
        //
        // Returns:
        //     The result of subtracting point from vector.
        public static Point3D Subtract(Vector3D vector, Point3D point)
        {
            return new Point3D(vector._x - point._x, vector._y - point._y, vector._z - point._z);
        }

        //
        // Summary:
        //     Multiplies the specified System.Windows.Media.Media3D.Vector3D structure by the
        //     specified scalar and returns the result as a System.Windows.Media.Media3D.Vector3D.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to multiply.
        //
        //   scalar:
        //     The scalar to multiply.
        //
        // Returns:
        //     The result of multiplying vector and scalar.
        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        //
        // Summary:
        //     Multiplies the specified System.Windows.Media.Media3D.Vector3D structure by the
        //     specified scalar and returns the result as a System.Windows.Media.Media3D.Vector3D.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to multiply.
        //
        //   scalar:
        //     The scalar to multiply.
        //
        // Returns:
        //     The result of multiplying vector and scalar.
        public static Vector3D Multiply(Vector3D vector, double scalar)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        //
        // Summary:
        //     Multiplies the specified scalar by the specified System.Windows.Media.Media3D.Vector3D
        //     structure and returns the result as a System.Windows.Media.Media3D.Vector3D.
        //
        // Parameters:
        //   scalar:
        //     The scalar to multiply.
        //
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to multiply.
        //
        // Returns:
        //     The result of multiplying scalar and vector.
        public static Vector3D operator *(double scalar, Vector3D vector)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        //
        // Summary:
        //     Multiplies the specified scalar by the specified System.Windows.Media.Media3D.Vector3D
        //     structure and returns the result as a System.Windows.Media.Media3D.Vector3D.
        //
        // Parameters:
        //   scalar:
        //     The scalar to multiply.
        //
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to multiply.
        //
        // Returns:
        //     The result of multiplying scalar and vector.
        public static Vector3D Multiply(double scalar, Vector3D vector)
        {
            return new Vector3D(vector._x * scalar, vector._y * scalar, vector._z * scalar);
        }

        //
        // Summary:
        //     Divides the specified System.Windows.Media.Media3D.Vector3D structure by the
        //     specified scalar and returns the result as a System.Windows.Media.Media3D.Vector3D.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to be divided.
        //
        //   scalar:
        //     The scalar to divide vector by.
        //
        // Returns:
        //     The result of dividing vector by scalar.
        public static Vector3D operator /(Vector3D vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        //
        // Summary:
        //     Divides the specified System.Windows.Media.Media3D.Vector3D structure by the
        //     specified scalar and returns the result as a System.Windows.Media.Media3D.Vector3D.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to be divided.
        //
        //   scalar:
        //     The scalar to divide vector by.
        //
        // Returns:
        //     The result of dividing vector by scalar.
        public static Vector3D Divide(Vector3D vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        //
        // Summary:
        //     Transforms the coordinate space of the specified System.Windows.Media.Media3D.Vector3D
        //     structure using the specified System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to transform.
        //
        //   matrix:
        //     The transformation to apply to the System.Windows.Media.Media3D.Vector3D structure.
        //
        // Returns:
        //     The result of transforming vector by matrix.
        public static Vector3D operator *(Vector3D vector, Matrix3D matrix)
        {
            return matrix.Transform(vector);
        }

        //
        // Summary:
        //     Transforms the coordinate space of the specified System.Windows.Media.Media3D.Vector3D
        //     structure using the specified System.Windows.Media.Media3D.Matrix3D structure.
        //
        // Parameters:
        //   vector:
        //     The System.Windows.Media.Media3D.Vector3D structure to transform.
        //
        //   matrix:
        //     The transformation to apply to the System.Windows.Media.Media3D.Vector3D structure.
        //
        // Returns:
        //     Returns the result of transforming vector by matrix3D.
        public static Vector3D Multiply(Vector3D vector, Matrix3D matrix)
        {
            return matrix.Transform(vector);
        }

        //
        // Summary:
        //     Calculates the dot product of two System.Windows.Media.Media3D.Vector3D structures.
        //
        // Parameters:
        //   vector1:
        //     The first System.Windows.Media.Media3D.Vector3D structure to evaluate.
        //
        //   vector2:
        //     The second System.Windows.Media.Media3D.Vector3D structure to evaluate.
        //
        // Returns:
        //     The dot product of vector1 and vector2.
        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return DotProduct(ref vector1, ref vector2);
        }

        internal static double DotProduct(ref Vector3D vector1, ref Vector3D vector2)
        {
            return vector1._x * vector2._x + vector1._y * vector2._y + vector1._z * vector2._z;
        }

        //
        // Summary:
        //     Calculates the cross product of two System.Windows.Media.Media3D.Vector3D structures.
        //
        // Parameters:
        //   vector1:
        //     The first System.Windows.Media.Media3D.Vector3D structure to evaluate.
        //
        //   vector2:
        //     The second System.Windows.Media.Media3D.Vector3D structure to evaluate.
        //
        // Returns:
        //     The cross product of vector1 and vector2.
        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            CrossProduct(ref vector1, ref vector2, out var result);
            return result;
        }

        internal static void CrossProduct(ref Vector3D vector1, ref Vector3D vector2, out Vector3D result)
        {
            result._x = vector1._y * vector2._z - vector1._z * vector2._y;
            result._y = vector1._z * vector2._x - vector1._x * vector2._z;
            result._z = vector1._x * vector2._y - vector1._y * vector2._x;
        }

        //
        // Summary:
        //     Converts a System.Windows.Media.Media3D.Vector3D structure into a System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        // Parameters:
        //   vector:
        //     The vector to convert.
        //
        // Returns:
        //     The result of converting vector.
        public static explicit operator Point3D(Vector3D vector)
        {
            return new Point3D(vector._x, vector._y, vector._z);
        }

        //
        // Summary:
        //     Converts a System.Windows.Media.Media3D.Vector3D structure into a System.Windows.Media.Media3D.Size3D.
        //
        // Parameters:
        //   vector:
        //     The vector to convert.
        //
        // Returns:
        //     The result of converting vector.
        public static explicit operator Size3D(Vector3D vector)
        {
            return new Size3D(Math.Abs(vector._x), Math.Abs(vector._y), Math.Abs(vector._z));
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Vector3D structures for equality.
        //
        // Parameters:
        //   vector1:
        //     The first System.Windows.Media.Media3D.Vector3D structure to compare.
        //
        //   vector2:
        //     The second System.Windows.Media.Media3D.Vector3D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Vector3D.X, System.Windows.Media.Media3D.Vector3D.Y,
        //     and System.Windows.Media.Media3D.Vector3D.Z components of vector1 and vector2
        //     are equal; false otherwise.
        public static bool operator ==(Vector3D vector1, Vector3D vector2)
        {
            if (vector1.X == vector2.X && vector1.Y == vector2.Y)
            {
                return vector1.Z == vector2.Z;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Vector3D structures for inequality.
        //
        // Parameters:
        //   vector1:
        //     The first System.Windows.Media.Media3D.Vector3D structure to compare.
        //
        //   vector2:
        //     The second System.Windows.Media.Media3D.Vector3D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Vector3D.X, System.Windows.Media.Media3D.Vector3D.Y,
        //     and System.Windows.Media.Media3D.Vector3D.Z components of vector3D1 and vector3D2
        //     are different; false otherwise.
        public static bool operator !=(Vector3D vector1, Vector3D vector2)
        {
            return !(vector1 == vector2);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Vector3D structures for equality.
        //
        // Parameters:
        //   vector1:
        //     First System.Windows.Media.Media3D.Vector3D to compare.
        //
        //   vector2:
        //     Second System.Windows.Media.Media3D.Vector3D to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Vector3D.X, System.Windows.Media.Media3D.Vector3D.Y,
        //     and System.Windows.Media.Media3D.Vector3D.Z components of vector1 and vector2
        //     are equal; false otherwise.
        public static bool Equals(Vector3D vector1, Vector3D vector2)
        {
            if (vector1.X.Equals(vector2.X) && vector1.Y.Equals(vector2.Y))
            {
                return vector1.Z.Equals(vector2.Z);
            }

            return false;
        }

        //
        // Summary:
        //     Determines whether the specified object is a System.Windows.Media.Media3D.Vector3D
        //     structure and whether the System.Windows.Media.Media3D.Vector3D.X, System.Windows.Media.Media3D.Vector3D.Y,
        //     and System.Windows.Media.Media3D.Vector3D.Z properties of the specified System.Object
        //     are equal to the System.Windows.Media.Media3D.Vector3D.X, System.Windows.Media.Media3D.Vector3D.Y,
        //     and System.Windows.Media.Media3D.Vector3D.Z properties of this System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   o:
        //     The object to compare.
        //
        // Returns:
        //     true if o is a System.Windows.Media.Media3D.Vector3D structure and is identical
        //     with this System.Windows.Media.Media3D.Vector3D structure; false otherwise.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Vector3D))
            {
                return false;
            }

            Vector3D vector = (Vector3D)o;
            return Equals(this, vector);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Vector3D structures for equality.
        //
        // Parameters:
        //   value:
        //     The instance of Vector to compare against this instance.
        //
        // Returns:
        //     true if instances are equal; otherwise, false.
        public bool Equals(Vector3D value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Gets a hash code for this System.Windows.Media.Media3D.Vector3D structure.
        //
        // Returns:
        //     A hash code for this System.Windows.Media.Media3D.Vector3D structure.
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        //
        // Summary:
        //     Converts a System.String representation of a 3-D vector into the equivalent System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   source:
        //     The System.String representation of the 3-D vector.
        //
        // Returns:
        //     The equivalent System.Windows.Media.Media3D.Vector3D structure.
        /*public static Vector3D Parse(string source)
        {
            IFormatProvider invariantEnglishUS = System.Windows.Markup.TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string value = tokenizerHelper.NextTokenRequired();
            Vector3D result = new Vector3D(Convert.ToDouble(value, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS));
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Returns:
        //     A string containing the System.Windows.Media.Media3D.Vector3D.X, System.Windows.Media.Media3D.Vector3D.Y,
        //     and System.Windows.Media.Media3D.Vector3D.Z values of this System.Windows.Media.Media3D.Vector3D
        //     structure.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   provider:
        //     Culture-specific formatting information.
        //
        // Returns:
        //     Returns a System.String containing the System.Windows.Media.Media3D.Vector3D.X,
        //     System.Windows.Media.Media3D.Vector3D.Y, and System.Windows.Media.Media3D.Vector3D.Z
        //     values of this System.Windows.Media.Media3D.Vector3D structure.
        public string ToString(IFormatProvider provider)
        {
            return ConvertToString(null, provider);
        }

        //
        // Summary:
        //     This member is part of the Windows Presentation Foundation (WPF) infrastructure
        //     and is not intended to be used directly by your code. For a description of this
        //     member, see System.IFormattable.ToString(System.String,System.IFormatProvider).
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
        //     String representation of this object.
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
