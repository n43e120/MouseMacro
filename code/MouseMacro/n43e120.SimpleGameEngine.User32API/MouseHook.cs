using System;
using System.Windows.Forms;
using n43e120.Interop.WinAPI;
using n43e120.SimpleGameEngine.Common;

namespace n43e120.SimpleGameEngine.User32API
{
    public class MouseHook : IDisposable, ISignalOnOff
    {
        IntPtr hHookProc = IntPtr.Zero;
        User32.HOOKPROC HookProc;
        public MouseHook(User32.HOOKPROC h)
        {
            this.HookProc = h;
        }
        public void Start()
        {
            if (hHookProc == IntPtr.Zero)
            {
                //var hookproc = new User32.HOOKPROC(HookProc);
                //hHookProc = User32.SetWindowsHookEx(
                //    User32.WH.WH_MOUSE_LL,
                //    hookproc,
                //    User32.GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName),
                //    0U);
                hHookProc = User32.SetWindowsHookEx(
                    User32.WH.WH_MOUSE_LL,
                    HookProc,
                    User32.GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName),
                    0U);
                if (hHookProc == IntPtr.Zero)
                {
                    throw new Exception("SetWindowsHookEx(WH_MOUSE_LL...) failed");
                }
            }
        }
        public void Stop()
        {
            if (hHookProc != IntPtr.Zero)
            {
                var isSucceed = User32.UnhookWindowsHookEx(hHookProc);
                hHookProc = IntPtr.Zero;
                if (!isSucceed) throw new Exception("UnhookWindowsHookEx failed");
            }
        }

        //public event SimpleGameEngineKeyEventHandler KeyDown;
        //public event SimpleGameEngineKeyEventHandler KeyUp;
        //private unsafe int HookProc(int nCode, Int32 wParam, IntPtr lParam)
        //{
        //    // 侦听键盘事件
        //    if (nCode >= 0)
        //    {
        //        MSLLHOOKSTRUCT* p = (MSLLHOOKSTRUCT*)lParam;
        //        Keys k = 0;
        //        switch ((WM)wParam)
        //        {
        //            case WM.WM_LBUTTONDOWN: k = Keys.LButton; goto RAISE_EVENT_KEYDOWN;
        //            case WM.WM_RBUTTONDOWN: k = Keys.RButton; goto RAISE_EVENT_KEYDOWN;
        //            case WM.WM_MBUTTONDOWN: k = Keys.MButton; goto RAISE_EVENT_KEYDOWN;
        //            case WM.WM_XBUTTONDOWN: k = Keys.XButton1; goto RAISE_EVENT_KEYDOWN;
        //            //case WM.WM_XBUTTONDOWN:k = Keys.XButton2;goto RAISE_EVENT_KEYDOWN;
        //            RAISE_EVENT_KEYDOWN:
        //                {
        //                    //KeyEventArgs e = new KeyEventArgs(k);
        //                    //KeyDown?.Invoke(this, e);
        //                    KeyDown?.Invoke((int)k);
        //                }
        //                break;
        //            case WM.WM_LBUTTONUP: k = Keys.LButton; goto RAISE_EVENT_KEYUP;
        //            case WM.WM_RBUTTONUP: k = Keys.RButton; goto RAISE_EVENT_KEYUP;
        //            case WM.WM_MBUTTONUP: k = Keys.MButton; goto RAISE_EVENT_KEYUP;
        //            case WM.WM_XBUTTONUP: k = Keys.XButton1; goto RAISE_EVENT_KEYUP;
        //            //case WM.WM_XBUTTONUP:k = Keys.XButton2;goto RAISE_EVENT_KEYUP;
        //            RAISE_EVENT_KEYUP:
        //                {
        //                    //KeyEventArgs e = new KeyEventArgs(k);
        //                    //KeyUpEvent?.Invoke(this, e);
        //                    KeyUp?.Invoke((int)k);
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    //如果返回1，则结束消息，这个消息到此为止，不再传递。
        //    //如果返回0或调用CallNextHookEx函数则消息出了这个钩子继续往下传递，也就是传给消息真正的接受者
        //    return User32.CallNextHookEx(hHookProc, nCode, wParam, lParam);
        //}

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
        ~MouseHook()
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