using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.FMPages
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/2/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// 
    /// Interaction logic for FacilityInspectionItemControls.xaml
    /// </summary>
    public partial class FacilityInspectionItemControls : Page
    {
        private IFacilityInspectionItemManager _facilityInspectionItemManager;
        private IFacilityInspectionManager _facilityInspectionManager;

        string[] searchItems =
        {
            "Facility Inspection Item ID",
            "User ID",
            "Item Name",
            "Facility Inspection ID"
        };

        FacilityInspectionItem selectedFacilityInspectionItem;

        private PetUniverseUser _user;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// constructor for facility inspection item controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionItemControls()
        {
            InitializeComponent();
            _facilityInspectionItemManager = new FacilityInspectionItemManager();
            _facilityInspectionManager = new FacilityInspectionManager();
            selectedFacilityInspectionItem = new FacilityInspectionItem();
            cmbFacilityInspectionItemFields.ItemsSource = searchItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// constructor for facility inspection item controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionItemControls(PetUniverseUser user)
        {
            InitializeComponent();
            _facilityInspectionItemManager = new FacilityInspectionItemManager();
            _facilityInspectionManager = new FacilityInspectionManager();
            selectedFacilityInspectionItem = new FacilityInspectionItem();
            _user = user;
            cmbFacilityInspectionItemFields.ItemsSource = searchItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// displays the add facility inspection item canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFacilityInspectionItem_Click(object sender, RoutedEventArgs e)
        {
            canAddFacilityInspectionItem.Visibility = Visibility.Visible;
            txtUserID.Text = _user.PUUserID.ToString();
            List<FacilityInspection> facilityInspections = new List<FacilityInspection>();
            try
            {
                facilityInspections = _facilityInspectionManager.RetrieveAllFacilityInspection(false);
                List<string> inspectionIDs = new List<string>();
                foreach (var item in facilityInspections)
                {
                    inspectionIDs.Add(item.FacilityInspectionID.ToString());
                }

                cmbFacilityInspectionID.ItemsSource = inspectionIDs;
                canView.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// creates a new record the user has entered if validated
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitInspectionItemRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                MessageBox.Show("Please enter the item name");
                return;
            }
            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (cmbFacilityInspectionID.SelectedItem == null)
            {
                MessageBox.Show("Please select a facility inspection id");
                return;
            }
            if (string.IsNullOrEmpty(txtItemDescription.Text))
            {
                MessageBox.Show("Please enter the inspection item description");
                return;
            }

            try
            {
                FacilityInspectionItem facilityInspectionItem = new FacilityInspectionItem
                {
                    ItemName = txtItemName.Text,
                    UserID = Int32.Parse(txtUserID.Text),
                    FacilityInpectionID = Int32.Parse(cmbFacilityInspectionID.SelectedItem.ToString()),
                    ItemDescription = txtItemDescription.Text

                };
                if (_facilityInspectionItemManager.AddFacilityInspectionItemRecord(facilityInspectionItem))
                {
                    MessageBox.Show("Inspection record successfully added.");
                    canAddFacilityInspectionItem.Visibility = Visibility.Hidden;
                    canView.Visibility = Visibility.Visible;
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtItemName.Text = "";
                    txtItemDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Inspection Item record was not added.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// method to load facility inspection item data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgFacilityInspectionItem_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgFacilityInspectionItem.ItemsSource == null)
                {
                    dgFacilityInspectionItem.ItemsSource = _facilityInspectionItemManager.RetrieveAllFacilityInspectionItems();
                    dgFacilityInspectionItem.Columns[0].Header = "Facility Inspection Item ID";
                    dgFacilityInspectionItem.Columns[1].Header = "Facility Inspection Item Name";
                    dgFacilityInspectionItem.Columns[2].Header = "User ID";
                    dgFacilityInspectionItem.Columns[3].Header = "Facility Inspection Item Description";
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// method to refresh the data grid items
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshViewAllList()
        {
            try
            {
                dgFacilityInspectionItem.ItemsSource = _facilityInspectionItemManager.RetrieveAllFacilityInspectionItems();
                dgFacilityInspectionItem.Columns[0].Header = "Facility Inspection Item ID";
                dgFacilityInspectionItem.Columns[1].Header = "Facility Inspection Item Name";
                dgFacilityInspectionItem.Columns[2].Header = "User ID";
                dgFacilityInspectionItem.Columns[3].Header = "Facility Inspection Item Description";
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// cancels updated a record and brings user back to display screen
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelInspectionItemRecord_Click(object sender, RoutedEventArgs e)
        {
            txtItemName.Text = "";
            txtUserID.Text = "";
            txtItemDescription.Text = "";
            lblFacilityInspectionItem.Content = "Enter Facility Inspection Item Record";
            if (btnUpdateInspectionItemRecord.Visibility == Visibility.Visible)
            {
                btnUpdateInspectionItemRecord.Visibility = Visibility.Hidden;
                BtnSubmitInspectionItemRecord.Visibility = Visibility.Visible;
            }
            canAddFacilityInspectionItem.Visibility = Visibility.Hidden;
            canView.Visibility = Visibility.Visible;
            btnAddFacilityInspectionItem.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Refeshes the view all list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshViewAllList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// searches the item inputed by the user and displays it on the screen
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFacilityInspectionItemFields.Text == searchItems[0])
            {
                try
                {
                    int itemID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityInspectionItem.ItemsSource = _facilityInspectionItemManager.RetrieveFacilityInspectionItemByID(itemID);
                    dgFacilityInspectionItem.Columns[0].Header = "Facility Inspection Item ID";
                    dgFacilityInspectionItem.Columns[1].Header = "Facility Inspection Item Name";
                    dgFacilityInspectionItem.Columns[2].Header = "User ID";
                    dgFacilityInspectionItem.Columns[3].Header = "Facility Inspection Item Description";

                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityInspectionItemFields.Text == searchItems[1])
            {
                try
                {
                    int userID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityInspectionItem.ItemsSource = _facilityInspectionItemManager.RetrieveFacilityInspectionItemByUserID(userID);
                    dgFacilityInspectionItem.Columns[0].Header = "Facility Inspection Item ID";
                    dgFacilityInspectionItem.Columns[1].Header = "Facility Inspection Item Name";
                    dgFacilityInspectionItem.Columns[2].Header = "User ID";
                    dgFacilityInspectionItem.Columns[3].Header = "Facility Inspection Item Description";

                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityInspectionItemFields.Text == searchItems[2])
            {
                try
                {
                    dgFacilityInspectionItem.ItemsSource = _facilityInspectionItemManager.RetrieveFacilityInspectionByItemName(txtSearchItem.Text);
                    dgFacilityInspectionItem.Columns[0].Header = "Facility Inspection Item ID";
                    dgFacilityInspectionItem.Columns[1].Header = "Facility Inspection Item Name";
                    dgFacilityInspectionItem.Columns[2].Header = "User ID";
                    dgFacilityInspectionItem.Columns[3].Header = "Facility Inspection Item Description";

                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityInspectionItemFields.Text == searchItems[3])
            {
                try
                {
                    dgFacilityInspectionItem.ItemsSource = _facilityInspectionItemManager.RetrieveFacilityInspectionItemByfacilityInspectionID(Int32.Parse(txtSearchItem.Text));
                    dgFacilityInspectionItem.Columns[0].Header = "Facility Inspection Item ID";
                    dgFacilityInspectionItem.Columns[1].Header = "Facility Inspection Item Name";
                    dgFacilityInspectionItem.Columns[2].Header = "User ID";
                    dgFacilityInspectionItem.Columns[3].Header = "Facility Inspection Item Description";

                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Submits the updated information to the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateInspectionItemRecord_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                MessageBox.Show("Please enter the item name");
                return;
            }
            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (cmbFacilityInspectionID.SelectedItem == null)
            {
                MessageBox.Show("Please select a facility inspection id");
                return;
            }
            if (string.IsNullOrEmpty(txtItemDescription.Text))
            {
                MessageBox.Show("Please enter the inspection item description");
                return;
            }

            try
            {
                FacilityInspectionItem facilityInspectionItem = new FacilityInspectionItem
                {
                    ItemName = txtItemName.Text,
                    UserID = Int32.Parse(txtUserID.Text),
                    FacilityInpectionID = Int32.Parse(cmbFacilityInspectionID.SelectedItem.ToString()),
                    ItemDescription = txtItemDescription.Text

                };
                if (_facilityInspectionItemManager.EditFacilityInspectionItem(selectedFacilityInspectionItem, facilityInspectionItem))
                {
                    MessageBox.Show("Inspection record successfully updated.");
                    canAddFacilityInspectionItem.Visibility = Visibility.Hidden;
                    canView.Visibility = Visibility.Visible;
                    btnUpdateInspectionItemRecord.Visibility = Visibility.Hidden;
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtItemName.Text = "";
                    txtItemDescription.Text = "";
                    canView.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Inspection Item record was not updated.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// brings up update window
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgFacilityInspectionItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtUserID.Text = _user.PUUserID.ToString();
            selectedFacilityInspectionItem = (FacilityInspectionItem)dgFacilityInspectionItem.SelectedItem;
            List<FacilityInspection> facilityInspections = new List<FacilityInspection>();
            try
            {
                facilityInspections = _facilityInspectionManager.RetrieveAllFacilityInspection(false);
                List<string> inspectionIDs = new List<string>();
                foreach (var item in facilityInspections)
                {
                    inspectionIDs.Add(item.FacilityInspectionID.ToString());
                }

                cmbFacilityInspectionID.ItemsSource = inspectionIDs;
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
            if (selectedFacilityInspectionItem != null)
            {
                canAddFacilityInspectionItem.Visibility = Visibility.Visible;
                canView.Visibility = Visibility.Hidden;
                btnAddFacilityInspectionItem.Visibility = Visibility.Hidden;
                BtnSubmitInspectionItemRecord.Visibility = Visibility.Hidden;
                btnUpdateInspectionItemRecord.Visibility = Visibility.Visible;
                lblFacilityInspectionItem.Content = "Update Facility Inspection Item Record";
                txtItemName.Text = selectedFacilityInspectionItem.ItemName;
                txtUserID.Text = selectedFacilityInspectionItem.UserID.ToString();
                txtItemDescription.Text = selectedFacilityInspectionItem.ItemDescription;
            }
        }
    }
}

