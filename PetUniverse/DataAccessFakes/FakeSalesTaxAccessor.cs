using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/13
    /// Approver: Rob Holmes
    /// 
    /// Fake data source for sales tax (not the view model). Used for unit testing.
    /// </summary>
    public class FakeSalesTaxAccessor : ISalesTaxAccessor
    {
        private List<SalesTax> _salesTaxes;

        public FakeSalesTaxAccessor()
        {
            DateTime salesTaxDate = new DateTime(2002, 03, 20);
            DateTime salesTaxDate2 = new DateTime(2000, 04, 03);

            _salesTaxes = new List<SalesTax>()
            {
                new SalesTax()
                {
                    TaxDate = salesTaxDate,
                    TaxRate = 0.035M,
                    ZipCode = "FAKEZIPCODE"
                },
                new SalesTax()
                {
                    TaxDate = salesTaxDate2,
                    TaxRate = 0.021M,
                    ZipCode = "FAKEZIPCODE2"
                }
            };
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: Rob Holmes
        /// 
        /// This fake method is called to insert the sales tax.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="salesTax"></param>
        /// <returns>rows effected</returns>
        public int InsertSalesTax(SalesTax salesTax)
        {
            int result = 0;
            FakeSalesTaxAccessor fakeSalesTaxAccessor = new FakeSalesTaxAccessor();
            List<SalesTax> salesTaxes = _salesTaxes;

            if (!salesTaxes.Contains(salesTax))
            {
                salesTaxes.Add(salesTax);
                result = 1;
            }

            return result;
        }

        public List<SalesTax> SelectAllSalesTax()
        {
            return _salesTaxes;
        }
    }
}
