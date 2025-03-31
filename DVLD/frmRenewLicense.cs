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
    public partial class frmRenewLicense : Form
    {

        private int _Old_LicenseID = 0;
        private int _New_LicenseID = 0;

        private DBclsLicense _License = new DBclsLicense();

        public frmRenewLicense()
        {
            InitializeComponent();
        }

        private bool _CheckIsLicenseExpired()
        {
            if (!(_License.ExpirationDate < DateTime.Now))
            {
                MessageBox.Show($"Selected license is not expired yet, it will expire on: {_License.ExpirationDate.ToShortDateString()}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _IsLicenseValid()
        {
            if(!_CheckIsLicenseExpired())
                return false;
            
            if(!_License.IsActive)
            {
                MessageBox.Show("This license is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void _LoadBeforeSearching()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = DBclsApplicationType.GetAppFees(2).ToString(); ;
            lblCreatedBy.Text = clsGlobalUser.User.UserName;
        }

        private void _LoadAfterSearching()
        {
            if (!DBclsLicense.IsValueExist("Licenses", "LicenseID", _Old_LicenseID.ToString()))
            {
                MessageBox.Show($"There is no license with id = {_Old_LicenseID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _License = new DBclsLicense(_Old_LicenseID);

            if (!_IsLicenseValid())
                return;



            uctrlLicenseInfo1.License = new DBclsLicense(_Old_LicenseID);
            uctrlLicenseInfo1.LoadLicenseInfo();

            lbl_OldLicenseID.Text = _License.LicenseID.ToString();

            lnklblShowLicensesHistory.Enabled = true;

            btnRenew.Enabled = true;

            lblAppFees.Text = DBclsApplicationType.GetAppFees(2).ToString();
            lblLFees.Text = DBclsLicensesClasses.GetClassFeesByID(_License.ClassID).ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblAppFees.Text) + Convert.ToSingle(lblAppFees.Text)).ToString();
            lblExpDate.Text = DateTime.Now.AddYears(DBclsLicensesClasses.GetValidityDate(_License.ClassID)).ToString();
            lbl_OldLicenseID.Text = _License.LicenseID.ToString();
        }

        private void _Renew()
        {
            DBclsApplication App = new DBclsApplication();

            App.AppTypeID = 2;
            App.AppDate = DateTime.Now;
            App.ByUserID = clsGlobalUser.User.UserID;
            DBclsDriver driver = new DBclsDriver(_License.DriverID);
            App.PersonID = driver.PersonID;
            
            if(App.Save())
            {
                DBclsLicense NewLicense = new DBclsLicense();

                NewLicense.DriverID = _License.DriverID;
                NewLicense.ApplicationID = App.AppID;
                NewLicense.Note = txtNotes.Text;
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ClassID = _License.ClassID;
                NewLicense.ExpirationDate = Convert.ToDateTime(lblExpDate.Text);
                NewLicense.IsActive = true;
                NewLicense.IsDetained = false;
                NewLicense.IssueReasonID = 2;

                if(NewLicense.Save())
                {
                    MessageBox.Show($"License renewed seccessfully with id = {NewLicense.LicenseID}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblRLicenseID.Text = NewLicense.LicenseID.ToString();
                    _New_LicenseID = NewLicense.LicenseID;
                    lblRLAppID.Text = App.AppID.ToString();
                    _License.IsActive = false;
                    _License.Save();
                    btnRenew.Enabled = false;
                    lnklblShowLicenseInfo.Enabled = true;
                    gbFilter.Enabled = false;
                }
                
            }
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            _LoadBeforeSearching();
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_New_LicenseID);
            frm.ShowDialog();
        }

        private void lnklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBclsDriver driver = new DBclsDriver(_License.DriverID);
            frmLicensesHistory frm = new frmLicensesHistory(driver.PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchAbouLicense_Click(object sender, EventArgs e)
        {
            _Old_LicenseID = Convert.ToInt32(txtFilter.Text);
            _LoadAfterSearching();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            _Renew();
        }
    }
}