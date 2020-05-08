using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 03/19/2020
    /// Approver: Michael Thompson
    /// 
    /// This data object class is used as a reference to an appointment object and the location of the appointment
    /// </summary>
    public class AppointmentLocationVM : Appointment
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string LocationName { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string LocationAddress1 { get; set; }

        [DefaultValue("")]
        public string LocationAddress2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string LocationCity { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string LocationState { get; set; }

        [Required(ErrorMessage = "Please enter a zip code")]
        public string LocationZip { get; set; }
    }
}