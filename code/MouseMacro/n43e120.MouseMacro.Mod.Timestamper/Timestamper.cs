using n43e120.Interop.WinAPI;
using n43e120.MouseMacro.Design;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace n43e120.MouseMacro.Mod.Timestamper
{
    [MacroController]
    [TypeConverter(typeof(DisplayNameAbleConverter))]
    [DisplayName("Paste current UTC time")]
    public class TimestamperMacroController : DefaultMacroController
    {
        public static string GetStandardUTCDateString(DateTime d)
        {
            return d.ToUniversalTime().ToString("u");
        }
        public static string GetStandardUTCDateStringNow()
        {
            return GetStandardUTCDateString(DateTime.UtcNow);
        }
        [MacroAction]
        [Description("Paste text of current time")]
        [DefaultValue(Keys.F7)]
        public void PasteTimestamp()
        {
            var stimestamp = GetStandardUTCDateStringNow();
            Clipboard.SetText(stimestamp);
            user32helper.CTRL_V();
        }
    }
}
