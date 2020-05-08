using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE:3/12/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: Dalton Reierson
    /// 
    /// Fake Order class for testing
    /// </summary>
    public class FakeOrderAccessor
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver:  Dalton Reierson
        /// 
        /// This is a list of orders
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private List<Order> orders;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This method returns a fake list of Ordersfor testing
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <returns>
        /// IEnumerable<OrderInvoice> The list of Order Invoices
        /// </returns>
        public IEnumerable<Order> SelectOrders()
        {
            orders = new List<Order>() {
                new Order()
                {
                    OrderID = 1,
                    UserID = 100000
                }
            };
            return (IEnumerable<Order>)orders;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the method used to test updating the fake orders 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="oldOrderInvoice">The old invoice to be changed</param>
        /// <param name="newOrderInvoice">The invoice with the new values</param>
        /// <returns></returns>
        public int UpdateOrder(Order oldOrder, Order newOrder)
        {
            int result = 0;

            if (!oldOrder.Equals(newOrder))
            {
                oldOrder.OrderID = newOrder.OrderID;
                oldOrder.UserID = newOrder.UserID;
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the method used to test inserting a new order to the list
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="newOrderInvoice">The new invoice to be added</param>
        /// <returns></returns>
        public int InsertOrder(Order newOrder)
        {
            int result = 0;
            FakeOrderAccessor fakeOrderAccessor = new FakeOrderAccessor();
            IEnumerable<Order> orders = fakeOrderAccessor.SelectOrders();
            List<Order> invoiceList = orders.ToList();
            if (!invoiceList.Contains(newOrder))
            {
                invoiceList.Add(newOrder);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the method used to test deleting an order from the list 
        /// </summary>
        /// <param name="orderInvoiceID">The ID of the invoice to be deleted</param>
        /// <returns></returns>
        public int DeleteOrder(int orderID)
        {
            int result = 0;
            FakeOrderAccessor fakeOrderAccessor = new FakeOrderAccessor();
            IEnumerable<Order> orders = fakeOrderAccessor.SelectOrders();
            List<Order> invoiceList = orders.ToList();

            foreach (Order order in orders)
            {
                if (order.OrderID.Equals(orderID))
                {
                    invoiceList.Remove(order);
                    result = 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/23
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Method to update an orders orderStatus
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int UpdateOrderStatus(Order order, string orderStatus)
        {
            int results = 0;

            try
            {
                order.OrderStatus = orderStatus;
                results = 1;
            }
            catch (Exception)
            {
                throw;
            }
            return results;
        }
    }
}
