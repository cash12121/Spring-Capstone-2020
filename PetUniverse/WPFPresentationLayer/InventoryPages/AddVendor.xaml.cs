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
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;
using PresentationUtilityCode;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Code Behind file for add Vendor Page.
    /// </summary>
    public partial class AddVendor : Page
    {

        private IVendorManager _vendorManager;

        public AddVendor()
        {
            _vendorManager = new VendorManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Saves a vendor into the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnSaveVendor_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;

            if (txtVendorName.Text != "" && txtVendorAddress.Text != "" && txtVendorPhone.Text != "" &&
                txtVendorEmail.Text != "" && txtVendorState.Text != "" && txtVendorCity.Text != "" &&
                txtVendorZip.Text != "" && txtVendorName.Text.Length <= 50 &&
                txtVendorAddress.Text.Length <= 100 && txtVendorPhone.Text.Length <= 11 &&
                txtVendorEmail.Text.Length <= 250 && txtVendorState.Text.Length <= 2 &&
                txtVendorCity.Text.Length <= 50 && txtVendorZip.Text.Length <= 20)
            {
                // Seeing if the Quanitity of items from Report can be a number.
                try
                {
                    Vendor vendor = new Vendor();
                    vendor.VendorName = txtVendorName.Text;
                    vendor.VendorAddress = txtVendorAddress.Text;
                    vendor.VendorPhone = txtVendorPhone.Text;
                    vendor.VendorEmail = txtVendorEmail.Text;
                    vendor.VendorState = txtVendorState.Text;
                    vendor.VendorCity = txtVendorCity.Text;
                    vendor.VendorZip = txtVendorZip.Text;

                    // Send Data to Manager layer.
                    _vendorManager.createNewVendor(vendor);

                    result = true;
                    this.NavigationService?.Navigate(new ViewVendors());
                }
                catch (FormatException)
                {
                    "Please enter correct data.".ErrorMessage();
                }
            }
            if (txtVendorName.Text.Length > 50)
            {
                "Name is too long.".ErrorMessage();
            }
            if (txtVendorName.Text == "")
            {
                "Please Enter a Name.".ErrorMessage();
            }
            if (txtVendorAddress.Text.Length > 100)
            {
                "Address is too long.".ErrorMessage();
            }
            if (txtVendorAddress.Text == "")
            {
                "Please Enter an address.".ErrorMessage();
            }
            if (txtVendorPhone.Text.Length > 11)
            {
                "Phone is too long.".ErrorMessage();
            }
            if (txtVendorPhone.Text == "")
            {
                "Please Enter a Phone Number.".ErrorMessage();
            }
            if (txtVendorEmail.Text.Length > 250)
            {
                "Email is too long.".ErrorMessage();
            }
            if (txtVendorEmail.Text == "")
            {
                "Please Enter a Email.".ErrorMessage();
            }
            if (txtVendorState.Text.Length > 2)
            {
                "State must be an abbreviation.".ErrorMessage();
            }
            if (txtVendorState.Text == "")
            {
                "Please Enter a State abbreviation.".ErrorMessage();
            }
            if (txtVendorCity.Text.Length > 50)
            {
                "City is too long.".ErrorMessage();
            }
            if (txtVendorCity.Text == "")
            {
                "Please Enter a City.".ErrorMessage();
            }
            if (txtVendorZip.Text.Length > 20)
            {
                "Zip is too long.".ErrorMessage();
            }
            if (txtVendorZip.Text == "")
            {
                "Please Enter a Zip.".ErrorMessage();
            }
            if (result)
            {
                "Vendor was Successfully updated!".SuccessMessage();
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Goes back to Vendor List.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewVendors());
        }
    }
}
