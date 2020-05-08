using System;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/2
///  APPROVER: Lane Sandburg
///  
///  Active Time Off (for approved Time Off Requests) Data Transfer Object
/// </summary>

namespace DataTransferObjects
{
    public class ActiveTimeOff
    {
        public int TimeOffID { get; set; }

        public int UserID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
