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
    public partial class uctrlAppInfo : UserControl
    {
        public DBclsApplication App = new DBclsApplication();
        public uctrlAppInfo()
        {
            InitializeComponent();
        }

        public void LoaductrlAppInfo()
        {
            lblAppID.Text = App.AppID.ToString();
            switch (App.AppStatusID)
            {
                case 1:
                    {
                        lblStatus.Text = "New";
                        break;
                    }
                case 2:
                    {
                        lblStatus.Text = "Complated";
                        break;
                    }
                case 3:
                    {
                        lblStatus.Text = "Canceld";
                        break;
                    }

            }
            lblFees.Text = DBclsApplicationType.GetAppFees(App.AppTypeID).ToString();
            lblType.Text = DBclsApplicationType.GetAppTypeName(App.AppTypeID).ToString();
            DBclsPerson person = new DBclsPerson(App.PersonID);
            lblApplicant.Text = person.FullName();
            lblDate.Text = App.AppDate.ToShortDateString();
            DBclsUser user = new DBclsUser(App.ByUserID);
            lblCreatedBy.Text = user.UserName;
        }


        private void lnklblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonalDetails frm = new frmPersonalDetails(App.PersonID);
            frm.ShowDialog();
        }
    }
}
