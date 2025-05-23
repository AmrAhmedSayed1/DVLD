﻿using System;
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
        private int _LicenseID = 0;
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            uctrlLicenseInfo1.License = new DBclsLicense(_LicenseID);
            uctrlLicenseInfo1.LoadLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
