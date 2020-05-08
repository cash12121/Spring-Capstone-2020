using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Interface class for Vendor.
    /// </summary>
    public interface IVendorAccessor
    {
        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method that adds a new vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool addNewVendor(Vendor vendor);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method that gets a list of vendors.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<Vendor> getAllVendors();

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method that updates a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        int updateVendor(int vendorId, string oldVendorName, string oldVendorAddress, string oldVendorPhone,
            string oldVendorEmail, string oldVendorState, string oldVendorCity, string oldVendorZip,
            string newVendorName, string newVendorAddress, string newVendorPhone, string newVendorEmail,
            string newVendorState, string newVendorCity, string newVendorZip);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method that removes a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        int removeVendor(int vendorId);
    }
}
