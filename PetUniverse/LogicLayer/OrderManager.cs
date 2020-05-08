using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/12/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: Dalton Reierson
    /// 
    /// This is the class for handling logic for Orders
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public class OrderManager : IOrderManager
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the instance of orderAccessor used in this class
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private IOrderAccessor _orderAccessor;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the default manager constructor that receives the fake orderaccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public OrderManager()
        {
            _orderAccessor = new DataAccessLayer.OrderAccessor();
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the constructor that receives the real orderaccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="orderAccessor"></param>
        public OrderManager(IOrderAccessor orderInvoiceAccessor)
        {
            _orderAccessor = orderInvoiceAccessor;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the method that handles logic between SelectOrders() and the presentation
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        public IEnumerable<Order> RetrieveOrders()
        {
            {
                IEnumerable<Order> orderInvoices;

                try
                {
                    orderInvoices = _orderAccessor.SelectOrders();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return orderInvoices;
            }
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the method that handles logic between UpdateOrder() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="oldOrder"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public bool EditOrder(Order oldOrder, Order newOrder)
        {
            bool result = false;

            try
            {
                result = (1 == _orderAccessor.UpdateOrder(oldOrder, newOrder));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the method that handles logic between InsertOrder() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: Made sure that it gave a better error message instead of throwing ex.
        /// </remarks>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public bool AddOrder(Order newOrder)
        {
            bool result;

            try
            {
                result = (1 == _orderAccessor.InsertOrder(newOrder));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Order Failed.");
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// edits order status
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool EditOrderStatus(Order order, string orderStatus)
        {
            bool result = true;
            try
            {
                result = (1 == _orderAccessor.UpdateOrderStatus(order, orderStatus));
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/7/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// This is the method that handles logic between DeleteOrder() and the presentation
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/28/2020
        /// WHAT WAS CHANGED: Made sure that it gave a better error message instead of throwing ex.
        /// </remarks>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool DeleteOrder(int orderID)
        {
            bool result = true;
            try
            {
                result = _orderAccessor.DeleteOrder(orderID);
            }
            catch (Exception ex)
            {

                // throw new ApplicationException("Delete Order Failed.");
                throw ex;
            }

            return result;
        }
    }
}
