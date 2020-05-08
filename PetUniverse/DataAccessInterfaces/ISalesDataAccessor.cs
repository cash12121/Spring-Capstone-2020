using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Name: Cash Carlson
    /// Date: 03/19/2020
    /// Approver: Rob Holmes
    /// 
    /// An interface For Sales Data
    /// </summary>
    public interface ISalesDataAccessor
    {

		/// <summary>
		/// Name: Cash Carlson
		/// Date: 03/19/2020
		/// Approver: Rob Holmes
		/// 
		/// A data access method of getting all total product sales data
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// </remarks>
		/// <returns>List of SalesDataVM</returns>
		List<SalesDataVM> RetrieveAllTotalSalesData();

		/// <summary>
		/// Name: Cash Carlson
		/// Date: 03/19/2020
		/// Approver: Rasha Mohammed
		/// 
		/// A data access method of getting all lifetime employee product sales data
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// </remarks>
		/// <param name="employeeID"></param>
		/// <returns>List of SalesDataVM</returns>
		List<SalesDataVM> RetrieveAllEmployeeSalesData(int employeeID);
	}
}