using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/12/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// Lacation data access class
    /// </summary>
    public class LocationAccessor : ILocationAccessor
    {
        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Deletes a location
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="location"></param>
        /// <returns></returns>
        public int DeleteLocation(Location location)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_delete_location", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LocationID", location.LocationID);
            cmd.Parameters.AddWithValue("@Name", location.Name);
            cmd.Parameters.AddWithValue("@Address1", location.Address1);
            cmd.Parameters.AddWithValue("@Address2", location.Address2);
            cmd.Parameters.AddWithValue("@City", location.City);
            cmd.Parameters.AddWithValue("@State", location.State);
            cmd.Parameters.AddWithValue("@Zip", location.Zip);

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

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Inserts a location into the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="location"></param>
        /// <returns></returns>
        public int InsertLocation(Location location)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_location", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", location.Name);
            cmd.Parameters.AddWithValue("@Address1", location.Address1);
            cmd.Parameters.AddWithValue("@Address2", location.Address2);
            cmd.Parameters.AddWithValue("@City", location.City);
            cmd.Parameters.AddWithValue("@State", location.State);
            cmd.Parameters.AddWithValue("@Zip", location.Zip);


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

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// selects all locations
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<Location> SelectAllLocations()
        {
            List<Location> locations = new List<Location>();
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_locations", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var location = new Location();

                        location.LocationID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1)) location.Name = reader.GetString(1);
                        location.Address1 = reader.GetString(2);
                        location.Address2 = reader.IsDBNull(3) ? null : reader.GetString(3);
                        location.City = reader.GetString(4);
                        location.State = reader.GetString(5);
                        location.Zip = reader.GetString(6);

                        locations.Add(location);
                    }
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
            return locations;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Selects a location by its id
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public Location SelectLocationByLocationID()
        {
            var location = new Location();
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_location_by_location_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    location.LocationID = reader.GetInt32(0);
                    location.Name = reader.IsDBNull(1) ? null : reader.GetString(1);
                    location.Address1 = reader.GetString(2);
                    location.Address2 = reader.GetString(3);
                    location.City = reader.GetString(4);
                    location.State = reader.GetString(5);
                    location.Zip = reader.GetString(6);
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
            return location;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Updates a location
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldLocation"></param>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        public int UpdateLocation(Location oldLocation, Location newLocation)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_location", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LocationID", oldLocation.LocationID);

            cmd.Parameters.AddWithValue("@OldName", oldLocation.Name);
            cmd.Parameters.AddWithValue("@OldAddress1", oldLocation.Address1);
            cmd.Parameters.AddWithValue("@OldAddress2", oldLocation.Address2);
            cmd.Parameters.AddWithValue("@OldCity", oldLocation.City);
            cmd.Parameters.AddWithValue("@OldState", oldLocation.State);
            cmd.Parameters.AddWithValue("@OldZip", oldLocation.Zip);

            cmd.Parameters.AddWithValue("@NewName", newLocation.Name);
            cmd.Parameters.AddWithValue("@NewAddress1", newLocation.Address1);
            cmd.Parameters.AddWithValue("@NewAddress2", newLocation.Address2);
            cmd.Parameters.AddWithValue("@NewCity", newLocation.City);
            cmd.Parameters.AddWithValue("@NewState", newLocation.State);
            cmd.Parameters.AddWithValue("@NewZip", newLocation.Zip);

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
    }
}
