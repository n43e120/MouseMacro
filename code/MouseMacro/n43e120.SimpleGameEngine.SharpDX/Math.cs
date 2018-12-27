//using SharpDX;
using System.Drawing;

namespace n43e120.Maths
{
    public static class MatrixHelper
    {
        public static unsafe ref PointF ConvertVector2ToPointF(ref SharpDX.Vector2 p)
        {
            fixed (SharpDX.Vector2* ptrP = &p)
            {
                var ptrVector = (PointF*)ptrP;
                return ref (*ptrVector);
            }
        }
        public static unsafe ref SharpDX.Vector2 ConvertPointFToVector2(ref PointF p)
        {
            fixed (PointF* ptrP = &p)
            {
                var ptrVector = (SharpDX.Vector2*)ptrP;
                return ref (*ptrVector);
            }
        }
        public static System.Drawing.Drawing2D.Matrix ConvertMatrix3x2ToMatrix(ref SharpDX.Matrix3x2 m)
        {
            return new System.Drawing.Drawing2D.Matrix(m.M11, m.M12, m.M21, m.M22, m.M31, m.M32);
        }
        public static SharpDX.Matrix3x2 ConvertMatrixToMatrix3x2(System.Drawing.Drawing2D.Matrix m)
        {
            return new SharpDX.Matrix3x2(m.Elements);
        }
    }
}