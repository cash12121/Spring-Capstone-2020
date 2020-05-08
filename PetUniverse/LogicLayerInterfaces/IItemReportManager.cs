using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/07
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// Interface Manager for Item Report for items that are missing/damaged on the shelf.
    /// </summary>
    public interface IItemReportManager
    {
        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface Method that create a new Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool createNewItemReport(ItemReport itemReport);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface Method that retrieves all Item Reports.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<ItemReport> retrieveItemReports();

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that updates an Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool editItemReports(int oldQty, string oldReport, int newQty, string newReport, int itemId);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface Method that removes an Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool deleteItemReport(int itemId, int itemQty, string report);
    }
}
