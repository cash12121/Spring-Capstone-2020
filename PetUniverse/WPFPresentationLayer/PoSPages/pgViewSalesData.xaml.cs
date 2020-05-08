using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 03/19/2020
    /// Approver: Rob Holmes
    ///
    /// 
    /// Interaction logic for pgViewSalesData.xaml
    /// </summary>
    public partial class pgViewSalesData : Page
    {
        private ISalesDataManager _salesDataManager;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 03/19/2020
        /// Approver: Rob Holmes
        ///
        /// Default Constructor for InventoryItems Page
        /// </summary>
        public pgViewSalesData()
        {
            _salesDataManager = new SalesDataManager();
            InitializeComponent();
        }

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 03/19/2020
		/// Approver: Rob Holmes
		///
		/// Event Handler when the page loads
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			RefreshData(_salesDataManager.RetrieveAllTotalSalesData());
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 03/19/2020
		/// Approver: Rob Holmes
		///
		/// Refresh method to be called on when is needed.
		/// 
		/// </summary>
		private void RefreshData(List<SalesDataVM> source)
		{
			dgSalesData.ItemsSource = source;
			dgSalesData.Columns.Remove(dgSalesData.Columns[0]);

			//Columns reset at 0 after being removed
			dgSalesData.Columns[0].Header = "Product Name";
			dgSalesData.Columns[2].Header = "Product Category";
			dgSalesData.Columns[3].Header = "Product Type";
			dgSalesData.Columns[4].Header = "Total Sold";
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 04/25/2020
		/// Approver: Rasha Mohammed
		/// 
		/// When clicked will trigger refresh for viewing all lifetime sales data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewAllSales_Click(object sender, RoutedEventArgs e)
		{
			RefreshData(_salesDataManager.RetrieveAllTotalSalesData());
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 04/25/2020
		/// Approver: Rasha Mohammed
		/// 
		/// When clicked will trigger refresh for viewing all lifetime employee sales data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnViewEmployeeSales_Click(object sender, RoutedEventArgs e)
		{
			int employeeID;

			// Try to parse textbox into int
			bool success = Int32.TryParse(txtEmployeeID.Text, out employeeID);
			if (success)
			{
				RefreshData(_salesDataManager.RetrieveAllEmployeeSalesData(employeeID));
			}
			else
			{
				// failure message
				MessageBox.Show("Please enter a valid Employee ID");
			}
		}
	}
}
