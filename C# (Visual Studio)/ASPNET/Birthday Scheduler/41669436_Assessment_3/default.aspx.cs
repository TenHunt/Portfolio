// Daniël De Jager 41669436 - CMPG212 Assessment 3 Creative Project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace _41669436_Assessment_3
{
    public partial class _default : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataReader reader;
        SqlCommand comm;
        string sql;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e) // Login button, validates and goes to dashboard if valid
        {
            bool validUser = false; // Assume username is invalid
            bool validPass = false; // Assume password is invalid
            
            try // Queries db and matches valid usernames
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();
                sql = "SELECT * FROM Credentials WHERE Username = @User";
                comm = new SqlCommand(sql , conn);
                comm.Parameters.AddWithValue("@User", txtUser.Text);
                reader = comm.ExecuteReader();
                if(reader.HasRows) // If it has rows, username is valid
                {
                    validUser = true;
                    lblUserError.Text = " ";
                }
                else
                {
                    lblUserError.Text = "Invalid username";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

            try // Queries db and matches valid passwords
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BirthdaySystem.mdf;Integrated Security=True");
                conn.Open();
                sql = "SELECT * FROM Credentials WHERE Password = @Pass";
                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@Pass", txtPass.Text);
                reader = comm.ExecuteReader();
                if (reader.HasRows) // If it has rows, password is valid
                {
                    validPass = true;
                    lblPassError.Text = " ";
                }
                else
                {
                    lblPassError.Text = "Invalid password";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

            if(validUser && validPass) // If both username and password are valid, creates cookie and session and navigates to dashboard
            {
                lblError.Text = "Logging in...";
                HttpCookie myCookie = new HttpCookie("Details");
                myCookie["Username"] = txtUser.Text;
                myCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(myCookie);
                Session["Valid"] = true;
                Response.Redirect("dashboard.aspx");
            }
        }
    }
}