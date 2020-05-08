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
    /// Creator: Tener karar
    /// Created: 2020/02/7
    /// Approver: Brandyn T. Coverdill
    ///
    /// The main presentaion layer for  item class
    /// Contains all methods for performing basic item functions
    /// </summary>

    public partial class ViewInventory : Page
    {
        private IItemManager _itemManager;
        private IManageBackstockRecords StockManger;
        private Item item;
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this constrctor method mainwindow class 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        public ViewInventory()
        {
            InitializeComponent();
            StockManger = new ManageBackstockRecords();
            _itemManager = new ItemManager();
            item = new Item();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/03
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This click event opens the view item detail screen.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer  
        /// Updated: 4/13/2020
        /// Update: Moved from ViewInventory page
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)DGViewDatat.SelectedItem;
            if (DGViewDatat.SelectedItem != null)
            {
                this.NavigationService?.Navigate(new ViewItemDetail(item));
            }
            else
            {
                "Please pick an item to view.".ErrorMessage();
            }
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this event for main window class 
        /// desplay the item in the screen item  
        /// </summary>
        /// Updater Brandyn T. Coverdill
        /// Updated: 4/29/2020 
        /// Update: Changed the Accessor method to get a list of items more accurately.
        /// <remarks>
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGViewDatat.ItemsSource = _itemManager.retrieveItems();

        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Steven Cardona
        /// 
        /// this method creating a list to holde item list
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = StockManger.EditItemLocation(Convert.ToInt32(txtItemID.Text),
                 Convert.ToInt32(txtItemLocation.Text), Convert.ToInt32(txtNewItemLocation.Text));

                lblItemAdd.Content = "The item location updated.";
                txtItemLocation.Text = txtNewItemLocation.Text;
                txtNewItemLocation.Text = "";
            }
            catch (Exception)
            {
                lblItemAdd.Content = "Please enter a proper item location.";
            }
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Brandyn T. Coverdill
        /// 
        /// this method  for show update loction and Hiding item view
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DGViewDatat.UnselectAll();
            txtItemID.Text = "";
            txtItemName.Text = "";
            txtItemLocation.Text = "";
            txtNewItemLocation.Text = "";
            txtItemDescription.Text = "";
            txtItemCount.Text = "";

            canViewItems.Visibility = Visibility.Visible;
            canEditItemsLocation.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver:  Brandyn T. Coverdill
        /// 
        /// Auto generated columns method
        /// </summary>
        ///
        /// <remarks>
        /// Updater Matt Deaton
        /// Updated: 2020-03-07 
        /// Update: Removed Column 3 to insure the Shelter Threshold didn't show up in Data Grid
        /// 
        /// Updater Name: Brandyn T. Coverdill
        /// Updated: 4/29/2020
        /// Update: Removed the Identity field and renamed the columns.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGViewDatat_AutoGeneratedColumns(object sender, EventArgs e)
        {
            // Remove the columns.
            DGViewDatat.Columns.RemoveAt(3);
            DGViewDatat.Columns.RemoveAt(0);

            // this fill all availalbe space with available columns
            foreach (var column in this.DGViewDatat.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }

            // Renaming fields
            DGViewDatat.Columns[0].Header = "Item Name";
            DGViewDatat.Columns[1].Header = "Quantity";
            DGViewDatat.Columns[2].Header = "Item Category";
            DGViewDatat.Columns[3].Header = "Description";
            DGViewDatat.Columns[4].Header = "Is an Active Item";
            DGViewDatat.Columns[5].Header = "Is a Shelter Item";
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this event for main window class 
        /// desplay the item in the screen item  
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/13/2020
        /// Update: Added if item = null logic
        /// </remarks>
        private void btnUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            item = (Item)DGViewDatat.SelectedItem;
            List<int> locations = null;

            if (item != null)
            {
                try
                {
                    locations = StockManger.getItemLocations(item.ItemID);
                    txtItemID.Text = item.ItemID.ToString();
                    txtItemName.Text = item.ItemName;
                    txtItemLocation.Text = locations[0].ToString();
                    txtNewItemLocation.Text = "";
                    txtItemDescription.Text = item.Description;
                    txtItemCount.Text = locations.Count.ToString();

                }
                catch (Exception)
                {
                    locations = new List<int>();
                }


                canViewItems.Visibility = Visibility.Hidden;
                canEditItemsLocation.Visibility = Visibility.Visible;
            }
            else
            {
                WPFErrorHandler.ErrorMessage("No Item Selected. Please select one.");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/01
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// This Button shows the Add Item Screen.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer  
        /// Updated: 4/13/2020
        /// Update: Moved from ViewInventory page
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new AddItems());
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/13
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesee Tomash
        ///
        /// Click event for deactivate button
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer  
        /// Updated: 4/13/2020
        /// Update: Moved from ViewInventory page
        /// 
        /// Updater: Brandyn T. Coverdill
        /// Updated: 4/29/2020
        /// Update: Made it avaliable to reactivate an item.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeactivateItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)DGViewDatat.SelectedItem;
            if (DGViewDatat.SelectedItem != null)
            {
                if (item.Active == true)
                {
                    _itemManager.deactivateItem(item);
                    DGViewDatat.ItemsSource = _itemManager.retrieveItems();
                }
                else if (item.Active == false)
                {
                    _itemManager.reactivateItems(item);
                    DGViewDatat.ItemsSource = _itemManager.retrieveItems();
                }
            }
            else
            {
                "Please pick an item to view.".ErrorMessage();
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// This Button shows the Add Item Report Screen.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddItemReport_Click(object sender, RoutedEventArgs e)
        {
            Item item = (Item)DGViewDatat.SelectedItem;
            if (DGViewDatat.SelectedItem != null)
            {
                this.NavigationService?.Navigate(new AddItemReport(item));
            }
            else
            {
                "Please pick an item to add a new report.".ErrorMessage();
            }
        }
    }
}
