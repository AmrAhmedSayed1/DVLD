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
    public partial class frmIssueLDL : Form
    {
        private DBclsNewLDLApp _NewLDLApp = new DBclsNewLDLApp();
        public frmIssueLDL(DBclsNewLDLApp NewLDLApp)
        {
            InitializeComponent();
            _NewLDLApp = NewLDLApp;
        }

        private void _Save()
        {
            DBclsLicense License = new DBclsLicense();
            DBclsApplication App = new DBclsApplication(_NewLDLApp.AppID);

            int DriverID = 0;
            if((DriverID = DBclsLicense.GetDriverIDByPersonID(App.PersonID)) == 0)
            {
                DBclsDriver Driver = new DBclsDriver();
                Driver.PersonID = App.PersonID;

                Driver.AddNew();


                License.DriverID = Driver.DriverID;
            }
            else
                License.DriverID = DriverID;


            License.ClassID = _NewLDLApp.ClassID;
            License.ApplicationID = App.AppID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(DBclsLicensesClasses.GetExpirationDate(_NewLDLApp.ClassID));
            License.IssueReasonID = 1; // 1 = New
            License.IsActive = true;
            License.IsDetained = false;
            License.Note = lblNotes.Text;

            if(License.Save())
            {
                MessageBox.Show("The license has been issued successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;

                App.AppStatusID = 2;
                App.Save();
            }
            else
                MessageBox.Show("The license has not been issued successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueLDL_Load(object sender, EventArgs e)
        {
            uctrlNewLDLAppInfo1.NewLDLApp = _NewLDLApp;

            uctrlNewLDLAppInfo1.LoadNewLDLAppInfo();


            uctrlAppInfo1.App = new DBclsApplication(_NewLDLApp.AppID);

            uctrlAppInfo1.LoaductrlAppInfo();
        }
    }
}
