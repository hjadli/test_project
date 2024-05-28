using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UsersCollection
    {
        private List<Users> usersList;
        private Users thisUser;

        public UsersCollection()
        {
            usersList = new List<Users>(); // Ensure this is instantiated
            LoadAllUsers();
        }

        public List<Users> UsersList
        {
            get { return usersList; }
        }

        public Users ThisUser
        {
            get { return thisUser; }
            set { thisUser = value; }
        }

        // Load all users from the database
        private void LoadAllUsers()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Dbcon"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'Dbcon' not found.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users user = new Users
                        {
                            UserId = (int)reader["UserId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString(),
                            IsActive = (bool)reader["IsActive"]
                        };
                        usersList.Add(user);
                    }
                }
            }
        }

        // Add a new user to the database
        public int Add()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Dbcon"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'Dbcon' not found.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertUser", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FirstName", thisUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", thisUser.LastName);
                cmd.Parameters.AddWithValue("@Email", thisUser.Email);
                cmd.Parameters.AddWithValue("@Password", thisUser.Password);
                cmd.Parameters.AddWithValue("@Address", thisUser.Address);
                cmd.Parameters.AddWithValue("@Role", thisUser.Role);
                cmd.Parameters.AddWithValue("@IsActive", thisUser.IsActive);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()); // Assumes spInsertUser returns the new UserId
            }
        }

        // Update an existing user in the database
        public void Update()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Dbcon"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'Dbcon' not found.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Address = @Address, Password = @Password, Role = @Role, IsActive = @IsActive WHERE UserId = @UserId", conn);
                cmd.Parameters.AddWithValue("@UserId", thisUser.UserId);
                cmd.Parameters.AddWithValue("@FirstName", thisUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", thisUser.LastName);
                cmd.Parameters.AddWithValue("@Email", thisUser.Email);
                cmd.Parameters.AddWithValue("@Address", thisUser.Address);
                cmd.Parameters.AddWithValue("@Password", thisUser.Password);
                cmd.Parameters.AddWithValue("@Role", thisUser.Role);
                cmd.Parameters.AddWithValue("@IsActive", thisUser.IsActive);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a user from the database
        public void Delete(int userId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Dbcon"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'Dbcon' not found.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserId = @UserId", conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Filter users by a keyword in their name
        public void FilterByName(string keyword)
        {
            usersList.Clear();
            var connectionString = ConfigurationManager.ConnectionStrings["Dbcon"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'Dbcon' not found.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE FirstName LIKE @Keyword OR LastName LIKE @Keyword", conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users user = new Users
                        {
                            UserId = (int)reader["UserId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString(),
                            IsActive = (bool)reader["IsActive"]
                        };
                        usersList.Add(user);
                    }
                }
            }
        }

        public Users GetUserById(int newUserId)
        {
            throw new NotImplementedException();
        }
    }
}