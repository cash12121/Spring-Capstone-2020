using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: 
    /// Approver: 
    ///
    /// ReceivingRecord Object
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class ReceivingRecord
    {
        public int ReceivingRecordID { get; set; }
        public int OrderID { get; set; }
        public string ShipperID { get; set; }
        public DateTime ReceivingOrderDate { get; set; }

    }
}
