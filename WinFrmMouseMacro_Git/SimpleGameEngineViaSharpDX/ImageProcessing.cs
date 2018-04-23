using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace n43e120.ImageProcessing
{
    public static class ImageProcess
    {
        public static Bitmap SubImage(Bitmap img, ref Rectangle rect)
        {
            return img.Clone(rect, System.Drawing.Imaging.PixelFormat.DontCare);
        }
        public static byte[] ToArray(Bitmap img)
        {
            using (var mems = new System.IO.MemoryStream())
            {
                img.Save(mems, ImageFormat.Png);
                return mems.ToArray();
            }
        }

        /// <summary>
        /// 32->1  https://bbs.csdn.net/topics/392086010?page=1
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap BitmapTo1Bpp(Bitmap img, float threshold = 0.5f)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap dstBitmap = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData dstBmData = dstBitmap.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            for (int y = 0; y < h; y++)
            {
                byte[] scan = new byte[(w + 7) / 8];
                for (int x = 0; x < w; x++)
                {
                    Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= threshold) scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                System.Runtime.InteropServices.Marshal.Copy(scan, 0, (IntPtr)((int)dstBmData.Scan0 + dstBmData.Stride * y), scan.Length);
            }
            dstBitmap.UnlockBits(dstBmData);
            return dstBitmap;
        }
        public static Bitmap BitmapTo1Bpp(Bitmap img, Rectangle rectSrc, float threshold = 0.5f)
        {
            var w = rectSrc.Width;
            var h = rectSrc.Height;
            Bitmap dstBitmap = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData dstBmData = dstBitmap.LockBits(rectSrc, ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            for (int y = 0; y < h; y++)
            {
                byte[] scan = new byte[(w + 7) / 8];
                for (int x = 0; x < w; x++)
                {
                    Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= threshold) scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                System.Runtime.InteropServices.Marshal.Copy(scan, 0, (IntPtr)((int)dstBmData.Scan0 + dstBmData.Stride * y), scan.Length);
            }
            dstBitmap.UnlockBits(dstBmData);
            return dstBitmap;
        }
        //public static void BitmapTo1Bpp(Bitmap imgSrc, ref Rectangle rectSrc, Bitmap dstBitmapBW, ref Point locDst, System.Drawing.Drawing2D.Matrix m)
        //{
        //    using (var g = Graphics.FromImage(dstBitmapBW))
        //    {
        //        g.Transform = m;
        //        g.DrawImage(imgSrc, locDst.X, locDst.Y, rectSrc, GraphicsUnit.Pixel);
        //    }
        //}
        public static Bitmap BitmapTo1Bpp_InvertBlackWhite(Bitmap img, float threshold = 0.5f)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap dstBitmap = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData dstBmData = dstBitmap.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            for (int y = 0; y < h; y++)
            {
                byte[] scan = new byte[(w + 7) / 8];
                for (int x = 0; x < w; x++)
                {
                    Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() < threshold) scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                System.Runtime.InteropServices.Marshal.Copy(scan, 0, (IntPtr)((int)dstBmData.Scan0 + dstBmData.Stride * y), scan.Length);
            }
            dstBitmap.UnlockBits(dstBmData);
            return dstBitmap;
        }
        ///<summary>
        /// Set pallete of the image to grayscale
        ///</summary>
        public static void SetBlackAndWhitePalette(Bitmap srcImg)
        {
            // check pixel format
            if (srcImg.PixelFormat != PixelFormat.Format1bppIndexed)
                throw new ArgumentException();

            // get palette
            ColorPalette cp = srcImg.Palette;

            // init palette
            for (int i = 0; i < 2; i++)
            {
                cp.Entries[i] = Color.FromArgb(i * 255, i * 255, i * 255);
            }

            srcImg.Palette = cp;
        }
        ///<summary>
        /// Create and initialize grayscale image
        ///</summary>
        public static Bitmap CreateBlackAndWhiteImage(int width, int height)
        {
            // create new image
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format1bppIndexed);

            // set palette to grayscale
            SetBlackAndWhitePalette(bmp);

            // return new image
            return bmp;
        }
        public static Bitmap RGB2BackWhite(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);
            BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Bitmap dstBitmap = CreateBlackAndWhiteImage(wide, height);
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            System.IntPtr srcScan = srcBmData.Scan0;
            System.IntPtr dstScan = dstBmData.Scan0;
            unsafe //启动不安全代码
            {
                byte* srcP = (byte*)(void*)srcScan;
                byte* dstP = (byte*)(void*)dstScan;
                int srcOffset = srcBmData.Stride - wide * 3;
                int dstOffset = dstBmData.Stride - wide;
                byte red, green, blue;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < wide; x++, srcP += 3, dstP++)
                    {
                        blue = srcP[0];
                        green = srcP[1];
                        red = srcP[2];
                        var brightness = (.299 * red + .587 * green + .114 * blue);
                        if (brightness > 0.5d)
                        {
                            *dstP = 1;
                        }
                        else
                        {
                            *dstP = 0;
                        }
                        //* dstP = (byte)(.299 * red + .587 * green + .114 * blue);
                    }
                    srcP += srcOffset;
                    dstP += dstOffset;
                }
            }
            dstBitmap.UnlockBits(dstBmData);
            srcBitmap.UnlockBits(srcBmData);
            return dstBitmap;
        }
        ///<summary>
        /// Set pallete of the image to grayscale
        ///</summary>
        public static void SetGrayscalePalette(Bitmap srcImg)
        {
            // check pixel format
            if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new ArgumentException();

            // get palette
            ColorPalette cp = srcImg.Palette;

            // init palette
            for (int i = 0; i < 256; i++)
            {
                cp.Entries[i] = Color.FromArgb(i, i, i);
            }

            srcImg.Palette = cp;
        }
        ///<summary>
        /// Create and initialize grayscale image
        ///</summary>
        public static Bitmap CreateGrayscaleImage(int width, int height)
        {
            // create new image
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

            // set palette to grayscale
            SetGrayscalePalette(bmp);

            // return new image
            return bmp;
        }
        /// <summary>
        /// https://www.cnblogs.com/GmrBrian/p/6830106.html
        /// </summary>
        /// <param name="srcBitmap"></param>
        /// <returns></returns>
        public static Bitmap RGB2Gray(Bitmap srcBitmap)
        {
            int wide = srcBitmap.Width;
            int height = srcBitmap.Height;
            Rectangle rect = new Rectangle(0, 0, wide, height);
            BitmapData srcBmData = srcBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Bitmap dstBitmap = CreateGrayscaleImage(wide, height);
            BitmapData dstBmData = dstBitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            System.IntPtr srcScan = srcBmData.Scan0;
            System.IntPtr dstScan = dstBmData.Scan0;
            unsafe //启动不安全代码
            {
                byte* srcP = (byte*)(void*)srcScan;
                byte* dstP = (byte*)(void*)dstScan;
                int srcOffset = srcBmData.Stride - wide * 3;
                int dstOffset = dstBmData.Stride - wide;
                byte red, green, blue;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < wide; x++, srcP += 3, dstP++)
                    {
                        blue = srcP[0];
                        green = srcP[1];
                        red = srcP[2];
                        *dstP = (byte)(.299 * red + .587 * green + .114 * blue);
                    }
                    srcP += srcOffset;
                    dstP += dstOffset;
                }
            }
            srcBitmap.UnlockBits(srcBmData);
            dstBitmap.UnlockBits(dstBmData);
            return dstBitmap;
        }
    }
}
