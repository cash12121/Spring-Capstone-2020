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
    /// Created: 2020/04/13
    /// Approver: Rob Holmes
    /// 
    /// Implementations for Sales Tax.
    /// </summary>
    public class SalesTaxAccessor : ISalesTaxAccessor
    {

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// APPROVER: Rob Holmes
        ///
        /// Implementation for Inserting Sales Tax Data.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="salesTax"></param>
        /// <returns>rows effected.</returns>
        public int InsertSalesTax(SalesTax salesTax)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_sales_tax", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ZipCode", salesTax.ZipCode);
            cmd.Parameters.AddWithValue("@TaxRate", salesTax.TaxRate);
            cmd.Parameters.AddWithValue("@SalesTaxDate", salesTax.TaxDate);


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

        public List<SalesTax> SelectAllSalesTax()
        {
            var salesTaxes = new List<SalesTax>();

            var conn = DBConnection.GetConnection();
            var cmdText = "sp_select_all_sales_tax";

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        salesTaxes.Add(new SalesTax
                        {
                            ZipCode = reader.GetString(0),
                            TaxDate = reader.GetDateTime(1),
                            TaxRate = reader.GetDecimal(2)
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return salesTaxes;
        }
    }
}
