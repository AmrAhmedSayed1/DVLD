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
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _LoadDetainedLicenses()
        {
            dgvDetainedLicenses.DataSource = DBclsDetainedLicense.GetAllDetainedLicenses();

            _EditDGV();
        }

        private void _EditDGV()
        {
            if (dgvDetainedLicenses.Rows.Count > 0)
                dgvDetainedLicenses.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            lblNumOfRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void _LoadDetainedLicensesWithFilter()
        {

            dgvDetainedLicenses.DataSource = (txtFilter.Visible == true) ? DBclsDetainedLicense.GetAllDetainedLicensesWithFilter(cbFilterBy.SelectedItem.ToString(), txtFilter.Text) :
                (cbFilterBy.Visible == true) ? DBclsDetainedLicense.GetAllDetainedLicensesWithFilter(cbFilterBy.SelectedItem.ToString(), cbIsReleased.SelectedItem.ToString()) : null;

            _EditDGV();
        }

        private void _Refresh()
        {
            cbFilterBy.SelectedIndex = 0;
            cbIsReleased.Visible = false;
            txtFilter.Visible = false;
            _LoadDetainedLicenses();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.SelectedItem.ToString())
            {
                case "None":
                    {
                        cbIsReleased.Visible = false;
                        txtFilter.Visible = false;
                        _LoadDetainedLicenses();
                        break;
                    }
                case "Is Released":
                    {
                        cbIsReleased.Visible = true;
                        txtFilter.Visible = false;
                        cbIsReleased.SelectedIndex = 0;
                        _LoadDetainedLicensesWithFilter();
                        break;
                    }
                default:
                    {
                        cbIsReleased.Visible = false;
                        txtFilter.Visible = true;
                        txtFilter.Text = "";
                        _LoadDetainedLicenses();
                        break;
                    }
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadDetainedLicensesWithFilter();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _LoadDetainedLicensesWithFilter();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();

            _Refresh();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDL frm = new frmReleaseDL();
            frm.ShowDialog();

            _Refresh();
        }

        private void cmsManageDetainedLicenses_MouseEnter(object sender, EventArgs e)
        {
            tsmRelease.Enabled = !(Convert.ToBoolean(dgvDetainedLicenses.SelectedRows[0].Cells[3].Value) == true);
        }

        private int _GetLicenseID()
        {
            int LicenseID = (Convert.ToInt32(dgvDetainedLicenses.SelectedRows[0].Cells[1].Value));

            if (DBclsLicense.IsValueExist("Licenses", "LicenseID", LicenseID.ToString()))
                return LicenseID;
            else
            {
                MessageBox.Show("The License wich you selected was deleted before you selected it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;
            if ((LicenseID = _GetLicenseID()) == 0)
                return;

            DBclsLicense License = new DBclsLicense(LicenseID);

            DBclsDriver Driver = new DBclsDriver(License.DriverID);

            frmPersonalDetails frm = new frmPersonalDetails(Driver.PersonID);
            frm.ShowDialog();
        }

        private void tsmShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;
            if ((LicenseID = _GetLicenseID()) == 0)
                return;

            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void tsmShowLicenseHistory_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;
            if ((LicenseID = _GetLicenseID()) == 0)
                return;

            DBclsLicense License = new DBclsLicense(LicenseID);

            DBclsDriver Driver = new DBclsDriver(License.DriverID);

            frmLicensesHistory frm = new frmLicensesHistory(Driver.PersonID);
            frm.ShowDialog();
        }

        private void tsmRelease_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;
            if ((LicenseID = _GetLicenseID()) == 0)
                return;

            frmReleaseDL frm = new frmReleaseDL(LicenseID);
            frm.ShowDialog();

            _Refresh();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString() == "D.ID" || cbFilterBy.SelectedItem.ToString() == "ReleaseAppID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}