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
    public partial class ViewForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Quotes.mdf';Integrated Security=True"); // Global database connection
        SqlDataAdapter adapter;
        SqlDataReader reader;
        DataSet dataset;
        private void loadDB() // Loads the database into the datagridview
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Famous";
                SqlCommand comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                dataset = new DataSet();
                adapter.Fill(dataset, "Famous");
                dgvData.DataSource = dataset;
                dgvData.DataMember = "Famous";
                conn.Close();
            }
            catch (SqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void popCBB() // Populates the combobox
        {
            try
            {
                conn.Open();
                string sql = "SELECT FirstName FROM Famous";
                SqlCommand comm = new SqlCommand(sql, conn);
                reader = comm.ExecuteReader();
                while(reader.Read())
                {
                    cbbName.Items.Add(reader.GetValue(0));
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ViewForm()
        {
            InitializeComponent();
            loadDB();
            popCBB();
        }

        private void hsbYear_Scroll(object sender, ScrollEventArgs e) // When scroll bar is moved, filter data to only list years lower than selected year
        {
            lblCurrentYear.Text = hsbYear.Value.ToString(); // Changes the label to show selected year
            try
            {
                conn.Open();
                string sql = $"SELECT * FROM Famous WHERE YearSaid < {hsbYear.Value}"; // Instructions state dates "smaller than" and not "equal to or smaller than"
                SqlCommand comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                dataset = new DataSet();
                adapter.Fill(dataset, "Famous");
                dgvData.DataSource = dataset;
                dgvData.DataMember = "Famous";
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbName_SelectedIndexChanged(object sender, EventArgs e) // Filter data by name selected from combobox
        {
            try
            {
                conn.Open();
                string sql = $"SELECT * FROM Famous WHERE FirstName = '{cbbName.SelectedItem}'";
                SqlCommand comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                dataset = new DataSet();
                adapter.Fill(dataset, "Famous");
                dgvData.DataSource = dataset;
                dgvData.DataMember = "Famous";
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblRemoveFilter_Click(object sender, EventArgs e) // Resets and clears filter
        {
            cbbName.SelectedText = "";
            hsbYear.Value = 0;
            lblCurrentYear.Text = "0";
            loadDB();
        }
    }
}
