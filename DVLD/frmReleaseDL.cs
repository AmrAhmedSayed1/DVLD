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
    public partial class frmReleaseDL : Form
    {
        private int _LicenseID = 0;
        private DBclsLicense _License;
        private DBclsDetainedLicense _DetainedLicense;

        public frmReleaseDL(int licenseID = 0)
        {
            InitializeComponent();
            _LicenseID = licenseID;

        }

        private void _LoadBeforeSearching()
        {
            lblAppFees.Text = DBclsApplicationType.GetAppFees(5).ToString();
        }

        private bool _CheckIsLicenseValid()
        {            
            if (!_License.IsDetained)
            {
                MessageBox.Show($"This license is not detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            _DetainedLicense = new DBclsDetainedLicense(_LicenseID, true);

            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();

            lblLicenseID.Text = _LicenseID.ToString();

            lblCreatedBy.Text = DBclsUser.GetUserNameByUserID(_DetainedLicense.ByUserID);
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();

            lblTotalFees.Text = (_DetainedLicense.FineFees + Convert.ToSingle(lblAppFees.Text)).ToString();

            lnklblShowLicensesHistory.Enabled = true;

            btnRelease.Enabled = true;
        }

        private bool _Release()
        {
            DBclsApplication App = new DBclsApplication();

            App.AppStatusID = 2;
            App.AppDate = DateTime.Now;
            App.AppTypeID = 5;
            App.ByUserID = clsGlobalUser.User.UserID;
            
            DBclsDriver Driver = new DBclsDriver(_License.DriverID);

            App.PersonID = Driver.PersonID;

            if (App.Save())
            {
                _DetainedLicense.ReleaseAppID = App.AppID;
                _DetainedLicense.IsReleased = true;
                _DetainedLicense.ReleasedByUserID = clsGlobalUser.User.UserID;
                _DetainedLicense.ReleaseDate = DateTime.Now;

                if (_DetainedLicense.Save())
                {
                    MessageBox.Show($"The license has been Released successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblReleaseAppID.Text = App.AppID.ToString();

                    gbFilter.Enabled = false;

                    lnklblShowLicenseInfo.Enabled = true;

                    btnRelease.Enabled = false;

                    _License.IsDetained = false;
                    _License.Save();

                    return true;
                }
            }

            MessageBox.Show($"License has not not released successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
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

        private void frmReleaseDL_Load(object sender, EventArgs e)
        {
            _LoadBeforeSearching();

            if (_LicenseID > 0)
            {
                _LoadAfterSearching();
                gbFilter.Enabled = false;
                txtFilter.Text = _LicenseID.ToString();
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            _Release();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}