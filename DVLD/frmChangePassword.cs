using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusinessLayer;

namespace DVLD
{
    public partial class frmChangePassword : Form
    {
        private int UserID;

        private DBclsUser User;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            UserID = userID;
            User = new DBclsUser(UserID);
        }

        private void _CheckTextBoxIsNotEmpty(TextBox textbox, ErrorProvider ep)
        {

            if (string.IsNullOrEmpty(textbox.Text))
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

        private bool _checktxtConfirmPassword()
        {
            if (txtConfirmNewPassword.Text != txtNewPassword.Text)
            {
                eptxtConfirmNewPassword.SetError(txtConfirmNewPassword, "This feild must be matched with origin Password");
                txtConfirmNewPassword.Tag = 0;
                return false;
            }
            else
            {
                eptxtConfirmNewPassword.Clear();
                txtConfirmNewPassword.Tag = 1;
                return true;
            }
        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            _CheckTextBoxIsNotEmpty(txtCurrentPassword, eptxtCurrentPassword);
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            _checktxtConfirmPassword();
            _CheckTextBoxIsNotEmpty(txtNewPassword, eptxtNewPassword);
        }

        private void txtConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {
            _checktxtConfirmPassword();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            uctrlUserDetails1.UserID = UserID;
            uctrlUserDetails1.LoadDateToPersonalDetailsAndLoginInfo(sender, e);
        }

        private string _Crypt(string Text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] HashedText = sha256.ComputeHash(Encoding.UTF8.GetBytes(Text));

                return BitConverter.ToString(HashedText).Replace("-", "");
            }
        }

        private bool _CheckPasswordIsTrue()
        {
            
            return (_Crypt(txtCurrentPassword.Text) == User.Password);
        }

        private bool _CheckAllDatetrue()
        {
            if (!_checktxtConfirmPassword()) 
            {
                MessageBox.Show("The Confirm Password must match origin Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!((Convert.ToInt32(txtCurrentPassword.Tag) + Convert.ToInt32(txtNewPassword.Tag) + Convert.ToInt32(txtConfirmNewPassword.Tag)) == 3))
            {
                MessageBox.Show("Please Enter All Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(!_CheckPasswordIsTrue())
            {
                MessageBox.Show("The current password is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _PutAllDateToUser()
        {
            if(_CheckAllDatetrue())
            {
                User.Password = _Crypt(txtNewPassword.Text);
                return true;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_PutAllDateToUser())
            {
                if (User.SaveUser())
                {
                    MessageBox.Show("Password was updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Password was not updated successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}