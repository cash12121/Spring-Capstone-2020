using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/14
    /// Approver: Cash Carlson
    /// 
    /// Holds tests for product manager class.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    [TestClass]
    public class ProductManagerTests
    {
        private IProductAccessor _productAccessor;
        private IProductAccessor _fakeProductAccessor;
        private IProductManager _productManager;
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Load fake product accessor for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _productAccessor = new FakeProductAccessor();
            _fakeProductAccessor = new FakeProductAccessor();
            _productManager = new ProductManager(_fakeProductAccessor);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/14
        /// Approver: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to retrieve products from the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestProductManagerRetrievesTestsTestType()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            string typeToSearch = "Test Type";
            int productsExpected = 1;

            // Act
            products = productManager.RetrieveAllProductsByType(typeToSearch);

            // Assert
            Assert.AreEqual(productsExpected, products.Count);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to retrieve all products from the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestProductManagerRetrievesAllTypes()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            int productsExpected = 4;

            // Act
            products = productManager.RetrieveAllProductsByType();

            // Assert
            Assert.AreEqual(productsExpected, products.Count);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to retrieve products with a mismatched type.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestProductManagerMissingData()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            string typeToSearch = "Bad Type";
            int productsExpected = 0;

            //Act
            products = productManager.RetrieveAllProductsByType(typeToSearch);

            Assert.AreEqual(productsExpected, products.Count);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Appprover: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to catch a thrown application exception.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDataLoadFailure()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            string typeToSearch = "Fail Type";

            //Act
            products = productManager.RetrieveAllProductsByType(typeToSearch);
            // Should fail at this point
        }

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/13/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Test method for the EditProduct  method
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditProduct()
        {
            // arrange, the attribute that need
            Product oldProduct = new Product();
            Product newProduct = new Product();
            bool result = false;
            bool expected = true;

            //act
            oldProduct.ProductID = "1234567890120";
            oldProduct.ItemID = 0;
            oldProduct.Name = "Test";
            oldProduct.Category = "Test Category";
            oldProduct.Type = "Test Type";
            oldProduct.Description = "A test product description.";
            oldProduct.Price = 0.50M;
            oldProduct.Brand = "Test Brand";
            oldProduct.Taxable = true;

            newProduct.ProductID = "1234567890120";
            newProduct.ItemID = 0;
            newProduct.Name = "Test";
            newProduct.Category = "Test Category";
            newProduct.Type = "Test Type";
            newProduct.Description = "A test product description.";
            newProduct.Price = 10.00M;
            newProduct.Brand = "Test Brand";
            newProduct.Taxable = true;

            result = _productManager.EditProduct(oldProduct, newProduct);

            // Assert
            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Tests whether the Product Manager is able to add a product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAddProduct()
        {
            // Arrange
            Product product = new Product()
            {
                ProductID = "1234567890123",
                Name = "Test Product",
                Category = "Test Category",
                Brand = "Test Brand",
                ItemID = 100000,
                Price = 1.0M,
                Taxable = true,
                Type = "Test Type",
                Description = "Test product description."
            };
            int expected = 1;

            // Act
            int actual = _productAccessor.InsertProduct(product);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Tests whether the manager catches an exception thrown when attempting to add a duplicate item.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestFailAddProductDuplicate()
        {
            // Arrange
            Product product = new Product()
            {
                ProductID = "1234567890123",
                Name = "Test Product",
                Category = "Test Category",
                Brand = "Test Brand",
                ItemID = 100000,
                Price = 1.0M,
                Taxable = true,
                Type = "Test Type",
                Description = "Test product description."
            };

            // Act 
            _productAccessor.InsertProduct(product);
            _productAccessor.InsertProduct(product);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Tests whether the Product Manager is able to get the list of all product types.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestSelectAllProductTypeIDs()
        {
            // Arrange
            int expected = 1;

            // Act
            List<string> list = _productAccessor.SelectAllProductTypeIDs();
            int actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Test method for deactivate product
        /// </summary>
        [TestMethod]
        public void TestDeactivateProduct()
        {
            //Arrange
            int expected = 1;
            string testProductID = "1234567890121";

            //Act
            int actual = _productAccessor.DeactivateProduct(testProductID);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Test method for activate product
        /// </summary>
        [TestMethod]
        public void TestActivateProduct()
        {
            //Arrange
            int expected = 1;
            string testProductID = "1234567890124";

            //Act
            int actual = _productAccessor.ActivateProduct(testProductID);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2/21/2020
        /// Approver: Cash Carlson
        /// 
        /// Nullifies variables to set up for next run.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        [TestCleanup]
        public void TestCleanup()
        {
            _productAccessor = null;
            _fakeProductAccessor = null;
        }
    }
}
