using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/19 
    ///
    /// This Class for creating  the properties of Customer.
    /// </summary>
    public class Customer
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Please supply a first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please supply a last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please supply a phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Supply an Address")]
        [Display(Name = "Address Line One")]
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        [Required(ErrorMessage = "Please supply a city.")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please supply a state.")]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please supply a Zip code.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public bool Active { get; set; }
    }
}
