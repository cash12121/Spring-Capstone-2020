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
    /// Class to view shippers
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    public partial class ViewShipper : Page
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
        public ViewShipper()
        {
            InitializeComponent();
            _shipperManager = new ShipperManager();
            _shipper = new Shipper();
            PopulateDatagrid();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// Method to populate datagrid
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void PopulateDatagrid()
        {
            dgShipper.ItemsSource = _shipperManager.selectAllShippers();
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver:  
        ///
        /// button to delete shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _shipper = (Shipper)dgShipper.SelectedItem;
            _shipperManager.deleteShipper(_shipper);
            PopulateDatagrid();
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
            _shipper = (Shipper)dgShipper.SelectedItem;
            this.NavigationService?.Navigate(new UpdateShipper(_shipper));
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
            this.NavigationService?.Navigate(new AddShipper());
        }
    }
}
