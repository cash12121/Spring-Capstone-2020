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
    /// Creator: Jaeho Kim
    /// Created: 2/27/2020
    /// Approver: Rasha Mohammed
    ///  
    /// Test Class for TransactionManager
    /// </summary>
    [TestClass]
    public class TransactionManagerTests
    {

        private ITransactionAccessor _transactionAccessor;

        private TransactionManager _transactionManager;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Constructor for instantiating FakeTransactionAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public TransactionManagerTests()
        {
            _transactionAccessor = new FakeTransactionAccessor();
        }

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/26/2020
        /// CHECKED BY: Jaeho Kim
        /// 
        /// Load fake transcationLine accessor for testing purposes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _transactionAccessor = new FakeTransactionAccessor();
            _transactionManager = new TransactionManager(_transactionAccessor);
        }


        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        ///  
        /// Test method for retrieving all products using a transactionId
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllProductsByTransactionID()
        {
            // arrange 
            List<TransactionVM> products;
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);
            // Act
            products = transactionManager.RetrieveAllProductsByTransactionID(1000);
            // assert
            Assert.AreEqual(1, products.Count);
        }

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/28/2020
        /// CHECKED BY: Jaeho Kim
        /// 
        /// Tests whether the transaction Manager is able to delete the item from transactionLine.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestDeleteItemt()
        {
            // arrange
            string productID = "123abc456";
            bool result = false;

            // act
            result = _transactionManager.DeleteItem(productID);

            // assert
            Assert.AreEqual(true, result);

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Tests AddTransaction
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddTransaction()
        {


            Transaction newTransaction = new Transaction()
            {
                EmployeeID = 100002
            };

            FakeTransactionAccessor _transactionAccessor = new FakeTransactionAccessor();

            bool result = _transactionAccessor.InsertTransaction(newTransaction) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Tests AddTransactionLineProducts
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddTransactionLineProducts()
        {
            bool result = false;

            TransactionLineProducts newTransactionLineProducts = new TransactionLineProducts()
            {
                TransactionID = 100002
            };

            FakeTransactionAccessor _transactionAccessor = new FakeTransactionAccessor();

            result = _transactionAccessor.InsertTransactionLineProducts(newTransactionLineProducts) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This is a unit test for retrieve by zipcode only.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveLatestSalesTaxDateByZipCode()
        {
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            DateTime salesTaxDate = new DateTime(2002, 10, 18);
            SalesTax salesTax = new SalesTax()
            {
                TaxDate = salesTaxDate,
                TaxRate = 0.0025M,
                ZipCode = "1111"
            };

            DateTime anotherSalesTaxDate = transactionManager.RetrieveLatestSalesTaxDateByZipCode(salesTax.ZipCode);

            Assert.AreEqual(salesTax.TaxDate, anotherSalesTaxDate);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This is a unit test for retrieve by id.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveProductByProductID()
        {
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            string productID = "ProductID100";

            ProductVM anotherProductVM;

            anotherProductVM = transactionManager.RetrieveProductByProductID(productID);

            Assert.AreEqual(anotherProductVM.ProductID, productID);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/4/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This is a unit test for retrieve tax rate by date and zipcode.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTaxRateBySalesTaxDateAndZipCode()
        {
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            DateTime salesTaxDate = new DateTime(2002, 10, 18);
            SalesTax salesTax = new SalesTax()
            {
                TaxDate = salesTaxDate,
                TaxRate = 0.0025M,
                ZipCode = "1111"
            };

            decimal anotherTaxRate = transactionManager
                .RetrieveTaxRateBySalesTaxDateAndZipCode(salesTax.ZipCode, salesTax.TaxDate);

            Assert.AreEqual(salesTax.TaxRate, anotherTaxRate);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Test method for retrieving transactions using a transaction date.
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 2020/04/13
        /// Update: Added the second date parameter
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTransactionsByTransactionDate()
        {
            // arrange 
            List<TransactionVM> transactions;
            DateTime transactionDate1 = new DateTime(2010, 10, 18);

            DateTime transactionDate2 = new DateTime(2011, 11, 19);

            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);
            // Act
            transactions = transactionManager.RetrieveTransactionByTransactionDate(transactionDate1, transactionDate2);

            // assert
            Assert.AreEqual(2, transactions.Count);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 3/08/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Test method for retreiving transactions by employee name.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTransactionByEmployeeName()
        {
            //arrange
            List<TransactionVM> transactions;
            string firstName = "Bob";
            string lastName = "Jones";
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            // Act
            transactions = transactionManager.RetrieveTransactionByEmployeeName(firstName, lastName);

            // assert
            Assert.AreEqual(1, transactions.Count);

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        /// 
        /// Test method for retreiving transactions by transaction id.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveTransactionByTransactionID()
        {
            //arrange
            List<TransactionVM> transactions;
            int transactionID = 1000;
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            // Act
            transactions = transactionManager.RetrieveTransactionByTransactionID(transactionID);

            // assert
            Assert.AreEqual(1, transactions.Count);

        }

        /// <summary>
        ///  Creator: Rasha Mohammed
        ///  Created: 4/12/2020
        ///  Approver: Robert Holmes
        ///  
        ///  Test method for edit product priceon transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditProductPrice()
        {
            // arrange, the attribute that need
            ProductVM oldProduct = new ProductVM();
            ProductVM newProduct = new ProductVM();
            bool result = false;
            bool expected = true;

            //act

            oldProduct.Price = 0.50M;


            newProduct.Price = 10.00M;


            result = _transactionManager.EditProduct(oldProduct, newProduct);


            // Assert
            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/24/2020
        /// Approver: Robert Holmes
        /// 
        /// This is a unit test for retrieve all transaction types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllTransactionTypes()
        {

            // arrrange
            List<TransactionType> transactionTypes = new List<TransactionType>();
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            // act
            transactionTypes = transactionManager.RetrieveAllTransactionTypes();

            // assert
            Assert.AreEqual(3, transactionTypes.Count);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/24/2020
        /// Approver: Robert Holmes
        /// 
        /// This is a unit test for retrieve all transaction statuses
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllTransactionStatus()
        {

            // arrrange
            List<TransactionStatus> transactionStatuses = new List<TransactionStatus>();
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            // act
            transactionStatuses = transactionManager.RetrieveAllTransactionStatus();

            // assert
            Assert.AreEqual(4, transactionStatuses.Count);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// Test method for retreiving the deafult transaction type.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveDefaultTransactionType()
        {
            //arrange
            var transactionType = new TransactionType();

            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            // Act
            transactionType = transactionManager.RetrieveDefaultTransactionType();

            // assert
            Assert.AreEqual(true, transactionType.DefaultInStore);

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// Test method for retreiving the deafult transaction status.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveDefaultTransactionStatus()
        {
            //arrange
            var transactionStatus = new TransactionStatus();

            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            // Act
            transactionStatus = transactionManager.RetrieveDefaultTransactionStatus();

            // assert
            Assert.AreEqual(true, transactionStatus.DefaultInStore);

        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 4/25/2020
        ///  Approver: Robert Holmes
        ///  
        /// Test method for edit item quantity.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditItemQuantity()
        {
            // arrange, the attribute that need
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);

            bool result = false;
            bool expected = true;

            TransactionLineProducts transactionLineProducts = new TransactionLineProducts();
            List<ProductVM> _productsSold = new List<ProductVM>();

            var productVM1 = new ProductVM();
            productVM1.ItemID = 100;
            productVM1.ItemQuantity = 5;

            var productVM2 = new ProductVM();
            productVM2.ItemID = 200;
            productVM2.ItemQuantity = 10;

            _productsSold.Add(productVM1);
            _productsSold.Add(productVM2);

            transactionLineProducts.ProductsSold = _productsSold;


            //act
            result = _transactionManager.EditItemQuantity(transactionLineProducts);


            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestGetTransactionByEmail()
        {
            ITransactionManager transactionManager = new TransactionManager(_transactionAccessor);
            int expected = 1;

            var result = _transactionManager.GetTransactionsByCustomerEmail("test@test.com");

            Assert.AreEqual(expected, result.Count);

        }
    }
}
