using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace n43e120.Interop.WinAPI
{
    public static class user32helper
    {
        //https://blog.csdn.net/hfzsjz/article/details/4351392
        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        public static extern void mouse_event(
                int dwFlags,
                int dx,
                int dy,
                int cButtons,
                int dwExtraInfo
            );

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(
            byte bVk,
            byte bScan,
            int dwFlags,
            int dwExtraInfo
        );

        public const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        public const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        public const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MoveMouse(int x, int y)
        {
            mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LEFTDOWN()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LEFTUP()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RIGHTDOWN()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RIGHTUP()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MIDDLEDOWN()
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MIDDLEUP()
        {
            mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }
        //https://www.cnblogs.com/liujiang/archive/2008/11/21/1338272.html
        // An umanaged function that retrieves the states of each key

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);
        public const int KEYEVENTF_EXTENDEDKEY = 0x1;
        public const int KEYEVENTF_KEYUP = 0x2;
        /// <summary>
        /// 可以用，但是SetLockOn跟SetLockOff效果一样，没有区别
        /// </summary>
        /// <param name="bytVK"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetLockOn(byte bytVK)
        {
            keybd_event(bytVK, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(bytVK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetLockOff(byte bytVK)
        {
            keybd_event(bytVK, 0x45, 0, 0);
            keybd_event(bytVK, 0x45, KEYEVENTF_KEYUP, 0);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLockOn(byte bytVK)
        {
            return (((ushort)GetKeyState(bytVK)) & 0xffff) != 0;
        }
        public static bool CapLock
        {
            get { return IsLockOn(VK_CAPITAL); }
            set
            {
                //keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
                //keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                if (value)
                {
                    SetLockOn(VK_CAPITAL);
                }
                else
                {
                    SetLockOff(VK_CAPITAL);
                }
            }
        }
        public static bool NumLock
        {
            get { return IsLockOn(VK_NUMLOCK); }
            set
            {
                if (value)
                {
                    SetLockOn(VK_NUMLOCK);
                }
                else
                {
                    SetLockOff(VK_NUMLOCK);
                }
            }
        }
        public static bool ScrollLock
        {
            get { return IsLockOn(VK_SCROLLLOCK); }
            set
            {
                if (value)
                {
                    SetLockOn(VK_SCROLLLOCK);
                }
                else
                {
                    SetLockOff(VK_SCROLLLOCK);
                }
            }
        }
        public const byte VK_CAPITAL = 0x14;
        public const byte VK_NUMLOCK = 0x90;
        public const byte VK_SCROLLLOCK = 0x91;
        public const byte VK_SHIFT = 16;
        public const byte VK_CONTROL = 17;
        public const byte VK_MENU = 18;
        public const byte A = 65;
        public const byte C = 67;
        public const byte V = 86;
        public static void CTRL_A()
        {
            keybd_event(VK_CONTROL, 0, 0, 0);
            keybd_event(A, 0, 0, 0);
            keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void CTRL_C()
        {
            keybd_event(VK_CONTROL, 0, 0, 0);
            keybd_event(C, 0, 0, 0);
            keybd_event(C, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void CTRL_V()
        {
            keybd_event(VK_CONTROL, 0, 0, 0);
            keybd_event(V, 0, 0, 0);
            keybd_event(V, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        }

        /// <summary>
        /// MSLLHOOKSTRUCT.mouseData
        /// </summary>
        public const int XBUTTON1 = 0x10000; //65536;
        public const int XBUTTON2 = 0x20000; //131072;
    }
}
