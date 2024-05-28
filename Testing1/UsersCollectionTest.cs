using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing1
{
    [TestClass]
    public class UsersCollectionTest
    {
        [TestMethod]
        public void InstanceCreationTest()
        {
            UsersCollection usersCollection = new UsersCollection();
            Assert.IsNotNull(usersCollection);
        }

        [TestMethod]
        public void AddUserTest()
        {
            UsersCollection usersCollection = new UsersCollection();
            Users user = new Users
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "harpreet.singh@example.com",
                Password = "password123",
                Address = "Test Address",
                Role = "user",
                IsActive = true
            };
            usersCollection.ThisUser = user;

            int newUserId = usersCollection.Add(); // Add the user and get the new UserId

            usersCollection = new UsersCollection(); // Reload the collection to include the newly added user
            Users foundUser = usersCollection.UsersList.Find(u => u.UserId == newUserId);

            Assert.IsNotNull(foundUser); // Verify the user was found
            Assert.AreEqual(user.FirstName, foundUser.FirstName);
            Assert.AreEqual(user.LastName, foundUser.LastName);
            Assert.AreEqual(user.Email, foundUser.Email);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            UsersCollection usersCollection = new UsersCollection();
            Users user = new Users
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "harpreet.singh@example.com",
                Password = "password123",
                Address = "Test Address",
                Role = "user",
                IsActive = true
            };
            usersCollection.ThisUser = user;

            int newUserId = usersCollection.Add(); // Add the user
            user.UserId = newUserId;
            user.Email = "updated.email@example.com";
            usersCollection.ThisUser = user;
            usersCollection.Update(); // Update the user

            usersCollection = new UsersCollection(); // Reload the collection to include the updated user
            Users foundUser = usersCollection.UsersList.Find(u => u.UserId == newUserId);

            Assert.IsNotNull(foundUser); // Verify the user was found
            Assert.AreEqual("updated.email@example.com", foundUser.Email); // Verify the email was updated
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            UsersCollection usersCollection = new UsersCollection();
            Users user = new Users
            {
                FirstName = "Harpreet",
                LastName = "Singh",
                Email = "harpreet.singh@example.com",
                Password = "password123",
                Address = "Test Address",
                Role = "user",
                IsActive = true
            };
            usersCollection.ThisUser = user;

            int newUserId = usersCollection.Add(); // Add the user
            usersCollection.Delete(newUserId); // Delete the user

            usersCollection = new UsersCollection(); // Reload the collection to exclude the deleted user
            Users foundUser = usersCollection.UsersList.Find(u => u.UserId == newUserId);

            Assert.IsNull(foundUser); // Verify the user was not found
        }

        [TestMethod]
        public void FilterByNameTest()
        {
            UsersCollection usersCollection = new UsersCollection();
            usersCollection.FilterByName("Harpreet");

            List<Users> filteredUsers = usersCollection.UsersList;

            foreach (Users user in filteredUsers)
            {
                Assert.IsTrue(user.FirstName.Contains("Harpreet") || user.LastName.Contains("Harpreet"));
            }
        }
    }
}
