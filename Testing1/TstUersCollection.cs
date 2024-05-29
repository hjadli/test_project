using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing1
{
    [TestClass]
    public class TstUsersCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            // Create an instance of the class we want to create
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            // Test to see that it exists
            Assert.IsNotNull(AllUsers);
        }

        [TestMethod]
        public void UsersListOK()
        {
            // Create an instance of the class we want to create
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            // Create some test data to assign to the property
            List<ClsUsers> TestList = new List<ClsUsers>();
            // Add an item to the list
            ClsUsers TestItem = new ClsUsers();
            // Set its properties
            TestItem.UserId = 1;
            TestItem.FirstName = "John";
            TestItem.LastName = "Doe";
            TestItem.Email = "john.doe@example.com";
            TestItem.Address = "123 Main St";
            TestItem.Password = "password123";
            TestItem.Role = "user";
            TestItem.IsActive = true;
            // Add the item to the test list
            TestList.Add(TestItem);
            // Assign the data to the property
            AllUsers.UsersList = TestList;
            // Test to see that the two values are the same
            Assert.AreEqual(AllUsers.UsersList, TestList);
        }

        [TestMethod]
        public void CountPropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            // Create some test data to assign to the property
            int ExpectedCount = AllUsers.UsersList.Count;
            // Test to see that the two values are the same
            Assert.AreEqual(AllUsers.Count, ExpectedCount);
        }

        [TestMethod]
        public void ThisUserPropertyOK()
        {
            // Create an instance of the class we want to create
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            // Create some test data to assign to the property
            ClsUsers TestUser = new ClsUsers();
            // Set its properties
            TestUser.UserId = 1;
            TestUser.FirstName = "John";
            TestUser.LastName = "Doe";
            TestUser.Email = "john.doe@example.com";
            TestUser.Address = "123 Main St";
            TestUser.Password = "password123";
            TestUser.Role = "user";
            TestUser.IsActive = true;
            // Assign the data to the property
            AllUsers.ThisUser = TestUser;
            // Test to see that the two values are the same
            Assert.AreEqual(AllUsers.ThisUser, TestUser);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            // Create an instance of the class we want to create
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            // Create the item of test data
            ClsUsers TestItem = new ClsUsers();
            // Variable to store the primary key
            int PrimaryKey = 0;
            // Set its properties
            TestItem.FirstName = "John";
            TestItem.LastName = "Doe";
            TestItem.Email = "john.doe@example.com";
            TestItem.Address = "123 Main St";
            TestItem.Password = "password123";
            TestItem.Role = "user";
            TestItem.IsActive = true;
            // Set ThisUser to the test data
            AllUsers.ThisUser = TestItem;
            // Add the record
            PrimaryKey = AllUsers.Add();
            // Set the primary key of the test data
            TestItem.UserId = PrimaryKey;
            // Find the record
            AllUsers.ThisUser.Find(PrimaryKey);
            // Test to see that the two values are the same
            Assert.AreEqual(AllUsers.ThisUser, TestItem);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            // Create an instance of the class we want to create
            ClsUsersCollection AllUsers = new ClsUsersCollection();
            // Create the item of test data
            ClsUsers TestItem = new ClsUsers();
            // Variable to store the primary key
            int PrimaryKey = 0;
            // Set its properties
            TestItem.FirstName = "John";
            TestItem.LastName = "Doe";
            TestItem.Email = "john.doe@example.com";
            TestItem.Address = "123 Main St";
            TestItem.Password = "password123";
            TestItem.Role = "user";
            TestItem.IsActive = true;
            // Set ThisUser to the test data
            AllUsers.ThisUser = TestItem;
            // Add the record
            PrimaryKey = AllUsers.Add();
            // Set the primary key of the test data
            TestItem.UserId = PrimaryKey;
            // Find the record
            AllUsers.ThisUser.Find(PrimaryKey);
            // Delete the record
            AllUsers.Delete();
            // Now find the record
            Boolean Found = AllUsers.ThisUser.Find(PrimaryKey);
            // Test to see that the record was not found
            Assert.IsFalse(Found);
        }
    }
}




