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
    public partial class frmInsert : Form
    {
        public frmInsert()
        {
            InitializeComponent();
            txtID.Text = findNextID().ToString(); // Loads next ID into read-only textbox
        }

        private int findNextID() // Finds next ID to put into text box, since instructions show we must have but user input will create conflicts and errors
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
                ID++; // Adds one to last entry's ID for next entry's ID
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int tID = findNextID();
            int tYear = 0;
            bool success = false;
            if (txtName.Text == "" || txtSurname.Text == "" || txtYear.Text == "" || txtQuote.Text == "") // Ensures all values are entered without needing to throw not null errors in DB
            {
                MessageBox.Show("Please enter all the values");
            }
            else // All textboxes have inputs, then store them
            {
                if(int.TryParse(txtYear.Text, out tYear))
                {
                    success = true;
                }
            }

            if (success) // If all textboxes filled and parsed correctly
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Quotes.mdf';Integrated Security=True");
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sql = "INSERT INTO Famous(FirstName, LastName, YearSaid, Quote) VALUES(@FirstName, @Surname, @YearSaid, @Quote)";
                    SqlCommand comm = new SqlCommand(sql, conn);
                    //comm.Parameters.AddWithValue("@Id", tID); // ID isn't inserted since it throws an error (primary key insertion) we haven't been taught to solve yet
                    comm.Parameters.AddWithValue("@FirstName", txtName.Text);
                    comm.Parameters.AddWithValue("@Surname", txtSurname.Text);
                    comm.Parameters.AddWithValue("@YearSaid", tYear);
                    comm.Parameters.AddWithValue("@Quote", txtQuote.Text);
                    adapter.InsertCommand = comm;
                    adapter.InsertCommand.ExecuteNonQuery();
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
