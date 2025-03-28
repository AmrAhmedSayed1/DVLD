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
    public partial class frmAddEditTestAppointment : Form
    {
        DBclsTestAppointment TestAppointment = new DBclsTestAppointment();

        private DBclsNewLDLApp _NewLDLApp = new DBclsNewLDLApp();
        public enum enTestType { Vision = 1, Written = 2, Street = 3 }
        public enTestType TestType;

        public enum enMode_NewOrRetakeTest { New = 1, ReTakeTest = 2}
        public enMode_NewOrRetakeTest Mode_NewOrRetakeTest;

        public enum enIsEditMode { Yes = 1, No = 2 }
        public enIsEditMode IsEditMode;


        public frmAddEditTestAppointment(DBclsNewLDLApp newLDLApp, enTestType TestType, enMode_NewOrRetakeTest ModeNewOrRetakeTest, enIsEditMode isEditMode, int testAppointmentID)
        {
            InitializeComponent();
            _NewLDLApp = newLDLApp;
            this.TestType = TestType;
            Mode_NewOrRetakeTest = ModeNewOrRetakeTest;
            IsEditMode = isEditMode;
            TestAppointment = (testAppointmentID == 0) ? new DBclsTestAppointment() : new DBclsTestAppointment(testAppointmentID);
        }

        private void _LoadImageAndLabelForTestType()
        {
            switch (TestType)
            {
                case enTestType.Vision:
                    {
                        pbTestType.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\eye_chart.png";
                        lblTestType.Text = "Vision Test";
                        break;
                    }
                case enTestType.Written:
                    {
                        pbTestType.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\cover_page.png";
                        lblTestType.Text = "Written Test";
                        break;
                    }
                case enTestType.Street:
                    {
                        pbTestType.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\road_closed_sign (1).png";
                        lblTestType.Text = "Street Test";
                        break;
                    }
            }
            gbTestType.Text = lblTestType.Text;

            if (Mode_NewOrRetakeTest == enMode_NewOrRetakeTest.ReTakeTest)
            {
                gbRAppInfo.Enabled = true;
                lblTestType.Text = "Retake " + lblTestType.Text;
            }
        }

        private void _LoadTrialLabel()
        {
            switch (TestType)
            {
                case enTestType.Vision:
                    {
                        lblTrial.Text = _NewLDLApp.VisionTrial.ToString();
                        break;
                    }
                case enTestType.Written:
                    {
                        lblTrial.Text = _NewLDLApp.WrittenTrial.ToString();
                        break;
                    }
                case enTestType.Street:
                    {
                        lblTrial.Text = _NewLDLApp.StreetTrial.ToString();
                        break;
                    }
            }
        }

        private void _LoadDataToForm()
        {
            lblAppID.Text = _NewLDLApp.AppID.ToString();

            lblDClass.Text = DBclsLicensesClasses.GetLicenseClassNameByClassID(_NewLDLApp.ClassID);

            DBclsApplication App = new DBclsApplication(_NewLDLApp.AppID);

            DBclsPerson person = new DBclsPerson(App.PersonID);

            lblName.Text = person.FullName();

            _LoadTrialLabel();

            lblFees.Text = DBclsTestType.GetTestFees(Convert.ToInt32(TestType)).ToString();

            if (Mode_NewOrRetakeTest == enMode_NewOrRetakeTest.ReTakeTest)
            {
                lblRAppFees.Text = DBclsApplicationType.GetAppFees(7).ToString();

                gbRAppInfo.Enabled = true;
            }

            float TotalFees = 0;

            TotalFees = Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRAppFees.Text);

            lblTotalFees.Text = TotalFees.ToString();

            if (IsEditMode == enIsEditMode.Yes)
                lblRAppID.Text = TestAppointment.OldAppID.ToString();

        }

        private void frmAddNewTestAppointment_Load(object sender, EventArgs e)
        {

            dtpDate.MinDate = DateTime.Now;
            dtpDate.MaxDate = DateTime.Now.AddMonths(6);
            _LoadImageAndLabelForTestType();
            _LoadDataToForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillNewTestAppointment()
        {
            TestAppointment.NewLDLAppID = _NewLDLApp.NewLDLAppID;
            TestAppointment.ByUserID = clsGlobalUser.User.UserID;
            DBclsApplication App = new DBclsApplication(_NewLDLApp.AppID);
            TestAppointment.PersonID = App.PersonID;
            TestAppointment.TestDate = dtpDate.Value;
            TestAppointment.TestTypeID = Convert.ToInt32(TestType);

            TestAppointment.ApplicationID = _NewLDLApp.AppID;

        }

        private void _FillRetakeTestAppointment()
        {
            TestAppointment.NewLDLAppID = _NewLDLApp.NewLDLAppID;
            TestAppointment.ByUserID = clsGlobalUser.User.UserID;
            DBclsApplication App = new DBclsApplication(_NewLDLApp.AppID);
            TestAppointment.PersonID = App.PersonID;
            TestAppointment.TestDate = dtpDate.Value;
            TestAppointment.TestTypeID = Convert.ToInt32(TestType);

            DBclsApplication NewApp = new DBclsApplication();

            NewApp.AppTypeID = 7;
            NewApp.AppDate = DateTime.Now;
            NewApp.ByUserID = clsGlobalUser.User.UserID;
            NewApp.PersonID = App.PersonID;
            NewApp.Save();

            TestAppointment.ApplicationID = NewApp.AppID;
            TestAppointment.OldAppID = _NewLDLApp.AppID;

        }

        private bool _Save()
        {
            switch (Mode_NewOrRetakeTest)
            {
                case enMode_NewOrRetakeTest.New:
                    {
                        _FillNewTestAppointment();

                        break;
                    }
                case enMode_NewOrRetakeTest.ReTakeTest:
                    {
                        _FillRetakeTestAppointment();

                        break;
                    }
            }

            if (TestAppointment.Save())
            {
                MessageBox.Show("Test Appointment was added successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                lblRAppID.Text = (TestAppointment.OldAppID == 0) ? "??" : TestAppointment.ApplicationID.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Test Appointment was not added successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void _SaveEditMode()
        {
            TestAppointment.TestDate = dtpDate.Value;
            if(TestAppointment.Save())
                MessageBox.Show("Test Appointment was updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Test Appointment was not updated successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEditMode == enIsEditMode.Yes)
                _SaveEditMode();
            else
                _Save();
        }
    }
}