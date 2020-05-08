using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    ///
    /// This Class for creating  the properties of Home Inspector Adoption Appointment Decision.
    /// </summary>
    public class HomeInspectorAdoptionAppointmentDecision
    {
        public int AppointmentID { get; set; }
        public int AdoptionApplicationID { get; set; }
        public string LocationName { get; set; }
        public string AppointmentTypeID { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }
        public string Decision { get; set; }
        public int LocationID { get; set; }
        public bool Active { get; set; }
    }
}
