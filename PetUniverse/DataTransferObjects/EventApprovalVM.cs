using System;

namespace DataTransferObjects
{
    /// <summary>
    ///  
    /// CREATOR: Steve Coonrod
    /// CREATED: 2020/3/08
    /// APPROVER: Matt Deaton
    ///  
    /// This is the View Model for an event approval
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// UPDATER: NA
    /// UPDATED: NA
    /// UPDATE: NA
    /// 
    /// </remarks>
    public class EventApprovalVM
    {
        public string EventName { get; set; }
        public DateTime DateCreated { get; set; }
        public string EventTypeID { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string BannerPath { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string RequestedByName { get; set; }
        public string DisapprovalReason { get; set; }
        public string ReviewerName { get; set; }
        public int DesiredVolunteers { get; set; }
    }
}