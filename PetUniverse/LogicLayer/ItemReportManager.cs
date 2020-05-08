using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/07
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// Class that manages Item Reports (Items on shelf.)
    /// </summary>
    public class ItemReportManager : IItemReportManager
    {

        private IItemReportAccessor _itemReportAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Constructor that takes an Item Report Accessor Interface.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ItemReportManager(IItemReportAccessor itemAccessor)
        {
            _itemReportAccessor = itemAccessor;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Constructor that takes no arguments.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ItemReportManager()
        {
            _itemReportAccessor = new ItemReportAccessor();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Creates a new Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool createNewItemReport(ItemReport itemReport)
        {
            try
            {
                return _itemReportAccessor.addNewItemReport(itemReport);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add a new Item Report.", ex);
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Removes an Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool deleteItemReport(int itemId, int itemQty, string report)
        {
            try
            {
                return 1 == _itemReportAccessor.removeItemReport(itemId, itemQty, report);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to Delete Item Report.", ex);
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Edits an Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool editItemReports(int oldQty, string oldReport, int newQty, string newReport, int itemId)
        {

            bool result = false;

            try
            {
                result = 1 == _itemReportAccessor.updateItemReport(oldQty, oldReport, newQty, newReport, itemId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update Item Report Failed.", ex);
            }

            return result;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Retrieves a list of Item Reports.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<ItemReport> retrieveItemReports()
        {
            List<ItemReport> itemReports = new List<ItemReport>();

            try
            {
                itemReports = _itemReportAccessor.getAllItemReports();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Item Reports Found", ex);
            }

            return itemReports;
        }
    }
}
