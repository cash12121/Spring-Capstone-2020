using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/30/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    /// 
    /// The Interface for the ordermanager Class
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public interface ISpecialOrderManager
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// The interface method for the method to retrieve all orders
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        IEnumerable<SpecialOrder> RetrieveSpecialOrders();
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
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
        bool EditSpecialOrder(SpecialOrder oldOrderInvoice, SpecialOrder newOrderInvoice);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
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
        bool AddSpecialOrder(SpecialOrder newOrderInvoice);
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
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
        bool DeleteSpecialOrder(int orderInvoiceID);
    }
}
