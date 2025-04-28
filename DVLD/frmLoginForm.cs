using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusinessLayer;
using Microsoft.Win32;

namespace DVLD
{
    public partial class frmLoginForm : Form
    {
        public frmLoginForm()
        {
            InitializeComponent();
        }

        private void _CheckChbRememberMe()
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            string Value_Name_UserName = "User Name";
            string Value_Name_Password = "Password";
            string Value_Name_RememberMe = "Remember Me";

            if (chbRememberMe.Checked)
            {
                string Value_UserName = txtUserName.Text;
                string Value_Password = txtPassword.Text;
                bool Value_RememberMy = true;

                try
                {
                    Registry.SetValue(KeyPath, Value_Name_UserName, Value_UserName);
                    Registry.SetValue(KeyPath, Value_Name_Password, Value_Password);
                    Registry.SetValue(KeyPath, Value_Name_RememberMe, Value_RememberMy);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {

                

                string Value_UserName = "";
                string Value_Password = "";
                bool Value_RememberMy = false;

                try
                {
                    Registry.SetValue(KeyPath, Value_Name_UserName, Value_UserName);
                    Registry.SetValue(KeyPath, Value_Name_Password, Value_Password);
                    Registry.SetValue(KeyPath, Value_Name_RememberMe, Value_RememberMy);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private string _Crypt(string Text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] HashedText = sha256.ComputeHash(Encoding.UTF8.GetBytes(Text));

                return BitConverter.ToString(HashedText).Replace("-", "");
            }
        }

        private bool _CheckUserNameAndPassword()
        {
            DBclsUser User = new DBclsUser(txtUserName.Text, _Crypt(txtPassword.Text));

            if(User.UserID == 0 )
            {
                MessageBox.Show("Wrong User Name Or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if(User.IsActive == 0)
                {
                    MessageBox.Show("This User is not allowed to access the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                clsGlobalUser.User = User;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(_CheckUserNameAndPassword())
            {
                _CheckChbRememberMe();

                MainForm frm = new MainForm(this);
                frm.ShowDialog();
            }
        }

        private void _LoadUserNameAndPassword()
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            string Value_Name_UserName = "User Name";
            string Value_Name_Password = "Password";
            string Value_Name_RememberMe = "Remember Me";
            

            try
            {
                string Value_UserName = Registry.GetValue(KeyPath, Value_Name_UserName, null)  as string;
                string Value_Password = Registry.GetValue(KeyPath, Value_Name_Password, null)  as string;
                bool Value_RememberMy = Convert.ToBoolean(Registry.GetValue(KeyPath, Value_Name_RememberMe, null));

                if (Value_RememberMy)
                {
                    txtUserName.Text = Value_UserName;
                    txtPassword.Text = Value_Password;
                    chbRememberMe.Checked = true;
                }
                else
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    chbRememberMe.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void frmLoginForm_Load(object sender, EventArgs e)
        {
            _LoadUserNameAndPassword();
        }
    }
}
