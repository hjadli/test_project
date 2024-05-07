using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Check if terms are accepted
        if (!chkTerms.Checked)
        {
            lblMessage.Text = "You must accept the terms and conditions.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

        // Determine selected gender
        string gender = radioMale.Checked ? "Male" : "Female";

        // Connect to the database and insert the user record
        string connectionString = "your_connection_string_here";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string query = "INSERT INTO Users (Username, Password, Email, Gender) VALUES (@Username, @Password, @Email, @Gender)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.ExecuteNonQuery();
        }

        // Show a success message
        lblMessage.Text = "Registration successful!";
        lblMessage.ForeColor = System.Drawing.Color.Green;
    }

}