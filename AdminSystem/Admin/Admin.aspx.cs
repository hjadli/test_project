using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
{
    private ClsUsersCollection usersCollection = new ClsUsersCollection();
    // Create OrderCollection and ReportCollection as per your implementation

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is logged in
            if (Session["UserId"] == null || Session["Role"] == null || Session["Role"].ToString() != "admin")
            {
                // If no user is logged in or user is not admin, redirect to login page
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                

                // Load dashboard data
                LoadDashboardData();
            }
        }
    }

    protected void LoadDashboardData()
    {
        // Get count of registered users
        int registeredUsers = usersCollection.Count;
        lblRegisteredUsers.Text = registeredUsers.ToString();

        
    }

   

   

    protected void BtnAddProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddProduct.aspx");
    }

    protected void BtnAddCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddCategory.aspx");
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        // Clear the session
        Session.Clear();
        // Redirect to login page
        Response.Redirect("~/UserLogin.aspx");
    }
}