using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n43e120.Interop.WinAPI
{
    public static class constants
    {
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const int WM_SYSKEYDOWN = 0x104;
        public const int WM_SYSKEYUP = 0x105;
        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_MBUTTONDOWN = 0x207;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_MBUTTONUP = 0x208;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_MBUTTONDBLCLK = 0x209;

        //鼠标常量 
        public const int WH_KEYBOARD_LL = 13;   //keyboard   hook   constant   
        //鼠标常量   
        public const int WH_MOUSE_LL = 14;   //mouse   hook   constant   


        public const uint VK_LBUTTON = 1;
        public const uint VK_RBUTTON = 2;
        public const uint VK_CANCEL = 3;
        public const uint VK_MBUTTON = 4;
        public const uint VK_BACK = 8;
        public const uint VK_TAB = 9;
        public const uint VK_CLEAR = 12;
        public const uint VK_RETURN = 13;
        public const uint VK_SHIFT = 16;
        public const uint VK_CONTROL = 17;
        public const uint VK_MENU = 18;
        public const uint VK_PAUSE = 19;
        public const uint VK_CAPITAL = 20;
        public const uint VK_ESCAPE = 27;
        public const uint VK_SPACE = 32;
        public const uint VK_PRIOR = 33;
        public const uint VK_NEXT = 34;
        public const uint VK_END = 35;
        public const uint VK_HOME = 36;
        public const uint VK_LEFT = 37;
        public const uint VK_UP = 38;
        public const uint VK_RIGHT = 39;
        public const uint VK_DOWN = 40;
        public const uint VK_SELECT = 41;
        public const uint VK_PRINT = 42;
        public const uint VK_EXECUTE = 43;
        public const uint VK_SNAPSHOT = 44;
        public const uint VK_INSERT = 45;
        public const uint VK_DELETE = 46;
        public const uint VK_HELP = 47;
        public const uint VK_NUM0 = 48; //0  
        public const uint VK_NUM1 = 49; //1  
        public const uint VK_NUM2 = 50; //2  
        public const uint VK_NUM3 = 51; //3  
        public const uint VK_NUM4 = 52; //4  
        public const uint VK_NUM5 = 53; //5  
        public const uint VK_NUM6 = 54; //6  
        public const uint VK_NUM7 = 55; //7  
        public const uint VK_NUM8 = 56; //8  
        public const uint VK_NUM9 = 57; //9  
        public const uint VK_A = 65; //A  
        public const uint VK_B = 66; //B  
        public const uint VK_C = 67; //C  
        public const uint VK_D = 68; //D  
        public const uint VK_E = 69; //E  
        public const uint VK_F = 70; //F  
        public const uint VK_G = 71; //G  
        public const uint VK_H = 72; //H  
        public const uint VK_I = 73; //I  
        public const uint VK_J = 74; //J  
        public const uint VK_K = 75; //K  
        public const uint VK_L = 76; //L  
        public const uint VK_M = 77; //M  
        public const uint VK_N = 78; //N  
        public const uint VK_O = 79; //O  
        public const uint VK_P = 80; //P  
        public const uint VK_Q = 81; //Q  
        public const uint VK_R = 82; //R  
        public const uint VK_S = 83; //S  
        public const uint VK_T = 84; //T  
        public const uint VK_U = 85; //U  
        public const uint VK_V = 86; //V  
        public const uint VK_W = 87; //W  
        public const uint VK_X = 88; //X  
        public const uint VK_Y = 89; //Y  
        public const uint VK_Z = 90; //Z  
        public const uint VK_NUMPAD0 = 96; //0  
        public const uint VK_NUMPAD1 = 97; //1  
        public const uint VK_NUMPAD2 = 98; //2  
        public const uint VK_NUMPAD3 = 99; //3  
        public const uint VK_NUMPAD4 = 100; //4  
        public const uint VK_NUMPAD5 = 101; //5  
        public const uint VK_NUMPAD6 = 102; //6  
        public const uint VK_NUMPAD7 = 103; //7  
        public const uint VK_NUMPAD8 = 104; //8  
        public const uint VK_NUMPAD9 = 105; //9  
        public const uint VK_NULTIPLY = 106;
        public const uint VK_ADD = 107;
        public const uint VK_SEPARATOR = 108;
        public const uint VK_SUBTRACT = 109;
        public const uint VK_DECIMAL = 110;
        public const uint VK_DIVIDE = 111;
        public const uint VK_F1 = 112;
        public const uint VK_F2 = 113;
        public const uint VK_F3 = 114;
        public const uint VK_F4 = 115;
        public const uint VK_F5 = 116;
        public const uint VK_F6 = 117;
        public const uint VK_F7 = 118;
        public const uint VK_F8 = 119;
        public const uint VK_F9 = 120;
        public const uint VK_F10 = 121;
        public const uint VK_F11 = 122;
        public const uint VK_F12 = 123;
        public const uint VK_NUMLOCK = 144;
        public const uint VK_SCROLL = 145;

        public const uint MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        public const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
    }
}
