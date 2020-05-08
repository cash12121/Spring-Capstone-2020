using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Class for Vendor Manager Methods.
    /// </summary>
    public class VendorManager : IVendorManager
    {

        private IVendorAccessor _vendorAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Constuctor that takes an IVendorAccessor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public VendorManager(IVendorAccessor vendorAccessor)
        {
            _vendorAccessor = vendorAccessor;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Constuctor that takes no arguments.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public VendorManager()
        {
            _vendorAccessor = new VendorAccessor();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that creates a new vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool createNewVendor(Vendor vendor)
        {
            try
            {
                return _vendorAccessor.addNewVendor(vendor);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add a new Vendor.", ex);
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that deletes a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool deleteVendor(int vendorId)
        {
            try
            {
                return 1 == _vendorAccessor.removeVendor(vendorId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to Delete Vendor.", ex);
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that edits a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool editVendor(int vendorId, string oldVendorName, string oldVendorAddress,
            string oldVendorPhone, string oldVendorEmail, string oldVendorState, string oldVendorCity,
            string oldVendorZip, string newVendorName, string newVendorAddress, string newVendorPhone,
            string newVendorEmail, string newVendorState, string newVendorCity, string newVendorZip)
        {

            bool result = false;

            try
            {
                result = 1 == _vendorAccessor.updateVendor(vendorId, oldVendorName, oldVendorAddress,
                    oldVendorPhone, oldVendorEmail, oldVendorState, oldVendorCity, oldVendorZip,
                    newVendorName, newVendorAddress, newVendorPhone, newVendorEmail, newVendorState,
                    newVendorCity, newVendorZip);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Vendor Failed.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Method that retrieves all vendors.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Vendor> retrieveVendors()
        {
            List<Vendor> vendors = new List<Vendor>();

            try
            {
                vendors = _vendorAccessor.getAllVendors();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Vendors Found", ex);
            }

            return vendors;
        }
    }
}
