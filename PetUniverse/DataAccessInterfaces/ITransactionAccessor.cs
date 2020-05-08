using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 02/27/2020
    /// Approver: Rasha Mohammed
    /// 
    /// Interfaces for Transactions.
    /// </summary>
    public interface ITransactionAccessor
    {

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/03/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for Selecting all products using a TransactionID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="transactionID"</param>
        /// <returns>The transaction vm the end user needs to see.</returns>
        List<TransactionVM> SelectAllProductsByTransactionID(int transactionID);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/05/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for retrieving all transactions by date.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionDate">Initial date</param>
        /// <param name="secondTransactionDate">Final Date</param>
        /// <returns>The transaction vm the end user needs to see.</returns>
        List<TransactionVM> SelectTransactionsByTransactionDate(DateTime transactionDate, DateTime secondTransactionDate);

        /// Creator: Rasha Mohammed
        /// Created: 2/14/2020
        /// APPROVER: Jaeho Kim
        ///
        /// The method is used to delete the products on the transactionLine by selecting the product ID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="productID"</param>
        /// <returns>Rows effected</returns>
        int DeleteItemFromTransaction(string productID);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for inserting a transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="transaction"</param>
        /// <returns>Rows effected</returns>
        int InsertTransaction(Transaction transaction);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for inserting products related to transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="transactionLineProducts"</param>
        /// <returns>Rows effected</returns>
        int InsertTransactionLineProducts(TransactionLineProducts transactionLineProducts);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for selecting the exact latest sales tax date of the zipcode entered.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="zipCode"</param>
        /// <returns>the exact latest date of the sales tax rate of the zip code</returns>
        DateTime SelectLatestSalesTaxDateByZipCode(string zipCode);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for selecting the sales tax rate of the zipcode entered, 
        /// and the exact date entered.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="zipCode"</param>
        /// <param>name="salesTaxDate"</param>
        /// <returns>The actual tax rate of the zip code and the tax date</returns>
        decimal SelectTaxRateBySalesTaxDateAndZipCode(string zipCode, DateTime salesTaxDate);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 04/04/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for selecting the product by product id. 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="productID"</param>
        /// <returns>The product vm</returns>
        ProductVM SelectProductByProductID(string productID);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/08/2020
        /// APPROVER: Rasha Mohammed
        ///
        /// Interface method signature for Selecting transactions using a Employee Name.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param>name="firstName"</param>
        /// <param>name="lastName"</param>
        /// <returns>the transaction vm</returns>
        List<TransactionVM> SelectTransactionsByEmployeeName(string firstName, string lastName);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// APPROVER: Rob Holmes
        ///
        /// Interface method signature for Selecting transactions using a transaction id.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="transactionID"></param>
        /// <returns>the transaction vm</returns>
        List<TransactionVM> SelectTransactionsByTransactionID(int transactionID);

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/11/2020
        /// Approver: Robert Holmes
        ///
        /// Interface method signature for updating the price on transaction
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int UpdateProduct(ProductVM oldProduct, ProductVM newProduct);

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/23
        /// APPROVER: Robert Holmes
        ///
        /// Interface method signature for selecting all transaction types.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TransactionTypes</returns>
        List<TransactionType> SelectAllTransactionTypes();

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// APPROVER: Robert Holmes
        ///
        /// Interface method signature for selecting all transaction status.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Transactionstatus list</returns>
        List<TransactionStatus> SelectAllTransactionStatus();

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/23
        /// APPROVER: Robert Holmes
        ///
        /// Interface method signature for selecting default transaction type
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TransactionType</returns>
        TransactionType SelectDefaultTransactionType();

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// APPROVER: Robert Holmes
        ///
        /// Interface method signature for selecting default transaction status
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TransactionStatus</returns>
        TransactionStatus SelectDefaultTransactionStatus();

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/25
        /// Approver: Robert Holmes
        ///
        /// Interface method signature for updating the item quantity (quantity in stock)
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>int</returns>
        int UpdateItemQuantity(TransactionLineProducts transactionLineProducts);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        ///
        /// Interface method signature for getting transaction by customer email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        List<Transaction> GetTransactionsByCustomerEmail(string email);

    }
}
