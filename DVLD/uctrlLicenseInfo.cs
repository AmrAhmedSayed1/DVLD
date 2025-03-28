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
    public partial class uctrlLicenseInfo : UserControl
    {
        public DBclsLicense License = new DBclsLicense();

        public uctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo()
        {
            DBclsApplication App = new DBclsApplication(License.ApplicationID);
            DBclsPerson person = new DBclsPerson(App.PersonID);

            lblClass.Text = DBclsLicensesClasses.GetLicenseClassNameByClassID(License.ClassID);
            lblName.Text = person.FullName();
            lblLicenseID.Text = License.LicenseID.ToString();
            lblNationalNo.Text = person.NationalNo;
            lblGender.Text = person.Gender;
            lblIssueDate.Text = License.IssueDate.ToShortDateString();
            lblIssueReason.Text = DBclsIssueReason.GetIssueReasonNameByID(License.IssueReasonID);
            lblNote.Text = (string.IsNullOrEmpty(License.Note)) ? "No Notes" : License.Note;
            lblIsActive.Text = (License.IsActive) ? "Yes" : "No";
            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = License.DriverID.ToString();
            lblExpirationDate.Text = License.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = (License.IsDetained) ? "Yes" : "No";
            pbPersonImage.ImageLocation = person.ImagePath;
        }
    }
}
