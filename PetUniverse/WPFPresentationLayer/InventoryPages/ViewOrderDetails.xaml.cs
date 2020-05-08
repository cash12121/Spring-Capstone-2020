using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/24
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Page to view details of an order
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public partial class ViewOrderDetails : Page
    {
        private IOrderManager _orderManager;
        private IReceivingRecordManager _receivingRecordManager;
        private IOrderLineManager _orderLineManager;

        private Order _order;
        private ReceivingRecord _receivingRecord;
        private OrderLine _orderLine;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Initilizes the page and data
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ViewOrderDetails(Order order)
        {
            InitializeComponent();
            _orderManager = new OrderManager();
            _receivingRecordManager = new ReceivingRecordManager();
            _orderLineManager = new OrderLineManager();
            _order = order;
            PopulateTextBoxes(order);
            PopulateDataGrid(order);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Methods to show data in textboxes
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void PopulateTextBoxes(Order order)
        {
            txtOrderID.Text = order.OrderID.ToString();
            txtEmployeeID.Text = order.UserID.ToString();
            txtActive.Text = order.Active.ToString();
            txtOrderStatus.Text = order.OrderStatus.ToString();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Method to show data in datagrid
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void PopulateDataGrid(Order order)
        {
            _receivingRecord = _receivingRecordManager.RetrieveReceivingRecordByOrderID(_order.OrderID);
            dgOrderLine.ItemsSource = _orderLineManager.RetrieveOrderLineByReceivingRecordID(_receivingRecord.ReceivingRecordID);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Back button
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewOrders());
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Button to check in a delivery
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnCheckIn_Click(object sender, RoutedEventArgs e)
        {
            string orderStatus = "Checked In";

            // Update order status to received
            if (_orderManager.EditOrderStatus(_order, orderStatus))
            {
                _order.OrderStatus = orderStatus;
            }

            // Refresh text box data
            PopulateTextBoxes(_order);
        }
    }
}
