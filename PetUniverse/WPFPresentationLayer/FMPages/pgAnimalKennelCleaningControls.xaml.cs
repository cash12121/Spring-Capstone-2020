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
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Interaction logic for AnimalKennelCleaningControls.xaml
    /// </summary>
    public partial class pgAnimalKennelCleaningControls : Page
    {
        private IAnimalKennelCleaningManager _cleaningManager;

        private PetUniverseUser _user;

        private AnimalKennelCleaningRecord _oldCleaningRecord;

        private bool isAddMode;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Initial constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public pgAnimalKennelCleaningControls()
        {
            InitializeComponent();
            _cleaningManager = new AnimalKennelCleaningManager();

            isAddMode = false;
            _oldCleaningRecord = null;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Second constructor; Takes the currently logged in user to auto-populate the UserID field
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="user"></param>
        public pgAnimalKennelCleaningControls(PetUniverseUser user)
        {
            InitializeComponent();
            _cleaningManager = new AnimalKennelCleaningManager();
            _user = user;

            isAddMode = false;
            _oldCleaningRecord = null;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/9/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Extracted method for enabling editing fields;
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableEditingFields()
        {
            txtKennelID.IsEnabled = true;
            txtNotes.IsEnabled = true;
            txtUserID.IsEnabled = true;
            cndCleaningDate.IsEnabled = true;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Reveals the details canvas for adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddKennelCleaning_Click(object sender, RoutedEventArgs e)
        {
            canAddKennelCleaningRecord.Visibility = Visibility.Visible;
            txtNotes.Text = "";
            txtUserID.Text = _user.PUUserID.ToString();

            lblTitle.Content = "Add Cleaning Record";

            isAddMode = true;

            EnableEditingFields();
            canView.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// The button that triggers the process for saving record data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitCleaningRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text) || !int.TryParse(txtUserID.Text, out int num1))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(txtKennelID.Text) || !int.TryParse(txtKennelID.Text, out int num2))
            {
                MessageBox.Show("Please enter a valid kennel id");
                return;
            }
            if (string.IsNullOrEmpty(cndCleaningDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please select the cleaning date");
                return;
            }
            if (txtNotes.Text.Length > 250)
            {
                MessageBox.Show("Notes field is too long. Please enter again.");
                return;
            }

            try
            {
                AnimalKennelCleaningRecord newCleaningRecord = new AnimalKennelCleaningRecord
                {
                    UserID = num1,
                    AnimalKennelID = num2,
                    Date = (DateTime)cndCleaningDate.SelectedDate,
                    Notes = txtNotes.Text
                };
                if (isAddMode)
                {

                    if (_cleaningManager.AddKennelCleaningRecord(newCleaningRecord))
                    {
                        WPFErrorHandler.SuccessMessage("Cleaning Record successfully added.");
                        CloseCleaningCanvas();
                    }
                    else
                    {
                        MessageBox.Show("Cleaning record was not added.");
                    }
                }
                else
                {
                    if (_cleaningManager.EditKennelCleaningRecord(_oldCleaningRecord, newCleaningRecord))
                    {
                        WPFErrorHandler.SuccessMessage("Cleaning Record successfully edited.");
                        CloseCleaningCanvas();
                    }
                    else
                    {
                        MessageBox.Show("Cleaning record was not edited.");
                    }
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Button for hiding the canvas.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseCleaningCanvas();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Extracted method for resetting each field and hiding the canvas
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 4/9/2020
        /// Update: Added a call to refresh the data
        /// </remarks>
        private void CloseCleaningCanvas()
        {
            txtUserID.Text = "";
            txtKennelID.Text = "";
            txtNotes.Text = "";
            cndCleaningDate.SelectedDate = null;

            txtUserID.IsEnabled = false;
            txtKennelID.IsEnabled = false;
            txtNotes.IsEnabled = false;
            cndCleaningDate.IsEnabled = false;

            BtnSubmitCleaningRecord.Visibility = Visibility.Visible;
            BtnEditCleaning.Visibility = Visibility.Hidden;

            canAddKennelCleaningRecord.Visibility = Visibility.Hidden;

            BtnDeleteCleaning.IsEnabled = false;
            BtnDeleteCleaning.Visibility = Visibility.Hidden;

            canView.Visibility = Visibility.Visible;
            RefreshData();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Loads the data of a single cleaning record to the view/edit record.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgKennelCleaning_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                _oldCleaningRecord = (AnimalKennelCleaningRecord)dgKennelCleaning.SelectedItem;

                lblTitle.Content = "Viewing Cleaning Record";

                txtKennelID.Text = _oldCleaningRecord.AnimalKennelID.ToString();
                txtNotes.Text = _oldCleaningRecord.Notes;
                txtUserID.Text = _oldCleaningRecord.UserID.ToString();
                cndCleaningDate.SelectedDate = _oldCleaningRecord.Date;

                canAddKennelCleaningRecord.Visibility = Visibility.Visible;
                canView.Visibility = Visibility.Hidden;
                BtnSubmitCleaningRecord.Visibility = Visibility.Hidden;
                BtnEditCleaning.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message);
            }


        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Retrieves all of the kennel cleaning records from the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgKennelCleaning_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/8/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Retrieves all of the kennel cleaning records from the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshData()
        {
            try
            {
                dgKennelCleaning.ItemsSource = _cleaningManager.RetrieveAllKennelCleaningRecords();
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/10/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Enables all of the editing fields
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditCleaningRecord_Click(object sender, RoutedEventArgs e)
        {
            BtnSubmitCleaningRecord.Visibility = Visibility.Visible;
            BtnEditCleaning.Visibility = Visibility.Hidden;

            lblTitle.Content = "Editing Kennel Cleaning Records";

            BtnDeleteCleaning.IsEnabled = true;
            BtnDeleteCleaning.Visibility = Visibility.Visible;

            EnableEditingFields();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/10/2020
        /// Approver: Carl Davis 4/10/2020
        /// 
        /// Deletes a cleaning record from the database 
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteCleaning_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Cleaning Record",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
            {
                return;
            }

            try
            {
                _cleaningManager.RemoveKennelCleaningRecord(_oldCleaningRecord);
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }

            CloseCleaningCanvas();
        }
    }
}
