using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jesse Tomash
    /// Created: 3/30/2020    
    /// Approver: Brandyn T. Coverdill
    /// 
    /// This is the interface for order accessor
    /// </summary>
    public interface ISpecialOrderAccessor
    {

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface method for selecting all orders
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        IEnumerable<SpecialOrder> SelectSpecialOrders();

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface  method for updating an order
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        /// <param name="oldOrder"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int UpdateSpecialOrder(SpecialOrder oldOrder, SpecialOrder newOrder);

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface method to insert an order
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: (example: Fixed a problem when user inputs bad data)
        /// </remarks>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int InsertSpecialOrder(SpecialOrder newOrder);

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// This is the interface method to delete an order
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="orderID"></param>
        /// <returns></returns>
        int DeleteSpecialOrder(int orderID);
    }
}
