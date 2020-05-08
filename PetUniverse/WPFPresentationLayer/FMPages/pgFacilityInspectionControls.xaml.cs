using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.FMPages
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// 
    /// Interaction logic for FacilityInspectionControls.xaml
    /// </summary>
    public partial class FacilityInspectionControls : Page
    {
        private IFacilityInspectionManager _facilityInspectionManager;

        string[] inspectionItems =
        {
            "Inspection ID",
            "User ID",
            "Inspector Name"
        };
        FacilityInspection selectedFacilityInspection;

        private PetUniverseUser _user;


        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// constructor for facility inspection controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionControls()
        {
            InitializeComponent();
            _facilityInspectionManager = new FacilityInspectionManager();
            selectedFacilityInspection = new FacilityInspection();
            cmbFacilityInspectionFields.ItemsSource = inspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// constructor for facility inspection controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionControls(PetUniverseUser user)
        {
            InitializeComponent();
            _facilityInspectionManager = new FacilityInspectionManager();
            selectedFacilityInspection = new FacilityInspection();
            cmbFacilityInspectionFields.ItemsSource = inspectionItems;
            _user = user;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// displays the add facility inspection canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFacilityInspection_Click(object sender, RoutedEventArgs e)
        {
            canAddFacilityInspection.Visibility = Visibility.Visible;
            txtUserID.Text = _user.PUUserID.ToString();
            canView.Visibility = Visibility.Hidden;
            cndInspectionDate.DisplayDateStart = DateTime.Now;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
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
        private void BtnSubmitInspectionRecord_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(txtInspectorName.Text))
            {
                MessageBox.Show("Please enter the inspector name");
                return;
            }
            if (string.IsNullOrEmpty(cndInspectionDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the inspection date");
                return;
            }
            if (string.IsNullOrEmpty(txtInspectionDescription.Text))
            {
                MessageBox.Show("Please enter the inspection description");
                return;
            }

            try
            {
                FacilityInspection facilityInspection = new FacilityInspection
                {
                    UserID = Int32.Parse(txtUserID.Text),
                    InspectorName = txtInspectorName.Text,
                    InspectionDate = (DateTime)cndInspectionDate.SelectedDate,
                    InspectionDescription = txtInspectionDescription.Text
                };
                if (_facilityInspectionManager.AddFacilityInspectionRecord(facilityInspection))
                {
                    MessageBox.Show("Inspection record successfully added.");
                    canAddFacilityInspection.Visibility = Visibility.Hidden;
                    canView.Visibility = Visibility.Visible;
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtInspectorName.Text = "";
                    txtInspectionDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Inspection record was not added.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
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
        private void btnCancelInspectionRecord_Click(object sender, RoutedEventArgs e)
        {
            txtUserID.Text = "";
            txtInspectorName.Text = "";
            txtInspectionDescription.Text = "";
            lblFacilityInspection.Content = "Enter Facility Inspection Record";
            if (btnUpdateBuildingInspectionRecord.Visibility == Visibility.Visible)
            {
                btnUpdateBuildingInspectionRecord.Visibility = Visibility.Hidden;
                BtnSubmitInspectionRecord.Visibility = Visibility.Visible;
                lblInspectionCompleted.Visibility = Visibility.Hidden;
                chkInspectionCompleted.Visibility = Visibility.Hidden;
            }
            canAddFacilityInspection.Visibility = Visibility.Hidden;
            canView.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
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
        private void dgFacilityInspection_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgFacilityInspection.ItemsSource == null)
                {
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveAllFacilityInspection((bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
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
                dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveAllFacilityInspection((bool)chkInspected.IsChecked);
                dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                dgFacilityInspection.Columns[1].Header = "User ID";
                dgFacilityInspection.Columns[2].Header = "Inspector Name";
                dgFacilityInspection.Columns[3].Header = "Inspection Date";
                dgFacilityInspection.Columns[4].Header = "Inspection Description";

            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
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
        private void chkInspected_Click(object sender, RoutedEventArgs e)
        {
            RefreshViewAllList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
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
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
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
            if (cmbFacilityInspectionFields.Text == inspectionItems[0])
            {
                try
                {
                    int inspectionID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveFacilityInspectionByID(inspectionID, (bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityInspectionFields.Text == inspectionItems[1])
            {
                try
                {
                    int userID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveFacilityInspectionByUserID(userID, (bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityInspectionFields.Text == inspectionItems[2])
            {
                try
                {
                    string inspectorName = txtSearchItem.Text;
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveFacilityInspectionByInspectorName(inspectorName, (bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/18/2020
        /// Approver: Chuck Baxter, 3/18/2020
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
        private void dgFacilityInspection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtUserID.Text = _user.PUUserID.ToString();
            cndInspectionDate.DisplayDateStart = DateTime.Now;
            selectedFacilityInspection = (FacilityInspection)dgFacilityInspection.SelectedItem;
            if (selectedFacilityInspection != null)
            {
                canAddFacilityInspection.Visibility = Visibility.Visible;
                canView.Visibility = Visibility.Hidden;
                btnUpdateBuildingInspectionRecord.Visibility = Visibility.Visible;
                BtnSubmitInspectionRecord.Visibility = Visibility.Hidden;
                lblInspectionCompleted.Visibility = Visibility.Visible;
                chkInspectionCompleted.Visibility = Visibility.Visible;
                lblFacilityInspection.Content = "Update Facility Inspection Record";
                txtUserID.Text = selectedFacilityInspection.UserID.ToString();
                txtInspectorName.Text = selectedFacilityInspection.InspectorName;
                txtInspectionDescription.Text = selectedFacilityInspection.InspectionDescription;
                cndInspectionDate.SelectedDate = selectedFacilityInspection.InspectionDate;
                chkInspectionCompleted.IsChecked = selectedFacilityInspection.InspectionCompleted;
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/18/2020
        /// Approver: Chuck Baxter, 3/18/2020
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
        private void btnUpdateBuildingInspectionRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(txtInspectorName.Text))
            {
                MessageBox.Show("Please enter the inspector name");
                return;
            }
            if (string.IsNullOrEmpty(cndInspectionDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the inspection date");
                return;
            }
            if (string.IsNullOrEmpty(txtInspectionDescription.Text))
            {
                MessageBox.Show("Please enter the inspection description");
                return;
            }

            try
            {
                FacilityInspection facilityInspection = new FacilityInspection
                {
                    UserID = Int32.Parse(txtUserID.Text),
                    InspectorName = txtInspectorName.Text,
                    InspectionDate = (DateTime)cndInspectionDate.SelectedDate,
                    InspectionDescription = txtInspectionDescription.Text,
                    InspectionCompleted = (bool)chkInspectionCompleted.IsChecked
                };
                if (_facilityInspectionManager.EditFacilityInspection(selectedFacilityInspection, facilityInspection))
                {
                    MessageBox.Show("Inspection record successfully updated.");
                    canAddFacilityInspection.Visibility = Visibility.Hidden;
                    canView.Visibility = Visibility.Visible;
                    BtnSubmitInspectionRecord.Visibility = Visibility.Visible;
                    btnUpdateBuildingInspectionRecord.Visibility = Visibility.Hidden;
                    lblInspectionCompleted.Visibility = Visibility.Hidden;
                    chkInspectionCompleted.Visibility = Visibility.Hidden;
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtInspectorName.Text = "";
                    txtInspectionDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Inspection record was not updated.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }
    }
}
