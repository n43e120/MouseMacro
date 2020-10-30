using n43e120.Interop.WinAPI;
using n43e120.MouseMacro.Design;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static n43e120.Interop.WinAPI.user32helper;
using static System.Threading.Thread;

namespace n43e120.MouseMacro.Mod.RepetitiveClicker
{
    [MacroController]
    [TypeConverter(typeof(DisplayNameAbleConverter))]
    [DisplayName("Click Repeatly")]
    public class RepetitiveClickerMacroController : DefaultMacroController
    {
        private Keys _trigger;
        [Category("Key")]
        [DisplayName("Trigger")]
        [Description("The key which triggers the action")]
        [DefaultValue(Keys.F8)]
        public Keys Trigger
        {
            get { return _trigger; }
            set
            {
                //if (value == _trigger)
                //{
                //    return;
                //}
                //else 
                if (value == Keys.None)
                {
                    actualProcessMethod = null;
                    _trigger = value;
                    return;
                }
                else if (value == _target)
                {
                    MessageBox.Show("Trigger and Target Key cannot be same!");
                    return;
                }
                _trigger = value;
                switch (_trigger)
                {
                    case Keys.LButton:
                        this.actualProcessMethod = WndProc_LMB;
                        break;
                    case Keys.RButton:
                        this.actualProcessMethod = WndProc_RMB;
                        break;
                    case Keys.MButton:
                        this.actualProcessMethod = WndProc_MMB;
                        break;
                    case Keys.XButton1:
                        this.actualProcessMethod = WndProc_XMB1;
                        break;
                    case Keys.XButton2:
                        this.actualProcessMethod = WndProc_XMB2;
                        break;
                    //case Keys.KeyCode:
                    //case Keys.Modifiers:
                    //case Keys.None:
                    //case Keys.Cancel:
                    case Keys.Back:
                    case Keys.Tab:
                    case Keys.LineFeed:
                    case Keys.Clear:
                    //case Keys.Return:
                    case Keys.Enter:
                    case Keys.ShiftKey:
                    case Keys.ControlKey:
                    case Keys.Menu:
                    case Keys.Pause:
                    //case Keys.Capital:
                    case Keys.CapsLock:
                    case Keys.KanaMode:
                    //case Keys.HanguelMode:
                    //case Keys.HangulMode:
                    case Keys.JunjaMode:
                    case Keys.FinalMode:
                    case Keys.HanjaMode:
                    //case Keys.KanjiMode:
                    case Keys.Escape:
                    case Keys.IMEConvert:
                    case Keys.IMENonconvert:
                    case Keys.IMEAccept:
                    //case Keys.IMEAceept:
                    case Keys.IMEModeChange:
                    case Keys.Space:
                    //case Keys.Prior:
                    case Keys.PageUp:
                    //case Keys.Next:
                    case Keys.PageDown:
                    case Keys.End:
                    case Keys.Home:
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Right:
                    case Keys.Down:
                    case Keys.Select:
                    case Keys.Print:
                    case Keys.Execute:
                    //case Keys.Snapshot:
                    case Keys.PrintScreen:
                    case Keys.Insert:
                    case Keys.Delete:
                    case Keys.Help:
                    case Keys.D0:
                    case Keys.D1:
                    case Keys.D2:
                    case Keys.D3:
                    case Keys.D4:
                    case Keys.D5:
                    case Keys.D6:
                    case Keys.D7:
                    case Keys.D8:
                    case Keys.D9:
                    case Keys.A:
                    case Keys.B:
                    case Keys.C:
                    case Keys.D:
                    case Keys.E:
                    case Keys.F:
                    case Keys.G:
                    case Keys.H:
                    case Keys.I:
                    case Keys.J:
                    case Keys.K:
                    case Keys.L:
                    case Keys.M:
                    case Keys.N:
                    case Keys.O:
                    case Keys.P:
                    case Keys.Q:
                    case Keys.R:
                    case Keys.S:
                    case Keys.T:
                    case Keys.U:
                    case Keys.V:
                    case Keys.W:
                    case Keys.X:
                    case Keys.Y:
                    case Keys.Z:
                    case Keys.LWin:
                    case Keys.RWin:
                    case Keys.Apps:
                    case Keys.Sleep:
                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                    case Keys.Multiply:
                    case Keys.Add:
                    case Keys.Separator:
                    case Keys.Subtract:
                    case Keys.Decimal:
                    case Keys.Divide:
                    case Keys.F1:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:
                    case Keys.F10:
                    case Keys.F11:
                    case Keys.F12:
                    case Keys.F13:
                    case Keys.F14:
                    case Keys.F15:
                    case Keys.F16:
                    case Keys.F17:
                    case Keys.F18:
                    case Keys.F19:
                    case Keys.F20:
                    case Keys.F21:
                    case Keys.F22:
                    case Keys.F23:
                    case Keys.F24:
                    case Keys.NumLock:
                    case Keys.Scroll:
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                    case Keys.LControlKey:
                    case Keys.RControlKey:
                    case Keys.LMenu:
                    case Keys.RMenu:
                    case Keys.BrowserBack:
                    case Keys.BrowserForward:
                    case Keys.BrowserRefresh:
                    case Keys.BrowserStop:
                    case Keys.BrowserSearch:
                    case Keys.BrowserFavorites:
                    case Keys.BrowserHome:
                    case Keys.VolumeMute:
                    case Keys.VolumeDown:
                    case Keys.VolumeUp:
                    case Keys.MediaNextTrack:
                    case Keys.MediaPreviousTrack:
                    case Keys.MediaStop:
                    case Keys.MediaPlayPause:
                    case Keys.LaunchMail:
                    case Keys.SelectMedia:
                    case Keys.LaunchApplication1:
                    case Keys.LaunchApplication2:
                    case Keys.OemSemicolon:
                    //case Keys.Oem1:
                    case Keys.Oemplus:
                    case Keys.Oemcomma:
                    case Keys.OemMinus:
                    case Keys.OemPeriod:
                    case Keys.OemQuestion:
                    //case Keys.Oem2:
                    case Keys.Oemtilde:
                    //case Keys.Oem3:
                    case Keys.OemOpenBrackets:
                    //case Keys.Oem4:
                    case Keys.OemPipe:
                    //case Keys.Oem5:
                    case Keys.OemCloseBrackets:
                    //case Keys.Oem6:
                    case Keys.OemQuotes:
                    //case Keys.Oem7:
                    case Keys.Oem8:
                    case Keys.OemBackslash:
                    //case Keys.Oem102:
                    case Keys.ProcessKey:
                    case Keys.Packet:
                    case Keys.Attn:
                    case Keys.Crsel:
                    case Keys.Exsel:
                    case Keys.EraseEof:
                    case Keys.Play:
                    case Keys.Zoom:
                    case Keys.NoName:
                    case Keys.Pa1:
                    case Keys.OemClear:
                        //case Keys.Shift:
                        //case Keys.Control:
                        //case Keys.Alt:
                        this.actualProcessMethod = WndProc_KeyboardKey;
                        break;
                    default:
                        ShowMessageBoxUnsupportKey(value);
                        this.actualProcessMethod = null;
                        break;
                }
            }
        }
        [Category("Key")]
        [DisplayName("Activator")]
        [Description("When it is on, the action won't stop at release the trigger button until the button is pressed again")]
        public System.Windows.Forms.Keys Lock { get; } = System.Windows.Forms.Keys.NumLock;
        void ShowMessageBoxUnsupportKey(Keys k)
        {
            MessageBox.Show($"Unsupported Key {k.ToString()}");
        }
        private Keys _target;
        [Category("Key")]
        [DisplayName("Target")]
        [Description("The key Which to simulate to click repetitively")]
        [DefaultValue(Keys.LButton)]
        public Keys Target
        {
            get { return _target; }
            set
            {
                this.Actor?.Stop();
                if (value == _target)
                {
                    return;
                }
                else if (value == Keys.None)
                {
                    actualProcessMethod = null;
                    _target = value;
                    return;
                }
                else if (value == _trigger)
                {
                    MessageBox.Show("Trigger and Target Key cannot be same!");
                    return;
                }
                _target = value;
                switch (_target)
                {
                    case Keys.LButton:
                        Actor.Action = RepetitivelyClickLMB; break;
                    case Keys.RButton:
                        Actor.Action = RepetitivelyClickRMB; break;
                    case Keys.MButton:
                        Actor.Action = RepetitivelyClickMMB; break;

                    //case Keys.Capital:
                    case Keys.CapsLock:
                    case Keys.NumLock:
                    case Keys.Scroll:
                        Actor.Action = RepetitivelyClickKeyboard_EXTENDEDKEY;
                        break;
                    //case Keys.KeyCode:
                    //case Keys.Modifiers:
                    //case Keys.None:
                    case Keys.XButton1:
                    case Keys.XButton2:
                    case Keys.Cancel:
                    case Keys.Back:
                    case Keys.Tab:
                    case Keys.LineFeed:
                    case Keys.Clear:
                    //case Keys.Return:
                    case Keys.Enter:
                    case Keys.ShiftKey:
                    case Keys.ControlKey:
                    case Keys.Menu:
                    case Keys.Pause:
                    case Keys.KanaMode:
                    //case Keys.HanguelMode:
                    //case Keys.HangulMode:
                    case Keys.JunjaMode:
                    case Keys.FinalMode:
                    case Keys.HanjaMode:
                    //case Keys.KanjiMode:
                    case Keys.Escape:
                    case Keys.IMEConvert:
                    case Keys.IMENonconvert:
                    case Keys.IMEAccept:
                    //case Keys.IMEAceept:
                    case Keys.IMEModeChange:
                    case Keys.Space:
                    //case Keys.Prior:
                    case Keys.PageUp:
                    //case Keys.Next:
                    case Keys.PageDown:
                    case Keys.End:
                    case Keys.Home:
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Right:
                    case Keys.Down:
                    case Keys.Select:
                    case Keys.Print:
                    case Keys.Execute:
                    //case Keys.Snapshot:
                    case Keys.PrintScreen:
                    case Keys.Insert:
                    case Keys.Delete:
                    case Keys.Help:
                    case Keys.D0:
                    case Keys.D1:
                    case Keys.D2:
                    case Keys.D3:
                    case Keys.D4:
                    case Keys.D5:
                    case Keys.D6:
                    case Keys.D7:
                    case Keys.D8:
                    case Keys.D9:
                    case Keys.A:
                    case Keys.B:
                    case Keys.C:
                    case Keys.D:
                    case Keys.E:
                    case Keys.F:
                    case Keys.G:
                    case Keys.H:
                    case Keys.I:
                    case Keys.J:
                    case Keys.K:
                    case Keys.L:
                    case Keys.M:
                    case Keys.N:
                    case Keys.O:
                    case Keys.P:
                    case Keys.Q:
                    case Keys.R:
                    case Keys.S:
                    case Keys.T:
                    case Keys.U:
                    case Keys.V:
                    case Keys.W:
                    case Keys.X:
                    case Keys.Y:
                    case Keys.Z:
                    case Keys.LWin:
                    case Keys.RWin:
                    case Keys.Apps:
                    case Keys.Sleep:
                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                    case Keys.Multiply:
                    case Keys.Add:
                    case Keys.Separator:
                    case Keys.Subtract:
                    case Keys.Decimal:
                    case Keys.Divide:
                    case Keys.F1:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:
                    case Keys.F10:
                    case Keys.F11:
                    case Keys.F12:
                    case Keys.F13:
                    case Keys.F14:
                    case Keys.F15:
                    case Keys.F16:
                    case Keys.F17:
                    case Keys.F18:
                    case Keys.F19:
                    case Keys.F20:
                    case Keys.F21:
                    case Keys.F22:
                    case Keys.F23:
                    case Keys.F24:
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                    case Keys.LControlKey:
                    case Keys.RControlKey:
                    case Keys.LMenu:
                    case Keys.RMenu:
                    case Keys.BrowserBack:
                    case Keys.BrowserForward:
                    case Keys.BrowserRefresh:
                    case Keys.BrowserStop:
                    case Keys.BrowserSearch:
                    case Keys.BrowserFavorites:
                    case Keys.BrowserHome:
                    case Keys.VolumeMute:
                    case Keys.VolumeDown:
                    case Keys.VolumeUp:
                    case Keys.MediaNextTrack:
                    case Keys.MediaPreviousTrack:
                    case Keys.MediaStop:
                    case Keys.MediaPlayPause:
                    case Keys.LaunchMail:
                    case Keys.SelectMedia:
                    case Keys.LaunchApplication1:
                    case Keys.LaunchApplication2:
                    case Keys.OemSemicolon:
                    //case Keys.Oem1:
                    case Keys.Oemplus:
                    case Keys.Oemcomma:
                    case Keys.OemMinus:
                    case Keys.OemPeriod:
                    case Keys.OemQuestion:
                    //case Keys.Oem2:
                    case Keys.Oemtilde:
                    //case Keys.Oem3:
                    case Keys.OemOpenBrackets:
                    //case Keys.Oem4:
                    case Keys.OemPipe:
                    //case Keys.Oem5:
                    case Keys.OemCloseBrackets:
                    //case Keys.Oem6:
                    case Keys.OemQuotes:
                    //case Keys.Oem7:
                    case Keys.Oem8:
                    case Keys.OemBackslash:
                    //case Keys.Oem102:
                    case Keys.ProcessKey:
                    case Keys.Packet:
                    case Keys.Attn:
                    case Keys.Crsel:
                    case Keys.Exsel:
                    case Keys.EraseEof:
                    case Keys.Play:
                    case Keys.Zoom:
                    case Keys.NoName:
                    case Keys.Pa1:
                    case Keys.OemClear:
                        //case Keys.Shift:
                        //case Keys.Control:
                        //case Keys.Alt:
                        Actor.Action = RepetitivelyClickKeyboard;
                        break;
                    default:
                        ShowMessageBoxUnsupportKey(value);
                        Actor.Action = null;
                        break;
                }
            }
        }

