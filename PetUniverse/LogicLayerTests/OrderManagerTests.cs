using DataAccessFakes;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 2/7/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: Dalton Reierson
    /// 
    /// This is the Test class for OrderManager
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    [TestClass]
    public class OrderManagerTests
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// Tests RetrieveOrders
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void RetrieveOrderTest()
        {
            bool result = false;

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.SelectOrders().Any();

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// Tests EditORder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void EditOrderTest()
        {
            bool result = false;

            Order oldOrder = new Order()
            {
                OrderID = 1,
                UserID = 100000
            };

            Order editedOrder = new Order()
            {
                OrderID = 2,
                UserID = 100000
            };

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.UpdateOrder(oldOrder, editedOrder) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// Tests AddOrder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void AddOrderTest()
        {
            bool result = false;

            Order newOrder = new Order()
            {
                UserID = 100000
            };

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.InsertOrder(newOrder) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// Tests DeleteOrder
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        [TestMethod]
        public void DeleteOrderTest()
        {
            bool result = false;

            Order newOrder = new Order()
            {
                OrderID = 1,
                UserID = 100000
            };

            FakeOrderAccessor _orderAccessor = new FakeOrderAccessor();

            result = _orderAccessor.DeleteOrder(newOrder.OrderID) == 1;

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/23
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Update orderStatus test
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void UpdateOrderStatus()
        {
            // Arrange
            int result = 0;
            int expectedResult = 1;
            FakeOrderAccessor orderAccessor = new FakeOrderAccessor();
            Order order = new Order();
            order.OrderID = 10000;
            order.UserID= 100000;
            order.Active = true;
            order.OrderStatus = "original";
            string newOrderStatus = "new";

            // Act 
            result = orderAccessor.UpdateOrderStatus(order, newOrderStatus);

            // Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}
