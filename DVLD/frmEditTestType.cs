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
    public partial class frmEditTestType : Form
    {
        private int TestTypeID;
        public frmEditTestType(int testTypeID)
        {
            InitializeComponent();
            TestTypeID = testTypeID;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            lblTestTypeID.Text = TestTypeID.ToString();
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


        private bool _CheckAllDateRight()
        {
            if ((string.IsNullOrWhiteSpace(txtTestTypeName.Text) || string.IsNullOrWhiteSpace(txtTestTypeDescription.Text) || string.IsNullOrWhiteSpace(txtTestTypeFees.Text)))
            {
                MessageBox.Show("Please Enter All Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTestTypeFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CheckAllDateRight())
            {
                if (DBclsTestType.UpateTestType(TestTypeID, txtTestTypeName.Text, txtTestTypeDescription.Text, Convert.ToSingle(txtTestTypeFees.Text)))
                {
                    MessageBox.Show("The Test Type was updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("The Test Type was not updated successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
