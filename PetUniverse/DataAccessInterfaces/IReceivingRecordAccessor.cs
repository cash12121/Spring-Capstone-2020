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
    /// Approver: 
    /// Approver: 
    ///
    /// interface for receiving record Accessor
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public interface IReceivingRecordAccessor
    {
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: 
        /// Approver: 
        ///
        /// Selects all receiving records
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<ReceivingRecord> SelectAllReceivingRecords();

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: 
        /// Approver: 
        ///
        /// selects receiving record by order id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        ReceivingRecord SelectReceivingRecordbyOrderID(int OrderID);
    }
}
