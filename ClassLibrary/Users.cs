using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Users
    {
        private string role;
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Role
        {
            get => role ?? "user";
            set
            {
                if (value != "user" && value != "admin")
                {
                    throw new ArgumentException("Invalid role specified. Only 'user' or 'admin' are allowed.");
                }
                role = value;
            }
        }
        public bool IsActive { get; set; } = true;

        // Simulated data source
        private static readonly Dictionary<int, Users> dataSource = new Dictionary<int, Users>
        {
            { 1, new Users { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Address = "123 Main St", Password = "password123", Role = "user" } },
            { 2, new Users { UserId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Address = "456 Elm St", Password = "password456", Role = "admin" } }
        };

        // Find method
        public bool Find(int userId)
        {
            if (dataSource.ContainsKey(userId))
            {
                var user = dataSource[userId];
                UserId = user.UserId;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Address = user.Address;
                Password = user.Password;
                Role = user.Role;
                IsActive = user.IsActive;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}