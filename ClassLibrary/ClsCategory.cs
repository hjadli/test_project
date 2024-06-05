using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ClsCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetails { get; set; }
        public string CategoryType { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool Find(int categoryId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CategoryId", categoryId);
            DB.Execute("sproc_tblCategories_FindByCategoryId");

            if (DB.Count == 1)
            {
                CategoryId = Convert.ToInt32(DB.DataTable.Rows[0]["CategoryId"]);
                CategoryName = Convert.ToString(DB.DataTable.Rows[0]["CategoryName"]);
                CategoryDetails = Convert.ToString(DB.DataTable.Rows[0]["CategoryDetails"]);
                CategoryType = Convert.ToString(DB.DataTable.Rows[0]["CategoryType"]);
                CreatedDate = Convert.ToDateTime(DB.DataTable.Rows[0]["CreatedDate"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Valid(string categoryName, string categoryDetails, string categoryType, string createdDate)
        {
            string error = "";
            DateTime tempDate;

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                error += "The category name may not be blank : ";
            }
            if (categoryName.Length > 100)
            {
                error += "The category name must be less than 100 characters : ";
            }
            if (!string.IsNullOrEmpty(categoryDetails) && categoryDetails.Length > 255)
            {
                error += "The category details must be less than 255 characters : ";
            }
            if (!string.IsNullOrEmpty(categoryType) && categoryType.Length > 50)
            {
                error += "The category type must be less than 50 characters : ";
            }
            if (!DateTime.TryParse(createdDate, out tempDate))
            {
                error += "The created date is not a valid date : ";
            }

            return error;
        }
    }
}