using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    /// This Class for accessing InHome Inspection Appointment Decision Accessor
    /// data in the database.
    /// </summary>
    public class InHomeInspectionAppointmentDecisionAccessor : IInHomeInspectionAppointmentDecisionAccessor
    {

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/03/10
        /// Approver:  Awaab Elamin, 2020/03/13
        /// This method gets the Customer"s email from the Customer table in the database by Adoption
        /// Application ID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationId"></param>
        /// <returns>customerEmail</returns>
        public string GetCustomerEmailByAdoptionApplicationID(int adoptionApplicationId)
        {
            string customerEmail = null;
            // connection?
            var conn = DBConnection.GetConnection();
            // commands?
            var cmd = new SqlCommand("sp_select_customer_email_by_adoption_ApplicationId", conn);
            // command type?
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adoptionApplicationId", adoptionApplicationId);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customerEmail = reader.GetString(0);

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
            return customerEmail;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// This method used to get Adoption Applications Aappointments ByAppointmen
        ///  tType
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>inHomeInspectionAppointmentDecisions List</returns>
        public List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            List<HomeInspectorAdoptionAppointmentDecision> inHomeInspectionAppointmentDecisions = new List<HomeInspectorAdoptionAppointmentDecision>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_inHomeInspectionAppointments_by_AppointmentType", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var inHomeInspectionAppointmentDecision = new HomeInspectorAdoptionAppointmentDecision();



                        inHomeInspectionAppointmentDecision.AppointmentID = reader.GetInt32(0);
                        inHomeInspectionAppointmentDecision.AdoptionApplicationID = reader.GetInt32(1);
                        inHomeInspectionAppointmentDecision.AppointmentTypeID = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            inHomeInspectionAppointmentDecision.DateTime = reader.GetDateTime(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            inHomeInspectionAppointmentDecision.Notes = reader.GetString(4);
                        }
                        else
                        {
                            inHomeInspectionAppointmentDecision.Notes = "";
                        }
                        if (!reader.IsDBNull(5))
                        {
                            inHomeInspectionAppointmentDecision.Decision = reader.GetString(5);
                        }
                        else
                        {
                            inHomeInspectionAppointmentDecision.Decision = "";
                        }

                        inHomeInspectionAppointmentDecision.LocationName =
                            RetrieveLocationNameByLocationID(reader.GetInt32(6));
                        inHomeInspectionAppointmentDecision.Active = reader.GetBoolean(7);

                        inHomeInspectionAppointmentDecisions.Add(inHomeInspectionAppointmentDecision);
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
            return inHomeInspectionAppointmentDecisions;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/03/10
        /// Approved By:  
        /// This is private method gets the Location's name from the Location table in the database
        /// by Adoption ID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="LocationID"></param>
        /// <returns>name</returns>
        private string RetrieveLocationNameByLocationID(int LocationID)
        {
            string name = "";
            // connection?
            var conn = DBConnection.GetConnection();
            // commands?
            var cmd = new SqlCommand("sp_location_Name_by_Location_Id", conn);
            // command type?
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LocationID", LocationID);
            try
            {

                // open the connection
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name = reader.GetString(0);

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Location name not found!", ex);
            }
            finally
            {
                // close the connection
                conn.Close();
            }
            return name;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// This method used to update an Adoptin Appliction decision.
        /// ID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="oldHomeInspectorAdoptionAppointmentDecision"></param>
        /// <param name="oldHomeInspectorAdoptionAppointmentDecision"></param>
        /// <returns>Zero or one depending if the record was updated </returns>
        public int UpdateAppoinment(HomeInspectorAdoptionAppointmentDecision
            oldHomeInspectorAdoptionAppointmentDecision, HomeInspectorAdoptionAppointmentDecision
            newHomeInspectorAdoptionAppointmentDecision)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_adoption_appointment_decision_note", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", newHomeInspectorAdoptionAppointmentDecision
                .AppointmentID);

            cmd.Parameters.AddWithValue("@NewNotes",
                newHomeInspectorAdoptionAppointmentDecision.Notes);
            cmd.Parameters.AddWithValue("@NewDecision",
                newHomeInspectorAdoptionAppointmentDecision.Decision);

            cmd.Parameters.AddWithValue("@OldNotes",
                oldHomeInspectorAdoptionAppointmentDecision.Notes);
            cmd.Parameters.AddWithValue("@OldDecision",
                oldHomeInspectorAdoptionAppointmentDecision.Decision);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ApplicationException("Record not found.");
                }
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
        /// Creator: Mohamed Elamin
        /// Created: 2020/03/10
        /// Approver: Awaab Elamin, 2020/03/13
        /// This method updates the Home-Inspector Decision in the Adoption Aplication table. 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        /// <returns>Zero or one depending if the record was updated </returns>
        public int UpdateHomeInspectorDecision(int adoptionApplicationID, string decision)
        {
            int count = 0;
            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_update_adoption_application_status";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AdoptionApplicationID", SqlDbType.Int);
            cmd.Parameters.Add("@status", SqlDbType.NVarChar, 1000);

            cmd.Parameters["@AdoptionApplicationID"].Value = adoptionApplicationID;


            cmd.Parameters["@status"].Value = decision;

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }
    }
}

