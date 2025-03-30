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
    public partial class frmIssueIDL : Form
    {
        private int _L_LicenseID = 0;

        private DBclsLicense _License = new DBclsLicense();

        public frmIssueIDL()
        {
            InitializeComponent();
        }

        private void _LoadBeforeSearching()
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = DBclsApplicationType.GetAppFees(6).ToString(); ;
            lblExpDate.Text = DateTime.Now.AddYears(DBclsLicensesClasses.GetValidityDate(8)).ToShortDateString();
            lblCreatedBy.Text = clsGlobalUser.User.UserName;
        }

        private bool _CheckIsLicenseValid()
        {
            if (!_License.IsActive)
            {
                MessageBox.Show("The local license must be active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (_License.ClassID != 3)
            {
                MessageBox.Show($"The local license's class must be \"{DBclsLicensesClasses.GetLicenseClassNameByClassID(3)}\" !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void _LoadAfterSearching()
        {
            if(!DBclsLicense.IsValueExist("Licenses", "LicenseID", _L_LicenseID.ToString()))
            {
                MessageBox.Show($"There is no license with id = {_L_LicenseID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _License = new DBclsLicense(_L_LicenseID);

            if (!_CheckIsLicenseValid())
                return;



            uctrlLicenseInfo1.License = new DBclsLicense(_L_LicenseID);
            uctrlLicenseInfo1.LoadLicenseInfo();

            lbl_LicenseID.Text = _License.LicenseID.ToString();

            lnklblShowLicensesHistory.Enabled = true;

            btnIssue.Enabled = true;


        }

        private void frmIssueIDL_Load(object sender, EventArgs e)
        {
            _LoadBeforeSearching();
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
            if(string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                MessageBox.Show("Please enter a license id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _L_LicenseID = Convert.ToInt32(txtFilter.Text);

            _LoadAfterSearching();
        }

        private bool _IssueILDL()
        {
            //Fill New App
            DBclsApplication NewApp = new DBclsApplication();

            NewApp.AppTypeID = 6;
            NewApp.AppDate = DateTime.Now;
            NewApp.ByUserID = clsGlobalUser.User.UserID;

            DBclsDriver driver = new DBclsDriver(_License.DriverID);

            NewApp.PersonID = driver.PersonID;
            
            if(NewApp.Save())
            {
                //Fill International License 

                DBclsI_License i_License = new DBclsI_License();

                i_License.ApplicationID = NewApp.AppID;
                i_License.LocalLicenseID = _L_LicenseID;
                i_License.DriverID = driver.DriverID;
                i_License.ExpirationDate = Convert.ToDateTime(lblExpDate.Text);
                i_License.IssueDate = Convert.ToDateTime(lblIssueDate.Text);
                i_License.IsActive = true;
                
                if(i_License.Save())
                {
                    MessageBox.Show($"The license has been issued successfully with id = {i_License.I_LicenseID}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lbl_I_l_AppID.Text = NewApp.AppID.ToString();
                    lbl_I_LicenseID.Text = i_License.I_LicenseID.ToString();

                    btnIssue.Enabled = false;
                    gbFilter.Enabled = false;

                    lnklblShowLicenseInfo.Enabled = true;
                    return true;
                }
            }
            return false;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(lbl_LicenseID.Text == "??")
            {
                MessageBox.Show("Please enter a license id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _IssueILDL();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lnklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBclsI_License i_License = new DBclsI_License(Convert.ToInt32(lbl_I_LicenseID.Text));
            frmI_LicenseInfo frm = new frmI_LicenseInfo(i_License);
            frm.ShowDialog();
        }
    }
}
