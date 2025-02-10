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
    public partial class uctrlManageTestsTypes : UserControl
    {
        public uctrlManageTestsTypes()
        {
            InitializeComponent();
        }

        private void _LoadDateToDGV()
        {
            dgvTestsTypes.DataSource = DBclsTestType.GetAllTestsTypes();
            lblNumOfRecords.Text = dgvTestsTypes.Rows.Count.ToString();

            dgvTestsTypes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void uctrlManageTestsTypes_Load(object sender, EventArgs e)
        {
            _LoadDateToDGV();
        }

        private int _GetTestTypeIDFromDGV()
        {
            return Convert.ToInt32(dgvTestsTypes.SelectedRows[0].Cells[0].Value);
        }

        private void tsmEditApplicationType_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType(_GetTestTypeIDFromDGV());
            frm.ShowDialog();
            _LoadDateToDGV();
        }
    }
}
