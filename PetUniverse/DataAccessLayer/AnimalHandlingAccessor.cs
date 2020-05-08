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
    /// Created: 2/21/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Accessor class for AnimalHandingNotes
    /// </summary>
    public class AnimalHandlingAccessor : IAnimalHandlingAccessor
    {
        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/4/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Updates a single handling notes record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="notes"></param>
        /// <returns> Number of Rows effected</returns>
        public int InsertAnimalHandlingNotes(AnimalHandlingNotes notes)
        {
            int notesID = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_handling_notes_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", notes.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", notes.UserID);
            cmd.Parameters.AddWithValue("@AnimalHandlingNotes", notes.HandlingNotes);
            cmd.Parameters.AddWithValue("@TemperamentWarning", notes.TemperamentWarning);
            cmd.Parameters.AddWithValue("@UpdateDate", notes.UpdateDate);

            try
            {
                conn.Open();
                notesID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return notesID;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Select a list of AnimalHandlingNotes objects by their shared animal ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns>The list of animal handling notes</returns>
        public List<AnimalHandlingNotes> SelectAllHandlingNotesByAnimalID(int animalID)
        {
            List<AnimalHandlingNotes> notes = new List<AnimalHandlingNotes>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_handling_notes_by_animal_id");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters["@AnimalID"].Value = animalID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var note = new AnimalHandlingNotes();
                        note.HandlingNotesID = reader.GetInt32(0);
                        note.UserID = reader.GetInt32(4);
                        note.HandlingNotes = reader.GetString(1);
                        note.TemperamentWarning = reader.GetString(2);
                        note.UpdateDate = reader.GetDateTime(3);
                        note.AnimalID = animalID;
                        notes.Add(note);
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

            return notes;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/21/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Select a single AnimalHandlingNotes record by it's primary key
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="handlingNotesID"></param>
        /// <returns>The animal handling notes object</returns>
        public AnimalHandlingNotes SelectHandlingNotesByID(int handlingNotesID)
        {
            AnimalHandlingNotes note = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_handling_notes_by_id");
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalHandlingNotesID", handlingNotesID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    note = new AnimalHandlingNotes()
                    {
                        HandlingNotesID = handlingNotesID,
                        AnimalID = reader.GetInt32(0),
                        UserID = reader.GetInt32(4),
                        HandlingNotes = reader.GetString(1),
                        TemperamentWarning = reader.GetString(2),
                        UpdateDate = reader.GetDateTime(3)
                    };
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

            return note;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/4/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver: 
        /// 
        /// Updates a single handling notes record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldNotes"></param>
        /// <param name="newNotes"></param>
        /// <returns> Number of rows effected </returns>
        public int UpdateAnimalHandlingNotes(AnimalHandlingNotes oldNotes, AnimalHandlingNotes newNotes)
        {
            int rows = 0;

            // connecttion
            var conn = DBConnection.GetConnection();

            // cmd
            var cmd = new SqlCommand("sp_update_handling_notes_record");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Automatically assumes the value is an int32. Decimal and money are more ambiguous
            cmd.Parameters.AddWithValue("@AnimalHandlingNotesID", oldNotes.HandlingNotesID);

            cmd.Parameters.AddWithValue("@NewAnimalID", newNotes.AnimalID);
            cmd.Parameters.AddWithValue("@NewUserID", newNotes.UserID);
            cmd.Parameters.AddWithValue("@NewAnimalHandlingNotes", newNotes.HandlingNotes);
            cmd.Parameters.AddWithValue("@NewTemperamentWarning", newNotes.TemperamentWarning);
            cmd.Parameters.AddWithValue("@NewUpdateDate", newNotes.UpdateDate);


            cmd.Parameters.AddWithValue("@OldAnimalID", oldNotes.AnimalID);
            cmd.Parameters.AddWithValue("@OldUserID", oldNotes.UserID);
            cmd.Parameters.AddWithValue("@OldAnimalHandlingNotes", oldNotes.HandlingNotes);
            cmd.Parameters.AddWithValue("@OldTemperamentWarning", oldNotes.TemperamentWarning);
            cmd.Parameters.AddWithValue("@OldUpdateDate", oldNotes.UpdateDate);

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
