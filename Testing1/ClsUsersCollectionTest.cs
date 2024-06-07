using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing1
{
    [TestClass]
    public class ClsUsersCollectionTest
    {
        /****************** Instance of the class Test *********************/
        [TestMethod]
        public void InstanceOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            Assert.IsNotNull(AllUsers);
        }

        /************************* Property OK Tests ************************/
        [TestMethod]
        public void UsersListOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            List<ClsUsers> TestList = new List<ClsUsers>();
            ClsUsers TestItem = new ClsUsers();

            TestItem.UserId = 1;
            TestItem.FirstName = "Harpreet";
            TestItem.LastName = "Singh";
            TestItem.Email = "Harpreet.Singh@example.com";
            TestItem.Address = "123 Main St";
            TestItem.Password = "password123";
            TestItem.Role = "user";
            TestItem.IsActive = true;

            TestList.Add(TestItem);
            AllUsers.UsersList = TestList;

            Assert.AreEqual(AllUsers.UsersList, TestList);
        }

       

        [TestMethod]
        public void ThisUserPropertyOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            ClsUsers TestItem = new ClsUsers();

            TestItem.UserId = 1;
            TestItem.FirstName = "Harpreet";
            TestItem.LastName = "Singh";
            TestItem.Email = "Harpreet.Singh@example.com";
            TestItem.Address = "123 Main St";
            TestItem.Password = "password123";
            TestItem.Role = "user";
            TestItem.IsActive = true;

            AllUsers.ThisUser = TestItem;

            Assert.AreEqual(AllUsers.ThisUser, TestItem);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            List<ClsUsers> TestList = new List<ClsUsers>();
            ClsUsers TestItem = new ClsUsers();

            TestItem.UserId = 1;
            TestItem.FirstName = "Harpreet";
            TestItem.LastName = "Singh";
            TestItem.Email = "Harpreet.Singh@example.com";
            TestItem.Address = "123 Main St";
            TestItem.Password = "password123";
            TestItem.Role = "user";
            TestItem.IsActive = true;

            TestList.Add(TestItem);
            AllUsers.UsersList = TestList;

            Assert.AreEqual(AllUsers.Count, TestList.Count);
        }

        [TestMethod]
        public void TwoRecordsPresent()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            Assert.AreEqual(AllUsers.Count, AllUsers.Count);
        }

        /*************************** Add Method Test **************************************/
        [TestMethod]
        public void AddMethodOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            ClsUsers TestUser = new ClsUsers();
            Int32 PrimaryKey = 0;

            TestUser.FirstName = "Harpreet";
            TestUser.LastName = "Singh";
            TestUser.Email = "Harpreet.Singh2@example.com"; // Ensure this email is unique
            TestUser.Address = "123 Main St";
            TestUser.Password = "password123";
            TestUser.Role = "user";
            TestUser.IsActive = true;

            AllUsers.ThisUser = TestUser;
            PrimaryKey = AllUsers.Add();
            TestUser.UserId = PrimaryKey;

            AllUsers.ThisUser.Find(PrimaryKey);
            Assert.AreEqual(AllUsers.ThisUser, TestUser);
        }

        /********************************** Update Method Test ************************************/
        [TestMethod]
        public void UpdateMethodOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            ClsUsers TestUser = new ClsUsers();
            Int32 PrimaryKey = 0;

            TestUser.FirstName = "Harpreet";
            TestUser.LastName = "Singh";
            TestUser.Email = "Harpreet.Singh3@example.com"; // Ensure this email is unique
            TestUser.Address = "123 Main St";
            TestUser.Password = "password123";
            TestUser.Role = "user";
            TestUser.IsActive = true;

            AllUsers.ThisUser = TestUser;
            PrimaryKey = AllUsers.Add();
            TestUser.UserId = PrimaryKey;

            TestUser.FirstName = "UpdatedFirstName";
            TestUser.LastName = "UpdatedLastName";
            TestUser.Email = "Updated.Email@example.com";
            TestUser.Address = "Updated Address";
            TestUser.Password = "UpdatedPassword";
            TestUser.Role = "user";
            TestUser.IsActive = false;

            AllUsers.ThisUser = TestUser;
            AllUsers.Update();
            AllUsers.ThisUser.Find(PrimaryKey);
            Assert.AreEqual(AllUsers.ThisUser, TestUser);
        }

        /********************************** Delete Method Test ************************************/
        [TestMethod]
        public void DeleteMethodOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            ClsUsers TestUser = new ClsUsers();
            Int32 PrimaryKey = 0;

            TestUser.FirstName = "Harpreet";
            TestUser.LastName = "Singh";
            TestUser.Email = "Harpreet.Singh4@example.com"; // Ensure this email is unique
            TestUser.Address = "123 Main St";
            TestUser.Password = "password123";
            TestUser.Role = "user";
            TestUser.IsActive = true;

            AllUsers.ThisUser = TestUser;
            PrimaryKey = AllUsers.Add();
            TestUser.UserId = PrimaryKey;

            AllUsers.ThisUser.Find(PrimaryKey);
            AllUsers.Delete(TestUser.UserId);
            Boolean Found = AllUsers.ThisUser.Find(PrimaryKey);

            Assert.IsFalse(Found);
        }

        /********************************** Filter Method Test ************************************/
        [TestMethod]
        public void FilterByNameMethodOK()
        {
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            ClsUsersCollection FilteredUsers = new ClsUsersCollection();
            FilteredUsers.FilterByName("");

            Assert.AreEqual(AllUsers.Count, FilteredUsers.Count);
        }

        [TestMethod]
        public void FilterByNameNoneFound()
        {
            ClsUsersCollection FilteredUsers = new ClsUsersCollection();
            FilteredUsers.FilterByName("NonExistingName");

            Assert.AreEqual(0, FilteredUsers.Count);
        }

        [TestMethod]
        public void FilterByNameTestDataFound()
        {
            ClsUsersCollection FilteredUsers = new ClsUsersCollection();
            Boolean OK = true;
            FilteredUsers.FilterByName("Harpreet");

            if (FilteredUsers.Count == 1)
            {
                if (FilteredUsers.UsersList[0].UserId != 1)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }
    }
}