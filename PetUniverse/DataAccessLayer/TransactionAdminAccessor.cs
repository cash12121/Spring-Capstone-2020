using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// This class deals with setting up data that 
    /// the transaction entry use case requires. 
    /// The transaction entry depends on the data, 
    /// transaction type and status. The head 
    /// cashier puts this data into the database 
    /// in which the transaction entry can function.
    /// </summary>
    public class TransactionAdminAccessor : ITransactionAdminAccessor
    {
        

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Implementation for inserting a transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        /// <returns>rows effected</returns>
        public int InsertTransactionStatus(TransactionStatus transactionStatus)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionStatusID", transactionStatus.TransactionStatusID);
            cmd.Parameters.AddWithValue("@Description", transactionStatus.Description);
            cmd.Parameters.AddWithValue("@DefaultInStore", transactionStatus.DefaultInStore);

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
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Implementation for inserting a transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        /// <returns>rows effected</returns>
        public int InsertTransactionType(TransactionType transactionType)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionTypeID", transactionType.TransactionTypeID);
            cmd.Parameters.AddWithValue("@Description", transactionType.Description);
            cmd.Parameters.AddWithValue("@DefaultInStore", transactionType.DefaultInStore);

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
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Implementation method signature for updating the transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="newTransactionType"></param>
        /// <param name="oldTransactionType"></param>
        /// <returns>int</returns>
        public int UpdateTransactionType(TransactionType oldTransactionType, TransactionType newTransactionType)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_transaction_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NewTransactionTypeID", newTransactionType.TransactionTypeID);
            cmd.Parameters.AddWithValue("@NewDescription", newTransactionType.Description);
            cmd.Parameters.AddWithValue("@NewDefaultInStore", newTransactionType.DefaultInStore);

            cmd.Parameters.AddWithValue("@OldTransactionTypeID", oldTransactionType.TransactionTypeID);
            cmd.Parameters.AddWithValue("@OldDescription", oldTransactionType.Description);
            cmd.Parameters.AddWithValue("@OldDefaultInStore", oldTransactionType.DefaultInStore);
            

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ApplicationException("Could Not Find Record.");
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

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Implementation method signature for deleting the transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionTypeID"></param>
        /// <returns>int</returns>
        public int DeleteTransactionType(string transactionTypeID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_transaction_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransactionTypeID", transactionTypeID);

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
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        ///
        /// Implementation method signature for updating the transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="oldTransactionStatus"></param>
        /// <param name="newTransactionStatus"></param>
        public int UpdateTransactionStatus(TransactionStatus oldTransactionStatus, TransactionStatus newTransactionStatus)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_transaction_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NewTransactionStatusID", newTransactionStatus.TransactionStatusID);
            cmd.Parameters.AddWithValue("@NewDescription", newTransactionStatus.Description);
            cmd.Parameters.AddWithValue("@NewDefaultInStore", newTransactionStatus.DefaultInStore);

            cmd.Parameters.AddWithValue("@OldTransactionStatusID", oldTransactionStatus.TransactionStatusID);
            cmd.Parameters.AddWithValue("@OldDescription", oldTransactionStatus.Description);
            cmd.Parameters.AddWithValue("@OldDefaultInStore", oldTransactionStatus.DefaultInStore);


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ApplicationException("Could Not Find Record.");
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

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Implementation method signature for deleting the transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionStatusID"></param>
        /// <returns>int</returns>
        public int DeleteTransactionStatus(string transactionStatusID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_transaction_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransactionStatusID", transactionStatusID);

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
