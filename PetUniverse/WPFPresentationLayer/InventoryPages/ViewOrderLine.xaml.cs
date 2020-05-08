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
    /// Created: 2020/04/29
    /// Approver: 
    /// Approver:  
    ///
    /// page to view all orderLines
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public partial class ViewOrderLine : Page
    {
        private IOrderLineManager _orderLineManager;
        private OrderLine _orderLine;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// Default constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ViewOrderLine()
        {
            InitializeComponent();
            _orderLineManager = new OrderLineManager();
            _orderLine = new OrderLine();
            PopulateDataGrid();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// Mehtod to add data to datagrid
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void PopulateDataGrid()
        {
            dgOrderLine.ItemsSource = _orderLineManager.selectAllOrderLines();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// button to delete selected orderLine
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _orderLine = (OrderLine)dgOrderLine.SelectedItem;
            _orderLineManager.deleteOrderLine(_orderLine);
            PopulateDataGrid();

        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// Takes selected orderLine and moves the user to the update orderLine page
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _orderLine = (OrderLine)dgOrderLine.SelectedItem;
            this.NavigationService?.Navigate(new UpdateOrderLine(_orderLine));
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// takes user to the create orderLine page
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new AddOrderLine());
        }
    }
}
