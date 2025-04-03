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
    public partial class uctrlManageApplicationsTypes : UserControl
    {
        public uctrlManageApplicationsTypes()
        {
            InitializeComponent();
        }

        private void _LoadDateToDGV()
        {
            dgvApplicationsTypes.DataSource = DBclsApplicationType.GetAllApplicationsTypes();
            lblNumOfRecords.Text = dgvApplicationsTypes.Rows.Count.ToString();

            dgvApplicationsTypes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvApplicationsTypes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void uctrlManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            _LoadDateToDGV();
        }

        private int _GetAppTypeIDFromDGV()
        {
            return Convert.ToInt32(dgvApplicationsTypes.SelectedRows[0].Cells[0].Value);
        }

        private void tsmEditApplicationType_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType(_GetAppTypeIDFromDGV());
            frm.ShowDialog();
            _LoadDateToDGV();
        }
    }
}
