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
        private string _FilterBy = "";
        private string _Filtertxt = "";

        private void _LoadAllPoepleWithFilter()
        {
            if(_FilterBy == "Gender")
            {
                _Filtertxt = cbGender.SelectedItem.ToString();
            }
            dgvPoeple.DataSource = DBclsPerson.GitAllPoepleWithFilter(_FilterBy, _Filtertxt);

            lblNumOfRecords.Text = dgvPoeple.Rows.Count.ToString();
        }

        private void _LoadAllPoeple()
        {
            dgvPoeple.DataSource = DBclsPerson.GitAllPoeple();
            lblNumOfRecords.Text = dgvPoeple.Rows.Count.ToString();
        }

        public uctrlManagePoeple()
        {
            InitializeComponent();

            dgvPoeple.DataSource = DBclsPerson.GitAllPoeple();
        }

        public void uctrlManagePoeple_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllPoeple();

            _FilterBy = cbFilterBy.Text.Replace(" ", "");

            if (_FilterBy != "None")
            {
                if(_FilterBy == "Gender")
                {
                    cbGender.Visible = true;
                    txtFilter.Visible = false;
                    cbGender.SelectedItem = "All";
                }
                else
                {
                    cbGender.Visible = false;
                    txtFilter.Visible = true;
                }
            }
            else
            {
                cbGender.Visible = false;
                txtFilter.Visible = false;
            }

            if (_FilterBy == "Nationality")
                _FilterBy = "CountryName";

            txtFilter.Text = "";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
       {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _LoadAllPoeple();
                return;
            }

            

            _Filtertxt = txtFilter.Text;

            _LoadAllPoepleWithFilter();
        }


        private int _GetPersonIDFromDGV()
        {
            if (!(dgvPoeple.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return Convert.ToInt32(dgvPoeple.SelectedRows[0].Cells[0].Value);
        }

        private void _RefreshDGVAfterAction()
        {
            if (txtFilter.Visible == true)
                txtFilter.Text = "";
            else if (cbGender.Visible == true)
                cbGender.SelectedItem = "Alle";
            else
                _LoadAllPoeple();
        }

        private void _ShowMessageError()
        {
            MessageBox.Show("This person was deleted before you clicked on them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _LoadAllPoeple();
        }

        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person frm = new frmAdd_Edit_Person(0);
            frm.ShowDialog();
            _LoadAllPoeple();
        }


        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Person frm = new frmAdd_Edit_Person(0);
            frm.ShowDialog();
            _RefreshDGVAfterAction();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {

            int PersonID;
            if ((PersonID = _GetPersonIDFromDGV()) == 0)
                return;

            if (DBclsPerson.IsValueExist("PersonID", PersonID.ToString()))
            {
                frmAdd_Edit_Person frm = new frmAdd_Edit_Person(PersonID);
                frm.ShowDialog();
                _RefreshDGVAfterAction();
            }
            else
            {
                _ShowMessageError();
                return;
            }

        }

        private bool _CheckIsPersonConnectedWithData(int PersonID)
        {
            if(DBclsUser.IsValueExist("PersonID", PersonID.ToString()))
            {
                MessageBox.Show("This person cannot be deleted because there are data associated with them in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            int PersonID;
            if ((PersonID = _GetPersonIDFromDGV()) == 0)
                return;


            if (DBclsPerson.IsValueExist("PersonID", PersonID.ToString()))
            {
                if (MessageBox.Show("Are you sure you want to delete this person?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (_CheckIsPersonConnectedWithData(PersonID))
                        return;
                    if (DBclsPerson.DeletePerson(PersonID))
                    {
                        MessageBox.Show("This person was deleted Successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshDGVAfterAction();
                    }
                    else
                        MessageBox.Show("This person was not deleted Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    return;


            }
            else
            {
                _ShowMessageError();
                return;
            }
        }

        private void tsmiShowDetails_Click(object sender, EventArgs e)
        {
            int PersonID;
            if ((PersonID = _GetPersonIDFromDGV()) == 0)
                return;

            if (DBclsPerson.IsValueExist("PersonID", PersonID.ToString()))
            {
                frmPersonalDetails frm = new frmPersonalDetails(PersonID);
                frm.ShowDialog();
            }
            else
            {
                _ShowMessageError();
                return;
            }
        }

        private void tsmiSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void tsmiPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbGender.SelectedItem.ToString() == "All")
            {
                _LoadAllPoeple();
            }
            else
                _LoadAllPoepleWithFilter();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterBy == "Phone" || _FilterBy == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
