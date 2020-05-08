using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// Interfaces for Transaction Admin.
    /// </summary>
    public interface ITransactionAdminAccessor
    {
        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// APPROVER: Ethan Holmes
        ///
        /// Interface method signature for inserting transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        /// <returns>rows effected</returns>
        int InsertTransactionType(TransactionType transactionType);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// APPROVER: Ethan Holmes
        ///
        /// Interface method signature for inserting transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        /// <returns>rows effected</returns>
        int InsertTransactionStatus(TransactionStatus transactionStatus);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Interface method signature for updating the transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>int</returns>
        int UpdateTransactionType(TransactionType oldTransactionType, TransactionType newTransactionType);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Interface method signature for deleting the transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>int</returns>
        int DeleteTransactionType(string transactionTypeID);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Interface method signature for updating the transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>int</returns>
        int UpdateTransactionStatus(TransactionStatus oldTransactionStatus, TransactionStatus newTransactionStatus);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        ///
        /// Interface method signature for deleting the transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>int</returns>
        int DeleteTransactionStatus(string transactionStatusID);
    }
}
