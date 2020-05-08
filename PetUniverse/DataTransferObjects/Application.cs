using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: Micheal Thompson
    /// 
    /// Contains all the information needed for an adoption Application
    /// </summary>
    public class Application
    {
        [Display(Name = "Adoption Application ID")]
        public int AdoptionApplicationID { get; set; }
        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }
        [Display(Name = "Animal ID")]
        public int AnimalID { get; set; }
        [Display(Name = "Adoption Satus")]
        public string Status { get; set; }
        [Display(Name = "Application Recieved on")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RecievedDate { get; set; }
        [Display(Name = "Application Active")]
        public bool ApplicationActive { get; set; }
    }
}
