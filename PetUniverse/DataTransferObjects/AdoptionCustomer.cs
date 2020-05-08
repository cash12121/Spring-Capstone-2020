namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 3/15/2020
    ///
    /// This data object matching the customer Data who fill adoption Application
    /// </summary>
    public class AdoptionCustomer
    {
        public string CustomerEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public bool Active { get; set; }
    }
}
