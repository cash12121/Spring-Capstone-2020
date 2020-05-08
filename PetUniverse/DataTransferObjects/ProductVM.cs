namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/21
    /// Approver: Cash Carlson
    /// 
    /// Holds the values of interest for display in a datagrid.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class ProductVM : Product
    {

        // The item quantity column that's part of the 
        // Item Table. This represents the name of the 
        // product or item (to be specific).
        public string ItemName { get; set; }

        // The item quantity column that's part of the 
        // Item Table. This represents the quantity 
        // that's in stock.
        public int ItemQuantity { get; set; }

        // The quantity is the number of products the 
        // customer wishes to purchase. It cannot 
        // exceed the item quantity.
        public int Quantity { get; set; }

        // The item quantity column that's part of the 
        // Item Table. This represents the description 
        // of the item.
        public string ItemDescription { get; set; }


        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver:  Cash Carlson
        /// 
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public ProductVM() { }

    }
}
