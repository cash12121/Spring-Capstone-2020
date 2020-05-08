using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Interface for orderLine accessor
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: Dalton Reierson 
    /// Updated: 4/29/20
    /// Update: Added CRUD functions
    /// </remarks>
    public interface IOrderLineAccessor
    {
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Method to select orderline by receiving record id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<OrderLine> SelectOrderLineByReceivingRecordID(int ReceivingRecordID);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// method to update orderLine
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        int UpdateOrderLine(OrderLine oldOrderLine, OrderLine newOrderLine);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/28
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// Method to create an orderLine
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks
        bool createOrderLine(OrderLine orderLine);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/28
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// Method to delete an orderLine
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks
        bool deleteOrderLine(OrderLine orderLine);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/28
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// Method to select all orderLines
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        List<OrderLine> selectAllOrderLines();
    }
}
