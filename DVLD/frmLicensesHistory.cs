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

            dgvLDLS.Columns[2].Width = 250;
            dgvLDLS.Columns[3].Width = 250;
            dgvLDLS.Columns[4].Width = 245;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            uctrlPersonalDetails1.PersonID = PersonID;
            uctrlPersonalDetails1.LoadDataToForm();

            _LoadLDLS();
        }
    }
}
