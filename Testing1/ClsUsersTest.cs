using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing1
{
    [TestClass]
    public class ClsUsersTest
    {
        // Test data
        String FirstName = "Harpreet";
        String LastName = "Singh";
        String Email = "Harpreet.Singh@example.com";
        String Address = "123 Main St";
        String Password = "password123";
        String Role = "user";
        String IsActive = "true";

        /******************** Validation OK Tests *********************/
        [TestMethod]
        public void ValidMethodOK()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        /********************** FirstName Validation ************************/
        [TestMethod]
        public void FirstNameMinLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String FirstName = "";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The first name may not be blank. ");
        }

        [TestMethod]
        public void FirstNameMin()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String FirstName = "a";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMinPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String FirstName = "aa";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMaxLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String FirstName = new string('a', 49);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMax()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String FirstName = new string('a', 50);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void FirstNameMaxPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String FirstName = new string('a', 51);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The first name must be less than 50 characters. ");
        }

        /********************** LastName Validation ************************/
        [TestMethod]
        public void LastNameMinLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String LastName = "";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The last name may not be blank. ");
        }

        [TestMethod]
        public void LastNameMin()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String LastName = "a";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void LastNameMinPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String LastName = "aa";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void LastNameMaxLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String LastName = new string('a', 49);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void LastNameMax()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String LastName = new string('a', 50);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void LastNameMaxPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String LastName = new string('a', 51);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The last name must be less than 50 characters. ");
        }

        /********************** Email Validation ************************/
        [TestMethod]
        public void EmailMinLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Email = "";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The email may not be blank. ");
        }

        [TestMethod]
        public void EmailMin()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Email = "a";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailMinPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Email = "aa";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailMaxLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Email = new string('a', 99);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailMax()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Email = new string('a', 100);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailMaxPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Email = new string('a', 101);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The email must be less than 100 characters. ");
        }

        [TestMethod]
        public void EmailInvalidFormat()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Email = "invalid-email-format";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The email format is not valid. ");
        }

        /********************** Password Validation ************************/
        [TestMethod]
        public void PasswordMinLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Password = "";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The password may not be blank. ");
        }

        [TestMethod]
        public void PasswordMin()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Password = "a";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PasswordMinPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Password = "aa";
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PasswordMaxLessOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Password = new string('a', 254);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PasswordMax()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Password = new string('a', 255);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PasswordMaxPlusOne()
        {
            ClsUsers AUser = new ClsUsers();
            String Error = "";
            String Password = new string('a', 256);
            Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual(Error, "The password must be less than 255 characters. ");
        }

        /********************** Find Method Tests ************************/
        [TestMethod]
        public void FindMethodOK()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestUserIdFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.UserId != 1)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestFirstNameFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.FirstName != "Harpreet")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestLastNameFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.LastName != "Singh")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEmailFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.Email != "Harpreet.Singh@example.com")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestAddressFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.Address != "123 Main St")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPasswordFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.Password != "password123")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestRoleFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.Role != "user")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIsActiveFound()
        {
            ClsUsers AUser = new ClsUsers();
            Boolean Found = false;
            Boolean OK = true;
            Int32 UserId = 1;
            Found = AUser.Find(UserId);
            if (AUser.IsActive != true)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }
    }
}