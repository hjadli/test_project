using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class AdminDashboard : System.Web.UI.Page
{
    private ClsCategoriesCollection categoriesCollection = new ClsCategoriesCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is logged in and is an admin
            if (Session["UserId"] == null || Session["Role"] == null || Session["Role"].ToString() != "admin")
            {
                Response.Redirect("~/UserLogin.aspx");
            }
        }
    }

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        // Validate inputs
        if (ValidateInputs())
        {
            ClsCategory newCategory = new ClsCategory
            {
                CategoryName = txtCategoryName.Text,
                CategoryDetails = txtCategoryDetails.Text,
                CategoryType = txtCategoryType.Text,
                CreatedDate = DateTime.Now // Setting the CreatedDate to current date
            };

            string validationMessage = newCategory.Valid(newCategory.CategoryName, newCategory.CategoryDetails, newCategory.CategoryType, newCategory.CreatedDate.ToString());
            if (string.IsNullOrEmpty(validationMessage))
            {
                try
                {
                    // Add new category to collection
                    categoriesCollection.ThisCategory = newCategory;
                    categoriesCollection.Add();

                    // Show success message
                    lblMessage.Text = "Category added successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    // Clear form fields
                    ClearForm();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = validationMessage;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
        {
            lblMessage.Text = "Category Name is required.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtCategoryDetails.Text))
        {
            lblMessage.Text = "Category Details are required.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtCategoryType.Text))
        {
            lblMessage.Text = "Category Type is required.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }
        return true;
    }

    private void ClearForm()
    {
        txtCategoryName.Text = string.Empty;
        txtCategoryDetails.Text = string.Empty;
        txtCategoryType.Text = string.Empty;
    }
}