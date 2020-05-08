using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
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
    /// Created: 2020/04/30
    /// Approver: 
    /// Approver:  
    ///
    /// Page to update orderLines
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public partial class UpdateOrderLine : Page
    {
        private IOrderLineManager _orderLineManager;
        private OrderLine _orderLine;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/30
        /// Approver: 
        /// Approver:  
        ///
        /// no argument constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public UpdateOrderLine()
        {
            InitializeComponent();
            _orderLineManager = new OrderLineManager();
            _orderLine = new OrderLine();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/30
        /// Approver: 
        /// Approver:  
        ///
        /// Takes an orderLine to update
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public UpdateOrderLine(OrderLine orderLine)
        {
            InitializeComponent();
            _orderLineManager = new OrderLineManager();
            _orderLine = new OrderLine();
            _orderLine = orderLine;
            int result;

            if (int.TryParse(txtItemID.Text, out result))
            {
                _orderLine.ItemID = result;
            }
            else
            {
                "ItemID must be a number.".ErrorMessage();
            }

            if (int.TryParse(txtReceivingRecordID.Text, out result))
            {
                _orderLine.ReceivingRecordID = result;
            }
            else
            {
                "ReceivingRecordID must be a number.".ErrorMessage();
            }

            if (int.TryParse(txtDamagedItemQuantity.Text, out result))
            {
                _orderLine.DamagedItemQuantity = result;
            }
            else
            {
                "DamagedItemQuantity must be a number.".ErrorMessage();
            }

            if (int.TryParse(txtMissingItemQuantity.Text, out result))
            {
                _orderLine.MissingItemQuantity = result;
            }
            else
            {
                "MissingItemQuantity must be a number.".ErrorMessage();
            }

            txtOrderLineID.Text = _orderLine.ItemID.ToString();
            txtReceivingRecordID.Text = _orderLine.ReceivingRecordID.ToString();
            txtItemID.Text = _orderLine.ItemID.ToString();
            txtDamagedItemQuantity.Text = _orderLine.DamagedItemQuantity.ToString();
            txtMissingItemQuantity.Text = _orderLine.MissingItemQuantity.ToString();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/30
        /// Approver: 
        /// Approver:  
        ///
        /// takes user back to viewOrder page
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewOrderLine());
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: 
        /// Approver:  
        ///
        /// takes original order line and new orderline and sends them to update method
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int result;
            OrderLine newOrderLine = new OrderLine();

            if (int.TryParse(txtItemID.Text, out result))
            {
                newOrderLine.ItemID = result;
            }
            else
            {
                "ItemID must be a number.".ErrorMessage();
            }

            if (int.TryParse(txtReceivingRecordID.Text, out result))
            {
                newOrderLine.ReceivingRecordID = result;
            }
            else
            {
                "ReceivingRecordID must be a number.".ErrorMessage();
            }

            if (int.TryParse(txtDamagedItemQuantity.Text, out result))
            {
                newOrderLine.DamagedItemQuantity = result;
            }
            else
            {
                "DamagedItemQuantity must be a number.".ErrorMessage();
            }

            if (int.TryParse(txtMissingItemQuantity.Text, out result))
            {
                newOrderLine.MissingItemQuantity = result;
            }
            else
            {
                "MissingItemQuantity must be a number.".ErrorMessage();
            }

            _orderLineManager.UpdateOrderLine(_orderLine, newOrderLine);
            this.NavigationService?.Navigate(new ViewOrderLine());
        }
    }
}
