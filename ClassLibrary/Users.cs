using System;

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
    }
}