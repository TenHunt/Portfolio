using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeJager_Daniel_41669436
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e) // Shows form to insert new data into database
        {
            frmInsert myFrmInsert = new frmInsert();
            myFrmInsert.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e) // Shows form to update quote entry in database
        {
            frmUpdate myFrmUpdate = new frmUpdate();
            myFrmUpdate.ShowDialog();
        }
    }
}
