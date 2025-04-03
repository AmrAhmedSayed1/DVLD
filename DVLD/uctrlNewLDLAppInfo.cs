using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusinessLayer;

namespace DVLD
{
    public partial class uctrlNewLDLAppInfo : UserControl
    {
        public DBclsNewLDLApp NewLDLApp = new DBclsNewLDLApp();
        public uctrlNewLDLAppInfo()
        {
            InitializeComponent();
        }

        public void LoadNewLDLAppInfo()
        {
            lblNewLDLAppID.Text = NewLDLApp.NewLDLAppID.ToString();
            lblLicenseClass.Text = DBclsLicensesClasses.GetLicenseClassNameByClassID(NewLDLApp.ClassID);
            lblPassedTests.Text = NewLDLApp.PassedTests.ToString() + "/3";
        }
    }
}
