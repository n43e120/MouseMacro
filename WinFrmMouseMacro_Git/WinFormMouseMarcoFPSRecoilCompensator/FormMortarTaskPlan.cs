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
    public partial class FormMortarTaskPlan : Form
    {
        public FormMortarTaskPlan()
        {
            InitializeComponent();
        }
    }
    public enum ShellDistributionOffset
    {
        NoOffset=0,
        AlongArc,
        AlongArcLeft,
        AlongArcRight,
    }
    public class MortarFireTaskForMouseMacro
    {
        public SharpDX.Vector3 baseLoc { get; set; }
        public SharpDX.Vector3 TargetLoc { get; set; }
        public float InitialAzimuthInRad { get; set; }
        public float TargetAzimuthInRad { get; set; }
        public float TargetRangeInMeter { get; set; }
        public ShellDistributionOffset offset { get; set; }
        public float param_spacing { get; set; }
    }
}
