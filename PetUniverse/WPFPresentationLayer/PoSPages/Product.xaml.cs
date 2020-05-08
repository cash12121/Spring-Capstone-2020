using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 3/3/2020
    /// Approver: Robert Holmes
    /// 
    /// This class has interaction logic for the PetUniverseHome window
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    /// </summary>
    public partial class ViewAllProducts : Page
    {
        private IProductManager _productManager;
        private Product _product = null;


        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/3/2020
        /// Approver: Robert Holmes
        /// 
        /// This is the default constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ViewAllProducts()
        {
            InitializeComponent();
            _productManager = new ProductManager();
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/3/2020
        /// Approver: Robert Holmes
        ///  
        /// This method is show the list of Product when the window loads
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProductList_Loaded(object sender, RoutedEventArgs e)
        {
            ShowList();

        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/3/2020
        /// Approver: Robert Holmes
        /// 
        /// This method is retrive list of product. 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        ///
        private void ShowList()
        {
            dgProductList.ItemsSource = _productManager.RetrieveAllProducts();


            dgProductList.Columns[0].Header = "ProductID";
            dgProductList.Columns[1].Header = "ItemID";
            dgProductList.Columns[2].Header = "ProductName";
            dgProductList.Columns[3].Header = "ProductCategoryID";
            dgProductList.Columns[4].Header = "ProductTypeID";
            dgProductList.Columns[5].Header = "Description";
            dgProductList.Columns[6].Header = "Price";
            dgProductList.Columns[7].Header = "Brand";
            dgProductList.Columns[8].Header = "Taxable";

        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/10/2020
        /// Approver: Robert Holmes
        /// 
        /// This method shows you adetials of one product that you selected 
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewProducts.Visibility = Visibility.Hidden;
            EditProduct.Visibility = Visibility.Visible;
            txtPrice.Focus();
            btnDone.Visibility = Visibility.Visible;

            _product = (Product)dgProductList.SelectedItem;

            txtProductID.Text = _product.ProductID.ToString();
            txtItemID.Text = _product.ItemID.ToString();
            txtProductName.Text = _product.Name.ToString();
            txtProductCategoryID.Text = _product.Category.ToString();
            txtProductTypeID.Text = _product.Type.ToString();
            txtDescription.Text = _product.Description.ToString();
            txtPrice.Text = _product.Price.ToString();
            txtBrand.Text = _product.Brand.ToString();
            txtTaxable.Text = _product.Taxable.ToString();

        }


        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 3/11/2020
        /// Approver: Robert Holmes
        /// 
        /// This method Validate the Updated data and retrieve it after update
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDone_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                Product newProduct = new Product()
                {
                    ProductID = txtProductID.Text,
                    ItemID = Convert.ToInt32(txtItemID.Text),
                    Name = txtProductName.Text,
                    Category = txtProductCategoryID.Text,
                    Type = txtProductTypeID.Text,
                    Description = txtDescription.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Brand = txtBrand.Text,
                    Taxable = Convert.ToBoolean(txtTaxable.Text)
                };

                if (_productManager.EditProduct(_product, newProduct))
                {
                    ShowList();
                    ViewProducts.Visibility = Visibility.Visible;
                    EditProduct.Visibility = Visibility.Hidden;
                    btnDone.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("The price did not change");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("You must enter a valid price. \n \n" + ex.Message);
                txtPrice.Focus();
            }



        }
    }
}
