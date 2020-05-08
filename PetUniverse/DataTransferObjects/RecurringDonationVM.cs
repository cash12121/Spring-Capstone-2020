using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    ///  Creator: Ryan Morganti
    ///  Created: 2020/04/16
    ///  Approver: Derek Taylor
    ///  
    ///  Recurring Donation Info VM : This collects all the payment properties when
    ///  setting up a recurring donation and sets validation limits on them.
    /// </summary>
    public class RecurringDonationVM : RecurringDonation
    {
        public string IntervalVM { get; set; }
        [Required]
        [Display(Name = "Name on Card")]
        public string BillingName { get; set; }
        [Display(Name = "Credit Card")]
        [Required(ErrorMessage = "CONTACT_NUMBER Required!")]
        // https://stackoverflow.com/a/9315696
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$",
            ErrorMessage = "Entered card number is not in valid format.")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name = "Exp (MM/YY)")]
        [RegularExpression(@"^((0[1-9])|(1[0-2]))[\/\.\-]*((2[0-9]))$",
            ErrorMessage = "Date is not in valid format")]
        public string ExpirationDate { get; set; }
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        // found a ZipCode Regex for data annotation
        // https://stackoverflow.com/a/16675193
        [Required(ErrorMessage = "Zip is Required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
