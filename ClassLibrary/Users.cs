using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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

        // Validation Method
        public string Valid(string firstName, string lastName, string email, string password, string address)
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(firstName))
            {
                error += "First name is required. ";
            }
            else if (firstName.Length > 50)
            {
                error += "First name must be less than 50 characters. ";
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                error += "Last name is required. ";
            }
            else if (lastName.Length > 50)
            {
                error += "Last name must be less than 50 characters. ";
            }

            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                error += "A valid email is required. ";
            }
            else if (email.Length > 100)
            {
                error += "Email must be less than 100 characters. ";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                error += "Password is required. ";
            }
            else if (password.Length > 255)
            {
                error += "Password must be less than 255 characters. ";
            }

            if (!string.IsNullOrWhiteSpace(address) && address.Length > 255)
            {
                error += "Address must be less than 255 characters. ";
            }

            return error.Trim();
        }

        // Email Validation Method
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Method to Find User by Id
        public bool Find(int userId)
        {
            // Simulated data source for testing purposes
            var users = new[]
            {
                new Users { UserId = 1, FirstName = "Harpreet", LastName = "Singh", Email = "harpreet.singh@example.com", Address = "123 Main St", Password = "password123", Role = "user", IsActive = true },
                new Users { UserId = 2, FirstName = "Noman", LastName = "Doe", Email = "noman.doe@example.com", Address = "456 Elm St", Password = "password456", Role = "admin", IsActive = true }
            };

            foreach (var user in users)
            {
                if (user.UserId == userId)
                {
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
            }
            return false;
        }
    }
}