using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/08
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// Code-behind file for Editing an Item Report view (Items Missing/Damaged from shelf).
    /// </summary>
    public partial class EditItemReports : Page
    {
        private IItemReportManager _itemReportManager;
        private ItemReport _itemReport;


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/08
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Constructor for EditItemReports.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public EditItemReports(ItemReport itemReport)
        {
            _itemReportManager = new ItemReportManager();
            _itemReport = itemReport;
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/08
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Event that takes the user back to View Item Reports view.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewItemReports());
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/08
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// When the page is loaded, add the item fields to the page.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtItemID.Text = _itemReport.ItemID.ToString();
            txtName.Text = _itemReport.ItemName.ToString();
            txtItemQuantity.Text = _itemReport.ItemQuantity.ToString();
            txtReport.Text = _itemReport.Report.ToString();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/08
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Event that edits an Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditReport_Click(object sender, RoutedEventArgs e)
        {
            btnEditReport.Visibility = Visibility.Hidden;
            btnSaveItemReport.Visibility = Visibility.Visible;
            txtItemQuantity.IsReadOnly = false;
            txtReport.IsReadOnly = false;
            txtItemQuantity.Focus();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/08
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Event that saves the edited Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveItemReport_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;

            if (txtItemQuantity.Text != "" && txtReport.Text != ""
                && txtReport.Text.Length <= 250)
            {
                // Seeing if the Quanitity of items from Report can be a number.
                try
                {
                    int newQty = Int32.Parse(txtItemQuantity.Text);

                    int id = _itemReport.ItemID;

                    // Get Old Data.
                    int oldQty = _itemReport.ItemQuantity;
                    string oldRpt = _itemReport.Report;

                    // Get New Data.
                    string newRpt = txtReport.Text.ToString();

                    // Send Data to Manager layer.
                    _itemReportManager.editItemReports(oldQty, oldRpt, newQty, newRpt, id);

                    btnSaveItemReport.Visibility = Visibility.Hidden;
                    btnEditReport.Visibility = Visibility.Visible;
                    result = true;
                    this.NavigationService?.Navigate(new ViewItemReports());
                }
                catch (FormatException)
                {
                    "Item Quantity must be a number.".ErrorMessage();
                }
            }
            if (txtReport.Text.Length > 250)
            {
                "Report is too long.".ErrorMessage();
            }
            if (txtReport.Text == "")
            {
                "Please Enter a Report.".ErrorMessage();
            }
            if (txtItemQuantity.Text == "")
            {
                "Please Enter a Quantity.".ErrorMessage();
            }
            if (result)
            {
                "Item Report was Successfully updated!".SuccessMessage();
            }
        } // End Edit Item Report.
    }
}
