using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The Accessor class for Item.
    /// </summary>
    public class ItemAccessor : IItemAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method to create a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool addNewItem(Item item)
        {
            bool result = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_items", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);
            cmd.Parameters.AddWithValue("@ItemCategoryID", item.ItemCategoryID);
            cmd.Parameters.AddWithValue("@ItemDescription", item.Description);

            try
            {
                conn.Open();
                result = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method that gets a list of all items for inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: Brandyn T. Coverdill
        /// Updated: 2020/03/03
        /// Update: The Item Description was not getting fetched into the datagrid, so I added that field.
        /// Approver:  Jesse Tomash
        /// 
        /// Updated By: Matt Deaton
        /// Updated: 2020-03-07
        /// Update: Added ShelterItem field to show in retrieved list
        /// 
        /// </remarks>
        public List<Item> getAllItems()
        {
            List<Item> items = new List<Item>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_retrieve_items", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new Item()
                    {
                        ItemID = reader.GetInt32(0),
                        ItemName = reader.GetString(1),
                        ItemQuantity = reader.GetInt32(2),
                        ItemCategoryID = reader.GetString(3),
                        Description = reader.GetString(4),
                        Active = reader.GetBoolean(5),
                        ShelterItem = reader.GetBoolean(6),
                        ShelterThreshold = reader.IsDBNull(7) ? 0 : reader.GetInt32(7)
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

            return items;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: 
        /// Approver:  
        ///
        /// Method that updates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="newDesc"></param>
        /// <param name="newName"></param>
        /// <param name="newQuantity"></param>
        /// <param name="oldDesc"></param>
        /// <param name="oldName"></param>
        /// <param name="oldQuantity"></param>
        public int updateItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_specific_item", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OldItemName", oldName);
            cmd.Parameters.AddWithValue("@OldItemDescription", oldDesc);
            cmd.Parameters.AddWithValue("@OldItemQuantity", oldQuantity);
            cmd.Parameters.AddWithValue("@NewItemName", newName);
            cmd.Parameters.AddWithValue("@NewItemDescription", newDesc);
            cmd.Parameters.AddWithValue("@NewItemQuantity", newQuantity);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conn.Close();
            }

            return result;
        }


        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/09
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesee Tomash
        ///
        /// Method to select all items by active field
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: Robert Holmes
        /// Updated: 04/29/2020
        /// Update: Made it safe to attempt when description is null.
        /// 
        /// Updated By: Brandyn T. Coverdill
        /// Updated: 4/29/2020
        /// Update: Added the ShelterItem field for item.
        /// </remarks>
        public List<Item> getAllItemsByActive(bool active)
        {
            List<Item> itemList = new List<Item>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_items_by_active", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item();
                    item.ItemID = reader.GetInt32(0);
                    item.ItemName = reader.GetString(1);
                    item.ItemQuantity = reader.GetInt32(2);
                    item.ItemCategoryID = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                    {
                        item.Description = reader.GetString(4);
                    }
                    //item.Active = reader.GetBoolean(5);
                    item.ShelterItem = reader.GetBoolean(5);
                    itemList.Add(item);
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

            return itemList;
        }


        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/09
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesee Tomash
        ///
        /// Method to set active to 0 for one item
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public int deactivateItem(Item item)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_item", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@ItemCategoryID", item.ItemCategoryID);
            cmd.Parameters.AddWithValue("@ItemDescription", item.Description);
            cmd.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);

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


        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-07
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to add a new donation item to the shelter inventory.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// <param name="donatedItem"></param>
        /// <returns></returns>
        public int AddNewDonatedItem(Item donatedItem)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_new_physical_donation", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemName", donatedItem.ItemName);
            cmd.Parameters.AddWithValue("@ItemCategoryID", donatedItem.ItemCategoryID);
            cmd.Parameters.AddWithValue("@ItemQuantity", donatedItem.ItemQuantity);
            cmd.Parameters.AddWithValue("@ItemDescription", donatedItem.Description);
            cmd.Parameters.AddWithValue("@ShelterItem", donatedItem.ShelterItem);
            cmd.Parameters.AddWithValue("@ShelterThershold", donatedItem.ShelterThreshold);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }// End AddNewDonationItem()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-07
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to return a list of needed shelter items.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="shelterThreshold"></param>
        /// <returns></returns>
        public List<Item> SelectNeededShelterItems()
        {

            List<Item> items = new List<Item>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_needed_donations", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(new Item()
                        {
                            ItemName = reader.GetString(0),
                            ItemCategoryID = reader.GetString(1),
                            ItemQuantity = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            ShelterItem = reader.GetBoolean(4),
                            ItemID = reader.GetInt32(5),
                            ShelterThreshold = reader.GetInt32(6)
                        });

                    }
                    reader.Close();
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            return items;
        }// End SelectNeededShelterItems()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-06
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to return a list of shelter use items.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// <returns>List of Items marked for shelter use</returns>
        public List<Item> SelectShelterItems(bool shelterItem)
        {
            List<Item> items = new List<Item>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_shelter_items", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ShelterItem", SqlDbType.Bit);
            cmd.Parameters["@ShelterItem"].Value = shelterItem;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(new Item()
                        {
                            ItemName = reader.GetString(0),
                            ItemCategoryID = reader.GetString(1),
                            ItemQuantity = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            ShelterItem = reader.GetBoolean(4),
                            ItemID = reader.GetInt32(5),
                            ShelterThreshold = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                        });

                    }
                    reader.Close();
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            return items;
        }// End SelectShelterItems()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03-17
        /// CHECKED BY: Steven Coonrod
        /// 
        /// Method to update a Shelter Item in inventory.
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATED BY: Steve Coonrod
        /// UPDATED: 2020-4-25
        /// CHANGE: Changed the rowCount check to accomidate a low inventory trigger in the DB
        ///         which will return that it effected 3 rows rather than 1
        /// 
        /// </remarks>
        /// <param name="oldShelterItem"></param>
        /// <param name="newShelterItem"></param>
        /// <returns>Count of rows affected</returns>
        public int UpdateShelterItem(Item oldShelterItem, Item newShelterItem)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_shelter_item", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemID", oldShelterItem.ItemID);

            cmd.Parameters.AddWithValue("@NewItemName", newShelterItem.ItemName);
            cmd.Parameters.AddWithValue("@NewItemCategoryID", newShelterItem.ItemCategoryID);
            cmd.Parameters.AddWithValue("@NewItemQuantity", newShelterItem.ItemQuantity);
            cmd.Parameters.AddWithValue("@NewItemDescription", newShelterItem.Description);
            cmd.Parameters.AddWithValue("@NewShelterItem", newShelterItem.ShelterItem);
            cmd.Parameters.AddWithValue("@NewShelterThershold", newShelterItem.ShelterThreshold);

            cmd.Parameters.AddWithValue("@OldItemName", oldShelterItem.ItemName);
            cmd.Parameters.AddWithValue("@OldItemCategoryID", oldShelterItem.ItemCategoryID);
            cmd.Parameters.AddWithValue("@OldItemQuantity", oldShelterItem.ItemQuantity);
            cmd.Parameters.AddWithValue("@OldItemDescription", oldShelterItem.Description);
            cmd.Parameters.AddWithValue("@OldShelterItem", oldShelterItem.ShelterItem);
            cmd.Parameters.AddWithValue("@OldShelterThershold", oldShelterItem.ShelterThreshold);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows != 1 && rows != 3)
                {
                    throw new ApplicationException("Shelter Item Not Found");
                }
            }
            catch (Exception up)
            {
                throw up;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }// End UpdateShelterItem()

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method to create a new shelter item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool addNewShelterItem(Item item)
        {
            bool result = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_shelter_items", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);
            cmd.Parameters.AddWithValue("@ItemCategoryID", item.ItemCategoryID);
            cmd.Parameters.AddWithValue("@ItemDescription", item.Description);

            try
            {
                conn.Open();
                result = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/10
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method to set active to 1 for one item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public int reactivateItem(Item item)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_reactivate_item", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@ItemCategoryID", item.ItemCategoryID);
            cmd.Parameters.AddWithValue("@ItemDescription", item.Description);
            cmd.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);

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
        /// <summary>
        /// Creator: Jesse Tomash
        /// Created: 4/27/2020
        /// Approver: 
        ///
        /// Method to select item by item id.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public Item SelectItemByItemID(int itemID)
        {
            Item item = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_item_by_item_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ItemID", itemID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    {
                        item = new Item()
                        {
                            ItemName = reader.GetString(0),
                            ItemCategoryID = reader.GetString(1),
                            ItemQuantity = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            ShelterItem = reader.GetBoolean(4),
                            ItemID = reader.GetInt32(5),
                            ShelterThreshold = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                        };
                    }
                    reader.Close();
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

            return item;
        }
    }
}

