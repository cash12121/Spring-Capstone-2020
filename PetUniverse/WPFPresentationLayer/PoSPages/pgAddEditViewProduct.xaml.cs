using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for pgAddEditViewProduct.xaml
    /// </summary>
    public partial class pgAddEditViewProduct : Page
    {
        private Frame _frame;
        private IProductManager _productManager;
        private IPictureManager _pictureManager;
        private List<Product> _products;
        private Product _product;
        private InventoryItems _inventoryItem;
        private Picture _picture;
        private bool _pictureUpdated = false;
        private bool _editMode;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Constructor used for adding a new product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="frame">Frame used for navigation.</param>
        /// <param name="productManager">ProductManager passed from previous screen to avoid having to instantiate a new one.</param>
        /// <param name="item">Item selected from previous screen.</param>
        public pgAddEditViewProduct(Frame frame, IProductManager productManager, Item item)
        {
            _frame = frame;
            _productManager = productManager;
            _pictureManager = new PictureManager();
            _product = new Product();
            _picture = new Picture();
            InitializeComponent();
            setItemFields(item);
            initializeComboBoxes();
            lblHeading.Content = "Add a New Product";
            btnAction.Content = "Save";
            try
            {
                _products = _productManager.RetrieveAllProductsByType();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Failed to load product list.");
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: 
        /// 
        /// Constroctor for view/edit operations.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Migrated edit functionality from other tab.
        /// 
        /// </remarks>
        /// <param name="frame"></param>
        /// <param name="inventoryItem"></param>
        /// <param name="editMode"></param>
        public pgAddEditViewProduct(Frame frame, InventoryItems inventoryItem, bool editMode = false)
        {
            _frame = frame;
            _productManager = new ProductManager();
            _pictureManager = new PictureManager();
            _inventoryItem = inventoryItem;
            _editMode = editMode;
            try
            {
                _product = _productManager.RetrieveProductByID(inventoryItem.ProductID);
                _picture = _pictureManager.RetrieveMostRecentPictureByProductID(_product.ProductID);
                _products = _productManager.RetrieveAllProductsByType();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("There was a problem loading product data:\n\n" + ex.Message);
            }
            InitializeComponent();
            setItemFields(_product);
            initializeComboBoxes();
            if (_picture == null)
            {
                _picture = new Picture();
            }

            try
            {
                using (var stream = new MemoryStream(_picture.ImageData))
                {
                    imgPicture.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("There was a problem loading the picture.\n\n" + ex.Message);
            }

            if (!editMode)
            {
                lblHeading.Content = "View Product";
                btnAction.Content = "Done";
                btnCancel.Visibility = Visibility.Hidden;
                makeReadOnly();
            }
            else
            {
                lblHeading.Content = "Edit Product";
                btnAction.Content = "Update";
                makeEditable();
                txtProductID.IsReadOnly = true;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Method to set the data contained in the item passed in.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="item">Item data to use.</param>
        private void setItemFields(Item item)
        {
            txtItemID.Text = item.ItemID.ToString();
            txtName.Text = item.ItemName;
            txtCategory.Text = item.ItemCategoryID;
            txtDescription.Text = item.Description;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Gets information about the product into the controls.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void setItemFields(Product product)
        {
            txtProductID.Text = product.ProductID;
            txtItemID.Text = product.ItemID.ToString();
            txtName.Text = product.Name;
            txtCategory.Text = product.Category;
            txtBrand.Text = product.Brand;
            numPrice.Text = product.Price.ToString("C");
            txtDescription.Text = product.Description;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Method to set the data sources for the combo boxes on the page.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void initializeComboBoxes()
        {
            cboTaxable.ItemsSource = new List<string> { "Yes", "No" };
            if (_product != null)
            {
                if (_product.ProductID == null)
                {
                    cboTaxable.SelectedItem = "Yes";
                }
                else if (!_product.Taxable)
                {
                    cboTaxable.SelectedItem = "No";
                }
                else
                {
                    cboTaxable.SelectedItem = "Yes";
                }
            }

            cboType.ItemsSource = _productManager.RetrieveAllProductTypeIDs();
            if (_product != null)
            {
                cboType.SelectedItem = _product.Type;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Handles navigation without saving any changes made.
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
            if (MessageBoxResult.Yes == MessageBox.Show("You will lose any entered data. Continue?", "Abandon Product", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                _frame.Navigate(new pgInventoryItems(_frame));
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Handles saving product data to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            switch (btnAction.Content)
            {
                case ("Save"):
                    {
                        if (validateFields())
                        {
                            try
                            {
                                _product.ProductID = txtProductID.Text;
                                _product.ItemID = Convert.ToInt32(txtItemID.Text);
                                _product.Name = txtName.Text;
                                _product.Category = txtCategory.Text;
                                _product.Brand = txtBrand.Text;
                                _product.Type = (string)cboType.SelectedItem;
                                _product.Price = (decimal)numPrice.Value;
                                _product.Description = txtDescription.Text;
                                if ((string)cboTaxable.SelectedItem == "No")
                                {
                                    _product.Taxable = false;
                                }
                                else
                                {
                                    _product.Taxable = true;
                                }

                                _productManager.AddProduct(_product);

                                _picture.ProductID = _product.ProductID;
                                if (!_picture.IsUsingDefault)
                                {
                                    _pictureManager.AddPicture(_picture);
                                }
                            }
                            catch (Exception ex)
                            {
                                WPFErrorHandler.ErrorMessage("Failed to save product to database.\n\n" + ex.Message, ex.GetType().ToString());
                            }
                            _frame.Navigate(new pgInventoryItems(_frame));
                        }

                        break;
                    }
                case "Update":
                    {
                        if (validateFields())
                        {
                            try
                            {
                                var newProduct = new Product
                                {
                                    ProductID = _product.ProductID,
                                    ItemID = Convert.ToInt32(txtItemID.Text),
                                    Name = txtName.Text,
                                    Category = txtCategory.Text,
                                    Brand = txtBrand.Text,
                                    Type = (string)cboType.SelectedItem,
                                    Price = (decimal)numPrice.Value,
                                    Description = txtDescription.Text,
                                    Active = _product.Active
                                };
                                if (cboTaxable.SelectedItem.ToString().Equals("No"))
                                {
                                    newProduct.Taxable = false;
                                }
                                else
                                {
                                    newProduct.Taxable = true;
                                }
                                _productManager.EditProduct(_product, newProduct);
                                _picture.ProductID = _product.ProductID;
                                if (_pictureUpdated)
                                {
                                    _pictureManager.AddPicture(_picture);
                                }
                            }
                            catch (Exception ex)
                            {
                                WPFErrorHandler.ErrorMessage("There was a problem saving the new product information:\n\n" + ex.Message);
                            }
                            _frame.Navigate(new pgInventoryItems(_frame));
                        }
                        break;
                    }
                case "Done":
                    {
                        _frame.Navigate(new pgInventoryItems(_frame));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Validates product information.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns>Returns true if field contents are acceptable.</returns>
        private bool validateFields()
        {
            Regex notAlphaNum = new Regex("[^A-Za-z0-9]+");
            bool isValid = false;
            while (!isValid)
            {
                //ProductID
                if (txtProductID.Text.Equals(""))
                {
                    WPFErrorHandler.ErrorMessage("You must enter a Product ID.");
                    txtProductID.Focus();
                    break;
                }
                if (txtProductID.Text.Contains(" "))
                {
                    WPFErrorHandler.ErrorMessage("Product ID may not contain spaces.");
                    txtProductID.Focus();
                    break;
                }
                if (!_editMode)
                {
                    bool duplicate = false;
                    foreach (Product p in _products)
                    {
                        if (p.ProductID.Equals(txtProductID.Text))
                        {
                            duplicate = true;
                        }
                    }
                    if (duplicate)
                    {
                        WPFErrorHandler.ErrorMessage("There is already a product with that Product ID, you must enter a new one.");
                        txtProductID.Focus();
                        break;
                    }
                }
                if (notAlphaNum.IsMatch(txtProductID.Text))
                {
                    WPFErrorHandler.ErrorMessage("Product ID may only contain numbers and letters.");
                    txtProductID.Focus();
                    break;
                }
                //Type
                if (cboType.SelectedItem == null)
                {
                    WPFErrorHandler.ErrorMessage("You must select a product type.");
                    cboType.Focus();
                    break;
                }
                //Brand
                if (txtBrand.Text.Equals(""))
                {
                    WPFErrorHandler.ErrorMessage("You must enter a product brand.");
                    txtBrand.Focus();
                    break;
                }
                //Price
                if (numPrice.Value == null)
                {
                    WPFErrorHandler.ErrorMessage("You must enter a valid price.");
                    numPrice.Focus();
                    break;
                }
                //Taxable
                if (cboTaxable.SelectedItem == null)
                {
                    WPFErrorHandler.ErrorMessage("You must indicate whether this product is subject to sales tax.");
                    cboTaxable.Focus();
                    break;
                }
                //Description
                //None
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/26/2020
        /// Approver: Jaeho Kim
        /// 
        /// Opens a file dialog to allow someone to upload an image for a product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicture_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.Filter = "Pictures (*.jpg, *.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png|All Files|*.*";
            fileDialog.FilterIndex = 0;
            fileDialog.RestoreDirectory = true;
            fileDialog.Multiselect = false;

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = fileDialog.FileName;

                if (!path.Equals(""))
                {
                    string extension = Path.GetExtension(path);

                    List<string> acceptableExtensions = new List<string>(new string[] { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" });

                    if (acceptableExtensions.Contains(extension))
                    {

                        var bmi = new BitmapImage();
                        bmi.BeginInit();
                        bmi.UriSource = new Uri(path);
                        bmi.EndInit();
                        imgPicture.Stretch = Stretch.Uniform;
                        imgPicture.Source = bmi;

                        _picture.ImageData = System.IO.File.ReadAllBytes(path);
                        _picture.ImageMimeType = getMimeType(extension);
                        _pictureUpdated = true;
                    }
                    else
                    {
                        StringBuilder errorSB = new StringBuilder();
                        errorSB.Append("Incorrect File Format!\n\nMust have extension: ");
                        for (int i = 0; i < acceptableExtensions.Count; i++)
                        {
                            if (i != 0)
                            {
                                errorSB.Append(", ");
                            }
                            if (i == acceptableExtensions.Count - 1)
                            {
                                errorSB.Append("or ");
                            }
                            errorSB.Append(acceptableExtensions[i]);
                        }
                        WPFErrorHandler.ErrorMessage(errorSB.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns mime type based on file extension.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private string getMimeType(string fileExtension)
        {
            string result = "";
            if (fileExtension.Equals(".jpg") || fileExtension.Equals(".jpeg") || fileExtension.Equals(".jpe"))
            {
                result = "image/jpeg";
            }
            else if (fileExtension.Equals(".jfif"))
            {
                result = "image/pjpeg";
            }
            else if (fileExtension.Equals(".png"))
            {
                result = "image/png";
            }

            return result;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Makes fields read only (for viewing).
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void makeReadOnly()
        {
            txtProductID.IsReadOnly = true;
            cboType.IsEnabled = false;
            txtBrand.IsReadOnly = true;
            numPrice.ShowButtonSpinner = false;
            numPrice.IsEnabled = false;
            txtDescription.IsReadOnly = true;
            cboTaxable.IsEnabled = false;
            btnPicture.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Makes fields editable (for editing).
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void makeEditable()
        {
            txtProductID.IsReadOnly = false;
            cboType.IsEnabled = true;
            txtBrand.IsReadOnly = false;
            numPrice.ShowButtonSpinner = true;
            numPrice.IsEnabled = true;
            txtDescription.IsReadOnly = false;
            cboTaxable.IsEnabled = true;
            btnPicture.Visibility = Visibility.Visible;
        }
    }
}
