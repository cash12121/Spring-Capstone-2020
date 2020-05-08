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
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Order line data access layer
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: Jesse Tomash
    /// Update:
    /// </remarks>
    public class OrderLineAccessor : IOrderLineAccessor
    {

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// Method to create orderLine
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool createOrderLine(OrderLine orderLine)
        {
            bool result = false;

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_create_orderLine", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameters
            cmd.Parameters.AddWithValue("@ItemID", orderLine.ItemID);
            cmd.Parameters.AddWithValue("@ReceivingRecordID", orderLine.ReceivingRecordID);
            cmd.Parameters.AddWithValue("@DamagedItemQuantity", orderLine.DamagedItemQuantity);
            cmd.Parameters.AddWithValue("@MissingItemQuantity", orderLine.MissingItemQuantity);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// method to delete orderLine
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool deleteOrderLine(OrderLine orderLine)
        {
            bool result = false;

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_delete_orderLine", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameters
            cmd.Parameters.AddWithValue("@OrderLineID", orderLine.OrderLineID);
            cmd.Parameters.AddWithValue("@ItemID", orderLine.ItemID);
            cmd.Parameters.AddWithValue("@ReceivingRecordID", orderLine.ReceivingRecordID);
            cmd.Parameters.AddWithValue("@DamagedItemQuantity", orderLine.DamagedItemQuantity);
            cmd.Parameters.AddWithValue("@MissingItemQuantity", orderLine.MissingItemQuantity);


            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// method to select all orderLines
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<OrderLine> selectAllOrderLines()
        {
            List<OrderLine> orderLineList = new List<OrderLine>();

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_select_orderLines");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                // Execute Command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderLine orderLine = new OrderLine();

                        orderLine.OrderLineID = reader.GetInt32(0);
                        orderLine.ItemID = reader.GetInt32(1);
                        orderLine.ReceivingRecordID = reader.GetInt32(2);
                        orderLine.DamagedItemQuantity = reader.GetInt32(3);
                        orderLine.MissingItemQuantity = reader.GetInt32(4);
                        orderLineList.Add(orderLine);
                    }

                }
                else
                {
                    throw new ApplicationException("OrderLines not found");
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

            return orderLineList;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Selects all order lines by receiving record id
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<OrderLine> SelectOrderLineByReceivingRecordID(int ReceivingRecordID)
        {
            List<OrderLine> orderLineList = new List<OrderLine>();

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_select_orderline_by_receivingrecordid");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameters
            cmd.Parameters.Add("@ReceivingRecordID", SqlDbType.Int);
            cmd.Parameters["@ReceivingRecordID"].Value = ReceivingRecordID;

            try
            {
                // Open Connection
                conn.Open();

                // Execute Command
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderLine orderLine = new OrderLine();

                        orderLine.OrderLineID = reader.GetInt32(0);
                        orderLine.ItemID = reader.GetInt32(1);
                        orderLine.ReceivingRecordID = reader.GetInt32(2);
                        orderLine.DamagedItemQuantity = reader.GetInt32(3);
                        orderLine.MissingItemQuantity = reader.GetInt32(4);
                        orderLineList.Add(orderLine);
                    }

                }
                else
                {
                    throw new ApplicationException("OrderLines not found");
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
            return orderLineList;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Updates order line
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int UpdateOrderLine(OrderLine oldOrderLine, OrderLine newOrderLine)
        {
            int rowsAffected = 0;

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_update_orderline", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameters
            cmd.Parameters.AddWithValue("@OrderLineId", oldOrderLine.OrderLineID);

            cmd.Parameters.AddWithValue("@NewItemID", newOrderLine.ItemID);
            cmd.Parameters.AddWithValue("@NewReceivingRecordID", newOrderLine.ReceivingRecordID);
            cmd.Parameters.AddWithValue("@NewDamagedItemQuantity", newOrderLine.DamagedItemQuantity);
            cmd.Parameters.AddWithValue("@NewMissingItemQuantity", newOrderLine.MissingItemQuantity);

            cmd.Parameters.AddWithValue("@OldItemID", oldOrderLine.ItemID);
            cmd.Parameters.AddWithValue("@OldReceivingRecordID", oldOrderLine.ReceivingRecordID);
            cmd.Parameters.AddWithValue("@OldDamagedItemQuantity", oldOrderLine.DamagedItemQuantity);
            cmd.Parameters.AddWithValue("@OldMissingItemQuantity", oldOrderLine.MissingItemQuantity);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }
    }
}
