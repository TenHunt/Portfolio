// Daniël De Jager 41669436 - CMPG212 Assessment 3 Creative Project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace _41669436_Assessment_3
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand comm;
        DataTable dataTable;
        string sql;

        protected void Query_DB() // Queries database
        {
            try
            {
                lblError.Text = "";
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();
                if (sql == null) // If sql request not set
                {
                    sql = "SELECT * FROM Birthdays";
                }
                comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataTable.Columns["BirthDate"].DataType = typeof(DateTime); // Remove the time portion of the date
                gvBirthdays.DataSource = dataTable;
                gvBirthdays.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            linkLogout.Visible = false; // Hide logout link until validated
            HttpCookie myCookie = Request.Cookies["Details"]; // Retrieve cookie with user details
            bool valid = false; // Checks if session is valid
            if(Session["Valid"] != null)
            {
                valid = (bool)Session["Valid"];
            }

            if (myCookie != null && valid) // If cookie exists and session is valid
            {
                linkLogout.Visible = true;
                linkLogin.Visible = false; // Remove link to go back to login
                lblWelcome.Text = " Welcome to the dashboard, " + myCookie["Username"].ToString() + "!"; // Welcome the user

                sql = "SELECT * FROM Birthdays";
                Query_DB();
            }
            else // Hide buttons for user not logged in
            {
                btnAll.Visible = false;
                btnNextMonth.Visible = false;
                btnThisMonth.Visible = false;
                btnYearsAtCompany10.Visible = false;
                btnYearsAtCompany5.Visible = false;
                btnEdit.Visible = false;
                lblSort.Visible = false;
                lblHeading.Visible = false;
                lblAction.Visible = false;
            }
        }

        protected void btnThisMonth_Click(object sender, EventArgs e) // Retrieve birthdays within this month
        {
            sql = "SELECT * FROM Birthdays WHERE MONTH(BirthDate) = MONTH(GETDATE())";
            Query_DB();
        }

        protected void btnNextMonth_Click(object sender, EventArgs e) // Retrieve birthdays within next month
        {
            sql = "SELECT * FROM Birthdays WHERE MONTH(BirthDate) = MONTH(DATEADD(month, 1, GETDATE()))";
            Query_DB();
        }

        protected void btnAll_Click(object sender, EventArgs e) // Retrieve all birthday info from db
        {
            sql = "SELECT * FROM Birthdays";
            Query_DB();
        }

        protected void btnYearsAtCompany5_Click(object sender, EventArgs e) // Retrieve more than or equal to 5 years at company
        {
            sql = "SELECT * FROM Birthdays WHERE TimeAtCompany >= 5";
            Query_DB();
        }

        protected void btnYearsAtCompany10_Click(object sender, EventArgs e) // Retrieve more than or equal to 10 years at company
        {
            sql = "SELECT * FROM Birthdays WHERE TimeAtCompany >= 10";
            Query_DB();
        }

        protected void btnEdit_Click(object sender, EventArgs e) // Redirects user to page where editing can occur
        {
            Response.Redirect("edit.aspx");
        }
    }
}