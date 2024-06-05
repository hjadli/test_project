using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ClsCategoriesCollection
    {
        private List<ClsCategory> mCategoriesList = new List<ClsCategory>();
        private ClsCategory mThisCategory = new ClsCategory();

        public List<ClsCategory> CategoriesList
        {
            get { return mCategoriesList; }
            set { mCategoriesList = value; }
        }

        public int Count
        {
            get { return mCategoriesList.Count; }
        }

        public ClsCategory ThisCategory
        {
            get { return mThisCategory; }
            set { mThisCategory = value; }
        }

        public ClsCategoriesCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblCategories_SelectAll");
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            int index = 0;
            int recordCount = DB.Count;
            mCategoriesList = new List<ClsCategory>();
            while (index < recordCount)
            {
                ClsCategory aCategory = new ClsCategory
                {
                    CategoryId = Convert.ToInt32(DB.DataTable.Rows[index]["CategoryId"]),
                    CategoryName = Convert.ToString(DB.DataTable.Rows[index]["CategoryName"]),
                    CategoryDetails = Convert.ToString(DB.DataTable.Rows[index]["CategoryDetails"]),
                    CategoryType = Convert.ToString(DB.DataTable.Rows[index]["CategoryType"]),
                    CreatedDate = Convert.ToDateTime(DB.DataTable.Rows[index]["CreatedDate"])
                };
                mCategoriesList.Add(aCategory);
                index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CategoryName", mThisCategory.CategoryName);
            DB.AddParameter("@CategoryDetails", mThisCategory.CategoryDetails);
            DB.AddParameter("@CategoryType", mThisCategory.CategoryType);
            return DB.Execute("spInsertCategory");
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CategoryId", mThisCategory.CategoryId);
            DB.AddParameter("@CategoryName", mThisCategory.CategoryName);
            DB.AddParameter("@CategoryDetails", mThisCategory.CategoryDetails);
            DB.AddParameter("@CategoryType", mThisCategory.CategoryType);
            DB.Execute("spUpdateCategory");
        }

        public void Delete(int categoryId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CategoryId", categoryId);
            DB.Execute("spDeleteCategory");
        }
    }
}