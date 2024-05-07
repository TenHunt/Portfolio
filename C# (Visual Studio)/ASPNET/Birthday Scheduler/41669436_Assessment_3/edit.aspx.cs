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
    public partial class edit : System.Web.UI.Page
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

        protected void Read_Data() // Reads data to put into edit textboxes and calendar
        {
            try
            {
                lblError.Text = "";
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();

                sql = $"SELECT FirstName, LastName, BirthDate, TimeAtCompany FROM Birthdays WHERE Id = {ddlIDEdit.SelectedValue}";
                comm = new SqlCommand(sql, conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    DateTime birthDate = (DateTime)reader["BirthDate"];
                    string timeAtCompany = reader["TimeAtCompany"].ToString();

                    txtFNameEdit.Text = firstName;
                    txtLNameEdit.Text = lastName;
                    calBirthDateEdit.SelectedDate = birthDate;
                    calBirthDateEdit.VisibleDate = birthDate;
                    txtYearsAtCompanyEdit.Text = timeAtCompany;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void Pop_Drop() // Populates dropdown box
        {
            try
            {
                lblError.Text = "";
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();
                sql = "SELECT Id FROM Birthdays";
                comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                adapter.SelectCommand = comm;
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                ddlIDEdit.DataSource = dataTable;
                ddlIDEdit.DataTextField = "Id";
                ddlIDEdit.DataBind();
                ddlIDDel.DataSource = dataTable;
                ddlIDDel.DataTextField = "Id";
                ddlIDDel.DataBind();
                conn.Close();
                Read_Data();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                linkReturn.Visible = false; // Hide link to return to dashboard until validated
                HttpCookie myCookie = Request.Cookies["Details"]; // Retrieve cookie with user details
                bool valid = false; // Checks if session is valid
                if (Session["Valid"] != null)
                {
                    valid = (bool)Session["Valid"];
                }

                if (myCookie != null && valid) // If cookie exists and session is valid
                {
                    linkReturn.Visible = true; // Show link to return to dashboard
                    linkLogin.Visible = false; // Remove link to go back to login
                    lblWelcome.Text = " Welcome to the editor, " + myCookie["Username"].ToString() + "!"; // Welcome the user

                    calBirthDateEdit.SelectedDate = DateTime.Now; // Set calendar to now

                    sql = "SELECT * FROM Birthdays";
                    Query_DB();
                    Pop_Drop();
                }
                else // Hide buttons for user not logged in
                {
                    lblHeading.Visible = false;
                    lblAdd.Visible = false;
                    lblBirthDateAdd.Visible = false;
                    lblBirthDateEdit.Visible = false;
                    lblDelete.Visible = false;
                    lblEdit.Visible = false;
                    lblError.Visible = false;
                    lblFNameAdd.Visible = false;
                    lblFNameEdit.Visible = false;
                    lblIDDel.Visible = false;
                    lblIDEdit.Visible = false;
                    lblLNameAdd.Visible = false;
                    lblLNameEdit.Visible = false;
                    lblYearsAtCompanyAdd.Visible = false;
                    lblYearsAtCompanyEdit.Visible = false;
                    calBirthDateAdd.Visible = false;
                    calBirthDateEdit.Visible = false;
                    txtFNameAdd.Visible = false;
                    txtFNameEdit.Visible = false;
                    txtLNameAdd.Visible = false;
                    txtLNameEdit.Visible = false;
                    txtYearsAtCompanyAdd.Visible = false;
                    txtYearsAtCompanyEdit.Visible = false;
                    ddlIDDel.Visible = false;
                    ddlIDEdit.Visible = false;
                    btnAdd.Visible = false;
                    btnDel.Visible = false;
                    btnSubmit.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e) // Submit changes to a birthday entry, then refreshes
        {
            try
            {
                DateTime birthDate = new DateTime();
                birthDate = calBirthDateEdit.SelectedDate;
                lblError.Text = ""; // Resets error label
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();
                sql = "UPDATE Birthdays SET FirstName = @fname, LastName = @lname, BirthDate = @birthdate, TimeAtCompany = @timeatcompany WHERE Id = @id"; // Inserts the values into the DB properly
                comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                comm.Parameters.AddWithValue("@fname", txtFNameEdit.Text);
                comm.Parameters.AddWithValue("@lname", txtLNameEdit.Text);
                comm.Parameters.AddWithValue("@birthdate", birthDate);
                comm.Parameters.AddWithValue("@timeatcompany", txtYearsAtCompanyEdit.Text);
                comm.Parameters.AddWithValue("@id", ddlIDEdit.SelectedValue);
                adapter.UpdateCommand = comm;
                adapter.UpdateCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            sql = "SELECT * FROM Birthdays";
            Query_DB();
            Pop_Drop();
        }

        protected void btnDel_Click(object sender, EventArgs e) // Delete a birthdays entry, then refreshes
        {
            try
            {
                lblError.Text = ""; // Resets error label
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();
                sql = "DELETE FROM Birthdays WHERE Id = @id"; // Inserts the values into the DB properly
                comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                comm.Parameters.AddWithValue("@id", ddlIDDel.SelectedValue);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            sql = "SELECT * FROM Birthdays";
            Query_DB();
            Pop_Drop();
        }

        protected void btnAdd_Click(object sender, EventArgs e) // Add new birthdays entry, then refreshes
        {
            try
            {
                DateTime birthDate = new DateTime();
                birthDate = calBirthDateAdd.SelectedDate;
                lblError.Text = ""; // Resets error label
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();
                sql = "INSERT INTO Birthdays(FirstName, LastName, BirthDate, TimeAtCompany) VALUES(@fname, @lname, @birthdate, @timeatcompany)"; // Inserts the values into the DB properly
                comm = new SqlCommand(sql, conn);
                adapter = new SqlDataAdapter();
                comm.Parameters.AddWithValue("@fname", txtFNameAdd.Text);
                comm.Parameters.AddWithValue("@lname", txtLNameAdd.Text);
                comm.Parameters.AddWithValue("@birthdate", birthDate);
                comm.Parameters.AddWithValue("@timeatcompany", txtYearsAtCompanyAdd.Text);
                adapter.InsertCommand = comm;
                adapter.InsertCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            sql = "SELECT * FROM Birthdays";
            Query_DB();
            Pop_Drop();
        }

        protected void ddlIDEdit_SelectedIndexChanged(object sender, EventArgs e) // Reads data each time dropdown is changed (postback = true)
        {
            Read_Data();
        }
    }
}