using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessFakes;
using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Tests for order line manager
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    [TestClass]
    public class OrderLineManagerTests
    {
        private FakeOrderLineAccessor _fakeOrderLineAccessor;
        private OrderLineManager _orderLineManager;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Test set up
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeOrderLineAccessor = new FakeOrderLineAccessor();
            _orderLineManager = new OrderLineManager(_fakeOrderLineAccessor);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Test for selecting order line by receving record id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveOrderLineByReceivingRecordID()
        {
            // Arrange 
            List<OrderLine> orderLines = null;
            int expectedCount = 2;

            // Act 
            orderLines = _orderLineManager.RetrieveOrderLineByReceivingRecordID(100000);

            // Assert
            Assert.AreEqual(expectedCount, orderLines.Count);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// test to update order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateOrderLine()
        {
            // Arrange 
            OrderLine oldOrderLine = new OrderLine();
            OrderLine newOrderLine = new OrderLine();
            int expectedRowsAffected = 1;

            newOrderLine.OrderLineID = 100000;
            newOrderLine.ItemID = 100001;
            newOrderLine.ReceivingRecordID = 100002;
            newOrderLine.DamagedItemQuantity = 10;
            newOrderLine.MissingItemQuantity = 11;

            oldOrderLine.OrderLineID = 200000;
            oldOrderLine.ItemID = 200001;
            oldOrderLine.ReceivingRecordID = 200002;
            oldOrderLine.DamagedItemQuantity = 20;
            oldOrderLine.MissingItemQuantity = 21;

            // Act 
            int rowsAffected = _orderLineManager.UpdateOrderLine(newOrderLine, oldOrderLine);

            // Assert
            Assert.AreEqual(rowsAffected, expectedRowsAffected);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test to create order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateOrderLine()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;

            OrderLine orderLine = new OrderLine()
            {
                OrderLineID = 100000,
                ReceivingRecordID = 100000,
                ItemID = 100000,
                MissingItemQuantity = 10,
                DamagedItemQuantity = 10
            };

            // Act
            result = _orderLineManager.createOrderLine(orderLine);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test to delete order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteOrderLine()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;

            OrderLine orderLine = new OrderLine()
            {
                OrderLineID = 100000,
                ReceivingRecordID = 100000,
                ItemID = 100000,
                MissingItemQuantity = 10,
                DamagedItemQuantity = 10
            };

            // Act
            result = _orderLineManager.deleteOrderLine(orderLine);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test to select all order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestSelectAllOrderLines()
        {
            // Arrange
            List<OrderLine> orderLines = new List<OrderLine>();
            int expectedResult = 2;
            int result = 0;

            // Act
            orderLines = _orderLineManager.selectAllOrderLines();
            result = orderLines.Count;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Test clean up
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeOrderLineAccessor = null;
            _orderLineManager = null;

        }
    }
}
