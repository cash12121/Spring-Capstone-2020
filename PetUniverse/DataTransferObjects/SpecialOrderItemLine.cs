using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jesse Tomash
    /// Created: 4/26/2020
    /// Approver:
    ///
    /// the data transfer object for orderitem line
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    /// </summary>
    public class SpecialOrderItemLine
    {
        public int SpecialOrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
}
