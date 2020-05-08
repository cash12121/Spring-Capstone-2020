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
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/14/2020
    /// Approver: Chuck Baxter, 2/14/2020
    /// 
    /// Data access methods for the kennel table
    /// </summary>
    public class AnimalKennelAccessor : IAnimalKennelAccessor
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Adds a date out to the object in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"></param>
        /// <returns></returns>
        public int AddDateOut(AnimalKennel kennel)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_date_out", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalKennelID", kennel.AnimalKennelID);
            cmd.Parameters.AddWithValue("@AnimalKennelDateOut", kennel.AnimalKennelDateOut);

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
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Adds a kennel record to the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="kennel"> Kennel object </param>
        /// <returns> An integer that represents the number of rows effected. Should equal 1 if method succeeded. </returns>
        public int InsertKennelRecord(AnimalKennel kennel)
        {
            int animalKennelID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_kennel_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", kennel.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", kennel.UserID);
            cmd.Parameters.AddWithValue("@AnimalKennelInfo", kennel.AnimalKennelInfo);
            cmd.Parameters.AddWithValue("@AnimalKennelDateIn", kennel.AnimalKennelDateIn);

            try
            {
                conn.Open();
                animalKennelID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return animalKennelID;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/12/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Gets all kennel records and returns them to the up layers
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <returns> a list of all kennel records in the DB </returns>
        public List<AnimalKennel> RetriveAllAnimalKennels()
        {
            List<AnimalKennel> kennels = new List<AnimalKennel>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_kennel_records");
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
                        var note = new AnimalKennel();
                        note.AnimalKennelID = reader.GetInt32(0);
                        note.AnimalID = reader.GetInt32(1);
                        note.UserID = reader.GetInt32(2);
                        note.AnimalKennelInfo = reader.GetString(3);
                        note.AnimalKennelDateIn = reader.GetDateTime(4);
                        note.AnimalKennelDateOut = reader[5] as DateTime?;
                        kennels.Add(note);
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

            return kennels;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Updates a single kennel record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="oldKennel"></param>
        /// <param name="newKennel"></param>
        /// <returns> Number of database rows effected. Should always be 1. </returns>
        public int UpdateKennelRecord(AnimalKennel oldKennel, AnimalKennel newKennel)
        {
            int rows = 0;

            // connecttion
            var conn = DBConnection.GetConnection();

            // cmd
            var cmd = new SqlCommand("sp_update_kennel_record");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Automatically assumes the value is an int32. Decimal and money are more ambiguous
            cmd.Parameters.AddWithValue("@AnimalKennelID", oldKennel.AnimalKennelID);

            cmd.Parameters.AddWithValue("@NewAnimalID", newKennel.AnimalID);
            cmd.Parameters.AddWithValue("@NewUserID", newKennel.UserID);
            cmd.Parameters.AddWithValue("@NewAnimalKennelInfo", newKennel.AnimalKennelInfo);
            cmd.Parameters.AddWithValue("@NewAnimalKennelDateIn", newKennel.AnimalKennelDateIn);
            cmd.Parameters.AddWithValue("@NewAnimalKennelDateOut", newKennel.AnimalKennelDateOut);


            cmd.Parameters.AddWithValue("@OldAnimalID", oldKennel.AnimalID);
            cmd.Parameters.AddWithValue("@OldUserID", oldKennel.UserID);
            cmd.Parameters.AddWithValue("@OldAnimalKennelInfo", oldKennel.AnimalKennelInfo);
            cmd.Parameters.AddWithValue("@OldAnimalKennelDateIn", oldKennel.AnimalKennelDateIn);
            cmd.Parameters.AddWithValue("@OldAnimalKennelDateOut", oldKennel.AnimalKennelDateOut);

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
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Updates a single kennel record without a DateOut value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="oldKennel"></param>
        /// <param name="newKennel"></param>
        /// <returns> Number of database rows effected. Should always be 1. </returns>
        public int UpdateKennelRecordNoDateOut(AnimalKennel oldKennel, AnimalKennel newKennel)
        {
            int rows = 0;

            // connecttion
            var conn = DBConnection.GetConnection();

            // cmd
            var cmd = new SqlCommand("sp_update_kennel_record_no_date_out");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Automatically assumes the value is an int32. Decimal and money are more ambiguous
            cmd.Parameters.AddWithValue("@AnimalKennelID", oldKennel.AnimalKennelID);

            cmd.Parameters.AddWithValue("@NewAnimalID", newKennel.AnimalID);
            cmd.Parameters.AddWithValue("@NewUserID", newKennel.UserID);
            cmd.Parameters.AddWithValue("@NewAnimalKennelInfo", newKennel.AnimalKennelInfo);
            cmd.Parameters.AddWithValue("@NewAnimalKennelDateIn", newKennel.AnimalKennelDateIn);


            cmd.Parameters.AddWithValue("@OldAnimalID", oldKennel.AnimalID);
            cmd.Parameters.AddWithValue("@OldUserID", oldKennel.UserID);
            cmd.Parameters.AddWithValue("@OldAnimalKennelInfo", oldKennel.AnimalKennelInfo);
            cmd.Parameters.AddWithValue("@OldAnimalKennelDateIn", oldKennel.AnimalKennelDateIn);

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
