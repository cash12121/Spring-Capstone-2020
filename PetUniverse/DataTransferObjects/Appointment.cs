using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 02/06/2020
    /// Approver: Awaab Elamin
    /// 
    /// This data object class is used as a reference to an appointment object
    /// </summary>
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int AdoptionApplicationID { get; set; }
        public string AppointmentTypeID { get; set; }

        [Required(ErrorMessage = "Please pick a date and time")]
        public DateTime DateTime { get; set; }

        public string Notes { get; set; }
        public string Decicion { get; set; }
        public int LocationID { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}