//using SharpDX;
using n43e120.ImageProcessing;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

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
namespace n43e120.AI.SquadGame
{
    /// <summary>
    /// https://stackoverflow.com/questions/1897555/what-is-the-equivalent-of-memset-in-c
    /// </summary>
    public static class Util
    {
        static Util()
        {
            var dynamicMethod = new DynamicMethod("Memset", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard,
                null, new[] { typeof(IntPtr), typeof(byte), typeof(int) }, typeof(Util), true);

            var generator = dynamicMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Initblk);
            generator.Emit(OpCodes.Ret);

            MemsetDelegate = (Action<IntPtr, byte, int>)dynamicMethod.CreateDelegate(typeof(Action<IntPtr, byte, int>));
        }

        public static void Memset(byte[] array, byte what, int length)
        {
            var gcHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
            MemsetDelegate(gcHandle.AddrOfPinnedObject(), what, length);
            gcHandle.Free();
        }

        public static void ForMemset(byte[] array, byte what, int length)
        {
            for (var i = 0; i < length; i++)
            {
                array[i] = what;
            }
        }

        private static Action<IntPtr, byte, int> MemsetDelegate;
        public static void ZeroMemory(IntPtr adr, int len)
        {
            MemsetDelegate(adr, 0, len);
        }
        public unsafe static void ZeroMemory(void* adr, int len)
        {
            MemsetDelegate((IntPtr)adr, 0, len);
        }
    }
    /// <summary>
    /// only support screen resolution 1920x1080
    /// </summary>
    public class SquadScreen1920x1080
    {
        const int MARGIN_TOP_PRESUMED_ENTIRE_CONTENT_AREA = 8;
        const int MARGIN_PRESUMED_MAP_TAB = 4; //top and bottom left

        const int MARGIN_TOP_MAP_NAME_TAG = 52;//when 1920x1080
        const int MARGIN_BOTTOM_MAP_TAB = 84;//when 1920x1080

        const int HEIGHT_MAP_NAME_TAG = 40;
        const int MARGIN_BETWEEN_MAP_NAME_TAG_AND_MAP_TAB = 4;

        const int HEIGHT_MAP_TAB = 900;
        const int WIDTH_MAP_TAB = 899;//=45+800+54

        public const int SIZE_MAPOnScreen = 800; //map size 800x800
        const int HEIGHT_MAP_MARGIN_TOP = 52;
        const int HEIGHT_MAP_MARGIN_BOTTOM = 48;
        const int HEIGHT_MAP_MARGIN_LEFT = 45;
        const int HEIGHT_MAP_MARGIN_RIGHT = 54;

        const int HEIGHT_BOTTOM_BUTTON = 40; //the CLOSE button at bottom of screen

        const int MARGIN_LEFT_TEAM_TAB = 25;
        public int Width { get; } = 1920;
        public int Height { get; } = 1080;
        public SquadScreen1920x1080()
        {
            calcRegions();
        }
        private void calcRegions()
        {
            //return new Rectangle(1066, 148, 800, 800); //1920x1080
            var x = this.Width - WIDTH_MAP_TAB + HEIGHT_MAP_MARGIN_LEFT;//1920 - 899 + 45=1066                                                                       
            var y = this.Height / 2 - SIZE_MAPOnScreen / 2 + MARGIN_TOP_PRESUMED_ENTIRE_CONTENT_AREA; //var y = 148; //when 1920x1080
            region_MapViewPortOnScreen = new Rectangle(x, y, SIZE_MAPOnScreen, SIZE_MAPOnScreen);
            region_MapViewPortOnScreenF = region_MapViewPortOnScreen;

            x = 1805; //1066 + 800 - 60 = 1806, all rulers ended at 1805
            region_Ruler300 = new Rectangle(x, 913, 0, 1);
            region_Ruler100 = new Rectangle(x, 898, 0, 1);
            region_Ruler30 = new Rectangle(x, 883, 0, 1);


            region_MAP_ABC = new Rectangle(region_MapViewPortOnScreen.X, 112, region_MapViewPortOnScreen.Width, 13); //height = 124-112+1=13
            region_MAP_123 = new Rectangle(1036, region_MapViewPortOnScreen.Y, 30, region_MapViewPortOnScreen.Height); //height of each character is 12x13 pixels 
        }
        //public SquadOCRScreen(int w, int h)
        //{
        //    this.Width = w;
        //    this.Height = h;
        //}


        private RectangleF region_MapViewPortOnScreenF; public ref RectangleF Region_MapViewRegionOnScreenF => ref region_MapViewPortOnScreenF;
        private Rectangle region_MapViewPortOnScreen; public ref Rectangle Region_MapViewOnScreen => ref region_MapViewPortOnScreen;
        private Rectangle region_Ruler300; public ref Rectangle Region_Ruler300 => ref region_Ruler300;
        private Rectangle region_Ruler100; public ref Rectangle Region_Ruler100 => ref region_Ruler100;
        private Rectangle region_Ruler30; public ref Rectangle Region_Ruler30 => ref region_Ruler30;
        public Color Color_Ruler300 { get; } = Color.Black;
        public Color Color_Ruler100 { get; } = Color.Black;
        public Color Color_Ruler30 { get; } = Color.White;
        public const float Len_Ruler300_World = 300;
        public const float Len_Ruler100_World = 100;
        public const float Len_Ruler30_World = 30;
        private Rectangle region_MAP_ABC; public ref Rectangle Region_MAP_ABC => ref region_MAP_ABC;
        private Rectangle region_MAP_123; public ref Rectangle Region_MAP_123 => ref region_MAP_123;
    }

    /// <summary>
    /// do OCR hard-codedly, brutally
    /// </summary>
    public unsafe class MapRecognition_Brutally_Hardcoded : IDisposable
    {
        SquadScreen1920x1080 screen = new SquadScreen1920x1080();

        const int LEN_ALPHABET = 11; //a-k, abcdefghijk,  1 to 11
        const int HEIGHT_CHAR = 13;
        const int WIDTH_CHAR_123 = 11;
        const int WIDTH_CHAR_LETTER = 12;


        System.Drawing.Drawing2D.Matrix mIdentity;
        System.Drawing.Drawing2D.Matrix mABC;

        Bitmap bBuffer;
        System.IntPtr pBuffer;
        int len_buffer;
        int* Scan0_Letters;
        int len_buffer_letters;
        int* Scan0_Digitals;
        int len_buffer_digitals;
        int* Scan0_Target;
        int len_buffer_target;

        System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<int>> dictScanlines_ABC = new System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<int>>();
        System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<int>> dictScanlines_123 = new System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<int>>();
        public MapRecognition_Brutally_Hardcoded()
        {
            len_buffer_letters = sizeof(int) * WIDTH_CHAR_LETTER * LEN_ALPHABET;
            len_buffer_digitals = sizeof(int) * HEIGHT_CHAR * LEN_ALPHABET;
            len_buffer_target = sizeof(int) * SquadScreen1920x1080.SIZE_MAPOnScreen;
            len_buffer = len_buffer_letters + len_buffer_digitals + len_buffer_target;

            pBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(len_buffer);
            Util.ZeroMemory(pBuffer, len_buffer);
            bBuffer = new Bitmap(32, 800);

            Scan0_Target = (int*)pBuffer; //(int*)(pBuffer + len_buffer_letters + len_buffer_digitals);
            Scan0_Letters = Scan0_Target + len_buffer_target;
            Scan0_Digitals = Scan0_Letters + len_buffer_letters;//(int*)(pBuffer + len_buffer_letters);

            mIdentity = new System.Drawing.Drawing2D.Matrix();
            mABC = new System.Drawing.Drawing2D.Matrix(0f, 1f, 1f, 0f, 0f, 0f);//RotationMatrix[90 Degree].ScalingMatrix[{-1, 1}]= {{0, -1}, {-1, 0}}

            RegisterABC_Characters();
            Register123_Characters();
        }
        public static void CopyBitmapPixelToint32ScanVerticalStrip(Bitmap imgSrc, Rectangle rectSrc, int* scan0Dst)
        {
            var h = rectSrc.Height;
            var w = rectSrc.Width;
            for (int i = 0; i < h; i++)
            {
                var scan = 0;
                for (int j = 0; j < w; j++)
                {
                    var c = imgSrc.GetPixel(j, i);
                    if (c.GetBrightness() > 0.5f)
                    {
                        scan |= 1 << j;
                    }
                }
                *(scan0Dst + i) = scan;
            }
        }
        static unsafe void generalizedRegister(int* Scan0, int lenScanline, System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<int>> dict)
        {
            for (int y = 0; y < lenScanline; y++)
            {
                var ptrScan = Scan0 + y;
                int scan = *ptrScan;
                if (scan != 0)
                {
                    System.Collections.Generic.HashSet<int> hs;
                    if (dict.ContainsKey(scan))
                    {
                        hs = dict[scan];
                    }
                    else
                    {
                        hs = new System.Collections.Generic.HashSet<int>();
                        dict.Add(scan, hs);
                    }
                    hs.Add(y);
                }
            }
        }
        public void RegisterABC_Characters()
        {
            var img_ABC = new Bitmap(@"C:\Users\123aser\Pictures\SquadMapCharABC12x13.png");

            var w = HEIGHT_CHAR;// 32;
            var h = WIDTH_CHAR_LETTER * LEN_ALPHABET;
            var img = bBuffer;// new Bitmap(w, h);
            using (var g = Graphics.FromImage(img))
            {
                g.Clear(Color.Black);
                g.Transform = mABC;
                g.DrawImageUnscaled(img_ABC, 0, 0);
            }
            CopyBitmapPixelToint32ScanVerticalStrip(img, new Rectangle(0, 0, w, h), Scan0_Letters);

            generalizedRegister(
                Scan0_Letters,
                h,
                dictScanlines_ABC);
        }
        public void Register123_Characters()
        {
            var img_123 = new Bitmap(@"C:\Users\123aser\Pictures\SquadMapCharNum11x13.png");
            var w = WIDTH_CHAR_123;// 32;
            var h = HEIGHT_CHAR * LEN_ALPHABET;
            var img = bBuffer;

            var rectEachChar = new Rectangle(0, 0, WIDTH_CHAR_123, HEIGHT_CHAR);
            using (var g = Graphics.FromImage(img))
            {
                g.Clear(Color.Black);
                for (int i = 0; i < 10; i++) //0, 1 to 9
                {
                    var y = i * HEIGHT_CHAR;
                    rectEachChar.X = i * WIDTH_CHAR_123;
                    g.DrawImage(img_123, 0, y, rectEachChar, GraphicsUnit.Pixel);
                }
                for (int i = 10; i < 12; i++)//10,11
                {
                    var yDst = i * HEIGHT_CHAR;
                    rectEachChar.X = 1 * WIDTH_CHAR_123;
                    g.DrawImage(img_123, 0, yDst, rectEachChar, GraphicsUnit.Pixel);

                    var xDst = WIDTH_CHAR_123;
                    rectEachChar.X = (i / 10) * WIDTH_CHAR_123;
                    g.DrawImage(img_123, xDst, yDst, rectEachChar, GraphicsUnit.Pixel);
                }
            }

            CopyBitmapPixelToint32ScanVerticalStrip(img, new Rectangle(0, 0, w, h), Scan0_Digitals);

            generalizedRegister(
                Scan0_Digitals,
                h,
                dictScanlines_123);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgScreenCapture"></param>
        /// <returns>return how many meters equals 1 pixel on the satellite map, 
        /// return 0 means failed.
        /// </returns>
        public float Recogninze_Map_Scale_ByRulers(Bitmap imgScreenCapture)
        {
            int x, y;
            Color c;
            Color colorMATCH;
            int i = 0;

            x = screen.Region_Ruler300.X;
            y = screen.Region_Ruler300.Y;
            colorMATCH = screen.Color_Ruler300;
            for (i = 0; i < SquadScreen1920x1080.SIZE_MAPOnScreen; i++)
            {
                c = imgScreenCapture.GetPixel(x - i, y);
                if (c == colorMATCH)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (i < 1)
            {
                //300m-ruler will disappear when map viewport is too small to show entire length of it.
                //continue on check ruler 100m to find the map scale
            }
            else
            {
                return SquadScreen1920x1080.Len_Ruler300_World / (i - 1);
            }
            //x = region_Ruler100.X;
            y = screen.Region_Ruler100.Y;
            //colorMATCH = Color_Ruler100;
            for (i = 0; i < SquadScreen1920x1080.SIZE_MAPOnScreen; i++)
            {
                c = imgScreenCapture.GetPixel(x - i, y);
                if (c == colorMATCH)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (i < 1)
            {
                //throw new Exception("recognize failed");
            }
            else
            {
                return SquadScreen1920x1080.Len_Ruler100_World / (i - 1);
            }
            return 0f;
        }
        public const float mThresholdConsiderBlacken = 0.3f;
        public Point Recogninze_GridCrosspointOnMap(Bitmap imgScreenCapture)
        {
            var ret = new Point(-1, -1);
            {
                var po = screen.Region_MapViewOnScreen.Location;
                for (int i = 0; i < 800; i++)
                {
                    var p = imgScreenCapture.GetPixel(po.X + i, po.Y);
                    var brightness = p.GetBrightness();
                    if (brightness < mThresholdConsiderBlacken)
                    {
                        ret.X = i;
                        break;
                    }
                }
                for (int i = 0; i < 800; i++)
                {
                    var p = imgScreenCapture.GetPixel(po.X, po.Y + i);
                    var brightness = p.GetBrightness();
                    if (brightness < mThresholdConsiderBlacken)
                    {
                        ret.Y = i;
                        break;
                    }
                }
            }
            return ret;
        }
        private static bool ConfirmMatch(int* Scan0, int posOnTarget, int* ptrCharTypeTemplate, int posMatchOnTypeTemplate, int scanlineForEachChar)
        {
            var modRemainderOnTypeTemplate = posMatchOnTypeTemplate % scanlineForEachChar;

            var PosStartCharOnTypeTemplate = posMatchOnTypeTemplate - modRemainderOnTypeTemplate;
            var PosStartNextCharOnTypeTemplate = PosStartCharOnTypeTemplate + scanlineForEachChar;

            var PosStartCharOnTarget = posOnTarget - modRemainderOnTypeTemplate;
            //var PosEndCharOnTarget = PosStartCharOnTarget + scanlineForEachChar;

            for (int i = PosStartCharOnTarget, j = PosStartCharOnTypeTemplate; j < PosStartNextCharOnTypeTemplate; i++, j++)
            {
                if (*(Scan0 + i) == *(ptrCharTypeTemplate + j))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        static void GeneralizedScanLineSubImageMatching(
            int* pScan0Target,
            int iPosStart,
            int iPosEndPlus1,
            int* pScan0TypeTemplate,
            int iCountScanlinesEachChar,
            System.Collections.Generic.Dictionary<int, System.Collections.Generic.HashSet<int>> dictTypeTemplate,
            out int iResult_CharIndexOnTemplate,
            out int iResult_PosFound
            )
        {
            for (int pos = iPosStart; pos < iPosEndPlus1; pos++)
            {
                var scan = (*(pScan0Target + pos));
                if (dictTypeTemplate.ContainsKey(scan))
                {
                    var hs = dictTypeTemplate[scan];
                    foreach (var posTemplate in hs)
                    {
                        if (ConfirmMatch(pScan0Target, pos, pScan0TypeTemplate, posTemplate, iCountScanlinesEachChar))
                        {
                            var iRemainder = posTemplate % iCountScanlinesEachChar;
                            var iQuotient = posTemplate / iCountScanlinesEachChar;
                            iResult_CharIndexOnTemplate = iQuotient;
                            iResult_PosFound = pos - iRemainder;
                            return;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            //upper half not found, continue to search at lower half
            for (int pos = iPosStart - 1; pos >= 0; pos--)
            {
                var scan = (*(pScan0Target + pos));
                if (dictTypeTemplate.ContainsKey(scan))
                {
                    var hs = dictTypeTemplate[scan];
                    foreach (var posTemplate in hs)
                    {
                        if (ConfirmMatch(pScan0Target, pos, pScan0TypeTemplate, posTemplate, iCountScanlinesEachChar))
                        {
                            var iRemainder = posTemplate % iCountScanlinesEachChar;
                            var iQuotient = posTemplate / iCountScanlinesEachChar;
                            iResult_CharIndexOnTemplate = iQuotient;
                            iResult_PosFound = pos - iRemainder;
                            return;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            iResult_PosFound = -1;
            iResult_CharIndexOnTemplate = -1;
        }
        public PointF Recogninze_GridCrosspointInWorld_ByMapScaleMarker(Bitmap imgScreenCapture, ref Point crosspointMap, int iScalePixelsPer300Meters)
        {
            var crosspointWorld = new PointF(-1, -1);
            Rectangle rectBuffer = new Rectangle(0, 0, bBuffer.Width, bBuffer.Height);
            {
                ref var rectSearch = ref screen.Region_MAP_ABC;
                using (var g = Graphics.FromImage(bBuffer))
                {
                    g.Clear(Color.Black);
                    g.Transform = mABC;
                    g.DrawImage(imgScreenCapture, 0, 0, rectSearch, GraphicsUnit.Pixel);
                }
                using (var bBuffer1bpp = bBuffer.Clone(rectBuffer, PixelFormat.Format1bppIndexed))
                {
                    BitmapData bmdata = bBuffer1bpp.LockBits(rectBuffer, ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);

                    var scan0 = bmdata.Scan0;

                    var iPosStart = crosspointMap.X;

                    GeneralizedScanLineSubImageMatching(
                    pScan0Target: (int*)scan0,
                    iPosStart: iPosStart,
                    iPosEndPlus1: screen.Region_MAP_ABC.Width,
                    pScan0TypeTemplate: Scan0_Letters,
                    iCountScanlinesEachChar: WIDTH_CHAR_LETTER,
                    dictTypeTemplate: dictScanlines_ABC,
                    iResult_CharIndexOnTemplate: out int iResult_CharIndex,
                    iResult_PosFound: out int posFound
                    );
                    if (iResult_CharIndex <0)
                    {
                        throw new TimeZoneNotFoundException("letter");
                    }
                    var x = (posFound - iPosStart) / iScalePixelsPer300Meters;
                    posFound -= iScalePixelsPer300Meters * x;
                    iResult_CharIndex = -x;

                    if (posFound < iPosStart)
                    {
                        posFound += iScalePixelsPer300Meters;
                        iResult_CharIndex++;
                    }

                    crosspointWorld.X = iResult_CharIndex * SquadScreen1920x1080.Len_Ruler300_World;

                    bBuffer1bpp.UnlockBits(bmdata);
                }
            }
            {
                ref var rectSearch = ref screen.Region_MAP_123;
                using (var g = Graphics.FromImage(bBuffer))
                {
                    g.Clear(Color.Black);
                    //g.Transform = mIdentity;
                    g.DrawImage(imgScreenCapture, 0, 0, rectSearch, GraphicsUnit.Pixel);
                }
                using (var bBuffer1bpp = bBuffer.Clone(rectBuffer, PixelFormat.Format1bppIndexed))
                {
                    BitmapData bmdata = bBuffer1bpp.LockBits(rectBuffer, ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);

                    var scan0 = bmdata.Scan0;

                    var iPosStart = crosspointMap.Y;

                    GeneralizedScanLineSubImageMatching(
                    pScan0Target: (int*)scan0,
                    iPosStart: iPosStart,
                    iPosEndPlus1: screen.Region_MAP_123.Height,
                    pScan0TypeTemplate: Scan0_Digitals,
                    iCountScanlinesEachChar: HEIGHT_CHAR,
                    dictTypeTemplate: dictScanlines_123,
                    iResult_CharIndexOnTemplate: out int iResult_CharIndex,
                    iResult_PosFound: out int posFound
                    );
                    if (iResult_CharIndex < 0)
                    {
                        throw new TimeZoneNotFoundException("digital");
                    }
                    var x = (posFound - iPosStart) / iScalePixelsPer300Meters;
                    posFound -= iScalePixelsPer300Meters * x;
                    iResult_CharIndex = -x;

                    if (posFound < iPosStart)
                    {
                        posFound += iScalePixelsPer300Meters;
                        iResult_CharIndex++;
                    }

                    crosspointWorld.Y = (iResult_CharIndex + 1) * SquadScreen1920x1080.Len_Ruler300_World; //+1 because template start at '0' not '1'


                    bBuffer1bpp.UnlockBits(bmdata);
                }
            }
            return crosspointWorld;
        }
        //public RectangleF Recogninze_MapViewRegionOnWorld(Bitmap imgScreenCapture)
        //{
        //    var rectf = new RectangleF();

        //    var scaleMetersPerPixel = Recogninze_Map_Scale_ByRulers(imgScreenCapture);
        //    int iPixels_per300meter = (int)(SquadScreen1920x1080.Len_Ruler300_World / scaleMetersPerPixel);

        //    rectf.Width = (float)(screen.Region_MapViewOnScreen.Width * scaleMetersPerPixel);
        //    rectf.Height= (float)(screen.Region_MapViewOnScreen.Height * scaleMetersPerPixel);

        //    var crosspointMap = Recogninze_GridCrosspointOnMap(imgScreenCapture);

        //    var posFound = -1;
        //    var crosspointWorld = new PointF();
        //    Recogninze_MapScaleMarker_ABC(imgScreenCapture, crosspointMap.X , out char charLetter, out posFound);
        //    crosspointWorld.X = (charLetter - 'A' + 1) * SquadScreen1920x1080.Len_Ruler300_World;
        //    Recogninze_MapScaleMarker_123(imgScreenCapture, crosspointMap.Y, out char charDigital, out posFound);
        //    crosspointWorld.Y = (charDigital - '1' + 1) * SquadScreen1920x1080.Len_Ruler300_World;

        //    rectf.X = (float)(crosspointWorld.X - scaleMetersPerPixel * (crosspointMap.X + 1));
        //    rectf.Y = (float)(crosspointWorld.Y - scaleMetersPerPixel * (crosspointMap.Y + 1));

        //    return rectf;
        //}
        public System.Drawing.Drawing2D.Matrix Recogninze_TransformScreen2World(Bitmap imgScreenCapture)
        {
            //PointF loc;
            //ref var rectfViewPortOnScreen = ref screen.Region_MapViewRegionOnScreenF;
            //loc = rectfViewPortOnScreen.Location; //upperleft
            //var ptsViewPortCornersOnScreen = new PointF[3] { loc, loc, loc };
            //ptsViewPortCornersOnScreen[1].X += rectfViewPortOnScreen.Width;//upper right
            //ptsViewPortCornersOnScreen[2].Y += rectfViewPortOnScreen.Height;//lower left


            //var rectfMapViewRegionOnWorld = Recogninze_MapViewRegionOnWorld(imgScreenCapture);
            //loc = rectfMapViewRegionOnWorld.Location; //upperleft
            //var ptsMapViewRegionOnWorld = new PointF[3] { loc, loc, loc };
            //ptsMapViewRegionOnWorld[1].X += rectfMapViewRegionOnWorld.Width;//upper right
            //ptsMapViewRegionOnWorld[2].Y += rectfMapViewRegionOnWorld.Height;//lower left

            //Transform_Screen2World = new System.Drawing.Drawing2D.Matrix(rectfViewPortOnScreen, ptsMapViewRegionOnWorld);
            //Transform_World2Screen = new System.Drawing.Drawing2D.Matrix(rectfMapViewRegionOnWorld, ptsViewPortCornersOnScreen);




            var fScaleMetersPerPixel = Recogninze_Map_Scale_ByRulers(imgScreenCapture);
            if (fScaleMetersPerPixel == 0f)
            {
                throw new Exception("failed to recognize ruler");
            }
            var fScalePixelsPerMeter = 1 / fScaleMetersPerPixel;
            var iScalePixelsPer300Meters = (int)(300 / fScaleMetersPerPixel);

            var Transform_Screen2World = new System.Drawing.Drawing2D.Matrix();
            Transform_Screen2World.Scale(fScalePixelsPerMeter, fScalePixelsPerMeter);


            var crosspointMap = Recogninze_GridCrosspointOnMap(imgScreenCapture);
            if (crosspointMap.X == -1 || crosspointMap.Y == -1)
            {
                throw new Exception("failed to recognize grid");
            }
            PointF crosspointWorld;
            try
            {
                crosspointWorld = Recogninze_GridCrosspointInWorld_ByMapScaleMarker(imgScreenCapture, ref crosspointMap, iScalePixelsPer300Meters);
            }
            catch (Exception)
            {
                throw new Exception("failed to recognize scale marker");
            }

            var crosspointScreen = new PointF(crosspointMap.X + screen.Region_MapViewOnScreen.X, crosspointMap.Y + screen.Region_MapViewOnScreen.Y);
            var posAfterScaled = new PointF(crosspointScreen.X * fScalePixelsPerMeter, crosspointScreen.Y * fScalePixelsPerMeter);
            Transform_Screen2World.Translate(crosspointWorld.X - posAfterScaled.X, crosspointWorld.Y - posAfterScaled.Y);
            return Transform_Screen2World;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                System.Runtime.InteropServices.Marshal.FreeHGlobal(this.pBuffer);
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~MapRecognition_Brutally_Hardcoded()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}