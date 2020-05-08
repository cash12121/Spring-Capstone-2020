using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Interface for orderLineManager
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public interface IOrderLineManager
    {
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Retreives order line by reciving record id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: Jesse Tomash
        /// Update:
        /// </remarks>
        List<OrderLine> RetrieveOrderLineByReceivingRecordID(int ReceivingRecordID);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// updates order line
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
