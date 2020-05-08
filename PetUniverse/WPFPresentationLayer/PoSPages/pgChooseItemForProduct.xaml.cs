using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for pgChooseItemForProduct.xaml
    /// </summary>
    public partial class pgChooseItemForProduct : Page
    {
        Frame _frame;
        IItemManager _itemManager;
        IProductManager _productManager;
        List<Item> _items;
        List<Product> _products = new List<Product>();

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Cash Carlson
        /// 
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public pgChooseItemForProduct()
        {
            _itemManager = new ItemManager();
            _productManager = new ProductManager();
            try
            {
                _items = _itemManager.retrieveItemsByActive(active: true);
                _products = _productManager.RetrieveAllProductsByType();
            }
            catch (Exception)
            {
                WPFErrorHandler.ErrorMessage("Failed to load inventory items.");
            }
            InitializeComponent();
            _items = getItemsWithoutProducts(_items);
            dgItems.ItemsSource = _items;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Cash Carlson
        /// 
        /// Constructor that takes a frame for navigation purposes.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="frame">The frame to use for navigation.</param>
        public pgChooseItemForProduct(Frame frame)
        {
            _itemManager = new ItemManager();
            _productManager = new ProductManager();
            _frame = frame;
            try
            {
                _items = _itemManager.retrieveItemsByActive(active: true);
                _products = _productManager.RetrieveAllProductsByType();
            }
            catch (Exception)
            {
                WPFErrorHandler.ErrorMessage("Failed to load inventory items.");
            }
            InitializeComponent();
            _items = getItemsWithoutProducts(_items);
            dgItems.ItemsSource = _items;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Cash Carlson
        /// 
        /// Filters the list of items based on the content of txtSearch.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var _filteredItems = new List<Item>();
                Regex regex;
                if (!txtSearch.Text.Equals(""))
                {
                    regex = new Regex("(" + txtSearch.Text.ToLower() + ")");
                    foreach (Item item in _items)
                    {
                        bool isChecked = false;
                        while (!isChecked)
                        {
                            if (regex.Match(item.ItemID.ToString().ToLower()).Success)
                            {
                                _filteredItems.Add(item);
                                break;
                            }
                            if (regex.Match(item.ItemName.ToLower()).Success)
                            {
                                _filteredItems.Add(item);
                                break;
                            }
                            if (regex.Match(item.ItemCategoryID.ToLower()).Success)
                            {
                                _filteredItems.Add(item);
                                break;
                            }
                            if (regex.Match(item.Description.ToLower()).Success)
                            {
                                _filteredItems.Add(item);
                            }
                            isChecked = true;
                        }
                    }
                }
                else
                {
                    _filteredItems = _items;
                }
                dgItems.ItemsSource = _filteredItems;
            }
            catch (Exception)
            {
                WPFErrorHandler.ErrorMessage("Failed to search items.");
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Cash Carlson
        /// 
        /// Format columns for the data grid.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update:
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgItems_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string header = e.Column.Header.ToString();
            if (header.Equals("ItemID"))
            {
                e.Column.Header = "Item ID";
            }
            else if (header.Equals("ItemName"))
            {
                e.Column.Header = "Item Name";
            }
            else if (header.Equals("ItemQuantity"))
            {
                e.Column.Header = "Quantity";
            }
            else if (header.Equals("ItemCategoryID"))
            {
                e.Column.Header = "Category";
            }
            else if (header.Equals("Description"))
            {

            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Cash Carlson
        /// 
        /// Returns a list containing only items without associated products.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<Item> getItemsWithoutProducts(List<Item> items)
        {
            var filteredItems = new List<Item>();
            if (_items != null)
            {
                foreach (Item i in _items)
                {
                    bool hasProduct = false;
                    foreach (Product p in _products)
                    {
                        if (i.ItemID == p.ItemID)
                        {
                            hasProduct = true;
                            break;
                        }
                    }
                    if (!hasProduct)
                    {
                        filteredItems.Add(i);
                    }
                }
            }
            return filteredItems;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Cash Carlson
        /// 
        /// Navigates to the previous page.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new pgInventoryItems(_frame));
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Cash Carlson
        /// 
        /// Sends inventory item data to the page used to create a new product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (dgItems.SelectedItem != null)
            {
                Item item = (Item)dgItems.SelectedItem;
                _frame.Navigate(new pgAddEditViewProduct(_frame, _productManager, item));
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Cash Carlson
        /// 
        /// Sends inventory item data to the page used to create a new product but with a double click.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void dgItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnChoose_Click(sender, e);
        }
    }
}
