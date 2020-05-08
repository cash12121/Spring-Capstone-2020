using System;
using System.Collections.Generic;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Holds relevent information about a promotion.
    /// </summary>
    public class Promotion
    {
        public string PromotionID { get; set; }
        public string PromotionTypeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public bool Active { get; set; }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Default constructor
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// 
        /// </remarks>
        public Promotion()
        {
            Products = new List<Product>();
        }
    }
}
