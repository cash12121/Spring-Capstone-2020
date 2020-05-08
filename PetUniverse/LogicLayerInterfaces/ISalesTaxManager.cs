using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/13
    /// Approver: Rob Holmes
    /// Interface outlines the requirements for the Sales Tax Manager class.
    /// </summary>
    public interface ISalesTaxManager
    {

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        ///
        /// Interface method signature for inserting sales tax.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="salesTax"></param>
        /// <returns>returns if success or failure</returns>
        bool AddSalesTax(SalesTax salesTax);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 5/5/2020
        /// Approver: 
        /// 
        /// Necessary to load real data.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <returns></returns>
        List<SalesTax> RetrieveAllSalesTax();
    }
}
