namespace DataTransferObjects
{
    /// <summary>
    /// 
    /// Created By: Ryan Morganti
    /// Date: 2020/04/04
    /// Checked By: Matt Deaton
    /// 
    /// DTO for a Donor object: to track individuals who have made donations to the PetUniverse Shelter
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public class Donor
    {
        public int DonorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
