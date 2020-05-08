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
using PresentationUtilityCode;
using LogicLayer;
using LogicLayerInterfaces;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Code Behind file for edit Vendor Page.
    /// </summary>
    public partial class EditVendor : Page
    {

        private IVendorManager _vendorManager;
        private Vendor _vendor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Constructor for EditVendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public EditVendor(Vendor vendor)
        {
            _vendor = vendor;
            _vendorManager = new VendorManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Goes back to view All Vendors.
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

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Saves the new Vendor Information.
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

                    int id = Int32.Parse(txtVendorID.Text);

                    // Get Old Data.
                    string oldName = _vendor.VendorName;
                    string oldAddress = _vendor.VendorAddress;
                    string oldPhone = _vendor.VendorPhone;
                    string oldEmail = _vendor.VendorEmail;
                    string oldState = _vendor.VendorState;
                    string oldCity = _vendor.VendorCity;
                    string oldZip = _vendor.VendorZip;

                    // Get New Data.
                    string newName = txtVendorName.Text.ToString();
                    string newAddress = txtVendorAddress.Text.ToString();
                    string newPhone = txtVendorPhone.Text.ToString();
                    string newEmail = txtVendorEmail.Text.ToString();
                    string newState = txtVendorState.Text.ToString();
                    string newCity = txtVendorCity.Text.ToString();
                    string newZip = txtVendorZip.Text.ToString();

                    // Send Data to Manager layer.
                    _vendorManager.editVendor(id, oldName, oldAddress, oldPhone, oldEmail, oldState,
                        oldCity, oldZip, newName, newAddress, newPhone, newEmail, newState, newCity, newZip);
                    result = true;

                    btnSaveVendor.Visibility = Visibility.Hidden;
                    btnEditVendor.Visibility = Visibility.Visible;
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
        /// Makes the Vendor Information editable.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void btnEditVendor_Click(object sender, RoutedEventArgs e)
        {
            txtVendorName.IsReadOnly = false;
            txtVendorAddress.IsReadOnly = false;
            txtVendorCity.IsReadOnly = false;
            txtVendorEmail.IsReadOnly = false;
            txtVendorZip.IsReadOnly = false;
            txtVendorPhone.IsReadOnly = false;
            txtVendorState.IsReadOnly = false;
            txtVendorName.Focus();
            btnEditVendor.Visibility = Visibility.Hidden;
            btnSaveVendor.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Adds Vendor information to the text fields.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtVendorID.Text = _vendor.VendorID.ToString();
            txtVendorName.Text = _vendor.VendorName.ToString();
            txtVendorAddress.Text = _vendor.VendorAddress.ToString();
            txtVendorCity.Text = _vendor.VendorCity.ToString();
            txtVendorEmail.Text = _vendor.VendorEmail.ToString();
            txtVendorPhone.Text = _vendor.VendorPhone.ToString();
            txtVendorZip.Text = _vendor.VendorZip.ToString();
            txtVendorState.Text = _vendor.VendorState.ToString();
        }
    }
}
