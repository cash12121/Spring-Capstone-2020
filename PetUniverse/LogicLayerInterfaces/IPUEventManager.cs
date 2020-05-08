using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2020-02-06
    /// APPROVER: Ryan Morganti
    /// 
    /// The interface to manage the data from 
    /// the Data Access Layer for the Events
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Updater: NA
    /// Updated: NA
    /// Update: NA   
    /// 
    /// </remarks>
    public interface IPUEventManager
    {
        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This method takes an event and sends it through the EventAccessor
        /// To be added to the database.
        /// It returns the added events EventID
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        /// <param name="puEvent"></param>
        /// <returns></returns>
        int AddEvent(PUEvent puEvent);


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti 
        /// 
        /// This method takes an event and sends it through the EventAccessor
        /// To be edited in the database.
        /// It returns true if the edit was successful
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
        bool EditEvent(PUEvent oldEvent, PUEvent newEvent);

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti 
        /// 
        /// This method takes an event and sends it through the EventAccessor
        /// To be deleted from the database.
        /// It returns true if the delete was successful
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
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This method sends an EventRequest to the EventAccessor class
        /// To be added to the DB. Returns the count of rows effected in the DB.
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
        int AddEventRequest(EventRequest eventRequest);

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This method sends a Request to the Event Accessor to be added to the DB
        /// Returns the added Request's new RequestID, or 0 if unsuccessful.
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
        int AddRequest(Request request);

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This method retrieves a List of all events in the DB
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
        List<PUEvent> GetAllEvents();

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This method returns the Event associated with the supplied EventID
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
        PUEvent GetEventByID(int eventID);

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This method returns a List of all Event Types in the DB
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
        List<EventType> GetAllEventTypes();

        //=========================================================================\\

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-01
        /// APPROVER: Ryan Morganti
        /// 
        /// This method retrieves a List of all events 
        /// which have the specified Status
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
        List<PUEvent> GetEventsByStatus(string status);

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-04
        /// APPROVER: Ryan Morganti 
        /// 
        /// This method returns the Event View Model associated with the given eventID
        /// through the EventAccessor
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        /// <param name="EventID"></param>
        /// <param name="CreatedByID"></param>
        /// <returns></returns>
        EventApprovalVM GetEventApprovalVM(int EventID, int CreatedByID);

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti 
        /// 
        /// The event manager method for Selecting an Event Request associated with the specified EventD
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
        EventRequest GetEventRequestByEventID(int eventID);

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti 
        /// 
        /// The event manager method for Updating an Event Request
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
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-03-15
        /// APPROVER: Ryan Morganti 
        /// 
        /// A method to Update an Event's Status to the status specified
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
