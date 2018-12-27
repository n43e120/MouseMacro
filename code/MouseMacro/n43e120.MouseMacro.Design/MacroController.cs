using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using n43e120.Interop.WinAPI;
using n43e120.MouseMacro.Design;
using n43e120.SimpleGameEngine.Common;

namespace n43e120.MouseMacro
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MacroControllerAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class MacroActionAttribute : Attribute
    {
    }
    [MacroController]
    [TypeConverter(typeof(DisplayNameAbleConverter))]//[TypeConverter(typeof(ExpandableObjectConverter))]
    [DisplayName("Default")]
    public class DefaultMacroController : IMessageReceptor
    {
        //[MacroAction]
        //[DefaultValue(Key.F9)]
        //public static void StopResponseMouse()
        //{
        //    Program.game1.Stop();
        //    //System.Environment.Exit(0);
        //}
        //[MacroAction]
        //[DefaultValue(Key.F4)]
        //public static void StartResponseMouse()
        //{
        //    Program.game1.Start();
        //    //System.Environment.Exit(0);
        //}
        [MacroAction]
        [DefaultValue(Keys.F12)]
        public static void EmergencyExit()
        {
            System.Environment.Exit(0);
        }

        public unsafe virtual void WndProc(IntPtr msg)
        {
            var m = (MSG*)msg;
            switch ((WM)m->message)
            {
                case WM.WM_KEYUP:
                    KBDLLHOOKSTRUCT* p = (KBDLLHOOKSTRUCT*)m->lParam;
                    var k = (Keys)p->vkCode;
                    foreach (var item in this.KeyboardKeyBindings)
                    {
                        var kb = item as KeyMacroBinding;
                        if (kb.Hotkey == k)
                        {
                            kb.Action();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        //public virtual void Receptor_KeyboardChanged(object sender, KeyboardState keyboardstate)
        //{
        //    if (keyboardstate.PressedKeys.Count != 1)
        //    {
        //        return;
        //    }
        //    var k = keyboardstate.PressedKeys[0];
        //    foreach (var item in this.KeyboardKeyBindings)
        //    {
        //        if (keyboardstate.PressedKeys.Count == 1)
        //        {
        //            var kb = item as KeyMacroBinding;
        //            if (kb.Hotkey == k)
        //            {
        //                kb.Action();
        //            }
        //        }
        //    }
        //}
        //public virtual void Receptor_MouseChanged(object sender, MouseState mousestate)
        //{

        //    //foreach (var item in this.MouseKeyBindings)
        //    //{
        //    //    var b = item as MouseMacroBinding;
        //    //    var i = b.Button;

        //    //    if (mousestate.Buttons[i]) //left mouse button pressed
        //    //    {
        //    //        if (isMouseButtonXDown[i])
        //    //        {

        //    //        }
        //    //        else //LMB down
        //    //        {
        //    //            isMouseButtonXDown[i] = true;
        //    //            mouserunner.SignalToWork();
        //    //            //_signal.Set();
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        if (isMouseButtonXDown[i]) //LMB up
        //    //        {
        //    //            isMouseButtonXDown[i] = false;
        //    //            mouserunner.SignalToStopWorking();
        //    //        }
        //    //        else
        //    //        {

        //    //        }
        //    //    }
        //    //}
        //    var bs = mousestate.Buttons;
        //    for (int i = 0; i < bs.Length; i++)
        //    {
        //        if (mousestate.Buttons[i])
        //        {
        //            Console.WriteLine(i);
        //            return;
        //        }
        //    }
        //}

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
                    em.Hotkey = (Keys)(arro[0] as DefaultValueAttribute).Value;
                }
                keybindings.Add(em);
            }
        }
    }
}