using System;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Ethan Holmes
    /// DATE: 2/6/2020
    /// APPROVER: Josh Jackson, Timothy Licktieg
    /// 
    /// This is the object definition for the VolunteerTask Object.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public class VolunteerTask
    {
        public int VolunteerTaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public string AssignmentGroup { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
    }
}
