using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2/27/2020
    /// Approver: Rasha Mohammed
    /// 
    /// This is a DataAccess class for TSQL it implements the ITransactionAccessor
    /// </summary>
    public class TransactionAccessor : ITransactionAccessor
    {
        // scope identity, used for transaction line products.
        int TransactionID = 0;

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 2/21/2020
        /// Approver: Jaeho Kim
        /// 
        /// Queries the SQL database for a delete item from trnsactionLine when that match the productID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="productID">The product upc number</param>
        /// <returns>rows effected</returns>
        public int DeleteItemFromTransaction(string productID)
        {
            int rows = 0;

            string cmdText = "sp_delete_Item_from_Transaction";


            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", productID);


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
        /// Created: 03/19/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for selecting a product by the product upc (productID).
        /// This is part of the search function for populating a ProductVM details 
        /// using the product upc.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="productID">The product upc number</param>
        /// <returns>ProductVM</returns>
        public ProductVM SelectProductByProductID(string productID)
        {
            ProductVM product = null;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_product_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", productID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new ProductVM();
                    product.ProductID = reader.GetString(0);
                    product.Name = reader.GetString(1);
                    product.Taxable = reader.GetBoolean(2);
                    product.Price = reader.GetDecimal(3);
                    product.ItemQuantity = reader.GetInt32(4);
                    product.ItemDescription = reader.GetString(5);
                    product.Active = reader.GetBoolean(6);
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
            return product;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for inserting a transaction.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 04/21/2020
        /// Update: Added CustomerEmail and StripeChargeID.
        /// </remarks>
        /// <param name="transaction">The transaction that is inserted to the database.</param>
        /// <returns>rows effected</returns>
        public int InsertTransaction(Transaction transaction)
        {
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionDateTime", transaction.TransactionDateTime);
            cmd.Parameters.AddWithValue("@TaxRate", transaction.TaxRate);
            cmd.Parameters.AddWithValue("@SubTotalTaxable", transaction.SubTotalTaxable);
            cmd.Parameters.AddWithValue("@SubTotal", transaction.SubTotal);
            cmd.Parameters.AddWithValue("@Total", transaction.Total);
            cmd.Parameters.AddWithValue("@TransactionTypeID", transaction.TransactionTypeID);
            cmd.Parameters.AddWithValue("@EmployeeID", transaction.EmployeeID);
            cmd.Parameters.AddWithValue("@TransactionStatusID", transaction.TransactionStatusID);
            if (transaction.CustomerEmail != null)
            {
                cmd.Parameters.AddWithValue("@CustomerEmail", transaction.CustomerEmail);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CustomerEmail", DBNull.Value);
            }
            if (transaction.StripeChargeID != null)
            {
                cmd.Parameters.AddWithValue("@StripeChargeID", transaction.StripeChargeID);
            }
            else
            {
                cmd.Parameters.AddWithValue("@StripeChargeID", DBNull.Value);
            }

            // Tax Exemption

            if (!String.IsNullOrWhiteSpace(transaction.TaxExemptNumber))
            {
                cmd.Parameters.AddWithValue("@TaxExemptNumber", transaction.TaxExemptNumber);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TaxExemptNumber", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@ReturnTransactionId", 0);



            try
            {
                conn.Open();
                TransactionID = Convert.ToInt32(cmd.ExecuteScalar());
                transaction.TransactionID = TransactionID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return TransactionID;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 04/04/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for inserting a products related to the transaction.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 4/20/2020
        /// Update: Now actually saves the quantity purchased to the database.
        /// </remarks>
        /// <param name="transactionLineProducts">
        /// The products related to the transaction that is inserted to the database.
        /// </param>
        /// <returns>rows effected</returns>
        public int InsertTransactionLineProducts(TransactionLineProducts transactionLineProducts)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_transaction_line_products", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                foreach (var item in transactionLineProducts.ProductsSold)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TransactionID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@PriceSold", SqlDbType.Decimal));

                    cmd.Parameters[0].Value = TransactionID;
                    cmd.Parameters[1].Value = item.ProductID;

                    // This is the item quantity that got purchased.
                    cmd.Parameters[2].Value = item.Quantity;

                    // This is the price that is sold for this transaction.
                    cmd.Parameters[3].Value = item.Price;
                    rows = cmd.ExecuteNonQuery();
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
        /// Created: 03/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for Selecting all products using a TransactionID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="transactionID">The transaction id that is related to the products</param>
        /// <returns>returns a list of transactions</returns>
        public List<TransactionVM> SelectAllProductsByTransactionID(int transactionID)
        {
            List<TransactionVM> products = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_products_by_transaction_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("TransactionID", transactionID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionVM transactionVM = new TransactionVM();

                    transactionVM.Quantity = reader.GetInt32(0);
                    transactionVM.ProductID = reader.GetString(1);
                    transactionVM.ProductName = reader.GetString(2);
                    transactionVM.ProductCategoryID = reader.GetString(3);
                    transactionVM.ProductTypeID = reader.GetString(4);
                    transactionVM.Price = reader.GetDecimal(5);

                    products.Add(transactionVM);
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

            return products;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for selecting the SalesTax by zipCode.
        /// This function retrieves the exact date of the latest 
        /// salesTaxDate of the ZipCode. The tax rate is NOT 
        /// included.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="zipCode">the zip code of the sales tax rate</param>
        /// <returns>DateTime of the sales tax rate of the zip code</returns>
        public DateTime SelectLatestSalesTaxDateByZipCode(string zipCode)
        {
            DateTime salesTaxDate = DateTime.Now;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_latest_salesTaxDate_by_zipCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ZipCode", zipCode);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        salesTaxDate = reader.GetDateTime(0);
                    }
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

            return salesTaxDate;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/19/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for selecting the Sales Tax Rate by zipCode 
        /// and salesTaxDate.
        /// This function retrieves the sales tax rate of the latest 
        /// salesTaxDate of the ZipCode.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="zipCode">the zip code of the sales tax rate</param>
        /// <param name="salesTaxDate">the date of the sales tax rate</param>
        /// <returns>TaxRate</returns>
        public decimal SelectTaxRateBySalesTaxDateAndZipCode(string zipCode, DateTime salesTaxDate)
        {
            decimal taxRate = 0.0M;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_taxRate_by_salesTaxDate_and_zipCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ZipCode", zipCode);
            cmd.Parameters.AddWithValue("@SalesTaxDate", salesTaxDate);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        taxRate = reader.GetDecimal(0);
                    }
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

            return taxRate;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for Selecting all transactions using a TransactionDate.
        /// and salesTaxDate.
        /// This function retrieves the sales tax rate of the latest 
        /// salesTaxDate of the ZipCode.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 04/20/2020
        /// Update: Added CustomerEmail and StripeChargeID
        /// </remarks>
        /// <param name="transactionDate">the date of the transaction</param>
        /// <returns>returns a list of transactions</returns>
        public List<TransactionVM> SelectTransactionsByTransactionDate(DateTime transactionDate, DateTime secondTransactionDate)
        {
            List<TransactionVM> transactions = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_transactions_by_datetime", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionDateTime", transactionDate);
            cmd.Parameters.AddWithValue("@SecondTransactionDateTime", secondTransactionDate);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionVM transactionVM = new TransactionVM();

                    transactionVM.TransactionID = reader.GetInt32(0);
                    transactionVM.TransactionDateTime = reader.GetDateTime(1);
                    transactionVM.EmployeeID = reader.GetInt32(2);
                    transactionVM.FirstName = reader.GetString(3);
                    transactionVM.LastName = reader.GetString(4);
                    transactionVM.TransactionTypeID = reader.GetString(5);
                    transactionVM.TransactionStatusID = reader.GetString(6);
                    transactionVM.TaxRate = reader.GetDecimal(7);
                    transactionVM.SubTotalTaxable = reader.GetDecimal(8);
                    transactionVM.SubTotal = reader.GetDecimal(9);
                    transactionVM.Total = reader.GetDecimal(10);
                    if (!reader.IsDBNull(11))
                    {
                        transactionVM.CustomerEmail = reader.GetString(11);

                    }
                    if (!reader.IsDBNull(12))
                    {
                        transactionVM.StripeChargeID = reader.GetString(12);
                    }

                    transactions.Add(transactionVM);
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

            return transactions;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/08/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Implementation for Selecting all transactions using a employee name.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 04/24/2020
        /// Update: Added CustomerEmail and StripeChargeID
        /// </remarks>
        /// <param name="firstName">the first name of the employee</param>
        /// <param name="lastName">the last name of the employee</param>
        /// <returns>returns a list of transactions</returns>
        public List<TransactionVM> SelectTransactionsByEmployeeName(string firstName, string lastName)
        {
            List<TransactionVM> transactions = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_transactions_by_employee_name", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("FirstName", firstName);
            cmd.Parameters.AddWithValue("LastName", lastName);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionVM transactionVM = new TransactionVM();

                    transactionVM.TransactionID = reader.GetInt32(0);
                    transactionVM.TransactionDateTime = reader.GetDateTime(1);
                    transactionVM.EmployeeID = reader.GetInt32(2);
                    transactionVM.FirstName = reader.GetString(3);
                    transactionVM.LastName = reader.GetString(4);
                    transactionVM.TransactionTypeID = reader.GetString(5);
                    transactionVM.TransactionStatusID = reader.GetString(6);
                    transactionVM.TaxRate = reader.GetDecimal(7);
                    transactionVM.SubTotalTaxable = reader.GetDecimal(8);
                    transactionVM.SubTotal = reader.GetDecimal(9);
                    transactionVM.Total = reader.GetDecimal(10);
                    if (!reader.IsDBNull(11))
                    {
                        transactionVM.CustomerEmail = reader.GetString(11);

                    }
                    if (!reader.IsDBNull(12))
                    {
                        transactionVM.StripeChargeID = reader.GetString(12);
                    }

                    transactions.Add(transactionVM);
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

            return transactions;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        /// 
        /// Implementation for Selecting all transactions using a transaction id.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 04/24/2020
        /// Update: Added CustomerEmail and StripeChargeID
        /// </remarks>
        /// <param name="transactionID"></param>
        /// <returns>returns a list of transactions</returns>
        public List<TransactionVM> SelectTransactionsByTransactionID(int transactionID)
        {
            List<TransactionVM> transactions = new List<TransactionVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_transactions_by_transaction_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TransactionID", transactionID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionVM transactionVM = new TransactionVM();

                    transactionVM.TransactionID = reader.GetInt32(0);
                    transactionVM.TransactionDateTime = reader.GetDateTime(1);
                    transactionVM.EmployeeID = reader.GetInt32(2);
                    transactionVM.FirstName = reader.GetString(3);
                    transactionVM.LastName = reader.GetString(4);
                    transactionVM.TransactionTypeID = reader.GetString(5);
                    transactionVM.TransactionStatusID = reader.GetString(6);
                    transactionVM.TaxRate = reader.GetDecimal(7);
                    transactionVM.SubTotalTaxable = reader.GetDecimal(8);
                    transactionVM.SubTotal = reader.GetDecimal(9);
                    transactionVM.Total = reader.GetDecimal(10);
                    if (!reader.IsDBNull(11))
                    {
                        transactionVM.CustomerEmail = reader.GetString(11);

                    }
                    if (!reader.IsDBNull(12))
                    {
                        transactionVM.StripeChargeID = reader.GetString(12);
                    }

                    transactions.Add(transactionVM);
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

            return transactions;
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/11/2020
        /// Approver: Robert Holmes
        ///
        /// Implementation for selecting a product by the product upc (productID) to change its price.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>ProductVM</returns>
        public int UpdateProduct(ProductVM oldProduct, ProductVM newProduct)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_product_price", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductID", oldProduct.ProductID);


            cmd.Parameters.AddWithValue("@NewPrice", newProduct.Price);

            cmd.Parameters.AddWithValue("@OldPrice", oldProduct.Price);


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
        /// Created: 4/23/2020
        /// Approver: Robert Holmes
        ///
        /// Implementation for selecting transaction types.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>ProductVM</returns>
        public List<TransactionType> SelectAllTransactionTypes()
        {
            List<TransactionType> transactionTypes = new List<TransactionType>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_transaction_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionType transactionType = new TransactionType();

                    transactionType.TransactionTypeID = reader.GetString(0);
                    transactionType.Description = reader.GetString(1);
                    transactionType.DefaultInStore = reader.GetBoolean(2);

                    transactionTypes.Add(transactionType);
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

            return transactionTypes;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/24/2020
        /// Approver: Robert Holmes
        ///
        /// Implementation for selecting transaction status.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TransactionStatus list</returns>
        public List<TransactionStatus> SelectAllTransactionStatus()
        {
            List<TransactionStatus> transactionStatuses = new List<TransactionStatus>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_transaction_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransactionStatus transactionStatus = new TransactionStatus();

                    transactionStatus.TransactionStatusID = reader.GetString(0);
                    transactionStatus.Description = reader.GetString(1);
                    transactionStatus.DefaultInStore = reader.GetBoolean(2);

                    transactionStatuses.Add(transactionStatus);
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

            return transactionStatuses;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/23/2020
        /// Approver: Robert Holmes
        ///
        /// Implementation for selecting default transaction type.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TransactionType</returns>
        public TransactionType SelectDefaultTransactionType()
        {
            var transactionType = new TransactionType();
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_default_transaction_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    transactionType.TransactionTypeID = reader.GetString(0);
                    transactionType.Description = reader.GetString(1);
                    transactionType.DefaultInStore = reader.GetBoolean(2);
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
            return transactionType;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/24/2020
        /// Approver: Robert Holmes
        ///
        /// Implementation for selecting default transaction status.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>TransactionStatus</returns>
        public TransactionStatus SelectDefaultTransactionStatus()
        {
            var transactionStatus = new TransactionStatus();
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_default_transaction_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    transactionStatus.TransactionStatusID = reader.GetString(0);
                    transactionStatus.Description = reader.GetString(1);
                    transactionStatus.DefaultInStore = reader.GetBoolean(2);
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
            return transactionStatus;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 4/25/2020
        /// Approver: Robert Holmes
        ///
        /// Implementation for adjusting item quantity
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>int</returns>
        public int UpdateItemQuantity(TransactionLineProducts transactionLineProducts)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_item_quantity", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                foreach (var item in transactionLineProducts.ProductsSold)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@TransactionID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar));


                    cmd.Parameters[0].Value = TransactionID;
                    cmd.Parameters[1].Value = item.ProductID;

                    rows = cmd.ExecuteNonQuery();
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
        /// Creator: Zach Behrensmeye
        /// Created: 4/29/2020
        /// Approver: Steven Cardona
        ///
        /// This code gets transactions by customer email to display them for the customer
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<Transaction> GetTransactionsByCustomerEmail(string email)
        {
            List<Transaction> transactions = new List<Transaction>();
            
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_transactions_by_customer_email", conn);
            cmd.Parameters.AddWithValue("@CustomerEmail", email);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transactions.Add(new Transaction()
                    {
                        TransactionID = reader.GetInt32(0),
                        TransactionDateTime = reader.GetDateTime(1),
                        SubTotal = reader.GetDecimal(2),
                        Total = reader.GetDecimal(3)
                    });                    
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
            return transactions;
        }
    }
}
