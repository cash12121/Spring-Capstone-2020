namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2/14/2020
    /// Approver: Cash Carlson
    /// 
    /// Holds data relevant to a Product.
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020
    /// Update: Removed duplicate fields with sligtly different names.
    /// </remarks>
    public class Product
    {
        public string ProductID { get; set; }
        public int ItemID { get; set; }
        public bool Taxable { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2/21/2020
        /// Approver: Cash Carlson
        /// 
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public Product()
        {

        }
    }
}
