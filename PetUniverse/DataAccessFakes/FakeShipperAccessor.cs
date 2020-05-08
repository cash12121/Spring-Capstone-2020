using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// fake data access layer for shipper
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class FakeShipperAccessor : IShipperAccessor
    {

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// fake to create shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool createShipper(Shipper shipper)
        {
            bool shipperID = shipper.ShipperID.Equals("100000");
            bool complaimnt = shipper.Complaint.Equals("no");

            if (shipperID && complaimnt)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Cannot add new orderLine.");
            }
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// fake for deleteing shipper
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

            Shipper testShipper = new Shipper();

            testShipper.ShipperID = "100000";
            testShipper.Complaint = "no"; ;

            if (shipper.ShipperID == testShipper.ShipperID && shipper.Complaint == testShipper.Complaint)
            {
                shipper = null;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// fake for selecting all shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Shipper> selectAllShippers()
        {
            List<Shipper> shippers = new List<Shipper>();
            Shipper shipper = new Shipper();

            shipper.ShipperID = "100000";
            shipper.Complaint = "no";
            shippers.Add(shipper);

            shipper.ShipperID = "100001";
            shipper.Complaint = "yes";
            shippers.Add(shipper);

            return shippers;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// fake for updating shipper
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

            try
            {
                oldShipper = newShipper;
            }
            catch (Exception)
            {

                throw;
            }

            if (oldShipper == newShipper)
            {
                result = true;
            }

            return result;
        }
    }
}

