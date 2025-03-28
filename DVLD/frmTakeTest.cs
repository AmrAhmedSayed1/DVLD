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
using static DVLD.frmAddEditTestAppointment;

namespace DVLD
{
    public partial class frmTakeTest : Form
    {
        private DBclsNewLDLApp _NewLDLApp = new DBclsNewLDLApp();
        private DBclsTestAppointment _TestAppointment = new DBclsTestAppointment();
        public enum _enTestType { Vision = 1, Written = 2, Street = 3 }
        public _enTestType _EnTestType;

        private float _TotalFees = 0;

        private DBclsTest _Test = new DBclsTest();

        public frmTakeTest(DBclsTestAppointment testAppointment, _enTestType TestType)
        {
            InitializeComponent();
            _EnTestType = TestType;
            _TestAppointment = testAppointment;
            _NewLDLApp = new DBclsNewLDLApp(_TestAppointment.NewLDLAppID);
        }

        private void _LoadImageAndLabelForTestType()
        {
            switch (_EnTestType)
            {
                case _enTestType.Vision:
                    {
                        pbTestType.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\eye_chart.png";
                        lblTestType.Text = "Vision Test";
                        break;
                    }
                case _enTestType.Written:
                    {
                        pbTestType.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\cover_page.png";
                        lblTestType.Text = "Written Test";
                        break;
                    }
                case _enTestType.Street:
                    {
                        pbTestType.ImageLocation = "C:\\Users\\Amr\\source\\repos\\DVLD\\DVLD\\Images\\road_closed_sign (1).png";
                        lblTestType.Text = "Street Test";
                        break;
                    }
            }
            gbTestType.Text = lblTestType.Text;
        }

        private void _LoadTrialLabel()
        {
            switch (_EnTestType)
            {
                case _enTestType.Vision:
                    {
                        lblTrial.Text = _NewLDLApp.VisionTrial.ToString();
                        break;
                    }
                case _enTestType.Written:
                    {
                        lblTrial.Text = _NewLDLApp.WrittenTrial.ToString();
                        break;
                    }
                case _enTestType.Street:
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

            lblFees.Text = DBclsTestType.GetTestFees(Convert.ToInt32(_EnTestType)).ToString();

            lblDate.Text = _TestAppointment.TestDate.ToShortDateString();
            
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadImageAndLabelForTestType();

            _LoadDataToForm();
        }

        private bool _CheckIsRBChecked()
        {
            if(rbPass.Checked == false && rbFail.Checked == false)
            {
                MessageBox.Show("Please Check 'Pass' Or 'Fail'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void _IncreaseNumOfTrial()
        {
            switch (_EnTestType)
            {
                case _enTestType.Vision:
                    {
                        _NewLDLApp.VisionTrial++;
                        break;
                    }
                case _enTestType.Written:
                    {
                        _NewLDLApp.WrittenTrial++;
                        break;
                    }
                case _enTestType.Street:
                    {
                        _NewLDLApp.StreetTrial++;
                        break;
                    }
            }
        }

        private bool _Save()
        {
            if (_CheckIsRBChecked())
            {
                
                _Test.TestAppointmentID = _TestAppointment.TestAppointmentID;

                _Test.IsPassed = (rbPass.Checked);

                _Test.Note = txtNotes.Text;

                if (_Test.Save())
                {
                    MessageBox.Show("Result was saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if(_Test.IsPassed)
                    {
                        _TestAppointment.StatusID = 2;

                        _NewLDLApp.PassedTests++;

                        _IncreaseNumOfTrial();
                    }
                    else
                    {
                        _TestAppointment.StatusID = 2;

                        _IncreaseNumOfTrial();
                    }

                    _TestAppointment.Save();

                    _NewLDLApp.Save();

                    lblTrial.Text = (Convert.ToInt32(lblTrial.Text) + 1).ToString();

                    lblTestID.Text = _Test.TestID.ToString(); ;

                    btnSave.Enabled = false;

                    return true;
                }
                else
                    MessageBox.Show("Result was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
