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

        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person frm = new frmAdd_Edit_Person(0);
            frm.ShowDialog();
            LoadAllPoeple();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if(!(dgvPoeple.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int PersonID = 0;

            PersonID = Convert.ToInt32(dgvPoeple.SelectedRows[0].Cells[0].Value);

            if (DBclsPerson.IsValueExist("PersonID", PersonID.ToString()))
            {
                frmAdd_Edit_Person frm = new frmAdd_Edit_Person(PersonID);
                frm.ShowDialog();
                LoadAllPoeple();
            }
            else
            {
                MessageBox.Show("This person was deleted before you clicked on them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAllPoeple();
                return;
            }

        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvPoeple.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int PersonID = 0;

            PersonID = Convert.ToInt32(dgvPoeple.SelectedRows[0].Cells[0].Value);

            if (DBclsPerson.IsValueExist("PersonID", PersonID.ToString()))
            {
                if(DBclsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("This person was deleted Successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPoeple();
                }
                else
                    MessageBox.Show("This person was not deleted Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("This person was deleted before you clicked on them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAllPoeple();
                return;
            }
        }

        private void tsmiShowDetails_Click(object sender, EventArgs e)
        {
            if (!(dgvPoeple.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int PersonID = 0;

            PersonID = Convert.ToInt32(dgvPoeple.SelectedRows[0].Cells[0].Value);

            if (DBclsPerson.IsValueExist("PersonID", PersonID.ToString()))
            {
                //frmPersonDetails frm = new frmPersonDetails(PersonID);
                //frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("This person was deleted before you clicked on them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAllPoeple();
                return;
            }
        }
    }
}
