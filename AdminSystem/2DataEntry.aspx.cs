using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_DataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Any initialization logic can go here
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string productName = txtProductName.Text;
        string description = txtDescription.Text;
        string priceText = txtPrice.Text;
        string stockText = txtStock.Text;
        string categoryIdText = ddlCategory.SelectedValue;
        string supplierIdText = ddlSupplier.SelectedValue;

        decimal price;
        int stock, categoryId, supplierId;

        if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(stockText) || string.IsNullOrEmpty(categoryIdText) || string.IsNullOrEmpty(supplierIdText))
        {
            // Display error message for empty fields
            Response.Write("<script>alert('All fields are required.');</script>");
            return;
        }

        if (!decimal.TryParse(priceText, out price))
        {
            // Display error message for invalid price
            Response.Write("<script>alert('Invalid price format.');</script>");
            return;
        }

        if (!int.TryParse(stockText, out stock))
        {
            // Display error message for invalid stock
            Response.Write("<script>alert('Invalid stock format.');</script>");
            return;
        }

        if (!int.TryParse(categoryIdText, out categoryId))
        {
            // Display error message for invalid category ID
            Response.Write("<script>alert('Invalid category format.');</script>");
            return;
        }

        if (!int.TryParse(supplierIdText, out supplierId))
        {
            // Display error message for invalid supplier ID
            Response.Write("<script>alert('Invalid supplier format.');</script>");
            return;
        }

        // Save the product to the database
        string connectionString = "Data Source=v00egd00002l.lec-admin.dmu.ac.uk;Initial Catalog=p2771538;User ID=P2771538;Password=9gQ3nIppVO6NxBeWAq";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Products (ProductName, ProductDescription, Price, Stock, CategoryId, SupplierId) VALUES (@ProductName, @Description, @Price, @Stock, @CategoryId, @SupplierId)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Stock", stock);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@SupplierId", supplierId);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Product added successfully.');</script>");
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}