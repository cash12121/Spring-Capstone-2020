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
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: 
    /// Approver: 
    ///
    /// This page handles adding new items to inventory and adding a new category if needed.
    /// </summary>
    public partial class AddItems : Page
    {
        private IItemCategoryManager _itemCategoryManager;
        private IItemManager _itemManager;

        public AddItems()
        {
            InitializeComponent();
            _itemManager = new ItemManager();
            _itemCategoryManager = new ItemCategoryManager();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: 
        /// Approver:  
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
        }


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: 
        /// Approver:  
        ///
        /// When the user clicks this button, it will add the item to the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (txtItemName.Text != "" && txtItemQty.Text != "" && cboBxCategory.Text != "")
            {
                // Seeing if the Quanitity of items can be a number.
                try
                {
                    int quantity = Int32.Parse(txtItemQty.Text);
                    Item item = new Item();
                    item.ItemName = txtItemName.Text;
                    item.ItemQuantity = quantity;
                    item.Description = txtItemDesc.Text;
                    string ItemCatName = cboBxCategory.Text;
                    string ItemCatID = cboBxCategory.SelectedItem.ToString();

                    item.ItemCategoryID = ItemCatID;
                    _itemManager.createNewItem(item);
                    "Successfully Added Item to Inventory!".SuccessMessage();
                    txtAddCategory.Clear();
                    txtItemName.Clear();
                    txtItemQty.Clear();
                    cboBxCategory.Text = "";
                    txtItemName.Focus();
                }
                catch (FormatException)
                {
                    "Item Quanitity must be a number.".ErrorMessage();
                }
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: 
        /// Approver:  
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
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: 
        /// Approver:  
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
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: 
        /// Approver:  
        ///
        /// This method refreshes the ComboBox that shows Item Categories to choose from.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/13/2020
        /// Update: Redirect to ViewInventory page upon click
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewInventory());
        }
    }
}