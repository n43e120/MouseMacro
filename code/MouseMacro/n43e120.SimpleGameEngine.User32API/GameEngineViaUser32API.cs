using n43e120.Interop.WinAPI;
using n43e120.SimpleGameEngine.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n43e120.SimpleGameEngine.User32API
{
    public class GameEngineViaUser32API : MessageDispatcher, IDisposable, ISignalOnOff
    {
        KeyboardHook hK;
        MouseHook hM;
        public GameEngineViaUser32API()
        {
            this.hK = new KeyboardHook(KBHookProc);
            this.hM = new MouseHook(MouseHookProc);
        }
        public void Start()
        {
            this.hK?.Start();
            this.hM?.Start();
        }
        public void Stop()
        {
            this.hM?.Stop();
            this.hK?.Stop();
        }

        private unsafe int KBHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 侦听键盘事件
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT* p = (KBDLLHOOKSTRUCT*)lParam;
                MSG msg;
                msg.message = (uint)wParam;
                msg.lParam = lParam;
                MSG* pmsg = &msg;
                base.Broadcast((IntPtr)pmsg);
                //KBDLLHOOKSTRUCT* p = (KBDLLHOOKSTRUCT*)lParam;
                //var k = (*p).vkCode;
                //switch ((WM)wParam)
                //{
                //    case WM.WM_KEYDOWN:
                //    case WM.WM_SYSKEYDOWN:
                //        {
                //            //KeyEventArgs e = new KeyEventArgs(k);
                //            //KeyDownEvent?.Invoke(this, e);
                //            OnKeyDown((int)k);
                //        }
                //        break;
                //    case WM.WM_KEYUP:
                //    case WM.WM_SYSKEYUP:
                //        {
                //            //KeyEventArgs e = new KeyEventArgs(k);
                //            //KeyUpEvent?.Invoke(this, e);
                //            OnKeyUp((int)k);
                //        }
                //        break;
                //    default:
                //        break;
                //}
            }
            //如果返回1，则结束消息，这个消息到此为止，不再传递。
            //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
            return 0;// return User32.CallNextHookEx(hHookProc, nCode, wParam, lParam);
        }

        private unsafe int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            //const int XBUTTON1 = 0x10000; //65536;
            //const int XBUTTON2 = 0x20000; //131072;
            // 侦听键盘事件
            if (nCode >= 0)
            {
                MSG msg;
                msg.message = (uint)wParam;
                msg.lParam = lParam;
                MSG* pmsg = &msg;
                base.Broadcast((IntPtr)pmsg);

                //MSLLHOOKSTRUCT* p = (MSLLHOOKSTRUCT*)lParam;
                //Keys k = 0;
                //switch ((WM)wParam)
                //{
                //    case WM.WM_LBUTTONDOWN: k = Keys.LButton; goto RAISE_EVENT_KEYDOWN;
                //    case WM.WM_RBUTTONDOWN: k = Keys.RButton; goto RAISE_EVENT_KEYDOWN;
                //    case WM.WM_MBUTTONDOWN: k = Keys.MButton; goto RAISE_EVENT_KEYDOWN;
                //    case WM.WM_XBUTTONDOWN:
                //        switch (p->mouseData)
                //        {
                //            case XBUTTON1: k = Keys.XButton1;break;
                //            case XBUTTON2: k = Keys.XButton2; break;
                //            default:
                //                break;
                //        }
                //         goto RAISE_EVENT_KEYDOWN;
                //    //case WM.WM_XBUTTONDOWN:k = Keys.XButton2;goto RAISE_EVENT_KEYDOWN;
                //    RAISE_EVENT_KEYDOWN:
                //        {
                //            //KeyEventArgs e = new KeyEventArgs(k);
                //            //KeyDown?.Invoke(this, e);
                //            OnKeyDown((int)k);
                //        }
                //        break;
                //    case WM.WM_LBUTTONUP: k = Keys.LButton; goto RAISE_EVENT_KEYUP;
                //    case WM.WM_RBUTTONUP: k = Keys.RButton; goto RAISE_EVENT_KEYUP;
                //    case WM.WM_MBUTTONUP: k = Keys.MButton; goto RAISE_EVENT_KEYUP;
                //    case WM.WM_XBUTTONUP:
                //        switch (p->mouseData)
                //        {
                //            case XBUTTON1: k = Keys.XButton1; break;
                //            case XBUTTON2: k = Keys.XButton2; break;
                //            default:
                //                break;
                //        }
                //        goto RAISE_EVENT_KEYUP;
                //    //case WM.WM_XBUTTONUP:k = Keys.XButton2;goto RAISE_EVENT_KEYUP;
                //    RAISE_EVENT_KEYUP:
                //        {
                //            //KeyEventArgs e = new KeyEventArgs(k);
                //            //KeyUpEvent?.Invoke(this, e);
                //            OnKeyUp((int)k);
                //        }
                //        break;
                //    case WM.WM_MOUSEMOVE:
                //        return 0;
                //        break;
                //    default:
                //        break;
                //}
            }
            //如果返回1，则结束消息，这个消息到此为止，不再传递。
            //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
            return 0;// return User32.CallNextHookEx(hHookProc, nCode, wParam, lParam);
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
                Stop();

                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~GameEngineViaUser32API()
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
