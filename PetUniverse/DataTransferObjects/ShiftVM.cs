/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Data Transfer Object built to hold details for a specific shift (combined with ShiftTime)
/// </summary>
namespace DataTransferObjects
{
    public class ShiftVM
    {
        public int ShiftID { get; set; }

        public int EmployeeWorking { get; set; }

        public string Department { get; set; }

        public string Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int ShiftTimeID { get; set; }
    }
}
