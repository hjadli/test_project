using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    private ClsUsersCollection usersCollection = new ClsUsersCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is logged in
            if (Session["UserId"] != null)
            {
                LoadUserDetails();
            }
            else
            {
                // If no user is logged in, redirect to login page
                Response.Redirect("UserLogin.aspx");
            }
        }
    }

    private void LoadUserDetails()
    {
        int userId = (int)Session["UserId"];
        ClsUsers user = usersCollection.UsersList.Find(u => u.UserId == userId);

        if (user != null)
        {
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtAddress.Text = user.Address;
            txtPassword.Text = user.Password;
        }
        else
        {
            lblMessage.Text = "User details not found.";
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int userId = (int)Session["UserId"];
        ClsUsers user = usersCollection.UsersList.Find(u => u.UserId == userId);

        if (user != null)
        {
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Email = txtEmail.Text;
            user.Address = txtAddress.Text;
            user.Password = txtPassword.Text;

            usersCollection.ThisUser = user;
            usersCollection.Update();

            lblMessage.Text = "User details updated successfully.";
        }
        else
        {
            lblMessage.Text = "User details not found.";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int userId = (int)Session["UserId"];
        ClsUsers user = usersCollection.UsersList.Find(u => u.UserId == userId);

        if (user != null)
        {
            usersCollection.Delete(userId);

            // Clear the session and redirect to login page after deletion
            Session.Clear();
            Response.Redirect("UserLogin.aspx");
        }
        else
        {
            lblMessage.Text = "User details not found.";
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clear the session
        Session.Clear();
        // Redirect to login page
        Response.Redirect("UserLogin.aspx");
    }
}