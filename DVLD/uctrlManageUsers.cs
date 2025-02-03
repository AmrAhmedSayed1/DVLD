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
    public partial class uctrlManageUsers : UserControl
    {

        private string _FilterBy = "";
        private string _Filtertxt = "";

        private void _LoadAllUsersWithFilter()
        {
            if (_FilterBy == "Is Active")
            {
                _Filtertxt = cbIsActive.SelectedItem.ToString();
            }
            dgvUsers.DataSource = DBclsUser.GitAllUsersWithFilter(_FilterBy, _Filtertxt);

            lblNumOfRecords.Text = dgvUsers.Rows.Count.ToString();
            if(dgvUsers.Rows.Count > 0)
                dgvUsers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void _LoadAllUsers()
        {
            dgvUsers.DataSource = DBclsUser.GitAllUsers();
            lblNumOfRecords.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
                dgvUsers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public uctrlManageUsers()
        {
            InitializeComponent();

            dgvUsers.DataSource = DBclsUser.GitAllUsers();
        }

        public void uctrlManageUsers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllUsers();

            _FilterBy = cbFilterBy.Text;

            if (_FilterBy != "None")
            {
                if (_FilterBy == "Is Active")
                {
                    cbIsActive.Visible = true;
                    txtFilter.Visible = false;
                    cbIsActive.SelectedItem = "All";
                }
                else
                {
                    cbIsActive.Visible = false;
                    txtFilter.Visible = true;
                }
            }
            else
            {
                cbIsActive.Visible = false;
                txtFilter.Visible = false;
            }

            txtFilter.Text = "";
        }


        private int _GetUserIDFromDGV()
        {
            if (!(dgvUsers.SelectedRows.Count > 0))
            {
                MessageBox.Show("Please select a row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
        }

        private void _RefreshDGVAfterAction()
        {
            if (txtFilter.Visible == true)
                txtFilter.Text = "";
            else if (cbIsActive.Visible == true)
                cbIsActive.SelectedItem = "Alle";
            else
                _LoadAllUsers();
        }

        private void _ShowMessageError()
        {
            MessageBox.Show("This User was deleted before you clicked on them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _LoadAllUsers();
        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _LoadAllUsers();
                return;
            }

            if (_FilterBy == "User ID" || _FilterBy == "Person ID")
            {
                if (!int.TryParse(txtFilter.Text, out int val))
                {
                    if (txtFilter.Text != "")
                    {
                        var sb = new StringBuilder(txtFilter.Text);
                        sb.Remove(txtFilter.Text.Length - 1, 1);
                        txtFilter.Text = sb.ToString();
                        _Filtertxt = txtFilter.Text;
                        return;
                    }
                }
            }

            _Filtertxt = txtFilter.Text;

            _LoadAllUsersWithFilter();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedItem.ToString() == "All")
            {
                _LoadAllUsers();
            }
            else
                _LoadAllUsersWithFilter();
        }

        private void btnAddNewUser_Click_1(object sender, EventArgs e)
        {
            frmAdd_Edit_User frm = new frmAdd_Edit_User(0);
            frm.ShowDialog();
            _RefreshDGVAfterAction();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterBy == "User ID" || _FilterBy == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void tsmiShowDetails_Click_1(object sender, EventArgs e)
        {
            int UserID;
            if ((UserID = _GetUserIDFromDGV()) == 0)
                return;

            if (DBclsUser.IsValueExist("UserID", UserID.ToString()))
            {
                frmUserDetails frm = new frmUserDetails(UserID);
                frm.ShowDialog();
            }
            else
            {
                _ShowMessageError();
                return;
            }
        }

        private void tsmiAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAdd_Edit_User frm = new frmAdd_Edit_User(0);
            frm.ShowDialog();
            _RefreshDGVAfterAction();
        }

        private void tsmiEdit_Click_1(object sender, EventArgs e)
        {
            int UserID;
            if ((UserID = _GetUserIDFromDGV()) == 0)
                return;
            frmAdd_Edit_User frm = new frmAdd_Edit_User(UserID);
            frm.ShowDialog();
            _RefreshDGVAfterAction();
        }

        private void tsmiDelete_Click_1(object sender, EventArgs e)
        {
            int UserID;
            if ((UserID = _GetUserIDFromDGV()) == 0)
                return;
            if(MessageBox.Show("Are you sure you want to delete this user ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (DBclsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User Was Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshDGVAfterAction();
                }
                else
                    MessageBox.Show("User Was not Deleted Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                        
        }

        private void tsmiSendEmail_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmiPhoneCall_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!", "Not ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            int UserID;
            if ((UserID = _GetUserIDFromDGV()) == 0)
                return;
            frmChangePassword frm = new frmChangePassword(UserID);
            frm.ShowDialog();
        }
    }
}