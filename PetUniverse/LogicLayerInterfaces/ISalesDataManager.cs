using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
	/// <summary>
	/// Creator: Cash Carlson
	/// Created: 03/19/2020
	/// Approver: Rob Holmes
	///
	/// An interface for Sales Data Logic Manager
	/// </summary>
	public interface ISalesDataManager
	{
		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 03/19/2020
		/// Approver: Rob Holmes
		///
		/// Interface for a method that gets a list of all Total Sales Data from an accessor
		/// </summary>
		/// <returns>List of Sales Data View Model Objects</returns>
		List<SalesDataVM> RetrieveAllTotalSalesData();

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 04/25/2020
		/// Approver: Rasha Mohammed
		/// 
		/// Interface for a mehtod that gets a list of lifetime Sales Data for an employee
		/// </summary>
		/// <param name="employeeID"></param>
		/// <returns></returns>
		List<SalesDataVM> RetrieveAllEmployeeSalesData(int employeeID);
	}
}
