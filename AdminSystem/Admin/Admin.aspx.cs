using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is logged in
            if (Session["UserId"] != null && Session["Role"] != null && Session["Role"].ToString() == "admin")
            {
                string firstName = Session["FirstName"].ToString();
                lblAdminWelcome.Text = "Welcome, " + firstName + "!";
            }
            else
            {
                // If no user is logged in or user is not admin, redirect to login page
                Response.Redirect("~/Login.aspx");
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clear the session
        Session.Clear();

        // Redirect to login page
        Response.Redirect("~/Login.aspx");
    }
}