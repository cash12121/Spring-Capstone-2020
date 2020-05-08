using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for pgCheckOut.xaml
    /// </summary>
    public partial class pgCheckOut : Page
    {
        private List<Product> _allProducts;
        private IProductManager _productManager = new ProductManager();
        private Transaction _transaction = new Transaction();
        private static readonly decimal TAX_RATE = 0.06M;

        public pgCheckOut()
        {
            InitializeComponent();
            loadProducts();

        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/18/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Formats the columns for the data grid.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTransactionItems_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string columnHeader = e.Column.Header.ToString();
            // Format column content as necessary
            if (e.PropertyType == typeof(decimal))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "$0.00";
            }
            // Format column headings and hide unused 
            if (columnHeader.Equals("Name"))
            {
                e.Column.Header = "Item Name";
            }
            else if (columnHeader.Equals("ProductID"))
            {
                e.Column.Header = "UPC Code";
            }
            else if (columnHeader.Equals("Price"))
            {
                e.Column.Header = "Price";
            }
            else if (columnHeader.Equals("Quantity"))
            {
                e.Column.Header = "Quantity";
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/18/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Loads products into the data grid.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        private void loadProducts()
        {
            try
            {
                _allProducts = _productManager.RetrieveAllProductsByType();
            }
            catch (Exception)
            {
                WPFErrorHandler.ErrorMessage("There was an issue loading Products");
            }
            List<ProductVM> dgItems = new List<ProductVM>();
            if (_transaction.ProductAmounts.Count > 0)
            {
                foreach (Product p in _transaction.ProductAmounts.Keys)
                {
                    _transaction.ProductAmounts.TryGetValue(p, out int qty);
                    dgItems.Add(new ProductVM() { Name = p.Name, Price = p.Price, ProductID = p.ProductID, Quantity = qty });
                }
            }
            dgTransactionItems.ItemsSource = dgItems;
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/18/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Searches for a product based on the information in txtSearch text box.
        /// Temporary functionality until more robust search function is implemented.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            AddProductToTransaction(txtSearch.Text);
            txtSearch.Text = "";
            loadProducts();
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/18/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Adds a product to a transaction.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 2020/03/13
        /// Update: Changed error handling to be more user friendly.
        /// 
        /// </remarks>
        /// <param name="ProductID"></param>
        public void AddProductToTransaction(string ProductID)
        {
            try
            {
                bool found = false;
                foreach (Product p in _allProducts)
                {
                    if (p.ProductID.Equals(ProductID))
                    {
                        found = true;
                        bool alreadyAdded = false;
                        foreach (Product key in _transaction.ProductAmounts.Keys)
                        {
                            if (key.ProductID.Equals(ProductID))
                            {
                                _transaction.ProductAmounts.TryGetValue(key, out int qty);
                                _transaction.ProductAmounts.Remove(key);
                                _transaction.ProductAmounts.Add(p, ++qty);
                                alreadyAdded = true;
                                break;
                            }
                        }
                        if (!alreadyAdded)
                        {
                            _transaction.ProductAmounts.Add(p, 1);
                        }
                        updateTotals();
                        break;
                    }
                }
                if (!found)
                {
                    throw new ArgumentException("Unable to find item");
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Unable to load products", ex.GetType().ToString());
            }
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Does math and displays totals for the transaction.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        private void updateTotals()
        {
            if (_transaction != null)
            {
                decimal subTotal = 0;
                foreach (Product key in _transaction.ProductAmounts.Keys)
                {
                    _transaction.ProductAmounts.TryGetValue(key, out int qty);
                    subTotal += key.Price * qty;
                }
                txtSubtotal.Text = subTotal.ToString("C");
                decimal taxAmt = subTotal * TAX_RATE;
                txtTax.Text = taxAmt.ToString("C");
                decimal total = subTotal + taxAmt;
                txtTotal.Text = total.ToString("C");
            }
        }
    }
}
