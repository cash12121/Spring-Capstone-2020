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
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// OrderLine Object
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public int ItemID { get; set; }
        public int ReceivingRecordID { get; set; }
        public int DamagedItemQuantity { get; set; }
        public int MissingItemQuantity { get; set; }
    }
}
