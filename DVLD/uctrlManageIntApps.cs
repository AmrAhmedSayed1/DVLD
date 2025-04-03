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
    public partial class uctrlManageIntApps : UserControl
    {
        string FilterBy = "";
        string Value = "";
        public uctrlManageIntApps()
        {
            InitializeComponent();
        }

        private void _Styledgv()
        {
            lblNumOfRecords.Text = dgvI_LicensesApps.Rows.Count.ToString();

            if (dgvI_LicensesApps.Rows.Count > 0)
            {
                dgvI_LicensesApps.Columns[0].Width = 130;
                dgvI_LicensesApps.Columns[1].Width = 130;
                dgvI_LicensesApps.Columns[2].Width = 130;
                dgvI_LicensesApps.Columns[3].Width = 130;
                dgvI_LicensesApps.Columns[4].Width = 130;
                dgvI_LicensesApps.Columns[5].Width = 130;
                dgvI_LicensesApps.Columns[6].Width = 130;
            }
        }

        private void _Refresh()
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilter.Visible = false;
            cbIsActive.Visible = false;
            _LoadApps();
        }

        private void _LoadApps()
        {
            
            
            dgvI_LicensesApps.DataSource = DBclsI_License.GetAllApplications();

            _Styledgv();
        }

        private void uctrlManageIntApps_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _LoadAppsWithFilter(string FilterBy, string Value)
        {
            dgvI_LicensesApps.DataSource = DBclsI_License.GetAllApplicationsWithFilter(FilterBy, Value);
            _Styledgv();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
            switch(cbFilterBy.SelectedItem.ToString())
            {
                case "None":
                    {
                        _LoadApps();
                        break;
                    }
                case "Is Active":
                    {
                        cbIsActive.SelectedIndex = 0;
                        cbIsActive.Visible = true;
                        txtFilter.Visible = false;
                        FilterBy = "I_Licenses.IsActive";
                        break;
                    }
                case "I license ID":
                    {
                        FilterBy = "I_LicenseID";
                        cbIsActive.Visible= false;
                        txtFilter.Visible = true;
                        break;
                    }
                case "App ID":
                    {
                        FilterBy = "I_Licenses.ApplicationID";
                        cbIsActive.Visible = false;
                        txtFilter.Visible = true;
                        break;
                    }
                case "L License ID":
                    {
                        FilterBy = "LocalLicenseID";
                        cbIsActive.Visible = false;
                        txtFilter.Visible = true;
                        break;
                    }
                case "Driver ID":
                    {
                        FilterBy = "Drivers.DriverID";
                        cbIsActive.Visible = false;
                        txtFilter.Visible = true;
                        break;
                    }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Value = txtFilter.Text;
            _LoadAppsWithFilter(FilterBy, Value);
        }

        private void btnAddNewIDLApp_Click(object sender, EventArgs e)
        {
            frmIssueIDL frm = new frmIssueIDL();
            frm.ShowDialog();

            _Refresh();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.SelectedItem.ToString())
            {
                case "Yes":
                    {
                        Value = "1";
                        _LoadAppsWithFilter(FilterBy, Value);
                        break;
                    }
                case "No":
                    {
                        Value = "0";
                        _LoadAppsWithFilter(FilterBy, Value);
                        break;
                    }
            }
        }

        private int _GetILicenseAppIDFromDGV()
        {
            if (!(dgvI_LicensesApps.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return Convert.ToInt32(dgvI_LicensesApps.SelectedRows[0].Cells[0].Value);
        }

        private int _GetPersonIDfromDGV()
        {
            int ILAppID;
            if ((ILAppID = _GetILicenseAppIDFromDGV()) == 0)
                return 0;

            DBclsI_License ILicense = new DBclsI_License(ILAppID);
            DBclsDriver Driver = new DBclsDriver(ILicense.DriverID);

            return Driver.PersonID;
        }

        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {
            int PersonID = 0;
            if ((PersonID = _GetPersonIDfromDGV()) == 0)
                return;
            frmPersonalDetails frm = new frmPersonalDetails(PersonID);
            frm.ShowDialog();
        }

        private void tsmShowLicenseInfo_Click(object sender, EventArgs e)
        {
            int ILAppID;
            if ((ILAppID = _GetILicenseAppIDFromDGV()) == 0)
                return;

            DBclsI_License ILicense = new DBclsI_License(ILAppID);
            frmI_LicenseInfo frm = new frmI_LicenseInfo(ILicense);
            frm.ShowDialog();
        }

        private void tsmShowPersonLHis_Click(object sender, EventArgs e)
        {
            int PersonID = 0;
            if ((PersonID = _GetPersonIDfromDGV()) == 0)
                return;

            frmLicensesHistory frm = new frmLicensesHistory(PersonID);
            frm.ShowDialog();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}