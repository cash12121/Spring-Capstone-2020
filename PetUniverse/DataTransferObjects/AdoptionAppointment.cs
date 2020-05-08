using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/7/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This is a data transfer object used for accessing Adoption
    /// appointment data in the database.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionAppointment
    {
        public int AppointmentID { get; set; }
        public string LocationName { get; set; }
        public int AdoptionApplicationID { get; set; }
        [Display(Name = "Appointment Type")]
        public string AppointmentTypeID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Notes { get; set; }
        public string Decision { get; set; }
        public int LocationID { get; set; }
        public bool AppointmentActive { get; set; }
    }
}
