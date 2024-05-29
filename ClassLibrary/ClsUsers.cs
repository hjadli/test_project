using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class ClsUsers
    {
        // Private data members
        private int mUserId;
        private string mFirstName;
        private string mLastName;
        private string mEmail;
        private string mAddress;
        private string mPassword;
        private string mRole;
        private bool mIsActive;

        // Public properties
        public int UserId
        {
            get { return mUserId; }
            set { mUserId = value; }
        }

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string LastName
        {
            get { return mLastName; }
            set { mLastName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string Role
        {
            get { return mRole; }
            set { mRole = value; }
        }

        public bool IsActive
        {
            get { return mIsActive; }
            set { mIsActive = value; }
        }

        // Find method
        public bool Find(int userId)
        {
            // Here you would normally connect to a database to find the record
            // Simulating finding a record by setting data based on userId
            if (userId == 1)
            {
                mUserId = 1;
                mFirstName = "Harpreet";
                mLastName = "Singh";
                mEmail = "Harpreet.Singh@example.com";
                mAddress = "123 Main St";
                mPassword = "password123";
                mRole = "user";
                mIsActive = true;
                return true;
            }
            else
            {
                // Simulate record not found
                return false;
            }
        }

        // Valid method
        public string Valid(string firstName, string lastName, string email, string address, string password, string role, string isActive)
        {
            // Create a string variable to store the error
            string Error = "";

            // Validation rules

            // FirstName cannot be blank
            if (firstName.Length == 0)
            {
                Error += "The first name may not be blank : ";
            }
            // FirstName must be less than 50 characters
            if (firstName.Length > 50)
            {
                Error += "The first name must be less than 50 characters : ";
            }

            // LastName cannot be blank
            if (lastName.Length == 0)
            {
                Error += "The last name may not be blank : ";
            }
            // LastName must be less than 50 characters
            if (lastName.Length > 50)
            {
                Error += "The last name must be less than 50 characters : ";
            }

            // Email cannot be blank
            if (email.Length == 0)
            {
                Error += "The email may not be blank : ";
            }
            // Email must be less than 100 characters
            if (email.Length > 100)
            {
                Error += "The email must be less than 100 characters : ";
            }
            // Email must be in a valid format
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Error += "The email format is not valid : ";
            }

            // Address must be less than 255 characters
            if (address.Length > 255)
            {
                Error += "The address must be less than 255 characters : ";
            }

            // Password cannot be blank
            if (password.Length == 0)
            {
                Error += "The password may not be blank : ";
            }
            // Password must be less than 255 characters
            if (password.Length > 255)
            {
                Error += "The password must be less than 255 characters : ";
            }

            // Role must be either 'admin' or 'user'
            if (role != "admin" && role != "user")
            {
                Error += "The role must be either 'admin' or 'user' : ";
            }

            // IsActive must be either 'true' or 'false'
            bool isActiveBool;
            if (!bool.TryParse(isActive, out isActiveBool))
            {
                Error += "The active status must be either 'true' or 'false' : ";
            }

            // Return any error messages
            return Error;
        }
    }
}
