using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPFPresentation.Models
{
    /// <summary>
    /// /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: Jaeho Kim
    /// 
    /// Simple class for holding the cart and return url.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update:
    /// </remarks>
    /// </summary>
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}