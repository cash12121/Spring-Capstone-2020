using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IShipperAccessor
    {

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/28
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// Method to create a shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks
        bool createShipper(Shipper shipper);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/28
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// Method to update shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks
        bool updateShipper(Shipper oldShipper, Shipper newShipper);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/28
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// method to deleteShipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks
        bool deleteShipper(Shipper shipper);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/28
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// Method to select all shippers
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks
        List<Shipper> selectAllShippers();
    }
}
