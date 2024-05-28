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
    UsersCollection usersCollection = new UsersCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialize or perform necessary actions on first load
        }
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        if (ValidateInputs())
        {
            try
            {
                // Check if the email already exists
                if (IsEmailRegistered(txtEmail.Text))
                {
                    lblMessage.Text = "The email address is already registered.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                Users newUser = new Users
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    Password = txtPassword.Text,
                    Role = "user", // Default role
                    IsActive = true
                };

                usersCollection.ThisUser = newUser;
                int newUserId = usersCollection.Add();

                lblMessage.Text = "User registered successfully with UserID: " + newUserId;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearForm();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (ValidateInputs())
        {
            try
            {
                string email = txtEmail.Text;
                Users userToUpdate = usersCollection.UsersList.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
                if (userToUpdate != null)
                {
                    userToUpdate.FirstName = txtFirstName.Text;
                    userToUpdate.LastName = txtLastName.Text;
                    userToUpdate.Email = txtEmail.Text;
                    userToUpdate.Address = txtAddress.Text;
                    userToUpdate.Password = txtPassword.Text;

                    usersCollection.ThisUser = userToUpdate;
                    usersCollection.Update();

                    lblMessage.Text = "User updated successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    ClearForm();
                }
                else
                {
                    lblMessage.Text = "User not found.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string email = txtEmail.Text;
            Users userToDelete = usersCollection.UsersList.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (userToDelete != null)
            {
                usersCollection.Delete(userToDelete.UserId);

                lblMessage.Text = "User deleted successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearForm();
            }
            else
            {
                lblMessage.Text = "User not found.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error: " + ex.Message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void ClearForm()
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            lblMessage.Text = "First Name is required.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            lblMessage.Text = "Last Name is required.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            lblMessage.Text = "Email is required.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            lblMessage.Text = "Password is required.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }

        return true;
    }

    private bool IsEmailRegistered(string email)
    {
        Users user = usersCollection.UsersList.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        return user != null;
    }
}