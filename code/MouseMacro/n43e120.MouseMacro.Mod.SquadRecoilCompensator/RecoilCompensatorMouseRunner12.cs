using System;
using System.ComponentModel;
using static System.Threading.Thread;
using static n43e120.Interop.WinAPI.user32helper;
using n43e120.MouseMacro.Design;

namespace n43e120.MouseMacro.Mod.SquadRecoilCompensator
{
    /// <summary>
    /// For Squad version Alpha 12.1
    /// created at 2018/12/29
    /// </summary>
    public class RecoilCompensatorMouseRunner_v12_1 : Actor
    {
        [TypeConverter(typeof(StaticActionConverter))]
        public override Action Action
        {
            get { return this.action1; }
            set { this.action1 = value; }
        }

        public const int INTERVAL_DELAY_AFTER_FIRST_TRIGGER = 32;

        public static void Auto_AK74M()
        {
            const int INTERVAL_AK = 98;
            int[] recoil_y = { 8, 9, 10, 10, 11, 12, 13, 14, 16, 18, 19, 20, 21, 22, 23, 23, 23, 23, };
            int[] recoil_x = { 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            int y = 0, x = 0;
            int i = 0;

            for (; i < 15; i++)
            {
                y = recoil_y[i];
                x = recoil_x[i];
                MoveMouse(x, y);
                Sleep(INTERVAL_AK);
            }
            LEFTUP();
            MoveMouse(x, y);
        }
        public static void Auto_M4A1_M68_Stand_Crouch()
        {
            int[] recoil_y = { 7, 8, 9, 10, 11, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 20, 21, 22, 23, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, };
            int[] recoil_x = { 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            int INTERVAL_M4A1 = 70;
            int y = 0, x = 0;
            for (int i = 0; i < 31; i++)
            {
                y = recoil_y[i];
                x = recoil_x[i];
                MoveMouse(x, y);
                Sleep(INTERVAL_M4A1);
            }
            LEFTUP();
        }
        public static void Auto_M4A1_M68_Prone()
        {
            int[] recoil_y = { 5, 6, 7, 8, 9, 10, 11, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 20, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, };
            int[] recoil_x = { 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            int INTERVAL_M4A1 = 70;
            int y = 0, x = 0;
            for (int i = 0; i < 31; i++)
            {
                y = recoil_y[i];
                x = recoil_x[i];
                MoveMouse(x, y);
                Sleep(INTERVAL_M4A1);
            }
            LEFTUP();
        }
        static string getStr()
        {
            return System.Windows.Forms.Clipboard.GetText();
        }
        public static void Debugg()
        {
            int[] recoil_y = { 7, 8, 9, 10, 11, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 20, 21, 22, 23, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, };
            int[] recoil_x = { 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            int INTERVAL_M4A1 = 70; //63
            //const float y3 = 0;// 1f / 1200f;
            //const float y2 = 0.014f;
            //const float y1 = 0.6f;
            //const float y0 = 7;
            //float fy, fx;
            int y = 0, x = 0;
            int i = 0;
            Func<string> del = getStr;
            var s = del(); // Program.ui.Invoke(del) as string;
            try
            {
                var m = System.Text.RegularExpressions.Regex.Match(s, @"^\s*{(.+)}\s*$");
                if (m.Success)
                {
                    //System.Diagnostics.Debug.WriteLine($"match success str:{s}");
                    var strArray = m.Groups[1].Value.Split(',');
                    for (; i < 31; i++)
                    {
                        //var ii = i * i;
                        //var iii = i * i * i;
                        //fy = y0 + y1 * i + y2 * ii;
                        //fx = -0.07f * i;
                        //y = (int)fy;
                        //x = (int)fx;

                        if (!int.TryParse(strArray[i], out y))
                        {
                            //System.Diagnostics.Debug.WriteLine($"parse fail str[{i}]:{s}");
                            return;
                        }// recoil_y[i];
                        x = recoil_x[i];
                        MoveMouse(x, y);
                        Sleep(INTERVAL_M4A1);
                    }
                    LEFTUP();
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine($"match fail str:{s}");
                    return;
                }
                //for (; i < 31; i++)
                //{
                //    y = recoil_y[i];
                //    x = recoil_x[i];
                //    MoveMouse(x, y);
                //    Sleep(INTERVAL_M4A1);
                //}
                //LEFTUP();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
