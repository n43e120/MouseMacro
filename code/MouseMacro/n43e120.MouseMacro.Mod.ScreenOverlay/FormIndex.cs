using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormIndex : Form
    {
        public class MyAppConfig
        {

            [Category("config"), Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public string Filename { get; set; }

            //[Category("config"), DefaultValue(ContentAlignment.MiddleCenter)]
            //public ContentAlignment ImageAlign { get; set; }

            [Category("config"), DefaultValue(typeof(System.Drawing.Point),"0,0")]
            public Point DesktopLocation { get; set; }

            [Browsable(false), Category("runtime status")]
            public bool Visible { get; set; }
        }
        FormDesktopCrosshair frmCrosshair;
        System.IO.Stream streamImg;
        MyAppConfig myappconfig;
        public FormIndex()
        {
            InitializeComponent();
            Initialize();
        }
        void Initialize()
        {

            try
            {
                myappconfig = new MyAppConfig();

                var offset = System.Configuration.ConfigurationManager.AppSettings.Get("offset");
                myappconfig.DesktopLocation = (Point)new PointConverter().ConvertFromString(offset);

                var filename = System.Configuration.ConfigurationManager.AppSettings.Get("filename_img");
                myappconfig.Filename = filename;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            //myappconfig.ImageAlign = ContentAlignment.MiddleCenter;
            //myappconfig.Offset = Point.Empty;
            //1920/2 - 64/2==928
            //1080/2 - 64/2==508
            this.propertyGrid1.SelectedObject = myappconfig;

            try
            {
                frmCrosshair = new FormDesktopCrosshair();

                var rect = Screen.PrimaryScreen.Bounds;
                frmCrosshair.Size = rect.Size;


                var b = new Binding("DesktopLocation", myappconfig, "DesktopLocation");
                frmCrosshair.DataBindings.Add(b);
                //var offset = myappconfig.DesktopLocation;
                //(frmCrosshair as FormDesktopCrosshair).SetDesktopLocation(offset.X, offset.Y);


                var fs = new System.IO.FileStream(myappconfig.Filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                //this.textBox1.Text = filename;
                streamImg = fs;
                var img = new Bitmap(streamImg);
                frmCrosshair.BackgroundImage = img;


                frmCrosshair.DataBindings.Add("Visible", myappconfig, "Visible", false, DataSourceUpdateMode.OnPropertyChanged);
                //this.checkBox1.DataBindings.Add("Checked", frmCrosshair, "Visible", false, DataSourceUpdateMode.OnPropertyChanged);
                this.checkBox1.DataBindings.Add("Checked", myappconfig, "Visible", false, DataSourceUpdateMode.OnPropertyChanged);

                frmCrosshair?.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        void CleanUp()
        {

            myappconfig = null;

            frmCrosshair?.Close();
            frmCrosshair?.Dispose();
            frmCrosshair = null;

            streamImg?.Close();
            streamImg?.Dispose();
            streamImg = null;
        }
        private void FormIndex_Load(object sender, EventArgs e)
        {
        }

        private void FormIndex_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (frmCrosshair.Visible)
            {
                frmCrosshair.Visible = false;
                //frmCrosshair?.Hide();
            }
            else
            {
                frmCrosshair.Visible = true;
                //frmCrosshair?.Show();
            }
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

        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://n43e120.com");
        }

        //private void btnFileChoose_Click(object sender, EventArgs e)
        //{
        //    var d = new OpenFileDialog();
        //    d.Multiselect = false;
        //    var dr = d.ShowDialog(this);
        //    switch (dr)
        //    {
        //        case DialogResult.OK:
        //            if (!d.CheckFileExists)
        //            {
        //                MessageBox.Show("file not exist");
        //            }
        //            this.textBox1.Text = d.FileName;
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
