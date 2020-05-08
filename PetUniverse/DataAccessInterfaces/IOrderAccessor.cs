using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jesse Tomash
    /// Created: 3/12/2020
    /// Approver: Dalton Rierson
    /// 
    /// This is the interface for order accessor
    /// </summary>
    public interface IOrderAccessor
    {

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface method for selecting all orders
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <returns></returns>
        IEnumerable<Order> SelectOrders();

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface  method for updating an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <param name="oldOrder"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int UpdateOrder(Order oldOrder, Order newOrder);

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface method to insert an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int InsertOrder(Order newOrder);

        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 3/12/2020
        /// Approver: Dalton Rierson
        /// 
        /// This is the interface method to delete an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Update:
        /// Updated:
        /// </remarks>
        /// <param name="orderID"></param>
        /// <returns></returns>
        bool DeleteOrder(int orderID);
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/23
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Interface method to update the orderStatus of an order
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        int UpdateOrderStatus(Order order, string orderStatus);
    }
}