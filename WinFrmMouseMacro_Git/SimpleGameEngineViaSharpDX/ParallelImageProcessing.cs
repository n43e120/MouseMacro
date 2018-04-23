using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SimpleGameEngineViaSharpDX
{
    /// <summary>
    /// https://www.cnblogs.com/xzbrillia/archive/2012/07/22/2603638.html
    /// </summary>
    class ParallelImageProcessing
    {
        private static unsafe Image GrayByParallelForEach(Image image)
        {
            var bmp = (Bitmap)image;

            int height = bmp.Height;
            int width = bmp.Width;

            var data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var startPtr = (PixelColor*)data.Scan0.ToPointer();
            ParallelForEach(startPtr, width, height);
            bmp.UnlockBits(data);

            return bmp;
        }

        private static unsafe void ParallelForEach(PixelColor* startPtr, int width, int height)
        {
            Parallel.ForEach(Partitioner.Create(0, height), (h) =>
            {
                var ptr = startPtr + h.Item1 * width;

                for (int y = h.Item1; y < h.Item2; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var c = *ptr;
                        var gray = ((c.Red * 38 + c.Green * 75 + c.Blue * 15) >> 7);
                        (*ptr).Green = (*ptr).Red = (*ptr).Blue = (byte)gray;

                        ptr++;
                    }
                }
            });
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct PixelColor
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;

    }
}
