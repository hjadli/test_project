using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace Testing1
{
    [TestClass]
    public class UsersTests
    {
        // Method to create a sample user object for testing
        private Users CreateTestUser()
        {
            return new Users
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "harpreet.singh@example.com",
                Password = "password123",
                Address = "123 Main St",
                Role = "user",
                IsActive = true
            };
        }

        // Test to ensure that an instance of the Users class can be created
        [TestMethod]
        public void InstanceCreationTest()
        {
            Users user = new Users(); // Create an instance of Users
            Assert.IsNotNull(user); // Check that the instance is not null
        }

        // Test to ensure that the Valid method works with valid data
        [TestMethod]
        public void ValidMethodTest_ValidData()
        {
            Users user = new Users(); // Create an instance of Users
            string error = user.Valid("Harpreet", "Singh", "harpreet.singh@example.com", "password123", "123 Main St"); // Call the Valid method with valid data
            Assert.AreEqual("", error); // Check that the method returns an empty error string
        }

        // Test to ensure that the Valid method detects missing first name
        [TestMethod]
        public void ValidMethodTest_MissingFirstName()
        {
            Users user = new Users(); // Create an instance of Users
            string error = user.Valid("", "Singh", "harpreet.singh@example.com", "password123", "123 Main St"); // Call the Valid method with missing first name
            Assert.AreEqual("First name is required.", error); // Check that the method returns the appropriate error message
        }

        // Test to ensure that the Valid method detects missing last name
        [TestMethod]
        public void ValidMethodTest_MissingLastName()
        {
            Users user = new Users(); // Create an instance of Users
            string error = user.Valid("Harpreet", "", "harpreet.singh@example.com", "password123", "123 Main St"); // Call the Valid method with missing last name
            Assert.AreEqual("Last name is required.", error); // Check that the method returns the appropriate error message
        }

        // Test to ensure that the Valid method detects an invalid email
        [TestMethod]
        public void ValidMethodTest_InvalidEmail()
        {
            Users user = new Users(); // Create an instance of Users
            string error = user.Valid("Harpreet", "Singh", "invalid-email", "password123", "123 Main St"); // Call the Valid method with an invalid email
            Assert.AreEqual("A valid email is required.", error); // Check that the method returns the appropriate error message
        }

        // Test to ensure that the Valid method detects missing password
        [TestMethod]
        public void ValidMethodTest_MissingPassword()
        {
            Users user = new Users(); // Create an instance of Users
            string error = user.Valid("Harpreet", "Singh", "harpreet.singh@example.com", "", "123 Main St"); // Call the Valid method with missing password
            Assert.AreEqual("Password is required.", error); // Check that the method returns the appropriate error message
        }

        // Test to ensure that the Valid method detects multiple errors
        [TestMethod]
        public void ValidMethodTest_MultipleErrors()
        {
            Users user = new Users(); // Create an instance of Users
            string error = user.Valid("", "", "invalid-email", "", "123 Main St"); // Call the Valid method with multiple invalid fields
            Assert.AreEqual("First name is required. Last name is required. A valid email is required. Password is required.", error); // Check that the method returns all the appropriate error messages
        }

        // Test to ensure that the Role property accepts "user"
        [TestMethod]
        public void RolePropertyTest_ValidUser()
        {
            Users user = new Users { Role = "user" }; // Set the Role property to "user"
            Assert.AreEqual("user", user.Role); // Check that the Role property is correctly set
        }

        // Test to ensure that the Role property accepts "admin"
        [TestMethod]
        public void RolePropertyTest_ValidAdmin()
        {
            Users user = new Users { Role = "admin" }; // Set the Role property to "admin"
            Assert.AreEqual("admin", user.Role); // Check that the Role property is correctly set
        }

        // Test to ensure that the Role property throws an exception for an invalid role
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RolePropertyTest_InvalidRole()
        {
            Users user = new Users { Role = "invalidrole" }; // Set the Role property to an invalid role, which should throw an exception
        }

        // Test to ensure that the Find method works when the user is found
        [TestMethod]
        public void FindMethodTest_UserFound()
        {
            Users user = new Users(); // Create an instance of Users
            bool found = user.Find(1); // Call the Find method with a UserId that exists in the simulated data source
            Assert.IsTrue(found); // Check that the user is found
            Assert.AreEqual("Harpreet", user.FirstName); // Check that the user's first name is correctly set
        }

        // Test to ensure that the Find method works when the user is not found
        [TestMethod]
        public void FindMethodTest_UserNotFound()
        {
            Users user = new Users(); // Create an instance of Users
            bool found = user.Find(-1); // Call the Find method with a UserId that does not exist in the simulated data source
            Assert.IsFalse(found); // Check that the user is not found
        }
    }
}
