using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;
namespace Testing2
{
    [TestClass]
    public class ClsProductTests
    {
        // Good test data
        private string validProductName = "Test Product";
        private string validProductDescription = "This is a test product description.";
        private string validPrice = "19.99";
        private string validStock = "100";
        private string validCategoryId = "1";
        private string validSupplierId = "1";

        [TestMethod]
        public void ProductNameMinLength()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid("a", validProductDescription, validPrice, validStock, validCategoryId, validSupplierId);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void ProductNameMinLengthPlusOne()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid("aa", validProductDescription, validPrice, validStock, validCategoryId, validSupplierId);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void ProductNameMaxLength()
        {
            ClsProduct product = new ClsProduct();
            string productName = new string('a', 100);
            string error = product.Valid(productName, validProductDescription, validPrice, validStock, validCategoryId, validSupplierId);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void ProductNameMaxLengthPlusOne()
        {
            ClsProduct product = new ClsProduct();
            string productName = new string('a', 101);
            string error = product.Valid(productName, validProductDescription, validPrice, validStock, validCategoryId, validSupplierId);
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void ProductNameEmpty()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid("", validProductDescription, validPrice, validStock, validCategoryId, validSupplierId);
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void ProductDescriptionMaxLength()
        {
            ClsProduct product = new ClsProduct();
            string productDescription = new string('a', 255);
            string error = product.Valid(validProductName, productDescription, validPrice, validStock, validCategoryId, validSupplierId);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void ProductDescriptionMaxLengthPlusOne()
        {
            ClsProduct product = new ClsProduct();
            string productDescription = new string('a', 256);
            string error = product.Valid(validProductName, productDescription, validPrice, validStock, validCategoryId, validSupplierId);
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void PriceValid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, "19.99", validStock, validCategoryId, validSupplierId);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void PriceInvalid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, "invalid", validStock, validCategoryId, validSupplierId);
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void StockValid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, validPrice, "100", validCategoryId, validSupplierId);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void StockInvalid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, validPrice, "invalid", validCategoryId, validSupplierId);
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void CategoryIdValid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, validPrice, validStock, "1", validSupplierId);
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void CategoryIdInvalid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, validPrice, validStock, "invalid", validSupplierId);
            Assert.AreNotEqual("", error);
        }

        [TestMethod]
        public void SupplierIdValid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, validPrice, validStock, validCategoryId, "1");
            Assert.AreEqual("", error);
        }

        [TestMethod]
        public void SupplierIdInvalid()
        {
            ClsProduct product = new ClsProduct();
            string error = product.Valid(validProductName, validProductDescription, validPrice, validStock, validCategoryId, "invalid");
            Assert.AreNotEqual("", error);
        }
    }
}