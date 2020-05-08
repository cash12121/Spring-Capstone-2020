using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2020-02-06
    /// APPROVER: Ryan Morganti
    /// 
    /// EventAccessor class that implements IEventAccessor
    /// Manages the operations with the database
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// Updater: NA
    /// Updated: NA
    /// Update: NA   
    /// 
    /// </remarks>
    public class EventAccessor : IEventAccessor
    {
        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod, Matt Deaton
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This InsertEvent method is used to access data through a stored 
        /// procedure sp_insert_event in the database
        /// It returns the new Event's EventID
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
        /// <returns> int eventID </returns>
        public int InsertEvent(PUEvent puEvent)
        {
            int eventID = 0;
            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_event");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@CreatedByID", SqlDbType.Int);
            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
            cmd.Parameters.Add("@EventName", SqlDbType.NVarChar, 150);
            cmd.Parameters.Add("@EventTypeID", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@EventDateTime", SqlDbType.DateTime);
            cmd.Parameters.Add("@EventAddress", SqlDbType.NVarChar, 200);
            cmd.Parameters.Add("@EventCity", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@EventState", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@EventZipcode", SqlDbType.NVarChar, 15);
            cmd.Parameters.Add("@EventPictureFileName", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);

            //Values
            cmd.Parameters["@CreatedByID"].Value = puEvent.CreatedByID;
            cmd.Parameters["@DateCreated"].Value = puEvent.DateCreated;
            cmd.Parameters["@EventName"].Value = puEvent.EventName;
            cmd.Parameters["@EventTypeID"].Value = puEvent.EventTypeID;
            cmd.Parameters["@EventDateTime"].Value = puEvent.EventDateTime;
            cmd.Parameters["@EventAddress"].Value = puEvent.Address;
            cmd.Parameters["@EventCity"].Value = puEvent.City;
            cmd.Parameters["@EventState"].Value = puEvent.State;
            cmd.Parameters["@EventZipcode"].Value = puEvent.Zipcode;
            cmd.Parameters["@EventPictureFileName"].Value = puEvent.BannerPath;
            cmd.Parameters["@Status"].Value = puEvent.Status;
            cmd.Parameters["@Description"].Value = puEvent.Description;

            try
            {
                conn.Open();
                eventID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return eventID;
        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-09
        /// APPROVER: Ryan Morganti
        /// 
        /// This UpdateEventDetails method is used to Update event data through  
        /// a stored procedure sp_update_event in the database
        /// 
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
        /// <returns> bool successful </returns>
        public bool UpdateEventDetails(PUEvent oldEvent, PUEvent newEvent)
        {
            bool successful = false;
            int rowsEffected = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_event", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters with values
            cmd.Parameters.AddWithValue("@EventID", oldEvent.EventID);
            cmd.Parameters.AddWithValue("@OldCreatedByID", oldEvent.CreatedByID);
            cmd.Parameters.AddWithValue("@OldDateCreated", oldEvent.DateCreated);
            cmd.Parameters.AddWithValue("@OldEventName", oldEvent.EventName);
            cmd.Parameters.AddWithValue("@OldEventTypeID", oldEvent.EventTypeID);
            cmd.Parameters.AddWithValue("@OldEventDateTime", oldEvent.EventDateTime);
            cmd.Parameters.AddWithValue("@OldEventAddress", oldEvent.Address);
            cmd.Parameters.AddWithValue("@OldEventCity", oldEvent.City);
            cmd.Parameters.AddWithValue("@OldEventState", oldEvent.State);
            cmd.Parameters.AddWithValue("@OldEventZipcode", oldEvent.Zipcode);
            cmd.Parameters.AddWithValue("@OldEventPictureFileName", oldEvent.BannerPath);
            cmd.Parameters.AddWithValue("@OldStatus", oldEvent.Status);
            cmd.Parameters.AddWithValue("@OldDescription", oldEvent.Description);

            cmd.Parameters.AddWithValue("@NewCreatedByID", newEvent.CreatedByID);
            cmd.Parameters.AddWithValue("@NewDateCreated", newEvent.DateCreated);
            cmd.Parameters.AddWithValue("@NewEventName", newEvent.EventName);
            cmd.Parameters.AddWithValue("@NewEventTypeID", newEvent.EventTypeID);
            cmd.Parameters.AddWithValue("@NewEventDateTime", newEvent.EventDateTime);
            cmd.Parameters.AddWithValue("@NewEventAddress", newEvent.Address);
            cmd.Parameters.AddWithValue("@NewEventCity", newEvent.City);
            cmd.Parameters.AddWithValue("@NewEventState", newEvent.State);
            cmd.Parameters.AddWithValue("@NewEventZipcode", newEvent.Zipcode);
            cmd.Parameters.AddWithValue("@NewEventPictureFileName", newEvent.BannerPath);
            cmd.Parameters.AddWithValue("@NewStatus", newEvent.Status);
            cmd.Parameters.AddWithValue("@NewDescription", newEvent.Description);

            try
            {
                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            //Verify that exactly one row was affected
            if (rowsEffected == 1)
            {
                successful = true;
            }
            return successful;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This DeleteEvent method calls the stored procedure sp_delete_event
        /// It will return true if the Event records have been sucessfully deleted
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater: NA
        /// Updated: NA
        /// Update: NA   
        /// 
        /// </remarks>
        public bool DeleteEvent(int eventID)
        {
            bool successful = false;
            int rowsEffected = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_delete_event");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters["@EventID"].Value = eventID;

            try
            {
                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            //Rows effected will equal 1 if the event has no Request 
            //  and therefore no EventRequest associated with it 
            //  (This is the case when a Donation Coordinator creates an event)
            //Or it will equal 3 if the event was created by a non-DC member.
            // This is because there is a corresponding eventID and RequestID in the
            // Event, Request, and EventRequest tables that will be removed
            if (rowsEffected == 1 || rowsEffected == 3)
            {
                successful = true;
            }
            return successful;
        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This InsertEventRequest method is used to access data through a stored 
        /// procedure sp_insert_event_request in the database
        /// It returns the rows effected
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
        /// <returns >int rowsEffected </returns>
        public int InsertEventRequest(EventRequest eventRequest)
        {
            int rowsEffected = 0;
            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_event_request");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters.Add("@RequestID", SqlDbType.Int);
            cmd.Parameters.Add("@ReviewerID", SqlDbType.Int);
            cmd.Parameters.Add("@DisapprovalReason", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@DesiredVolunteers", SqlDbType.Int);
            cmd.Parameters.Add("@Active", SqlDbType.Bit);

            //Values
            cmd.Parameters["@EventID"].Value = eventRequest.EventID;
            cmd.Parameters["@RequestID"].Value = eventRequest.RequestID;
            cmd.Parameters["@ReviewerID"].Value = eventRequest.ReviewerID;
            cmd.Parameters["@DisapprovalReason"].Value = eventRequest.DisapprovalReason;
            cmd.Parameters["@DesiredVolunteers"].Value = eventRequest.DesiredVolunteers;
            cmd.Parameters["@Active"].Value = eventRequest.Active;

            try
            {
                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsEffected;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This InsertRequest method is used to access data through a stored 
        /// procedure sp_insert_event_request in the database
        /// It returns the new Request's RequestID
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
        /// <returns> int requestID </returns>
        public int InsertRequest(Request request)
        {
            int requestID = 0;
            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
            cmd.Parameters.Add("@RequestTypeID", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@RequestingUserID", SqlDbType.Int);
            cmd.Parameters.Add("@Open", SqlDbType.Bit);
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Direction = ParameterDirection.Output;

            //Values
            cmd.Parameters["@DateCreated"].Value = request.DateCreated;
            cmd.Parameters["@RequestTypeID"].Value = request.RequestTypeID;
            cmd.Parameters["@RequestingUserID"].Value = request.RequestingUserID;
            cmd.Parameters["@Open"].Value = request.Open;

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
                requestID = (int)cmd.Parameters["@RequestID"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requestID;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-06
        /// APPROVER: Ryan Morganti
        /// 
        /// This is a helper method that calls the stored procedure sp_select_all_event_types
        /// It returns the full list of all Event Types in the database
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
        public List<EventType> SelectAllEventTypes()
        {
            List<EventType> eventTypes = new List<EventType>();

            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_event_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EventType selectedEventType = new EventType();
                        selectedEventType.EventTypeID = reader.GetString(0);
                        selectedEventType.Description = reader.GetString(1);
                        eventTypes.Add(selectedEventType);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return eventTypes;
        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-09
        /// APPROVER: Ryan Morganti
        /// 
        /// This SelectEventByID method is used to access data through a stored 
        /// procedure sp_select_Event_by_ID in the database
        /// 
        /// It returns the Event associated with the given EventID
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
        /// <returns> Event event </returns>
        public PUEvent SelectEventByID(int eventID)
        {
            PUEvent retrievedEvent = new PUEvent();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_event_by_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", eventID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        retrievedEvent.EventID = eventID;
                        retrievedEvent.CreatedByID = reader.GetInt32(0);
                        retrievedEvent.DateCreated = reader.GetDateTime(1);
                        retrievedEvent.EventName = reader.GetString(2);
                        retrievedEvent.EventTypeID = reader.GetString(3);
                        retrievedEvent.EventDateTime = reader.GetDateTime(4);
                        retrievedEvent.Address = reader.GetString(5);
                        retrievedEvent.City = reader.GetString(6);
                        retrievedEvent.State = reader.GetString(7);
                        retrievedEvent.Zipcode = reader.GetString(8);
                        retrievedEvent.BannerPath = reader.GetString(9);
                        retrievedEvent.Status = reader.GetString(10);
                        retrievedEvent.Description = reader.GetString(11);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return retrievedEvent;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020-02-09
        /// APPROVER: Ryan Morganti
        /// 
        /// This method calls the stored procedure sp_select_all_events
        /// It returns a full list of all Events in the DB
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
        public List<PUEvent> SelectEventsAll()
        {
            List<PUEvent> retrievedEvents = new List<PUEvent>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_events", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PUEvent retrievedEvent = new PUEvent();

                        retrievedEvent.EventID = reader.GetInt32(0);
                        retrievedEvent.CreatedByID = reader.GetInt32(1);
                        retrievedEvent.DateCreated = reader.GetDateTime(2);
                        retrievedEvent.EventName = reader.GetString(3);
                        retrievedEvent.EventTypeID = reader.GetString(4);
                        retrievedEvent.EventDateTime = reader.GetDateTime(5);
                        retrievedEvent.Address = reader.GetString(6);
                        retrievedEvent.City = reader.GetString(7);
                        retrievedEvent.State = reader.GetString(8);
                        retrievedEvent.Zipcode = reader.GetString(9);
                        retrievedEvent.BannerPath = reader.GetString(10);
                        retrievedEvent.Status = reader.GetString(11);
                        retrievedEvent.Description = reader.GetString(12);

                        retrievedEvents.Add(retrievedEvent);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return retrievedEvents;
        }// End SelectAllEvents()

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3/15/2020
        /// APPROVER: Ryan Morganti
        /// 
        /// The data accessor method for Selecting an Event View Model
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
        public EventApprovalVM SelectEventApprovalVM(int eventID, int createdByID)
        {
            EventApprovalVM retrievedEventApprovalVM = new EventApprovalVM();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_event_approval_request_by_eventID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", eventID);
            cmd.Parameters.AddWithValue("@CreatedByID", createdByID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        retrievedEventApprovalVM.RequestedByName = reader.GetString(0);
                        retrievedEventApprovalVM.DateCreated = reader.GetDateTime(1);
                        retrievedEventApprovalVM.EventName = reader.GetString(2);
                        retrievedEventApprovalVM.EventTypeID = reader.GetString(3);
                        retrievedEventApprovalVM.EventDateTime = reader.GetDateTime(4);
                        retrievedEventApprovalVM.Address = reader.GetString(5);
                        retrievedEventApprovalVM.City = reader.GetString(6);
                        retrievedEventApprovalVM.State = reader.GetString(7);
                        retrievedEventApprovalVM.Zipcode = reader.GetString(8);
                        retrievedEventApprovalVM.BannerPath = reader.GetString(9);
                        retrievedEventApprovalVM.Status = reader.GetString(10);
                        retrievedEventApprovalVM.Description = reader.GetString(11);
                        if (!reader.IsDBNull(12))
                        {
                            retrievedEventApprovalVM.ReviewerName = reader.GetInt32(12).ToString();
                        }
                        else
                        {
                            retrievedEventApprovalVM.ReviewerName = "0";
                        }
                        if (!reader.IsDBNull(13))
                        {
                            retrievedEventApprovalVM.DisapprovalReason = reader.GetString(13);
                        }
                        retrievedEventApprovalVM.DesiredVolunteers = reader.GetInt32(14);

                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return retrievedEventApprovalVM;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// Created: 3/15/2020
        /// APPROVER: Ryan Morganti
        /// 
        /// The data accessor method for Selecting an Event Request by it's EventID
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
        public EventRequest SelectEventRequestByEventID(int eventID)
        {
            EventRequest retrievedEventRequest = new EventRequest();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_event_request_by_event_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", eventID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        retrievedEventRequest.EventID = eventID;
                        retrievedEventRequest.RequestID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                        {
                            retrievedEventRequest.ReviewerID = reader.GetInt32(1);
                        }
                        else
                        {
                            retrievedEventRequest.ReviewerID = 0;
                        }
                        if (!reader.IsDBNull(2))
                        {
                            retrievedEventRequest.DisapprovalReason = reader.GetString(2);
                        }

                        retrievedEventRequest.DesiredVolunteers = reader.GetInt32(3);
                        retrievedEventRequest.Active = reader.GetBoolean(4);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return retrievedEventRequest;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3/15/2020
        /// APPROVER: Ryan Morganti
        /// 
        /// The data accessor method for Updating an Event Request
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
        public bool UpdateEventRequest(EventRequest oldEventRequest, EventRequest newEventRequest)
        {
            bool successful = false;
            int rowsEffected = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_event_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters with values
            cmd.Parameters.AddWithValue("@EventID", oldEventRequest.EventID);
            cmd.Parameters.AddWithValue("@ReviewerID", newEventRequest.ReviewerID);
            cmd.Parameters.AddWithValue("@DisapprovalReason", newEventRequest.DisapprovalReason);
            cmd.Parameters.AddWithValue("@DesiredVolunteers", newEventRequest.DesiredVolunteers);
            cmd.Parameters.AddWithValue("@Active", newEventRequest.Active);
            cmd.Parameters.AddWithValue("@OldReviewerID", oldEventRequest.ReviewerID);
            cmd.Parameters.AddWithValue("@OldDisapprovalReason", oldEventRequest.DisapprovalReason);
            cmd.Parameters.AddWithValue("@OldDesiredVolunteers", oldEventRequest.DesiredVolunteers);
            cmd.Parameters.AddWithValue("@OldActive", oldEventRequest.Active);

            if (cmd.Parameters[1].Value == null)
            {
                cmd.Parameters[1].Value = DBNull.Value;
            }
            if (cmd.Parameters[2].Value == null)
            {
                cmd.Parameters[2].Value = DBNull.Value;
            }
            if (cmd.Parameters[5].Value == null || (int)cmd.Parameters[5].Value == 0)
            {
                cmd.Parameters[5].Value = DBNull.Value;
            }
            if (cmd.Parameters[6].Value == null)
            {
                cmd.Parameters[6].Value = DBNull.Value;
            }
            try
            {
                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            //Verify that exactly one row was affected
            if (rowsEffected == 1)
            {
                successful = true;
            }
            return successful;

        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3/15/2020
        /// APPROVER: Ryan Morganti
        /// 
        /// The data accessor method for Selecting a List of Events by the Status
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
        public List<PUEvent> SelectEventsByStatus(string status)
        {
            List<PUEvent> retrievedEvents = new List<PUEvent>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_events_by_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Status", status);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PUEvent retrievedEvent = new PUEvent();

                        retrievedEvent.EventID = reader.GetInt32(0);
                        retrievedEvent.CreatedByID = reader.GetInt32(1);
                        retrievedEvent.DateCreated = reader.GetDateTime(2);
                        retrievedEvent.EventName = reader.GetString(3);
                        retrievedEvent.EventTypeID = reader.GetString(4);
                        retrievedEvent.EventDateTime = reader.GetDateTime(5);
                        retrievedEvent.Address = reader.GetString(6);
                        retrievedEvent.City = reader.GetString(7);
                        retrievedEvent.State = reader.GetString(8);
                        retrievedEvent.Zipcode = reader.GetString(9);
                        retrievedEvent.BannerPath = reader.GetString(10);
                        retrievedEvent.Status = reader.GetString(11);
                        retrievedEvent.Description = reader.GetString(12);

                        retrievedEvents.Add(retrievedEvent);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return retrievedEvents;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3/15/2020
        /// APPROVER: Ryan Morganti
        /// 
        /// The data accessor method for Updating an Event's Status
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
        public bool UpdateEventStatus(int eventID, string status)
        {
            bool successful = false;
            int rowsEffected = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_set_event_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters with values
            cmd.Parameters.AddWithValue("@EventID", eventID);
            cmd.Parameters.AddWithValue("@Status", status);
            try
            {
                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            //Verify that exactly one row was affected
            if (rowsEffected == 1)
            {
                successful = true;
            }
            return successful;
        }


    }
}
