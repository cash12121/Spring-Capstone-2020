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
    /// Creator: Dalton Reierson
    /// Created: 2020/04/29
    /// Approver: Brandyn T. Coverdill
    /// Approver:  
    ///
    /// Shipper accessor class
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class ShipperAccessor : IShipperAccessor
    {
        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// Method to create shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool createShipper(Shipper shipper)
        {
            bool result = false;

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_create_shipper", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameters
            cmd.Parameters.AddWithValue("@ShipperID", shipper.ShipperID);
            cmd.Parameters.AddWithValue("@Complaint", shipper.Complaint);

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
        /// Method to delete shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool deleteShipper(Shipper shipper)
        {
            bool result = false;

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_delete_shipper", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameters
            cmd.Parameters.AddWithValue("@ShipperID", shipper.ShipperID);
            cmd.Parameters.AddWithValue("@Complaint", shipper.Complaint);

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
        /// Method to get a list of all shippers
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Shipper> selectAllShippers()
        {
            List<Shipper> shipperList = new List<Shipper>();

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_select_shippers");
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
                        Shipper shipper = new Shipper();

                        shipper.ShipperID = reader.GetString(0);
                        shipper.Complaint = reader.GetString(1);
                        shipperList.Add(shipper);
                    }
                }

            }
            catch (Exception)
            {

                throw new ApplicationException("Shippers not found");
            }
            finally
            {
                conn.Close();
            }

            return shipperList;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// method to upate shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool updateShipper(Shipper oldShipper, Shipper newShipper)
        {
            bool result = false;

            // Connection
            var conn = DBConnection.GetConnection();

            // Command Objects
            var cmd = new SqlCommand("sp_update_shipper", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Parameters
            cmd.Parameters.AddWithValue("@ShipperID", oldShipper.ShipperID);
            cmd.Parameters.AddWithValue("@OldComplaint", oldShipper.Complaint);
            cmd.Parameters.AddWithValue("@NewComplaint", newShipper.Complaint);

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
    }
}
