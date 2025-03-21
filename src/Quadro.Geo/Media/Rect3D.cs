﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Rect3D : IFormattable
    {
        internal static readonly Rect3D Infinite = CreateInfiniteRect3D();

        private static readonly Rect3D s_empty = CreateEmptyRect3D();

        internal double _x;

        internal double _y;

        internal double _z;

        internal double _sizeX;

        internal double _sizeY;

        internal double _sizeZ;

        //
        // Summary:
        //     Gets an empty System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     An empty System.Windows.Media.Media3D.Rect3D.
        public static Rect3D Empty => s_empty;

        //
        // Summary:
        //     Gets a value that indicates whether this System.Windows.Media.Media3D.Rect3D
        //     is the System.Windows.Media.Media3D.Rect3D.EmptySystem.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     true if this System.Windows.Media.Media3D.Rect3D is the empty rectangle; false
        //     otherwise.
        public bool IsEmpty => _sizeX < 0.0;

        //
        // Summary:
        //     Gets or sets a System.Windows.Media.Media3D.Point3D that represents the origin
        //     of the System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     System.Windows.Media.Media3D.Point3D that represents the origin of the System.Windows.Media.Media3D.Rect3D,
        //     typically the back bottom left corner. The default value is (0,0,0).
        public Point3D Location
        {
            get
            {
                return new Point3D(_x, _y, _z);
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                _x = value._x;
                _y = value._y;
                _z = value._z;
            }
        }

        //
        // Summary:
        //     Gets or sets the area of the System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     System.Windows.Media.Media3D.Size3D that specifies the area of the System.Windows.Media.Media3D.Rect3D.
        public Size3D Size
        {
            get
            {
                if (IsEmpty)
                {
                    return Size3D.Empty;
                }

                return new Size3D(_sizeX, _sizeY, _sizeZ);
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
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                _sizeX = value._x;
                _sizeY = value._y;
                _sizeZ = value._z;
            }
        }

        //
        // Summary:
        //     Gets or sets the size of the System.Windows.Media.Media3D.Rect3D in the X dimension.
        //
        // Returns:
        //     Double that specifies the size of the System.Windows.Media.Media3D.Rect3D in
        //     the X dimension.
        public double SizeX
        {
            get
            {
                return _sizeX;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size3D_DimensionCannotBeNegative");
                }

                _sizeX = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the size of the System.Windows.Media.Media3D.Rect3D in the Y dimension.
        //
        // Returns:
        //     Double that specifies the size of the System.Windows.Media.Media3D.Rect3D in
        //     the Y dimension.
        public double SizeY
        {
            get
            {
                return _sizeY;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size3D_DimensionCannotBeNegative");
                }

                _sizeY = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the size of the Rect3D in the Z dimension.
        //
        // Returns:
        //     Double that specifies the size of the System.Windows.Media.Media3D.Rect3D in
        //     the Z dimension.
        public double SizeZ
        {
            get
            {
                return _sizeZ;
            }
            set
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                if (value < 0.0)
                {
                    throw new ArgumentException("Size3D_DimensionCannotBeNegative");
                }

                _sizeZ = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the X coordinate of the System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     Value of the X coordinate of the System.Windows.Media.Media3D.Rect3D.
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
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                _x = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the Y coordinate of the System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     Value of the Y coordinate of the System.Windows.Media.Media3D.Rect3D.
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
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                _y = value;
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the Z coordinate of the System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     Value of the Z coordinate of the System.Windows.Media.Media3D.Rect3D.
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
                    throw new InvalidOperationException("Rect3D_CannotModifyEmptyRect");
                }

                _z = value;
            }
        }

        //
        // Summary:
        //     Initializes a new instance of a System.Windows.Media.Media3D.Rect3D structure.
        //
        // Parameters:
        //   location:
        //     Location of the new System.Windows.Media.Media3D.Rect3D.
        //
        //   size:
        //     Size of the new System.Windows.Media.Media3D.Rect3D.
        public Rect3D(Point3D location, Size3D size)
        {
            if (size.IsEmpty)
            {
                this = s_empty;
                return;
            }

            _x = location._x;
            _y = location._y;
            _z = location._z;
            _sizeX = size._x;
            _sizeY = size._y;
            _sizeZ = size._z;
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Media.Media3D.Rect3D structure.
        //
        // Parameters:
        //   x:
        //     X-axis coordinate of the new System.Windows.Media.Media3D.Rect3D.
        //
        //   y:
        //     Y-axis coordinate of the new System.Windows.Media.Media3D.Rect3D.
        //
        //   z:
        //     Z-axis coordinate of the new System.Windows.Media.Media3D.Rect3D.
        //
        //   sizeX:
        //     Size of the new System.Windows.Media.Media3D.Rect3D in the X dimension.
        //
        //   sizeY:
        //     Size of the new System.Windows.Media.Media3D.Rect3D in the Y dimension.
        //
        //   sizeZ:
        //     Size of the new System.Windows.Media.Media3D.Rect3D in the Z dimension.
        public Rect3D(double x, double y, double z, double sizeX, double sizeY, double sizeZ)
        {
            if (sizeX < 0.0 || sizeY < 0.0 || sizeZ < 0.0)
            {
                throw new ArgumentException("Size3D_DimensionCannotBeNegative");
            }

            _x = x;
            _y = y;
            _z = z;
            _sizeX = sizeX;
            _sizeY = sizeY;
            _sizeZ = sizeZ;
        }

        internal Rect3D(Point3D point1, Point3D point2)
        {
            _x = Math.Min(point1._x, point2._x);
            _y = Math.Min(point1._y, point2._y);
            _z = Math.Min(point1._z, point2._z);
            _sizeX = Math.Max(point1._x, point2._x) - _x;
            _sizeY = Math.Max(point1._y, point2._y) - _y;
            _sizeZ = Math.Max(point1._z, point2._z) - _z;
        }

        internal Rect3D(Point3D point, Vector3D vector)
            : this(point, point + vector)
        {
        }

        //
        // Summary:
        //     Gets a value that indicates whether a specified System.Windows.Media.Media3D.Point3D
        //     is within the System.Windows.Media.Media3D.Rect3D, including its edges.
        //
        // Parameters:
        //   point:
        //     Point to be tested.
        //
        // Returns:
        //     True if the specified point or rectangle is within the System.Windows.Media.Media3D.Rect3D,
        //     including its edges; false otherwise.
        public bool Contains(Point3D point)
        {
            return Contains(point._x, point._y, point._z);
        }

        //
        // Summary:
        //     Gets a value that indicates whether a specified System.Windows.Media.Media3D.Point3D
        //     is within the System.Windows.Media.Media3D.Rect3D, including its edges.
        //
        // Parameters:
        //   x:
        //     X-axis coordinate of the System.Windows.Media.Media3D.Point3D to be tested.
        //
        //   y:
        //     Y-axis coordinate of the System.Windows.Media.Media3D.Point3D to be tested.
        //
        //   z:
        //     Z-coordinate of the System.Windows.Media.Media3D.Point3D to be tested.
        //
        // Returns:
        //     true if the specified point or rectangle is within the System.Windows.Media.Media3D.Rect3D,
        //     including its edges; false otherwise.
        public bool Contains(double x, double y, double z)
        {
            if (IsEmpty)
            {
                return false;
            }

            return ContainsInternal(x, y, z);
        }

        //
        // Summary:
        //     Gets a value that indicates whether a specified System.Windows.Media.Media3D.Point3D
        //     is within the System.Windows.Media.Media3D.Rect3D, including its edges.
        //
        // Parameters:
        //   rect:
        //     System.Windows.Media.Media3D.Rect3D to be tested.
        //
        // Returns:
        //     True if the specified point or rectangle is within the System.Windows.Media.Media3D.Rect3D,
        //     including its edges; false otherwise.
        public bool Contains(Rect3D rect)
        {
            if (IsEmpty || rect.IsEmpty)
            {
                return false;
            }

            if (_x <= rect._x && _y <= rect._y && _z <= rect._z && _x + _sizeX >= rect._x + rect._sizeX && _y + _sizeY >= rect._y + rect._sizeY)
            {
                return _z + _sizeZ >= rect._z + rect._sizeZ;
            }

            return false;
        }

        //
        // Summary:
        //     Returns a value that indicates whether the specified System.Windows.Media.Media3D.Rect3D
        //     intersects with this System.Windows.Media.Media3D.Rect3D.
        //
        // Parameters:
        //   rect:
        //     Rectangle to evaluate.
        //
        // Returns:
        //     true if the specified System.Windows.Media.Media3D.Rect3D intersects with this
        //     System.Windows.Media.Media3D.Rect3D; false otherwise.
        public bool IntersectsWith(Rect3D rect)
        {
            if (IsEmpty || rect.IsEmpty)
            {
                return false;
            }

            if (rect._x <= _x + _sizeX && rect._x + rect._sizeX >= _x && rect._y <= _y + _sizeY && rect._y + rect._sizeY >= _y && rect._z <= _z + _sizeZ)
            {
                return rect._z + rect._sizeZ >= _z;
            }

            return false;
        }

        //
        // Summary:
        //     Finds the intersection of the current System.Windows.Media.Media3D.Rect3D and
        //     the specified System.Windows.Media.Media3D.Rect3D, and stores the result as the
        //     current System.Windows.Media.Media3D.Rect3D.
        //
        // Parameters:
        //   rect:
        //     The System.Windows.Media.Media3D.Rect3D to intersect with the current System.Windows.Media.Media3D.Rect3D.
        public void Intersect(Rect3D rect)
        {
            if (IsEmpty || rect.IsEmpty || !IntersectsWith(rect))
            {
                this = Empty;
                return;
            }

            double num = Math.Max(_x, rect._x);
            double num2 = Math.Max(_y, rect._y);
            double num3 = Math.Max(_z, rect._z);
            _sizeX = Math.Min(_x + _sizeX, rect._x + rect._sizeX) - num;
            _sizeY = Math.Min(_y + _sizeY, rect._y + rect._sizeY) - num2;
            _sizeZ = Math.Min(_z + _sizeZ, rect._z + rect._sizeZ) - num3;
            _x = num;
            _y = num2;
            _z = num3;
        }

        //
        // Summary:
        //     Returns the intersection of the specified System.Windows.Media.Media3D.Rect3D
        //     values.
        //
        // Parameters:
        //   rect1:
        //     First System.Windows.Media.Media3D.Rect3D.
        //
        //   rect2:
        //     Second System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     Result of the intersection of rect1 and rect2.
        public static Rect3D Intersect(Rect3D rect1, Rect3D rect2)
        {
            rect1.Intersect(rect2);
            return rect1;
        }

        //
        // Summary:
        //     Updates a specified System.Windows.Media.Media3D.Rect3D to reflect the union
        //     of that System.Windows.Media.Media3D.Rect3D and a second specified System.Windows.Media.Media3D.Rect3D.
        //
        // Parameters:
        //   rect:
        //     The System.Windows.Media.Media3D.Rect3D whose union with the current System.Windows.Media.Media3D.Rect3D
        //     is to be evaluated.
        public void Union(Rect3D rect)
        {
            if (IsEmpty)
            {
                this = rect;
            }
            else if (!rect.IsEmpty)
            {
                double num = Math.Min(_x, rect._x);
                double num2 = Math.Min(_y, rect._y);
                double num3 = Math.Min(_z, rect._z);
                _sizeX = Math.Max(_x + _sizeX, rect._x + rect._sizeX) - num;
                _sizeY = Math.Max(_y + _sizeY, rect._y + rect._sizeY) - num2;
                _sizeZ = Math.Max(_z + _sizeZ, rect._z + rect._sizeZ) - num3;
                _x = num;
                _y = num2;
                _z = num3;
            }
        }

        //
        // Summary:
        //     Returns a new instance of System.Windows.Media.Media3D.Rect3D that represents
        //     the union of two System.Windows.Media.Media3D.Rect3D objects.
        //
        // Parameters:
        //   rect1:
        //     First System.Windows.Media.Media3D.Rect3D.
        //
        //   rect2:
        //     Second System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     A System.Windows.Media.Media3D.Rect3D value that represents the result of the
        //     union of rect1 and rect2.
        public static Rect3D Union(Rect3D rect1, Rect3D rect2)
        {
            rect1.Union(rect2);
            return rect1;
        }

        //
        // Summary:
        //     Updates a specified System.Windows.Media.Media3D.Rect3D to reflect the union
        //     of that System.Windows.Media.Media3D.Rect3D and a specified System.Windows.Media.Media3D.Point3D.
        //
        // Parameters:
        //   point:
        //     The System.Windows.Media.Media3D.Point3D whose union with the specified System.Windows.Media.Media3D.Rect3D
        //     is to be evaluated.
        public void Union(Point3D point)
        {
            Union(new Rect3D(point, point));
        }

        //
        // Summary:
        //     Returns a new System.Windows.Media.Media3D.Rect3D that represents the union of
        //     a System.Windows.Media.Media3D.Rect3D, and a specified System.Windows.Media.Media3D.Point3D.
        //
        // Parameters:
        //   rect:
        //     The System.Windows.Media.Media3D.Rect3D whose union with the current System.Windows.Media.Media3D.Rect3D
        //     is to be evaluated.
        //
        //   point:
        //     The System.Windows.Media.Media3D.Point3D whose union with the specified System.Windows.Media.Media3D.Rect3D
        //     is to be evaluated.
        //
        // Returns:
        //     Result of the union of rect and point.
        public static Rect3D Union(Rect3D rect, Point3D point)
        {
            rect.Union(new Rect3D(point, point));
            return rect;
        }

        //
        // Summary:
        //     Sets the offset translation of the System.Windows.Media.Media3D.Rect3D to the
        //     provided value, specified as a System.Windows.Media.Media3D.Vector3D.
        //
        // Parameters:
        //   offsetVector:
        //     System.Windows.Media.Media3D.Vector3D that specifies the offset translation.
        public void Offset(Vector3D offsetVector)
        {
            Offset(offsetVector._x, offsetVector._y, offsetVector._z);
        }

        //
        // Summary:
        //     Gets or sets an offset value by which the location of a System.Windows.Media.Media3D.Rect3D
        //     is translated.
        //
        // Parameters:
        //   offsetX:
        //     Offset along the X axis.
        //
        //   offsetY:
        //     Offset along the Y axis.
        //
        //   offsetZ:
        //     Offset along the Z axis.
        public void Offset(double offsetX, double offsetY, double offsetZ)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Rect3D_CannotCallMethod");
            }

            _x += offsetX;
            _y += offsetY;
            _z += offsetZ;
        }

        //
        // Summary:
        //     Gets or sets an offset value by which the location of a System.Windows.Media.Media3D.Rect3D
        //     is translated.
        //
        // Parameters:
        //   rect:
        //     System.Windows.Media.Media3D.Rect3D to be translated.
        //
        //   offsetVector:
        //     System.Windows.Media.Media3D.Vector3D that specifies the offset translation.
        //
        // Returns:
        //     A System.Windows.Media.Media3D.Rect3D value that represents the result of the
        //     offset.
        public static Rect3D Offset(Rect3D rect, Vector3D offsetVector)
        {
            rect.Offset(offsetVector._x, offsetVector._y, offsetVector._z);
            return rect;
        }

        //
        // Summary:
        //     Gets or sets an offset value by which the location of a System.Windows.Media.Media3D.Rect3D
        //     is translated.
        //
        // Parameters:
        //   rect:
        //     Rect3D to be translated.
        //
        //   offsetX:
        //     Offset along the X axis.
        //
        //   offsetY:
        //     Offset along the Y axis.
        //
        //   offsetZ:
        //     Offset along the Z axis.
        //
        // Returns:
        //     A System.Windows.Media.Media3D.Rect3D value that represents the result of the
        //     offset.
        public static Rect3D Offset(Rect3D rect, double offsetX, double offsetY, double offsetZ)
        {
            rect.Offset(offsetX, offsetY, offsetZ);
            return rect;
        }

        private bool ContainsInternal(double x, double y, double z)
        {
            if (x >= _x && x <= _x + _sizeX && y >= _y && y <= _y + _sizeY && z >= _z)
            {
                return z <= _z + _sizeZ;
            }

            return false;
        }

        private static Rect3D CreateEmptyRect3D()
        {
            Rect3D result = default;
            result._x = double.PositiveInfinity;
            result._y = double.PositiveInfinity;
            result._z = double.PositiveInfinity;
            result._sizeX = double.NegativeInfinity;
            result._sizeY = double.NegativeInfinity;
            result._sizeZ = double.NegativeInfinity;
            return result;
        }

        private static Rect3D CreateInfiniteRect3D()
        {
            Rect3D result = default;
            result._x = -3.4028234663852886E+38;
            result._y = -3.4028234663852886E+38;
            result._z = -3.4028234663852886E+38;
            result._sizeX = 6.8056469327705772E+38;
            result._sizeY = 6.8056469327705772E+38;
            result._sizeZ = 6.8056469327705772E+38;
            return result;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Rect3D instances for exact equality.
        //
        // Parameters:
        //   rect1:
        //     First System.Windows.Media.Media3D.Rect3D to evaluate.
        //
        //   rect2:
        //     Second System.Windows.Media.Media3D.Rect3D to evaluate.
        //
        // Returns:
        //     true if the two System.Windows.Media.Media3D.Rect3D instances are exactly equal;
        //     false otherwise.
        public static bool operator ==(Rect3D rect1, Rect3D rect2)
        {
            if (rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Z == rect2.Z && rect1.SizeX == rect2.SizeX && rect1.SizeY == rect2.SizeY)
            {
                return rect1.SizeZ == rect2.SizeZ;
            }

            return false;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Rect3D instances for exact inequality.
        //
        // Parameters:
        //   rect1:
        //     First System.Windows.Media.Media3D.Rect3D to compare.
        //
        //   rect2:
        //     Second System.Windows.Media.Media3D.Rect3D to compare.
        //
        // Returns:
        //     True if the two System.Windows.Media.Media3D.Rect3D instances are unequal, false
        //     otherwise.
        public static bool operator !=(Rect3D rect1, Rect3D rect2)
        {
            return !(rect1 == rect2);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Rect3D instances for equality.
        //
        // Parameters:
        //   rect1:
        //     First System.Windows.Media.Media3D.Rect3D to compare.
        //
        //   rect2:
        //     Second System.Windows.Media.Media3D.Rect3D to compare.
        //
        // Returns:
        //     true if the two specified System.Windows.Media.Media3D.Rect3D instances are exactly
        //     equal; false otherwise.
        public static bool Equals(Rect3D rect1, Rect3D rect2)
        {
            if (rect1.IsEmpty)
            {
                return rect2.IsEmpty;
            }

            if (rect1.X.Equals(rect2.X) && rect1.Y.Equals(rect2.Y) && rect1.Z.Equals(rect2.Z) && rect1.SizeX.Equals(rect2.SizeX) && rect1.SizeY.Equals(rect2.SizeY))
            {
                return rect1.SizeZ.Equals(rect2.SizeZ);
            }

            return false;
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Rect3D instances for equality.
        //
        // Parameters:
        //   o:
        //     The object to compare.
        //
        // Returns:
        //     true if the two specified System.Windows.Media.Media3D.Rect3D instances are exactly
        //     equal; false otherwise.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Rect3D))
            {
                return false;
            }

            Rect3D rect = (Rect3D)o;
            return Equals(this, rect);
        }

        //
        // Summary:
        //     Compares two System.Windows.Media.Media3D.Rect3D instances for equality.
        //
        // Parameters:
        //   value:
        //     The System.Windows.Media.Media3D.Rect3D instance to compare with the current
        //     instance.
        //
        // Returns:
        //     true if the two specified System.Windows.Media.Media3D.Rect3D instances are exactly
        //     equal; false otherwise.
        public bool Equals(Rect3D value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Returns the hash code for the System.Windows.Media.Media3D.Rect3D
        //
        // Returns:
        //     A hash code for this System.Windows.Media.Media3D.Rect3D.
        public override int GetHashCode()
        {
            if (IsEmpty)
            {
                return 0;
            }

            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ SizeX.GetHashCode() ^ SizeY.GetHashCode() ^ SizeZ.GetHashCode();
        }

        //
        // Summary:
        //     Converts a string representation of a System.Windows.Media.Media3D.Rect3D into
        //     the equivalent System.Windows.Media.Media3D.Rect3D structure.
        //
        // Parameters:
        //   source:
        //     String that represents a System.Windows.Media.Media3D.Rect3D.
        //
        // Returns:
        //     A string representation of the System.Windows.Media.Media3D.Rect3D.
        /*public static Rect3D Parse(string source)
        {
            IFormatProvider invariantEnglishUS = System.Windows.Markup.TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string text = tokenizerHelper.NextTokenRequired();
            Rect3D result = ((!(text == "Empty")) ? new Rect3D(Convert.ToDouble(text, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS)) : Empty);
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Creates a string representation of the Rect3D.
        //
        // Returns:
        //     A string representation of the System.Windows.Media.Media3D.Rect3D.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Creates a string representation of the System.Windows.Media.Media3D.Rect3D.
        //
        // Parameters:
        //   provider:
        //     Culture-specific formatting information.
        //
        // Returns:
        //     A string representation of the System.Windows.Media.Media3D.Rect3D.
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

            char numericListSeparator = ':';// TokenizerHelper.GetNumericListSeparator(provider);
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}{0}{4:" + format + "}{0}{5:" + format + "}{0}{6:" + format + "}", numericListSeparator, _x, _y, _z, _sizeX, _sizeY, _sizeZ);
        }
    }
}
