using System;
using System.Text;
using System.Windows.Forms;
using n43e120.Interop.WinAPI;
using n43e120.SimpleGameEngine;
using n43e120.SimpleGameEngine.Common;
using n43e120.SimpleGameEngine.User32API;
using static n43e120.Interop.WinAPI.user32helper;
namespace SampleSetWindowHook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        unsafe void WndProc(IntPtr MSG)
        {
            var m = (MSG*) MSG;
            var sb = new StringBuilder();
            sb.AppendLine($"msg={((WM)m->message).ToString()}");
            switch ((WM)m->message)
            {
                case WM.WM_LBUTTONDOWN:
                case WM.WM_LBUTTONUP:
                case WM.WM_RBUTTONDOWN:
                case WM.WM_RBUTTONUP:
                case WM.WM_MBUTTONDOWN:
                case WM.WM_MBUTTONUP:
                case WM.WM_XBUTTONDOWN:
                case WM.WM_XBUTTONUP:
                case WM.WM_MOUSEMOVE:
                    {
                        MSLLHOOKSTRUCT* p = (MSLLHOOKSTRUCT*)m->lParam;
                        sb.AppendLine($"mdata={(p->mouseData).ToString()}");
                    }
                    break;
                case WM.WM_KEYDOWN:
                case WM.WM_KEYUP:
                case WM.WM_SYSKEYDOWN:
                case WM.WM_SYSKEYUP:
                    {
                        KBDLLHOOKSTRUCT* p = (KBDLLHOOKSTRUCT*)m->lParam;
                        sb.AppendLine($"vkCode={((Keys)p->vkCode).ToString()}");
                    }
                    break;
                default:
                    break;
            }
            this.textBox1.Text = sb.ToString();
        }
        MessageDispatcher ge;
        private void button1_Click(object sender, EventArgs e)
        {
            ge = new GameEngineViaUser32API(); //new KeyboardHook();
            ge.evMessage += WndProc;
            (ge as ISignalOnOff).Start();
        }

        private void btnCaplock_Click(object sender, EventArgs e)
        {
            SetLockOff(VK_CAPITAL);
            //user32helper.CapLock = !user32helper.CapLock;
        }
        private void btnNumLock_Click(object sender, EventArgs e)
        {
            user32helper.NumLock = !user32helper.NumLock;
        }
        private void btnScrollLock_Click(object sender, EventArgs e)
        {
            user32helper.ScrollLock = !user32helper.ScrollLock;
        }
        //protected override void WndProc(ref Message m)
        //{
        //    switch ((WM)m.Msg)
        //    {
        //        case WM.WM_LBUTTONDOWN:
        //        case WM.WM_LBUTTONUP:
        //        case WM.WM_RBUTTONDOWN:
        //        case WM.WM_RBUTTONUP:
        //        case WM.WM_MBUTTONDOWN:
        //        case WM.WM_MBUTTONUP:
        //        case WM.WM_XBUTTONDOWN:
        //        case WM.WM_XBUTTONUP:
        //        case WM.WM_MOUSEMOVE:
        //        case WM.WM_KEYDOWN:
        //        case WM.WM_KEYUP:
        //        case WM.WM_SYSKEYDOWN:
        //        case WM.WM_SYSKEYUP:
        //            this.textBox1.Text = m.ToString();
        //            break;
        //        default:
        //            break;
        //    }
        //    base.WndProc(ref m);
        //}
    }
}
