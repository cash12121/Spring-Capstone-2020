namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/12/2020
    /// Approver: Chase Schulte
    /// 
    /// This is a data transfer object for BaseScheduleLine.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class BaseScheduleLine
    {
        public string ERoleID { get; set; }
        public int BaseScheduleID { get; set; }
        public int ShiftTimeID { get; set; }
        public string DepartmentID { get; set; }

        // A count with a default value of 0. To be set by the user 
        // to represent the number of employees needed for the role.
        public int Count { get; set; }
    }
}
