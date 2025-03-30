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
    }
}
