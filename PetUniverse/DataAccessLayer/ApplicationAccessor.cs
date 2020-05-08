using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 3/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class accesses applications
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public class ApplicationAccessor : IApplicationAccessor
    {
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 3/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This method is used to insert an application
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns></returns>
        public int InsertApplication(int ApplicantID, int JobListingID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_application", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ApplicantID", ApplicantID);
            cmd.Parameters.AddWithValue("@JobListingID", JobListingID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }

            return rows;
        }

        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 3/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This method is used to select all applications by applicant
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>List of Application</returns>
        public List<JobApplication> SelectApplicationsByApplicantID(int ApplicantID)
        {
            List<JobApplication> applications = new List<JobApplication>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_applications_by_applicant_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ApplicantID", ApplicantID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        applications.Add(new JobApplication()
                        {
                            ApplicantID = ApplicantID,
                            ApplicationID = reader.GetInt32(0)
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
            return applications;
        }
    }
}
