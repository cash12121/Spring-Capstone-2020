using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System.Text.RegularExpressions;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
	/// Creator: Jaeho Kim
	/// Created: 03/25/2020
	/// Approver: Rasha Mohammed
    /// Interaction logic for pgOpenTransaction.xaml
	/// </summary>
    public partial class pgOpenTransaction : Page
    {
        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/25/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Default constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public pgOpenTransaction()
        {
            InitializeComponent();

            _transactionManager = new TransactionManager();

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/25/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Gets the User that's logged in.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="user"></param>
        public pgOpenTransaction(PetUniverseUser user)
        {
            employeeID = user.PUUserID;

            InitializeComponent();
            _transactionManager = new TransactionManager();

        }

        // Instantiate the manager class.
        private ITransactionManager _transactionManager;

        // Instantiate the product
        private ProductVM productVM = null;

        // Instantiate the employee id variable for logging.
        private int employeeID;

        // Instantiate the quantity in stock for validations.
        private int quantityInStock = 0;

        // Retrieving the transaction sale data for transaction entry.
        private decimal taxRate;
        private decimal subTotalTaxable;
        private decimal subTotal;
        private decimal total;

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// DATE: 03/17/2020
        /// APPROVER: Jaeho Kim
        ///
        /// Interface method signature for searching a product with Product UPC.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Returns null instead of empty object.
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {

            string productUPC = txtSearchProduct.Text.ToString();
            productVM = null;
            productVM = _transactionManager.RetrieveProductByProductID(productUPC);

            if (productVM != null)
            {

                txtItemName.Text = productVM.Name;
                chkTaxable.IsChecked = productVM.Taxable;
                txtPrice.Text = productVM.Price.ToString();
                txtQuantity.Text = "1";
                txtItemDescription.Text = productVM.ItemDescription;

                quantityInStock = productVM.ItemQuantity;

                btnAddProduct.Visibility = Visibility.Visible;
            }
            else
            {
                clearFields();
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/25/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Loading the page.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtItemName.IsReadOnly = true;
            chkTaxable.IsEnabled = false;
            txtPrice.IsReadOnly = true;
            txtQuantity.IsReadOnly = false;
            txtItemDescription.IsReadOnly = true;
            txtTotal.IsReadOnly = true;
            txtSubTotal.IsReadOnly = true;
            txtSubTotalTaxable.IsReadOnly = true;

            btnAddProduct.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/25/2020
        /// Approver: Rasha Mohammed
        ///
        /// Adds a product to the shopping cart.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: try/catch around dangerous code.
        /// </remarks>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {


            var salesTax = new SalesTax();

            try
            {
                // Populates the salesTax data transfer object by zipcode.
                salesTax.ZipCode = txtZipCode.Text.ToString();
                salesTax.TaxDate = _transactionManager
                    .RetrieveLatestSalesTaxDateByZipCode(txtZipCode.Text.ToString());
                salesTax.TaxRate = _transactionManager
                    .RetrieveTaxRateBySalesTaxDateAndZipCode(txtZipCode.Text.ToString(), salesTax.TaxDate);
                // SalesTax details operation now complete.
            }
            catch (Exception)
            {
                salesTax.TaxRate = 0M;
            }

            taxRate = salesTax.TaxRate;




            bool isValid = false;
            // The logic verifies that the product searched actually exists and is valid.
            try
            {
                // Populates the productVM data transfer object using the product UPC number that was searched.
                ProductVM productVM = new ProductVM()
                {
                    ProductID = txtSearchProduct.Text.ToString(),
                    Name = txtItemName.Text.ToString(),
                    Taxable = chkTaxable.IsChecked == true,
                    Price = decimal.Parse(txtPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    ItemDescription = txtItemDescription.Text.ToString(),
                    ItemQuantity = quantityInStock,
                    Active = true
                };

                isValid = _transactionManager.isItemQuantityValid(_transactionManager.GetAllProducts(), productVM);

                if (isValid)
                {
                    _transactionManager.AddProduct(productVM);

                    // If the product is taxable, add it to the taxable product list.
                    if (productVM.Taxable)
                    {
                        _transactionManager.AddProductTaxable(productVM);
                    }
                    clearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            if (isValid == false)
            {
                // Let the user know that the item quantity did not get entered.
                MessageBox.Show("Invalid Item Quantity");
            }

            // Displays all the products on the data grid.
            dgShoppingCart.ItemsSource = _transactionManager.GetAllProducts();


            // CalculateSubTotal, takes the master list of products.
            // The reason for storing the variable is the value obtained from the CalculateSubTotal 
            // is going to be passed to calculate the total.
            subTotal = _transactionManager.CalculateSubTotal(_transactionManager.GetAllProducts());
            txtSubTotal.Text = subTotal.ToString();


            // CalculateSubTotalTaxable, takes the taxable list of products.
            // The reason for storing the variable is the value obtained from the CalculateSubTotal 
            // is going to be passed to calculate the tax.
            subTotalTaxable = _transactionManager.CalculateSubTotalTaxable(_transactionManager.GetTaxableProducts());
            txtSubTotalTaxable.Text = subTotalTaxable.ToString();

            // tax exempt simply means the tax rate is zero. Zero (tax rate)
            // multiply with sub total taxable is zero. Zero add sub total 
            // is simply the total without tax.
            if (!String.IsNullOrWhiteSpace(txtTaxExemptNumber.Text))
            {
                salesTax.TaxRate = 0;
            }

            // Calculates the total.
            total = _transactionManager.CalculateTotal(subTotal, subTotalTaxable, salesTax);
            txtTotal.Text = total.ToString();

        }


        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/25/2020
        /// Approver: Rasha Mohammed
        ///
        /// Completes the transaction and performs the transaction entry operation.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnCompleteTransaction_Click(object sender, RoutedEventArgs e)
        {
            var transactionType = new TransactionType();
            var transactionStatus = new TransactionStatus();

            // This transactionDate operation 
            // involves ignoring Milliseconds.
            // Seconds do count however!
            DateTime transactionDate = DateTime.Now;
            transactionDate = new DateTime(
            transactionDate.Ticks -
            (transactionDate.Ticks % TimeSpan.TicksPerSecond),
            transactionDate.Kind
            );
            // end transactionDate ignore milliseconds operation.

            var transaction = new Transaction();
            try
            {
                // This is for practical purposes. A cashier should not have to 
                // constantly put in the transaction type for each transaction.
                // A default transaction type is retrieved from the database 
                // everytime the transaction type text is empty.
                if (cbTransactionType.Text == "")
                {
                    transactionType = _transactionManager.RetrieveDefaultTransactionType();
                    cbTransactionType.Text = transactionType.TransactionTypeID;
                }

                if (cbTransactionStatus.Text == "")
                {
                    transactionStatus = _transactionManager.RetrieveDefaultTransactionStatus();
                    cbTransactionStatus.Text = transactionStatus.TransactionStatusID;
                }

                // if the transaction type was return or void, the values for item quantity
                // and total calculations must be negative.
                if (cbTransactionType.Text == "return")
                {
                    subTotalTaxable *= -1;
                    subTotal *= -1;
                    total *= -1;
                }

                if (cbTransactionType.Text == "void")
                {
                    subTotalTaxable *= -1;
                    subTotal *= -1;
                    total *= -1;
                }

                transaction.TransactionDateTime = transactionDate;
                transaction.TaxRate = taxRate;
                transaction.SubTotalTaxable = subTotalTaxable;
                transaction.SubTotal = subTotal;
                transaction.Total = total;
                transaction.TransactionTypeID = cbTransactionType.Text.ToString();
                transaction.EmployeeID = employeeID;
                transaction.TransactionStatusID = cbTransactionStatus.Text.ToString();
                transaction.TaxExemptNumber = txtTaxExemptNumber.Text.ToString();

                transaction.CustomerEmail = txtEmail.Text.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + "Please set the default transaction type or status!");
            }

            var transactionLineProducts = new TransactionLineProducts();
            List<ProductVM> ProductsSoldList = new List<ProductVM>();

            foreach (var item in _transactionManager.GetAllProducts())
            {
                // return transaction type!
                if (cbTransactionType.Text == "return")
                {
                    item.Quantity *= -1;
                }

                // return transaction type!
                if (cbTransactionType.Text == "void")
                {
                    item.Quantity *= -1;
                }
                ProductsSoldList.Add(item);
            }

            transactionLineProducts.ProductsSold = ProductsSoldList;

            try
            {
                // Creating the transaction in the database
                if (transaction.SubTotal != 0)
                {
                    if (collectPayment(transaction))
                    {
                        _transactionManager.AddTransaction(transaction);
                        _transactionManager.AddTransactionLineProducts(transactionLineProducts);
                        _transactionManager.EditItemQuantity(transactionLineProducts);

                        txtSearchProduct.Text = "";
                        txtItemName.Text = "";
                        chkTaxable.IsChecked = false;
                        txtPrice.Text = "";
                        txtQuantity.Text = "";
                        txtItemDescription.Text = "";
                        

                        cbTransactionType.Text = "";
                        cbTransactionStatus.Text = "";

                        txtTaxExemptNumber.Text = "";
                        txtEmail.Clear();

                        txtTotal.Text = "";
                        txtSubTotal.Text = "";
                        txtSubTotalTaxable.Text = "";

                        dgShoppingCart.ItemsSource = null;
                        subTotalTaxable = 0.0M;
                        subTotal = 0.0M;
                        total = 0.0M;
                        _transactionManager.ClearShoppingCart();

                        btnAddProduct.Visibility = Visibility.Hidden;
                        


                        MessageBox.Show("Transaction Complete", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        WPFErrorHandler.ErrorMessage("Payment Processing incomplete.");
                    }
                }
                else 
                {
                    MessageBox.Show("Could Not Add Transaction!");
                }
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message + "\n\n" + "You Must Enter Transaction Admin Data!");
            }

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/25/2020
        /// Approver: Rasha Mohammed
        ///
        /// Auto generates the shopping cart columns. Removes 
        /// unnecessary inherited properties.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void dgShoppingCart_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgShoppingCart.Columns.RemoveAt(13);
            dgShoppingCart.Columns.RemoveAt(12);
            dgShoppingCart.Columns.RemoveAt(11);
            dgShoppingCart.Columns.RemoveAt(10);
            dgShoppingCart.Columns.RemoveAt(9);
            dgShoppingCart.Columns.RemoveAt(8);
            dgShoppingCart.Columns.RemoveAt(6);
            dgShoppingCart.Columns.RemoveAt(5);
            dgShoppingCart.Columns.RemoveAt(3);
            dgShoppingCart.Columns.RemoveAt(1);
            dgShoppingCart.Columns.RemoveAt(0);
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 03/25/2020
        /// Approver: Rasha Mohammed
        ///
        /// Clears the shopping cart, but also closes the transaction.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnClearShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            txtSearchProduct.Text = "";
            txtItemName.Text = "";
            chkTaxable.IsChecked = false;
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtItemDescription.Text = "";

            cbTransactionType.Text = "";
            cbTransactionStatus.Text = "";

            txtTaxExemptNumber.Text = "";
            txtEmail.Text = "";

            txtTotal.Text = "";
            txtSubTotal.Text = "";
            txtSubTotalTaxable.Text = "";

            subTotalTaxable = 0.0M;
            subTotal = 0.0M;
            total = 0.0M;

            dgShoppingCart.ItemsSource = null;
            btnAddProduct.Visibility = Visibility.Hidden;
            _transactionManager.ClearShoppingCart();
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/12/2020
        /// Approver: Robert Holmes
        /// 
        /// This method return a product that its UPC match the productID 
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
        private void ShowProduct()
        {
            string productUPC = txtSearchProduct.Text.ToString();

            productVM = _transactionManager.RetrieveProductByProductID(productUPC);



            txtItemName.Text = productVM.Name;
            chkTaxable.IsChecked = productVM.Taxable;
            txtPrice.Text = productVM.Price.ToString();
            txtQuantity.Text = "1";
            txtItemDescription.Text = productVM.ItemDescription;
        }

        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/12/2020
        /// Approver: Robert Holmes
        /// 
        /// This method Validate the Updated price and retrieve it after update
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
        private void btnEditPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtPrice.IsReadOnly = false;
                txtPrice.Focus();

                ProductVM newProduct = new ProductVM()
                {

                    Price = Convert.ToDecimal(txtPrice.Text),

                };

                if (_transactionManager.EditProduct(productVM, newProduct))
                {
                    ShowProduct();

                }
                else
                {
                    MessageBox.Show("The price did not change");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("You must enter a valid price. \n \n" + ex.Message);

            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Handles payment recieved from customer.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool collectPayment(Transaction transaction)
        {
            bool result = false;
            PaymentType paymentType = PaymentType.Cancel;
            var due = new AmountDue(transaction.Total);
            while (due.Amount != 0)
            {
                var frmPayment = new frmPayment(paymentType, due);
                frmPayment.ShowDialog();
                paymentType = frmPayment.PaymentType;
                if (paymentType == PaymentType.Card)
                {
                    var frmCardEntry = new frmCardEntry(due, transaction);
                    frmCardEntry.ShowDialog();
                    result = true;
                }
                else if (paymentType == PaymentType.Cash)
                {
                    var frmCashEntry = new frmCashEntry(due);
                    frmCashEntry.ShowDialog();
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// retrieves all transaction types
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTransactionType_Loaded(object sender, RoutedEventArgs e)
        {
            List<TransactionType> transactionTypes = _transactionManager.RetrieveAllTransactionTypes();


            foreach (var item in transactionTypes)
            {
                cbTransactionType.Items.Add(item.TransactionTypeID.ToString());
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// retrieves all transaction statuses
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTransactionStatus_Loaded(object sender, RoutedEventArgs e)
        {
            List<TransactionStatus> transactionStatuses = _transactionManager.RetrieveAllTransactionStatus();


            foreach (var item in transactionStatuses)
            {
                cbTransactionStatus.Items.Add(item.TransactionStatusID.ToString());
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/24
        /// Approver: Robert Holmes
        /// 
        /// validates only positive values.
        /// However, the item quantity validation accepts negative values only if 
        /// the transaction type is a "return" or "void".
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQuantity_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 5/5/2020
        /// Approver: 
        /// 
        /// Extracted method for clarity.
        /// </summary>
        private void clearFields()
        {
            txtItemName.Text = "";
            chkTaxable.IsChecked = false;
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtItemDescription.Text = "";
            btnAddProduct.Visibility = Visibility.Hidden;
        }
    }
}
