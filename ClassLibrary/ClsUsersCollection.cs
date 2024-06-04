using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace ClassLibrary
    {
    public class ClsUsersCollection
    {
        // Private data member for the list
        private List<ClsUsers> mUsersList = new List<ClsUsers>();
        // Private data member for ThisUser
        private ClsUsers mThisUser = new ClsUsers();

        // Public property for the UsersList
        public List<ClsUsers> UsersList
        {
            get { return mUsersList; }
            set { mUsersList = value; }
        }

        // Public property for Count
        public int Count
        {
            get { return mUsersList.Count; }
        }

        // Public property for ThisUser
        public ClsUsers ThisUser
        {
            get { return mThisUser; }
            set { mThisUser = value; }
        }

        // Constructor for the class
        public ClsUsersCollection()
        {
            // Object for the data connection
            clsDataConnection DB = new clsDataConnection();
            // Execute the stored procedure to get all users
            DB.Execute("sproc_tblUsers_SelectAll");
            // Populate the array list with the data table
            PopulateArray(DB);
        }

        // Method to populate the array list based on the data table in the parameter DB
        void PopulateArray(clsDataConnection DB)
        {
            // Populate the list based on the table in the database
            int Index = 0;
            int RecordCount = DB.Count;
            mUsersList = new List<ClsUsers>();
            while (Index < RecordCount)
            {
                ClsUsers AUser = new ClsUsers();
                AUser.UserId = Convert.ToInt32(DB.DataTable.Rows[Index]["UserId"]);
                AUser.FirstName = Convert.ToString(DB.DataTable.Rows[Index]["FirstName"]);
                AUser.LastName = Convert.ToString(DB.DataTable.Rows[Index]["LastName"]);
                AUser.Email = Convert.ToString(DB.DataTable.Rows[Index]["Email"]);
                AUser.Address = Convert.ToString(DB.DataTable.Rows[Index]["Address"]);
                AUser.Password = Convert.ToString(DB.DataTable.Rows[Index]["Password"]);
                AUser.Role = Convert.ToString(DB.DataTable.Rows[Index]["Role"]);
                AUser.IsActive = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsActive"]);
                mUsersList.Add(AUser);
                Index++;
            }
        }
        public bool IsEmailRegistered(string email)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Email", email);
            DB.Execute("sproc_tblUsers_FindByEmail");
            if (DB.Count == 1)
            {
                return true;
            }
            return false;
        }


        public int Add()
        {
            // Add a new record to the database based on the values of mThisUser
            clsDataConnection DB = new clsDataConnection();
            // Set the parameters for the stored procedure
            DB.AddParameter("@FirstName", mThisUser.FirstName);
            DB.AddParameter("@LastName", mThisUser.LastName);
            DB.AddParameter("@Email", mThisUser.Email);
            DB.AddParameter("@Address", mThisUser.Address);
            DB.AddParameter("@Password", mThisUser.Password);
            DB.AddParameter("@Role", mThisUser.Role);
            DB.AddParameter("@IsActive", mThisUser.IsActive);
            // Execute the query returning the primary key value
            return DB.Execute("sproc_tblUsers_Insert");
        }

        public void Delete(int userId)
        {
            // Delete a record from the database based on the UserId
            clsDataConnection DB = new clsDataConnection();
            // Set the parameter for the stored procedure
            DB.AddParameter("@UserId", userId);
            // Execute the stored procedure
            DB.Execute("sproc_tblUsers_Delete");
        }

        public void Update()
        {
            // Update an existing record in the database based on the values of mThisUser
            clsDataConnection DB = new clsDataConnection();
            // Set the parameters for the stored procedure
            DB.AddParameter("@UserId", mThisUser.UserId);
            DB.AddParameter("@FirstName", mThisUser.FirstName);
            DB.AddParameter("@LastName", mThisUser.LastName);
            DB.AddParameter("@Email", mThisUser.Email);
            DB.AddParameter("@Address", mThisUser.Address);
            DB.AddParameter("@Password", mThisUser.Password);
            DB.AddParameter("@Role", mThisUser.Role);
            DB.AddParameter("@IsActive", mThisUser.IsActive);
            // Execute the stored procedure
            DB.Execute("sproc_tblUsers_Update");
        }
    }
}
