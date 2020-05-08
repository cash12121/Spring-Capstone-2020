using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPFPresentation.Models
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: Jaeho Kim
    /// 
    /// Holds an assorment of data necessary from completing the transaction.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class CompleteCheckoutViewModel
    {
        public OrderDetails OrderDetails { get; set; }
        public Cart Cart { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
    }
}