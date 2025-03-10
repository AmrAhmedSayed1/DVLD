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

        private void _HandllingScheduleTests_EnabledOrNo(int PassedTests)
        {
            tsmIssueDLFT.Enabled = PassedTests == 3;
            tsmScheduleTests.Enabled = PassedTests != 3;
            tsmScheduleVisionTest.Enabled = PassedTests == 0;
            tsmScheduleWrittenTest.Enabled = PassedTests == 1;
            tsmScheduleStreetTest.Enabled = PassedTests == 2;
            
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
            frmAddNewLDLApp frm = new frmAddNewLDLApp();
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
            int AppID;
            if ((AppID = _GetNewLDLAppIDFromDGV()) == 0)
                return;

            if (DBclsApplication.IsValueExist(AppID.ToString()))
            {
                DBclsApplication App = new DBclsApplication(AppID);

                DBclsNewLDLApp NewLDLApp = new DBclsNewLDLApp(App.AppID, true);

                _HandllingScheduleTests_EnabledOrNo(NewLDLApp.PassedTests);
            }
            else
            {
                _ShowMessageError();
                return;
            }
        }
    }
}
