using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/12/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: Dalton Reierson
    /// 
    /// The Interface for the ordermanager Class
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public interface IOrderManager
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// The interface method for the method to retrieve all orders
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        IEnumerable<Order> RetrieveOrders();
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// The interface method for the method to edit an order
        /// </summary>
        /// <param name="oldOrderInvoice"></param>
        /// <param name="newOrderInvoice"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool EditOrder(Order oldOrderInvoice, Order newOrderInvoice);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// The interface method for the method to add an order
        /// </summary>
        /// <param name="newOrderInvoice"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool AddOrder(Order newOrderInvoice);
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/23
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Interface method to edit an orders status
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool EditOrderStatus(Order order, string orderStatus);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/12/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// The interface method for the method for deleting an orderr by id
        /// </summary>
        /// <param name="orderInvoiceID"></param>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        bool DeleteOrder(int orderInvoiceID);
    }
}
