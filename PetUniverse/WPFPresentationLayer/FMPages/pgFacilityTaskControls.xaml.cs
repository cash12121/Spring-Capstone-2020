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

namespace WPFPresentationLayer.FMPages
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// 
    /// Interaction logic for FacilityTaskControls.xaml
    /// </summary>
    public partial class FacilityTaskControls : Page
    {
        private IFacilityTaskManager _facilityTaskManager;

        string[] searchItems =
        {
            "Facility Task ID",
            "Facility Task Name",
            "User ID"
        };

        FacilityTask selectedFacilityTask;

        private PetUniverseUser _user;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// constructor for facility Task controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityTaskControls()
        {
            InitializeComponent();
            _facilityTaskManager = new FacilityTaskManager();
            selectedFacilityTask = new FacilityTask();
            cmbFacilityTaskFields.ItemsSource = searchItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// constructor for facility Task controls with a user parameter
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityTaskControls(PetUniverseUser user)
        {
            InitializeComponent();
            _facilityTaskManager = new FacilityTaskManager();
            selectedFacilityTask = new FacilityTask();
            _user = user;
            cmbFacilityTaskFields.ItemsSource = searchItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// displays the add facility task canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFacilityTask_Click(object sender, RoutedEventArgs e)
        {
            canAddFacilityTask.Visibility = Visibility.Visible;
            canViewFacilityTask.Visibility = Visibility.Hidden;
            txtUserID.Text = _user.PUUserID.ToString();
            cndStartDate.DisplayDateStart = DateTime.Now;
            cndCompletionDate.DisplayDateStart = DateTime.Now;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// creates a new facility task record the user has entered if validated
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitTaskRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                MessageBox.Show("Please enter the facility task name");
                return;
            }
            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(cndStartDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the start date");
                return;
            }
            if (string.IsNullOrEmpty(cndCompletionDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the completion date");
                return;
            }
            if (string.IsNullOrEmpty(txtTaskNotes.Text))
            {
                MessageBox.Show("Please enter the task notes");
                return;
            }

            try
            {
                FacilityTask facilityTask = new FacilityTask
                {
                    FacilityTaskName = txtTaskName.Text,
                    UserID = Int32.Parse(txtUserID.Text),
                    StartDate = (DateTime)cndStartDate.SelectedDate,
                    CompletionDate = (DateTime)cndStartDate.SelectedDate,
                    FacilityTaskNotes = txtTaskNotes.Text
                };
                if (_facilityTaskManager.AddFacilityTaskRecord(facilityTask))
                {
                    MessageBox.Show("Facility Task record successfully added.");
                    canAddFacilityTask.Visibility = Visibility.Hidden;
                    canViewFacilityTask.Visibility = Visibility.Visible;
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtTaskName.Text = "";
                    txtTaskNotes.Text = "";
                }
                else
                {
                    MessageBox.Show("Facility Task record was not added.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
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
                dgFacilityTask.ItemsSource = _facilityTaskManager.RetrieveAllFacilityTask((bool)chkTaskCompleted.IsChecked);
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// cancels update a record and brings user back to display screen
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelTaskRecord_Click(object sender, RoutedEventArgs e)
        {
            txtTaskName.Text = "";
            txtUserID.Text = "";
            txtTaskNotes.Text = "";
            if (btnUpdateFacilityTaskRecord.Visibility == Visibility.Visible)
            {
                btnUpdateFacilityTaskRecord.Visibility = Visibility.Hidden;
                BtnSubmitTaskRecord.Visibility = Visibility.Visible;
                lblTaskFinished.Visibility = Visibility.Hidden;
                chkTaskFinished.Visibility = Visibility.Hidden;
            }
            canAddFacilityTask.Visibility = Visibility.Hidden;
            canViewFacilityTask.Visibility = Visibility.Visible;
            lblFacilityTask.Content = "Enter Facility Task Record";
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// method to load facility task data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgFacilityTask_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgFacilityTask.ItemsSource == null)
                {
                    dgFacilityTask.ItemsSource = _facilityTaskManager.RetrieveAllFacilityTask();
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// method to set the names of the column headers of the data grid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgFacilityTask_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgFacilityTask.Columns[0].Header = "Facility Task ID";
            dgFacilityTask.Columns[1].Header = "Facility Task Name";
            dgFacilityTask.Columns[2].Header = "User ID";
            dgFacilityTask.Columns[3].Header = "Start Date";
            dgFacilityTask.Columns[4].Header = "Completion Date";
            dgFacilityTask.Columns[5].Header = "Facility Task Notes";
            dgFacilityTask.Columns[6].Header = "Task Completed";
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// 
        /// Refeshes the view all list when chkTaskComplete is clicked
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTaskCompleted_Click(object sender, RoutedEventArgs e)
        {
            RefreshViewAllList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
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
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
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
            if (cmbFacilityTaskFields.Text == searchItems[0])
            {
                try
                {
                    int taskID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityTask.ItemsSource = _facilityTaskManager.RetrieveFacilityTaskByID(taskID, (bool)chkTaskCompleted.IsChecked);
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityTaskFields.Text == searchItems[1])
            {
                try
                {
                    string taskName = txtSearchItem.Text;
                    dgFacilityTask.ItemsSource = _facilityTaskManager.RetrieveFacilityTaskByTaskName(taskName, (bool)chkTaskCompleted.IsChecked);
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityTaskFields.Text == searchItems[2])
            {
                try
                {
                    int userID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityTask.ItemsSource = _facilityTaskManager.RetrieveFacilityTaskByUserID(userID, (bool)chkTaskCompleted.IsChecked);
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
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
        private void dgFacilityTask_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtUserID.Text = _user.PUUserID.ToString();
            selectedFacilityTask = (FacilityTask)dgFacilityTask.SelectedItem;
            cndStartDate.DisplayDateStart = DateTime.Now;
            cndCompletionDate.DisplayDateStart = DateTime.Now;
            if (selectedFacilityTask != null)
            {

                BtnSubmitTaskRecord.Visibility = Visibility.Hidden;
                canViewFacilityTask.Visibility = Visibility.Hidden;
                canAddFacilityTask.Visibility = Visibility.Visible;
                btnUpdateFacilityTaskRecord.Visibility = Visibility.Visible;
                lblTaskFinished.Visibility = Visibility.Visible;
                chkTaskFinished.Visibility = Visibility.Visible;
                lblFacilityTask.Content = "Update Facility Task Record";
                txtUserID.Text = selectedFacilityTask.UserID.ToString();
                txtTaskName.Text = selectedFacilityTask.FacilityTaskName;
                txtTaskNotes.Text = selectedFacilityTask.FacilityTaskNotes;
                cndStartDate.SelectedDate = selectedFacilityTask.StartDate;
                cndCompletionDate.SelectedDate = selectedFacilityTask.CompletionDate;
                chkTaskFinished.IsChecked = selectedFacilityTask.TaskCompleted;
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
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
        private void btnUpdateFacilityTaskRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                MessageBox.Show("Please enter the facility task name");
                return;
            }
            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(cndStartDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the start date");
                return;
            }
            if (string.IsNullOrEmpty(cndCompletionDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the completion date");
                return;
            }
            if (string.IsNullOrEmpty(txtTaskNotes.Text))
            {
                MessageBox.Show("Please enter the task notes");
                return;
            }

            try
            {
                FacilityTask facilityTask = new FacilityTask
                {
                    FacilityTaskName = txtTaskName.Text,
                    UserID = Int32.Parse(txtUserID.Text),
                    StartDate = (DateTime)cndStartDate.SelectedDate,
                    CompletionDate = (DateTime)cndCompletionDate.SelectedDate,
                    FacilityTaskNotes = txtTaskNotes.Text,
                    TaskCompleted = (bool)chkTaskFinished.IsChecked
                };
                if (_facilityTaskManager.EditFacilityTask(selectedFacilityTask, facilityTask))
                {
                    MessageBox.Show("Facility Task record successfully updated.");
                    canAddFacilityTask.Visibility = Visibility.Hidden;
                    canViewFacilityTask.Visibility = Visibility.Visible;
                    BtnSubmitTaskRecord.Visibility = Visibility.Visible;
                    btnUpdateFacilityTaskRecord.Visibility = Visibility.Hidden;
                    lblTaskFinished.Visibility = Visibility.Hidden;
                    chkTaskFinished.Visibility = Visibility.Hidden;
                    lblFacilityTask.Content = "Enter Facility Task Record";
                    RefreshViewAllList();
                    txtUserID.Text = "";
                    txtTaskName.Text = "";
                    txtTaskNotes.Text = "";
                }
                else
                {
                    MessageBox.Show("Facility Task record was not updated.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/19/2020
        /// Approver: Daulton Schiling, 4/16/2020
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
        private void btnDeleteFacilityTask_Click(object sender, RoutedEventArgs e)
        {
            selectedFacilityTask = (FacilityTask)dgFacilityTask.SelectedItem;
            string caption = "";
            if (MessageBox.Show("Are you sure you want to delete this record?", caption, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    _facilityTaskManager.DeleteFacilityTask(selectedFacilityTask.FacilityTaskID);
                    RefreshViewAllList();
                    MessageBox.Show("Maintenance record successfully deleted.");
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message, "Update");
                }
            }
        }
    }
}
