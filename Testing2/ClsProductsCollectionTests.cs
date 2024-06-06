using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing2
{
    [TestClass]
    public class ClsProductsCollectionTests
    {
        [TestMethod]
        public void InstanceOK()
        {
            // Arrange and Act
            ClsProductsCollection allProducts = new ClsProductsCollection();
            // Assert
            Assert.IsNotNull(allProducts);
        }

        [TestMethod]
        public void ProductsListOK()
        {
            // Arrange
            ClsProductsCollection allProducts = new ClsProductsCollection();
            List<ClsProduct> testList = new List<ClsProduct>();
            ClsProduct testItem = new ClsProduct
            {
                ProductId = 1,
                ProductName = "Test Product",
                ProductDescription = "Test Description",
                Price = 19.99M,
                Stock = 100,
                CategoryId = 1,
                SupplierId = 1
            };
            testList.Add(testItem);
            // Act
            allProducts.ProductsList = testList;
            // Assert
            Assert.AreEqual(allProducts.ProductsList, testList);
        }

        [TestMethod]
        public void CountPropertyOK()
        {
            // Arrange
            ClsProductsCollection allProducts = new ClsProductsCollection();
            List<ClsProduct> testList = new List<ClsProduct>();
            ClsProduct testItem = new ClsProduct
            {
                ProductId = 1,
                ProductName = "Test Product",
                ProductDescription = "Test Description",
                Price = 19.99M,
                Stock = 100,
                CategoryId = 1,
                SupplierId = 1
            };
            testList.Add(testItem);
            allProducts.ProductsList = testList;
            // Act
            int count = allProducts.Count;
            // Assert
            Assert.AreEqual(count, testList.Count);
        }

        [TestMethod]
        public void ThisProductPropertyOK()
        {
            // Arrange
            ClsProductsCollection allProducts = new ClsProductsCollection();
            ClsProduct testItem = new ClsProduct
            {
                ProductId = 1,
                ProductName = "Test Product",
                ProductDescription = "Test Description",
                Price = 19.99M,
                Stock = 100,
                CategoryId = 1,
                SupplierId = 1
            };
            // Act
            allProducts.ThisProduct = testItem;
            // Assert
            Assert.AreEqual(allProducts.ThisProduct, testItem);
        }

        [TestMethod]
        public void ListAndCountOK()
        {
            // Arrange
            ClsProductsCollection allProducts = new ClsProductsCollection();
            List<ClsProduct> testList = new List<ClsProduct>();
            ClsProduct testItem = new ClsProduct
            {
                ProductId = 1,
                ProductName = "Test Product",
                ProductDescription = "Test Description",
                Price = 19.99M,
                Stock = 100,
                CategoryId = 1,
                SupplierId = 1
            };
            testList.Add(testItem);
            // Act
            allProducts.ProductsList = testList;
            // Assert
            Assert.AreEqual(allProducts.Count, testList.Count);
        }

        


    }
}