using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using n43e120.Interop.WinAPI;
using n43e120.MouseMacro.Design;

namespace n43e120.MouseMacro.Mod.SquadRecoilCompensator
{
    public class ActorConverter : ExpandableObjectConverter
    {
        public static string ConvertToString(Actor v)
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
            if (destType == typeof(string) && value is Actor)
            {
                //var emp = (KeyMacroBinding)value;
                //return emp.Department + "," + emp.Role;
                //return emp.Hotkey.ToString();
                return ConvertToString((Actor)value);
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    [MacroController]
    [TypeConverter(typeof(DisplayNameAbleConverter))]//[TypeConverter(typeof(ExpandableObjectConverter))]
    [DisplayName("Squad")]
    public class SquadMacroController : DefaultMacroController
    {
        [Category("Key")]
        [DisplayName("Trigger")]
        [Description("The trigger key which starts the action while pressing, which stops and resets at release.")]
        public System.Windows.Forms.Keys Trigger { get; } = System.Windows.Forms.Keys.LButton;
        [Category("Key")]
        [DisplayName("Inhibitor")]
        [Description("When inhibitor key state is on, it prevents action from being triggered.")]
        public System.Windows.Forms.Keys Inhibitor { get; } = System.Windows.Forms.Keys.Scroll;
        //[Browsable(false)]
        [Category("Action")]
        [DisplayName("Action")]
        [TypeConverter(typeof(ActorConverter))]//[TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual Actor Actor { get; set; }
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
            Actor = new RecoilCompensatorMouseRunner_v12_1();
            AddAttributeToProperty(Actor, "Signal", new BrowsableAttribute(false));
            AddAttributeToProperty(Actor, "Thread", new BrowsableAttribute(false));
            AddAttributeToProperty(Actor, "ThreadStart", new BrowsableAttribute(false));

            textspeaker = new TextSpeaker();
        }

        private bool leftMouseDown;
        public unsafe override void WndProc(IntPtr msg)
        {
            var m = (MSG*)msg;
            switch ((WM)m->message)
            {
                case WM.WM_LBUTTONDOWN:
                    if (this.Actor.Action == null || leftMouseDown)
                    {
                        return;
                    }
                    if (user32helper.ScrollLock)
                    {
                        break;
                    }
                    leftMouseDown = true;
                    Actor.Start();
                    break;
                case WM.WM_LBUTTONUP:
                    if (!leftMouseDown)
                    {
                        return;
                    }
                    Actor.Stop();
                    leftMouseDown = false;
                    break;
                default:
                    break;
            }
            base.WndProc(msg);
        }
        //void Speak(string txt)
        //{
        //    textspeaker.script = txt;
        //    textspeaker.Restart();
        //}
        //void TTSspeak(System.Action act)
        //{
        //    if (act == null)
        //    {
        //        Speak("Left Mouse Button Macro Off");
        //    }
        //    else
        //    {
        //        Speak(act.Method.Name.ToString().Replace('_', ' '));
        //    }
        //}
        //public bool TryChangeMode(System.Action act)
        //{
        //    if (Actor.Action == act)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        Actor.Action = act;
        //        return true;
        //    }
        //}
        //Action lastaction;
        //[MacroAction]
        //[Category("Squad Recoil Compensator")]
        //[Description("Hotkey to Switch Macro for LMB")]
        //[DefaultValue(Keys.F8)]
        //public void SwitchOff()
        //{
        //    if (this.Actor.Action == null)
        //    {
        //        if (this.lastaction == null)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            var a = lastaction;
        //            lastaction = null;
        //            this.Actor.Action = a;
        //            TTSspeak(a);
        //            this.Actor.Stop();
        //            System.Media.SystemSounds.Beep.Play();
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        lastaction = this.Actor.Action;
        //        if (TryChangeMode(null))
        //        {
        //            TTSspeak(null);
        //            this.Actor.Stop();
        //            System.Media.SystemSounds.Hand.Play();
        //        }
        //    }
        //}
        //private void TrySwitchToMode(System.Action act)
        //{
        //    if (TryChangeMode(act))
        //    {
        //        TTSspeak(act);
        //        this.Actor.Stop();
        //        System.Media.SystemSounds.Beep.Play();
        //    }
        //}
        //[MacroAction]
        //[Category("Squad Recoil Compensator")]
        //[Description("Hotkey to Switch Macro for LMB")]
        //[DefaultValue(Keys.F5)]
        //public void SWITCH_TO_Auto_AK74()
        //{
        //    System.Action act = RecoilCompensatorMouseRunner.Auto_AK74;
        //    TrySwitchToMode(act);
        //}
        //[MacroAction]
        //[Category("Squad Recoil Compensator")]
        //[Description("Hotkey to Switch Macro for LMB")]
        //[DefaultValue(Keys.None)]
        //public void SWITCH_TO_Auto_M4A1()
        //{
        //    System.Action act = RecoilCompensatorMouseRunner.Auto_M4A1;
        //    TrySwitchToMode(act);
        //}
        //[MacroAction]
        //[Category("Squad Recoil Compensator")]
        //[Description("Hotkey to Switch Macro for LMB")]
        //[DefaultValue(Keys.F6)]
        //public void SWITCH_TO_Burst_M4()
        //{
        //    System.Action act = RecoilCompensatorMouseRunner.Burst_M4;
        //    TrySwitchToMode(act);
        //}
        //[MacroAction]
        //[Category("Squad Recoil Compensator")]
        //[Description("Hotkey to Switch Macro for LMB")]
        //[DefaultValue(Keys.None)]
        //public void SWITCH_TO_Burst_M4_with_M150()
        //{
        //    System.Action act = RecoilCompensatorMouseRunner.Burst_M4_with_M150;
        //    TrySwitchToMode(act);
        //}
        //[MacroAction]
        //[Category("Squad Recoil Compensator")]
        //[Description("Hotkey to Switch Macro for LMB")]
        //[DefaultValue(Keys.F7)]
        //public void SWITCH_TO_Single_Pistol_dadada()
        //{
        //    System.Action act = RecoilCompensatorMouseRunner.Single_Pistol_dadada;
        //    TrySwitchToMode(act);
        //}
    }
}
