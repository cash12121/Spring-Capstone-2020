using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Accessor Class for Vendor.
    /// </summary>
    public class VendorAccessor : IVendorAccessor
    {
        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that adds a new vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool addNewVendor(Vendor vendor)
        {
            bool result = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_new_vendor", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@VendorName", vendor.VendorName);
            cmd.Parameters.AddWithValue("@VendorAddress", vendor.VendorAddress);
            cmd.Parameters.AddWithValue("@VendorCity", vendor.VendorCity);
            cmd.Parameters.AddWithValue("@VendorState", vendor.VendorState);
            cmd.Parameters.AddWithValue("@VendorZip", vendor.VendorZip);
            cmd.Parameters.AddWithValue("@VendorPhone", vendor.VendorPhone);
            cmd.Parameters.AddWithValue("@VendorEmail", vendor.VendorEmail);

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
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        /// Method that gets all vendors.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Vendor> getAllVendors()
        {
            List<Vendor> vendors = new List<Vendor>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_vendors", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    vendors.Add(new Vendor()
                    {
                        VendorID = reader.GetInt32(0),
                        VendorName = reader.GetString(1),
                        VendorAddress = reader.GetString(2),
                        VendorPhone = reader.GetString(3),
                        VendorEmail = reader.GetString(4),
                        VendorState = reader.GetString(5),
                        VendorCity = reader.GetString(6),
                        VendorZip = reader.GetString(7)
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

            return vendors;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that removes a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int removeVendor(int vendorId)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_remove_vendor", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VendorID", vendorId);

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
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that updates a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public int updateVendor(int vendorId, string oldVendorName, string oldVendorAddress, string oldVendorPhone, string oldVendorEmail, string oldVendorState, string oldVendorCity, string oldVendorZip, string newVendorName, string newVendorAddress, string newVendorPhone, string newVendorEmail, string newVendorState, string newVendorCity, string newVendorZip)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_vendor", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VendorID", vendorId);
            cmd.Parameters.AddWithValue("@OldVendorName", oldVendorName);
            cmd.Parameters.AddWithValue("@OldVendorAddress", oldVendorAddress);
            cmd.Parameters.AddWithValue("@OldVendorPhone", oldVendorPhone);
            cmd.Parameters.AddWithValue("@OldVendorEmail", oldVendorEmail);
            cmd.Parameters.AddWithValue("@OldVendorState", oldVendorState);
            cmd.Parameters.AddWithValue("@OldVendorCity", oldVendorCity);
            cmd.Parameters.AddWithValue("@OldVendorZip", oldVendorZip);

            cmd.Parameters.AddWithValue("@NewVendorName", newVendorName);
            cmd.Parameters.AddWithValue("@NewVendorAddress", newVendorAddress);
            cmd.Parameters.AddWithValue("@NewVendorPhone", newVendorPhone);
            cmd.Parameters.AddWithValue("@NewVendorEmail", newVendorEmail);
            cmd.Parameters.AddWithValue("@NewVendorState", newVendorState);
            cmd.Parameters.AddWithValue("@NewVendorCity", newVendorCity);
            cmd.Parameters.AddWithValue("@NewVendorZip", newVendorZip);

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
