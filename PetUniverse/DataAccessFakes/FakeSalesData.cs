using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{

    /// <summary>
    /// Creator: Cash Carlson
    /// Date: 03/19/2020
    /// Approver: Rob Holmes
    /// 
    /// This class is used to create fake sales data for testing.
    /// </summary>
    public class FakeSalesData : ISalesDataAccessor
    {
        private List<SalesDataVM> salesDataVMs;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 03/19/2020
        /// Approver: Rob Holmes
        /// 
        /// Constructor loading in fake data for testing
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Updater: N/A
        /// </remarks>
        public FakeSalesData()
        {
            salesDataVMs = new List<SalesDataVM>()
            {
                new SalesDataVM()
                {
                    ProductID = "Fake",
                    ProductName = "Fake Name",
                    Brand = "Fake Brand",
                    ProductCategory = "Fake Category",
                    ProductType = "Fake Type",
                    TotalSold = 50
                }
            };
        }

        /// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/04/29
		/// Approver: Rasha Mohammed
		/// 
		/// Return all total employee sales data accessor.
		/// </summary>
		/// <remarks>
		/// Updater: N/A
		/// Updated: N/A
		/// Updater: N/A
		/// </remarks>
        /// <param name="employeeID"></param>
		/// <returns></returns>
		public List<SalesDataVM> RetrieveAllEmployeeSalesData(int employeeID)
		{
			return salesDataVMs;
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 03/19/2020
		/// Approver: Rob Holmes
		/// 
		/// Return all total sales data accessor.
		/// </summary>
		/// <remarks>
		/// Updater: N/A
		/// Updated: N/A
		/// Updater: N/A
		/// </remarks>
		/// <returns></returns>
		public List<SalesDataVM> RetrieveAllTotalSalesData()
		{
			return salesDataVMs;
		}
	}
}
