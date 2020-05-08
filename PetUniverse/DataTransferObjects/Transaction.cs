using System;
using System.Collections.Generic;

namespace DataTransferObjects
{
    /// <summary>
    ///  Creator: Jaeho Kim
    ///  Created: 2020/02/27
    ///  Approver: Rasha Mohammed
    ///  
    ///  Transaction Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Updated by: Robert Holmes
    /// Updated on: 03/03/2020
    /// Changes: Added ProductAmounts, Date, Status, and Type fields and constructor.
    /// 
    /// Updater: Robert Holmes
    /// Updated on: 04/21/2020
    /// Update: Added CustomerEmail and SwipeChargeID
    /// 
    /// Updater: Jaeho Kim
    /// Updated on: 04/26/2020
    /// Update: Added tax exempt property
    /// </remarks>
    public class Transaction
    {

        public Dictionary<Product, int> ProductAmounts { get; set; }


        public int TransactionID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal TaxRate { get; set; }
        public decimal SubTotalTaxable { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string TransactionTypeID { get; set; }
        public int EmployeeID { get; set; }
        public string TransactionStatusID { get; set; }
        public string CustomerEmail { get; set; }
        public string StripeChargeID { get; set; }
        public string TaxExemptNumber { get; set; }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Initiates transaction with a not null empty dictionary of products and ints.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public Transaction()
        {
            ProductAmounts = new Dictionary<Product, int>();
        }
    }
}
