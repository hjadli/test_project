using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if user is logged in
            if (Session["UserId"] == null || Session["Role"] == null || Session["Role"].ToString() != "admin")
            {
                // If no user is logged in or user is not admin, redirect to login page
                Response.Redirect("~/Login.aspx");
            }
        }
    }
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        ClsProductsCollection productsCollection = new ClsProductsCollection();
        ClsProduct newProduct = new ClsProduct();

        string validationMessage = newProduct.Valid(
            txtProductName.Text,
            txtProductDescription.Text,
            txtPrice.Text,
            txtStock.Text,
            txtCategoryId.Text,
            txtSupplierId.Text
        );

        if (string.IsNullOrEmpty(validationMessage))
        {
            newProduct.ProductName = txtProductName.Text;
            newProduct.ProductDescription = txtProductDescription.Text;
            newProduct.Price = Convert.ToDecimal(txtPrice.Text);
            newProduct.Stock = Convert.ToInt32(txtStock.Text);
            newProduct.CategoryId = string.IsNullOrWhiteSpace(txtCategoryId.Text) ? (int?)null : Convert.ToInt32(txtCategoryId.Text);
            newProduct.SupplierId = string.IsNullOrWhiteSpace(txtSupplierId.Text) ? (int?)null : Convert.ToInt32(txtSupplierId.Text);

            productsCollection.ThisProduct = newProduct;
            productsCollection.Add();

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Product added successfully!";
            ClearForm();
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = validationMessage;
        }
    }

    private void ClearForm()
    {
        txtProductName.Text = string.Empty;
        txtProductDescription.Text = string.Empty;
        txtPrice.Text = string.Empty;
        txtStock.Text = string.Empty;
        txtCategoryId.Text = string.Empty;
        txtSupplierId.Text = string.Empty;
    }
}
