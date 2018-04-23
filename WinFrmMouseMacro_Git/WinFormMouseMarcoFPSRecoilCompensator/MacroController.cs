using SharpDX.DirectInput;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace WinFormMouseMarco
{
    public interface IMacroController
    {
        void Receptor_MouseChanged(object sender, MouseState mousestate);
        void Receptor_KeyboardChanged(object sender, KeyboardState keyboardstate);
    }
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class MacroActionAttribute : Attribute
    {
    }
    [TypeConverter(typeof(DisplayNameAbleConverter))]//[TypeConverter(typeof(ExpandableObjectConverter))]
    [DisplayName("Default")]
    public class DefaultMacroController : IMacroController
    {
        [MacroAction]
        [DefaultValue(Key.F9)]
        public static void StopResponseMouse()
        {
            Program.game1.Mouse.SignalToStopWorking();
            //System.Environment.Exit(0);
        }
        [MacroAction]
        [DefaultValue(Key.F4)]
        public static void StartResponseMouse()
        {
            Program.game1.Mouse.SignalToWork();
            //System.Environment.Exit(0);
        }
        [MacroAction]
        public static void EmergencyExit()
        {
            System.Environment.Exit(0);
        }
        
        //MouseMacroBindingCollection mousebindings = new MouseMacroBindingCollection();
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        //public virtual MouseMacroBindingCollection MouseKeyBindings
        //{
        //    get { return mousebindings; }
        //}
        //public virtual MouseRunner mouserunner { get; set; }
        //bool[] isMouseButtonXDown = { false, false, false };//, false, false, false, false, false, false, false };
        public virtual void Receptor_MouseChanged(object sender, MouseState mousestate)
        {
            //foreach (var item in this.MouseKeyBindings)
            //{
            //    var b = item as MouseMacroBinding;
            //    var i = b.Button;

            //    if (mousestate.Buttons[i]) //left mouse button pressed
            //    {
            //        if (isMouseButtonXDown[i])
            //        {

            //        }
            //        else //LMB down
            //        {
            //            isMouseButtonXDown[i] = true;
            //            mouserunner.SignalToWork();
            //            //_signal.Set();
            //        }
            //    }
            //    else
            //    {
            //        if (isMouseButtonXDown[i]) //LMB up
            //        {
            //            isMouseButtonXDown[i] = false;
            //            mouserunner.SignalToStopWorking();
            //        }
            //        else
            //        {

            //        }
            //    }
            //}
        }

        KeyMacroBindingCollection keybindings = new KeyMacroBindingCollection();
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual KeyMacroBindingCollection KeyboardKeyBindings
        {
            get { return keybindings; }
        }
        /// <summary>
        /// Editor bug, must have this a dummy property to display other properties
        /// </summary>
        [Browsable(false)]
        public int MyProperty { get; set; }
        public virtual void Receptor_KeyboardChanged(object sender, KeyboardState keyboardstate)
        {
            if (keyboardstate.PressedKeys.Count != 1)
            {
                return;
            }
            var k = keyboardstate.PressedKeys[0];
            foreach (var item in this.KeyboardKeyBindings)
            {
                if (keyboardstate.PressedKeys.Count == 1)
                {
                    var kb = item as KeyMacroBinding;
                    if (kb.Hotkey == k)
                    {
                        kb.Action();
                    }
                }
            }
        }
        public DefaultMacroController()
        {
            var typeattr = typeof(DefaultValueAttribute);
            var type1 = this.GetType();
            foreach (var method1 in type1.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Instance))
            {
                //if (method1.IsPublic)//&& method1.IsStatic)
                //{
                //}
                var arro = method1.GetCustomAttributes(typeof(MacroActionAttribute), false);
                if (arro != null && arro.Length > 0)
                {
                }
                else
                {
                    continue;
                }

                var em = new KeyMacroBinding();
                //this.GetType().GetMethod("dummy").CreateDelegate(typeof(Action), this) as Action;
                if (method1.IsStatic)
                {
                    em.Action = method1.CreateDelegate(typeof(Action)) as Action;
                }
                else
                {
                    em.Action = method1.CreateDelegate(typeof(Action), this) as Action;
                }

                arro = method1.GetCustomAttributes(typeattr, false);
                if (arro != null && arro.Length > 0)
                {
                    var k = Key.Unknown;
                    k = (Key)(arro[0] as DefaultValueAttribute).Value;
                    em.Hotkey = k;
                }
                keybindings.Add(em);
            }
        }
    }
}