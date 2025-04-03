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
    public partial class uctrlManageNewLDLApps : UserControl
    {
        private string _FilterBy = "";
        private string _Filtertxt = "";
        public uctrlManageNewLDLApps()
        {
            InitializeComponent();
        }

        public void LoadAllAppsToDGV()
        {
            dgvLDLApps.DataSource = DBclsNewLDLApp.GetAllNewLDLApps();

            if (dgvLDLApps.Rows.Count > 0)
            {
                dgvLDLApps.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLDLApps.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            lblNumOfRecords.Text = dgvLDLApps.Rows.Count.ToString();

        }

        private void _LoadAllAppsWithFilterToDGV()
        {
            dgvLDLApps.DataSource = DBclsNewLDLApp.GetAllNewLDLAppsWithFilter(_FilterBy, _Filtertxt);

            if (dgvLDLApps.Rows.Count > 0)
            {
                dgvLDLApps.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvLDLApps.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            lblNumOfRecords.Text = dgvLDLApps.Rows.Count.ToString();
        }

        private void uctrlManageLDLApps_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            LoadAllAppsToDGV();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllAppsToDGV();

            _FilterBy = cbFilterBy.Text;

            switch (_FilterBy)
            {
                case "None":
                    {
                        cbStatus.Visible = false;
                        txtFilter.Visible = false;
                        return;
                    }
                case "Status":
                    {
                        _FilterBy = "StatusName";
                        cbStatus.Visible = true;
                        txtFilter.Visible = false;
                        cbStatus.SelectedItem = "All";
                        return;
                    }
                case "L.D.L App ID":
                    {
                        _FilterBy = "Applications.ApplicationID";
                        break;
                    }
                case "Full Name":
                    {
                        _FilterBy = "(Poeple.FirstName + ' ' + Poeple.SecondName + ' ' + Poeple.ThirdName + ' ' + ' ' + Poeple.LastName)";
                        break;
                    }
                default:
                    {
                        _FilterBy = cbFilterBy.SelectedItem.ToString().Replace(" ", "");
                        break;
                    }
            }

            cbStatus.Visible = false;
            txtFilter.Visible = true;
            txtFilter.Text = "";
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbStatus.SelectedItem.ToString() != "All")
            {
                _Filtertxt = cbStatus.SelectedItem.ToString();
                _LoadAllAppsWithFilterToDGV();
                return;
            }
            LoadAllAppsToDGV();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                LoadAllAppsToDGV();
                return;
            }



            _Filtertxt = txtFilter.Text;

            _LoadAllAppsWithFilterToDGV();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "L.D.L App ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddNewLDLApp_Click(object sender, EventArgs e)
        {
            frmAdd_EditNewLDLApp frm = new frmAdd_EditNewLDLApp();
            frm.ShowDialog();
            RefreshDGVAfterAction();
        }

        private int _GetNewLDLAppIDFromDGV()
        {
            if (!(dgvLDLApps.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return Convert.ToInt32(dgvLDLApps.SelectedRows[0].Cells[0].Value);
        }

        public void RefreshDGVAfterAction()
        {
            LoadAllAppsToDGV();
            cbFilterBy.SelectedIndex = 0;
            txtFilter.Visible = false;
            cbStatus.Visible = false;
        }

        private void _ShowMessageError()
        {
            MessageBox.Show("This Application was deleted before you clicked on them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsmCancelApp_Click(object sender, EventArgs e)
        {
            int NewLDLAppID;
            if ((NewLDLAppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;


            if (DBclsApplication.IsValueExist(NewLDLAppID.ToString()))
            {
                DBclsApplication App = new DBclsApplication(NewLDLAppID);

                if (App.AppStatusID == 3) //  Status ID {1 = New|  2 = Complate| 3 = Canceld|
                {
                    MessageBox.Show("This application already canceld", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(MessageBox.Show("Are you sure you want to cancel this Application ? ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    App.AppStatusID = 3; //  Canceld

                    if (App.Save())
                    {
                        MessageBox.Show("This Application was Canceld Successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDGVAfterAction();
                    }
                    else
                        MessageBox.Show("This Application was not Canceld Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                _ShowMessageError();
                return;
            }
        }

        private void cmsManagePerson_MouseEnter(object sender, EventArgs e)
        {
            _MakeTSMSenabledFalse();
        }

        private void _HandllingTSMS_Enable_New()
        {
            tsmShowLicense.Enabled = false;

            tsmShowAppDetails.Enabled = true;
            tsmEditApp.Enabled = true;
            tsmDeleteApp.Enabled = true;
            tsmCancelApp.Enabled = true;
        }

        private void _HandllingTSMS_Enable_Complated()
        {
            tsmEditApp.Enabled = false;
            tsmDeleteApp.Enabled = false;
            tsmCancelApp.Enabled = false;
            tsmScheduleTests.Enabled = false;
            tsmIssueDLFT.Enabled = false;

            tsmShowAppDetails.Enabled = true;
            tsmShowLicense.Enabled = true;
        }

        private void _HandllingTSMS_Enable_Cancel()
        {
            tsmEditApp.Enabled = false;
            tsmDeleteApp.Enabled = false;
            tsmCancelApp.Enabled = false;
            tsmScheduleTests.Enabled = false;
            tsmIssueDLFT.Enabled = false;
            tsmShowLicense.Enabled = false;

            tsmShowAppDetails.Enabled = true;
        }

        private void _ScheduleTest(frmManageTestsAppointments._enTestType TestType)
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            if (DBclsApplication.IsValueExist(AppID.ToString()))
            {
                DBclsNewLDLApp NewLDLApp = new DBclsNewLDLApp(AppID, true);

                frmManageTestsAppointments frm = new frmManageTestsAppointments(NewLDLApp, TestType);

                frm.ShowDialog();
            }

            else
            {
                _ShowMessageError();
                return;
            }
        }

        private void _HandillingScheduleTests()
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            DBclsNewLDLApp newLDLApp = new DBclsNewLDLApp(AppID, true);

            tsmScheduleTests.Enabled = (newLDLApp.PassedTests != 3);
            tsmScheduleVisionTest.Enabled = (newLDLApp.PassedTests == 0);
            tsmScheduleWrittenTest.Enabled = (newLDLApp.PassedTests == 1);
            tsmScheduleStreetTest.Enabled = (newLDLApp.PassedTests == 2);
            tsmIssueDLFT.Enabled = (newLDLApp.PassedTests == 3 && DBclsLicense.IsValueExist("Licenses", "ApplicationID", AppID.ToString()) == false);
        }

        private void _MakeTSMSenabledFalse()
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;
            DBclsApplication App = new DBclsApplication(AppID);

            _HandillingScheduleTests();

            if (App.AppStatusID == 1)
                _HandllingTSMS_Enable_New();
            else if (App.AppStatusID == 2)
                _HandllingTSMS_Enable_Complated();
            else
                _HandllingTSMS_Enable_Cancel();

            
        }

        private void tsmScheduleVisionTest_Click(object sender, EventArgs e)
        {
            _ScheduleTest(frmManageTestsAppointments._enTestType.Vision);
            
            RefreshDGVAfterAction();
        }

        private void tsmScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            _ScheduleTest(frmManageTestsAppointments._enTestType.Written);

            RefreshDGVAfterAction();
        }

        private void tsmScheduleStreetTest_Click(object sender, EventArgs e)
        {
            _ScheduleTest(frmManageTestsAppointments._enTestType.Street);

            RefreshDGVAfterAction();
        }

        private void tsmIssueDLFT_Click(object sender, EventArgs e)
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            frmIssueLDL frm = new frmIssueLDL(new DBclsNewLDLApp(AppID, true));

            frm.ShowDialog();
        }

        private void tsmShowLicense_Click(object sender, EventArgs e)
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            DBclsLicense license = new DBclsLicense(AppID, true);
            frmLicenseInfo frm = new frmLicenseInfo(license.LicenseID);
            frm.ShowDialog();
        }

        private void tsmShowAppDetails_Click(object sender, EventArgs e)
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            frmAppInfo frm = new frmAppInfo(new DBclsApplication(AppID));
            frm.ShowDialog();
        }

        private void tsmShowPersonLHis_Click(object sender, EventArgs e)
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            DBclsApplication App = new DBclsApplication(AppID);

            frmLicensesHistory frm = new frmLicensesHistory(App.PersonID);
            frm.ShowDialog();
        }

        private bool _DeleteNewLDLApp(int AppID)
        {
            DBclsNewLDLApp newLDLApp = new DBclsNewLDLApp(AppID, true);

            if (MessageBox.Show("Are you sure you want to delete this Application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (DBclsNewLDLApp.DeleteNewLDLApp(newLDLApp.NewLDLAppID))
                {
                    if (DBclsApplication.DeleteAppliaction(AppID))
                    {
                        MessageBox.Show("The application has been deleted successfully?", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                
            }
            MessageBox.Show("This Application has not been deleted because it is linked to other data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        private void tsmDeleteApp_Click(object sender, EventArgs e)
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            _DeleteNewLDLApp(AppID);
            RefreshDGVAfterAction();
        }

        private void tsmEditApp_Click(object sender, EventArgs e)
        {
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            DBclsNewLDLApp newLDLApp = new DBclsNewLDLApp(AppID, true);

            if (newLDLApp.PassedTests == 0)
            {
                frmAdd_EditNewLDLApp frm = new frmAdd_EditNewLDLApp(newLDLApp, frmAdd_EditNewLDLApp._enAddOrEdit.Edit);
                frm.ShowDialog();
                RefreshDGVAfterAction();
            }
            else
                MessageBox.Show("This operation is not allowed because the number of passed tests is greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}