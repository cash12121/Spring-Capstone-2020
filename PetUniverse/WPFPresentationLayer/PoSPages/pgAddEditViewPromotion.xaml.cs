using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Interaction logic for pgAddEditViewPromotion.xaml
    /// </summary>
    public partial class pgAddEditViewPromotion : Page
    {
        private IPromotionManager _promotionManager;
        private IProductManager _productManager;
        private Promotion _promotion;
        private Frame _frame;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Constructor used for add operations.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public pgAddEditViewPromotion(IPromotionManager promotionManager, Frame frame)
        {
            _promotionManager = promotionManager;
            _frame = frame;
            _promotion = new Promotion();
            InitializeComponent();
            lblPageHeading.Content = "Add New Promotion";
            btnAction.Content = "Add Promo";
            cboPromotionType.ItemsSource = _promotionManager.GetAllPromotionTypes();
            dgProducts.ItemsSource = _promotion.Products;
            _productManager = new ProductManager();
            makeEditable();
            setupNumUpDown();
            btnToggleActive.IsEnabled = false;
            txtActive.Text = "Active";
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Constructor for use when viewing the details of a promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public pgAddEditViewPromotion(IPromotionManager promotionManager, Frame frame, Promotion promotion)
        {
            _promotionManager = promotionManager;
            _frame = frame;
            _promotion = promotion;
            InitializeComponent();
            lblPageHeading.Content = "Promotion Details";
            btnAction.Content = "Done";
            btnCancel.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Hidden;
            btnRemove.Visibility = Visibility.Hidden;
            txtSearch.Visibility = Visibility.Hidden;
            loadFields();
            makeReadOnly();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Constructor for edit operations.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public pgAddEditViewPromotion(IPromotionManager promotionManager, Frame frame, Promotion promotion, bool editMode = true)
        {
            if (editMode)
            {
                _promotionManager = promotionManager;
                _frame = frame;
                _promotion = promotion;
                InitializeComponent();
                lblPageHeading.Content = "Editing Promotion";
                btnAction.Content = "Save";
                loadFields();
                makeEditable();
                txtPromotionID.IsReadOnly = true;
            }
            else
            {
                _frame.Navigate(new pgAddEditViewPromotion(promotionManager, frame, promotion));
            }
        }
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Sets editable controls to an uneditable state.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void makeReadOnly()
        {
            txtPromotionID.IsReadOnly = true;
            dateStartDate.IsEnabled = false;
            numDiscount.IsEnabled = false;
            dateEndDate.IsEnabled = false;
            cboPromotionType.IsEnabled = false;
            txtDescription.IsReadOnly = true;
            btnToggleActive.IsEnabled = false;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Sets editable controls to an editable state.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void makeEditable()
        {
            txtPromotionID.IsReadOnly = false;
            dateStartDate.IsEnabled = true;
            dateEndDate.IsEnabled = true;
            numDiscount.IsEnabled = true;
            cboPromotionType.IsEnabled = true;
            txtDescription.IsReadOnly = false;
            btnToggleActive.IsEnabled = true;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/11
        /// Approver: Cash Carlson
        /// 
        /// Loads values into item sources.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 2020/03/19
        /// Update: Now loads ALL relevant data
        /// 
        /// </remarks>
        private void loadFields()
        {
            try
            {
                cboPromotionType.ItemsSource = _promotionManager.GetAllPromotionTypes();
                dgProducts.ItemsSource = _promotion.Products;
                _productManager = new ProductManager();
                if (_promotion.PromotionID != null)
                {
                    txtPromotionID.Text = _promotion.PromotionID;
                }
                if (_promotion.PromotionTypeID != null)
                {
                    cboPromotionType.SelectedItem = _promotion.PromotionTypeID;
                }
                if (_promotion.StartDate != null)
                {
                    dateStartDate.SelectedDate = _promotion.StartDate;
                }
                if (_promotion.EndDate != null)
                {
                    dateEndDate.SelectedDate = _promotion.EndDate;
                }
                if (_promotion.Description != null)
                {
                    txtDescription.Text = _promotion.Description;
                }
                numDiscount.Value = _promotion.Discount;
                if (_promotion.Active)
                {
                    txtActive.Text = "Active";
                    btnToggleActive.Content = "Deactivate";
                }
                else
                {
                    txtActive.Text = "Inactive";
                    btnToggleActive.Content = "Reactivate";
                }
                setupNumUpDown();
                if (cboPromotionType.SelectedItem.ToString().Equals("Percent"))
                {
                    numDiscount.FormatString = "P0";
                }
                if (cboPromotionType.SelectedItem.ToString().Equals("Flat Amount"))
                {
                    numDiscount.FormatString = "C2";
                }

            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("There was an issue loading the data", ex.Message);
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/13
        /// Approver:  Cash Carlson
        /// 
        /// Calls method to add a product to the promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProductToPromotion(txtSearch.Text);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/11
        /// Approver:  Cash Carlson
        /// 
        /// Adds a product to the promotion.
        /// </summary>
        /// <param name="ProductID">UPC of the product to add</param>
        public void AddProductToPromotion(string ProductID)
        {
            try
            {
                var products = _productManager.RetrieveAllProductsByType();
                bool found = false;
                foreach (Product p in products)
                {
                    if (p.ProductID.Equals(ProductID))
                    {
                        found = true;
                        bool alreadyAdded = false;
                        foreach (Product key in _promotion.Products)
                        {
                            if (key.ProductID.Equals(ProductID))
                            {
                                alreadyAdded = true;
                                break;
                            }
                        }
                        if (!alreadyAdded)
                        {
                            _promotion.Products.Add(p);
                        }
                        dgProducts.ItemsSource = null;
                        dgProducts.ItemsSource = _promotion.Products;
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
                WPFErrorHandler.ErrorMessage("Failed to add item", ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson 
        /// 
        /// Removes products from the promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem != null)
            {
                _promotion.Products.Remove((Product)dgProducts.SelectedItem);
                dgProducts.ItemsSource = null;
                dgProducts.ItemsSource = _promotion.Products;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Handles add/view/edit commands.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 2020/03/19
        /// Update: Added "Done" and "Save" cases to switch.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            switch (btnAction.Content)
            {
                case ("Add Promo"):
                    if (validateFields())
                    {
                        _promotion.PromotionID = txtPromotionID.Text;
                        _promotion.PromotionTypeID = cboPromotionType.SelectedItem.ToString();
                        _promotion.StartDate = (DateTime)dateStartDate.SelectedDate;
                        _promotion.EndDate = (DateTime)dateEndDate.SelectedDate;
                        _promotion.Discount = (decimal)numDiscount.Value;
                        _promotion.Description = txtDescription.Text;
                        try
                        {
                            _promotionManager.AddPromotion(_promotion);
                            _frame.Navigate(new pgPromotion(_frame));
                        }
                        catch (SqlException)
                        {
                            WPFErrorHandler.ErrorMessage("Promotion ID must be unique.");
                            txtPromotionID.Focus();
                        }
                        catch (Exception)
                        {
                            WPFErrorHandler.ErrorMessage("Unable to add promotion");
                        }
                    }
                    break;
                case ("Done"):
                    {
                        _frame.Navigate(new pgPromotion(_frame));
                        break;
                    }
                case ("Save"):
                    {
                        if (validateFields())
                        {
                            Promotion newPromotion = new Promotion();
                            newPromotion.PromotionID = txtPromotionID.Text;
                            newPromotion.PromotionTypeID = cboPromotionType.SelectedItem.ToString();
                            newPromotion.StartDate = (DateTime)dateStartDate.SelectedDate;
                            newPromotion.EndDate = (DateTime)dateEndDate.SelectedDate;
                            newPromotion.Discount = (decimal)numDiscount.Value;
                            newPromotion.Description = txtDescription.Text;
                            newPromotion.Products = _promotion.Products;
                            try
                            {
                                _promotionManager.EditPromotion(_promotion, newPromotion);
                                _frame.Navigate(new pgPromotion(_frame));
                            }
                            catch (Exception ex)
                            {
                                WPFErrorHandler.ErrorMessage("Failed to save edit.");
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Validates fields.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 2020/03/19
        /// Update: Fixed an issue that would cause the value from numDiscount to throw an error.
        /// 
        /// </remarks>
        /// <returns>Returns true if field contents are acceptable.</returns>
        private bool validateFields()
        {
            bool valid = false;
            while (!valid)
            {
                //txtPromotionID
                if (txtPromotionID.Text == null)
                {
                    WPFErrorHandler.ErrorMessage("Promotion ID may not be null.");
                    txtPromotionID.Focus();
                    break;
                }
                if (txtPromotionID.Text.Equals("") || txtPromotionID.Text.Length > 20)
                {
                    WPFErrorHandler.ErrorMessage("Promotion ID must contain between 1 and 20 characters.");
                    txtPromotionID.Focus();
                    break;
                }
                if (txtPromotionID.Text.Contains(" "))
                {
                    WPFErrorHandler.ErrorMessage("Promotion ID may not contain spaces.");
                    txtPromotionID.Focus();
                    break;
                }

                //cboPromotionType
                if (cboPromotionType.SelectedItem == null)
                {
                    WPFErrorHandler.ErrorMessage("You must select a type of discount.");
                    cboPromotionType.Focus();
                    break;
                }
                if (cboPromotionType.SelectedItem.ToString().Equals(""))
                {
                    WPFErrorHandler.ErrorMessage("You must select a type of discount.");
                    cboPromotionType.Focus();
                    break;
                }
                //numDiscount
                // Input sufficiently restricted
                //dateStartDate
                if (dateStartDate.SelectedDate == null)
                {
                    WPFErrorHandler.ErrorMessage("You must select a start date.");
                    dateStartDate.Focus();
                    break;
                }
                //dateEndDate
                if (dateEndDate.SelectedDate == null)
                {
                    WPFErrorHandler.ErrorMessage("You must select an end date.");
                    dateEndDate.Focus();
                    break;
                }
                if (dateEndDate.SelectedDate < dateStartDate.SelectedDate)
                {
                    WPFErrorHandler.ErrorMessage("End date must come after start date.");
                    dateEndDate.Focus();
                    break;
                }
                //txtDescription
                if (txtDescription.Text.Length > 500)
                {
                    WPFErrorHandler.ErrorMessage("Description may not be longer than 500 characters.");
                    txtDescription.Focus();
                    break;
                }
                //dgProducts
                if (_promotion.Products.Count == 0)
                {
                    WPFErrorHandler.ErrorMessage("You must add at least one product to a promotion.");
                    txtSearch.Focus();
                    break;
                }
                valid = true;
            }
            return valid;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Navigates to main promotion page.
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
            if (MessageBoxResult.Yes == MessageBox.Show("You will lose any entered data. Continue?", "Abandon Promotion", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                _frame.Navigate(new pgPromotion(_frame));
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/13
        /// Approver: Cash Carlson
        /// 
        /// Sets up columns for the product data grid.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProducts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
            else if (columnHeader.Equals("Category"))
            {
                e.Column.Header = "Category";
            }
            else if (columnHeader.Equals("Type"))
            {
                e.Column.Header = "Type";
            }
            else if (columnHeader.Equals("Brand"))
            {
                e.Column.Header = "Brand";
            }
            else if (columnHeader.Equals("Price"))
            {
                e.Column.Header = "Price";
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/13
        /// Approver: Cash Carlson
        /// 
        /// Changes settings on related numeric control based on selection in combo box.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPromotionType_DropDownClosed(object sender, EventArgs e)
        {
            setupNumUpDown();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Sets up the numeric control on the page.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void setupNumUpDown()
        {
            if (cboPromotionType.SelectedItem != null)
            {
                if (cboPromotionType.SelectedItem.ToString().Equals("Percent"))
                {
                    numDiscount.Increment = .01M;
                    numDiscount.IsEnabled = true;
                    numDiscount.Watermark = null;
                    numDiscount.Maximum = 1;
                    if (numDiscount.Value > 1)
                    {
                        numDiscount.Text = "0";
                    }
                    numDiscount.FormatString = "P0";
                }
                if (cboPromotionType.SelectedItem.ToString().Equals("Flat Amount"))
                {
                    numDiscount.Increment = .01M;
                    numDiscount.Maximum = decimal.MaxValue;
                    numDiscount.IsEnabled = true;
                    numDiscount.Watermark = null;
                    numDiscount.FormatString = "C2";
                }
                if (cboPromotionType.SelectedItem.ToString().Equals(""))
                {
                    numDiscount.IsEnabled = false;
                    numDiscount.Watermark = "Select Type First";
                }
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Handles active status for current promotion.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToggleActive_Click(object sender, RoutedEventArgs e)
        {
            switch (btnToggleActive.Content)
            {
                case ("Deactivate"):
                    {
                        if (MessageBoxResult.Yes == MessageBox.Show("Deactivate current promotion?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question))
                        {
                            try
                            {
                                _promotionManager.TogglePromotionActive(_promotion);
                                _promotion.Active = false;
                            }
                            catch (Exception ex)
                            {
                                WPFErrorHandler.ErrorMessage("Unable to deactivate promotion:\n\n" + ex.Message);
                            }
                        }
                        break;
                    }
                case ("Reactivate"):
                    {
                        if (MessageBoxResult.Yes == MessageBox.Show("Reactivate current promotion?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question))
                        {
                            try
                            {
                                _promotionManager.TogglePromotionActive(_promotion);
                                _promotion.Active = true;
                            }
                            catch (Exception ex)
                            {
                                WPFErrorHandler.ErrorMessage("Unable to reactivate promotion:\n\n" + ex.Message);
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            loadFields();
        }
    }
}
