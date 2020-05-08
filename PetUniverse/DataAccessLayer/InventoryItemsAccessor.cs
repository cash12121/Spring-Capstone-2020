using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 2020/02/21
    /// Approver: Zach Behrensmeyer
    ///
    /// Accessor class for selecting inventory items
    /// </summary>
    public class InventoryItemsAccessor : IInventoryItemsAccessor
    {
        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// Method to get Inventory Items
        /// </summary>
        /// <remarks>
        /// Updater Cash Carlson
        /// Updated: 2020/04/29
        /// Update: Updated to add active field
        /// </remarks>
        /// <returns>A List of Inventory Items</returns>
        public List<InventoryItems> SelectAllInventory()
        {
            List<InventoryItems> inventoryItems = new List<InventoryItems>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_products_items");
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
                        var inventoryItem = new InventoryItems();
                        inventoryItem.ProductID = reader.GetString(0);
                        inventoryItem.Name = reader.GetString(1);
                        inventoryItem.Brand = reader.GetString(2);
                        inventoryItem.Category = reader.GetString(3);
                        inventoryItem.Type = reader.GetString(4);
                        inventoryItem.Price = reader.GetDecimal(5);
                        inventoryItem.Quantity = reader.GetInt32(6);
                        inventoryItem.Active = reader.GetBoolean(7);

                        inventoryItems.Add(inventoryItem);
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
            return inventoryItems;
        }
    }
}
