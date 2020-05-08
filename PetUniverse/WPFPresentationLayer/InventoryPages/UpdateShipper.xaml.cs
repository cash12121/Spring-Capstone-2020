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
    /// Page to update shippers
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public partial class UpdateShipper : Page
    {
        private IShipperManager _shipperManager;
        private Shipper _shipper;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// Constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public UpdateShipper()
        {
            InitializeComponent();
        }

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
        public UpdateShipper(Shipper shipper)
        {
            InitializeComponent();
            _shipperManager = new ShipperManager();
            _shipper = shipper;
            txtShipperID.Text = shipper.ShipperID.ToString();
            txtComplaint.Text = shipper.Complaint.ToString();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// button to return to ViewShipper
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
        /// button to update shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Shipper newShipper = new Shipper();
            newShipper.ShipperID = txtShipperID.Text;
            newShipper.Complaint = txtComplaint.Text;
            _shipperManager.updateShipper(_shipper, newShipper);
            this.NavigationService?.Navigate(new ViewShipper());
        }
    }
}
