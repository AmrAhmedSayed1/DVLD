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
    public partial class frmEditApplicationType : Form
    {
        private int AppTypeID;
        public frmEditApplicationType(int AppTypeID)
        {
            InitializeComponent();
            this.AppTypeID = AppTypeID;
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            lblAppTypeID.Text = AppTypeID.ToString();
        }

        private void _CheckTextBoxIsNotEmpty(TextBox textbox, ErrorProvider ep)
        {

            if (string.IsNullOrEmpty(textbox.Text))
            {
                ep.SetError(textbox, "This Feild can't be empty");
                textbox.Tag = 0;
            }
            else
            {
                ep.Clear();
                textbox.Tag = 1;
            }
        }
        private void txtAppTypeName_TextChanged(object sender, EventArgs e)
        {
            _CheckTextBoxIsNotEmpty(txtAppTypeName, epAppTypeName);
        }

        private void txtAppTypeFees_TextChanged(object sender, EventArgs e)
        {
            _CheckTextBoxIsNotEmpty(txtAppTypeFees, epAppTypeFees);
        }

        private void txtAppTypeFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private bool _CheckAllDateRight()
        {
            if((string.IsNullOrWhiteSpace(txtAppTypeName.Text) || string.IsNullOrWhiteSpace(txtAppTypeFees.Text)))
            {
                MessageBox.Show("Please Enter All Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_CheckAllDateRight())
            {
                if (DBclsApplicationType.UpateApplicationType(AppTypeID, txtAppTypeName.Text, Convert.ToSingle(txtAppTypeFees.Text)))
                {
                    MessageBox.Show("The Application Type was updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("The Application Type was not updated successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
