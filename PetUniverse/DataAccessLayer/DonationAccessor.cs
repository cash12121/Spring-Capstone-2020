using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    ///  CREATOR: Ryan Morganti
    ///  CREATED: 2020/04/04
    ///  APPROVER: Matt Deaton
    ///  
    ///   Donation Access class for connection to the database when making donation relation queries
    /// </summary>
    public class DonationAccessor : IDonationAccessor
    {
        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Access layer method to chance the active property of a RecurringDonationInfo record.
        ///  This will stop a recurring donation from continuing to process.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int DeactivateRecurringDonation(int recurringDonationID)
        {
            int result;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_recurring_donation", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecurringDonationID", recurringDonationID);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/16
        ///  APPROVER: Derek Taylor
        ///  
        ///  Access layer method to insert new recurring donation records into the database.
        ///  This method will create a new donorID before linking it to the RecurringDonationInfo table.
        ///  Then will make the first donation, tying it to the RecurringDonationInfo in the RecurringDonation table.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public int InsertNewRecurringDonation(RecurringDonationVM donation)
        {
            int donorID;
            int result;
            int recurringDonationID;
            int donationID;
            string firstName = "";
            string lastName = "";

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_name_by_username", conn);
            var cmd2 = new SqlCommand("sp_insert_new_donor", conn);
            var cmd3 = new SqlCommand("sp_insert_new_recurring_donation_info", conn);
            var cmd4 = new SqlCommand("sp_insert_new_monetary_donation", conn);
            var cmd5 = new SqlCommand("sp_insert_new_recurring_donation", conn);



            cmd.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd5.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", donation.UserName);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        firstName = reader.GetString(0);
                        lastName = reader.GetString(1);
                    }
                }
                reader.Close();

                cmd2.Parameters.AddWithValue("@FirstName", firstName);
                cmd2.Parameters.AddWithValue("@LastName", lastName);
                donorID = Convert.ToInt32(cmd2.ExecuteScalar());

                cmd3.Parameters.AddWithValue("@UserName", donation.UserName);
                cmd3.Parameters.AddWithValue("@DonorID", donorID);
                cmd3.Parameters.AddWithValue("@DonationAmount", donation.DonationAmount);
                cmd3.Parameters.AddWithValue("@Interval", donation.Interval);
                recurringDonationID = Convert.ToInt32(cmd3.ExecuteScalar());


                cmd4.Parameters.AddWithValue("@DonorID", donorID);
                cmd4.Parameters.AddWithValue("@TypeOfDonation", "Monetary - Recurring");
                cmd4.Parameters.AddWithValue("@DonationAmount", donation.DonationAmount);
                donationID = Convert.ToInt32(cmd4.ExecuteScalar());

                cmd5.Parameters.AddWithValue("@RecurringDonationID", recurringDonationID);
                cmd5.Parameters.AddWithValue("@DonationID", donationID);

                result = cmd5.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }



            return result;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/04
        ///  APPROVER: Matt Deaton
        ///  
        ///  Database access method used to retrieve the past year's donation history
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<Donation> SelectDonationsFromPastYear()
        {
            List<Donation> donations = new List<Donation>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_donations_from_past_year", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Donation newDonation = new Donation();

                        newDonation.DonationID = reader.GetInt32(0);
                        newDonation.DonorID = reader.GetInt32(1);
                        newDonation.FirstName = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            newDonation.LastName = reader.GetString(3);
                        }

                        newDonation.DateOfDonation = reader.GetDateTime(4);
                        newDonation.TypeOfDonation = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                        {
                            newDonation.DonationAmount = reader.GetDecimal(6);
                        }


                        donations.Add(newDonation);
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

            return donations;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Access layer method to SELECT and individual RecurringDonationInfo record
        ///  by its ID.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public RecurringDonationVM SelectRecurringDonationByID(int id)
        {
            RecurringDonationVM donation = new RecurringDonationVM();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_recurring_donation_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RecurringDonationID", id);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) 
                    {
                        donation.RecurringDonationID = id;
                        donation.UserName = reader.GetString(0);
                        donation.DonorID = reader.GetInt32(1);
                        donation.DonationAmount = reader.GetDecimal(2);
                        donation.StartDate = reader.GetDateTime(3);
                        donation.Interval = reader.GetInt32(4);
                        donation.Active = reader.GetBoolean(5);
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

            return donation;
        }

        /// <summary>
        ///  CREATOR: Ryan Morganti
        ///  CREATED: 2020/04/29
        ///  APPROVER: Derek Taylor
        ///  
        ///  Access layer method to SELECT a collection of RecurringDonationInfo records
        ///  by their associated UserName
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<RecurringDonationVM> SelectRecurringDonationsByUser(string username)
        {
            List<RecurringDonationVM> donations = new List<RecurringDonationVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_recurring_donations_by_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", username);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RecurringDonationVM newDonation = new RecurringDonationVM();

                        newDonation.RecurringDonationID = reader.GetInt32(0);
                        newDonation.DonorID = reader.GetInt32(1);
                        newDonation.DonationAmount = reader.GetDecimal(2);
                        newDonation.StartDate = reader.GetDateTime(3);
                        newDonation.Interval = reader.GetInt32(4);
                        newDonation.Active = reader.GetBoolean(5);

                        donations.Add(newDonation);
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

            return donations;
        }
    }
}
