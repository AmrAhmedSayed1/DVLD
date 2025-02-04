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
    public partial class frmLoginForm : Form
    {
        public frmLoginForm()
        {
            InitializeComponent();
        }

        private void _CheckChbRememberMe()
        {
            if(chbRememberMe.Checked)
            {
                Properties.Settings.Default.UserName = txtUserName.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.Save();
                return;
            }
            else
            {
                if(Properties.Settings.Default.UserName == txtUserName.Text )
                {
                    Properties.Settings.Default.UserName = null;
                    Properties.Settings.Default.Password = null;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private bool _CheckUserNameAndPassword()
        {
            DBclsUser User = new DBclsUser(txtUserName.Text, txtPassword.Text);

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

                MainForm frm = new MainForm();
                frm.ShowDialog();
            }
        }

        private void _LoadUserNameAndPassword()
        {
            txtUserName.Text = Properties.Settings.Default.UserName;
            txtPassword.Text = Properties.Settings.Default.Password;
        }

        private void frmLoginForm_Load(object sender, EventArgs e)
        {
            _LoadUserNameAndPassword();
        }
    }
}
