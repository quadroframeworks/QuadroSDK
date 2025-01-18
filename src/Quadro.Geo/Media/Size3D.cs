using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Size3D : IFormattable
    {
        private static readonly Size3D s_empty = CreateEmptySize3D();

        internal double _x;

        internal double _y;

        internal double _z;

        //
        // Summary:
        //     Gets a value that represents an empty System.Windows.Media.Media3D.Size3D structure.
        //
        // Returns:
        //     An empty instance of a System.Windows.Media.Media3D.Size3D structure.
        public static Size3D Empty => s_empty;

        //
        // Summary:
        //     Gets a value that indicates whether this System.Windows.Media.Media3D.Size3D
        //     structure is empty.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Size3D structure is empty; otherwise,
        //     false. The default is false.
        public bool IsEmpty => _x < 0.0;

        //
        // Summary:
        //     Gets or sets the System.Windows.Media.Media3D.Size3D.X value of this System.Windows.Media.Media3D.Size3D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Size3D.X value of this System.Windows.Media.Media3D.Size3D
        //     structure. The default value is 0.
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
                    throw new InvalidOperationException("Size3D_CannotModifyEmptySize");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size3D_DimensionCannotBeNegative");
                }

                _x = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the System.Windows.Media.Media3D.Size3D.Y value of this System.Windows.Media.Media3D.Size3D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Size3D.Y value of this System.Windows.Media.Media3D.Size3D
        //     structure. The default value is 0.
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
                    throw new InvalidOperationException("Size3D_CannotModifyEmptySize");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size3D_DimensionCannotBeNegative");
                }

                _y = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the System.Windows.Media.Media3D.Size3D.Z value of this System.Windows.Media.Media3D.Size3D
        //     structure.
        //
        // Returns:
        //     The System.Windows.Media.Media3D.Size3D.Z value of this System.Windows.Media.Media3D.Size3D
        //     structure. The default value is 0.
        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Size3D_CannotModifyEmptySize");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size3D_DimensionCannotBeNegative");
                }

                _z = value;
            }
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Media.Media3D.Size3D structure.
        //
        // Parameters:
        //   x:
        //     The new System.Windows.Media.Media3D.Size3D structure's System.Windows.Media.Media3D.Size3D.X
        //     value.
        //
        //   y:
        //     The new System.Windows.Media.Media3D.Size3D structure's System.Windows.Media.Media3D.Size3D.Y
        //     value.
        //
        //   z:
        //     The new System.Windows.Media.Media3D.Size3D structure's System.Windows.Media.Media3D.Size3D.Z
        //     value.
        public Size3D(double x, double y, double z)
        {
            if (x < 0.0 || y < 0.0 || z < 0.0)
            {
                throw new ArgumentException("Size3D_DimensionCannotBeNegative");
            }

            _x = x;
            _y = y;
            _z = z;
        }

        //
        // Summary:
        //     Converts this System.Windows.Media.Media3D.Size3D structure into a System.Windows.Media.Media3D.Vector3D
        //     structure.
        //
        // Parameters:
        //   size:
        //     The size to convert.
        //
        // Returns:
        //     The result of converting size.
        public static explicit operator Vector3D(Size3D size)
        {
            return new Vector3D(size._x, size._y, size._z);
        }

        //
        // Summary:
        //     Converts this System.Windows.Media.Media3D.Size3D structure into a System.Windows.Media.Media3D.Point3D
        //     structure.
        //
        // Parameters:
        //   size:
        //     The size to convert.
        //
        // Returns:
        //     The result of converting size.
        public static explicit operator Point3D(Size3D size)
        {
            return new Point3D(size._x, size._y, size._z);
        }

        private static Size3D CreateEmptySize3D()
        {
            Size3D result = default;
            result._x = double.NegativeInfinity;
            result._y = double.NegativeInfinity;
            result._z = double.NegativeInfinity;
            return result;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Size3D structures for equality. Two
        //     System.Windows.Media.Media3D.Size3D structures are equal if the values of their
        //     System.Windows.Media.Media3D.Size3D.X, System.Windows.Media.Media3D.Size3D.Y,
        //     and System.Windows.Media.Media3D.Size3D.Z properties are the same.
        //
        // Parameters:
        //   size1:
        //     The first System.Windows.Media.Media3D.Size3D structure to compare.
        //
        //   size2:
        //     The second System.Windows.Media.Media3D.Size3D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Size3D.X, System.Windows.Media.Media3D.Size3D.Y,
        //     and System.Windows.Media.Media3D.Size3D.Z components of size1 and size2 are equal;
        //     otherwise, false.
        public static bool operator ==(Size3D size1, Size3D size2)
        {
            if (size1.X == size2.X && size1.Y == size2.Y)
            {
                return size1.Z == size2.Z;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Size3D structures for inequality. Two
        //     System.Windows.Media.Media3D.Size3D structures are not equal if the values of
        //     their System.Windows.Media.Media3D.Size3D.X, System.Windows.Media.Media3D.Size3D.Y
        //     and System.Windows.Media.Media3D.Size3D.Z properties are different.
        //
        // Parameters:
        //   size1:
        //     The first System.Windows.Media.Media3D.Size3D structure to compare.
        //
        //   size2:
        //     The second System.Windows.Media.Media3D.Size3D structure to compare.
        //
        // Returns:
        //     true if the System.Windows.Media.Media3D.Size3D.X, System.Windows.Media.Media3D.Size3D.Y
        //     and System.Windows.Media.Media3D.Size3D.Z coordinates of size1 and size2 are
        //     different; otherwise, false.
        public static bool operator !=(Size3D size1, Size3D size2)
        {
            return !(size1 == size2);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Size3D structures for equality. Two
        //     System.Windows.Media.Media3D.Size3D structures are equal if the values of their
        //     System.Windows.Media.Media3D.Size3D.X, System.Windows.Media.Media3D.Size3D.Y,
        //     and System.Windows.Media.Media3D.Size3D.Z properties are the same.
        //
        // Parameters:
        //   size1:
        //     The first System.Windows.Media.Media3D.Size3D structure to compare.
        //
        //   size2:
        //     The second System.Windows.Media.Media3D.Size3D structure to compare.
        //
        // Returns:
        //     true if instances are equal; otherwise, false. true if the System.Windows.Media.Media3D.Size3D.X,
        //     System.Windows.Media.Media3D.Size3D.Y, and System.Windows.Media.Media3D.Size3D.Z
        //     components of size1 and size2 are equal; otherwise, false.
        public static bool Equals(Size3D size1, Size3D size2)
        {
            if (size1.IsEmpty)
            {
                return size2.IsEmpty;
            }

            if (size1.X.Equals(size2.X) && size1.Y.Equals(size2.Y))
            {
                return size1.Z.Equals(size2.Z);
            }

            return false;
        }

        //
        // Summary:
        //     Determines whether the specified object is a System.Windows.Media.Media3D.Size3D
        //     structure and whether the System.Windows.Media.Media3D.Size3D.X, System.Windows.Media.Media3D.Size3D.Y
        //     and System.Windows.Media.Media3D.Size3D.Z properties of the specified System.Object
        //     are equal to the System.Windows.Media.Media3D.Size3D.X, System.Windows.Media.Media3D.Size3D.Y
        //     and System.Windows.Media.Media3D.Size3D.Z properties of this System.Windows.Media.Media3D.Size3D
        //     structure.
        //
        // Parameters:
        //   o:
        //     The System.Object to compare.
        //
        // Returns:
        //     true if instances are equal; otherwise, false. true if o is a System.Windows.Media.Media3D.Size3D
        //     structure and is identical with this System.Windows.Media.Media3D.Size3D structure;
        //     otherwise, false.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Size3D))
            {
                return false;
            }

            Size3D size = (Size3D)o;
            return Equals(this, size);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Size3D structures for equality.
        //
        // Parameters:
        //   value:
        //     The instance of Size3D to compare to this instance.
        //
        // Returns:
        //     true if instances are equal; otherwise, false.
        public bool Equals(Size3D value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Returns a hash code for this System.Windows.Media.Media3D.Size3D structure.
        //
        // Returns:
        //     A hash code for this System.Windows.Media.Media3D.Size3D structure.
        public override int GetHashCode()
        {
            if (IsEmpty)
            {
                return 0;
            }

            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        //
        // Summary:
        //     Converts a System.String representation of a three-dimensional size structure
        //     into the equivalent System.Windows.Media.Media3D.Size3D structure.
        //
        // Parameters:
        //   source:
        //     The System.String representation of the three-dimensional size structure.
        //
        // Returns:
        //     The equivalent System.Windows.Media.Media3D.Size3D structure.
        /*public static Size3D Parse(string source)
        {
            IFormatProvider invariantEnglishUS = System.Windows.Markup.TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string text = tokenizerHelper.NextTokenRequired();
            Size3D result = ((!(text == "Empty")) ? new Size3D(Convert.ToDouble(text, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS)) : Empty);
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Size3D
        //     structure.
        //
        // Returns:
        //     Returns a System.String containing the System.Windows.Media.Media3D.Size3D.X,
        //     System.Windows.Media.Media3D.Size3D.Y, and System.Windows.Media.Media3D.Size3D.Z
        //     values of this System.Windows.Media.Media3D.Size3D structure.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Media3D.Size3D
        //     structure.
        //
        // Parameters:
        //   provider:
        //     Culture-specific formatting information.
        //
        // Returns:
        //     Returns a System.String containing the System.Windows.Media.Media3D.Size3D.X,
        //     System.Windows.Media.Media3D.Size3D.Y, and System.Windows.Media.Media3D.Size3D.Z
        //     values of this System.Windows.Media.Media3D.Size3D structure.
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
            if (IsEmpty)
            {
                return "Empty";
            }

            char numericListSeparator = ':'; // TokenizerHelper.GetNumericListSeparator(provider);
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}", numericListSeparator, _x, _y, _z);
        }
    }
}
