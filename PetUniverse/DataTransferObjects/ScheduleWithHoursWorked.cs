using System;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Data Transfer Object built to hold a Schedule's start and end dates, along with First week and Second week hours worked
/// </summary>
namespace DataTransferObjects
{
    public class ScheduleWithHoursWorked
    {
        public int ScheduleID { get; set; }

        public DateTime ScheduleStartDate { get; set; }

        public DateTime ScheduleEndDate { get; set; }

        public double FirstWeekHours { get; set; }

        public double SecondWeekHours { get; set; }
    }
}
