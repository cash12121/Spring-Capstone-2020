using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/03/03
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// This is the page for viewing item details.
    /// </summary>
    public partial class ViewItemDetail : Page
    {

        private IItemManager _itemManager;
        private IManageBackstockRecords _manageBackstockRecord;
        private Item _item;

        public ViewItemDetail(Item item)
        {
            InitializeComponent();
            _itemManager = new ItemManager();
            _manageBackstockRecord = new ManageBackstockRecords();
            _item = item;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/03
        /// Approver: Dalton Reierson
        /// Approver:  
        ///
        /// This click event is for going back to the Inventory Screen.
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
        /// Created: 2020/03/03
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This method loads the text fields with data when loaded.
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
            List<int> location = _manageBackstockRecord.getItemLocations(_item.ItemID);
            txtItemCount.Text = _item.ItemQuantity.ToString();
            txtItemID.Text = _item.ItemID.ToString();
            txtItemDescription.Text = _item.Description.ToString();
            txtItemName.Text = _item.ItemName.ToString();
            try
            {
                txtItemLocation.Text = location[0].ToString();
            }
            catch (Exception)
            {
                "There is no location specified yet for this item.".ErrorMessage("Notice");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This click event makes it so the items are editable.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;
            txtItemID.Background = Brushes.Bisque;
            txtItemLocation.Background = Brushes.Bisque;
            txtItemID.ToolTip = "You can not edit this information.";
            txtItemLocation.ToolTip = "You can not edit this information.";

            // Make the user able to edit the correct fields.
            txtItemDescription.IsReadOnly = false;
            txtItemName.IsReadOnly = false;
            txtItemCount.IsReadOnly = false;
            txtItemName.Focus();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
        ///
        /// Click Event that tries to save to edited information about the item back to the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Boolean to see if the result was able to edit the item.
            bool result = false;

            if (txtItemDescription.Text.Length <= 250 && txtItemName.Text.Length <= 50 && txtItemDescription.Text != "" && txtItemName.Text != "" && txtItemCount.Text != "")
            {
                string newItemDescription = txtItemDescription.Text.ToString();
                string newItemName = txtItemName.Text.ToString();
                // Check to see if the Item Count is valid.
                int newItemCount;
                int oldItemCount = Int32.Parse(_item.ItemQuantity.ToString());
                string oldItemName = _item.ItemName.ToString();
                string oldItemDescription = _item.Description.ToString();
                try
                {
                    newItemCount = Int32.Parse(txtItemCount.Text.ToString());
                    _itemManager.editItemDetail(oldItemName, oldItemDescription, oldItemCount, newItemName, newItemDescription, newItemCount);
                    result = true;
                }
                catch (Exception)
                {
                    "Item Count must be a real whole number.".ErrorMessage();
                }

            }
            if (txtItemDescription.Text.Length > 250)
            {
                "Item Description is too long.".ErrorMessage();
            }
            if (txtItemDescription.Text == "")
            {
                "Please enter an Item Description.".ErrorMessage();
            }
            if (txtItemName.Text.Length > 50)
            {
                "Item Name is too long.".ErrorMessage();
            }
            if (txtItemName.Text == "")
            {
                "Please enter an Item Name.".ErrorMessage();
            }
            if (txtItemCount.Text == "")
            {
                "Please enter an Item Count.".ErrorMessage();
            }
            if (result == true)
            {
                "Item was successfully saved!".SuccessMessage();
                btnEdit.Visibility = Visibility.Visible;
                btnSave.Visibility = Visibility.Hidden;
                txtItemID.Background = Brushes.Transparent;
                txtItemLocation.Background = Brushes.Transparent;

                // Make the fields not editiable anymore
                txtItemDescription.IsReadOnly = true;
                txtItemName.IsReadOnly = true;
                txtItemCount.IsReadOnly = true;
                txtItemID.ToolTip = null;
                txtItemLocation.ToolTip = null;
            }
        }
    }
}