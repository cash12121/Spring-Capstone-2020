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
    /// DATE: 2/18/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: Dalton Reierson
    /// 
    /// Data Access class for orders
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public class OrderAccessor : IOrderAccessor
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// Selects all order Invoices
        /// </summary>
        /// <returns>List of invoices</returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public IEnumerable<Order> SelectOrders()
        {
            List<Order> orderList = new List<Order>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_select_all_orders";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orderList.Add(new Order()
                    {
                        OrderID = reader.GetInt32(0),
                        UserID = reader.GetInt32(1)
                    });
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
            return (IEnumerable<Order>)orderList;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
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
        public int UpdateOrder(Order oldOrder, Order newOrder)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_update_order_by_id";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", oldOrder.OrderID);
            cmd.Parameters.AddWithValue("@UserID", newOrder.UserID);
            cmd.Parameters.AddWithValue("@Active", newOrder.Active);

            cmd.Parameters.AddWithValue("@OldOrderID", oldOrder.OrderID);
            cmd.Parameters.AddWithValue("@OldUserID", oldOrder.UserID);
            cmd.Parameters.AddWithValue("@OldActive", oldOrder.Active);
            try
            {
                conn.Open();
                cmd.ExecuteScalar();
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
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// Inserts a new Order Invoice
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="newOrder"></param>
        /// <returns>1 if successful, 0 if not</returns>
        public int InsertOrder(Order newOrder)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_insert_order";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", newOrder.UserID);
            cmd.Parameters.AddWithValue("@Active", newOrder.Active);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
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
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: Dalton Reierson
        /// 
        /// Delets an Order Invoice according to its ID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="orderInvoiceID">ID of order to be deleted</param>
        /// <returns>1 if successful, 0 if not</returns>
        public bool DeleteOrder(int orderID)
        {
            bool isDeleted = false;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_delete_order_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderID);

            try
            {
                conn.Open();
                isDeleted = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return isDeleted;
        }
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Methods to update orderStatus
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int UpdateOrderStatus(Order order, string orderStatus)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_update_order_status_by_orderID";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NewOrderStatus", orderStatus);
            cmd.Parameters.AddWithValue("@OldOrderID", order.OrderID);
            cmd.Parameters.AddWithValue("@OldEmployeeID", order.UserID);
            cmd.Parameters.AddWithValue("@OldActive", order.Active);
            cmd.Parameters.AddWithValue("@OldOrderStatus", order.OrderStatus);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
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
