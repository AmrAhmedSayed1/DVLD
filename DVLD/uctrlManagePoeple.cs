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

        private void LoadAllPoepleWithFilter()
        {
            dgvPoeple.DataSource = DBclsPerson.GitAllPoepleWithFilter(FilterBy, Filtertxt);
            lblNumOfRecords.Text = dgvPoeple.Rows.Count.ToString();
        }

        private void LoadAllPoeple()
        {
            dgvPoeple.DataSource = DBclsPerson.GitAllPoeple();
            lblNumOfRecords.Text = dgvPoeple.Rows.Count.ToString();
        }

        public uctrlManagePoeple()
        {
            InitializeComponent();

            dgvPoeple.DataSource = DBclsPerson.GitAllPoeple();
        }

        private void dgvPoeple_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void uctrlManagePoeple_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllPoeple();

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
            if (FilterBy == "Phone" || FilterBy == "PersonID")
            {
                if (!int.TryParse(txtFilter.Text, out int val))
                {
                    if (txtFilter.Text != "")
                    {
                        var sb = new StringBuilder(txtFilter.Text);
                        sb.Remove(txtFilter.Text.Length - 1, 1);
                        txtFilter.Text = sb.ToString();
                        Filtertxt = txtFilter.Text;
                        return;
                    }
                }
            }

            Filtertxt = txtFilter.Text;

            LoadAllPoepleWithFilter();
        }

        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person frm = new frmAdd_Edit_Person(0);
            frm.ShowDialog();
            LoadAllPoeple();
        }
    }
}
