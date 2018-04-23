using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormMouseMarco
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        public static MyGameConfigurator config;
        public static MyGame game1;
        static void Initialize()
        {
            game1 = new MyGame();
            config = new MyGameConfigurator();
            foreach (var item in config.MacroControllers)
            {
                game1.Keyboard.KeyboardChanged += item.Receptor_KeyboardChanged;
                game1.Mouse.MouseChanged += item.Receptor_MouseChanged;
            }

            game1.SignalToWork();
            game1.Signal.Reset();
            //game1.Mouse.SignalToStopWorking();


            game1.Activate();

#if DEBUG
            {
                var ctrl = config.MacroControllers[1] as SquadRecoilCompensator.SquadMacroController;
                ctrl.lmb.Action = SquadRecoilCompensator.RecoilCompensatorMouseRunner.Auto_G3A3;
            }

#endif

        }
        //protected override void Cleanup()
        //{
        //    mouserunner?.Dispose();
        //    mouserunner = null;
        //    textspeaker?.Dispose();
        //    textspeaker = null;

        //    this.Config = null;

        //    base.Cleanup();
        //}
    }
    public class MyGameConfigurator
    {
        System.Collections.Generic.List<IMacroController> _MacroControllers = new System.Collections.Generic.List<IMacroController>();
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public System.Collections.Generic.List<IMacroController> MacroControllers
        {
            get { return _MacroControllers; }
        }

        public MyGameConfigurator()
        {
            _MacroControllers.Add(new DefaultMacroController());
            _MacroControllers.Add(new SquadRecoilCompensator.SquadMacroController());

            //var typeattr = typeof(DefaultValueAttribute);

            //foreach (var module1 in System.Reflection.Assembly.GetExecutingAssembly().GetModules())
            //{
            //    var types = module1.FindTypes((m, filterCriteria) => { return false; }, null);
            //    foreach (var type1 in types)
            //    {
            //        foreach (var method1 in type1.GetMethods())
            //        {
            //            if (method1.IsPublic && method1.IsStatic)
            //            {
            //                var em = new KeyMacroBinding();
            //                em.Method = method1;

            //                Key k = Key.Unknown;
            //                var arro = method1.GetCustomAttributes(typeattr, false);
            //                if (arro != null && arro.Length > 0)
            //                {
            //                    k = (Key)(arro[0] as DefaultValueAttribute).Value;
            //                }

            //                em.Hotkey = k;
            //                employees.Add(em);
            //            }
            //        }
            //    }
            //}
            //_dict.Add(this.GetType().GetMethod(nameof(Auto_AK74)), this.Hotkey_Mode_Auto);
            //_dict.Add(this.GetType().GetMethod(nameof(Auto_M4A1)), Key.Unknown);
            //_dict.Add(this.GetType().GetMethod(Burst_M4), this.Hotkey_Mode_Burst);
            //_dict.Add(this.GetType().GetMethod(Burst_M4_with_M150, Key.Unknown);
            //_dict.Add(this.GetType().GetMethod(Single_M110_Scoped, this.Hotkey_Mode_Single);
        }
    }
}
