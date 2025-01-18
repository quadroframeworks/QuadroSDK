using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.Geo.Numerics
{
    internal class Num3DUtil
    {
        internal static float RadiansToDegrees(float radians)
        {
            return radians * (180.0f / Convert.ToSingle(Math.PI));
        }

        internal static float DegreesToRadians(float degrees)
        {
            return degrees * (Convert.ToSingle(Math.PI) / 180.0f);
        }

    }
}
