using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/29
    /// Approver: Brandyn T. Coverdill
    /// Approver:  
    ///
    /// Manager for Shippers
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public class ShipperManager : IShipperManager
    {
        private IShipperAccessor _shipperAccessor;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// No argument constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ShipperManager()
        {
            _shipperAccessor = new ShipperAccessor();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// contructor for tests
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ShipperManager(IShipperAccessor shipperAccessor)
        {
            _shipperAccessor = shipperAccessor;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// Method to create shippers
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

            try
            {
                result = _shipperAccessor.createShipper(shipper);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// method to delete shippers
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

            try
            {
                result = _shipperAccessor.deleteShipper(shipper);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// method to select all shippers
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

            try
            {
                shippers = _shipperAccessor.selectAllShippers();
            }
            catch (Exception)
            {

                throw;
            }

            return shippers;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// method to update shippers
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
                result = _shipperAccessor.updateShipper(oldShipper, newShipper);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
