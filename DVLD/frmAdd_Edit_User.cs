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
    public partial class frmAdd_Edit_User : Form
    {

        private int UserID = 0;

        private int PersonID = 0;

        private enum _enmode { AddNew, Update }

        private _enmode _EnMode;


        private DBclsUser _User;

        public frmAdd_Edit_User(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabAdd_Edit_User.SelectedIndex = 1;
        }

        private void _LoadMode(object sender, EventArgs e)
        {
            if(UserID > 0)
            {
                lblMode.Text = "Update User";
                _User = new DBclsUser(UserID);
                PersonID = _User.PersonID;
                uctrlPersonalDetails1.PersonID = _User.PersonID;
                uctrlPersonalDetails1.LoadDataToForm();
                lblUserID.Text = UserID.ToString();
                gbFilter.Enabled = false;
            }
            else
            {
                _User = new DBclsUser();
            }
        }

        private void frmAdd_Edit_User_Load(object sender, EventArgs e)
        {
            _LoadMode(sender, e);
        }

        private void tabLoginInfo_HandleCreated(object sender, EventArgs e)
        {
            MessageBox.Show("تم تحميل التبويب لأول مرة!");
        }

        private bool _CheckUserNameIsNotExist()
        {
            return !(DBclsUser.IsValueExist("UserName", txtUserName.Text));
        }

        private bool _PutAllDateTo_User()
        {
            if (!_CheckAllDateIsRight())
                return false;

            _User.PersonID = PersonID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = (chbIsActive.Checked) ? 1 : 0;
            return true;
        }
        
        private bool _CheckAllDateIsRight()
        {
            if(Convert.ToInt32(txtUserName.Tag) + Convert.ToInt32(txtPassword.Tag) + Convert.ToInt32(txtConfirmPassword.Tag) != 3)
            {
                MessageBox.Show("Please Enter All Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(UserID == 0 && !_CheckUserNameIsNotExist())
            {
                MessageBox.Show("This User Name Is Allready Exist, Please Enter Another One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!(PersonID > 0))
            {
                MessageBox.Show("Please Choose a Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_PutAllDateTo_User())
                return;

            if(UserID == 0)
            {
                if(_User.Save())
                {
                    MessageBox.Show("User Was Added Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserID = _User.UserID;
                    _LoadMode(sender, e);
                }  
                else
                {
                    MessageBox.Show("User Was not Added Succesfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if(_User.Save())
                {
                    MessageBox.Show("User Was Updated Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("User Was not Updated Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _CheckTextBoxIsNotEmpty(TextBox textbox, ErrorProvider ep)
        {
            
            if(string.IsNullOrEmpty(textbox.Text))
            {
                ep.SetError(textbox, "This Feild can't be empty");
                textbox.Tag = 0;
            }
            else
            {
                ep.Clear();
                textbox.Tag = 1;
            }
        }

        private void _checktxtConfirmPassword()
        {
            if(txtConfirmPassword.Text != txtPassword.Text)
            {
                epConfirmPassword.SetError(txtConfirmPassword, "This feild must be matched with origin Password");
                txtConfirmPassword.Tag = 0;
            }
            else
            {
                epConfirmPassword.Clear();
                txtConfirmPassword.Tag = 1;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            _CheckTextBoxIsNotEmpty(txtUserName, epUserName);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            _checktxtConfirmPassword();
            _CheckTextBoxIsNotEmpty(txtPassword, epPassword);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            _checktxtConfirmPassword();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (DBclsPerson.IsValueExist("NationalNo", txtFilter.Text))
            {

                DataTable dt = DBclsPerson.GitAllPoepleWithFilter("NationalNo", txtFilter.Text);
                PersonID = Convert.ToInt32(dt.Rows[0][0]);

                if (DBclsUser.IsValueExist("PersonID", PersonID.ToString()))
                {
                    MessageBox.Show("This Person Is Allready User, Please Choose Another Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PersonID = 0;
                    return;
                }

                
                uctrlPersonalDetails1.PersonID = PersonID;
                uctrlPersonalDetails1.LoadDataToForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void _LoaductrlPersonDetailsWithGivePersonID(object sender, EventArgs e, int personID)
        {
            PersonID = personID;
            uctrlPersonalDetails1.PersonID = PersonID;
            uctrlPersonalDetails1.LoadDataToForm();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person frm = new frmAdd_Edit_Person(0);
            frm.BackPersonID += _LoaductrlPersonDetailsWithGivePersonID;
            frm.ShowDialog();
        }
    }
}
