using System;
using System.Threading;
using System.Windows.Forms;

namespace WinFormMouseMarco
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        public object propertyGrid1_SelectedObject
        {
            get { return this.propertyGrid1.SelectedObject; }
            set {
                this.propertyGrid1.SelectedObject = value;
            }
        }
        //void CleanUp()
        //{
        //    game1?.Dispose();
        //    game1 = null;
        //}

        //void SignalOn()
        //{
        //    this.game1.SignalOn();
        //    switch (this.game1.Thread.ThreadState)
        //    {
        //        case ThreadState.Unstarted:
        //            this.game1.StartWorkThread();
        //            break;
        //        default:
        //            break;
        //    }
        //    //this.game1.Config.Enabled = true;
        //    //this.checkBox1.Checked = true;
        //}
        //void SignalOff()
        //{
        //    this.game1.Mouse.SignalOff();
        //    //this.game1.Config.Enabled = false;
        //    //this.checkBox1.Checked = false;
        //}
    }
}
