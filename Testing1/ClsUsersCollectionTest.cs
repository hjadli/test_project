using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing1
{
    [TestClass]
    public class ClsUsersCollectionTest
    {
        [TestMethod]
        public void InstanceOK()
        {
            // Create an instance of ClsUsersCollection
            ClsUsersCollection usersCollection = new ClsUsersCollection();
            // Test to see if it exists
            Assert.IsNotNull(usersCollection);
        }

        [TestMethod]
        public void UsersListOK()
        {
            // Create an instance of ClsUsersCollection
            ClsUsersCollection usersCollection = new ClsUsersCollection();
            // Create test data
            List<ClsUsers> testList = new List<ClsUsers>();
            // Add an item to the list
            ClsUsers testUser = new ClsUsers
            {
                UserId = 1,
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "Harpreet.Singh@example.com",
                Address = "123 Main St",
                Password = "password123",
                Role = "user",
                IsActive = true
            };
            testList.Add(testUser);
            // Assign the data to the property
            usersCollection.UsersList = testList;
            // Test to see that the two values are the same
            Assert.AreEqual(usersCollection.UsersList, testList);
        }

        [TestMethod]
        public void ThisUserOK()
        {
            // Create an instance of ClsUsersCollection
            ClsUsersCollection usersCollection = new ClsUsersCollection();
            // Create test data
            ClsUsers testUser = new ClsUsers
            {
                UserId = 1,
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "Harpreet.Singh@example.com",
                Address = "123 Main St",
                Password = "password123",
                Role = "user",
                IsActive = true
            };
            // Assign the data to the property
            usersCollection.ThisUser = testUser;
            // Test to see that the two values are the same
            Assert.AreEqual(usersCollection.ThisUser, testUser);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            // Create an instance of ClsUsersCollection
            ClsUsersCollection usersCollection = new ClsUsersCollection();
            // Create test data
            List<ClsUsers> testList = new List<ClsUsers>();
            // Add an item to the list
            ClsUsers testUser = new ClsUsers
            {
                UserId = 1,
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "Harpreet.Singh@example.com",
                Address = "123 Main St",
                Password = "password123",
                Role = "user",
                IsActive = true
            };
            testList.Add(testUser);
            // Assign the data to the property
            usersCollection.UsersList = testList;
            // Test to see that the two values are the same
            Assert.AreEqual(usersCollection.Count, testList.Count);
        }

        [TestMethod]
        public void AddMethodOK()
        {
            // Create an instance of ClsUsersCollection
            ClsUsersCollection usersCollection = new ClsUsersCollection();
            // Create the item of test data
            ClsUsers testUser = new ClsUsers
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "uniqueemail1@example.com", // Ensure a unique email for the test
                Address = "123 Main St",
                Password = "password123",
                Role = "user",
                IsActive = true
            };
            // Set ThisUser to the test data
            usersCollection.ThisUser = testUser;
            // Add the record
            int primaryKey = usersCollection.Add();
            // Set the primary key of the test data
            testUser.UserId = primaryKey;
            // Find the record
            bool found = usersCollection.ThisUser.Find(testUser.UserId);
            // Assert that the record was found
            Assert.IsTrue(found, $"User with UserId {testUser.UserId} was not found after adding. Primary key returned: {primaryKey}");
            // Assert that the values are correct
            Assert.AreEqual(usersCollection.ThisUser.FirstName, "Harpreet", "FirstName did not match after adding.");
            Assert.AreEqual(usersCollection.ThisUser.LastName, "Singh", "LastName did not match after adding.");
            Assert.AreEqual(usersCollection.ThisUser.Email, "uniqueemail@example.com", "Email did not match after adding.");
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            // Create an instance of ClsUsersCollection
            ClsUsersCollection usersCollection = new ClsUsersCollection();
            // Create the item of test data
            ClsUsers testUser = new ClsUsers
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "uniqueemail2@example.com", // Ensure a unique email for the test
                Address = "123 Main St",
                Password = "password123",
                Role = "user",
                IsActive = true
            };
            // Set ThisUser to the test data
            usersCollection.ThisUser = testUser;
            // Add the record
            int primaryKey = usersCollection.Add();
            // Set the primary key of the test data
            testUser.UserId = primaryKey;
            // Find the record
            bool found = usersCollection.ThisUser.Find(testUser.UserId);
            // Test to see that the two values are the same
            Assert.IsTrue(found, $"User with UserId {testUser.UserId} was not found after adding. Primary key returned: {primaryKey}");
            // Delete the record
            usersCollection.Delete(testUser.UserId);
            // Try to find the record again
            found = usersCollection.ThisUser.Find(testUser.UserId);
            // Test to see that the record was deleted
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            // Create an instance of ClsUsersCollection
            ClsUsersCollection usersCollection = new ClsUsersCollection();
            // Create the item of test data
            ClsUsers testUser = new ClsUsers
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "uniqueemail3@example.com", // Ensure a unique email for the test
                Address = "123 Main St",
                Password = "password123",
                Role = "user",
                IsActive = true
            };
            // Set ThisUser to the test data
            usersCollection.ThisUser = testUser;
            // Add the record
            int primaryKey = usersCollection.Add();
            // Set the primary key of the test data
            testUser.UserId = primaryKey;
            // Modify the test data
            testUser.FirstName = "UpdatedFirstName";
            testUser.LastName = "UpdatedLastName";
            testUser.Email = "Updated.Email@example.com";
            // Update the record
            usersCollection.ThisUser = testUser;
            usersCollection.Update();
            // Find the record
            bool found = usersCollection.ThisUser.Find(testUser.UserId);
            // Assert that the record was found
            Assert.IsTrue(found, $"User with UserId {testUser.UserId} was not found after updating.");
            // Test to see that the values are the same
            Assert.AreEqual(usersCollection.ThisUser.FirstName, "UpdatedFirstName", "FirstName did not match after updating.");
            Assert.AreEqual(usersCollection.ThisUser.LastName, "UpdatedLastName", "LastName did not match after updating.");
            Assert.AreEqual(usersCollection.ThisUser.Email, "Updated.Email@example.com", "Email did not match after updating.");
        }
    }
}