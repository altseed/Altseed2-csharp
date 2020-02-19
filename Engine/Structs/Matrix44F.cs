using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Altseed
{
    /// <summary>
    /// <see cref="float"/>型の4x4行列表す構造体
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix44F
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 4 * 4)]
        public float[,] Values;

        public void SetIdentity()
        {
            if (Values == null)
                Values = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Values[i, j] = 0.0f;

            Values[0, 0] = 1.0f;
            Values[1, 1] = 1.0f;
            Values[2, 2] = 1.0f;
            Values[3, 3] = 1.0f;
        }

        public void SetTranslation(float x, float y, float z)
        {
            SetIdentity();
            Values[0, 3] = x;
            Values[1, 3] = y;
            Values[2, 3] = z;
        }
    }
}
