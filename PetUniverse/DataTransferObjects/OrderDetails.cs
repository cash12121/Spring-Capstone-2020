using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 04/29/2020
    /// Approver: Jaeho Kim
    /// 
    /// Holds all relevent data for an order and server side validation.
    /// </summary>
    /// <remarks>
    /// Updater: 
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class OrderDetails
    {
        [Required(ErrorMessage = "Please enter a valid name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please enter a valid phone number")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Please enter an email address")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter an address")]
        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; }
        [Required(ErrorMessage = "Please Enter a city")]
        public string BillingCity { get; set; }
        [Required(ErrorMessage = "Please select a state")]
        public string BillingState { get; set; }
        [Required(ErrorMessage = "Enter a postal code")]
        [RegularExpression(@"/^\d{5}([-]|\s*)?(\d{4})?$/")]
        public string BillingPostalCode { get; set; }
        [Required(ErrorMessage = "Please select a country")]
        public string BillingCountry { get; set; }
        public string ShippingName { get; set; }
        [Phone]
        public string ShippingPhone { get; set; }
        public string ShippingAddressLine1 { get; set; }
        public string ShippingAddressLine2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        [RegularExpression(@"/^\d{5}([-]|\s*)?(\d{4})?$/")]
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        public string StripeChargeID { get; set; }
        public decimal TaxRate { get; set; }
    }
}
