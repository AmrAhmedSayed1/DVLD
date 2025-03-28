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
    public partial class frmLicenseInfo : Form
    {
        private int AppID = 0;
        public frmLicenseInfo(int appID)
        {
            InitializeComponent();
            AppID = appID;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            uctrlLicenseInfo1.License = new DBclsLicense(AppID, true);
            uctrlLicenseInfo1.LoadLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
