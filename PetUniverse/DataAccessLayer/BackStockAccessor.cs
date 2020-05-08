using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
// needed for provides access to classes that represent the ADO.NET architecture
using System.Data;
// needed to connect to SQL server
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Tener karar
    /// Created: 2020/02/7
    /// Approver: Brandyn T. Coverdill
    ///
    /// The Access class for the back stok record manger and item class
    /// Contains all methods for gitten the data form the  database
    /// </summary>
    public class BackStockAccessor : IBackStockAccessor
    {
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method get all item in back room  Edite 
        /// first, get a connection
        ///  next, we need a command object
        ///  set the command type
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Matt Deaton
        /// Updated: 2020-03-11
        /// Update: Added the ShelterItem item to the method, to display in data grid.
        /// </remarks>


        public List<Item> getAllItemsInBackRoom()
        {
            List<Item> items = new List<Item>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_retrieve_item_list", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // now that the command is set up, we can execute it

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var item = new Item();
                        item.ItemID = reader.GetInt32(0);
                        item.ItemName = reader.GetString(1);
                        item.ItemQuantity = reader.GetInt32(2);
                        item.ItemCategoryID = reader.GetString(3);
                        //item.ItemLocationID = reader.GetString(4);
                        item.Description = retrieveItemCategoryByItemCategoryID(item.ItemCategoryID);
                        item.ShelterItem = reader.GetBoolean(4);

                        items.Add(item);
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

            return items;
        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method get all item locatio in by item ID
        /// first, get a connection
        ///  next, we need a command object
        ///  set the command type
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="itemID"></param>

        public List<int> getItemLocationsByItemID(int itemID)
        {
            List<int> Locations = new List<int>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_retrieve_ItemLocations_list", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // add parameters for the procedure
            cmd.Parameters.Add("@ItemID", SqlDbType.Int);
            // set the values for the parameters
            cmd.Parameters["@ItemID"].Value = itemID;
            // now that the command is set up, we can execute it
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Locations.Add(
                        reader.GetInt32(0));


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

            return Locations;
        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method Updat Item Location in back room  
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="itemID"></param>
        /// <param name="itemLocationID"></param>
        /// <param name="NewitemLocationID"></param>
        public bool UpdateItemLocation(int itemID, int itemLocationID, int NewItemLocation)
        {
            bool updateSuccess = false;

            // connection
            var conn = DBConnection.GetConnection();

            // cmd
            var cmd = new SqlCommand("sp_update_Item_Location");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@ItemID", SqlDbType.Int);
            cmd.Parameters.Add("@OldLocationID", SqlDbType.Int);
            cmd.Parameters.Add("@NewLocationID", SqlDbType.Int);

            //// values
            cmd.Parameters["@ItemID"].Value = itemID;
            cmd.Parameters["@OldLocationID"].Value = itemLocationID;
            cmd.Parameters["@NewLocationID"].Value = NewItemLocation;

            // execute the command
            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                updateSuccess = (rows == 1);
            }
            catch (Exception)
            {
                updateSuccess = false;
            }
            finally
            {
                conn.Close();
            }

            return updateSuccess;
        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method retrieve Item Category By ItemCategoryID
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="itemID"></param>
        /// <summary>
        /// <param name="itemCategoryID"></param>

        private string retrieveItemCategoryByItemCategoryID(string itemCategoryID)
        {

            string itemCategory = null;
            List<ItemCategory> itemCategorys = new List<ItemCategory>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_retrieve_ItemCategory_list", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // now that the command is set up, we can execute it

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var itemCat = new ItemCategory();

                        itemCat.ItemCategoryID = reader.GetString(0);
                        itemCat.Description = reader.GetString(1);


                        itemCategorys.Add(itemCat);
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

            foreach (var itemCate in itemCategorys)
            {
                if (itemCate.ItemCategoryID == itemCategoryID)
                {
                    itemCategory = itemCate.Description;
                }
            }

            return itemCategory;
        }
    }
}
