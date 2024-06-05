using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace ClassLibrary

{

    public class ClsProductsCollection

    {

        private List<ClsProduct> mProductsList = new List<ClsProduct>();

        private ClsProduct mThisProduct = new ClsProduct();



        public List<ClsProduct> ProductsList

        {

            get { return mProductsList; }

            set { mProductsList = value; }

        }



        public int Count

        {

            get { return mProductsList.Count; }

        }



        public ClsProduct ThisProduct

        {

            get { return mThisProduct; }

            set { mThisProduct = value; }

        }



        public ClsProductsCollection()

        {

            clsDataConnection DB = new clsDataConnection();

            DB.Execute("sproc_tblProducts_SelectAll");

            PopulateArray(DB);

        }



        void PopulateArray(clsDataConnection DB)

        {

            int index = 0;

            int recordCount = DB.Count;

            mProductsList = new List<ClsProduct>();

            while (index < recordCount)

            {

                ClsProduct aProduct = new ClsProduct

                {

                    ProductId = Convert.ToInt32(DB.DataTable.Rows[index]["ProductId"]),

                    ProductName = Convert.ToString(DB.DataTable.Rows[index]["ProductName"]),

                    ProductDescription = Convert.ToString(DB.DataTable.Rows[index]["ProductDescription"]),

                    Price = Convert.ToDecimal(DB.DataTable.Rows[index]["Price"]),

                    Stock = Convert.ToInt32(DB.DataTable.Rows[index]["Stock"]),

                    CategoryId = DB.DataTable.Rows[index]["CategoryId"] as int?,

                    SupplierId = DB.DataTable.Rows[index]["SupplierId"] as int?

                };

                mProductsList.Add(aProduct);

                index++;

            }

        }



        public int Add()

        {

            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@ProductName", mThisProduct.ProductName);

            DB.AddParameter("@ProductDescription", mThisProduct.ProductDescription);

            DB.AddParameter("@Price", mThisProduct.Price);

            DB.AddParameter("@Stock", mThisProduct.Stock);

            DB.AddParameter("@CategoryId", mThisProduct.CategoryId);

            DB.AddParameter("@SupplierId", mThisProduct.SupplierId);

            return DB.Execute("spInsertProduct");

        }



        public void Update()

        {

            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@ProductId", mThisProduct.ProductId);

            DB.AddParameter("@ProductName", mThisProduct.ProductName);

            DB.AddParameter("@ProductDescription", mThisProduct.ProductDescription);

            DB.AddParameter("@Price", mThisProduct.Price);

            DB.AddParameter("@Stock", mThisProduct.Stock);

            DB.AddParameter("@CategoryId", mThisProduct.CategoryId);

            DB.AddParameter("@SupplierId", mThisProduct.SupplierId);

            DB.Execute("spUpdateProduct");

        }



        public void Delete(int productId)

        {

            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@ProductId", productId);

            DB.Execute("spDeleteProduct");

        }

    }

}