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
    public partial class frmManageTestsAppointments : Form
    {
        private DBclsNewLDLApp NewLDLApp = new DBclsNewLDLApp();
        public enum _enTestType { Vision = 1, Written = 2, Street = 3 }
        public _enTestType _EnTestType;

        public frmManageTestsAppointments(DBclsNewLDLApp newLDLApp, _enTestType TestType)
        {
            InitializeComponent();
            NewLDLApp = newLDLApp;
            _EnTestType = TestType;
        }

        private void _LoadImageAndLableForTestType()
        {
            switch(_EnTestType)
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
        }

        private void frmManageTestsAppointments_Load(object sender, EventArgs e)
        {
            _LoadImageAndLableForTestType();
            uctrlNewLDLAppInfo1.NewLDLApp = NewLDLApp;
            uctrlNewLDLAppInfo1.LoadNewLDLAppInfo();
            uctrlAppInfo1.App = new DBclsApplication(NewLDLApp.AppID);
            uctrlAppInfo1.LoaductrlAppInfo();
            _LoadTestsAppointments();
        }

        private void _LoadTestsAppointments()
        {
            dgvTestsAppointments.DataSource = DBclsTestAppointment.GitAllTestsAppointmentsWithFilter(NewLDLApp.NewLDLAppID, Convert.ToInt32(_EnTestType));
            if (dgvTestsAppointments.Rows.Count > 0)
            {
                dgvTestsAppointments.Columns["Appointment ID"].Width = 200;
                dgvTestsAppointments.Columns["Appointment Date"].Width = 200;
                dgvTestsAppointments.Columns["Paid Fees"].Width = 200;
                dgvTestsAppointments.Columns["Is Locked"].Width = 100;
            }
            lblNumOfRecords.Text = dgvTestsAppointments.Rows.Count.ToString();
        }

        private void _AddNewTestAppointment()
        {
            if (dgvTestsAppointments.Rows.Count == 0)
            {
                frmAddEditTestAppointment frm = new frmAddEditTestAppointment(NewLDLApp, (frmAddEditTestAppointment.enTestType)_EnTestType, frmAddEditTestAppointment.enMode_NewOrRetakeTest.New, frmAddEditTestAppointment.enIsEditMode.No, 0);
                frm.ShowDialog();
                _LoadTestsAppointments();

            }
            else
            {
                foreach (DataGridViewRow r in dgvTestsAppointments.Rows)
                {
                    if (Convert.ToBoolean(r.Cells[3].Value) == false)
                    {
                        MessageBox.Show("Please Finish The Current Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                frmAddEditTestAppointment frm = new frmAddEditTestAppointment(NewLDLApp, (frmAddEditTestAppointment.enTestType)_EnTestType, frmAddEditTestAppointment.enMode_NewOrRetakeTest.ReTakeTest, frmAddEditTestAppointment.enIsEditMode.No, 0);
                frm.ShowDialog();
                _LoadTestsAppointments();
            }
        }

        private void btnAddNewTestAppointment_Click(object sender, EventArgs e)
        {
            _AddNewTestAppointment();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int _GetUserIDFromDGV()
        {
            if (!(dgvTestsAppointments.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return Convert.ToInt32(dgvTestsAppointments.SelectedRows[0].Cells[0].Value);
        }

        private void _TakeTest()
        {
            int TestAppointmentID;
            if ((TestAppointmentID = _GetUserIDFromDGV()) == 0)
                return;
            frmTakeTest frm = new frmTakeTest(new DBclsTestAppointment(TestAppointmentID), (frmTakeTest._enTestType)_EnTestType);
            frm.ShowDialog();
            _LoadTestsAppointments();
        }

        private void tsmTakeTest_Click(object sender, EventArgs e)
        {
            _TakeTest();
        }

        private void cmsTestsAppointments_MouseEnter(object sender, EventArgs e)
        {
            if(dgvTestsAppointments.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dgvTestsAppointments.SelectedRows[0].Cells[3].Value) == true)
                {
                    tsmTakeTest.Enabled = false;
                    tsmEditTestAppointment.Enabled = false;
                }
                else
                {
                    tsmTakeTest.Enabled = true;
                    tsmEditTestAppointment.Enabled = true;
                }
            }
        }

        private void _EditTest()
        {
            int TestAppointmentID;
            if ((TestAppointmentID = _GetUserIDFromDGV()) == 0)
                return;

            frmAddEditTestAppointment frm;
            if (dgvTestsAppointments.Rows.Count > 1)
                frm = new frmAddEditTestAppointment(NewLDLApp, (frmAddEditTestAppointment.enTestType)_EnTestType, frmAddEditTestAppointment.enMode_NewOrRetakeTest.ReTakeTest, frmAddEditTestAppointment.enIsEditMode.Yes, TestAppointmentID);
            else
                frm = new frmAddEditTestAppointment(NewLDLApp, (frmAddEditTestAppointment.enTestType)_EnTestType, frmAddEditTestAppointment.enMode_NewOrRetakeTest.New, frmAddEditTestAppointment.enIsEditMode.Yes, TestAppointmentID);

            frm.ShowDialog();
            _LoadTestsAppointments();
        }

        private void tsmEditTestAppointment_Click(object sender, EventArgs e)
        {
            _EditTest();
        }
    }
}