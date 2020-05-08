using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 02/21/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Interaction logic for InventoryItems.xaml
    /// </summary>
    public partial class pgInventoryItems : Page
    {
        private IInventoryItemsManager _inventoryItemsManager;
        private IProductManager _productManager;
        private Frame _frame;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 02/21/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Default Constructor for InventoryItems Page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public pgInventoryItems()
        {
            _inventoryItemsManager = new InventoryItemsManager();
            _productManager = new ProductManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: 
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
        public pgInventoryItems(Frame frame)
        {
            _inventoryItemsManager = new InventoryItemsManager();
            _productManager = new ProductManager();
            _frame = frame;
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 02/21/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Event Handler Method that activates on page load
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 02/21/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Data Refresh Method to be called on every time it is needed.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void RefreshData()
        {
            dgInventoryItems.ItemsSource = _inventoryItemsManager.RetrieveInventoryItems();
            dgInventoryItems.Columns[0].Header = "UPC";
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new pgChooseItemForProduct(_frame));
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: 
        /// 
        /// Allows the user to view the details about an item.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void dgInventoryItems_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgInventoryItems.SelectedItem != null)
            {
                _frame.Navigate(new pgAddEditViewProduct(_frame, (InventoryItems)dgInventoryItems.SelectedItem));
            }
        }

        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Method used for Deactivate Button on Click
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: No longer crashes if nothing is selected.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeactivateProduct_Click(object sender, RoutedEventArgs e)
        {
            InventoryItems _inventoryItem = (InventoryItems)dgInventoryItems.SelectedItem;
            if (_inventoryItem != null)
            {
                if (_inventoryItem.Active)
                {
                    _productManager.DeactivateProduct(_inventoryItem.ProductID);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("This product is already deactivated!");
                }
            }
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/04/29
        /// Approver: Rasha Mohammed
        /// 
        /// Method used for Activate Button on Click
        /// </summary>
        /// <remarks>
        /// Updater: Robert Holmes
        /// Updated: 5/5/2020
        /// Update: No longer crashes if nothing is selected.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActivateProduct_Click(object sender, RoutedEventArgs e)
        {
            InventoryItems _inventoryItem = (InventoryItems)dgInventoryItems.SelectedItem;
            if (_inventoryItem != null)
            {
                if (!_inventoryItem.Active)
                {
                    _productManager.ActivateProduct(_inventoryItem.ProductID);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("This product is already active!");
                }
            }
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgInventoryItems.SelectedItem != null)
            {
                _frame.Navigate(new pgAddEditViewProduct(_frame, (InventoryItems)dgInventoryItems.SelectedItem, editMode: true));
            }
        }
    }
}
