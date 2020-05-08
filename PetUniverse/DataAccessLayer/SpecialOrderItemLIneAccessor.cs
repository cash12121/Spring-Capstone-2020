using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 4/27/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// 
    /// Data Access class for orderitemline
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public class SpecialOrderItemLineAccessor : ISpecialOrderItemLineAccessor
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// Selects orderitem lines by order id
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public IEnumerable<SpecialOrderItemLine> SelectSpecialOrderItemLinesByOrderID(int OrderID)
        {
            List<SpecialOrderItemLine> lineList = new List<SpecialOrderItemLine>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_select_special_order_item_lines_by_order_id";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SpecialOrderID", OrderID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lineList.Add(new SpecialOrderItemLine()
                    {
                        SpecialOrderID = reader.GetInt32(0),
                        ItemID = reader.GetInt32(1)
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
            return (IEnumerable<SpecialOrderItemLine>)lineList;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// Inserts a new Order-Item Line
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <returns>1 if successful, 0 if not</returns>
        public bool InsertSpecialOrderItemLine(SpecialOrderItemLine newLine)
        {
            bool isInserted = false;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_insert_special_order_item_line";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SpecialOrderID", newLine.SpecialOrderID);
            cmd.Parameters.AddWithValue("@ItemID", newLine.ItemID);
            cmd.Parameters.AddWithValue("@Quantity", newLine.Quantity);

            try
            {
                conn.Open();
                isInserted = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return isInserted;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/26/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// 
        /// Delets an order item line by item id
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <returns>1 if successful, 0 if not</returns>
        public bool DeleteSpecialOrderItemLineByItemID(int itemID)
        {
            bool isDeleted = false;
            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_delete_special_order_item_line_by_item_id";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemID", itemID);

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
    }
}
