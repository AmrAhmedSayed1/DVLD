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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class frmAddNewLDLApp : Form
    {
        private int PersonID = 0;
        public frmAddNewLDLApp()
        {
            InitializeComponent();
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (DBclsPerson.IsValueExist("NationalNo", txtFilter.Text))
            {

                DataTable dt = DBclsPerson.GitAllPoepleWithFilter("NationalNo", txtFilter.Text);
                PersonID = Convert.ToInt32(dt.Rows[0][0]);
                                
                uctrlPersonalDetails1.PersonID = PersonID;
                uctrlPersonalDetails1.LoadDataToForm();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            TabAdd_Edit_User.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadClassesNamesTocb()
        {
            cbLicenseClass.DataSource = DBclsLicensesClasses.GetAllClassesNames();
            cbLicenseClass.SelectedItem = "Class 3 - Ordinary driving license";
        }

        private void frmAddNewLDLApp_Load(object sender, EventArgs e)
        {
            lblCreatedBy.Text = clsGlobalUser.User.UserName.ToString();
            _LoadClassesNamesTocb();
            lblAppFees.Text = DBclsApplicationType.GetAppFees(1).ToString(); // 1 = References to New Local Driving License Service Type
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
        }

        private bool _IsModeAddNew()
        {
            if (lblDLApplicationID.Text == "??")
                return true;

            return false;
        }

        private bool _CheckIsTherePerson()
        {
            if (PersonID == 0)
            {
                MessageBox.Show("Please Choose A Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _CheckDoesnotPersonHasNewSameClassApp()
        {
            int AppID = 0;
            if ((AppID = DBclsApplication.IsPersonHasNewApplicationFromThisClass(PersonID, DBclsLicensesClasses.GetLicenseClassIDByClassName(cbLicenseClass.SelectedItem.ToString()))) > 1)
            {
                MessageBox.Show($"This person has an application of type new local driving license and license class \"{cbLicenseClass.SelectedItem.ToString()}\" with Application ID = {AppID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool _Save()
        {
            if(_IsModeAddNew())
            {
                if(_CheckIsTherePerson())
                {
                    if(_CheckDoesnotPersonHasNewSameClassApp())
                    {
                        DBclsApplication App = new DBclsApplication();
                        App.AppStatusID = 1;
                        App.AppTypeID = DBclsApplicationType.GetAppTypeID(this.Tag.ToString());
                        App.AppDate = DateTime.Now;
                        App.ByUserID = clsGlobalUser.User.UserID;
                        App.PersonID = PersonID;

                        if (App.Save())
                        {
                            MessageBox.Show($"The application was added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblDLApplicationID.Text = App.AppID.ToString();

                            DBclsNewLDLApp NewLDLApp = new DBclsNewLDLApp();

                            NewLDLApp.AppID = App.AppID;
                            NewLDLApp.ClassID = DBclsLicensesClasses.GetLicenseClassIDByClassName(cbLicenseClass.SelectedItem.ToString());
                            NewLDLApp.Save();

                            btnSave.Enabled = false;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show($"The application was not added successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }                    
                }         
                
            }
            return false;       
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }
    }
}