using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>   
    /// 
    /// Creator: Steve Coonrod
    /// Created: 02/06/2020
    /// Approver: Ryan Morganti
    /// 
    /// The interface to access data from the DTOs
    ///     for the Events
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Updater: NA
    /// Updated: NA
    /// Update: NA  
    /// 
    /// </remarks>
    public interface IEventAccessor
    {

        /// <summary>
        /// Creator: Steve Coonrod, Matt Deaton
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Adding an Event
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// </remarks>
        /// <param name="puEvent"></param>
        /// <returns></returns>
        int InsertEvent(PUEvent puEvent);//Took out createdByID parameter...

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Editing an Event
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// <param name="oldEvent"></param>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        bool UpdateEventDetails(PUEvent oldEvent, PUEvent newEvent);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Deleting an Event
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <returns></returns>
        bool DeleteEvent(int eventID);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Inserting A Request
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        int InsertRequest(Request request);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Inserting an eventRequest
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// <param name="eventRequest"></param>
        /// <returns></returns>
        int InsertEventRequest(EventRequest eventRequest);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Selecting an event by its EventID
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <returns></returns>
        PUEvent SelectEventByID(int eventID);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Selecting all events
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA 
        /// 
        /// </remarks>
        /// <returns></returns>
        List<PUEvent> SelectEventsAll();

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 2/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Selecting all event types
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        /// <returns></returns>
        List<EventType> SelectAllEventTypes();

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Selecting an Event Approval View Model
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA    
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <param name="createdByID"></param>
        /// <returns></returns>
        EventApprovalVM SelectEventApprovalVM(int eventID, int createdByID);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Selecting an Event Request by the Event's ID
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <returns></returns>
        EventRequest SelectEventRequestByEventID(int eventID);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/10/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Updating an Event Request
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA 
        /// 
        /// </remarks>
        /// <param name="oldEventRequest"></param>
        /// <param name="newEventRequest"></param>
        /// <returns></returns>
        bool UpdateEventRequest(EventRequest oldEventRequest, EventRequest newEventRequest);


        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/15/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Selecting a List of Events by the Status
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        /// <param name="status"></param>
        /// <returns></returns>
        List<PUEvent> SelectEventsByStatus(string status);

        /// <summary>
        /// 
        /// Creator: Steve Coonrod
        /// Created: 3/15/2020
        /// Approver: Ryan Morganti
        /// 
        /// The interface method for Updating an Event's Status
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        /// <param name="eventID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        bool UpdateEventStatus(int eventID, string status);
    }
}