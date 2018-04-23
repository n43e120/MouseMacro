using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMouseMarco
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            //this.linkLabel1.Text += $"  link to gitHub project";
        }
        FormSetting frmSetting;
        void InitFormSetting()
        {
            frmSetting = new FormSetting();
            frmSetting.propertyGrid1_SelectedObject = Program.config;
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (frmSetting == null)
            {
                InitFormSetting();
            }
            else if (frmSetting.IsDisposed)
            {
                InitFormSetting();
            }
            frmSetting.Show();
        }
        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/n43e120/MouseMacro");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.DoEvents();
            //Application.Exit();
            //Application.ExitThread();
            System.Environment.Exit(0);
        }
    }
}
