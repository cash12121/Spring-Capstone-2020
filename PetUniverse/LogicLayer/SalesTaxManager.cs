using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/13
    /// Approver: Rob Holmes
    /// Implementation of the sales tax manager.
    /// </summary>
    public class SalesTaxManager : ISalesTaxManager
    {
        ISalesTaxAccessor _salesTaxAccessor;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        ///
        /// Default constructor for sales tax.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public SalesTaxManager()
        {
            _salesTaxAccessor = new SalesTaxAccessor();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        ///
        /// Default constructor for sales tax. Used for
        /// unit testing.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="salesTaxAccessor"></param>
        public SalesTaxManager(ISalesTaxAccessor salesTaxAccessor)
        {
            _salesTaxAccessor = salesTaxAccessor;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        ///
        /// Interface implementation for inserting sales tax.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="salesTax"></param>
        /// <returns>returns if success or failure</returns>
        public bool AddSalesTax(SalesTax salesTax)
        {
            try
            {
                return 1 == _salesTaxAccessor.InsertSalesTax(salesTax);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not added.", ex);
            }
        }

        public List<SalesTax> RetrieveAllSalesTax()
        {
            var salesTax = new List<SalesTax>();

            try
            {
                salesTax = _salesTaxAccessor.SelectAllSalesTax();
            }
            catch (Exception)
            {
                throw;
            }

            return salesTax;
        }
    }
}
