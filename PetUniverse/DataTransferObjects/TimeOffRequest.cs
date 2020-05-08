using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    /// <summary>
    ///  CREATOR: Kaleb Bachert
    ///  CREATED: 2020/3/5
    ///  APPROVER: Lane Sandburg
    ///  
    ///  TimeOffRequest Data Transfer Object
    /// </summary>
    public class TimeOffRequest
    {
        public int TimeOffRequestID { get; set; }

        [Required]
        public DateTime EffectiveStart { get; set; }

        [Required]
        public DateTime EffectiveEnd { get; set; }

        public DateTime ApprovalDate { get; set; }

        public int ApprovingUserID { get; set; }

        public int RequestID { get; set; }
    }
}
