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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void poepleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePoeple frm = new frmManagePoeple();

            frm.ShowDialog();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(clsGlobalUser.User.UserID);
            frm.ShowDialog();
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobalUser.User.UserID);
            frm.ShowDialog();
        }

        private void tsmSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestsTypes frm = new frmManageTestsTypes();
            frm.ShowDialog();
        }

        private void tsmManageAppTypes_Click(object sender, EventArgs e)
        {
            frmManageApplicationsTypes frm = new frmManageApplicationsTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewLDLApp frm = new frmAddNewLDLApp();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDLApps frm = new frmManageLDLApps();
            frm.ShowDialog();
        }
    }
}
