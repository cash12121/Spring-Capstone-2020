using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
	/// Creator: Timothy Lickteig
	/// Date: 04/27/2020
	/// Approver: Zoey McDonald
	///
	/// foster appointment dto
    /// Updater: 
    /// Updated: 
    /// Update:     
	/// </summary>
    public class FosterAppointment
    {
        public int VolunteerID { get; set; }
        public int FosterAppointmentID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
    }
}
