using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020-04-14
    /// Approver: Ethan Holmes
    ///
    /// Interaction logic for pgTransactionAdmin.xaml
    /// </summary>
    public partial class pgTransactionAdmin : Page
    {

        private ITransactionAdminManager _transactionAdminManager = null;

        private ITransactionManager _transactionManager;

        private bool _addMode = true;

        private TransactionType oldTransactionType = new TransactionType();

        private TransactionStatus oldTransactionStatus = new TransactionStatus();

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020-04-14
        /// Approver: Ethan Holmes
        /// 
        /// Default Constructor.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public pgTransactionAdmin()
        {
            InitializeComponent();

            _transactionAdminManager = new TransactionAdminManager();

            _transactionManager = new TransactionManager();


        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Add transaction type Entry. Displays the transaction type details entry page.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTransactionType_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Hidden;
            canTransactionTypeDetails.Visibility = Visibility.Visible;




            txtTransactionTypeID.IsReadOnly = false;
            txtTransactionTypeID.Text = "";
            txtTransactionTypeDescription.IsReadOnly = false;
            txtTransactionTypeDescription.Text = "";
            chkTransactionTypeDefaultInStore.IsEnabled = true;
            chkTransactionTypeDefaultInStore.IsChecked = false;

            btnSaveTransactionType.Visibility = Visibility.Visible;
            btnEditTransactionType.Visibility = Visibility.Hidden;
            btnDeleteTransactionType.Visibility = Visibility.Hidden;

            _addMode = true;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Cancel transaction type entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelTransactionType_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Visible;
            canTransactionTypeDetails.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Clears the details page and returns to the original tab.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Reloads data so datagrid updates.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTransactionType()
        {
            canTransactionAdmin.Visibility = Visibility.Visible;

            canTransactionTypeDetails.Visibility = Visibility.Hidden;

            txtTransactionTypeID.Clear();
            txtTransactionTypeDescription.Clear();
            chkTransactionTypeDefaultInStore.IsChecked = false;
            loadData();
        }





        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Save transaction type entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveTransactionType_Click(object sender, RoutedEventArgs e)
        {
            if (txtTransactionTypeID.Text == "")
            {
                txtTransactionTypeID.Text = null;
                MessageBox.Show("Please enter TransactionType ID");
                return;
            }

            if (txtTransactionTypeDescription.Text == "")
            {
                txtTransactionTypeDescription.Text = null;
                MessageBox.Show("Please enter the Transaction Type Description");
                return;
            }

            TransactionType transactionType = new TransactionType();
            try
            {

                transactionType.TransactionTypeID = txtTransactionTypeID.Text;
                transactionType.Description = txtTransactionTypeDescription.Text;
                transactionType.DefaultInStore = (bool)chkTransactionTypeDefaultInStore.IsChecked;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (_addMode)
            {
                _transactionAdminManager.AddTransactionType(transactionType);
                MessageBox.Show("Transaction Type Added");
                clearTransactionType();
            }
            else
            {
                try
                {
                    if (_transactionAdminManager.EditTransactionType(oldTransactionType, transactionType))
                    {
                        MessageBox.Show("Success");
                        clearTransactionType();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Save transaction status entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            if (txtTransactionStatusID.Text == "")
            {
                txtTransactionStatusID.Text = null;
                MessageBox.Show("Please enter TransactionStatus ID");
                return;
            }

            if (txtTransactionStatusDescription.Text == "")
            {
                txtTransactionStatusDescription.Text = null;
                MessageBox.Show("Please enter the Transaction Status Description");
                return;
            }

            TransactionStatus transactionStatus = new TransactionStatus();
            try
            {

                transactionStatus.TransactionStatusID = txtTransactionStatusID.Text;
                transactionStatus.Description = txtTransactionStatusDescription.Text;
                transactionStatus.DefaultInStore = (bool)chkTransactionStatusDefaultInStore.IsChecked;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (_addMode)
            {
                _transactionAdminManager.AddTransactionStatus(transactionStatus);
                MessageBox.Show("Transaction Status Added");
                clearTransactionStatus();
            }
            else
            {
                try
                {
                    if (_transactionAdminManager.EditTransactionStatus(oldTransactionStatus, transactionStatus))
                    {
                        MessageBox.Show("Success");
                        clearTransactionStatus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Cancel transaction status entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Visible;
            canTransactionStatusDetails.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Add transaction status Entry. Displays the transaction status details entry page.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Hidden;
            canTransactionStatusDetails.Visibility = Visibility.Visible;

            txtTransactionStatusID.IsReadOnly = false;
            txtTransactionStatusID.Text = "";
            txtTransactionStatusDescription.IsReadOnly = false;
            txtTransactionStatusDescription.Text = "";
            chkTransactionStatusDefaultInStore.IsEnabled = true;
            chkTransactionStatusDefaultInStore.IsChecked = false;

            btnSaveTransactionStatus.Visibility = Visibility.Visible;
            btnEditTransactionStatus.Visibility = Visibility.Hidden;
            btnDeleteTransactionStatus.Visibility = Visibility.Hidden;

            _addMode = true;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Clears the details page and returns to the original tab.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Reloads data so datagrid updates.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTransactionStatus()
        {
            canTransactionAdmin.Visibility = Visibility.Visible;

            canTransactionStatusDetails.Visibility = Visibility.Hidden;

            txtTransactionStatusID.Clear();
            txtTransactionStatusDescription.Clear();
            chkTransactionStatusDefaultInStore.IsChecked = false;
            loadData();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/28
        /// Approver: Rasha Mohammed
        /// 
        /// Displays all of the transaction types.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: No longer crashes with no selection.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTransactionType_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TransactionType _transactionType = (TransactionType)dgTransactionType.SelectedItem;
            if (_transactionType != null)
            {
                canTransactionAdmin.Visibility = Visibility.Hidden;
                canTransactionTypeDetails.Visibility = Visibility.Visible;

                txtTransactionTypeID.Text = _transactionType.TransactionTypeID.ToString();
                txtTransactionTypeDescription.Text = _transactionType.Description.ToString();
                chkTransactionTypeDefaultInStore.IsChecked = _transactionType.DefaultInStore;

                txtTransactionTypeID.IsReadOnly = true;
                txtTransactionTypeDescription.IsReadOnly = true;
                chkTransactionTypeDefaultInStore.IsEnabled = false;
                btnSaveTransactionType.Visibility = Visibility.Hidden;
                btnEditTransactionType.Visibility = Visibility.Visible;
                btnDeleteTransactionType.Visibility = Visibility.Hidden;

                oldTransactionType.TransactionTypeID = txtTransactionTypeID.Text.ToString();
                oldTransactionType.Description = txtTransactionTypeDescription.Text.ToString();
                oldTransactionType.DefaultInStore = (bool)chkTransactionTypeDefaultInStore.IsChecked;
            }
        }


        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/28
        /// Approver: Rasha Mohammed
        /// 
        /// canvas for trans admin.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: Extracted method for clarity
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canTransactionAdmin_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/28
        /// Approver: Rasha Mohammed
        /// 
        /// Edit for trans type.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditTransactionType_Click(object sender, RoutedEventArgs e)
        {
            btnDeleteTransactionType.Visibility = Visibility.Visible;
            btnSaveTransactionType.Visibility = Visibility.Visible;
            btnEditTransactionType.Visibility = Visibility.Hidden;

            txtTransactionTypeID.IsReadOnly = false;
            txtTransactionTypeDescription.IsReadOnly = false;
            chkTransactionTypeDefaultInStore.IsEnabled = true;

            _addMode = false;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Delete functionality for trans type.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTransactionType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _transactionAdminManager.DeleteTransactionType(txtTransactionTypeID.Text.ToString());
                clearTransactionType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Edit the status.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            btnDeleteTransactionStatus.Visibility = Visibility.Visible;
            btnSaveTransactionStatus.Visibility = Visibility.Visible;
            btnEditTransactionStatus.Visibility = Visibility.Hidden;

            txtTransactionStatusID.IsReadOnly = false;
            txtTransactionStatusDescription.IsReadOnly = false;
            chkTransactionStatusDefaultInStore.IsEnabled = true;

            _addMode = false;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// delete status
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _transactionAdminManager.DeleteTransactionStatus(txtTransactionStatusID.Text.ToString());
                clearTransactionStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// single status details.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: No longer crashes with no selection.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTransactionStatus_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TransactionStatus _transactionStatus = (TransactionStatus)dgTransactionStatus.SelectedItem;
            if (_transactionStatus != null)
            {
                canTransactionAdmin.Visibility = Visibility.Hidden;
                canTransactionStatusDetails.Visibility = Visibility.Visible;

                txtTransactionStatusID.Text = _transactionStatus.TransactionStatusID.ToString();
                txtTransactionStatusDescription.Text = _transactionStatus.Description.ToString();
                chkTransactionStatusDefaultInStore.IsChecked = _transactionStatus.DefaultInStore;

                txtTransactionStatusID.IsReadOnly = true;
                txtTransactionStatusDescription.IsReadOnly = true;
                chkTransactionStatusDefaultInStore.IsEnabled = false;
                btnSaveTransactionStatus.Visibility = Visibility.Hidden;
                btnEditTransactionStatus.Visibility = Visibility.Visible;
                btnDeleteTransactionStatus.Visibility = Visibility.Hidden;

                oldTransactionStatus.TransactionStatusID = txtTransactionStatusID.Text.ToString();
                oldTransactionStatus.Description = txtTransactionStatusDescription.Text.ToString();
                oldTransactionStatus.DefaultInStore = (bool)chkTransactionStatusDefaultInStore.IsChecked;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Creatd: 5/5/2020
        /// Approver: 
        /// 
        /// Loads data to data grids. (Extracted for clarity)
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        private void loadData()
        {
            dgTransactionType.ItemsSource = _transactionManager.RetrieveAllTransactionTypes();
            dgTransactionStatus.ItemsSource = _transactionManager.RetrieveAllTransactionStatus();
        }
    }
}
