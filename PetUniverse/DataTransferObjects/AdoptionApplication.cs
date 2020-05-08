using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    ///
    /// This Class for creating  the properties of Adoption Applications.
    /// </summary>
    public class AdoptionApplication
    {
        [Required]
        public int AdoptionApplicationID { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string AnimalName { get; set; }

        public int AnimalID { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime RecievedDate { get; set; }
        [Required]
        public List<CustomerQuestionnar> qusetionnair { get; set; }
    }
}
