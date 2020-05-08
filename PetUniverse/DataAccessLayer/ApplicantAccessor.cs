using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Derek Taylor
    /// Created: 2/14/2020
    /// Approver: Ryan Morganti
    /// 
    /// This class accesses Applicants 
    /// </summary>
    /// <remarks>
    /// Updater: Matt Deaton
    /// Updated: 2020-04-11
    /// Update: Added more methods to deal with the applicants
    /// </remarks>
    public class ApplicantAccessor : IApplicantAccessor
    {
        /// <summary>
        /// Creator: Derek Taylor
        /// Created: 2/14/2020
        /// Approver: Ryan Morganti
        /// 
        /// This method is used to get all applicants
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>List of Logs</returns>
        public List<Applicant> SelectAllApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_applicants", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        applicants.Add(new Applicant()
                        {
                            ApplicantID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            MiddleName = reader.GetString(3),
                            Email = reader.GetString(4),
                            PhoneNumber = reader.GetString(5),
                            ApplicantStatus = reader.GetString(6),
                            ApplicationPostion = reader.GetString(7)

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
            return applicants;
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/03/19
        /// Approver: Derek Taylor
        ///  
        /// Method used to query all the positions at PetUniverse from the DataBase
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public List<JobListing> SelectAllJobPositions()
        {
            List<JobListing> positions = new List<JobListing>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_job_listings", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        JobListing job = new JobListing();

                        job.JobListingID = reader.GetInt32(0);
                        job.Position = reader.GetString(1);
                        job.Benefits = reader.GetString(2);
                        job.Requirements = reader.GetString(3);
                        job.StartingWage = reader.GetDecimal(4);
                        job.Responsibilities = reader.GetString(5);
                        job.Active = reader.GetBoolean(6);

                        positions.Add(job);
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
            return positions;
        }

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method to add a Foster Applicant.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="fosterApplicant"></param>
        /// <returns></returns>
        public int InsertFosterApplicant(Applicant fosterApplicant)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_foster_applicant", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", fosterApplicant.FirstName);
            cmd.Parameters.AddWithValue("@LastName", fosterApplicant.LastName);
            cmd.Parameters.AddWithValue("@MiddleName", fosterApplicant.MiddleName);
            cmd.Parameters.AddWithValue("@Email", fosterApplicant.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", fosterApplicant.PhoneNumber);
            cmd.Parameters.AddWithValue("@AddressLine1", fosterApplicant.AddressLineOne);
            cmd.Parameters.AddWithValue("@AddressLine2", fosterApplicant.AddressLineTwo);
            cmd.Parameters.AddWithValue("@City", fosterApplicant.City);
            cmd.Parameters.AddWithValue("@State", fosterApplicant.State);
            cmd.Parameters.AddWithValue("@ZipCode", fosterApplicant.Zipcode);
            cmd.Parameters.AddWithValue("@Foster", fosterApplicant.Foster);

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
        }// End InsertFosterApplicant()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-07
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method to view an Applicant with a provided ID#.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantID"></param>
        /// <returns>Applicant Information to be displayed in a view</returns>
        public Applicant SelectApplicantByID(int applicantID)
        {
            Applicant applicant = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_applicant_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ApplicantID", SqlDbType.Int);
            cmd.Parameters["@ApplicantID"].Value = applicantID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    applicant = new Applicant()
                    {
                        ApplicantID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        MiddleName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.GetString(5),
                        AddressLineOne = reader.GetString(6),
                        AddressLineTwo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        City = reader.GetString(8),
                        State = reader.GetString(9),
                        Zipcode = reader.GetString(10),
                        Foster = reader.GetBoolean(11)
                    };
                }// End if

                reader.Close();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return applicant;
        }// End SelectApplicantByID()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-11
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Accessor Layer method used to select items of an applicant 
        /// from the database to be used for an interview.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantID"></param>
        /// <returns></returns>
        public ApplicantVM SelectApplicantForInterview(int applicantID)
        {
            ApplicantVM applicant = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_applicant_for_interview", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ApplicantID", applicantID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    applicant = new ApplicantVM()
                    {
                        ApplicantID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        MiddleName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.GetString(5),
                        AddressLineOne = reader.GetString(6),
                        AddressLineTwo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        City = reader.GetString(8),
                        State = reader.GetString(9),
                        Zipcode = reader.GetString(10),
                        ApplicationPostion = reader.GetString(11),
                        SchoolName = reader.GetString(12),
                        SchoolCity = reader.GetString(13),
                        SchoolState = reader.GetString(14),
                        SchoolLevel = reader.GetString(15),
                        ReferenceName = reader.GetString(16),
                        ReferenceNameRelationship = reader.GetString(17),
                        ReferenceNamePhoneNumber = reader.GetString(18),
                        ReferenceNameEmail = reader.GetString(19),
                        ApplicantStatus = reader.GetString(20),
                        ResumePath = reader.GetString(21),
                        InterviewNotes = reader.GetString(22),
                        ApplicantSkills = reader.GetString(23),
                        PreviousWorkName = reader.GetString(24),
                        PreviousWorkCity = reader.GetString(25),
                        PreviousWorkState = reader.GetString(26),
                        PreviousWorkType = reader.GetString(27),
                        ApplicationID = reader.GetInt32(28),
                        HomeCheckDate = reader[29] as DateTime?
                    };
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }
            return applicant;
        }// End SelectApplicantForInterview()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method used to update interview notes using an applicantID from the Database.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicantID"></param>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns></returns>
        public int UpdateInterviewNotes(int applicationID, string oldNotes, string newNotes)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_interview_notes", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@oldNotes", oldNotes);
            cmd.Parameters.AddWithValue("@newNotes", newNotes);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }// End UpdateInterviewNotes()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method used to update application status using an applicantID from the Database.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicationID"></param>
        /// <param name="oldStatus"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        public int UpdateApplicationStatus(int applicationID, string oldStatus, string newStatus)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_application_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@OldStatus", oldStatus);
            cmd.Parameters.AddWithValue("@NewStatus", newStatus);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }// End UpdateApplicationStatus()

        /// <summary>
        /// CREATED BY: Matt Deaton
        /// DATE CREATED: 2020-04-16
        /// APPROVED BY: Steve Coonrod
        /// 
        /// Method used to update home check date using an applicantID from the Database.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="applicationID"></param>
        /// <param name="oldDate"></param>
        /// <param name="newDate"></param>
        /// <returns></returns>
        public int UpdateHomeCheckDate(int applicationID, DateTime? oldDate, DateTime? newDate)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_home_check_date", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            cmd.Parameters.AddWithValue("@OldHomeCheckDate", oldDate);
            cmd.Parameters.AddWithValue("@NewHomeCheckDate", newDate);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }// End UpdateHomeCheckDate()

    }// End class ApplicantAccessor

}// End DataAccessLayer
