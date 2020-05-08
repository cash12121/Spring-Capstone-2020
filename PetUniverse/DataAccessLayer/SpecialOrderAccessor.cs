using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/30/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    /// 
    /// Data Access class for orders
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public class SpecialOrderAccessor : ISpecialOrderAccessor
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Selects all order Invoices
        /// </summary>
        /// <returns>List of invoices</returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public IEnumerable<SpecialOrder> SelectSpecialOrders()
        {
            List<SpecialOrder> specialOrderList = new List<SpecialOrder>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_select_all_special_orders";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    specialOrderList.Add(new SpecialOrder()
                    {
                        SpecialOrderID = reader.GetInt32(0),
                        UserID = reader.GetInt32(1)
                    });
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (IEnumerable<SpecialOrder>)specialOrderList;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Updates an Order Invoice
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="oldOrderInvoice"></param>
        /// <param name="newOrderInvoice"></param>
        /// <returns>1 if successful, 0 if not</returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public int UpdateSpecialOrder(SpecialOrder oldOrder, SpecialOrder newOrder)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_update_special_order_by_id";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SpecialOrderID", oldOrder.SpecialOrderID);
            cmd.Parameters.AddWithValue("@UserID", newOrder.UserID);
            cmd.Parameters.AddWithValue("@Active", newOrder.Active);

            cmd.Parameters.AddWithValue("@OldSpecialOrderID", oldOrder.SpecialOrderID);
            cmd.Parameters.AddWithValue("@UserID", oldOrder.UserID);
            cmd.Parameters.AddWithValue("@OldActive", oldOrder.Active);
            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex )
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
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Inserts a new Order Invoice
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="newOrder"></param>
        /// <returns>1 if successful, 0 if not</returns>
        public int InsertSpecialOrder(SpecialOrder newOrder)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_insert_special_order";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", newOrder.UserID);
            cmd.Parameters.AddWithValue("@Active", newOrder.Active);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Delets an Order Invoice according to its ID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="orderInvoiceID">ID of order to be deleted</param>
        /// <returns>1 if successful, 0 if not</returns>
        public int DeleteSpecialOrder(int specialOrderID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_delete_special_order_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SpecialOrderID", specialOrderID);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
    }
}
