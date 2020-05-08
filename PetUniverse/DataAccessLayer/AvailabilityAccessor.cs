using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Accessor Class for Availability
/// </summary>
namespace DataAccessLayer
{
    public class AvailabilityAccessor : IAvailabilityAccessor
    {

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method retrieves all Users' Avilabilities
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<EmployeeAvailability> SelectAllUsersAvailability()
        {
            List<EmployeeAvailability> availabilities = new List<EmployeeAvailability>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_users_availabilities", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeAvailability availability = new EmployeeAvailability();

                        availability.EmployeeID = reader.GetInt32(0);
                        availability.DayOfWeek = reader.GetString(1);
                        availability.StartTime = reader.GetString(2);
                        availability.EndTime = reader.GetString(3);

                        availabilities.Add(availability);
                    }
                    reader.Close();
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

            return availabilities;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert
        /// 
        /// Method for Activating Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availabilityID"></param>
        /// <returns></returns>
        public int ActivateAvailability(int availabilityID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_activate_availability", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Vals
            cmd.Parameters.AddWithValue("AvailabilityID", availabilityID);


            //Execute Command
            try
            {
                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return nonQueryResults;
        }

        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert 
        /// 
        ///  Method for Deactivating Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availabiilityID"></param>
        /// <returns></returns>
        public int DeactivateAvailability(int availabiilityID)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_deactivate_availability", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Vals
            cmd.Parameters.AddWithValue("AvailabilityID", availabiilityID);


            //Execute Command
            try
            {
                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return nonQueryResults;
        }
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert 
        /// 
        /// Method for Inserting Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="availability"></param>
        /// <returns></returns>
        public int InsertAvailability(EmployeeAvailability availability)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_insert_availability", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Param
            cmd.Parameters.AddWithValue("@DayOfWeek", availability.DayOfWeek);
            cmd.Parameters.AddWithValue("@StartTime", availability.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", availability.EndTime);
            cmd.Parameters.AddWithValue("@UserID", availability.EmployeeID);

            //Execute Command
            try
            {
                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return nonQueryResults;
        }
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert 
        /// 
        /// Method for Selecting all Availabilites
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        public List<EmployeeAvailability> SelectAllAvailabilities()
        {
            //Conn
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_availabilties", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<EmployeeAvailability> availabilities = new List<EmployeeAvailability>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                //Reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        availabilities.Add(new EmployeeAvailability()
                        {
                            EmployeeID = reader.GetInt32(0),
                            StartTime = reader.GetString(1),
                            EndTime = reader.GetString(2),
                            DayOfWeek = reader.GetString(3)


                        });
                    }
                    reader.Close();
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

            return availabilities;
        }
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert 
        /// 
        /// Method for Select Availability By UserID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<AvailabilityVM> SelectAvailabilityByUserID(int userID)
        {
            //Conn
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_availabilties_by_employee_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserID", userID);
            List<AvailabilityVM> availabilities = new List<AvailabilityVM>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                //Reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        availabilities.Add(new AvailabilityVM()
                        {
                            AvailabilityID = reader.GetInt32(0),
                            EmployeeID = reader.GetInt32(1),
                            StartTime = reader.GetString(2),
                            EndTime = reader.GetString(3),
                            DayOfWeek = reader.GetString(4),
                            Name = reader.GetString(5) + " " + reader.GetString(6)


                        });
                    }
                    reader.Close();
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

            return availabilities;
        }
        /// Creator: Chase Schulte
        /// Created: 2020/03/28
        /// Approver: Kaleb Bachert 
        /// 
        /// Method for Updating Availability
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        public int UpdateAvailability(EmployeeAvailability newAvailability, EmployeeAvailability oldAvailability)
        {
            int nonQueryResults;

            //Conn
            var conn = DBConnection.GetConnection();

            //Cmd
            var cmd = new SqlCommand("sp_update_availablity_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Vals
            cmd.Parameters.AddWithValue("OldAvailabilityID", oldAvailability.AvailabilityID);
            cmd.Parameters.AddWithValue("OldUserID", oldAvailability.EmployeeID);
            cmd.Parameters.AddWithValue("OldStartTime", oldAvailability.StartTime);
            cmd.Parameters.AddWithValue("OldEndTime", oldAvailability.EndTime);
            cmd.Parameters.AddWithValue("OldDayOfWeek", oldAvailability.DayOfWeek);

            cmd.Parameters.AddWithValue("NewUserID", newAvailability.EmployeeID);
            cmd.Parameters.AddWithValue("NewStartTime", newAvailability.StartTime);
            cmd.Parameters.AddWithValue("NewEndTime", newAvailability.EndTime);
            cmd.Parameters.AddWithValue("NewDayOfWeek", newAvailability.DayOfWeek);

            //Execute Command
            try
            {
                //Open conn
                conn.Open();
                nonQueryResults = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return nonQueryResults;
        }
    }
}

