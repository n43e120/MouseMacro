using n43e120.Interop.WinAPI;
using n43e120.MouseMacro.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n43e120.MouseMacro.Mod.FileOpener
{
    [MacroController]
    [TypeConverter(typeof(DisplayNameAbleConverter))]
    [DisplayName("Open File")]
    public class FileOpener : DefaultMacroController
    {
        [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Filepath { get; set; } = "notepad.exe";
        [MacroAction]
        [Description("Open/Execute the File")]
        [DefaultValue(Keys.F5)]
        public void OpenFile()
        {   //if (System.IO.File.Exists(Filepath))
            //{
            //}                
            if (!string.IsNullOrWhiteSpace(Filepath))
            {
                try
                {
                    System.Diagnostics.Process.Start(Filepath);
                }
                catch (Exception)
                {
                    MessageBox.Show($"failed to open file {Filepath}");
                    throw;
                }
            }
        }
    }
}
