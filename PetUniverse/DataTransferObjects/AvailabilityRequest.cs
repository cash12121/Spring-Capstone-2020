using System;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/3/15
///  APPROVER: Lane Sandburg
///  
///  Request Data Transfer Object
/// </summary>

namespace DataTransferObjects
{
    public class AvailabilityRequest
    {
        public int AvailabilityRequestID { get; set; }

        public string SundayStartTime { get; set; }

        public string SundayEndTime { get; set; }

        public string MondayStartTime { get; set; }

        public string MondayEndTime { get; set; }

        public string TuesdayStartTime { get; set; }

        public string TuesdayEndTime { get; set; }

        public string WednesdayStartTime { get; set; }

        public string WednesdayEndTime { get; set; }

        public string ThursdayStartTime { get; set; }

        public string ThursdayEndTime { get; set; }

        public string FridayStartTime { get; set; }

        public string FridayEndTime { get; set; }

        public string SaturdayStartTime { get; set; }

        public string SaturdayEndTime { get; set; }

        public string ApprovalDate { get; set; }

        public int ApprovingUserID { get; set; }

        public int RequestID { get; set; }
    }
}
