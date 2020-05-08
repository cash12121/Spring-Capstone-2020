using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 3/30/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// Approver: 
    /// 
    /// Class to access Facility Inspection Items
    /// </summary>
    public class FacilityInspectionItemAccessor : IFacilityInspectionItemAccessor
    {

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to insert a FacilityInspectionItem Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        public int InsertFacilityInspectionItemRecord(FacilityInspectionItem facilityInspectionItem)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_INSERT_facility_inspection_item", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemName", facilityInspectionItem.ItemName);
            cmd.Parameters.AddWithValue("@UserID", facilityInspectionItem.UserID);
            cmd.Parameters.AddWithValue("@FacilityInspectionID", facilityInspectionItem.FacilityInpectionID);
            cmd.Parameters.AddWithValue("@ItemDescription", facilityInspectionItem.ItemDescription);

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
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to select all FacilityInspectionItem Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectAllFacilityInspectionItem()
        {
            List<FacilityInspectionItem> facilityInspectionItems = new List<FacilityInspectionItem>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_all_facility_inspection_item", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;



            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var facilityInspectionItem = new FacilityInspectionItem();
                        facilityInspectionItem.FacilityInspectionItemID = reader.GetInt32(0);
                        facilityInspectionItem.ItemName = reader.GetString(1);
                        facilityInspectionItem.UserID = reader.GetInt32(2);
                        facilityInspectionItem.FacilityInpectionID = reader.GetInt32(3);
                        facilityInspectionItem.ItemDescription = reader.GetString(4);

                        facilityInspectionItems.Add(facilityInspectionItem);

                    }
                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityInspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to select FacilityInspectionItem Records by Facility Inspection ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByFacilityInspectionID(int facilityInspectionID)
        {
            List<FacilityInspectionItem> facilityInspectionItems = new List<FacilityInspectionItem>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_inspection_item_by_facility_inspection_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityInspectionID", facilityInspectionID);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                while (reader.Read())
                {
                    var facilityInspectionItem = new FacilityInspectionItem();
                    facilityInspectionItem.FacilityInspectionItemID = reader.GetInt32(0);
                    facilityInspectionItem.ItemName = reader.GetString(1);
                    facilityInspectionItem.UserID = reader.GetInt32(2);
                    facilityInspectionItem.FacilityInpectionID = reader.GetInt32(3);
                    facilityInspectionItem.ItemDescription = reader.GetString(4);

                    facilityInspectionItems.Add(facilityInspectionItem);

                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityInspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to select FacilityInspectionItem Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItemID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByItemID(int facilityInspectionItemID)
        {
            List<FacilityInspectionItem> facilityInspectionItems = new List<FacilityInspectionItem>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_inspection_item_by_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityInspectionItemID", facilityInspectionItemID);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                while (reader.Read())
                {
                    var facilityInspectionItem = new FacilityInspectionItem();
                    facilityInspectionItem.FacilityInspectionItemID = reader.GetInt32(0);
                    facilityInspectionItem.ItemName = reader.GetString(1);
                    facilityInspectionItem.UserID = reader.GetInt32(2);
                    facilityInspectionItem.FacilityInpectionID = reader.GetInt32(3);
                    facilityInspectionItem.ItemDescription = reader.GetString(4);

                    facilityInspectionItems.Add(facilityInspectionItem);

                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityInspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to select FacilityInspectionItem Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByUserID(int userID)
        {
            List<FacilityInspectionItem> facilityInspectionItems = new List<FacilityInspectionItem>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_inspection_item_by_user_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                while (reader.Read())
                {
                    var facilityInspectionItem = new FacilityInspectionItem();
                    facilityInspectionItem.FacilityInspectionItemID = reader.GetInt32(0);
                    facilityInspectionItem.ItemName = reader.GetString(1);
                    facilityInspectionItem.UserID = reader.GetInt32(2);
                    facilityInspectionItem.FacilityInpectionID = reader.GetInt32(3);
                    facilityInspectionItem.ItemDescription = reader.GetString(4);

                    facilityInspectionItems.Add(facilityInspectionItem);

                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityInspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to select FacilityInspectionItem Records by item name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="itemName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionItemByItemName(string itemName)
        {
            List<FacilityInspectionItem> facilityInspectionItems = new List<FacilityInspectionItem>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_inspection_item_by_item_name", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ItemName", itemName);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                while (reader.Read())
                {
                    var facilityInspectionItem = new FacilityInspectionItem();
                    facilityInspectionItem.FacilityInspectionItemID = reader.GetInt32(0);
                    facilityInspectionItem.ItemName = reader.GetString(1);
                    facilityInspectionItem.UserID = reader.GetInt32(2);
                    facilityInspectionItem.FacilityInpectionID = reader.GetInt32(3);
                    facilityInspectionItem.ItemDescription = reader.GetString(4);

                    facilityInspectionItems.Add(facilityInspectionItem);

                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityInspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to update a facility inspection item record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspectionItem"></param>
        /// <param name="newFacilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        public int UpdateFacilityInspectionItem(FacilityInspectionItem oldFacilityInspectionItem, FacilityInspectionItem newFacilityInspectionItem)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_facility_inspection_item", conn);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FacilityInspectionItemID", oldFacilityInspectionItem.FacilityInspectionItemID);

            cmd.Parameters.AddWithValue("@OldItemName", oldFacilityInspectionItem.ItemName);

            cmd.Parameters.AddWithValue("@OldUserID", oldFacilityInspectionItem.UserID);

            cmd.Parameters.AddWithValue("@OldFacilityInspectionID", oldFacilityInspectionItem.FacilityInpectionID);

            cmd.Parameters.AddWithValue("@OldItemDescription", oldFacilityInspectionItem.ItemDescription);

            cmd.Parameters.AddWithValue("@NewItemName", newFacilityInspectionItem.ItemName);

            cmd.Parameters.AddWithValue("@NewUserID", newFacilityInspectionItem.UserID);

            cmd.Parameters.AddWithValue("@NewFacilityInspectionID", newFacilityInspectionItem.FacilityInpectionID);

            cmd.Parameters.AddWithValue("@NewItemDescription", newFacilityInspectionItem.ItemDescription);

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
    }
}
