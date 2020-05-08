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
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: 
    /// Approver: 
    ///
    /// Accessor for receiving records
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class ReceivingRecordAccessor : IReceivingRecordAccessor
    {

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: 
        /// Approver: 
        ///
        /// Selects all receiving records
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<ReceivingRecord> SelectAllReceivingRecords()
        {
            List<ReceivingRecord> receivingRecords = new List<ReceivingRecord>();

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Object
            var cmd = new SqlCommand("sp_select_all_receivingrecords");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameter

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var receivingRecord = new ReceivingRecord();

                        receivingRecord.ReceivingRecordID = reader.GetInt32(0);
                        receivingRecord.OrderID = reader.GetInt32(1);
                        receivingRecord.ShipperID = reader.GetString(2);
                        receivingRecord.ReceivingOrderDate = reader.GetDateTime(3);
                        receivingRecords.Add(receivingRecord);
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

            return receivingRecords;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: 
        /// Approver: 
        ///
        /// Selects receiving records by orderID
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ReceivingRecord SelectReceivingRecordbyOrderID(int OrderID)
        {
            ReceivingRecord receivingRecord = new ReceivingRecord();

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Object
            var cmd = new SqlCommand("sp_select_receiving_record_by_orderID");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameter
            cmd.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    receivingRecord.ReceivingRecordID = reader.GetInt32(0);
                    receivingRecord.OrderID = reader.GetInt32(1);
                    receivingRecord.ShipperID = reader.GetString(2);
                    receivingRecord.ReceivingOrderDate = reader.GetDateTime(3);
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

            return receivingRecord;
        }
    }
}
