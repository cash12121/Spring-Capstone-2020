using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/20/2020
    /// Approver: Jaeho Kim
    /// 
    /// Simple DTO to hold amount remaining on a transaction.
    /// </summary>
    public class AmountDue
    {
        public decimal Amount { get; set; }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Constructs object with an amount.
        /// </summary>
        /// <param name="amount"></param>
        public AmountDue(decimal amount)
        {
            Amount = amount;
        }
    }
}
