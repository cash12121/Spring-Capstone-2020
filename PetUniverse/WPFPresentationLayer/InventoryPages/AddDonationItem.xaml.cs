using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// CREATED BY: Matt Deaton
    /// DATE: 2020-03-15
    /// CHECKED BY: Steve Coonrod
    /// Page for adding a new Donated Item
    /// 
    /// Interaction logic for AddDonationItem.xaml
    /// </summary>
	/// <remarks>
	/// UPDATED BY:
	/// UPDATED:
	/// CHANGE:
	/// </remarks>
    public partial class AddDonatedItem : Page
    {
        private IItemCategoryManager _itemCategoryManager;
        private IItemManager _itemManager;

        public AddDonatedItem()
        {
            InitializeComponent();
            _itemCategoryManager = new ItemCategoryManager();
            _itemManager = new ItemManager();
        }// End Constructor

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
            cboBxCategory.Items.Clear();
            List<ItemCategory> list = new List<ItemCategory>();
            list = _itemCategoryManager.listItemCategories();
            foreach (var item in list)
            {
                cboBxCategory.Items.Add(item.ItemCategoryID);
            }
        }// End cboBxCategory_Loaded()

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Steve Coonrod 
        ///
        /// When the user clicks this button, it will add a new item category.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            ItemCategory itemCategory = new ItemCategory();

            if (txtAddCategory != null && txtAddCategory.Text != "" && txtCategoryDesc.Text != "" && txtCategoryDesc != null)
            {
                itemCategory.ItemCategoryID = txtAddCategory.Text;
                itemCategory.Description = txtCategoryDesc.Text;
                _itemCategoryManager.createNewItemCategory(itemCategory);
                refreshCategories();
                "Category Name has been added!".SuccessMessage();
                txtAddCategory.Clear();
                txtCategoryDesc.Clear();
                txtItemName.Focus();
            }
            else
            {
                "Category Name Or Category Description cannot be empty.".ErrorMessage();
            }
        }// End btnAddCategory_Click()

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Steve Coonrod  
        ///
        /// This method refreshes the ComboBox that shows Item Categories to choose from.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshCategories()
        {
            cboBxCategory.Items.Clear();
            List<ItemCategory> list = new List<ItemCategory>();
            list = _itemCategoryManager.listItemCategories();
            foreach (var item in list)
            {
                cboBxCategory.Items.Add(item.ItemCategoryID);
            }
        }// End refreshCategories()

        /// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE: 2020-03-06
		/// CHECKED BY: Steve Coonrod
		/// 
		/// Method that cancels the Add Donated Item Process, and 
        /// returns to Shelter Inventory view.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ShelterInventory());
        }// End btnCancel_Click()

        /// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE: 2020-03-06
		/// CHECKED BY: Steve Coonrod
		/// 
		/// Method that Adds a new Donated Item to the Shelter Inventory.
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
        private void btnAddDonation_Click(object sender, RoutedEventArgs e)
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

            if (txtItemName.Text.ToString() == "")
            {
                MessageBox.Show("Please enter an Item Name.");
                txtItemName.Focus();
                return;
            }
            if (txtItemQty.Text.ToString() == "")
            {
                MessageBox.Show("Please enter the Item Quantity Donated.");
                txtItemQty.Focus();
                return;
            }
            if (txtShelterThreshold.Text.ToString() == "")
            {
                MessageBox.Show("Please enter a Sheltry Threshold.");
                txtShelterThreshold.Focus();
                return;
            }
            if (txtItemDesc.Text.ToString() == "")
            {
                MessageBox.Show("Please enter a Description of the Item Donated.");
                txtItemDesc.Focus();
                return;
            }

            Item donatedItem = new Item()
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
                _itemManager.CreateNewDonatedItem(donatedItem);
                MessageBox.Show("Added " + txtItemQty.Text + " " + txtItemName.Text + " to the Shelter Inventory.");
                txtItemName.Text = "";
                txtItemQty.Text = "";
                txtShelterThreshold.Text = "";
                txtItemDesc.Text = "";
                txtShelterThreshold.Text = "";
                refreshCategories();
                this.NavigationService?.Navigate(new ShelterInventory());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }// End btnAddDonation_Click()

        /// <summary>
		/// CREATED BY: Matt Deaton
		/// DATE: 2020-03-17
		/// CHECKED BY: Steve Coonrod
		/// 
		/// Method that sets the focus to the Item Name when page is loaded.
		/// 
		/// </summary>
		/// <remarks>
		/// UPDATED BY:
		/// UPDATED:
		/// CHANGE:
		/// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txtItemName.Focus();
        }// End Grid_loaded()
    }// End class AddDonatedItem

}// End namespace  WPFPresentationLayer.InventoryPages