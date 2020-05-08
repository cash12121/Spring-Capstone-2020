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
    /// Created: 2020/04/29
    /// Approver: Brandyn T. Coverdill
    /// Approver:  
    ///
    /// Page to create order lines
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public partial class AddOrderLine : Page
    {
        private IOrderLineManager _orderLineManager;
        private OrderLine _orderLine;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// Constuctor
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public AddOrderLine()
        {
            InitializeComponent();
            _orderLineManager = new OrderLineManager();
            _orderLine = new OrderLine();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// takes user back to view order page
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
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// takes strings from textboxed, converts them to ints, then sends them to logic layer
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
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

            _orderLineManager.createOrderLine(_orderLine);
            this.NavigationService?.Navigate(new ViewOrderLine());
        }
    }
}
