using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeAvailabilityAccessor : IEmployeeAvailabilityAccessor
    {

        /// <summary>
        /// CREATOR: Lane Sandburg
        /// DATE: 4/2/2020
        /// APPROVER: Jordan Lindo
        ///
        ///  method for inserting a New Employee Availability
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="employeeAvailability">The availability the will be inserted</param>
        /// <returns>returns true if insertion of availability was successful else returns false</returns>
        public bool InsertNewEmployeeAvailability(EmployeeAvailability employeeAvailability)
        {
            bool Created = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_availability", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserID", employeeAvailability.EmployeeID);
            cmd.Parameters.AddWithValue("@DayOfWeek", employeeAvailability.DayOfWeek);
            cmd.Parameters.AddWithValue("@StartTime", employeeAvailability.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", employeeAvailability.EndTime);


            try
            {
                conn.Open();
                Created = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return Created;
        }

        /// <summary>
        /// CREATOR: Lane Sandburg
        /// DATE: 4/9/2020
        /// APPROVER: Jordan Lindo
        ///
        ///  method for Selecting all Employee Availability for a specific user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="employeeID">The Userid to get availabilities by</param>
        /// <returns>returns List<EmployeeAvailability> </returns>
        public List<EmployeeAvailability> SelectEmployeeAvailabilityByID(int employeeID)
        {
            List<EmployeeAvailability> availabilities = new List<EmployeeAvailability>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_user_availability_by_userID", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", employeeID);


            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    availabilities.Add(new EmployeeAvailability()
                    {
                        AvailabilityID = reader.GetInt32(0),
                        EmployeeID = reader.GetInt32(1),
                        DayOfWeek = reader.GetString(2),
                        StartTime = reader.GetString(3),
                        EndTime = reader.GetString(4),
                        Active = reader.GetBoolean(5)
                    });
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
            return availabilities;
        }

        /// <summary>
        /// CREATOR: Lane Sandburg
        /// DATE: 4/9/2020
        /// APPROVER: Jordan Lindo
        ///
        ///  method for Selecting last Employeeid 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="employeeID">The Userid to get availabilities by</param>
        /// <returns>returns List<EmployeeAvailability> </returns>
        public int SelectLastCreatedEmployeeID()
        {
            int employeeID = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_Select_Last_UserID");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeID = reader.GetInt32(0);
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
            return employeeID;
        }
    }
}

