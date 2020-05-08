using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// CREATED BY: Matt Deaton
    /// DATE: 2020-03-06
    /// CHECKED BY: Steve Coonrod
    /// 
    /// View for handling the UpdateShelterItem
    /// Interaction logic for UpdateShelterInventory.xaml
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED:
    /// CHANGE:
    /// </remarks>
    public partial class UpdateShelterItem : Page
    {
        private Item _shelterItem = null;
        private IItemManager _itemManager;
        private IItemCategoryManager _itemCategoryManager;

        public UpdateShelterItem(IItemManager itemManager)
        {
            InitializeComponent();
            _itemManager = itemManager;
            _itemCategoryManager = new ItemCategoryManager();
        }

        public UpdateShelterItem(Item shelterItem, IItemManager itemManager)
        {
            InitializeComponent();
            _shelterItem = shelterItem;
            _itemManager = itemManager;
            _itemCategoryManager = new ItemCategoryManager();
        }

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY: Steve Coonrod
        /// 
        /// Method to Load the selected items information.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txtItemName.Text = _shelterItem.ItemName.ToString();
            txtItemQty.Text = _shelterItem.ItemQuantity.ToString();
            txtShelterThreshold.Text = _shelterItem.ShelterThreshold.ToString();
            txtItemDesc.Text = _shelterItem.Description.ToString();
            cboBxCategory.SelectedItem = _shelterItem.ItemCategoryID.ToString();
            txtItemName.Focus();
            txtItemName.SelectAll();
        }// End Grid_Loaded()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY: Steve Coonrod
        /// 
        /// Method to Cancel the update of a Shelter Item.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED:
        /// CHANGE:
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ShelterInventory());
        }// End btnCancel_Click()

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Steve Coonrod  
        ///
        /// Populates the ComboBox with values.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void cboBxCategory_Loaded(object sender, RoutedEventArgs e)
        {
            List<ItemCategory> list = new List<ItemCategory>();
            list = _itemCategoryManager.listItemCategories();
            foreach (var item in list)
            {
                cboBxCategory.Items.Add(item.ItemCategoryID);
            }
        }// End cboBxCategory_Loaded()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY: Steve Coonrod
        /// 
        /// Method to save the update of a Shelter Item.
        /// 
        /// </summary>
        /// <remarks>
		/// UPDATED BY: Matt Deaton
		/// UPDATED: 2020-05-03
		/// CHANGE: Add validation checks to make sure ItemQty and ShelterThreshold were only
        /// recieving numbers.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Set variables to set the quantites to later.
            int itemQuantity = 0;
            int shelterThreshold = 0;

            // Check to make sure txtItemQty is a number. 
            try
            {
                int quantity = Int32.Parse(txtItemQty.Text);
                itemQuantity = quantity;
            }
            catch (FormatException)
            {
                MessageBox.Show("Item Quantity must be a number.");
                txtItemQty.Focus();
                return;
            }
            // Check to make sure txtShelterThreshold is a number.
            try
            {

                int threshold = Int32.Parse(txtShelterThreshold.Text);
                shelterThreshold = threshold;
            }
            catch (FormatException)
            {
                MessageBox.Show("Shelter Threshold must be a number.");
                txtShelterThreshold.Focus();
                return;
            }

            if (txtItemName.Text == "")
            {
                MessageBox.Show("You must enter an Item Name.");
                txtItemName.Focus();
                return;
            }
            if (txtItemQty.Text == "")
            {
                MessageBox.Show("You must enter a valid Item Quantitiy.");
                txtItemQty.Focus();
                return;
            }
            if (txtItemDesc.Text == "")
            {
                MessageBox.Show("You must enter an Item Description.");
                txtItemDesc.Focus();
                return;
            }

            Item shelterItem = new Item()
            {
                ItemName = txtItemName.Text.ToString(),
                ItemQuantity = itemQuantity,
                ShelterThreshold = shelterThreshold,
                ItemCategoryID = cboBxCategory.Text,
                Description = txtItemDesc.Text,
                ShelterItem = (bool)chkShelterItem.IsChecked
            };

            try
            {
                if (_itemManager.EditShelterItem(_shelterItem, shelterItem))
                {
                    MessageBox.Show("You updated " + txtItemName.Text);
                    this.NavigationService?.Navigate(new ShelterInventory());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }// End btnSaveUpdate_Click()

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY: Steve Coonrod
        /// 
        /// Method to select all text in ItemQty when tabbed into.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemQty_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                ((TextBox)sender).SelectAll();
            }
        }

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY: Steve Coonrod
        /// 
        /// Method to select all text in ShelterThreshold when tabbed into.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShelterThreshold_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                ((TextBox)sender).SelectAll();
            }
        }

        /// <summary>
        /// NAME: Matt Deaton
        /// DATE: 2020-03- 17
        /// CHECKED BY: Steve Coonrod
        /// 
        /// Method to select all text in ItemDescription when tabbed into.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemDesc_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }// End class UpdateShelterItem

}// End namespace WPFPresentationLayer.InventoryPages
