using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ClsProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }

        public bool Find(int productId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ProductId", productId);
            DB.Execute("sproc_tblProducts_FindByProductId");

            if (DB.Count == 1)
            {
                ProductId = Convert.ToInt32(DB.DataTable.Rows[0]["ProductId"]);
                ProductName = Convert.ToString(DB.DataTable.Rows[0]["ProductName"]);
                ProductDescription = Convert.ToString(DB.DataTable.Rows[0]["ProductDescription"]);
                Price = Convert.ToDecimal(DB.DataTable.Rows[0]["Price"]);
                Stock = Convert.ToInt32(DB.DataTable.Rows[0]["Stock"]);
                CategoryId = DB.DataTable.Rows[0]["CategoryId"] as int?;
                SupplierId = DB.DataTable.Rows[0]["SupplierId"] as int?;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Valid(string productName, string productDescription, string price, string stock, string categoryId, string supplierId)
        {
            string error = "";
            if (string.IsNullOrWhiteSpace(productName))
            {
                error += "The product name may not be blank : ";
            }
            if (productName.Length > 100)
            {
                error += "The product name must be less than 100 characters : ";
            }
            if (!string.IsNullOrEmpty(productDescription) && productDescription.Length > 255)
            {
                error += "The product description must be less than 255 characters : ";
            }
            if (!decimal.TryParse(price, out _))
            {
                error += "The price must be a valid decimal number : ";
            }
            if (!int.TryParse(stock, out _))
            {
                error += "The stock must be a valid integer : ";
            }
            if (!string.IsNullOrEmpty(categoryId) && !int.TryParse(categoryId, out _))
            {
                error += "The category ID must be a valid integer : ";
            }
            if (!string.IsNullOrEmpty(supplierId) && !int.TryParse(supplierId, out _))
            {
                error += "The supplier ID must be a valid integer : ";
            }
            return error;
        }
    }
}