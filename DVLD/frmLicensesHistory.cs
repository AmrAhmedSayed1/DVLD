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
                dgvI_Licenses.Columns[2].Width = 200;
                dgvI_Licenses.Columns[3].Width = 200;
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
    }
}
