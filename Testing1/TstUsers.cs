using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing1
{
    [TestClass]
    public class TstUsers
    {
        // Some test Data
        string firstName = "Harpreet";
        string lastName = "Singh";
        string email = "Harpreet.Singh@example.com";
        string address = "123 Main St";
        string password = "password123";
        string role = "user";
        string isActive = "true";

        [TestMethod]
        public void InstanceOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Test to see that it exists
            Assert.IsNotNull(AUser);
        }

        [TestMethod]
        public void UserIdPropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            int TestData = 1;
            // Assign the data to the property
            AUser.UserId = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.UserId, TestData);
        }

        [TestMethod]
        public void FirstNamePropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            string TestData = "Harpreet";
            // Assign the data to the property
            AUser.FirstName = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.FirstName, TestData);
        }

        [TestMethod]
        public void LastNamePropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            string TestData = "Singh";
            // Assign the data to the property
            AUser.LastName = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.LastName, TestData);
        }

        [TestMethod]
        public void EmailPropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            string TestData = "Harpreet.Singh@example.com";
            // Assign the data to the property
            AUser.Email = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.Email, TestData);
        }

        [TestMethod]
        public void AddressPropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            string TestData = "123 Main St";
            // Assign the data to the property
            AUser.Address = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.Address, TestData);
        }

        [TestMethod]
        public void PasswordPropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            string TestData = "password123";
            // Assign the data to the property
            AUser.Password = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.Password, TestData);
        }

        [TestMethod]
        public void RolePropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            string TestData = "admin";
            // Assign the data to the property
            AUser.Role = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.Role, TestData);
        }

        [TestMethod]
        public void IsActivePropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Create some test data to assign to the property
            bool TestData = false;
            // Assign the data to the property
            AUser.IsActive = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AUser.IsActive, TestData);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Test to see if the result is true
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestUserIdFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.UserId != 1)
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestFirstNameFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.FirstName != "Harpreet")
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestLastNameFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.LastName != "Singh")
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEmailFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.Email != "Harpreet.Singh@example.com")
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestAddressFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.Address != "123 Main St")
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPasswordFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.Password != "password123")
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestRoleFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.Role != "user")
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIsActiveFound()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // Boolean variable to store the result of the method
            Boolean Found = false;
            // Boolean variable to record if data is OK
            Boolean OK = true;
            // Test data to use with the method
            int UserId = 1;
            // Invoke the method
            Found = AUser.Find(UserId);
            // Check the property
            if (AUser.IsActive != true)
            {
                OK = false;
            }
            // Test to see that the result is correct
            Assert.IsTrue(OK);
        }

        // Validation Tests

        [TestMethod]
        public void FirstNameMinLessOne()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = ""; // this should trigger an error
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMin()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = "A"; // this should be ok
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMinPlusOne()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = "AA"; // this should be ok
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMaxLessOne()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = "".PadRight(49, 'A'); // this should be ok
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMax()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = "".PadRight(50, 'A'); // this should be ok
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMaxPlusOne()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = "".PadRight(51, 'A'); // this should trigger an error
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMid()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = "".PadRight(25, 'A'); // this should be ok
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        // Additional tests for LastName, Email, Address, Password, Role, IsActive...

        [TestMethod]
        public void InvalidData()
        {
            // Create an instance of the class we want to create
            ClsUsers AUser = new ClsUsers();
            // String variable to store any error message
            string Error = "";
            // Create some test data to pass to the method
            string firstName = "Harpreet";
            string lastName = "Singh";
            string email = "not an email"; // invalid email format
            string address = "123 Main St";
            string password = "password123";
            string role = "user";
            string isActive = "true";
            // Invoke the method
            Error = AUser.Valid(firstName, lastName, email, address, password, role, isActive);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }
    }
}