using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Zoey McDonald
    /// Created: 3/2/2020
    /// Approver: Timothy Lickteig
    /// 
    /// Treatment record accessor to interact with data.
    /// </summary>
    public class TreatmentRecordAccessor : ITreatmentRecordAccessor
    {
        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// A data access method that uses a stored procedure to add a treatment record to the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="treatmentRecord"></param>
        /// <returns></returns>
        public int InsertTreatmentRecord(TreatmentRecord treatmentRecord)
        {
            int TreatmentRecordID = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_treatment_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VetID", treatmentRecord.VetID);
            cmd.Parameters.AddWithValue("@AnimalID", treatmentRecord.AnimalID);
            cmd.Parameters.AddWithValue("@FormName", treatmentRecord.FormName);
            cmd.Parameters.AddWithValue("@TreatmentDate", treatmentRecord.TreatmentDate);
            cmd.Parameters.AddWithValue("@TreatmentDescription", treatmentRecord.TreatmentDescription);
            cmd.Parameters.AddWithValue("@Notes", treatmentRecord.Notes);
            cmd.Parameters.AddWithValue("@Reason", treatmentRecord.Reason);
            cmd.Parameters.AddWithValue("@Urgency", treatmentRecord.Urgency);

            try
            {
                conn.Open();
                TreatmentRecordID = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return TreatmentRecordID;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// A data access method that uses a stored procedure to delete all treatment records in the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// /// <param name="treatmentRecord"></param>
        /// <returns></returns>
        public int DeleteTreatmentRecord(int treatmentRecordID)
        {
            int result;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_treatment_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TreatmentRecordID", treatmentRecordID);

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
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// A data access method that uses a stored procedure to select all treatment records in the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public List<TreatmentRecord> SelectTreatmentRecords()
        {
            List<TreatmentRecord> treatmentRecords = new List<TreatmentRecord>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_treatment_records");
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
                        var treatmentRecord = new TreatmentRecord();
                        treatmentRecord.TreatmentRecordID = reader.GetInt32(0);
                        treatmentRecord.VetID = reader.GetString(1);
                        treatmentRecord.AnimalID = reader.GetInt32(2);
                        treatmentRecord.FormName = reader.GetString(3);
                        if (reader.IsDBNull(4))
                        {
                            treatmentRecord.TreatmentDate = DateTime.Parse("01/01/2020");
                        }
                        else
                        {
                            treatmentRecord.TreatmentDate = reader.GetDateTime(4);
                        }
                        treatmentRecord.TreatmentDescription = reader.GetString(5);
                        treatmentRecord.Notes = reader.GetString(6);
                        treatmentRecord.Reason = reader.GetString(7);
                        treatmentRecord.Urgency = reader.GetInt32(8);

                        treatmentRecords.Add(treatmentRecord);
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
            return treatmentRecords;
        }

        /// <summary>
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: Timothy Lickteig
        /// 
        /// A data access method that uses a stored procedure to update a treatment record in the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="newTreatmentRecord">Updated treatment record</param>
        /// <param name="oldTreatmentRecord">Record to be updated</param>

        public int UpdateTreatmentRecord(TreatmentRecord oldTreatmentRecord, TreatmentRecord newTreatmentRecord)
        {
            // Declare the variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_treatment_record");

            // Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters
            cmd.Parameters.Add("@TreatmentRecordID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@VetID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters.Add("@FormName", SqlDbType.NVarChar);
            cmd.Parameters.Add("@TreatmentDate", SqlDbType.Date);
            cmd.Parameters.Add("@TreatmentDescription", SqlDbType.NVarChar);
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar);
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar);
            cmd.Parameters.Add("@Urgency", SqlDbType.Int);

            // Set param values
            cmd.Parameters["@TreatmentRecordID"].Value = oldTreatmentRecord.TreatmentRecordID;
            cmd.Parameters["@VetID"].Value = newTreatmentRecord.VetID;
            cmd.Parameters["@AnimalID"].Value = newTreatmentRecord.AnimalID;
            cmd.Parameters["@FormName"].Value = newTreatmentRecord.FormName;
            cmd.Parameters["@TreatmentDate"].Value = newTreatmentRecord.TreatmentDate;
            cmd.Parameters["@TreatmentDescription"].Value = newTreatmentRecord.TreatmentDescription;
            cmd.Parameters["@Notes"].Value = newTreatmentRecord.Notes;
            cmd.Parameters["@Reason"].Value = newTreatmentRecord.Reason;
            cmd.Parameters["@Urgency"].Value = newTreatmentRecord.Urgency;

            // Try to execute query
            try
            {
                conn.Open();
                rows = Convert.ToInt32(cmd.ExecuteScalar());
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
        /// Creator: Zoey McDonald
        /// Created: 3/2/2020
        /// Approver: 
        /// 
        /// A data access method that uses a stored procedure to get a treatment record by name from the database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public TreatmentRecord GetTreatmentRecordByName(string treatmentRecordName)
        {
            TreatmentRecord _treatmentRecord = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_treatment_record_by_name", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FormName", treatmentRecordName);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _treatmentRecord = new TreatmentRecord();

                    _treatmentRecord.FormName = treatmentRecordName;
                    _treatmentRecord.VetID = reader.GetString(1);
                    _treatmentRecord.AnimalID = reader.GetInt32(2);
                    _treatmentRecord.TreatmentDate = reader.GetDateTime(4);
                    _treatmentRecord.TreatmentDescription = reader.GetString(5);
                    _treatmentRecord.Notes = reader.GetString(6);
                    _treatmentRecord.Reason = reader.GetString(7);
                    _treatmentRecord.Urgency = reader.GetInt32(8);
                }
                else
                {
                    throw new ApplicationException("Volunteer Task Not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _treatmentRecord;
        }
    }
}
