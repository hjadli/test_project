using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_List : System.Web.UI.Page
{
    UsersCollection usersCollection = new UsersCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialize or perform necessary actions on first load
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidateInputs())
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                Users userToAuthenticate = usersCollection.UsersList.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                if (userToAuthenticate != null && userToAuthenticate.Password == password)
                {
                    lblMessage.Text = "Login successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    // Set the user session
                    Session["UserId"] = userToAuthenticate.UserId;
                    Session["FirstName"] = userToAuthenticate.FirstName;
                    Session["Email"] = userToAuthenticate.Email;
                    Session["Role"] = userToAuthenticate.Role;

                    // Redirect based on user role
                    if (userToAuthenticate.Role == "admin")
                    {
                        Response.Redirect("~/Admin/Admin.aspx");
                    }
                    else
                    {
                        Response.Redirect("Dashboard.aspx");
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
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

    private bool ValidateInputs()
    {
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
}