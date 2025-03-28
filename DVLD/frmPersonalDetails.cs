using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmPersonalDetails : Form
    {

        private int PersonID = 0;

        public frmPersonalDetails(int personID)
        {
            InitializeComponent();
            PersonID = personID;
        }

        private void frmPersonalDetails_Load(object sender, EventArgs e)
        {
            uctrlPersonalDetails1.PersonID = PersonID;
            uctrlPersonalDetails1.LoadDataToForm();
        }
    }
}
