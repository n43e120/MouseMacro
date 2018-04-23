using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormMouseMarco
{
    public class ScreenCapturer
    {
        public static void Capture(Graphics gc, ref Point upperLeftSrcRegion, ref Point upperLeftDestRegion, ref Size blockRegionSize)
        {
            gc.CopyFromScreen(upperLeftSrcRegion, upperLeftDestRegion, blockRegionSize);
        }
        public static void Capture(Image imgDest, ref Point upperLeftSrcRegion, ref Size blockRegionSize)
        {
            using (var gc = Graphics.FromImage(imgDest))
            {
                gc.CopyFromScreen(upperLeftSrcRegion, new Point(0, 0), blockRegionSize);
            }
        }
        public static Image Capture(ref Point upperLeftRegion, ref Size blockRegionSize)
        {
            Image img = new Bitmap(blockRegionSize.Width, blockRegionSize.Height);
            Graphics gc = Graphics.FromImage(img);
            gc.CopyFromScreen(upperLeftRegion, new Point(0, 0), blockRegionSize);
            return img;
        }
        public static Image Capture()
        {
            Size size = Screen.PrimaryScreen.Bounds.Size;
            Point pos = new Point(0, 0);
            return Capture(ref pos, ref size);
        }
    }
}
