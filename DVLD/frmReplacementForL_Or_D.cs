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
    public partial class frmReplacementForL_Or_D : Form
    {

        private int _OldLicenseID = 0;
        private int _NewLicenseID = 0;
        private DBclsLicense _License;

        public frmReplacementForL_Or_D()
        {
            InitializeComponent();
        }

        private void _LoadBeforeSearching()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            
            lblAppFees.Text = DBclsApplicationType.GetAppFees(3).ToString(); ;
            
            lblCreatedBy.Text = clsGlobalUser.User.UserName;
        }

        private void frmReplacementForL_Or_D_Load(object sender, EventArgs e)
        {
            _LoadBeforeSearching();
        }

        private bool _IsLicenseValid()
        {
            if(!_License.IsActive)
            {
                MessageBox.Show("This liense is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }

        private void _LoadAfterSearching()
        {
            if (!DBclsLicense.IsValueExist("Licenses", "LicenseID", _OldLicenseID.ToString()))
            {
                MessageBox.Show($"There is no license with id = {_OldLicenseID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _License = new DBclsLicense(_OldLicenseID);

            if (!_IsLicenseValid())
                return;

            
            uctrlLicenseInfo1.License = new DBclsLicense(_OldLicenseID);
            uctrlLicenseInfo1.LoadLicenseInfo();

            lbl_OldLicenseID.Text = _License.LicenseID.ToString();

            lnklblShowLicensesHistory.Enabled = true;

            btnIssue.Enabled = true;
        }

        private void btnSearchAbouLicense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                MessageBox.Show("Please enter a license id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _OldLicenseID = Convert.ToInt32(txtFilter.Text);

            _LoadAfterSearching();
        }

        private bool _Issue()
        {
            //Fill New App
            DBclsApplication RApp = new DBclsApplication();

            RApp.AppTypeID = (rbForDamaged.Checked) ? 4 : 3;
            RApp.AppDate = DateTime.Now;
            RApp.ByUserID = clsGlobalUser.User.UserID;

            DBclsDriver driver = new DBclsDriver(_License.DriverID);

            RApp.PersonID = driver.PersonID;

            if (RApp.Save())
            {
                //Fill International License 

                DBclsLicense RLicense = new DBclsLicense();

                RLicense.ApplicationID = RApp.AppID;
                RLicense.DriverID = driver.DriverID;
                RLicense.ExpirationDate = DateTime.Now.AddYears(DBclsLicensesClasses.GetValidityDate(_License.ClassID));
                RLicense.IssueDate = DateTime.Now;
                RLicense.IsActive = true;
                RLicense.ClassID = _License.ClassID;
                RLicense.IsDetained = false;
                RLicense.IssueReasonID = rbForLost.Checked ? 3 : 5;
                RLicense.Note = _License.Note;


                if (RLicense.Save())
                {
                    MessageBox.Show($"The license has been Replaced successfully with id = {RLicense.LicenseID}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblRAppID.Text = RApp.AppID.ToString();
                    lblRLicenseID.Text = RLicense.LicenseID.ToString();

                    _License.IsActive = false;

                    _NewLicenseID = RLicense.LicenseID;

                    btnIssue.Enabled = false;
                    gbFilter.Enabled = false;

                    gbReplacement.Enabled = false;

                    lnklblShowLicenseInfo.Enabled = true;
                    return true;
                }
            }
            return false;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _Issue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_NewLicenseID);
            frm.ShowDialog();

        }

        private void lnklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBclsDriver dr = new DBclsDriver(_License.DriverID);

            frmLicensesHistory frm = new frmLicensesHistory(dr.PersonID);
            frm.ShowDialog();
        }
    }
}
