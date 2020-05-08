using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/7/2020
    /// Approver: Carl Davis 2/14/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// 
    /// A data object for animal vet appointments
    /// </summary>
    public class AnimalVetAppointment
    {
        public int VetAppointmentID { get; set; }
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public int UserID { get; set; }
        public DateTime? FollowUpDateTime { get; set; }
        public bool Active { get; set; }
        public string AppointmentDescription { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string ClinicAddress { get; set; }
        public string VetName { get; set; }
    }
}
