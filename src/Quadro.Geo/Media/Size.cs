using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Size : IFormattable
    {
        internal double _width;

        internal double _height;

        private static readonly Size s_empty = CreateEmptySize();

        //
        // Summary:
        //     Gets a value that represents a static empty System.Windows.Size.
        //
        // Returns:
        //     An empty instance of System.Windows.Size.
        public static Size Empty => s_empty;

        //
        // Summary:
        //     Gets a value that indicates whether this instance of System.Windows.Size is System.Windows.Size.Empty.
        //
        // Returns:
        //     true if this instance of size is System.Windows.Size.Empty; otherwise false.
        public bool IsEmpty => _width < 0.0;

        //
        // Summary:
        //     Gets or sets the System.Windows.Size.Width of this instance of System.Windows.Size.
        //
        // Returns:
        //     The System.Windows.Size.Width of this instance of System.Windows.Size. The default
        //     value is 0. The value cannot be negative.
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
                    throw new InvalidOperationException("Size_CannotModifyEmptySize");
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
        //     Gets or sets the System.Windows.Size.Height of this instance of System.Windows.Size.
        //
        // Returns:
        //     The System.Windows.Size.Height of this instance of System.Windows.Size. The default
        //     is 0. The value cannot be negative.
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
                    throw new InvalidOperationException("Size_CannotModifyEmptySize");
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
        //     Compares two instances of System.Windows.Size for equality.
        //
        // Parameters:
        //   size1:
        //     The first instance of System.Windows.Size to compare.
        //
        //   size2:
        //     The second instance of System.Windows.Size to compare.
        //
        // Returns:
        //     true if the two instances of System.Windows.Size are equal; otherwise false.
        public static bool operator ==(Size size1, Size size2)
        {
            if (size1.Width == size2.Width)
            {
                return size1.Height == size2.Height;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two instances of System.Windows.Size for inequality.
        //
        // Parameters:
        //   size1:
        //     The first instance of System.Windows.Size to compare.
        //
        //   size2:
        //     The second instance of System.Windows.Size to compare.
        //
        // Returns:
        //     true if the instances of System.Windows.Size are not equal; otherwise false.
        public static bool operator !=(Size size1, Size size2)
        {
            return !(size1 == size2);
        }

        //
        // Summary:
        //     Compares two instances of System.Windows.Size for equality.
        //
        // Parameters:
        //   size1:
        //     The first instance of System.Windows.Size to compare.
        //
        //   size2:
        //     The second instance of System.Windows.Size to compare.
        //
        // Returns:
        //     true if the instances of System.Windows.Size are equal; otherwise, false.
        public static bool Equals(Size size1, Size size2)
        {
            if (size1.IsEmpty)
            {
                return size2.IsEmpty;
            }

            if (size1.Width.Equals(size2.Width))
            {
                return size1.Height.Equals(size2.Height);
            }

            return false;
        }

        //
        // Summary:
        //     Compares an object to an instance of System.Windows.Size for equality.
        //
        // Parameters:
        //   o:
        //     The System.Object to compare.
        //
        // Returns:
        //     true if the sizes are equal; otherwise, false.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Size))
            {
                return false;
            }

            Size size = (Size)o;
            return Equals(this, size);
        }

        //
        // Summary:
        //     Compares a value to an instance of System.Windows.Size for equality.
        //
        // Parameters:
        //   value:
        //     The size to compare to this current instance of System.Windows.Size.
        //
        // Returns:
        //     true if the instances of System.Windows.Size are equal; otherwise, false.
        public bool Equals(Size value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Gets the hash code for this instance of System.Windows.Size.
        //
        // Returns:
        //     The hash code for this instance of System.Windows.Size.
        public override int GetHashCode()
        {
            if (IsEmpty)
            {
                return 0;
            }

            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        //
        // Summary:
        //     Returns an instance of System.Windows.Size from a converted System.String.
        //
        // Parameters:
        //   source:
        //     A System.String value to parse to a System.Windows.Size value.
        //
        // Returns:
        //     An instance of System.Windows.Size.
        /*public static Size Parse(string source)
        {
            IFormatProvider invariantEnglishUS = TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string text = tokenizerHelper.NextTokenRequired();
            Size result = ((!(text == "Empty")) ? new Size(Convert.ToDouble(text, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS)) : Empty);
            tokenizerHelper.LastTokenRequired();
            return result;
        }
        */
        //
        // Summary:
        //     Returns a System.String that represents this System.Windows.Size object.
        //
        // Returns:
        //     A System.String that specifies the width followed by the height.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Returns a System.String that represents this instance of System.Windows.Size.
        //
        // Parameters:
        //   provider:
        //     An object that provides a way to control formatting.
        //
        // Returns:
        //     A System.String that represents this System.Windows.Size object.
        public string ToString(IFormatProvider provider)
        {
            return ConvertToString(null, provider);
        }

        //
        // Summary:
        //     This type or member supports the Windows Presentation Foundation (WPF) infrastructure
        //     and is not intended to be used directly from your code.
        //
        // Parameters:
        //   format:
        //     The format to use.
        //
        //   provider:
        //     The provider to use to format the value.
        //
        // Returns:
        //     The value of the current instance in the specified format.
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
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}", new object[3] { numericListSeparator, _width, _height });
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Size structure and assigns it
        //     an initial width and height.
        //
        // Parameters:
        //   width:
        //     The initial width of the instance of System.Windows.Size.
        //
        //   height:
        //     The initial height of the instance of System.Windows.Size.
        public Size(double width, double height)
        {
            if (width < 0.0 || height < 0.0)
            {
                throw new ArgumentException("Size_WidthAndHeightCannotBeNegative");
            }

            _width = width;
            _height = height;
        }

        //
        // Summary:
        //     Explicitly converts an instance of System.Windows.Size to an instance of System.Windows.Vector.
        //
        // Parameters:
        //   size:
        //     The System.Windows.Size value to be converted.
        //
        // Returns:
        //     A System.Windows.Vector equal in value to this instance of System.Windows.Size.
        public static explicit operator Vector(Size size)
        {
            return new Vector(size._width, size._height);
        }

        //
        // Summary:
        //     Explicitly converts an instance of System.Windows.Size to an instance of System.Windows.Point.
        //
        // Parameters:
        //   size:
        //     The System.Windows.Size value to be converted.
        //
        // Returns:
        //     A System.Windows.Point equal in value to this instance of System.Windows.Size.
        public static explicit operator Point(Size size)
        {
            return new Point(size._width, size._height);
        }

        private static Size CreateEmptySize()
        {
            Size result = default;
            result._width = double.NegativeInfinity;
            result._height = double.NegativeInfinity;
            return result;
        }
    }
}
