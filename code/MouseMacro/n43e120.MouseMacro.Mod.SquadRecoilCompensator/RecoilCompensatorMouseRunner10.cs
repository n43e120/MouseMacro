using System;
using System.ComponentModel;
using static System.Threading.Thread;
using static n43e120.Interop.WinAPI.user32helper;
using n43e120.MouseMacro.Design;

namespace n43e120.MouseMacro.Mod.SquadRecoilCompensator
{
    /// <summary>
    /// For Squad version Alpha 10.3
    /// </summary>
    public class RecoilCompensatorMouseRunner_v10_3 : Actor
    {
        [TypeConverter(typeof(StaticActionConverter))]
        public override Action Action
        {
            get { return this.action1; }
            set { this.action1 = value; }
        }

        public const int INTERVAL_DELAY_AFTER_FIRST_TRIGGER = 32;
        public const int INTERVAL_M4 = 63;
        public const int INTERVAL_AK = 98;
        public static void Auto_AK74()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 6; //7
            int y = 0;
            int x = -1;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKS74()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 6; //7
            int y = 0;
            int x = -1;
            for (int i = 0; i < 20; i++)
            {
                y = i / a + b;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKS74U()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 4;
            const int b = 7; //7
            int y = 0;
            int x = 0;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKS74_1P78()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 17;
            int y = 0;
            int x = -1;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_RPK74()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            const int b = 5;
            int y = 0;
            int x = -1;
            for (int i = 0; i < 15; i++) //46 bullets per round
            {
                y = i / a + b;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKM()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            const int b = 5;
            int y = 0;
            int i = 0;
            int x = -1;
            for (; i < 30; i++) //30 bullets per round
            {
                x = i / -6 + -1;
                y = i / a + b;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_PKM()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int b = 8;
            int y = 0;
            int x = 0;
            int i = 0;

            y = b;
            for (; i < 16; i++) //46 bullets per round
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 6;
            const int b = 9;
            int y = 0;
            int x = -1;
            int i = 0;

            for (; i < 25; i++) //46 bullets per round
            {
                y = b + i / a;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249_PIP_M68()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 6;
            const int b = 9;
            int y = 0;
            int x = -1;
            int i = 0;

            for (; i < 30; i++) //46 bullets per round
            {
                y = b + i / a;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249_PIP_M145_Scoped()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 6;
            const int b = 25;
            int y = 0;
            int x = -1;
            int i = 0;

            for (; i < 25; i++) //46 bullets per round
            {
                y = b + i / a;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249_PIP_M145_hip()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int b = 17;
            int y = 0;
            int x = -1;
            int i = 0;

            y = b;
            for (; i < 25; i++) //46 bullets per round
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M240B()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int b = 12;
            int y = 0;
            int x = -1;
            int i = 0;

            y = b;
            for (; i < 25; i++) //46 bullets per round
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            x--;
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Single_M110_SPSS()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            MoveMouse(0, 50);
        }
        public static void Single_SVD()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            MoveMouse(0, 40);
        }
        //public static void Single_SKS()
        //{
        //}
        public static void Single_AK74()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);

            //if 0 then -1, if 1 then 0;  50% chance 0, 50% chances give -1
            var tick = unchecked((int)DateTime.Now.Ticks & 1);
            tick--;
            MoveMouse(tick, 5);
        }
        static int[] Single_AK74_dadada_ys = new int[] { 6, 8 };//, 15 };
        public static void Single_AK74_dadada()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            int i = 0;
            //for (; i < 2; i++) 
            //{
            //    MoveMouse(0, i+5);
            //    Sleep(120);
            //    User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            //}
            foreach (var item in Single_AK74_dadada_ys)
            {
                i = item;
                MoveMouse(0, i);
                Sleep(120 - INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
                LEFTDOWN();
                Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
                LEFTUP();
            }
            //for (; i < 30; i++) //46 bullets per round
            //{
            //    //if 0 then -1, if 1 then 0;  50% chance 0, 50% chances give -1
            //    var tick = unchecked((int)DateTime.Now.Ticks & 1);
            //    tick--;
            //    MoveMouse(tick, 7);
            //    Sleep(120);
            //    User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            //}
        }
        public static void Single_Pistol_dadada()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            for (int i = 0; i < 30; i++) //46 bullets per round
            {
                MoveMouse(0, 3);
                Sleep(70);
                LEFTDOWN();
            }
        }
        public static void Single_M4()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            MoveMouse(0, 5);
        }
        public static void Burst_M4()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            MoveMouse(-1, 9);
            Sleep(INTERVAL_M4);
            MoveMouse(0, 9);
            Sleep(INTERVAL_M4);
            MoveMouse(0, -7);
        }
        public static void Burst_M4_with_M150()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            MoveMouse(0, 37);
            Sleep(INTERVAL_M4);
            MoveMouse(0, 9);
            Sleep(INTERVAL_M4);
            MoveMouse(0, -24);
        }
        public static void Single_M4_with_M150()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            MoveMouse(0, 9);
            Sleep(INTERVAL_M4);
        }
        public static void Auto_M4A1()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 5;
            int y = 0;
            int x = 0;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                MoveMouse(x, y);
                Sleep(INTERVAL_M4);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_G3A3()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            int y = 0;
            int i = 0;
            int x = -1;
            for (; i < 30; i++) //30 bullets per round
            {
                x = Math.Min(i / a + 0, 6);
                y = Math.Min(i / a + 9, 27);
                MoveMouse(-x, y);
                Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_G3A4()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            int y = 0;
            int i = 0;
            int x = -1;
            for (; i < 30; i++) //30 bullets per round
            {
                x = Math.Min(i / a + 0, 6);
                y = Math.Min(i / a + 9, 27);
                MoveMouse(-x, y);
                Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_PPSh41()
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 4;
            const int b = 7; //7
            int y = 0;
            int x = 0;
            for (int i = 0; i < 30; i++)
            {
                y = Math.Min(i / a + b, 6);
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            do
            {
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            } while (true);
        }

        public static void Auto_L85A2_Bipod()//Version Alpha 11 20180504
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);

            int y = 0;
            int x = 0;
            int i = 0;
            x = -1;
            for (; i < 30; i++)
            {
                y = i / 3 + 7;
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_L85A2_ACOG()//Version Alpha 11 20180504
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);

            int y = 0;
            int x = 0;
            int i = 0;
            x = -1;
            MoveMouse(x, 14);
            Sleep(INTERVAL_AK);
            MoveMouse(x, 14);
            Sleep(INTERVAL_AK);
            MoveMouse(x, 14);
            Sleep(INTERVAL_AK);
            for (; i < 30; i++)
            {
                y = Math.Min(i / 3 + 7, 14);
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_L85A2()//Version Alpha 11 20180504
        {
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);

            int y = 0;
            int x = 0;
            int i = 0;
            x = -1;
            for (; i < 15; i++)
            {
                y = Math.Min(i / 4 + 6, 13);
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            for (; i < 20; i++)
            {
                y = Math.Min(i / 4 + 5, 10);
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            for (; i < 30; i++)
            {
                y = Math.Min(i / 4 + 4, 10);
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
        }
    }
}
