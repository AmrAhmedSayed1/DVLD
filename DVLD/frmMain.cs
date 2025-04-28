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
        private frmLoginForm frmLoginForm = new frmLoginForm();
        public MainForm(object s)
        {
            InitializeComponent();
            frmLoginForm = (frmLoginForm)s;
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
            frmAdd_EditNewLDLApp frm = new frmAdd_EditNewLDLApp();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageNewLDLApps frm = new frmManageNewLDLApps();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueIDL frm = new frmIssueIDL();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageILicensesApps frm = new frmManageILicensesApps();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmRenewLicense frm = new frmRenewLicense();
            frm.ShowDialog();
        }

        private void tsmReplaceForLostOrDamaged_Click(object sender, EventArgs e)
        {
            frmReplacementForL_Or_D frm = new frmReplacementForL_Or_D();
            frm.ShowDialog();
        }

        private void tsmReleaseDetained_Click(object sender, EventArgs e)
        {
            frmReleaseDL frm = new frmReleaseDL();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDL frm = new frmReleaseDL();
            frm.ShowDialog();
        }

        private void tsmRetakeTest_Click(object sender, EventArgs e)
        {
            frmManageNewLDLApps frm = new frmManageNewLDLApps();
            frm.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLoginForm.frmLoginForm_Load(sender, e);
        }
    }
}
