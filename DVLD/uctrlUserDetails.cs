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
    public partial class uctrlUserDetails : UserControl
    {
        public int UserID;
        public uctrlUserDetails()
        {
            InitializeComponent();
        }

        public void LoadDateToPersonalDetailsAndLoginInfo(object sender, EventArgs e)
        {
            DBclsUser User = new DBclsUser(UserID);
            _LoadDateToPersonalDetails(sender, e, User.PersonID);
            _LoadDateToLoginInfo(User);
        }

        private void _LoadDateToPersonalDetails(object sender, EventArgs e, int PersonID)
        {
            uctrlPersonalDetails1.PersonID = PersonID;
            uctrlPersonalDetails1.LoadDataToForm();
        }

        private void _LoadDateToLoginInfo(DBclsUser User)
        {
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.UserName.ToString();
            lblIsActive.Text = (User.IsActive == 1) ? "Yes" : "No";
        }
    }
}
