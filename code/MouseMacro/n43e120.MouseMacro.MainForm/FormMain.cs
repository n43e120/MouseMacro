using n43e120.SimpleGameEngine;
using n43e120.SimpleGameEngine.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace n43e120.MouseMacro
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Initialize();
        }
        private void Initialize()
        {
            //this.Text += $" {System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion}";
            foreach (var c in Program.MacroControllers)
            {
                this.checkedListBox1.Items.Add(c);
            }
            checkedListBox1_SelectedValueChanged(null, null);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.pictureBox2.BackColor = Color.Transparent;
            //this.BackColor = Color.Green;
            //this.TransparencyKey = this.BackColor;
            //COMMAND_DECTIVATE();
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.DoEvents();
            //Application.Exit();
            //Application.ExitThread();

            Application.Exit();
            System.Environment.Exit(0);
        }
        private void VisitLink()
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/n43e120/MouseMacro");
                linkLabel1.LinkVisited = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VisitLink();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VisitLink();
        }

        void COMMAND_ACTIVATE()
        {
            foreach (var item in this.checkedListBox1.CheckedItems)
            {
                Program.game1.evMessage += (item as IMessageReceptor).WndProc;
            }
            (Program.game1 as ISignalOnOff).Start();
        }
        void COMMAND_DECTIVATE()
        {
            (Program.game1 as ISignalOnOff).Stop();
            Program.game1.ClearAllSubscribers();
        }
        bool _IsActive = false;
        public bool IsActive
        {
            get { return _IsActive; }
            set {
                lock (this)
                {
                    if (value == _IsActive)
                    {
                        return;
                    }
                    if (value)
                    {
                        if (this.checkedListBox1.CheckedItems.Count <= 0)
                        {
                            return;
                        }
                        this.picSwitch.Image = global::n43e120.MouseMacro.Properties.Resources.switch_on;
                        this.gboxSetting.Visible = false;
                        this.btnSetting.Visible = false;
                        COMMAND_ACTIVATE();
                    }
                    else
                    {
                        COMMAND_DECTIVATE();

                        this.picSwitch.Image = global::n43e120.MouseMacro.Properties.Resources.switch_off;
                        this.gboxSetting.Visible = true;
                        this.btnSetting.Visible = true;
                    }
                    _IsActive = value;
                }
            }
        }


        private void picSwitch_Click(object sender, EventArgs e)
        {
            this.IsActive = !this.IsActive;
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSetting.Enabled = checkedListBox1.SelectedItem != null;
        }
        FormSetting frmSetting;
        void InitFormSetting()
        {
            frmSetting = new FormSetting();
            //frmSetting.propertyGrid1_SelectedObject = Program.MacroControllers;
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem == null)
            {
                btnSetting.Enabled = false;
            }
            if (frmSetting == null)
            {
                InitFormSetting();
            }
            else if (frmSetting.IsDisposed)
            {
                InitFormSetting();
            }
            frmSetting.propertyGrid1_SelectedObject = checkedListBox1.SelectedItem;
            frmSetting.Show();
        }
        #region 无边框拖动效果 //http://www.cnblogs.com/huanjun/p/8625686.html
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox2.BackColor = SystemColors.Control;
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox2.BackColor = Color.Red;
            //拖动窗体
            //ReleaseCapture();
            //SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2_MouseDown(sender, e);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (this.checkedListBox1)
            {
                var selected = checkedListBox1.SelectedItem;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.Items[i] == selected)
                    {
                        continue;
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

    }
}
