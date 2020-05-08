using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// This class calls the data accessor functions.
    /// </summary>
    public interface ITransactionAdminManager
    {

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Interface for inserting a transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionType"></param>
        /// <returns>bool (success or failure)</returns>
        bool AddTransactionType(TransactionType transactionType);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Interface for inserting a transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionStatus"></param>
        /// <returns>bool (success or failure)</returns>
        bool AddTransactionStatus(TransactionStatus transactionStatus);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        /// 
        /// Interface for updating a transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="oldTransactionType"></param>
        /// <param name="newTransactionType"></param>
        /// <returns>bool (success or failure)</returns>
        bool EditTransactionType(TransactionType oldTransactionType, TransactionType newTransactionType);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        /// 
        /// Interface for deleting a transaction type.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionTypeID"></param>
        /// <returns>bool (success or failure)</returns>
        bool DeleteTransactionType(string transactionTypeID);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        /// 
        /// Interface for updating a transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="oldTransactionStatus"></param>
        /// <param name="newTransactionStatus"></param>
        /// <returns>bool (success or failure)</returns>
        bool EditTransactionStatus(TransactionStatus oldTransactionStatus, TransactionStatus newTransactionStatus);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: NA
        /// 
        /// Interface for deleting a transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionStatusID"></param>
        /// <returns>bool (success or failure)</returns>
        bool DeleteTransactionStatus(string transactionStatusID);
    }
}
