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
    /// Created: 2/21/2020
    /// Approver: Steven Cardona
    /// 
    /// Interaction logic for FacilityMaintenanceControls.xaml
    /// </summary>BtnSubmitMaintenanceRecord_Click
    public partial class FacilityMaintenanceControls : Page
    {

        private IFacilityMaintenanceManager _facilityMaintenanceManager;

        private PetUniverseUser _user;

        string[] maintenanceItems =
        {
            "Maintenance ID",
            "User ID",
            "Maintenance Name"
        };
        FacilityMaintenance selectedFacilityMaintenance;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona 
        /// 
        /// constructor for facility maintenance controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityMaintenanceControls()
        {
            InitializeComponent();
            _facilityMaintenanceManager = new FacilityMaintenanceManager();
            selectedFacilityMaintenance = new FacilityMaintenance();
            cmbFacilityMaintenanceFields.ItemsSource = maintenanceItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: 
        /// 
        /// constructor for facility maintenance controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityMaintenanceControls(PetUniverseUser user)
        {
            InitializeComponent();
            _facilityMaintenanceManager = new FacilityMaintenanceManager();
            selectedFacilityMaintenance = new FacilityMaintenance();
            cmbFacilityMaintenanceFields.ItemsSource = maintenanceItems;
            _user = user;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
        /// 
        /// method to load facility maintenance data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgFacilityMaintenance_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgFacilityMaintenance.ItemsSource == null)
                {
                    dgFacilityMaintenance.ItemsSource = _facilityMaintenanceManager.RetrieveAllFacilityMaintenance((bool)chkActive.IsChecked);
                    dgFacilityMaintenance.Columns[0].Header = "Maitenance ID";
                    dgFacilityMaintenance.Columns[1].Header = "User ID";
                    dgFacilityMaintenance.Columns[2].Header = "Maitenance Name";
                    dgFacilityMaintenance.Columns[3].Header = "Maitenance Interval";
                    dgFacilityMaintenance.Columns[4].Header = "Maitenance Description";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
        /// 
        /// method to refresh the data grid items
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshViewAllList()
        {
            try
            {
                dgFacilityMaintenance.ItemsSource = _facilityMaintenanceManager.RetrieveAllFacilityMaintenance((bool)chkActive.IsChecked);
                dgFacilityMaintenance.Columns[0].Header = "Maitenance ID";
                dgFacilityMaintenance.Columns[1].Header = "User ID";
                dgFacilityMaintenance.Columns[2].Header = "Maitenance Name";
                dgFacilityMaintenance.Columns[3].Header = "Maitenance Interval";
                dgFacilityMaintenance.Columns[4].Header = "Maitenance Description";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
        /// 
        /// displays the add facility maintenance canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddFacilityMaintenance_Click(object sender, RoutedEventArgs e)
        {
            txtUserID.Text = _user.PUUserID.ToString();
            canView.Visibility = Visibility.Hidden;
            canAddFacilityMaintenance.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
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
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFacilityMaintenanceFields.Text == maintenanceItems[0])
            {
                try
                {
                    List<FacilityMaintenance> facilityMaintenances = new List<FacilityMaintenance>();


                    int maintenanceID = Int32.Parse(txtSearchItem.Text);
                    facilityMaintenances.Add(_facilityMaintenanceManager.RetrieveFacilityMaintenanceByFacilityMaintenanceID(maintenanceID, (bool)chkActive.IsChecked));
                    dgFacilityMaintenance.ItemsSource = facilityMaintenances;
                    dgFacilityMaintenance.Columns[0].Header = "Maitenance ID";
                    dgFacilityMaintenance.Columns[1].Header = "User ID";
                    dgFacilityMaintenance.Columns[2].Header = "Maitenance Name";
                    dgFacilityMaintenance.Columns[3].Header = "Maitenance Interval";
                    dgFacilityMaintenance.Columns[4].Header = "Maitenance Description";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmbFacilityMaintenanceFields.Text == maintenanceItems[1])
            {
                try
                {
                    int userID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityMaintenance.ItemsSource = _facilityMaintenanceManager.RetrieveFacilityMaintenanceByUserID(userID, (bool)chkActive.IsChecked);
                    dgFacilityMaintenance.Columns[0].Header = "Maitenance ID";
                    dgFacilityMaintenance.Columns[1].Header = "User ID";
                    dgFacilityMaintenance.Columns[2].Header = "Maitenance Name";
                    dgFacilityMaintenance.Columns[3].Header = "Maitenance Interval";
                    dgFacilityMaintenance.Columns[4].Header = "Maitenance Description";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (cmbFacilityMaintenanceFields.Text == maintenanceItems[2])
            {
                string maintenanceName = txtSearchItem.Text;
                dgFacilityMaintenance.ItemsSource = _facilityMaintenanceManager.RetrieveFacilityMaintenanceFacilityMaintenanceName(maintenanceName, (bool)chkActive.IsChecked);
                dgFacilityMaintenance.Columns[0].Header = "Maitenance ID";
                dgFacilityMaintenance.Columns[1].Header = "User ID";
                dgFacilityMaintenance.Columns[2].Header = "Maitenance Name";
                dgFacilityMaintenance.Columns[3].Header = "Maitenance Interval";
                dgFacilityMaintenance.Columns[4].Header = "Maitenance Description";
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
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
        private void BtnCancelMaintenanceRecord_Click(object sender, RoutedEventArgs e)
        {
            txtUserID.Text = "";
            txtMaintenanceName.Text = "";
            txtMaintenanceInterval.Text = "";
            txtMaintenanceDescription.Text = "";
            lblFacilityMaintenance.Content = "Enter Facility Maintenance Record";
            if (btnUpdateBuildingMaintenanceRecord.Visibility == Visibility.Visible)
            {
                btnUpdateBuildingMaintenanceRecord.Visibility = Visibility.Hidden;
                BtnSubmitMaintenanceRecord.Visibility = Visibility.Visible;
            }
            canAddFacilityMaintenance.Visibility = Visibility.Hidden;
            canView.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
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
        private void BtnSubmitMaintenanceRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(txtMaintenanceName.Text))
            {
                MessageBox.Show("Please enter the maintenance name");
                return;
            }
            if (string.IsNullOrEmpty(txtMaintenanceInterval.Text))
            {
                MessageBox.Show("Please enter the maintenance interval");
                return;
            }
            if (string.IsNullOrEmpty(txtMaintenanceDescription.Text))
            {
                MessageBox.Show("Please enter the maintenance description");
                return;
            }

            try
            {
                FacilityMaintenance facilityMaintenance = new FacilityMaintenance
                {
                    UserID = Int32.Parse(txtUserID.Text),
                    MaintenanceName = txtMaintenanceName.Text,
                    MaintenanceInterval = txtMaintenanceInterval.Text,
                    MaintenanceDescription = txtMaintenanceDescription.Text
                };
                if (_facilityMaintenanceManager.AddFacilityMaintenanceRecord(facilityMaintenance))
                {
                    MessageBox.Show("Maintenance record successfully added.");
                    canAddFacilityMaintenance.Visibility = Visibility.Hidden;
                    canView.Visibility = Visibility.Visible;
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtMaintenanceName.Text = "";
                    txtMaintenanceInterval.Text = "";
                    txtMaintenanceDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Maintenance record was not added.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
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
        private void dgFacilityMaintenance_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtUserID.Text = _user.PUUserID.ToString();
            selectedFacilityMaintenance = (FacilityMaintenance)dgFacilityMaintenance.SelectedItem;
            if (selectedFacilityMaintenance != null)
            {
                canAddFacilityMaintenance.Visibility = Visibility.Visible;
                BtnSubmitMaintenanceRecord.Visibility = Visibility.Hidden;
                btnUpdateBuildingMaintenanceRecord.Visibility = Visibility.Visible;
                canView.Visibility = Visibility.Hidden;
                lblFacilityMaintenance.Content = "Update Facility Maintenance Record";
                txtUserID.Text = selectedFacilityMaintenance.UserID.ToString();
                txtMaintenanceName.Text = selectedFacilityMaintenance.MaintenanceName;
                txtMaintenanceInterval.Text = selectedFacilityMaintenance.MaintenanceInterval;
                txtMaintenanceDescription.Text = selectedFacilityMaintenance.MaintenanceDescription;
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Steven Cardona
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
        private void btnUpdateBuildingMaintenanceRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(txtMaintenanceName.Text))
            {
                MessageBox.Show("Please enter the maintenance name");
                return;
            }
            if (string.IsNullOrEmpty(txtMaintenanceInterval.Text))
            {
                MessageBox.Show("Please enter the maintenance interval");
                return;
            }
            if (string.IsNullOrEmpty(txtMaintenanceDescription.Text))
            {
                MessageBox.Show("Please enter the maintenance description");
                return;
            }

            try
            {
                FacilityMaintenance facilityMaintenance = new FacilityMaintenance
                {
                    UserID = Int32.Parse(txtUserID.Text),
                    MaintenanceName = txtMaintenanceName.Text,
                    MaintenanceInterval = txtMaintenanceInterval.Text,
                    MaintenanceDescription = txtMaintenanceDescription.Text
                };
                if (_facilityMaintenanceManager.EditFacilityMaintenance(selectedFacilityMaintenance, facilityMaintenance))
                {
                    MessageBox.Show("Maintenance record successfully updated.");
                    BtnSubmitMaintenanceRecord.Visibility = Visibility.Visible;
                    btnUpdateBuildingMaintenanceRecord.Visibility = Visibility.Hidden;
                    canAddFacilityMaintenance.Visibility = Visibility.Hidden;
                    canView.Visibility = Visibility.Visible;
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtMaintenanceName.Text = "";
                    txtMaintenanceInterval.Text = "";
                    txtMaintenanceDescription.Text = "";
                    lblFacilityMaintenance.Content = "Enter Facility Maintenance Record";
                }
                else
                {
                    MessageBox.Show("Maintenance record was not updated.");
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Update");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
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
        private void BtnDeleteFacilityMaintenance_Click(object sender, RoutedEventArgs e)
        {
            selectedFacilityMaintenance = (FacilityMaintenance)dgFacilityMaintenance.SelectedItem;
            string caption = "";
            if (MessageBox.Show("Are you sure you want to deactivate this record?", caption, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    _facilityMaintenanceManager.DeactivateFacilityMaintenance(selectedFacilityMaintenance.FacilityMaintenanceID);
                    RefreshViewAllList();
                    MessageBox.Show("Maintenance record successfully deactivated.");
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message, "Update");
                }
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
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
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshViewAllList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/6/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// Refeshes the view all list when chkActive is clicked
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkActive_Click(object sender, RoutedEventArgs e)
        {
            RefreshViewAllList();
        }
    }
}
