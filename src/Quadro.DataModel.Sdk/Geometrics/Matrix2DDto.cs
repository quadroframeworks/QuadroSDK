using CPBase.Geo.Media;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Geometrics
{
	public class Matrix2DDto : StorableGuid
    {
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }

        public static Matrix2DDto FromMatrix2D(Matrix matrix)
        {
            var result = new Matrix2DDto
            {
                M11 = matrix.M11,
                M12 = matrix.M12,
                M21 = matrix.M21,
                M22 = matrix.M22,
                OffsetX = matrix.OffsetX,
                OffsetY = matrix.OffsetY,
            };
            return result;
        }

        public Matrix ToMatrix2D()
        {
            var result = new Matrix(M11, M12, M21, M22, OffsetX, OffsetY);
            return result;
        }
    }
}
