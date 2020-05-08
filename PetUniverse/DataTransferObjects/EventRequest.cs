namespace DataTransferObjects
{
    /// <summary>
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2020/2/06
    /// APPROVER: Ryan Morganti
    /// 
    /// The DTO class to retrieve data for the EventRequest
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// UPDATER: NA
    /// UPDATED: NA
    /// UPDATE: NA
    /// 
    /// </remarks>
    public class EventRequest : Request
    {
        public int EventID { get; set; }
        public int ReviewerID { get; set; }
        public string DisapprovalReason { get; set; }
        public int DesiredVolunteers { get; set; }
        public bool Active { get; set; }

        /// <summary>
        ///  
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/2/06
        /// APPROVER: Matt Deaton
        /// 
        /// The no-argument constructor for an EventRequest
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public EventRequest() { }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/2/06
        /// APPROVER: Ryan Morganti
        /// 
        /// The full-argument constructor for an EventRequest
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <param name="requestID"></param>
        /// <param name="reviewerID"></param>
        /// <param name="disapprovalReason"></param>
        /// <param name="desiredVolunteers"></param>
        /// <param name="active"></param>
        public EventRequest(int eventID, int requestID, int reviewerID, string disapprovalReason, int desiredVolunteers, bool active)
        {
            EventID = eventID;
            RequestID = requestID;
            ReviewerID = reviewerID;
            DisapprovalReason = disapprovalReason;
            DesiredVolunteers = desiredVolunteers;
            Active = active;
        }

    }
}
