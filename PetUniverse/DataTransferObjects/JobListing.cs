namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ryan Morganti
    /// Created: 2020/03/19
    /// Approver:Derek Taylor
    /// 
    /// Class for storing JobListing data pulled from the data store
    /// </summary>
    public class JobListing
    {
        public int JobListingID { get; set; }
        public string Position { get; set; }
        public string RoleID { get; set; }
        public string Benefits { get; set; }
        public string Requirements { get; set; }
        public decimal StartingWage { get; set; }
        public string Responsibilities { get; set; }
        public bool Active { get; set; }
    }
}
