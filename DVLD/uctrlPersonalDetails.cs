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
    public partial class uctrlPersonalDetails : UserControl
    {
        public int PersonID = 0;

        public uctrlPersonalDetails()
        {
            InitializeComponent();
        }

        public void LoadDataToForm()
        {
            if(PersonID != 0)
            {
                DBclsPerson Person = new DBclsPerson(PersonID);

                lblPersonID.Text = Person.PersonID.ToString();
                lblName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                lblNationalNo.Text = Person.NationalNo;
                lblGender.Text = Person.Gender;
                pbGender.ImageLocation = (Person.Gender == "Male") ? "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\user (1).png" : "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\burka-woman-tradition-religion-muslim.png";
                lblEmail.Text = Person.Email;
                lblAddress.Text = Person.Address;
                lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
                lblPhone.Text = Person.Phone;
                lblCountry.Text = Person.Country.CountryName;

                PbPersonImage.ImageLocation = (Person.ImagePath == "") ? "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\Screenshot 2025-01-28 125155.png" : Person.ImagePath;

            }
        }

        private void lnklEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdd_Edit_Person frm = new frmAdd_Edit_Person(PersonID);
            frm.ShowDialog();
            LoadDataToForm();
        }
    }
}
