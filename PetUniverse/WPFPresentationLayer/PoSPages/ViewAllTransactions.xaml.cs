using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
	/// Creator: Jaeho Kim
	/// Created: 2/27/2020
	/// Approver: Rasha Mohammed
    /// Interaction logic for ViewAllTransactions.xaml
	/// </summary>
    public partial class ViewAllTransactions : Page
    {
        ITransactionManager _transactionManager;

        TransactionVM _transactionVM;

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This is the default constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public ViewAllTransactions()
        {
            _transactionManager = new TransactionManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This method populates all of the products to the data grid.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void populateProductList()
        {
            _transactionVM = (TransactionVM)dgTransactionsList.SelectedItem;
            int transactionID = _transactionVM.TransactionID;
            dgProductList.ItemsSource = _transactionManager.RetrieveAllProductsByTransactionID(transactionID);

        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This method displays a single transaction details with double click.
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: No longer crashes with no selection.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgTransactionsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgTransactionsList.SelectedItem != null)
            {
                canViewTransactions.Visibility = Visibility.Hidden;
                xTransactionDetails.Visibility = Visibility.Visible;
                _transactionVM = (TransactionVM)dgTransactionsList.SelectedItem;
                txtTransactionID.Text = _transactionVM.TransactionID.ToString();
                txtTransactionDate.Text = _transactionVM.TransactionDateTime.ToString();
                txtEmployeeID.Text = _transactionVM.EmployeeID.ToString();
                txtFirstName.Text = _transactionVM.FirstName.ToString();
                txtLastName.Text = _transactionVM.LastName.ToString();
                txtTransactionTypeID.Text = _transactionVM.TransactionTypeID.ToString();
                txtTransactionStatusID.Text = _transactionVM.TransactionStatusID.ToString();
                txtTransactionTaxRate.Text = _transactionVM.TaxRate.ToString();
                txtTransactionSubTotalTaxable.Text = _transactionVM.SubTotalTaxable.ToString();
                txtTransactionSubTotal.Text = _transactionVM.SubTotal.ToString();
                txtTransactionTotal.Text = _transactionVM.Total.ToString();

                populateProductList();
            }
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This simply takes the end user back to the View all transactions tab.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            canViewTransactions.Visibility = Visibility.Visible;
            xTransactionDetails.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 3/7/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Removes item from transaction
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            TransactionVM transaction = (TransactionVM)dgProductList.SelectedItem;
            if (transaction != null)
            {
                _transactionManager.DeleteItem(transaction.ProductID);
            }

            if (true)
            {
                MessageBox.Show("Are You Sure? The item will be removed");
                TransactionVM _transaction = (TransactionVM)dgProductList.SelectedItem;
                populateProductList();

            }
        }




        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This event automatically adjusts the data grid whenever the window is loaded
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Hid a couple more fields.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTransactionsList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgTransactionsList.Columns.RemoveAt(20);
            dgTransactionsList.Columns.RemoveAt(19);
            dgTransactionsList.Columns.RemoveAt(14);
            dgTransactionsList.Columns.RemoveAt(13);
            dgTransactionsList.Columns.RemoveAt(12);
            dgTransactionsList.Columns.RemoveAt(11);
            dgTransactionsList.Columns.RemoveAt(10);
            dgTransactionsList.Columns.RemoveAt(9);
            dgTransactionsList.Columns.RemoveAt(8);
            dgTransactionsList.Columns.RemoveAt(7);
            dgTransactionsList.Columns.RemoveAt(6);
            dgTransactionsList.Columns.RemoveAt(5);
            dgTransactionsList.Columns.RemoveAt(4);
            dgTransactionsList.Columns.RemoveAt(3);
            dgTransactionsList.Columns.RemoveAt(2);           
        }


        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This event automatically adjusts the data grid whenever the window is loaded
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Hid some more fields
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProductList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgProductList.Columns.RemoveAt(20);
            dgProductList.Columns.RemoveAt(19);
            dgProductList.Columns.RemoveAt(18);
            dgProductList.Columns.RemoveAt(17);
            dgProductList.Columns.RemoveAt(16);
            dgProductList.Columns.RemoveAt(15);
            dgProductList.Columns.RemoveAt(14);
            dgProductList.Columns.RemoveAt(13);
            dgProductList.Columns.RemoveAt(12);
            dgProductList.Columns.RemoveAt(11);
            dgProductList.Columns.RemoveAt(10);
            dgProductList.Columns.RemoveAt(9);
            dgProductList.Columns.RemoveAt(8);
            dgProductList.Columns.RemoveAt(1);
            dgProductList.Columns.RemoveAt(0);
        }


        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/08/2020
        /// Approver: Rasha Mohammed
        /// 
        /// Search Button for transaction by employee name
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactionSearchByEmployeeName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = txtEmployeeFirstName.Text.ToString();

                string lastName = txtEmployeeLastName.Text.ToString();

                if (firstName.Equals("") || firstName == null)
                {
                    WPFErrorHandler.ErrorMessage("Enter a first name.");
                    txtEmployeeFirstName.Focus();
                }
                else if (lastName.Equals("") || lastName == null)
                {
                    WPFErrorHandler.ErrorMessage("Enter a last name.");
                }
                else
                {
                    // Retrieve transactions
                    dgTransactionsList.ItemsSource = _transactionManager.RetrieveTransactionByEmployeeName(firstName, lastName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }


        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/07/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This button searches through transaction with a given transaction date.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactionSearchByDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /**
                 * This logic defaults the transaction search to past 30 days of the current date.
                 */
                if (dtpTransaction.Value == null || dtpTransaction2.Value == null)
                {


                    dtpTransaction2.Value = DateTime.Now;

                    dtpTransaction.Value = DateTime.Now.AddDays(-30);


                }



                // Convert the date time picker object to string
                string td = dtpTransaction.Value.ToString();
                // Parse the string into DateTime
                DateTime transactionDate = DateTime.Parse(td);

                // Convert the second date time picker object to string
                string td2 = dtpTransaction2.Value.ToString();
                DateTime secondTransactionDate = DateTime.Parse(td2);



                // Retrieve transactions
                dgTransactionsList.ItemsSource = _transactionManager.
                    RetrieveTransactionByTransactionDate(transactionDate, secondTransactionDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 2020/04/13
        /// Approver: NA
        /// 
        /// This button searches through transaction with a given transaction id (receipt number).
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactionSearchByTransactionID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tID = txtTransactionIDSearch.Text.ToString();
                int transactionID = int.Parse(tID);

                // Retrieve transactions
                dgTransactionsList.ItemsSource = _transactionManager.RetrieveTransactionByTransactionID(transactionID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
