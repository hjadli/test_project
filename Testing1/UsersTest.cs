using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Text.RegularExpressions;

namespace Testing1
{
    [TestClass]
    public class UsersTest
    {
        [TestMethod]
        public void UsersClassOK()
        {
            // Create an instance of the class we want to create
            Users users = new Users();
            // Test to see that it exists
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void CreateUser_ShouldSetProperties()
        {
            var user = new Users
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "happy@gmail.com",
                Address = "Leicester",
                Password = "123456789",
                Role = "user",
                IsActive = true
            };

            Assert.AreEqual("Harpreet", user.FirstName);
            Assert.AreEqual("Singh", user.LastName);
            Assert.AreEqual("happy@gmail.com", user.Email);
            Assert.AreEqual("Leicester", user.Address);
            Assert.AreEqual("123456789", user.Password);
            Assert.AreEqual("user", user.Role);
            Assert.IsTrue(user.IsActive);
        }

        [TestMethod]
        public void DefaultRole_ShouldBeUser()
        {
            var user = new Users
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "happy@gmail.com",
                Address = "Leicester",
                Password = "123456789"
            };

            Assert.AreEqual("user", user.Role);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid role specified. Only 'user' or 'admin' are allowed.")]
        public void InvalidRole_ShouldThrowException()
        {
            var user = new Users
            {
                Role = "invalid"
            };
        }

        [TestMethod]
        public void ValidRole_User_ShouldBeSet()
        {
            var user = new Users
            {
                Role = "user"
            };

            Assert.AreEqual("user", user.Role);
        }

        [TestMethod]
        public void ValidRole_Admin_ShouldBeSet()
        {
            var user = new Users
            {
                Role = "admin"
            };

            Assert.AreEqual("admin", user.Role);
        }

        [TestMethod]
        public void EmailFormat_ShouldBeValid()
        {
            var user = new Users
            {
                Email = "happy@gmail.com"
            };

            Assert.IsTrue(IsValidEmail(user.Email));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Invalid email format.")]
        public void InvalidEmailFormat_ShouldThrowException()
        {
            ValidateEmailFormat("invalid-email");
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }

        private void ValidateEmailFormat(string email)
        {
            if (!IsValidEmail(email))
            {
                throw new FormatException("Invalid email format.");
            }
        }

        /****************** FIND METHOD TEST ******************/

        [TestMethod]
        public void FindMethodOK()
        {
            // Create an instance of the class we want to create
            Users users = new Users();
            // Create some test data to use with the method
            int userId = 1;
            // Invoke the method
            bool found = users.Find(userId);
            // Test to see if the result is true
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void FindMethodNotFound()
        {
            // Create an instance of the class we want to create
            Users users = new Users();
            // Create some test data to use with the method
            int userId = 999; // Assume this ID does not exist
            // Invoke the method
            bool found = users.Find(userId);
            // Test to see if the result is false
            Assert.IsFalse(found);
        }
    }
}
