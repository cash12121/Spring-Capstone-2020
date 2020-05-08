/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/9
///  APPROVER: Lane Sandburg
///  
///  ScheduleChangeRequest Data Transfer Object View Model
/// </summary>
namespace DataTransferObjects
{
    public class ScheduleChangeRequestVM
    {
        public int ScheduleChangeRequestID { get; set; }

        public int ShiftID { get; set; }

        public int EmployeeWorking { get; set; }

        public string EmployeeWorkingEmail { get; set; }

        public string DepartmentID { get; set; }

        public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string ApprovalDate { get; set; }

        public int ApprovingUserID { get; set; }

        public int RequestID { get; set; }

        public string Role { get; set; }
    }
}
