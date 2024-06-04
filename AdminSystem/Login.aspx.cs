using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_List : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialize or perform necessary actions on first load
        }
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        if (ValidateInputs(email, password))
        {
            ClsUsers user = new ClsUsers();
            if (user.FindUser(email, password))
            {
                // Set session variables
                Session["UserId"] = user.UserId;
                Session["Role"] = user.Role;
                Session["FirstName"] = user.FirstName;

                // Redirect based on role
                if (user.Role == "admin")
                {
                    Response.Redirect("~/Admin/Admin.aspx");
                }
                else
                {
                    Response.Redirect("~/Dashboard.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid email or password.";
            }
        }
    }

    private bool ValidateInputs(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            lblMessage.Text = "Email is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            lblMessage.Text = "Password is required.";
            return false;
        }

        if (!IsValidEmail(email))
        {
            lblMessage.Text = "Invalid email format.";
            return false;
        }

        return true;
    }

    private bool IsValidEmail(string email)
    {
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
    }
}