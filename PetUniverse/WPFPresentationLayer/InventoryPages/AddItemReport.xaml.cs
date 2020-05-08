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
    /// Created: 2020/04/07
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// This class is used to add a new item report for missing / damaged items on the shelf.
    /// </summary>
    public partial class AddItemReport : Page
    {
        private Item _item;
        private IItemManager _itemManager;
        private IItemReportManager _itemReportManager;
        public AddItemReport(Item item)
        {
            InitializeComponent();
            _item = item;
            _itemReportManager = new ItemReportManager();
            _itemManager = new ItemManager();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This method takes the user back to view inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewInventory());
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This method populates the item id and item name fields.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtItemID.Text = _item.ItemID.ToString();
            txtName.Text = _item.ItemName.ToString();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This method adds a new Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Check for validation.
            if (txtReport.Text.Length > 250)
            {
                "Report is too long.".ErrorMessage();
            }
            if (txtReport.Text == "")
            {
                "Please enter a Report.".ErrorMessage();
            }
            if (txtItemQuantity.Text == "")
            {
                "Please enter a Quantity.".ErrorMessage();
            }
            if (txtItemQuantity.Text != "" && txtReport.Text != "")
            {
                try
                {
                    int quantity = Int32.Parse(txtItemQuantity.Text);
                    ItemReport itemReport = new ItemReport();
                    itemReport.ItemName = txtName.Text.ToString();
                    itemReport.ItemQuantity = quantity;
                    itemReport.Report = txtReport.Text.ToString();
                    itemReport.ItemID = Int32.Parse(txtItemID.Text);
                    _itemReportManager.createNewItemReport(itemReport);
                    txtReport.Clear();
                    txtItemQuantity.Clear();

                    // Return to ViewInventory Screen.
                    this.NavigationService?.Navigate(new ViewInventory());
                }
                catch (FormatException)
                {
                    "Quanitity must be a number.".ErrorMessage();
                }
            }
        }
    }
}
