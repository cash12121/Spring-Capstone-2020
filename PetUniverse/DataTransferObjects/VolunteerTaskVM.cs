namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Ethan Holmes
    /// DATE: 2/6/2020
    /// APPROVER: Josh Jackson, Timothy Licktieg
    /// 
    /// This is the VolunteerTaskVM object which returns the contents
    /// of the VolunteerTask excluding the VolunteerTaskID
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public class VolunteerTaskVM
    {
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public string AssignmentGroup { get; set; }
        public string TaskDescription { get; set; }
        public string DueDate { get; set; }
    }
}
