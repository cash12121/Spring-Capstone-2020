namespace DataTransferObjects
{
    /// <summary>
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2020/2/06
    /// APPROVER: Ryan Morganti
    /// 
    /// The DTO class to retrieve data for the EventType
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// UPDATER: NA
    /// UPDATED: NA
    /// UPDATE: NA
    /// 
    /// </remarks>
    public class EventType
    {
        public string EventTypeID { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/2/06
        /// APPROVER: Ryan Morganti
        /// 
        /// The no-argument constructor for an EventType
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public EventType() { }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/2/06
        /// APPROVER: Ryan Morganti
        /// 
        /// The full-argument constructor for an EventType
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="eventTypeID"></param>
        /// <param name="description"></param>
        public EventType(string eventTypeID, string description)
        {
            EventTypeID = eventTypeID;
            Description = description;
        }
    }
}
