using PInvoke;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using static PInvoke.User32.mouse_eventFlags;

namespace WinFormMouseMarco.SquadRecoilCompensator
{
    public class RecoilCompensatorMouseRunner : MouseRunner
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
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 6; //7
            int y = 0;
            int x = -1;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKS74()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 6; //7
            int y = 0;
            int x = -1;
            for (int i = 0; i < 20; i++)
            {
                y = i / a + b;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKS74U()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 4;
            const int b = 7; //7
            int y = 0;
            int x = 0;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKS74_1P78()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 17;
            int y = 0;
            int x = -1;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_RPK74()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            const int b = 5;
            int y = 0;
            int x = -1;
            for (int i = 0; i < 15; i++) //46 bullets per round
            {
                y = i / a + b;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_AKM()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            const int b = 5;
            int y = 0;
            int i = 0;
            int x = -1;
            for (; i < 30; i++) //30 bullets per round
            {
                x = i / -6 + -1;
                y = i / a + b;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_PKM()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int b = 8;
            int y = 0;
            int x = 0;
            int i = 0;

            y = b;
            for (; i < 16; i++) //46 bullets per round
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 6;
            const int b = 9;
            int y = 0;
            int x = -1;
            int i = 0;

            for (; i < 25; i++) //46 bullets per round
            {
                y = b + i / a;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249_PIP_M68()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 6;
            const int b = 9;
            int y = 0;
            int x = -1;
            int i = 0;

            for (; i < 30; i++) //46 bullets per round
            {
                y = b + i / a;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249_PIP_M145_Scoped()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 6;
            const int b = 25;
            int y = 0;
            int x = -1;
            int i = 0;

            for (; i < 25; i++) //46 bullets per round
            {
                y = b + i / a;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M249_PIP_M145_hip()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int b = 17;
            int y = 0;
            int x = -1;
            int i = 0;

            y = b;
            for (; i < 25; i++) //46 bullets per round
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_M240B()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int b = 12;
            int y = 0;
            int x = -1;
            int i = 0;

            y = b;
            for (; i < 25; i++) //46 bullets per round
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            x--;
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Single_M110_SPSS()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, 50, 0, IntPtr.Zero);
        }
        public static void Single_SVD()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, 40, 0, IntPtr.Zero);
        }
        //public static void Single_SKS()
        //{
        //}
        public static void Single_AK74()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);

            //if 0 then -1, if 1 then 0;  50% chance 0, 50% chances give -1
            var tick = unchecked((int)DateTime.Now.Ticks & 1);
            tick--;
            User32.mouse_event(MOUSEEVENTF_MOVE, tick, 5, 0, IntPtr.Zero);
        }
        static int[] Single_AK74_dadada_ys = new int[] { 6, 8 };//, 15 };
        public static void Single_AK74_dadada()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            int i = 0;
            //for (; i < 2; i++) 
            //{
            //    User32.mouse_event(MOUSEEVENTF_MOVE, 0, i+5, 0, IntPtr.Zero);
            //    Thread.Sleep(120);
            //    User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            //}
            foreach (var item in Single_AK74_dadada_ys)
            {
                i = item;
                User32.mouse_event(MOUSEEVENTF_MOVE, 0, i, 0, IntPtr.Zero);
                Thread.Sleep(120 - INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
                User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
                User32.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
            }
            //for (; i < 30; i++) //46 bullets per round
            //{
            //    //if 0 then -1, if 1 then 0;  50% chance 0, 50% chances give -1
            //    var tick = unchecked((int)DateTime.Now.Ticks & 1);
            //    tick--;
            //    User32.mouse_event(MOUSEEVENTF_MOVE, tick, 7, 0, IntPtr.Zero);
            //    Thread.Sleep(120);
            //    User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            //}
        }
        public static void Single_Pistol_dadada()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            for (int i = 0; i < 30; i++) //46 bullets per round
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, 0, 3, 0, IntPtr.Zero);
                Thread.Sleep(70);
                User32.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            }
        }
        public static void Single_M4()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, 5, 0, IntPtr.Zero);
        }
        public static void Burst_M4()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            User32.mouse_event(MOUSEEVENTF_MOVE, -1, 9, 0, IntPtr.Zero);
            Thread.Sleep(INTERVAL_M4);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, 9, 0, IntPtr.Zero);
            Thread.Sleep(INTERVAL_M4);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, -7, 0, IntPtr.Zero);
        }
        public static void Burst_M4_with_M150()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, 37, 0, IntPtr.Zero);
            Thread.Sleep(INTERVAL_M4);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, 9, 0, IntPtr.Zero);
            Thread.Sleep(INTERVAL_M4);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, -24, 0, IntPtr.Zero);
        }
        public static void Single_M4_with_M150()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            User32.mouse_event(MOUSEEVENTF_MOVE, 0, 9, 0, IntPtr.Zero);
            Thread.Sleep(INTERVAL_M4);
        }
        public static void Auto_M4A1()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 3;
            const int b = 5;
            int y = 0;
            int x = 0;
            for (int i = 0; i < 30; i++)
            {
                y = i / a + b;
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_M4);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
        public static void Auto_G3A3()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            int y = 0;
            int i = 0;
            int x = -1;
            for (; i < 30; i++) //30 bullets per round
            {
                x = Math.Min(i / a + 0, 6);
                y = Math.Min(i / a + 9, 27);
                User32.mouse_event(MOUSEEVENTF_MOVE, -x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_G3A4()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 1;
            int y = 0;
            int i = 0;
            int x = -1;
            for (; i < 30; i++) //30 bullets per round
            {
                x = Math.Min(i / a + 0, 6);
                y = Math.Min(i / a + 9, 27);
                User32.mouse_event(MOUSEEVENTF_MOVE, -x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
        }
        public static void Auto_PPSh41()
        {
            Thread.Sleep(INTERVAL_DELAY_AFTER_FIRST_TRIGGER);
            const int a = 4;
            const int b = 7; //7
            int y = 0;
            int x = 0;
            for (int i = 0; i < 30; i++)
            {
                y = Math.Min(i / a + b, 6);
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            }
            do
            {
                User32.mouse_event(MOUSEEVENTF_MOVE, x, y, 0, IntPtr.Zero);
                Thread.Sleep(INTERVAL_AK);
            } while (true);
        }
    }
    public class RecoilCompensatorMouseRunnerConverter : ExpandableObjectConverter
    {
        public static string ConvertToString(RecoilCompensatorMouseRunner v)
        {
            var strMethod = "No Action";
            switch (v.Action)
            {
                case null:
                    break;
                default:
                    strMethod = v.Action.Method.Name;
                    break;
            }
            return $"{strMethod}";
        }
        public override object ConvertTo(ITypeDescriptorContext context,
                                  System.Globalization.CultureInfo culture,
                                  object value, Type destType)
        {
            if (destType == typeof(string) && value is RecoilCompensatorMouseRunner)
            {
                //var emp = (KeyMacroBinding)value;
                //return emp.Department + "," + emp.Role;
                //return emp.Hotkey.ToString();
                return ConvertToString((RecoilCompensatorMouseRunner)value);
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    [TypeConverter(typeof(DisplayNameAbleConverter))]//[TypeConverter(typeof(ExpandableObjectConverter))]
    [DisplayName("Squad")]
    public class SquadMacroController : DefaultMacroController
    {
        //[Browsable(false)]
        [TypeConverter(typeof(RecoilCompensatorMouseRunnerConverter))]//[TypeConverter(typeof(ExpandableObjectConverter))]
        [DisplayName("Left Mouse Button")]
        public virtual MouseRunner lmb { get; set; }
        [Browsable(false)]
        public TextSpeaker textspeaker { get; set; }

        //[TypeConverter(typeof(StaticActionConverter))]
        //[Description("Button Down To Act, Up to Stop Acting")]
        //public Action LMB
        //{
        //    get { return this.mouserunner.Action; }
        //    set { this.mouserunner.Action = value; }
        //}
        /// <summary>
        /// inspired by reference https://www.cnblogs.com/kongbailingluangan/p/6243351.html
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="PropertyName"></param>
        /// <param name="attr"></param>
        public static void AddAttributeToProperty(object obj, string PropertyName, Attribute attr)
        {
            PropertyDescriptorCollection pds = TypeDescriptor.GetProperties(obj);
            var pd = pds[PropertyName];
            var ac = pd.Attributes;
            FieldInfo info = typeof(AttributeCollection).GetField("_attributes", BindingFlags.Instance | BindingFlags.NonPublic);// | BindingFlags.CreateInstance);
            var _attributes = info.GetValue(ac) as Attribute[];
            var lst = new List<Attribute>(_attributes);
            lst.Add(attr);
            _attributes = lst.ToArray();
            info.SetValue(ac, _attributes);
        }
        public SquadMacroController() : base()
        {
            lmb = new RecoilCompensatorMouseRunner();
            AddAttributeToProperty(lmb, "Signal", new BrowsableAttribute(false));
            AddAttributeToProperty(lmb, "Thread", new BrowsableAttribute(false));
            AddAttributeToProperty(lmb, "ThreadStart", new BrowsableAttribute(false));

            textspeaker = new TextSpeaker();
        }
        //public void Receptor_KeyboardChanged(object sender, KeyboardState keyboardstate)
        //{
        //    throw new NotImplementedException();
        //}
        private bool leftMouseDown;
        public override void Receptor_MouseChanged(object sender, MouseState mousestate)
        {
            if (this.lmb.Action == null)
            {
                return;
            }

            if (mousestate.Buttons[0]) //left mouse button pressed
            {
                if (leftMouseDown)
                {

                }
                else //LMB down
                {
                    leftMouseDown = true;
                    lmb.SignalToWork();
                    //_signal.Set();
                }
            }
            else
            {
                if (leftMouseDown) //LMB up
                {
                    leftMouseDown = false;
                    lmb.SignalToStopWorking();
                }
                else
                {

                }
            }
        }
        void Speak(string txt)
        {
            textspeaker.script = txt;
            textspeaker.SignalToRestart();
        }
        void TTSspeak(System.Action act)
        {
            if (act == null)
            {
                Speak("Left Mouse Button Macro Off");
            }
            else
            {
                Speak(act.Method.Name.ToString().Replace('_', ' '));
            }
        }
        ////https://blog.csdn.net/hfzsjz/article/details/4351392
        //[DllImport("dll", EntryPoint = "mouse_event")]
        //static extern void mouse_event(
        //        int dwFlags,
        //        int dx,
        //        int dy,
        //        int cButtons,
        //        int dwExtraInfo
        //    );

        //[DllImport("dll", EntryPoint = "keybd_event")]
        //static extern void keybd_event(
        //    byte bVk,
        //    byte bScan,
        //    int dwFlags,
        //    int dwExtraInfo
        //);

        //const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        //const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        //const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        //const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        //const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        //const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        //const int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
        //const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        public bool TryChangeMode(System.Action act)
        {
            if (lmb.Action == act)
            {
                return false;
            }
            else
            {
                lmb.Action = act;
                return true;
            }
        }
        Action lastaction;
        [MacroAction]
        [Category("Squad Recoil Compensator")]
        [Description("Hotkey to Switch Macro for LMB")]
        [DefaultValue(Key.F8)]
        public void SwitchOff()
        {
            if (this.lmb.Action == null)
            {
                if (this.lastaction == null)
                {
                    return;
                }
                else
                {
                    var a = lastaction;
                    lastaction = null;
                    this.lmb.Action = a;
                    TTSspeak(a);
                    this.lmb.SignalToStopWorking();
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
            }
            else
            {
                lastaction = this.lmb.Action;
                if (TryChangeMode(null))
                {
                    TTSspeak(null);
                    this.lmb.SignalToStopWorking();
                    System.Media.SystemSounds.Hand.Play();
                }
            }
        }
        [MacroAction]
        [Category("Squad Recoil Compensator")]
        [Description("Hotkey to Switch Macro for LMB")]
        [DefaultValue(Key.F5)]
        public void SWITCH_TO_Auto_AK74()
        {
            System.Action act = RecoilCompensatorMouseRunner.Auto_AK74;
            if (TryChangeMode(act))
            {
                TTSspeak(act);
                this.lmb.SignalToStopWorking();
                System.Media.SystemSounds.Beep.Play();
            }
        }
        [MacroAction]
        [Category("Squad Recoil Compensator")]
        [Description("Hotkey to Switch Macro for LMB")]
        [DefaultValue(Key.Unknown)]
        public void SWITCH_TO_Auto_M4A1()
        {
            System.Action act = RecoilCompensatorMouseRunner.Auto_M4A1;
            if (TryChangeMode(act))
            {
                TTSspeak(act);
                this.lmb.SignalToStopWorking();
                System.Media.SystemSounds.Beep.Play();
            }
        }
        [MacroAction]
        [Category("Squad Recoil Compensator")]
        [Description("Hotkey to Switch Macro for LMB")]
        [DefaultValue(Key.F6)]
        public void SWITCH_TO_Burst_M4()
        {
            System.Action act = RecoilCompensatorMouseRunner.Burst_M4;
            if (TryChangeMode(act))
            {
                TTSspeak(act);
                this.lmb.SignalToStopWorking();
                System.Media.SystemSounds.Beep.Play();
            }
        }
        [MacroAction]
        [Category("Squad Recoil Compensator")]
        [Description("Hotkey to Switch Macro for LMB")]
        [DefaultValue(Key.Unknown)]
        public void SWITCH_TO_Burst_M4_with_M150()
        {
            System.Action act = RecoilCompensatorMouseRunner.Burst_M4_with_M150;
            if (TryChangeMode(act))
            {
                TTSspeak(act);
                this.lmb.SignalToStopWorking();
                System.Media.SystemSounds.Beep.Play();
            }
        }
        [MacroAction]
        [Category("Squad Recoil Compensator")]
        [Description("Hotkey to Switch Macro for LMB")]
        [DefaultValue(Key.F7)]
        public void SWITCH_TO_Single_Pistol_dadada()
        {
            System.Action act = RecoilCompensatorMouseRunner.Single_Pistol_dadada;
            if (TryChangeMode(act))
            {
                TTSspeak(act);
                this.lmb.SignalToStopWorking();
                System.Media.SystemSounds.Beep.Play();
            }
        }
    }
}
