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
    public partial class uctrlIntLicenseInfo : UserControl
    {
        public DBclsI_License ILicense = new DBclsI_License();
        public uctrlIntLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadI_LicenseInfo()
        {
            DBclsDriver Driver = new DBclsDriver(ILicense.DriverID);
            DBclsPerson Person = new DBclsPerson(Driver.PersonID);

            lblName.Text = Person.FullName();
            lblI_LicenseID.Text = ILicense.I_LicenseID.ToString();
            lblLicenseID.Text = ILicense.LocalLicenseID.ToString();
            lblNationalNo.Text = Person.NationalNo;
            lblGender.Text = Person.Gender;
            lblIssueDate.Text = ILicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = ILicense.ApplicationID.ToString();
            lblIsActive.Text = ILicense.IsActive.ToString();
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = Driver.DriverID.ToString();
            lblExpirationDate.Text = ILicense.ExpirationDate.ToShortDateString();
            pbPersonImage.ImageLocation = Person.ImagePath;
        }
    }
}
