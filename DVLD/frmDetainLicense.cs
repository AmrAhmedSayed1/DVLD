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
    public partial class frmDetainLicense : Form
    {
        private int _LicenseID = 0;
        private DBclsLicense _License;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void _LoadBeforeSearching()
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobalUser.User.UserName;
        }

        private bool _CheckIsLicenseValid()
        {
            if (!_License.IsActive)
            {
                MessageBox.Show("The license must be active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (_License.IsDetained)
            {
                MessageBox.Show($"This license is already detained with id = \"{DBclsDetainedLicense.GetDetainIDByLicenseID(_LicenseID)}\" !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void _LoadAfterSearching()
        {
            if (!DBclsLicense.IsValueExist("Licenses", "LicenseID", _LicenseID.ToString()))
            {
                MessageBox.Show($"There is no license with id = {_LicenseID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _License = new DBclsLicense(_LicenseID);

            if (!_CheckIsLicenseValid())
                return;



            uctrlLicenseInfo1.License = new DBclsLicense(_LicenseID);
            uctrlLicenseInfo1.LoadLicenseInfo();

            lblLicenseID.Text = _License.LicenseID.ToString();

            lnklblShowLicensesHistory.Enabled = true;

            btnRelease.Enabled = true;


        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private void lnklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBclsDriver driver = new DBclsDriver(_License.DriverID);
            frmLicensesHistory frm = new frmLicensesHistory(driver.PersonID);
            frm.ShowDialog();
        }

        private bool _IstxtFineFeesnotempty()
        {
            if(string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                MessageBox.Show("Please enter a fine fees.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _Detain()
        {
            if (!_IstxtFineFeesnotempty())
                return false;

             DBclsDetainedLicense DL = new DBclsDetainedLicense();

            DL.DetainDate = DateTime.Now;
            DL.FineFees = Convert.ToSingle(txtFineFees.Text);
            DL.ByUserID = clsGlobalUser.User.UserID;
            DL.IsReleased = false;
            DL.LicenseID = _LicenseID;

            if (DL.Save())
            {
                MessageBox.Show($"The license has been Detained successfully with id = {DL.DetainID}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblLicenseID.Text = _LicenseID.ToString();
                lblDetainID.Text = DL.DetainID.ToString();

                gbFilter.Enabled = false;

                lnklblShowLicenseInfo.Enabled = true;

                btnRelease.Enabled = false;

                txtFineFees.Enabled = false;

                _License.IsDetained = true;
                _License.Save();

                return true;
            }
            
            return false;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _Detain();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchAbouLicense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                MessageBox.Show("Please enter a license id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LicenseID = Convert.ToInt32(txtFilter.Text);

            _LoadAfterSearching();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            _LoadBeforeSearching();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
