using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Matrix3DDto : StorableGuid
    {
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M13 { get; set; }
        public double M14 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }
        public double M23 { get; set; }
        public double M24 { get; set; }
        public double M31 { get; set; }
        public double M32 { get; set; }
        public double M33 { get; set; }
        public double M34 { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public double OffsetZ { get; set; }
        public double M44 { get; set; }

        public static Matrix3DDto FromMatrix3D(Matrix3D matrix)
        {
            var result = new Matrix3DDto
            {
                M11 = matrix.M11,
                M12 = matrix.M12,
                M13 = matrix.M13,
                M14 = matrix.M14,
                M21 = matrix.M21,
                M22 = matrix.M22,
                M23 = matrix.M23,
                M24 = matrix.M24,
                M31 = matrix.M31,
                M32 = matrix.M32,
                M33 = matrix.M33,
                M34 = matrix.M34,
                OffsetX = matrix.OffsetX,
                OffsetY = matrix.OffsetY,
                OffsetZ = matrix.OffsetZ,
                M44 = matrix.M44
            };
            return result;
        }

        public Matrix3D ToMatrix3D()
        {
            var result = new Matrix3D(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, OffsetX, OffsetY, OffsetZ, M44);
            return result;
        }
    }
}
