using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/3/2020
    /// 
    /// A window class for displaying, creating, and updating
    /// animal activity records
    /// </summary>
    public partial class AnimalActivityRecords : Page
    {
        private IAnimalActivityManager _activityManager;
        private PetUniverseUser _user;
        private bool addMode = false;
        private Animal selectedAnimal;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Default constructor that requires a user object
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalActivityRecords(PetUniverseUser user)
        {
            InitializeComponent();
            _activityManager = new AnimalActivityManager();
            _user = user;
            cboApptTime.ItemsSource = VetAppointmentControls.Times();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Opens the selected activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dgActivities.SelectedItem == null)
            {
                return;
            }
            cmbActivityType2.ItemsSource = cmbActivityType.ItemsSource;
            canViewActivityRecord.Visibility = Visibility.Visible;
            PopulateFields((AnimalActivity)dgActivities.SelectedItem);
            canView.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Opens the window for creating a new activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            EnableAddMode();
            canViewActivityRecord.Visibility = Visibility.Visible;
            canView.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Prepares the form for adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableAddMode()
        {
            addMode = true;
            cmbActivityType2.ItemsSource = cmbActivityType.ItemsSource;
            cmbActivityType2.IsEnabled = true;
            dateActivityDate.IsEnabled = true;
            cboApptTime.IsEnabled = true;
            txtDescription.IsEnabled = true;
            btnSaveEdit.Content = "Save";
            dateActivityDate.DisplayDateStart = DateTime.Now;
            lblAnimal.Visibility = Visibility.Visible;
            dgAnimalList.Visibility = Visibility.Visible;

            try
            {
                dgAnimalList.ItemsSource = new AnimalManager().RetrieveAnimalsByActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Takes form out of record adding state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableAddMode()
        {
            addMode = false;
            cmbActivityType2.ItemsSource = null;
            dgAnimalList.ItemsSource = null;
            cmbActivityType2.IsEnabled = false;
            dateActivityDate.IsEnabled = false;
            cboApptTime.IsEnabled = false;
            txtDescription.IsEnabled = false;
            btnSaveEdit.Content = "Edit";
            selectedAnimal = null;
            lblAnimal.Visibility = Visibility.Hidden;
            dgAnimalList.Visibility = Visibility.Hidden;
            ClearFields();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Prepares form for editing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableEditMode()
        {
            cmbActivityType2.ItemsSource = cmbActivityType.ItemsSource;
            cmbActivityType2.IsEnabled = true;
            dateActivityDate.IsEnabled = true;
            cboApptTime.IsEnabled = true;
            txtDescription.IsEnabled = true;
            btnSaveEdit.Content = "Save";
            dateActivityDate.DisplayDateStart = DateTime.Now;
            lblAnimal.Visibility = Visibility.Visible;
            dgAnimalList.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;
            selectedAnimal = new Animal()
            {
                AnimalID = ((AnimalActivity)dgActivities.SelectedItem).AnimalID
            };

            try
            {
                dgAnimalList.ItemsSource = new AnimalManager().RetrieveAnimalsByActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Helper method to disable edit mode
        /// Only calls DisableAddMode() as
        /// they work exactly the same
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableEditMode()
        {
            btnDelete.Visibility = Visibility.Hidden;
            DisableAddMode();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Removes unncessary data grid colums when it is
        /// populated with data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgActivities_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgActivities.Columns.Remove(dgActivities.Columns[0]);
            dgActivities.Columns.Remove(dgActivities.Columns[0]);
            dgActivities.Columns.Remove(dgActivities.Columns[0]);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Populates the data grid when it is loaded
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgActivities_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshActivitiesList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Refreshes the list of activity records
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 5/5/2020
        /// Update: Cleaned up column headers and size
        /// </remarks>
        private void RefreshActivitiesList()
        {
            dgActivities.ItemsSource = null;           
            try
            {
                dgActivities.ItemsSource = _activityManager
                    .RetrieveAnimalActivitiesByActivityType(
                    cmbActivityType.SelectedItem.ToString());

                dgActivities.Columns[0].Header = "Name";
                dgActivities.Columns[1].Header = "Activity";
                dgActivities.Columns[2].Header = "Date & Time";
                dgActivities.Columns[3].Header = "Description";

                dgActivities.Columns[0].Width = 200;
                dgActivities.Columns[1].Width = 200;
                dgActivities.Columns[2].Width = 200;
                dgActivities.Columns[3].Width = 590;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Searches for activity records by a partial animal name.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalName">The animal name to search</param>
        private void SearchActivitiesListByAnimalName(string animalName)
        {
            dgActivities.ItemsSource = null;
            try
            {
                dgActivities.ItemsSource = _activityManager
                    .RetrieveAnimalActivitiesByPartialAnimalName(animalName,
                    cmbActivityType.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Clears the search field when it gets focus
        /// for the first time
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Equals("Search Animal Name"))
            {
                txtSearch.Text = "";
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Searches records for the entered animal name.
        /// This is for querys shorter than the three character
        /// requirement to trigger auto-searching
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnSearch.Content == "Search")
            {
                SearchActivitiesListByAnimalName(txtSearch.Text);
                btnSearch.Content = "Clear";
            }
            else
            {
                txtSearch.Text = "";
                btnSearch.Content = "Search";
            }

        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Populates the activity type combo box with all
        /// valid activity type options.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void cmbActivityType_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbActivityType.ItemsSource = _activityManager
                    .RetrieveAllAnimalActivityTypes()
                    .Select(a => a.ActivityTypeId);
                cmbActivityType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Triggered when the activity type is changed
        /// Refreshes the datagrid for the corresponding activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void cmbActivityType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbActivityType.SelectedItem == null)
            {
                cmbActivityType.SelectedIndex = 0;
            }
            txtSearch.Text = "Search Animal Name";
            btnSearch.Content = "Search";
            RefreshActivitiesList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Begins to auto-search the activity records when
        /// the user has entered three or more characters into
        /// the seach field. Resets results when the field is empty
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length < 3 &&
                txtSearch.Text.Length > 0 ||
                txtSearch.Text == "Search Animal Name")
            {
                return;
            }
            if (txtSearch.Text.Length == 0)
            {
                RefreshActivitiesList();
            }
            else
            {
                SearchActivitiesListByAnimalName(txtSearch.Text);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Closes the details canvas and sets the form
        /// to its original state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            canViewActivityRecord.Visibility = Visibility.Hidden;
            if (addMode)
            {
                DisableAddMode();
            }
            else
            {
                ClearFields();
                DisableEditMode();
            }
            canView.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Helper method to populate form controls
        /// when a record is opened
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PopulateFields(AnimalActivity activity)
        {
            txtActivityId.Text = activity.AnimalActivityId.ToString();
            txtAnimalName.Text = activity.AnimalName;
            cmbActivityType2.Text = activity.AnimalActivityTypeID;
            dateActivityDate.SelectedDate = activity.ActivityDateTime;
            cboApptTime.Text = activity.ActivityDateTime.ToShortTimeString();
            txtDescription.Text = activity.Description;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Sets form controls back to default values
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ClearFields()
        {
            txtActivityId.Text = "";
            txtAnimalName.Text = "";
            cmbActivityType2.ItemsSource = null;
            dateActivityDate.SelectedDate = null;
            cboApptTime.SelectedItem = null;
            txtDescription.Text = "";
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Handles saving and edititing functions
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 4/6/2020
        /// Update: Added edit functionality
        /// Approver: Chuck Baxter 4/7/2020
        /// </remarks>
        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSaveEdit.Content.Equals("Edit"))
            {
                EnableEditMode();
                return;
            }
            if (selectedAnimal == null)
            {
                MessageBox.Show("You must select an animal first!");
                return;
            }
            if (cmbActivityType2.SelectedItem == null)
            {
                MessageBox.Show("You must select an activity type!");
                return;
            }
            if (dateActivityDate.SelectedDate == null)
            {
                MessageBox.Show("You must select the activity date");
                return;
            }
            if (cboApptTime.SelectedItem == null)
            {
                MessageBox.Show("Please select the activity time");
                return;
            }
            DateTime activityDate;
            if (!DateTime.TryParse(
                dateActivityDate.SelectedDate.Value.ToShortDateString()
                + " " + cboApptTime.SelectedItem.ToString(), out activityDate))
            {
                MessageBox.Show("Invalid date or time entered");
                return;
            }
            AnimalActivity animalActivity = new AnimalActivity()
            {
                AnimalID = selectedAnimal.AnimalID,
                AnimalActivityTypeID = cmbActivityType2.SelectedItem.ToString(),
                ActivityDateTime = activityDate,
                UserID = _user.PUUserID,
                Description = txtDescription.Text
            };

            if (addMode)
            {
                try
                {
                    if (_activityManager.AddAnimalActivityRecord(animalActivity))
                    {
                        MessageBox.Show("Record added!");
                        DisableAddMode();
                        canViewActivityRecord.Visibility = Visibility.Hidden;
                        canView.Visibility = Visibility.Visible;
                        RefreshActivitiesList();
                    }
                    else
                    {
                        throw new ApplicationException();
                    }
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Failed to add record" :
                        ex.Message + " " + ex.InnerException.Message;
                    MessageBox.Show(message);
                }
            }
            else
            {
                // Perform update
                try
                {
                    if (_activityManager.EditExistingAnimalActivityRecord(
                        (AnimalActivity)dgActivities.SelectedItem, animalActivity))
                    {
                        MessageBox.Show("Record updated");
                        DisableEditMode();
                        canViewActivityRecord.Visibility = Visibility.Hidden;
                        canView.Visibility = Visibility.Visible;
                        RefreshActivitiesList();
                    }
                    else
                    {
                        throw new ApplicationException("Record not found");
                    }
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Failed to add record" :
                        ex.Message + " " + ex.InnerException.Message;
                    MessageBox.Show(message);
                }
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Sets the selected animal when creating
        /// an activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgAnimalList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgAnimalList.SelectedItem == null)
            {
                return;
            }
            selectedAnimal = (Animal)dgAnimalList.SelectedItem;
            txtAnimalName.Text = selectedAnimal.AnimalName;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Removes unncessary columns in animal data grid
        /// when grid is populated with data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgAnimalList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[0]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Deletes the selected activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AnimalActivity activity = (AnimalActivity)dgActivities.SelectedItem;
            if (activity == null)
            {
                return;
            }
            string message = "Are you sure you want to delete the " + activity.AnimalActivityTypeID +
                " record for " + activity.AnimalName + "? This can't be undone!";
            if (MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    if (_activityManager.DeleteAnimalActivityRecord(activity))
                    {
                        MessageBox.Show("Record deleted");
                        DisableEditMode();
                        canViewActivityRecord.Visibility = Visibility.Hidden;
                        canView.Visibility = Visibility.Visible;
                        RefreshActivitiesList();
                    }
                    else
                    {
                        throw new ApplicationException("Record not found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        ///
        /// button on the animal activities home page to go to the crud activity type page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditActivityTypes_Click(object sender, RoutedEventArgs e)
        {
            canActivityTypes.Visibility = Visibility.Visible;
            txtActivityName.Text = "";
            txtActivityNotes.Text = "";
            cmbSelectActivityType.Text = "";
            lblCreateActivityType.Visibility = Visibility.Hidden;
            lblDeleteActivityType.Visibility = Visibility.Hidden;
            lblEditActivityType.Visibility = Visibility.Hidden;
            lblSelectActivityType.Visibility = Visibility.Hidden;
            cmbSelectActivityType.Visibility = Visibility.Hidden;
            lblActivityName.Visibility = Visibility.Hidden;
            txtActivityName.Visibility = Visibility.Hidden;
            lblActivityNotes.Visibility = Visibility.Hidden;
            txtActivityNotes.Visibility = Visibility.Hidden;
            btnCreateActivtyTypeSave.Visibility = Visibility.Hidden;
            btnEditActivtyTypeSave.Visibility = Visibility.Hidden;
            btnDeleteActivtyTypeSave.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        ///
        /// Shows the create animal activity type functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateActivityType_Click(object sender, RoutedEventArgs e)
        {
            lblCreateActivityType.Visibility = Visibility.Visible;
            lblDeleteActivityType.Visibility = Visibility.Hidden;
            lblEditActivityType.Visibility = Visibility.Hidden;
            lblSelectActivityType.Visibility = Visibility.Hidden;
            cmbSelectActivityType.Visibility = Visibility.Hidden;
            lblActivityName.Visibility = Visibility.Visible;
            txtActivityName.Visibility = Visibility.Visible;
            lblActivityNotes.Visibility = Visibility.Visible;
            txtActivityNotes.Visibility = Visibility.Visible;
            btnCreateActivtyTypeSave.Visibility = Visibility.Visible;
            btnEditActivtyTypeSave.Visibility = Visibility.Hidden;
            btnDeleteActivtyTypeSave.Visibility = Visibility.Hidden;
            txtActivityName.Text = "";
            txtActivityNotes.Text = "";
            cmbSelectActivityType.Text = "";
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        ///
        /// Shows the edit animal activity type functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditActivityType_Click(object sender, RoutedEventArgs e)
        {
            lblCreateActivityType.Visibility = Visibility.Hidden;
            lblEditActivityType.Visibility = Visibility.Visible;
            lblDeleteActivityType.Visibility = Visibility.Hidden;
            lblSelectActivityType.Visibility = Visibility.Visible;
            cmbSelectActivityType.Visibility = Visibility.Visible;
            lblActivityName.Visibility = Visibility.Visible;
            txtActivityName.Visibility = Visibility.Visible;
            lblActivityNotes.Visibility = Visibility.Visible;
            txtActivityNotes.Visibility = Visibility.Visible;
            btnCreateActivtyTypeSave.Visibility = Visibility.Hidden;
            btnEditActivtyTypeSave.Visibility = Visibility.Visible;
            btnDeleteActivtyTypeSave.Visibility = Visibility.Hidden;
            txtActivityName.Text = "";
            txtActivityNotes.Text = "";
            cmbSelectActivityType.ItemsSource = _activityManager.RetrieveAllAnimalActivityTypes().Select(a => a.ActivityTypeId);
            cmbSelectActivityType.SelectedIndex = 0;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        ///
        /// shows the delete animal activity type functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteActivityType_Click(object sender, RoutedEventArgs e)
        {
            lblCreateActivityType.Visibility = Visibility.Hidden;
            lblEditActivityType.Visibility = Visibility.Hidden;
            lblDeleteActivityType.Visibility = Visibility.Visible;
            lblSelectActivityType.Visibility = Visibility.Visible;
            cmbSelectActivityType.Visibility = Visibility.Visible;
            lblActivityName.Visibility = Visibility.Hidden;
            txtActivityName.Visibility = Visibility.Hidden;
            lblActivityNotes.Visibility = Visibility.Hidden;
            txtActivityNotes.Visibility = Visibility.Hidden;
            btnCreateActivtyTypeSave.Visibility = Visibility.Hidden;
            btnEditActivtyTypeSave.Visibility = Visibility.Hidden;
            btnDeleteActivtyTypeSave.Visibility = Visibility.Visible;
            txtActivityName.Text = "";
            txtActivityNotes.Text = "";
            cmbSelectActivityType.ItemsSource = _activityManager.RetrieveAllAnimalActivityTypes().Select(a => a.ActivityTypeId);
            cmbSelectActivityType.SelectedIndex = 0;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        ///
        /// returns to the animal activty home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnToActivityHome_Click(object sender, RoutedEventArgs e)
        {
            canActivityTypes.Visibility = Visibility.Hidden;
            txtActivityName.Text = "";
            txtActivityNotes.Text = "";
            cmbSelectActivityType.Text = "";
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Saving a new animal activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateActivtyTypeSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtActivityName.Text))
            {
                MessageBox.Show("Please enter the name of the new activity type.");
                return;
            }
            if (String.IsNullOrEmpty(txtActivityNotes.Text))
            {
                MessageBox.Show("Please enter the description of the new activity type.");
                return;
            }
            AnimalActivityType animalActivityType = new AnimalActivityType();
            animalActivityType.ActivityTypeId = txtActivityName.Text;
            animalActivityType.Description = txtActivityNotes.Text;

            try
            {
                if (_activityManager.AddAnimalActivityType(animalActivityType))
                {
                    WPFErrorHandler.SuccessMessage("Activity Type Successfully Added");
                    cmbActivityType.ItemsSource = _activityManager.RetrieveAllAnimalActivityTypes().Select(a => a.ActivityTypeId);
                    cmbActivityType.SelectedIndex = 0;
                    canActivityTypes.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canActivityTypes.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Saving an updated animal activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditActivtyTypeSave_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtActivityName.Text))
            {
                MessageBox.Show("Please enter the name of the updated activity type.");
                return;
            }
            if (String.IsNullOrEmpty(txtActivityNotes.Text))
            {
                MessageBox.Show("Please enter the description of the updated activity type.");
                return;
            }

            AnimalActivityType newAnimalActivityType = new AnimalActivityType();
            newAnimalActivityType.ActivityTypeId = txtActivityName.Text;
            newAnimalActivityType.Description = txtActivityNotes.Text;

            AnimalActivityType oldAnimalActivityType = new AnimalActivityType();
            oldAnimalActivityType.ActivityTypeId = (string)cmbSelectActivityType.SelectedItem;

            try
            {
                if (_activityManager.EditAnimalActivityType(oldAnimalActivityType, newAnimalActivityType))
                {
                    WPFErrorHandler.SuccessMessage("Activity Type Successfully Updated");
                    cmbActivityType.ItemsSource = _activityManager.RetrieveAllAnimalActivityTypes().Select(a => a.ActivityTypeId);
                    cmbActivityType.SelectedIndex = 0;
                    canActivityTypes.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canActivityTypes.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Deleting animal activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteActivtyTypeSave_Click(object sender, RoutedEventArgs e)
        {
            AnimalActivityType animalActivityType = new AnimalActivityType();
            animalActivityType.ActivityTypeId = (string)cmbSelectActivityType.SelectedItem;
            try
            {
                if (_activityManager.DeleteAnimalActivityType(animalActivityType))
                {
                    WPFErrorHandler.SuccessMessage("Activity Type Successfully Deleted");
                    cmbActivityType.ItemsSource = _activityManager.RetrieveAllAnimalActivityTypes().Select(a => a.ActivityTypeId);
                    cmbActivityType.SelectedIndex = 0;
                    canActivityTypes.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n"
                    + "Make sure you are not attempting to delete an activity type that has records."
                    + "\n\n" + ex.InnerException.Message);
                canActivityTypes.Visibility = Visibility.Hidden;
            }
        }
    }
}
