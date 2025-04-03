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
    public partial class uctrlManageDrivers : UserControl
    {
        public uctrlManageDrivers()
        {
            InitializeComponent();
        }

        private void _EditDGV()
        {
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDrivers.Columns[5].Width = 130;
            }
        }

        private void _LoadDrivers()
        {
            dgvDrivers.DataSource = DBclsDriver.GetAllDrivers();
            lblNumOfRecords.Text = dgvDrivers.Rows.Count.ToString();
            
            _EditDGV();
        }

        private void _LoadDriversWithFilter(string ColumnName, string Value)
        {
            dgvDrivers.DataSource = DBclsDriver.GetAllDriversWithFilter(ColumnName, Value);
            lblNumOfRecords.Text = dgvDrivers.Rows.Count.ToString();

            _EditDGV();
        }

        private void uctrlManageDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _LoadDrivers();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
            }

            _LoadDrivers();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _LoadDriversWithFilter(cbFilterBy.SelectedItem.ToString(), txtFilter.Text);
        }

        private int _GetPersonID()
        {
            int PersonID = (Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells[1].Value));

            if (DBclsLicense.IsValueExist("Poeple", "PersonID", PersonID.ToString()))
                return PersonID;
            else
            {
                MessageBox.Show("The Driver wich you selected was deleted before you selected it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {
            int PersonID = 0;

            if ((PersonID = _GetPersonID()) == 0)
                return;

            frmPersonalDetails frm = new frmPersonalDetails(PersonID);
            frm.ShowDialog();
        }

        private void tsmShowLicenseHistory_Click(object sender, EventArgs e)
        {
            int PersonID = 0;

            if ((PersonID = _GetPersonID()) == 0)
                return;

            frmLicensesHistory frm = new frmLicensesHistory(PersonID);
            frm.ShowDialog();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "Driver ID" || cbFilterBy.SelectedItem.ToString() == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