        private int _interval = 100;
        [Description("how long between two clicks")]
        [DefaultValue(100)]
        public int Interval
        {
            get { return _interval; }
            set
            {
                const int MAX = 1000;
                const int MIN = 0;
                switch (value)
                {
                    case int max when max > MAX:
                        _interval = MAX;
                        break;
                    case int min when min < MIN:
                        _interval = MIN;
                        break;
                    default:
                        _interval = value;
                        break;
                }
            }
        }
        public virtual Actor Actor { get; set; }

        public void RepetitivelyClickLMB()
        {
            while (hasTriggered)
            {
                LEFTDOWN();
                //Sleep(70);
                LEFTUP();
                Sleep(_interval);
            };
        }
        public void RepetitivelyClickRMB()
        {
            while (hasTriggered)
            {
                RIGHTDOWN();
                RIGHTUP();
                Sleep(_interval);
            }
        }
        public void RepetitivelyClickMMB()
        {
            while (hasTriggered)
            {
                MIDDLEDOWN();
                MIDDLEUP();
                Sleep(_interval);
            }
        }
        public void RepetitivelyClickKeyboard()
        {
            var bytK = (byte)((int)_target & 0xffff);
            while (hasTriggered)
            {
                keybd_event(bytK, 0, 0, 0);
                keybd_event(bytK, 0, 0x2, 0);
                Sleep(_interval);
            }
        }
        public void RepetitivelyClickKeyboard_EXTENDEDKEY()
        {
            var bytVK = (byte)((int)_target & 0xff);
            var v = _interval / 2;
            if (IsLockOn(bytVK))
            {
                keybd_event(bytVK, 0x45, 0, 0);
                keybd_event(bytVK, 0x45, KEYEVENTF_KEYUP, 0);
                Sleep(v);
            }
            while (hasTriggered)
            {
                keybd_event(bytVK, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
                keybd_event(bytVK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                Sleep(v);
                keybd_event(bytVK, 0x45, 0, 0);
                keybd_event(bytVK, 0x45, KEYEVENTF_KEYUP, 0);
                Sleep(v);
            }
        }
        public RepetitiveClickerMacroController()
        {
            this.Actor = new Actor();
            this.Trigger = Keys.F8;
            this.Target = Keys.LButton;
        }
        n43e120.SimpleGameEngine.Common.WndProc actualProcessMethod;
        public unsafe override void WndProc(IntPtr msg)
        {
            actualProcessMethod?.Invoke(msg);
            base.WndProc(msg);
        }
        private bool hasTriggered; //make sure that mousedown event must be paired with mouseup
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void INLINE_TryStart()
        {
            if (!hasTriggered)
            {
                hasTriggered = true;
                Actor.Start();
            }
            else
            {
                if (NumLock)
                {
                    //Actor.Stop();
                    hasTriggered = false; //signaling to stop rather than call thread.interrupt() which may cause mousedown mouseup can not be paired
                }
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void INLINE_TryStop()
        {
            if (hasTriggered)
            {
                if (NumLock)
                {
                    return;
                }
                //Actor.Stop();
                hasTriggered = false;
            }
        }
        public unsafe void WndProc_KeyboardKey(IntPtr msg)
        {
            var m = (MSG*)msg;
            switch ((WM)m->message)
            {
                case WM.WM_KEYDOWN:
                case WM.WM_SYSKEYDOWN:
                    {
                        KBDLLHOOKSTRUCT* p = (KBDLLHOOKSTRUCT*)m->lParam;
                        var k = (Keys)p->vkCode;
                        if (k == _trigger)
                        {
                            INLINE_TryStart();
                        }
                    }
                    break;
                case WM.WM_KEYUP:
                case WM.WM_SYSKEYUP:
                    {
                        KBDLLHOOKSTRUCT* p = (KBDLLHOOKSTRUCT*)m->lParam;
                        var k = (Keys)p->vkCode;
                        if (k == _trigger)
                        {
                            INLINE_TryStop();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public unsafe void WndProc_LMB(IntPtr msg)
        {
            var m = (MSG*)msg;
            switch ((WM)m->message)
            {
                case WM.WM_LBUTTONDOWN:
                    INLINE_TryStart();
                    break;
                case WM.WM_LBUTTONUP:
                    INLINE_TryStop();
                    break;
            }
        }
        public unsafe void WndProc_RMB(IntPtr msg)
        {
            var m = (MSG*)msg;
            switch ((WM)m->message)
            {
                case WM.WM_RBUTTONDOWN:
                    INLINE_TryStart();
                    break;
                case WM.WM_RBUTTONUP:
                    INLINE_TryStop();
                    break;
            }
        }
        public unsafe void WndProc_MMB(IntPtr msg)
        {
            var m = (MSG*)msg;
            switch ((WM)m->message)
            {
                case WM.WM_MBUTTONDOWN:
                    INLINE_TryStart();
                    break;
                case WM.WM_MBUTTONUP:
                    INLINE_TryStop();
                    break;
            }
        }
        public unsafe void WndProc_XMB1(IntPtr msg)
        {
            var m = (MSG*)msg;
            MSLLHOOKSTRUCT* p = (MSLLHOOKSTRUCT*)m->lParam;
            switch ((WM)m->message)
            {
                case WM.WM_XBUTTONDOWN:
                    switch (p->mouseData)
                    {
                        case XBUTTON1:
                            INLINE_TryStart();
                            break;
                    }
                    break;
                case WM.WM_MBUTTONUP:
                    switch (p->mouseData)
                    {
                        case XBUTTON1:
                            INLINE_TryStop();
                            break;
                    }
                    break;
            }
        }
        public unsafe void WndProc_XMB2(IntPtr msg)
        {
            var m = (MSG*)msg;
            MSLLHOOKSTRUCT* p = (MSLLHOOKSTRUCT*)m->lParam;
            switch ((WM)m->message)
            {
                case WM.WM_XBUTTONDOWN:
                    switch (p->mouseData)
                    {
                        case XBUTTON2:
                            INLINE_TryStart();
                            break;
                    }
                    break;
                case WM.WM_MBUTTONUP:
                    switch (p->mouseData)
                    {
                        case XBUTTON2:
                            INLINE_TryStop();
                            break;
                    }
                    break;
            }
        }
    }
}
