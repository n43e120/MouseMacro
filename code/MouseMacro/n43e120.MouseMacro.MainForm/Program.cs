using n43e120.SimpleGameEngine.Common;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace n43e120.MouseMacro
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

        public static MessageDispatcher game1;
        private static System.Collections.Generic.List<IMessageReceptor> _MacroControllers = new System.Collections.Generic.List<IMessageReceptor>();
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public static System.Collections.Generic.List<IMessageReceptor> MacroControllers
        {
            get { return _MacroControllers; }
        }
        static void AddControllerByAssembly(string filepathassembly)
        {
            var a = System.Reflection.Assembly.LoadFrom(filepathassembly);
            foreach (var type1 in a.GetTypes())
            {
                var arro = type1.GetCustomAttributes(typeof(MacroControllerAttribute), false);
                if (arro != null && arro.Length > 0)
                {
                }
                else
                {
                    continue;
                }
                _MacroControllers.Add(Activator.CreateInstance(type1) as IMessageReceptor);
            }
        }
        static void Initialize()
        {
            //if (!GC.TryStartNoGCRegion(1000000))
            //{
            //    MessageBox.Show("can not disable garbage collection");
            //}

            game1 = new n43e120.SimpleGameEngine.User32API.GameEngineViaUser32API();
            //_MacroControllers.Add(new DefaultMacroController());
            
            var moddir = new System.IO.DirectoryInfo(System.IO.Path.Combine(Environment.CurrentDirectory, "mod"));
            if (moddir.Exists)
            {
                foreach (var lib in moddir.GetFiles()) //"*.dll" "*.exe"
                {
                    try
                    {
                        AddControllerByAssembly(lib.FullName);
                    }
                    catch (System.BadImageFormatException)
                    {
                        continue;
                    }
                }
            }

            //#if DEBUG
            //            {
            //                var ctrl = config.MacroControllers[1] as SquadRecoilCompensator.SquadMacroController;
            //                //ctrl.lmb.Action = SquadRecoilCompensator.RecoilCompensatorMouseRunner.Auto_L85A2;
            //                ctrl.lmb.Action = SquadRecoilCompensator.RecoilCompensatorMouseRunner.Single_Pistol_dadada;
            //            }

            //#endif
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

        public MyGameConfigurator()
        {
            //_MacroControllers.Add(new RedOrchestraRecoilCompensator.RedOrchestraMacroController());

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
