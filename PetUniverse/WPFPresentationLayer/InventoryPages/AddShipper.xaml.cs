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
    /// Approver: Brandyn T. Coverdill
    /// Approver:  
    ///
    /// Page to create shippers
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public partial class AddShipper : Page
    {
        private IShipperManager _shipperManager;
        private Shipper _shipper;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public AddShipper()
        {
            InitializeComponent();
            InitializeComponent();
            _shipperManager = new ShipperManager();
            _shipper = new Shipper();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// button to return to viewShipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewShipper());
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// button to create shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            _shipper.ShipperID = txtShipperID.Text;
            _shipper.Complaint = txtComplaint.Text;
            _shipperManager.createShipper(_shipper);
            this.NavigationService?.Navigate(new ViewShipper());
        }
    }
}
