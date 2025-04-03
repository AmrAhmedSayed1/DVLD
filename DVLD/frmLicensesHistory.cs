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
    public partial class frmLicensesHistory : Form
    {
        private int PersonID = 0;
        public frmLicensesHistory(int personid)
        {
            InitializeComponent();
            PersonID = personid;
        }

        private void _LoadLDLS()
        {
            dgvLDLS.DataSource = DBclsLicense.GetAllLicenseWithFilter(PersonID);
            if (dgvLDLS.Rows.Count > 0)
            {
                dgvLDLS.Columns[2].Width = 250;
                dgvLDLS.Columns[3].Width = 250;
                dgvLDLS.Columns[4].Width = 245;
            }
        }

        private void _LoadI_LDLS()
        {
            dgvI_Licenses.DataSource = DBclsI_License.GetAllLicenseWithFilter(PersonID);
            if (dgvI_Licenses.Rows.Count > 0)
            {
                dgvI_Licenses.Columns[0].Width = 200;
                dgvI_Licenses.Columns[1].Width = 200;
                dgvI_Licenses.Columns[3].Width = 200;
            }
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            uctrlPersonalDetails1.PersonID = PersonID;
            uctrlPersonalDetails1.LoadDataToForm();

            _LoadLDLS();
            _LoadI_LDLS();
        }

        private int _GetLicenseID()
        {
            int LicenseID = (Convert.ToInt32(dgvLDLS.SelectedRows[0].Cells[0].Value));

            if (DBclsLicense.IsValueExist("Licenses", "LicenseID", LicenseID.ToString()))
                return LicenseID;

            else
            {
                MessageBox.Show("The License wich you selected was deleted before you selected it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int _GetILicenseID()
        {
            int ILicenseID = (Convert.ToInt32(dgvI_Licenses.SelectedRows[0].Cells[0].Value));

            if (DBclsLicense.IsValueExist("I_Licenses", "I_LicenseID", ILicenseID.ToString()))
                return ILicenseID;

            else
            {
                MessageBox.Show("The License wich you selected was deleted before you selected it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void tsmShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;

            if ((LicenseID = _GetLicenseID()) == 0)
                return;

            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void tsmShowILicenseDetails_Click(object sender, EventArgs e)
        {
            int ILicenseID = 0;

            if ((ILicenseID = _GetILicenseID()) == 0)
                return;

            frmI_LicenseInfo frm = new frmI_LicenseInfo(new DBclsI_License(ILicenseID));
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}