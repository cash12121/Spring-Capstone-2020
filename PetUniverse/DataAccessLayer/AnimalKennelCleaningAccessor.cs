using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Accessor for the kennel cleaning records
    /// </summary>
    public class AnimalKennelCleaningAccessor : IAnimalKennelCleaningAccessor
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/10/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Deletes a cleaning record from the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        public int DeleteKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_kennel_cleaning_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FacilityKennelCleaningID", cleaningRecord.FacilityKennelCleaningID);
            cmd.Parameters.AddWithValue("@UserID", cleaningRecord.UserID);
            cmd.Parameters.AddWithValue("@AnimalKennelID", cleaningRecord.AnimalKennelID);
            cmd.Parameters.AddWithValue("@Date", cleaningRecord.Date);
            cmd.Parameters.AddWithValue("@Notes", cleaningRecord.Notes);

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
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Inserts the cleaning record into the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="cleaningRecord"></param>
        /// <returns></returns>
        public int InsertKennelCleaningRecord(AnimalKennelCleaningRecord cleaningRecord)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_kennel_cleaning_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalKennelID", cleaningRecord.AnimalKennelID);
            cmd.Parameters.AddWithValue("@UserID", cleaningRecord.UserID);
            cmd.Parameters.AddWithValue("@Date", cleaningRecord.Date);
            cmd.Parameters.AddWithValue("@Notes", cleaningRecord.Notes);

            try
            {
                conn.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
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
        /// Creator: Ben Hanna
        /// Created: 4/7/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Gets all kennel records and returns them to the up layers
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <returns> List of all kennel cleaning records in the DB<</returns>
        public List<AnimalKennelCleaningRecord> SelectAllKennelCleaningRecords()
        {
            List<AnimalKennelCleaningRecord> cleaningRecords = new List<AnimalKennelCleaningRecord>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_kennel_cleaning_records");
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
                        var record = new AnimalKennelCleaningRecord()
                        {
                            FacilityKennelCleaningID = reader.GetInt32(0),
                            UserID = reader.GetInt32(1),
                            AnimalKennelID = reader.GetInt32(2),
                            Date = reader.GetDateTime(3),
                            Notes = reader.GetString(4)
                        };

                        cleaningRecords.Add(record);
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

            return cleaningRecords;


        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/7/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Edits an existing cleaning record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="oldRecord"></param>
        /// <param name="newRecord"></param>
        /// <returns></returns>
        public int UpdateKennelCleaningRecord(AnimalKennelCleaningRecord oldRecord, AnimalKennelCleaningRecord newRecord)
        {
            int rows = 0;

            // connecttion
            var conn = DBConnection.GetConnection();

            // cmd
            var cmd = new SqlCommand("sp_update_kennel_cleaning_record");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Automatically assumes the value is an int32. Decimal and money are more ambiguous
            cmd.Parameters.AddWithValue("@FacilityKennelCleaningID", oldRecord.FacilityKennelCleaningID);

            cmd.Parameters.AddWithValue("@NewUserID", newRecord.UserID);
            cmd.Parameters.AddWithValue("@NewAnimalKennelID", newRecord.AnimalKennelID);
            cmd.Parameters.AddWithValue("@NewDate", newRecord.Date);
            cmd.Parameters.AddWithValue("@NewNotes", newRecord.Notes);


            cmd.Parameters.AddWithValue("@OldUserID", oldRecord.UserID);
            cmd.Parameters.AddWithValue("@OldAnimalKennelID", oldRecord.AnimalKennelID);
            cmd.Parameters.AddWithValue("@OldDate", oldRecord.Date);
            cmd.Parameters.AddWithValue("@OldNotes", oldRecord.Notes);

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
    }
}
