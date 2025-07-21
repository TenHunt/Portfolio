/*
 * Name: CMPG212 Assessment 1
 * Author: Daniël De Jager 41669436
 * Date: 19/03/2024
 */

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiExit_Click(object sender, EventArgs e) // Exit button in menu strip, closes program
        {
            Application.Exit();
        }

        ViewForm myViewForm;
        ToolStripMenuItem menuViewForm;
        private void tsmiViewAll_Click(object sender, EventArgs e) // Shows view all form to display and filter data
        {
            if(myViewForm != null && myViewForm.IsDisposed != true) // If form exists and is displayed
            {
                MessageBox.Show("View form already open");
            }
            else
            {
                myViewForm = new ViewForm();
                myViewForm.MdiParent = this;
                myViewForm.Show();
                menuViewForm = new ToolStripMenuItem("View Form");
                menuViewForm.Checked = true;
                menuViewForm.Visible = true;
                tsmiWindow.DropDownItems.Add(menuViewForm);
            }
        }

        AdminForm myAdminForm;
        ToolStripMenuItem menuAdminForm;
        private void tsmiAdminPanel_Click(object sender, EventArgs e) // Shows admin form for insertion and updating
        {
            if(myAdminForm != null && myAdminForm.IsDisposed != true) // If form exists and is displayed
            {
                MessageBox.Show("Admin form already open");
            }
            else
            {
                myAdminForm = new AdminForm();
                myAdminForm.MdiParent = this;
                myAdminForm.Show();
                menuAdminForm = new ToolStripMenuItem("Admin Panel");
                menuAdminForm.Checked = true;
                menuAdminForm.Visible = true;
                tsmiWindow.DropDownItems.Add(menuAdminForm);
            }
        }

        private void tsmiWindow_Click(object sender, EventArgs e) // Rudimentary check to see what forms are open and not when Window menu item is clicked
        {
            if (myViewForm != null && myViewForm.IsDisposed == true)
            {
                menuViewForm.Visible = false;
            }
            if (myAdminForm != null && myAdminForm.IsDisposed == true)
            {
                menuAdminForm.Visible = false;
            }
        }
    }
}
