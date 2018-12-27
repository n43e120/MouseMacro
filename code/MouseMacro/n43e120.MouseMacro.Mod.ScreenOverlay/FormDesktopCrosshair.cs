using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormDesktopCrosshair : Form
    {
        public FormDesktopCrosshair()
        {
            InitializeComponent();
        }
        private void FormDesktopCrosshair_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Lime;
            this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            this.AllowTransparency = true;
            //Image img = Image.FromFile("MyCrosshair1.png");
            //this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.None;
            this.TopMost = true;
            this.Enabled = false;

            //var r = Screen.PrimaryScreen.Bounds;
            //this.SetDesktopLocation(r.Width / 2 - 32, r.Height / 2 - 32);
            this.ResumeLayout();
            //PInvoke.User32.SetWindowLong(this.Handle, PInvoke.User32.WindowLongIndexFlags.GWL_EXSTYLE,
            //     PInvoke.User32.SetWindowLongFlags.WS_EX_TRANSPARENT | PInvoke.User32.SetWindowLongFlags.WS_EX_LAYERED);
                
        }
        protected override CreateParams CreateParams
        {
            //https://zhidao.baidu.com/question/120292264.html
            //这次我也学到了... 刚注意到WS_EX_TRANSPARENT对于layered windows有特殊含义。如果一个窗口同时有WS_EX_TRANSPARENT和WS_LAYERED它就不会接受鼠标事件（注意WS_EX_TRANSPARENT对于普通窗口完全是另外一个意思。） 也谢谢你了，如果你不问我可能再过几年也不会注意到这个TvT
            get
            {
                const int x = (int) (PInvoke.User32.SetWindowLongFlags.WS_EX_TRANSPARENT | PInvoke.User32.SetWindowLongFlags.WS_EX_LAYERED);
                CreateParams cParms = base.CreateParams;
                cParms.ExStyle |= x;
                return cParms;
            }
            
        }
        //protected override void OnHandleCreated(EventArgs e)
        //{
        //    SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        //    SetStyle(ControlStyles.UserPaint, true);
        //    UpdateStyles();
        //    base.OnHandleCreated(e);
        //}
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cParms = base.CreateParams;
        //        cParms.ExStyle |= 0x00080000; // WS_EX_LAYERED
        //        return cParms;
        //    }
        //}
        //public FormDesktopCrosshair()
        //{
        //    InitializeComponent();
        //    //采用双缓冲技术的控件必需的设置
        //    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        //    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        //    //this.BackColor = Color.Lime;
        //    //this.TransparencyKey = Color.Lime; //Color.FromKnownColor(KnownColor.Lime);
        //    this.AllowTransparency = true;
        //}
        //Point point1;
        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    //base.OnPaintBackground(e);
        //}
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    //base.OnPaint(e);
        //    Graphics g = e.Graphics;
        //    //g.FillRectangle(Brushes.Black, x, y, 200, 200);
        //    var i = Image.FromFile("MyCrosshair1.png");
        //    g.DrawImage(i, point1);
        //}

        //private void FormDesktopCrosshair_Load(object sender, EventArgs e)
        //{
        //    var i = Image.FromFile("MyCrosshair1.png");
        //    Bitmap bitmap = new Bitmap(i); //new Bitmap(this.BackgroundImage);
        //    SetBits(bitmap);
        //}
        //public void SetBits(Bitmap bitmap)
        //{
        //    if (!haveHandle) return;

        //    if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
        //        throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");

        //    IntPtr oldBits = IntPtr.Zero;
        //    IntPtr screenDC = PInvoke.User32.GetDC(IntPtr.Zero).HWnd;
        //    IntPtr hBitmap = IntPtr.Zero;
        //    IntPtr memDc = PInvoke.User32.CreateCompatibleDC(screenDC);

        //    try
        //    {
        //        PInvoke.POINT topLoc = new PInvoke.POINT(Left, Top);
        //        PInvoke.User32.Size bitMapSize = new PInvoke.User32.Size(bitmap.Width, bitmap.Height);
        //        PInvoke.User32.BLENDFUNCTION blendFunc = new PInvoke.User32.BLENDFUNCTION();
        //        PInvoke.POINT srcLoc;// = new PInvoke.POINT(0, 0);

        //        hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
        //        oldBits = PInvoke.User32.SelectObject(memDc, hBitmap);

        //        blendFunc.BlendOp = PInvoke.User32.AC_SRC_OVER;
        //        blendFunc.SourceConstantAlpha = 255;
        //        blendFunc.AlphaFormat = PInvoke.User32.AC_SRC_ALPHA;
        //        blendFunc.BlendFlags = 0;

        //        PInvoke.User32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, PInvoke.User32.ULW_ALPHA);
        //    }
        //    finally
        //    {
        //        if (hBitmap != IntPtr.Zero)
        //        {
        //            PInvoke.User32.SelectObject(memDc, oldBits);
        //            PInvoke.User32.DeleteObject(hBitmap);
        //        }
        //        PInvoke.User32.ReleaseDC(IntPtr.Zero, screenDC);
        //        PInvoke.User32.DeleteDC(memDc);
        //    }
        //}
    }
}
