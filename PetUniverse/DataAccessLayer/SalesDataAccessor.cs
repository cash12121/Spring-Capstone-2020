using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Name: Cash Carlson
    /// Date: 03/19/2020
    /// Approver: Rob Holmes
    /// 
    /// This class is used to call Sales Data from the database and all things
    /// related.
    /// </summary>
	public class SalesDataAccessor : ISalesDataAccessor
	{

        /// <summary>
        /// Name: Cash Carlson
        /// Date: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// A method to call to the database to get all employee product sales data
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<SalesDataVM> RetrieveAllEmployeeSalesData(int employeeID)
        {
            List<SalesDataVM> salesData = new List<SalesDataVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_all_sales_by_employee_id");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var salesDatum = new SalesDataVM();
                        salesDatum.ProductID = reader.GetString(0);
                        salesDatum.ProductName = reader.GetString(1);
                        salesDatum.Brand = reader.GetString(2);
                        salesDatum.ProductCategory = reader.GetString(3);
                        salesDatum.ProductType = reader.GetString(4);
                        salesDatum.TotalSold = reader.GetInt32(5);


                        salesData.Add(salesDatum);
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
            return salesData;
        }

        /// <summary>
        /// Name: Cash Carlson
        /// Date: 03/19/2020
        /// Approver: Rob Holmes
        /// 
        /// A method to call to the database to get all product sales data
        /// </summary>
        /// <returns></returns>
        public List<SalesDataVM> RetrieveAllTotalSalesData()
		{
            List<SalesDataVM> salesData = new List<SalesDataVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_total_items_sold");
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
                        var salesDatum = new SalesDataVM();
                        salesDatum.ProductID = reader.GetString(0);
                        salesDatum.ProductName = reader.GetString(1);
                        salesDatum.Brand = reader.GetString(2);
                        salesDatum.ProductCategory = reader.GetString(3);
                        salesDatum.ProductType = reader.GetString(4);
                        salesDatum.TotalSold = reader.GetInt32(5);


                        salesData.Add(salesDatum);
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
            return salesData;
        }
    }
}
