using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// 
    /// Created By: Ryan Morganti
    /// Date: 2020/04/04
    /// Checked By: Matt Deaton
    /// 
    /// DTO for a Donation object: to track donations made to the PetUniverse Shelter
    /// Inherits from Donor, to tie an individual to a donation.
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public class Donation : Donor
    {
        public int DonationID { get; set; }
        public string TypeOfDonation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfDonation { get; set; }
        public decimal DonationAmount { get; set; }
    }
}
