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
    public partial class frmI_LicenseInfo : Form
    {
        DBclsI_License I_License = new DBclsI_License();
        public frmI_LicenseInfo(DBclsI_License i_license)
        {
            InitializeComponent();
            I_License = i_license;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmI_LicenseInfo_Load(object sender, EventArgs e)
        {
            uctrlIntLicenseInfo1.ILicense = I_License;
            uctrlIntLicenseInfo1.LoadI_LicenseInfo();
        }
    }
}
