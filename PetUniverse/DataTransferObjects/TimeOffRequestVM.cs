namespace DataTransferObjects
{
    /// <summary>
    ///  CREATOR: Kaleb Bachert
    ///  CREATED: 2020/3/5
    ///  APPROVER: Lane Sandburg
    ///  
    ///  TimeOffRequest Data Transfer Object View Model
    /// </summary>
    public class TimeOffRequestVM :TimeOffRequest
    {
        public new string EffectiveStart { get; set; }

        public new string EffectiveEnd { get; set; }

        public new string ApprovalDate { get; set; }
    }
}
