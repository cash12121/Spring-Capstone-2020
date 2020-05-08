using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Hassan Karar.
    /// Created: 2020/3/7
    /// Approver: 
    /// job listing accessor to interact with job listing data.
    /// </summary>
    public class JobListingAccessor : IJobListingAccessor
    {
        /// NAME: Hassan Karar
        /// DATE: 2020/3/7
        /// CHECKED BY:  Steve Coonrod.
        /// <summary>
        /// This method is deleting a field from the job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="jobListingID"></param>
        /// </remarks>
        /// 
        public int DeletetJobListing(int jobListingID)
        {
            int  results = 0;

            //Conn
            var conn = DBConnection.GetConnection();
            //Cmd
            var cmd = new SqlCommand("sp_delete_JobListing", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@JobListingID", jobListingID);
            try
            {
                
                conn.Open();
                results = cmd.ExecuteNonQuery();
                if (results == 0)
                {
                    throw new ApplicationException("Not found!");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return results;
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/7
        /// CHECKED BY: 
        /// <summary>
        /// This method for the retrive list of job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="jobListing"></param>
        /// </remarks>
        /// 
        public List<JobListing> GetAllJobListings()
        {
            List<JobListing> jobs = new List<JobListing>();


            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_retrieve_JobListing", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    JobListing jobListing = new JobListing();
        
                    jobListing.JobListingID = reader.GetInt32(0);
                    jobListing.Position = jobListing.RoleID;
                    jobListing.RoleID = reader.GetString(1);
                    jobListing.Benefits = reader.GetString(2);
                    jobListing.Requirements = reader.GetString(3);
                    jobListing.StartingWage = reader.GetDecimal(4);
                    jobListing.Responsibilities = reader.GetString(5);
                  
                    jobs.Add(jobListing);
                    
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

            return jobs;
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/7
        /// CHECKED BY: 
        /// <summary>
        /// This method for creating a new record of job listing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="jobListing"></param>
        /// </remarks>
        /// 
        public bool insertJobListing(JobListing jobListing)
        {
            bool result = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_JobListing", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleID", jobListing.RoleID);
            cmd.Parameters.AddWithValue("@Position", jobListing.Position);
            cmd.Parameters.AddWithValue("@Benefits", jobListing.Benefits);
            cmd.Parameters.AddWithValue("@Requirements", jobListing.Requirements);
            cmd.Parameters.AddWithValue("@StartingWage", jobListing.StartingWage);
            cmd.Parameters.AddWithValue("@Responsibilities", jobListing.Responsibilities);

            try
            {
                conn.Open();
                if ((int)cmd.ExecuteNonQuery() == 1)
                {
                    result = true;
                }
            }
            catch (Exception)
            {

                //     result = false;
                throw;
            }

            return result;
        }

        /// NAME: Hassan Karar
        /// DATE: 2020/3/7
        /// CHECKED BY: 
        /// <summary>
        /// This method for updating the job listing data access.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="newJobListing"></param>
        /// <param name="oldJobListing"></param>
        /// </remarks>
        /// 

        public int UpdateJobListing(JobListing newJobListing, JobListing oldJobListing)
        {
            int rows = 0;
            // connection
            var conn = DBConnection.GetConnection();

            // cmd
            var cmd = new SqlCommand("sp_update_JobListing",conn);
            cmd.CommandType = CommandType.StoredProcedure;

           // parameters
            cmd.Parameters.Add("@OldJobListingID", SqlDbType.Int);

            cmd.Parameters.Add("@OldRoleID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@OldBenefits", SqlDbType.NVarChar);
            cmd.Parameters.Add("@OldRequirements", SqlDbType.NVarChar);
            cmd.Parameters.Add("@OldStartingWage", SqlDbType.Decimal);
            cmd.Parameters.Add("@OldResponsibilities", SqlDbType.NVarChar);

            cmd.Parameters.Add("@NewRoleID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@NewBenefits", SqlDbType.NVarChar);
            cmd.Parameters.Add("@NewRequirements", SqlDbType.NVarChar);
            cmd.Parameters.Add("@NewStartingWage", SqlDbType.Decimal);
            cmd.Parameters.Add("@NewResponsibilities", SqlDbType.NVarChar);

            // values


            cmd.Parameters["@NewRoleID"].Value = newJobListing.RoleID;
            cmd.Parameters["@NewBenefits"].Value = newJobListing.Benefits;
            cmd.Parameters["@NewRequirements"].Value = newJobListing.Requirements;
            cmd.Parameters["@NewStartingWage"].Value = newJobListing.StartingWage;
            cmd.Parameters["@NewResponsibilities"].Value = newJobListing.Responsibilities;

            cmd.Parameters["@OldJobListingID"].Value = oldJobListing.JobListingID;
            cmd.Parameters["@OldRoleID"].Value = oldJobListing.RoleID;
            cmd.Parameters["@OldBenefits"].Value = oldJobListing.Benefits;
            cmd.Parameters["@OldRequirements"].Value = oldJobListing.Requirements;
            cmd.Parameters["@OldStartingWage"].Value = oldJobListing.StartingWage;
            cmd.Parameters["@OldResponsibilities"].Value = oldJobListing.Responsibilities;



            // execute the command
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ApplicationException("not found");
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
    }
 }


    

