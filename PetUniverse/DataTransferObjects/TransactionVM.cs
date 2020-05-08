namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2/27/20
    /// Approver: Rasha Mohammed
    /// This is the TransactionVM object in which the End User 
    /// will see. It contains data that the end user can understand.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update: 
    /// </remarks>
    public class TransactionVM : Transaction
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //View Model Details:
        public int Quantity { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryID { get; set; }
        public string ProductTypeID { get; set; }
        public decimal Price { get; set; }
    }
}
