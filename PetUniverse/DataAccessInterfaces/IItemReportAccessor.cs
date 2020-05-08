using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/07
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// Interface for Item Reports
    /// </summary>
    public interface IItemReportAccessor
    {
        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that adds a new report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool addNewItemReport(ItemReport itemReport);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that gets all of the Item Reports.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<ItemReport> getAllItemReports();

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
        int updateItemReport(int oldQty, string oldReport, int newQty, string newReport, int itemId);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that removes an Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        int removeItemReport(int itemId, int itemQty, string report);
    }
}
