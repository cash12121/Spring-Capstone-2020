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
    ///  Recurring Donation Info DTO
    /// </summary>
    public class RecurringDonation
    {
        public int RecurringDonationID { get; set; }
        public string UserName { get; set; }
        public int DonorID { get; set; }
        [Required]
        [Display(Name = "Donation Amount")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter positive donation amount")]
        public decimal DonationAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "A donation interval must be selected")]
        public int Interval { get; set; }
        public bool Active { get; set; }
    }
}
