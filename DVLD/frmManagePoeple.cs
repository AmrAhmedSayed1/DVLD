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
    public partial class frmManagePoeple : Form
    {
        public frmManagePoeple()
        {
            InitializeComponent();
        }

        private void frmManagePoeple_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1741, 778);
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            uctrlManagePoeple1.uctrlManagePoeple_Load(sender, e);
        }
    }
}
