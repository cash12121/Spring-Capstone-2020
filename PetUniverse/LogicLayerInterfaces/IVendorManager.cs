using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Interface for Vendor Manager Methods.
    /// </summary>
    public interface IVendorManager
    {
        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method for creating a new vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool createNewVendor(Vendor vendor);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method for retrieving vendors.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<Vendor> retrieveVendors();

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method for updating a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool editVendor(int vendorId, string oldVendorName, string oldVendorAddress, string oldVendorPhone,
            string oldVendorEmail, string oldVendorState, string oldVendorCity, string oldVendorZip,
            string newVendorName, string newVendorAddress, string newVendorPhone, string newVendorEmail,
            string newVendorState, string newVendorCity, string newVendorZip);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Interface method for deleting a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool deleteVendor(int vendorId);
    }
}
