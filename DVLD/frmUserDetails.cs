using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmUserDetails : Form
    {
        int UserID;
        public frmUserDetails(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        public void frmUserDetails_Load(object sender, EventArgs e)
        {
            uctrlUserDetails1.UserID = UserID;
            uctrlUserDetails1.LoadDateToPersonalDetailsAndLoginInfo(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
