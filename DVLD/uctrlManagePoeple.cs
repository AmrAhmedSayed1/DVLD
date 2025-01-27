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
    public partial class uctrlManagePoeple : UserControl
    {
        private string FilterBy = "";
        private string Filtertxt = "";

        private void LoadAAPoepleWithFilter()
        {
            dgvPoeple.DataSource = DBclsPoeple.GitAllPoepleWithFilter(FilterBy, Filtertxt);
            lblNumOfRecords.Text = dgvPoeple.Rows.Count.ToString();
        }

        private void LoadAAPoeple()
        {
            dgvPoeple.DataSource = DBclsPoeple.GitAllPoeple();
            lblNumOfRecords.Text = dgvPoeple.Rows.Count.ToString();
        }

        public uctrlManagePoeple()
        {
            InitializeComponent();

            dgvPoeple.DataSource = DBclsPoeple.GitAllPoeple();
        }

        private void dgvPoeple_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void uctrlManagePoeple_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAAPoeple();

            FilterBy = cbFilterBy.Text.Replace(" ", "");

            if (FilterBy != "None")
                txtFilter.Visible = true;
            else
                txtFilter.Visible = false;

            if (FilterBy == "Nationality")
                FilterBy = "CountryName";

            txtFilter.Text = "";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            Filtertxt = txtFilter.Text;

            LoadAAPoepleWithFilter();
        }
    }
}
