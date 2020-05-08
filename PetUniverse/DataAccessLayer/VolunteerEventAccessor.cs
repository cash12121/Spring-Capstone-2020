using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Zoey McDonald
    /// DATE: 2/7/2020
    /// CHECKED BY: Ethan Holmes
    /// 
    /// This is an accessor class for the volunteer event.
    /// 
    /// </summary>
    public class VolunteerEventAccessor : IVolunteerEventAccessor
    {
        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is an accessor method for inserting a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public int InsertVolunteerEvent(VolunteerEventVM volunteerEvent)
        {
            // Declare the variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_volunteer_event", conn);

            // Setup the cmd object
            cmd.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            cmd.Parameters.AddWithValue("@EventName", volunteerEvent.EventName);
            cmd.Parameters.AddWithValue("@EventDescription", volunteerEvent.EventDescription);
            cmd.Parameters.AddWithValue("@Active", volunteerEvent.Active);

            // Try to execute the query
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }



        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is an accessor method for updating a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public int UpdateVolunteerEvent(VolunteerEvent oldVolunteerEvent, VolunteerEvent newVolunteerEvent)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_volunteer_event");

            // Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // Add the parameters
            cmd.Parameters.Add("@VolunteerEventID", SqlDbType.Int);
            cmd.Parameters.Add("@EventName", SqlDbType.NVarChar, 400);
            cmd.Parameters.Add("@EventDescription", SqlDbType.NVarChar, 400);
            cmd.Parameters.Add("@Active", SqlDbType.Bit);

            // Set parameter values
            cmd.Parameters["@VolunteerEventID"].Value = oldVolunteerEvent.VolunteerEventID;
            cmd.Parameters["@EventName"].Value = newVolunteerEvent.EventName;
            cmd.Parameters["@EventDescription"].Value = newVolunteerEvent.EventDescription;
            cmd.Parameters["@Active"].Value = newVolunteerEvent.Active;

            // Try to execute the query
            try
            {
                conn.Open();
                rows = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is an accessor method for selecting volunteer events. NOT DONE YET.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public VolunteerEvent SelectEvent(int VolunteerEventID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is an accessor method for removing a volunteer event.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public int RemoveVolunteerEvent(int volunteerEventID)
        {
            // Declare the variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_volunteer_event");

            // Setup the cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters
            cmd.Parameters.Add("@VolunteerEventID", SqlDbType.Int);
            cmd.Parameters["@VolunteerEventID"].Value = volunteerEventID;

            // Try to execute the query
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is an accessor method for selecting all volunteer events.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public List<VolunteerEvent> SelectAllEvents()
        {
            // Declare the variables
            List<VolunteerEvent> volunteerEvents = new List<VolunteerEvent>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_volunteer_events");

            // Setup the cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // Try to execute the query
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VolunteerEvent volunteerEvent = new VolunteerEvent();
                    volunteerEvent.VolunteerEventID = Convert.ToInt32(reader.GetValue(0));
                    volunteerEvent.EventName = Convert.ToString(reader.GetValue(1));
                    volunteerEvent.EventDescription = Convert.ToString(reader.GetValue(2));
                    volunteerEvents.Add(volunteerEvent);
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
            return volunteerEvents;



        }
    }
}
