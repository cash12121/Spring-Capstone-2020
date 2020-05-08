namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/13/2020
    /// Approver: Michael Thompson
    /// 
    /// Location data transfer object class
    /// </summary>
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
