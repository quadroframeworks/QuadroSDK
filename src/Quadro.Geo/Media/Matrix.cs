using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Media
{
    public struct Matrix : IFormattable
    {
        private static Matrix s_identity = CreateIdentity();

        private const int c_identityHashCode = 0;

        internal double _m11;

        internal double _m12;

        internal double _m21;

        internal double _m22;

        internal double _offsetX;

        internal double _offsetY;

        internal MatrixTypes _type;

        internal int _padding;

        //
        // Summary:
        //     Gets an identity System.Windows.Media.Matrix.
        //
        // Returns:
        //     An identity matrix.
        public static Matrix Identity => s_identity;

        //
        // Summary:
        //     Gets a value that indicates whether this System.Windows.Media.Matrix structure
        //     is an identity matrix.
        //
        // Returns:
        //     true if the System.Windows.Media.Matrix structure is an identity matrix; otherwise,
        //     false. The default is true.
        public bool IsIdentity
        {
            get
            {
                if (_type != 0)
                {
                    if (_m11 == 1.0 && _m12 == 0.0 && _m21 == 0.0 && _m22 == 1.0 && _offsetX == 0.0)
                    {
                        return _offsetY == 0.0;
                    }

                    return false;
                }

                return true;
            }
        }

        //
        // Summary:
        //     Gets the determinant of this System.Windows.Media.Matrix structure.
        //
        // Returns:
        //     The determinant of this System.Windows.Media.Matrix.
        public double Determinant
        {
            get
            {
                switch (_type)
                {
                    case MatrixTypes.TRANSFORM_IS_IDENTITY:
                    case MatrixTypes.TRANSFORM_IS_TRANSLATION:
                        return 1.0;
                    case MatrixTypes.TRANSFORM_IS_SCALING:
                    case MatrixTypes.TRANSFORM_IS_TRANSLATION | MatrixTypes.TRANSFORM_IS_SCALING:
                        return _m11 * _m22;
                    default:
                        return _m11 * _m22 - _m12 * _m21;
                }
            }
        }

        //
        // Summary:
        //     Gets a value that indicates whether this System.Windows.Media.Matrix structure
        //     is invertible.
        //
        // Returns:
        //     true if the System.Windows.Media.Matrix has an inverse; otherwise, false. The
        //     default is true.
        public bool HasInverse => !DoubleUtil.IsZero(Determinant);

        //
        // Summary:
        //     Gets or sets the value of the first row and first column of this System.Windows.Media.Matrix
        //     structure.
        //
        // Returns:
        //     The value of the first row and first column of this System.Windows.Media.Matrix.
        //     The default value is 1.
        public double M11
        {
            get
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    return 1.0;
                }

                return _m11;
            }
            set
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    SetMatrix(value, 0.0, 0.0, 1.0, 0.0, 0.0, MatrixTypes.TRANSFORM_IS_SCALING);
                    return;
                }

                _m11 = value;
                if (_type != MatrixTypes.TRANSFORM_IS_UNKNOWN)
                {
                    _type |= MatrixTypes.TRANSFORM_IS_SCALING;
                }
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the first row and second column of this System.Windows.Media.Matrix
        //     structure.
        //
        // Returns:
        //     The value of the first row and second column of this System.Windows.Media.Matrix.
        //     The default value is 0.
        public double M12
        {
            get
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    return 0.0;
                }

                return _m12;
            }
            set
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    SetMatrix(1.0, value, 0.0, 1.0, 0.0, 0.0, MatrixTypes.TRANSFORM_IS_UNKNOWN);
                    return;
                }

                _m12 = value;
                _type = MatrixTypes.TRANSFORM_IS_UNKNOWN;
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the second row and first column of this System.Windows.Media.Matrix
        //     structure.
        //
        // Returns:
        //     The value of the second row and first column of this System.Windows.Media.Matrix.
        //     The default value is 0.
        public double M21
        {
            get
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    return 0.0;
                }

                return _m21;
            }
            set
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    SetMatrix(1.0, 0.0, value, 1.0, 0.0, 0.0, MatrixTypes.TRANSFORM_IS_UNKNOWN);
                    return;
                }

                _m21 = value;
                _type = MatrixTypes.TRANSFORM_IS_UNKNOWN;
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the second row and second column of this System.Windows.Media.Matrix
        //     structure.
        //
        // Returns:
        //     The value of the second row and second column of this System.Windows.Media.Matrix
        //     structure. The default value is 1.
        public double M22
        {
            get
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    return 1.0;
                }

                return _m22;
            }
            set
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    SetMatrix(1.0, 0.0, 0.0, value, 0.0, 0.0, MatrixTypes.TRANSFORM_IS_SCALING);
                    return;
                }

                _m22 = value;
                if (_type != MatrixTypes.TRANSFORM_IS_UNKNOWN)
                {
                    _type |= MatrixTypes.TRANSFORM_IS_SCALING;
                }
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the third row and first column of this System.Windows.Media.Matrix
        //     structure.
        //
        // Returns:
        //     The value of the third row and first column of this System.Windows.Media.Matrix
        //     structure. The default value is 0.
        public double OffsetX
        {
            get
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    return 0.0;
                }

                return _offsetX;
            }
            set
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    SetMatrix(1.0, 0.0, 0.0, 1.0, value, 0.0, MatrixTypes.TRANSFORM_IS_TRANSLATION);
                    return;
                }

                _offsetX = value;
                if (_type != MatrixTypes.TRANSFORM_IS_UNKNOWN)
                {
                    _type |= MatrixTypes.TRANSFORM_IS_TRANSLATION;
                }
            }
        }

        //
        // Summary:
        //     Gets or sets the value of the third row and second column of this System.Windows.Media.Matrix
        //     structure.
        //
        // Returns:
        //     The value of the third row and second column of this System.Windows.Media.Matrix
        //     structure. The default value is 0.
        public double OffsetY
        {
            get
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    return 0.0;
                }

                return _offsetY;
            }
            set
            {
                if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
                {
                    SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, value, MatrixTypes.TRANSFORM_IS_TRANSLATION);
                    return;
                }

                _offsetY = value;
                if (_type != MatrixTypes.TRANSFORM_IS_UNKNOWN)
                {
                    _type |= MatrixTypes.TRANSFORM_IS_TRANSLATION;
                }
            }
        }

        private bool IsDistinguishedIdentity => _type == MatrixTypes.TRANSFORM_IS_IDENTITY;

        //
        // Summary:
        //     Initializes a new instance of the System.Windows.Media.Matrix structure.
        //
        // Parameters:
        //   m11:
        //     The new System.Windows.Media.Matrix structure's System.Windows.Media.Matrix.M11
        //     coefficient.
        //
        //   m12:
        //     The new System.Windows.Media.Matrix structure's System.Windows.Media.Matrix.M12
        //     coefficient.
        //
        //   m21:
        //     The new System.Windows.Media.Matrix structure's System.Windows.Media.Matrix.M21
        //     coefficient.
        //
        //   m22:
        //     The new System.Windows.Media.Matrix structure's System.Windows.Media.Matrix.M22
        //     coefficient.
        //
        //   offsetX:
        //     The new System.Windows.Media.Matrix structure's System.Windows.Media.Matrix.OffsetX
        //     coefficient.
        //
        //   offsetY:
        //     The new System.Windows.Media.Matrix structure's System.Windows.Media.Matrix.OffsetY
        //     coefficient.
        public Matrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY)
        {
            _m11 = m11;
            _m12 = m12;
            _m21 = m21;
            _m22 = m22;
            _offsetX = offsetX;
            _offsetY = offsetY;
            _type = MatrixTypes.TRANSFORM_IS_UNKNOWN;
            _padding = 0;
            DeriveMatrixType();
        }

        //
        // Summary:
        //     Changes this System.Windows.Media.Matrix structure into an identity matrix.
        public void SetIdentity()
        {
            _type = MatrixTypes.TRANSFORM_IS_IDENTITY;
        }

        //
        // Summary:
        //     Multiplies a System.Windows.Media.Matrix structure by another System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   trans1:
        //     The first System.Windows.Media.Matrix structure to multiply.
        //
        //   trans2:
        //     The second System.Windows.Media.Matrix structure to multiply.
        //
        // Returns:
        //     The result of multiplying trans1 by trans2.
        public static Matrix operator *(Matrix trans1, Matrix trans2)
        {
            MatrixUtil.MultiplyMatrix(ref trans1, ref trans2);
            return trans1;
        }

        //
        // Summary:
        //     Multiplies a System.Windows.Media.Matrix structure by another System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   trans1:
        //     The first System.Windows.Media.Matrix structure to multiply.
        //
        //   trans2:
        //     The second System.Windows.Media.Matrix structure to multiply.
        //
        // Returns:
        //     The result of multiplying trans1 by trans2.
        public static Matrix Multiply(Matrix trans1, Matrix trans2)
        {
            MatrixUtil.MultiplyMatrix(ref trans1, ref trans2);
            return trans1;
        }

        //
        // Summary:
        //     Appends the specified System.Windows.Media.Matrix structure to this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   matrix:
        //     The System.Windows.Media.Matrix structure to append to this System.Windows.Media.Matrix
        //     structure.
        public void Append(Matrix matrix)
        {
            this *= matrix;
        }

        //
        // Summary:
        //     Prepends the specified System.Windows.Media.Matrix structure onto this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   matrix:
        //     The System.Windows.Media.Matrix structure to prepend to this System.Windows.Media.Matrix
        //     structure.
        public void Prepend(Matrix matrix)
        {
            this = matrix * this;
        }

        //
        // Summary:
        //     Applies a rotation of the specified angle about the origin of this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   angle:
        //     The angle of rotation.
        public void Rotate(double angle)
        {
            angle %= 360.0;
            this *= CreateRotationRadians(angle * (Math.PI / 180.0));
        }

        //
        // Summary:
        //     Prepends a rotation of the specified angle to this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   angle:
        //     The angle of rotation to prepend.
        public void RotatePrepend(double angle)
        {
            angle %= 360.0;
            this = CreateRotationRadians(angle * (Math.PI / 180.0)) * this;
        }

        //
        // Summary:
        //     Rotates this matrix about the specified point.
        //
        // Parameters:
        //   angle:
        //     The angle, in degrees, by which to rotate this matrix.
        //
        //   centerX:
        //     The x-coordinate of the point about which to rotate this matrix.
        //
        //   centerY:
        //     The y-coordinate of the point about which to rotate this matrix.
        public void RotateAt(double angle, double centerX, double centerY)
        {
            angle %= 360.0;
            this *= CreateRotationRadians(angle * (Math.PI / 180.0), centerX, centerY);
        }

        //
        // Summary:
        //     Prepends a rotation of the specified angle at the specified point to this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   angle:
        //     The rotation angle, in degrees.
        //
        //   centerX:
        //     The x-coordinate of the rotation center.
        //
        //   centerY:
        //     The y-coordinate of the rotation center.
        public void RotateAtPrepend(double angle, double centerX, double centerY)
        {
            angle %= 360.0;
            this = CreateRotationRadians(angle * (Math.PI / 180.0), centerX, centerY) * this;
        }

        //
        // Summary:
        //     Appends the specified scale vector to this System.Windows.Media.Matrix structure.
        //
        // Parameters:
        //   scaleX:
        //     The value by which to scale this System.Windows.Media.Matrix along the x-axis.
        //
        //   scaleY:
        //     The value by which to scale this System.Windows.Media.Matrix along the y-axis.
        public void Scale(double scaleX, double scaleY)
        {
            this *= CreateScaling(scaleX, scaleY);
        }

        //
        // Summary:
        //     Prepends the specified scale vector to this System.Windows.Media.Matrix structure.
        //
        // Parameters:
        //   scaleX:
        //     The value by which to scale this System.Windows.Media.Matrix structure along
        //     the x-axis.
        //
        //   scaleY:
        //     The value by which to scale this System.Windows.Media.Matrix structure along
        //     the y-axis.
        public void ScalePrepend(double scaleX, double scaleY)
        {
            this = CreateScaling(scaleX, scaleY) * this;
        }

        //
        // Summary:
        //     Scales this System.Windows.Media.Matrix by the specified amount about the specified
        //     point.
        //
        // Parameters:
        //   scaleX:
        //     The amount by which to scale this System.Windows.Media.Matrix along the x-axis.
        //
        //   scaleY:
        //     The amount by which to scale this System.Windows.Media.Matrix along the y-axis.
        //
        //   centerX:
        //     The x-coordinate of the scale operation's center point.
        //
        //   centerY:
        //     The y-coordinate of the scale operation's center point.
        public void ScaleAt(double scaleX, double scaleY, double centerX, double centerY)
        {
            this *= CreateScaling(scaleX, scaleY, centerX, centerY);
        }

        //
        // Summary:
        //     Prepends the specified scale about the specified point of this System.Windows.Media.Matrix.
        //
        // Parameters:
        //   scaleX:
        //     The x-axis scale factor.
        //
        //   scaleY:
        //     The y-axis scale factor.
        //
        //   centerX:
        //     The x-coordinate of the point about which the scale operation is performed.
        //
        //   centerY:
        //     The y-coordinate of the point about which the scale operation is performed.
        public void ScaleAtPrepend(double scaleX, double scaleY, double centerX, double centerY)
        {
            this = CreateScaling(scaleX, scaleY, centerX, centerY) * this;
        }

        //
        // Summary:
        //     Appends a skew of the specified degrees in the x and y dimensions to this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   skewX:
        //     The angle in the x dimension by which to skew this System.Windows.Media.Matrix.
        //
        //   skewY:
        //     The angle in the y dimension by which to skew this System.Windows.Media.Matrix.
        public void Skew(double skewX, double skewY)
        {
            skewX %= 360.0;
            skewY %= 360.0;
            this *= CreateSkewRadians(skewX * (Math.PI / 180.0), skewY * (Math.PI / 180.0));
        }

        //
        // Summary:
        //     Prepends a skew of the specified degrees in the x and y dimensions to this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   skewX:
        //     The angle in the x dimension by which to skew this System.Windows.Media.Matrix.
        //
        //   skewY:
        //     The angle in the y dimension by which to skew this System.Windows.Media.Matrix.
        public void SkewPrepend(double skewX, double skewY)
        {
            skewX %= 360.0;
            skewY %= 360.0;
            this = CreateSkewRadians(skewX * (Math.PI / 180.0), skewY * (Math.PI / 180.0)) * this;
        }

        //
        // Summary:
        //     Appends a translation of the specified offsets to this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   offsetX:
        //     The amount to offset this System.Windows.Media.Matrix along the x-axis.
        //
        //   offsetY:
        //     The amount to offset this System.Windows.Media.Matrix along the y-axis.
        public void Translate(double offsetX, double offsetY)
        {
            if (_type == MatrixTypes.TRANSFORM_IS_IDENTITY)
            {
                SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, MatrixTypes.TRANSFORM_IS_TRANSLATION);
            }
            else if (_type == MatrixTypes.TRANSFORM_IS_UNKNOWN)
            {
                _offsetX += offsetX;
                _offsetY += offsetY;
            }
            else
            {
                _offsetX += offsetX;
                _offsetY += offsetY;
                _type |= MatrixTypes.TRANSFORM_IS_TRANSLATION;
            }
        }

        //
        // Summary:
        //     Prepends a translation of the specified offsets to this System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   offsetX:
        //     The amount to offset this System.Windows.Media.Matrix along the x-axis.
        //
        //   offsetY:
        //     The amount to offset this System.Windows.Media.Matrix along the y-axis.
        public void TranslatePrepend(double offsetX, double offsetY)
        {
            this = CreateTranslation(offsetX, offsetY) * this;
        }

        //
        // Summary:
        //     Transforms the specified point by the System.Windows.Media.Matrix and returns
        //     the result.
        //
        // Parameters:
        //   point:
        //     The point to transform.
        //
        // Returns:
        //     The result of transforming point by this System.Windows.Media.Matrix.
        public Point Transform(Point point)
        {
            Point result = point;
            MultiplyPoint(ref result._x, ref result._y);
            return result;
        }

        //
        // Summary:
        //     Transforms the specified points by this System.Windows.Media.Matrix.
        //
        // Parameters:
        //   points:
        //     The points to transform. The original points in the array are replaced by their
        //     transformed values.
        public void Transform(Point[] points)
        {
            if (points != null)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    MultiplyPoint(ref points[i]._x, ref points[i]._y);
                }
            }
        }

        //
        // Summary:
        //     Transforms the specified vector by this System.Windows.Media.Matrix.
        //
        // Parameters:
        //   vector:
        //     The vector to transform.
        //
        // Returns:
        //     The result of transforming vector by this System.Windows.Media.Matrix.
        public Vector Transform(Vector vector)
        {
            Vector result = vector;
            MultiplyVector(ref result._x, ref result._y);
            return result;
        }

        //
        // Summary:
        //     Transforms the specified vectors by this System.Windows.Media.Matrix.
        //
        // Parameters:
        //   vectors:
        //     The vectors to transform. The original vectors in the array are replaced by their
        //     transformed values.
        public void Transform(Vector[] vectors)
        {
            if (vectors != null)
            {
                for (int i = 0; i < vectors.Length; i++)
                {
                    MultiplyVector(ref vectors[i]._x, ref vectors[i]._y);
                }
            }
        }

        //
        // Summary:
        //     Inverts this System.Windows.Media.Matrix structure.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The System.Windows.Media.Matrix structure is not invertible.
        public void Invert()
        {
            double determinant = Determinant;
            if (DoubleUtil.IsZero(determinant))
            {
                throw new InvalidOperationException("Transform_NotInvertible");
            }

            switch (_type)
            {
                case MatrixTypes.TRANSFORM_IS_SCALING:
                    _m11 = 1.0 / _m11;
                    _m22 = 1.0 / _m22;
                    break;
                case MatrixTypes.TRANSFORM_IS_TRANSLATION:
                    _offsetX = 0.0 - _offsetX;
                    _offsetY = 0.0 - _offsetY;
                    break;
                case MatrixTypes.TRANSFORM_IS_TRANSLATION | MatrixTypes.TRANSFORM_IS_SCALING:
                    _m11 = 1.0 / _m11;
                    _m22 = 1.0 / _m22;
                    _offsetX = (0.0 - _offsetX) * _m11;
                    _offsetY = (0.0 - _offsetY) * _m22;
                    break;
                default:
                    {
                        double num = 1.0 / determinant;
                        SetMatrix(_m22 * num, (0.0 - _m12) * num, (0.0 - _m21) * num, _m11 * num, (_m21 * _offsetY - _offsetX * _m22) * num, (_offsetX * _m12 - _m11 * _offsetY) * num, MatrixTypes.TRANSFORM_IS_UNKNOWN);
                        break;
                    }
                case MatrixTypes.TRANSFORM_IS_IDENTITY:
                    break;
            }
        }

        internal void MultiplyVector(ref double x, ref double y)
        {
            switch (_type)
            {
                case MatrixTypes.TRANSFORM_IS_IDENTITY:
                case MatrixTypes.TRANSFORM_IS_TRANSLATION:
                    return;
                case MatrixTypes.TRANSFORM_IS_SCALING:
                case MatrixTypes.TRANSFORM_IS_TRANSLATION | MatrixTypes.TRANSFORM_IS_SCALING:
                    x *= _m11;
                    y *= _m22;
                    return;
            }

            double num = y * _m21;
            double num2 = x * _m12;
            x *= _m11;
            x += num;
            y *= _m22;
            y += num2;
        }

        internal void MultiplyPoint(ref double x, ref double y)
        {
            switch (_type)
            {
                case MatrixTypes.TRANSFORM_IS_IDENTITY:
                    break;
                case MatrixTypes.TRANSFORM_IS_TRANSLATION:
                    x += _offsetX;
                    y += _offsetY;
                    break;
                case MatrixTypes.TRANSFORM_IS_SCALING:
                    x *= _m11;
                    y *= _m22;
                    break;
                case MatrixTypes.TRANSFORM_IS_TRANSLATION | MatrixTypes.TRANSFORM_IS_SCALING:
                    x *= _m11;
                    x += _offsetX;
                    y *= _m22;
                    y += _offsetY;
                    break;
                default:
                    {
                        double num = y * _m21 + _offsetX;
                        double num2 = x * _m12 + _offsetY;
                        x *= _m11;
                        x += num;
                        y *= _m22;
                        y += num2;
                        break;
                    }
            }
        }

        internal static Matrix CreateRotationRadians(double angle)
        {
            return CreateRotationRadians(angle, 0.0, 0.0);
        }

        internal static Matrix CreateRotationRadians(double angle, double centerX, double centerY)
        {
            Matrix result = default;
            double num = Math.Sin(angle);
            double num2 = Math.Cos(angle);
            double offsetX = centerX * (1.0 - num2) + centerY * num;
            double offsetY = centerY * (1.0 - num2) - centerX * num;
            result.SetMatrix(num2, num, 0.0 - num, num2, offsetX, offsetY, MatrixTypes.TRANSFORM_IS_UNKNOWN);
            return result;
        }

        internal static Matrix CreateScaling(double scaleX, double scaleY, double centerX, double centerY)
        {
            Matrix result = default;
            result.SetMatrix(scaleX, 0.0, 0.0, scaleY, centerX - scaleX * centerX, centerY - scaleY * centerY, MatrixTypes.TRANSFORM_IS_TRANSLATION | MatrixTypes.TRANSFORM_IS_SCALING);
            return result;
        }

        internal static Matrix CreateScaling(double scaleX, double scaleY)
        {
            Matrix result = default;
            result.SetMatrix(scaleX, 0.0, 0.0, scaleY, 0.0, 0.0, MatrixTypes.TRANSFORM_IS_SCALING);
            return result;
        }

        internal static Matrix CreateSkewRadians(double skewX, double skewY)
        {
            Matrix result = default;
            result.SetMatrix(1.0, Math.Tan(skewY), Math.Tan(skewX), 1.0, 0.0, 0.0, MatrixTypes.TRANSFORM_IS_UNKNOWN);
            return result;
        }

        internal static Matrix CreateTranslation(double offsetX, double offsetY)
        {
            Matrix result = default;
            result.SetMatrix(1.0, 0.0, 0.0, 1.0, offsetX, offsetY, MatrixTypes.TRANSFORM_IS_TRANSLATION);
            return result;
        }

        private static Matrix CreateIdentity()
        {
            Matrix result = default;
            result.SetMatrix(1.0, 0.0, 0.0, 1.0, 0.0, 0.0, MatrixTypes.TRANSFORM_IS_IDENTITY);
            return result;
        }

        private void SetMatrix(double m11, double m12, double m21, double m22, double offsetX, double offsetY, MatrixTypes type)
        {
            _m11 = m11;
            _m12 = m12;
            _m21 = m21;
            _m22 = m22;
            _offsetX = offsetX;
            _offsetY = offsetY;
            _type = type;
        }

        private void DeriveMatrixType()
        {
            _type = MatrixTypes.TRANSFORM_IS_IDENTITY;
            if (_m21 != 0.0 || _m12 != 0.0)
            {
                _type = MatrixTypes.TRANSFORM_IS_UNKNOWN;
                return;
            }

            if (_m11 != 1.0 || _m22 != 1.0)
            {
                _type = MatrixTypes.TRANSFORM_IS_SCALING;
            }

            if (_offsetX != 0.0 || _offsetY != 0.0)
            {
                _type |= MatrixTypes.TRANSFORM_IS_TRANSLATION;
            }

            if ((_type & (MatrixTypes.TRANSFORM_IS_TRANSLATION | MatrixTypes.TRANSFORM_IS_SCALING)) == 0)
            {
                _type = MatrixTypes.TRANSFORM_IS_IDENTITY;
            }
        }

        [Conditional("DEBUG")]
        private void Debug_CheckType()
        {
            switch (_type)
            {
                case MatrixTypes.TRANSFORM_IS_IDENTITY:
                    break;
                case MatrixTypes.TRANSFORM_IS_UNKNOWN:
                    break;
                case MatrixTypes.TRANSFORM_IS_SCALING:
                    break;
                case MatrixTypes.TRANSFORM_IS_TRANSLATION:
                    break;
                case MatrixTypes.TRANSFORM_IS_TRANSLATION | MatrixTypes.TRANSFORM_IS_SCALING:
                    break;
            }
        }

        //
        // Summary:
        //     Determines whether the two specified System.Windows.Media.Matrix structures are
        //     identical.
        //
        // Parameters:
        //   matrix1:
        //     The first System.Windows.Media.Matrix structure to compare.
        //
        //   matrix2:
        //     The second System.Windows.Media.Matrix structure to compare.
        //
        // Returns:
        //     true if matrix1 and matrix2 are identical; otherwise, false.
        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
            {
                return matrix1.IsIdentity == matrix2.IsIdentity;
            }

            if (matrix1.M11 == matrix2.M11 && matrix1.M12 == matrix2.M12 && matrix1.M21 == matrix2.M21 && matrix1.M22 == matrix2.M22 && matrix1.OffsetX == matrix2.OffsetX)
            {
                return matrix1.OffsetY == matrix2.OffsetY;
            }

            return false;
        }

        //
        // Summary:
        //     Determines whether the two specified System.Windows.Media.Matrix structures are
        //     not identical.
        //
        // Parameters:
        //   matrix1:
        //     The first System.Windows.Media.Matrix structure to compare.
        //
        //   matrix2:
        //     The second System.Windows.Media.Matrix structure to compare.
        //
        // Returns:
        //     true if matrix1 and matrix2 are not identical; otherwise, false.
        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            return !(matrix1 == matrix2);
        }

        //
        // Summary:
        //     Determines whether the two specified System.Windows.Media.Matrix structures are
        //     identical.
        //
        // Parameters:
        //   matrix1:
        //     The first System.Windows.Media.Matrix structure to compare.
        //
        //   matrix2:
        //     The second System.Windows.Media.Matrix structure to compare.
        //
        // Returns:
        //     true if matrix1 and matrix2 are identical; otherwise, false.
        public static bool Equals(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.IsDistinguishedIdentity || matrix2.IsDistinguishedIdentity)
            {
                return matrix1.IsIdentity == matrix2.IsIdentity;
            }

            if (matrix1.M11.Equals(matrix2.M11) && matrix1.M12.Equals(matrix2.M12) && matrix1.M21.Equals(matrix2.M21) && matrix1.M22.Equals(matrix2.M22) && matrix1.OffsetX.Equals(matrix2.OffsetX))
            {
                return matrix1.OffsetY.Equals(matrix2.OffsetY);
            }

            return false;
        }

        //
        // Summary:
        //     Determines whether the specified System.Object is a System.Windows.Media.Matrix
        //     structure that is identical to this System.Windows.Media.Matrix.
        //
        // Parameters:
        //   o:
        //     The System.Object to compare.
        //
        // Returns:
        //     true if o is a System.Windows.Media.Matrix structure that is identical to this
        //     System.Windows.Media.Matrix structure; otherwise, false.
        public override bool Equals(object o)
        {
            if (o == null || !(o is Matrix))
            {
                return false;
            }

            Matrix matrix = (Matrix)o;
            return Equals(this, matrix);
        }

        //
        // Summary:
        //     Determines whether the specified System.Windows.Media.Matrix structure is identical
        //     to this instance.
        //
        // Parameters:
        //   value:
        //     The instance of System.Windows.Media.Matrix to compare to this instance.
        //
        // Returns:
        //     true if instances are equal; otherwise, false.
        public bool Equals(Matrix value)
        {
            return Equals(this, value);
        }

        //
        // Summary:
        //     Returns the hash code for this System.Windows.Media.Matrix structure.
        //
        // Returns:
        //     The hash code for this instance.
        public override int GetHashCode()
        {
            if (IsDistinguishedIdentity)
            {
                return 0;
            }

            return M11.GetHashCode() ^ M12.GetHashCode() ^ M21.GetHashCode() ^ M22.GetHashCode() ^ OffsetX.GetHashCode() ^ OffsetY.GetHashCode();
        }

        //
        // Summary:
        //     Converts a System.String representation of a matrix into the equivalent System.Windows.Media.Matrix
        //     structure.
        //
        // Parameters:
        //   source:
        //     The System.String representation of the matrix.
        //
        // Returns:
        //     The equivalent System.Windows.Media.Matrix structure.
        /*public static Matrix Parse(string source)
        {
            IFormatProvider invariantEnglishUS = TypeConverterHelper.InvariantEnglishUS;
            TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantEnglishUS);
            string text = tokenizerHelper.NextTokenRequired();
            Matrix result = ((!(text == "Identity")) ? new Matrix(Convert.ToDouble(text, invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantEnglishUS)) : Identity);
            tokenizerHelper.LastTokenRequired();
            return result;
        }*/

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Matrix structure.
        //
        // Returns:
        //     A System.String containing the System.Windows.Media.Matrix.M11, System.Windows.Media.Matrix.M12,
        //     System.Windows.Media.Matrix.M21, System.Windows.Media.Matrix.M22, System.Windows.Media.Matrix.OffsetX,
        //     and System.Windows.Media.Matrix.OffsetY values of this System.Windows.Media.Matrix.
        public override string ToString()
        {
            return ConvertToString(null, null);
        }

        //
        // Summary:
        //     Creates a System.String representation of this System.Windows.Media.Matrix structure
        //     with culture-specific formatting information.
        //
        // Parameters:
        //   provider:
        //     The culture-specific formatting information.
        //
        // Returns:
        //     A System.String containing the System.Windows.Media.Matrix.M11, System.Windows.Media.Matrix.M12,
        //     System.Windows.Media.Matrix.M21, System.Windows.Media.Matrix.M22, System.Windows.Media.Matrix.OffsetX,
        //     and System.Windows.Media.Matrix.OffsetY values of this System.Windows.Media.Matrix.
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
        //     The value of the current instance in the specified format.
        string IFormattable.ToString(string format, IFormatProvider provider)
        {
            return ConvertToString(format, provider);
        }

        internal string ConvertToString(string format, IFormatProvider provider)
        {
            if (IsIdentity)
            {
                return "Identity";
            }

            char numericListSeparator = ':'; // TokenizerHelper.GetNumericListSeparator(provider);
            return string.Format(provider, "{1:" + format + "}{0}{2:" + format + "}{0}{3:" + format + "}{0}{4:" + format + "}{0}{5:" + format + "}{0}{6:" + format + "}", numericListSeparator, _m11, _m12, _m21, _m22, _offsetX, _offsetY);
        }
    }

    internal enum MatrixTypes
    {
        TRANSFORM_IS_IDENTITY = 0x0,
        TRANSFORM_IS_TRANSLATION = 0x1,
        TRANSFORM_IS_SCALING = 0x2,
        TRANSFORM_IS_UNKNOWN = 0x4
    }
}
