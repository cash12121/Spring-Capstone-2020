using DataAccessFakes;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    ///  
    /// Unit testing Class for Transaction Admin
    /// </summary>
    [TestClass]
    public class TransactionAdminTests
    {

        private FakeTransactionAdminAccessor _fakeTransactionAdminAccessor;

        public TransactionAdminTests()
        {
            _fakeTransactionAdminAccessor = new FakeTransactionAdminAccessor();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Tests AddTransactionType
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestTransactionAdminManagerInsertTransactionType()
        {
            // arrange
            var transactionType = new TransactionType()
            {
                TransactionTypeID = "FakeTransactionTypeID",
                Description = "FakeDescTransactionType",
                DefaultInStore = false
            };
            FakeTransactionAdminAccessor _transactionAdminAccessor = new FakeTransactionAdminAccessor();

            // act
            bool result = _transactionAdminAccessor.InsertTransactionType(transactionType) == 1;

            // assert
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Tests AddTransactionStatus
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestTransactionAdminManagerInsertTransactionStatus()
        {
            // arrange
            var transactionStatus = new TransactionStatus()
            {
                TransactionStatusID = "FakeTransactionStatusID1000",
                Description = "FakeDescTransactionStatus10000",
                DefaultInStore = false
            };
            FakeTransactionAdminAccessor _transactionAdminAccessor = new FakeTransactionAdminAccessor();

            // act
            bool result = _transactionAdminAccessor.InsertTransactionStatus(transactionStatus) == 1;

            // assert
            Assert.AreEqual(result, true);
        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 4/29/2020
        ///  Approver: NA
        ///  
        /// Test method for edit transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditTransactionType()
        {
            // arrange, the attribute that need
            TransactionType oldTransactionType = new TransactionType();
            TransactionType newTransactionType = new TransactionType();
            int result = 0;
            int expected = 1;

            //act
            oldTransactionType.TransactionTypeID = "FAKEID1";
            oldTransactionType.Description = "FakeDesc1";
            oldTransactionType.DefaultInStore = true;


            newTransactionType.TransactionTypeID = "NEWFAKE1";
            newTransactionType.Description = "NEWFAKEDESC1";
            newTransactionType.DefaultInStore = false;


            result = _fakeTransactionAdminAccessor.UpdateTransactionType(oldTransactionType, newTransactionType);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        ///  Creator: Jaeho Kim
        ///  Created: 4/29/2020
        ///  Approver: NA
        ///  
        /// Test method for edit transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestEditTransactionStatus()
        {
            // arrange, the attribute that need
            TransactionStatus oldTransactionStatus = new TransactionStatus();
            TransactionStatus newTransactionStatus = new TransactionStatus();
            int result = 0;
            int expected = 1;

            //act
            oldTransactionStatus.TransactionStatusID = "FAKESTATUSID1";
            oldTransactionStatus.Description = "FakeDesc1";
            oldTransactionStatus.DefaultInStore = true;


            newTransactionStatus.TransactionStatusID = "NEWFAKE1";
            newTransactionStatus.Description = "NEWFAKEDESC1";
            newTransactionStatus.DefaultInStore = false;


            result = _fakeTransactionAdminAccessor.UpdateTransactionStatus(oldTransactionStatus, newTransactionStatus);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Test Method for deleting trans types
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteTransactionType()
        {
            // Arrange
            int result = 0;

            // Act
            result = _fakeTransactionAdminAccessor.DeleteTransactionType("FAKEID1");

            // Assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Test Method for deleting trans status
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteTransactionStatus()
        {
            // Arrange
            int result = 0;

            // Act
            result = _fakeTransactionAdminAccessor.DeleteTransactionStatus("FAKESTATUSID1");

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
