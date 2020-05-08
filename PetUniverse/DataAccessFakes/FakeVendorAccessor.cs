using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Class for Fake Vendor Data Access.
    /// </summary>
    public class FakeVendorAccessor : IVendorAccessor
    {
        private List<Vendor> _vendor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Constructor that builds a list of a fake vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public FakeVendorAccessor()
        {
            _vendor = new List<Vendor>()
            {
                new Vendor()
                {
                    VendorID = 1,
                    VendorAddress = "1 Address",
                    VendorPhone = "1111111111",
                    VendorCity = "1 City",
                    VendorEmail = "Vendor1@email.com",
                    VendorName = "Vendor 1",
                    VendorState = "VE",
                    VendorZip = "11111"
                },
                new Vendor()
                {
                    VendorID = 2,
                    VendorAddress = "2 Address",
                    VendorPhone = "2222222222",
                    VendorCity = "2 City",
                    VendorEmail = "Vendor2@email.com",
                    VendorName = "Vendor 2",
                    VendorState = "VE",
                    VendorZip = "22222"
                }
            };
        }

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
            bool vendorId = vendor.VendorID.Equals(10);
            bool vendorName = vendor.VendorName.Equals("Vendor");
            bool vendorAddress = vendor.VendorAddress.Equals("Address");
            bool vendorPhone = vendor.VendorPhone.Equals("Phone");
            bool vendorEmail = vendor.VendorEmail.Equals("Email");
            bool vendorState = vendor.VendorState.Equals("IA");
            bool vendorCity = vendor.VendorCity.Equals("City");
            bool vendorZip = vendor.VendorZip.Equals("Zip");
            if (vendorId && vendorName && vendorAddress && vendorPhone && vendorEmail && vendorState && vendorCity
                && vendorZip)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Cannot add new Vendor.");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
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
            return _vendor;
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

            Vendor vendor = new Vendor();
            vendor.VendorID = vendorId;

            foreach (var vdr in _vendor)
            {
                if (vendor.VendorID == vdr.VendorID)
                {
                    try
                    {
                        _vendor.Remove(vdr);
                        rowsAffected = 1;
                    }
                    catch
                    {
                        return rowsAffected;
                    }
                }
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
        public int updateVendor(int vendorId, string oldVendorName, string oldVendorAddress,
            string oldVendorPhone, string oldVendorEmail, string oldVendorState, string oldVendorCity,
            string oldVendorZip, string newVendorName, string newVendorAddress, string newVendorPhone,
            string newVendorEmail, string newVendorState, string newVendorCity, string newVendorZip)
        {
            int result = 0;

            oldVendorName = newVendorName;
            oldVendorAddress = newVendorAddress;
            oldVendorPhone = newVendorPhone;
            oldVendorEmail = newVendorEmail;
            oldVendorState = newVendorState;
            oldVendorCity = newVendorCity;
            oldVendorZip = newVendorZip;

            if (oldVendorZip == newVendorZip && oldVendorName == newVendorName && oldVendorAddress == newVendorAddress
                && oldVendorPhone == newVendorPhone && oldVendorEmail == newVendorEmail && oldVendorState == newVendorState
                && oldVendorCity == newVendorCity)
            {
                result = 1;
            }

            return result;
        }
    }
}
