using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeJager_Daniel_41669436
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        private int findID() // Finds next ID to ensure user doesn't update ID out of range
        {
            int ID = -1;
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Quotes.mdf';Integrated Security=True");
                conn.Open();
                string sql = "SELECT Id FROM Famous";
                SqlCommand comm = new SqlCommand(sql, conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string TableID = reader.GetValue(0).ToString();
                    int.TryParse(TableID, out ID); // Updates ID variable until last entry
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ID; // Returns the last ID in the database
        }

        private void btnUpdate_Click(object sender, EventArgs e) // Checks inputs and updates quote in database
        {
            bool success = false;
            int tID = -1;
            if(txtID.Text == "" || txtUpdate.Text == "") // Checks if text boxes are populaed
            {
                MessageBox.Show("Please enter all the values");
            }
            else
            {
                if(int.TryParse(txtID.Text, out tID))
                {
                    int currentID = findID();
                    if (tID > currentID) // If entered ID is out of range
                    {
                        MessageBox.Show("Please enter an ID equal to or less than " + currentID);
                    }
                    else
                    {
                        success = true;
                    }
                }
            }

            if(success) // If all textboxes populated and parsed correctly
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Quotes.mdf';Integrated Security=True");
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sql = $"UPDATE Famous SET Quote = '{txtUpdate.Text}' WHERE Id = {tID}";
                    SqlCommand comm = new SqlCommand(sql, conn);
                    adapter.UpdateCommand = comm;
                    adapter.UpdateCommand.ExecuteNonQuery();
                    conn.Close();
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
