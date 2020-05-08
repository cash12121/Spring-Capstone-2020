namespace DataTransferObjects
{
    /// <summary>
    /// Name: Cash Carlson
    /// Date: 03/19/2020
    /// Approver: Rob Holmes
    /// 
    /// This is the SalesDataVM object in which the End User 
    /// will see. It contains data that the end user can understand.
    /// </summary>
    public class SalesDataVM
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public int TotalSold { get; set; }
    }
}
