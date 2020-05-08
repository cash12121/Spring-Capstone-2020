using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/20
    /// Approver: Ryan Morganti
    /// 
    /// This class is a representation of an Applicant Record
    /// </summary>
    /// <remarks>
    /// Updater: Matt Deaton
    /// Updated: 2020-0407
    /// Update: Added the Foster bool field, along with all the Data Annotations for all 
    /// fields to be used in the MVCPresentationLayer
    /// 
    /// </remarks>
    public class Applicant
    {
        public int ApplicantID { get; set; }

        [Required(ErrorMessage = "You must enter a First Name.")]
        [MaxLength(50, ErrorMessage = "This field may not be longer than 50 characters.")]
        [Display(Name = "*First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a Last Name.")]
        [MaxLength(50, ErrorMessage = "This field may not be longer than 50 characters.")]
        [Display(Name = "*Last Name:")]
        public string LastName { get; set; }

        // Middle Name not Required
        [Display(Name = "Middle Name:")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "You must enter an Email.")]
        [MaxLength(250, ErrorMessage = "This field may not be longer than 50 characters.")]
        [Display(Name = "*Email Address:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a Phone Number.")]
        [MaxLength(11, ErrorMessage = "This field may not be longer than 11 characters.")]
        [Display(Name = "*Phone Number:")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "You must enter a Address.")]
        [MaxLength(100, ErrorMessage = "This field may not be longer than 100 characters.")]
        [Display(Name = "*Address Line 1:")]
        public string AddressLineOne { get; set; }

        // Address Line 2 not Required
        [Display(Name = "Address Line 2:")]
        public string AddressLineTwo { get; set; }

        [Required(ErrorMessage = "You must enter a City.")]
        [MaxLength(100, ErrorMessage = "This field may not be longer than 100 characters.")]
        [Display(Name = "*City:")]
        public string City { get; set; }

        // Required, will have a drop down so can't be left empty
        [MaxLength(2, ErrorMessage = "This field may not be longer than 2 characters.")]
        [Display(Name = "*State:")]
        public string State { get; set; }

        [Required(ErrorMessage = "You must enter a Zip Code.")]
        [MaxLength(12, ErrorMessage = "This field may not be longer than 12 characters.")]
        [Display(Name = "*Zip Code:")]
        public string Zipcode { get; set; }

        // Foster not required for default applicant, default is set to 0
        [Display(Name = "Foster Applicant:")]
        public bool Foster { get; set; }

        // Used for showing HR what the current status of an applicant.
        public string ApplicantStatus { get; set; }

        // Used for showing HR what position was applied for.
        public string ApplicationPostion { get; set; }
    }// End class Applicant 
}
