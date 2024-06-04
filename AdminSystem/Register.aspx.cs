using ClassLibrary;
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
        if (!IsPostBack)
        {
            // Initialize or perform necessary actions on first load
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Clear the message label
        lblMessage.Text = "";

        // Create a new user instance
        ClsUsers newUser = new ClsUsers
        {
            FirstName = txtFirstName.Text.Trim(),
            LastName = txtLastName.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            Address = txtAddress.Text.Trim(),
            Password = txtPassword.Text.Trim(),
            Role = "user", // Default role
            IsActive = true // Default active status
        };

        // Validate user inputs
        string validationMessage = newUser.Valid(newUser.FirstName, newUser.LastName, newUser.Email, newUser.Address, newUser.Password, newUser.Role, newUser.IsActive.ToString());
        if (validationMessage != "")
        {
            lblMessage.Text = validationMessage;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

        // Check if the email is already registered
        ClsUsersCollection usersCollection = new ClsUsersCollection();
        if (usersCollection.IsEmailRegistered(newUser.Email))
        {
            lblMessage.Text = "The email address is already registered.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

        // Add the new user to the collection and save to database
        usersCollection.ThisUser = newUser;
        int userId = usersCollection.Add();
        if (userId > 0)
        {
            lblMessage.Text = "User registered successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            ClearForm();
        }
        else
        {
            lblMessage.Text = "Registration failed. Please try again.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void ClearForm()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtAddress.Text = "";
        txtPassword.Text = "";
    }
}