using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusinessLayer;

namespace DVLD
{
    public partial class frmAdd_Edit_Person : Form
    {

        private enum _enMode { AddNew, Update }

        private _enMode _EnMode;

        private DBclsPerson Person;

        public frmAdd_Edit_Person(int PersonID)
        {
            InitializeComponent();

            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-19);

            if(PersonID > 0)
            {
                Person = new DBclsPerson(PersonID);
                _EnMode = _enMode.Update;
            }
            else
            {
                Person = new DBclsPerson();
                _EnMode = _enMode.AddNew;
            }
        }

        private bool _CheckAllFieldFull()
        {
            if (txtFIrstName.Text == "" || txtSecondName.Text == "" || txtThirdName.Text == "" ||
                  txtLastName.Text == "" || txtNationalNo.Text == "" || txtPhone.Text == "" ||
                  txtEmail.Text == "" || txtAddress.Text == "" || (!rbMale.Checked && !rbFemale.Checked))
            {
                MessageBox.Show("Please enter all the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void _LoadAllCountriesTocbCountry()
        {
            cbCountry.DataSource = DBclsCountry.GitAllCountries();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DBclsPerson.GitAllPoeple();
        }

        private void _LoadDateToForm()
        {
            lblPersonID.Text = Person.PersonID.ToString();
            txtFIrstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtLastName.Text = Person.LastName;
            txtNationalNo.Text = Person.NationalNo;
            dtDateOfBirth.Value = Person.DateOfBirth;
            if (Person.Gender == "Male")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            txtPhone.Text = Person.Phone;
            txtEmail.Text = Person.Email;
            cbCountry.SelectedItem = Person.Country.CountryName;
            if (Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = Person.ImagePath;
                LnkLRemoveImage.Visible = true;
            }
            else
                pbPersonImage.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\user (2).png";
            txtAddress.Text = Person.Address;
        }

        private void frmAdd_Edit_Person_Load(object sender, EventArgs e)
        {
            _LoadAllCountriesTocbCountry();

            if(Person.PersonID > 0)
            {
                lblAdd_EditNewPerson.Text = "Edit Person";

                _LoadDateToForm();
            }
        }

        private void _PutDataInObject()
        {
            Person.NationalNo = txtNationalNo.Text;
            Person.Phone = txtPhone.Text;
            Person.Email = txtEmail.Text;
            Person.Address = txtAddress.Text;
            Person.FirstName = txtFIrstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = txtThirdName.Text;
            Person.LastName = txtLastName.Text;
            Person.Country = new DBclsCountry(cbCountry.Text);
            if (LnkLRemoveImage.Visible == false)
                Person.ImagePath = "";
            else
                Person.ImagePath = pbPersonImage.ImageLocation;
            Person.DateOfBirth = dtDateOfBirth.Value;
            if (rbMale.Checked)
                Person.Gender = "Male";
            else
                Person.Gender = "Female";
            Person.Phone = txtPhone.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckAllFieldFull())
                return;
            if(_EnMode == _enMode.AddNew)
            {
                if (DBclsPerson.IsValueExist("NationalNo", txtNationalNo.Text))
                {
                    MessageBox.Show("This NationalNo already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DBclsPerson.IsValueExist("Phone", txtPhone.Text))
                {
                    MessageBox.Show("This Phone already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (DBclsPerson.IsValueExist("Email", txtEmail.Text))
                {
                    MessageBox.Show("This Email already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DBclsPerson.IsValueExist("ImagePath", pbPersonImage.ImageLocation))
                {
                    MessageBox.Show("This Image already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _PutDataInObject();

                if (Person.Save())
                {
                    lblPersonID.Text = Person.PersonID.ToString();
                    MessageBox.Show("Person was added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Person was not added successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _PutDataInObject();

                if (Person.Save())
                {
                    lblPersonID.Text = Person.PersonID.ToString();
                    MessageBox.Show("Person was Updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Person was not Updated successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtFIrstName_TextChanged(object sender, EventArgs e)
        {
            if (txtFIrstName.Text == "")
                eptxtFirstName.SetError(txtFIrstName, "This field cannot be empty");
            else
                eptxtFirstName.Clear();
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {
            if (txtSecondName.Text == "")
                eptxtSecondName.SetError(txtSecondName, "This field cannot be empty");
            else
                eptxtSecondName.Clear();
        }

        private void txtThirdName_TextChanged(object sender, EventArgs e)
        {
            if (txtThirdName.Text == "")
                eptxtThirdName.SetError(txtThirdName, "This field cannot be empty");
            else
                eptxtThirdName.Clear();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
                eptxtLastName.SetError(txtLastName, "This field cannot be empty");
            else
                eptxtLastName.Clear();
        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {
            if (txtNationalNo.Text == "")
                eptxtNationalNo.SetError(txtNationalNo, "This field cannot be empty");
            else
                eptxtNationalNo.Clear();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

            if (!int.TryParse(txtPhone.Text, out int val))
            {
                if (txtPhone.Text != "")
                {
                    var sb = new StringBuilder(txtPhone.Text);
                    sb.Remove(txtPhone.Text.Length - 1, 1);
                    txtPhone.Text = sb.ToString();
                    return;
                }
            }

            if (txtPhone.Text == "")
                eptxtPhone.SetError(txtPhone, "This field cannot be empty");
            else
                eptxtPhone.Clear();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
                eptxtEmail.SetError(txtEmail, "This field cannot be empty");
            else
                eptxtEmail.Clear();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
                eptxtAddress.SetError(txtAddress, "This field cannot be empty");
            else
                eptxtAddress.Clear();
        }

        private void LnkLSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdGitPersonImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofdGitPersonImage.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdGitPersonImage.Title = "Choose Image";
            ofdGitPersonImage.ShowDialog();

            if (!string.IsNullOrWhiteSpace(ofdGitPersonImage.FileName))
            {
                pbPersonImage.ImageLocation = ofdGitPersonImage.FileName;
                LnkLRemoveImage.Visible = true;
            }
        }

        private void LnkLRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\Screenshot 2025-01-28 125155.png";
            LnkLRemoveImage.Visible = false;
        }
    }
}
