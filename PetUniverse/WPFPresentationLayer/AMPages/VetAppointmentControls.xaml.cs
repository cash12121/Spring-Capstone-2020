using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/7/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// Approver: Carl Davis 2/14/2020
    /// 
    /// A window class to display a list of animal vet appointments
    /// </summary>
    public partial class VetAppointmentControls : Page
    {
        private IVetAppointmentManager _vetAppointmentManager;
        private IAnimalManager _animalManager;
        private PetUniverseUser _user;
        private Animal _selectedAnimal;
        private List<AnimalVetAppointment> _vetAppointments;
        private bool _editMode = false;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// No argument constructor that intializes
        /// the animal vet appointment manager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public VetAppointmentControls(PetUniverseUser user)
        {
            InitializeComponent();
            _vetAppointmentManager = new VetAppointmentManager();
            _animalManager = new AnimalManager();
            _user = user;
            cboAppointmentTime.ItemsSource = Times();
            cboFollowupTime.ItemsSource = Times();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// An event that is triggered when the data grid is loaded.
        /// Data grid is populated with vet appointment records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Opens the filters window with options for filtering
        /// the animal vet appointment list
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 4/25/2020
        /// Update: Added logic to add time data to filter
        /// combo boxes
        /// Approver: Chuck Baxter 4/27/2020
        /// </remarks>
        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {

            canViewVetAppointmentFilter.Visibility = Visibility.Visible;
            cboDateTime.ItemsSource = Times();
            cboFollowUpTime.ItemsSource = Times();
            GetFilteredResultsCount(null, null);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Helper method for populating combo box
        /// with every hour of the day in a 12 hour clock format
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        public static List<string> Times()
        {
            List<string> times = new List<string>();
            for (int i = 1; i < 25; i++)
            {
                string daytime = "AM";
                int subtrahend = 0;
                if (i > 12)
                {
                    daytime = "PM";
                    subtrahend = 12;
                }
                times.Add(i - subtrahend + ":00 " + daytime);
            }
            return times;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Opens window for creeating a new animal vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            canViewVetAppointment.Visibility = Visibility.Visible;
            canView.Visibility = Visibility.Hidden;
            EnableAddMode();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Opens a vet appointment record in detail view
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dgAppointments.SelectedItem != null)
            {
                canViewVetAppointment.Visibility = Visibility.Visible;
                canView.Visibility = Visibility.Hidden;
                PopulateFields((AnimalVetAppointment)dgAppointments.SelectedItem);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Populates controls with supplied data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PopulateFields(AnimalVetAppointment vetAppointment)
        {
            txtAnimalName.Text = vetAppointment.AnimalName;
            dateAppointmentDate.SelectedDate = vetAppointment.AppointmentDateTime;
            cboAppointmentTime.Text = vetAppointment.AppointmentDateTime.ToShortTimeString();
            txtClinicAddress.Text = vetAppointment.ClinicAddress;
            txtVetName.Text = vetAppointment.VetName;
            txtDescription.Text = vetAppointment.AppointmentDescription;
            chkSetActive.IsChecked = vetAppointment.Active;
            if (vetAppointment.FollowUpDateTime != null)
            {
                dateFollowUp.SelectedDate = vetAppointment.FollowUpDateTime;
                cboFollowupTime.Text = vetAppointment.AppointmentDateTime.ToShortTimeString();
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets all controls back to default values
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ClearFields()
        {
            txtAnimalName.Text = "";
            dateAppointmentDate.SelectedDate = null;
            cboAppointmentTime.SelectedItem = null;
            txtClinicAddress.Text = "";
            txtVetName.Text = "";
            txtDescription.Text = "";
            dgAnimalList.ItemsSource = null;
            dateFollowUp.SelectedDate = null;
            cboFollowupTime.SelectedItem = null;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Prepares UI controls for adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableAddMode()
        {
            dateAppointmentDate.IsEnabled = true;
            cboAppointmentTime.IsEnabled = true;
            txtClinicAddress.IsEnabled = true;
            txtDescription.IsEnabled = true;
            txtVetName.IsEnabled = true;
            dateAppointmentDate.DisplayDateStart = DateTime.Now;
            btnSaveEdit.Content = "Save";
            dgAnimalList.Visibility = Visibility.Visible;
            lblAnimalList.Visibility = Visibility.Visible;
            try
            {
                dgAnimalList.ItemsSource = _animalManager.RetrieveAnimalsByActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets all controls back to read only state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableAddMode()
        {
            dateAppointmentDate.IsEnabled = false;
            cboAppointmentTime.IsEnabled = false;
            txtClinicAddress.IsEnabled = false;
            txtDescription.IsEnabled = false;
            txtVetName.IsEnabled = false;
            btnSaveEdit.Content = "Edit";
            dgAnimalList.Visibility = Visibility.Hidden;
            lblAnimalList.Visibility = Visibility.Hidden;
            ClearFields();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020 
        /// Approver:
        /// 
        /// Prepares the interface for editing the selected record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableEditMode()
        {
            _editMode = true;
            dateAppointmentDate.IsEnabled = true;
            cboAppointmentTime.IsEnabled = true;
            txtClinicAddress.IsEnabled = true;
            txtDescription.IsEnabled = true;
            txtVetName.IsEnabled = true;
            dateFollowUp.IsEnabled = true;
            cboFollowupTime.IsEnabled = true;
            btnClearFollowUp.Visibility = Visibility.Visible;
            dateAppointmentDate.DisplayDateStart = DateTime.Now;
            dateFollowUp.DisplayDateStart = DateTime.Now.AddDays(1);
            btnSaveEdit.Content = "Save";
            btnDelete.Visibility = Visibility.Visible;
            chkSetActive.IsEnabled = true;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Disables editing mode when the record has been
        /// updated or the edit window was closed
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableEditMode()
        {
            _editMode = false;
            DisableAddMode();
            dateFollowUp.IsEnabled = false;
            cboFollowupTime.IsEnabled = false;
            btnClearFollowUp.Visibility = Visibility.Hidden;
            btnDelete.Visibility = Visibility.Hidden;
            chkSetActive.IsEnabled = false;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets the appointment list to null, then
        /// repopulates it with the most recent data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshList()
        {
            dgAppointments.ItemsSource = null;
            try
            {
                _vetAppointments = _vetAppointmentManager.RetrieveVetAppointmentsByActive((bool)chkActive.IsChecked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
            dgAppointments.ItemsSource = _vetAppointments;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets all controls back to default view, then closes 
        /// the vet appointment detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            canViewVetAppointment.Visibility = Visibility.Hidden;
            canView.Visibility = Visibility.Visible;
            DisableEditMode();
            ClearFields();
            RefreshList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Validates all submitted information and saves a record
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 3/1/2020
        /// Update: Utlilized validation utility and added edit functionality
        /// Approver: Ben Hanna, 3/6/2020
        /// </remarks>
        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSaveEdit.Content.Equals("Save"))
            {
                if (_selectedAnimal == null &&
                    _editMode == false)
                {
                    MessageBox.Show("No animal selected. Please double click on the " +
                        "desired animal in the list on the right");
                    return;
                }
                else if (_editMode)
                {
                    _selectedAnimal = new Animal();
                    _selectedAnimal.AnimalID =
                        ((AnimalVetAppointment)dgAppointments.SelectedItem).AnimalID;
                }
                if (dateAppointmentDate.SelectedDate == null)
                {
                    MessageBox.Show("Please select an appointment date");
                    return;
                }
                if (cboAppointmentTime.SelectedItem == null)
                {
                    MessageBox.Show("Please select an appointment time");
                    return;
                }
                if (!txtVetName.Text.IsValidVetName())
                {
                    MessageBox.Show("Vet name can't be blank!");
                    return;
                }
                if (!txtClinicAddress.Text.IsValidClinicAddress())
                {
                    MessageBox.Show("Clinic address is invalid");
                    return;
                }
                if (!txtDescription.Text.IsValidAppointmentDescription())
                {
                    MessageBox.Show("Please enter a more descriptive description");
                    return;
                }

                AnimalVetAppointment animalVetAppointment = new AnimalVetAppointment()
                {
                    AnimalID = _selectedAnimal.AnimalID,
                    AnimalName = _selectedAnimal.AnimalName,
                    UserID = _user.PUUserID,
                    AppointmentDateTime = DateTime.Parse(
                        dateAppointmentDate.SelectedDate.Value.ToShortDateString() +
                        " " + cboAppointmentTime.SelectedValue),
                    ClinicAddress = txtClinicAddress.Text,
                    VetName = txtVetName.Text,
                    AppointmentDescription = txtDescription.Text,
                    FollowUpDateTime = null
                };

                if (_editMode)
                {
                    if ((dateFollowUp.SelectedDate != null &&
                        cboFollowupTime.SelectedItem == null) ||
                        (dateFollowUp.SelectedDate == null &&
                        cboFollowupTime.SelectedItem != null))
                    {
                        MessageBox.Show("If you select a follow up date you must select a time also and vice versa." +
                            " You can select the 'Clear Follow Up' button to not have one set.");
                        return;
                    }
                    if (dateFollowUp.SelectedDate != null
                        && cboFollowupTime.SelectedItem != null)
                    {
                        animalVetAppointment.FollowUpDateTime =
                                DateTime.Parse(
                                    dateFollowUp.SelectedDate.Value.ToShortDateString() +
                                    " " + cboFollowupTime.SelectedValue);
                    }
                    try
                    {
                        if (_vetAppointmentManager.EditAnimalVetAppointmentRecord(
                            (AnimalVetAppointment)dgAppointments.SelectedItem, animalVetAppointment))
                        {
                            MessageBox.Show("Record updated!");
                            BtnClose_Click(null, null);
                            RefreshList();
                            DisableEditMode();
                        }
                        else
                        {
                            throw new ApplicationException();
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex == null ? "Failed to update record" :
                            ex.Message + " " + ex.InnerException;
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    try
                    {
                        if (_vetAppointmentManager.AddAnimalVetAppointmentRecord(animalVetAppointment))
                        {
                            MessageBox.Show("Appointment has been scheduled!");
                            DisableAddMode();
                            BtnClose_Click(null, null);
                            RefreshList();
                        }
                        else
                        {
                            throw new ApplicationException();
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex == null ? "Failed to save record" :
                            ex.Message + " " + ex.InnerException;
                        MessageBox.Show(message);
                    }
                }
            }
            else if (btnSaveEdit.Content.Equals("Edit"))
            {
                EnableEditMode();
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Applies a filter(s) to the appointment list
        /// then closes the filter page
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 4/24/2020
        /// Update: Moved filtering responsibilities to helper method
        /// and updated this method accordingly.
        /// Approver: Chuck Baxter 4/27/2020
        /// </remarks>
        private void BtnApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            if (_vetAppointments == null)
            {
                MessageBox.Show("Vet appointments list is invalid");
                return;
            }

            List<AnimalVetAppointment> appointments = FilterVetAppointments();

            if (appointments.Count == 0)
            {
                MessageBox.Show("No records match your search criteria");
                return;
            }

            dgAppointments.ItemsSource = null;
            dgAppointments.ItemsSource = appointments;
            canViewVetAppointmentFilter.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Closes the filter page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCloseFilters_Click(object sender, RoutedEventArgs e)
        {
            canViewVetAppointmentFilter.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// A double click trigger on the animal list data grid
        /// Sets the global variable _selectedAnimal to the select item
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgAnimalList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgAnimalList.SelectedItem != null)
            {
                _selectedAnimal = (Animal)dgAnimalList.SelectedItem;
                txtAnimalName.Text = _selectedAnimal.AnimalName;
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Event for when the appointment date has been changed
        /// Sets the earlier follow up date to one day after the 
        /// appointment date. Only runs when editing a record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DateAppointmentDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_editMode)
            {
                dateFollowUp.SelectedDate = null;
                cboFollowupTime.SelectedItem = null;
                dateFollowUp.DisplayDateStart = dateAppointmentDate.SelectedDate.Value.AddDays(1);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Button click event to remove a follow up
        /// date when editing a record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnClearFollowUp_Click(object sender, RoutedEventArgs e)
        {
            dateFollowUp.SelectedDate = null;
            cboFollowupTime.SelectedItem = null;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/24/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Applies a filter(s) to the appointment list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private List<AnimalVetAppointment> FilterVetAppointments()
        {
            List<AnimalVetAppointment> filteredList = _vetAppointments;

            try
            {
                filteredList =
                    _vetAppointmentManager.RetrieveVetAppointmentsByActive((bool)chkActive.IsChecked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to filter by active: " + ex.InnerException.Message);
            }

            if ((bool)chkAnimalName.IsChecked)
            {
                try
                {
                    filteredList =
                        _vetAppointmentManager.RetrieveAppointmentsByAnimalName(txtFilterName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to filter by animal name: " + ex);
                    return _vetAppointments;
                }
            }
            if ((bool)chkApptDate.IsChecked)
            {
                try
                {
                    filteredList =
                        _vetAppointmentManager.RetrieveAppointmentsByDateTime(DateTime.Parse(
                            dateFilterDate.SelectedDate.Value.ToShortDateString() +
                            " " + cboDateTime.SelectedValue));
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Invalid date entered" :
                        "Data not found: " + ex;
                    MessageBox.Show(message);
                    return _vetAppointments;
                }
            }
            if ((bool)chkFollowUp.IsChecked)
            {
                try
                {
                    filteredList =
                        _vetAppointmentManager.RetrieveAppointmentsByFollowUpDate(DateTime.Parse(
                            dateFollowUpDateFilter.SelectedDate.Value.ToShortDateString() +
                            " " + cboFollowUpTime.SelectedValue));
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Invalid date entered" :
                        "Data not found: " + ex;
                    MessageBox.Show(message);
                    return _vetAppointments;
                }
            }
            if ((bool)chkClinicAddress.IsChecked)
            {
                try
                {
                    filteredList =
                        _vetAppointmentManager.RetrieveAppointmentsByClinicAddress(txtFilterAddress.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to filter clinic address: " + ex);
                    return _vetAppointments;
                }
            }
            if ((bool)chkVetname.IsChecked)
            {
                try
                {
                    filteredList =
                        _vetAppointmentManager.RetrieveAppointmentsByVetName(txtFilterVetName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to filter vet name: " + ex);
                    return _vetAppointments;
                }
            }

            return filteredList;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/24/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Gets number of records using the selected filters
        /// If result is 0 the user can't apply a filter
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void GetFilteredResultsCount(object sender, RoutedEventArgs e)
        {
            lblFilterResultCount.Content = "Search Result Count: " + FilterVetAppointments().Count;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Enables the filter corresponding to the control
        /// that was accessed
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableFilter(object sender, object e)
        {
            switch (((Control)sender).Name)
            {
                case "txtFilterName":
                    if (txtFilterName.Text == "")
                    {
                        return;
                    }
                    chkAnimalName.IsChecked = true;
                    chkAnimalName.IsEnabled = true;
                    break;
                case "dateFilterDate":
                    if (dateFilterDate.SelectedDate == null ||
                            cboDateTime.SelectedItem == null)
                    {
                        return;
                    }
                    chkApptDate.IsChecked = true;
                    chkApptDate.IsEnabled = true;
                    GetFilteredResultsCount(null, null);
                    break;
                case "cboDateTime":
                    if (dateFilterDate.SelectedDate == null ||
                            cboDateTime.SelectedItem == null)
                    {
                        return;
                    }
                    chkApptDate.IsChecked = true;
                    chkApptDate.IsEnabled = true;
                    GetFilteredResultsCount(null, null);
                    break;
                case "dateFollowUpDateFilter":
                    if (dateFollowUpDateFilter.SelectedDate == null ||
                            cboFollowUpTime.SelectedItem == null)
                    {
                        return;
                    }
                    chkFollowUp.IsChecked = true;
                    chkFollowUp.IsEnabled = true;
                    GetFilteredResultsCount(null, null);
                    break;
                case "cboFollowUpTime":
                    if (dateFollowUpDateFilter.SelectedDate == null ||
                            cboFollowUpTime.SelectedItem == null)
                    {
                        return;
                    }
                    chkFollowUp.IsChecked = true;
                    chkFollowUp.IsEnabled = true;
                    GetFilteredResultsCount(null, null);
                    break;
                case "txtFilterAddress":
                    if (txtFilterAddress.Text == "")
                    {
                        return;
                    }
                    chkClinicAddress.IsEnabled = true;
                    chkClinicAddress.IsChecked = true;
                    break;
                case "txtFilterVetName":
                    if (txtFilterVetName.Text == "")
                    {
                        return;
                    }
                    chkVetname.IsChecked = true;
                    chkVetname.IsEnabled = true;
                    break;
                case "chkSetActive":
                    GetFilteredResultsCount(null, null);
                    break;
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Event that disables a filter when the
        /// corresponding checkbox is unchecked
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableFilter(object sender, RoutedEventArgs e)
        {
            switch (((CheckBox)sender).Name)
            {
                case "chkAnimalName":
                    chkAnimalName.IsEnabled = false;
                    chkAnimalName.IsChecked = false;
                    txtFilterName.Text = "";
                    break;
                case "chkApptDate":
                    chkApptDate.IsChecked = false;
                    chkApptDate.IsEnabled = false;
                    dateFilterDate.SelectedDate = null;
                    cboDateTime.SelectedItem = null;
                    break;
                case "chkFollowUp":
                    chkFollowUp.IsChecked = false;
                    chkFollowUp.IsEnabled = false;
                    dateFollowUpDateFilter.SelectedDate = null;
                    cboFollowUpTime.SelectedItem = null;
                    break;
                case "chkClinicAddress":
                    chkClinicAddress.IsChecked = false;
                    chkClinicAddress.IsEnabled = false;
                    txtFilterAddress.Text = "";
                    break;
                case "chkVetname":
                    chkVetname.IsChecked = false;
                    chkVetname.IsEnabled = false;
                    txtFilterVetName.Text = "";
                    break;
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Button click event to reset all filter controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnResetFilters_Click(object sender, RoutedEventArgs e)
        {
            string[] checkboxes = { "chkAnimalName", "chkApptDate", "chkFollowUp", "chkClinicAddress", "chkVetname" };
            foreach (string id in checkboxes)
            {
                CheckBox chk = new CheckBox();
                chk.Name = id;
                DisableFilter(chk, null);
            }
            chkActive.IsChecked = true;
            GetFilteredResultsCount(null, null);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/27/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Button click event to delete vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AnimalVetAppointment appointment = (AnimalVetAppointment)dgAppointments.SelectedItem;
            if (appointment == null)
            {
                return;
            }
            string message = "Are you sure you want to delete the vet appointment record for " +
                appointment.AnimalName + " on " + appointment.AppointmentDateTime.ToShortDateString() +
                "? If you're unsure please deactivate the record instead, as deletions can't be undone!";
            if (MessageBox.Show(message, "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    if (_vetAppointmentManager.RemoveAnimalVetAppointment(appointment))
                    {
                        MessageBox.Show("Record deleted!");
                        BtnClose_Click(null, null);
                        RefreshList();
                        DisableEditMode();
                    }
                    else
                    {
                        throw new ApplicationException("Delete failed");
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.InnerException == null ? ex.Message :
                        ex.Message + "\n\n" + ex.InnerException.Message;
                    MessageBox.Show(error);
                }
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Click event to switch record between active/inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void chkSetActive_Click(object sender, RoutedEventArgs e)
        {
            string message = "Are you sure you want to " +
                ((bool)chkSetActive.IsChecked ? "activate" : "deactivate") +
                " this record?";
            if (MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if ((bool)chkSetActive.IsChecked)
                {
                    try
                    {
                        if (_vetAppointmentManager.ActivateVetAppointment(
                            (AnimalVetAppointment)dgAppointments.SelectedItem))
                        {
                            MessageBox.Show("Record activated");
                            DisableEditMode();
                            PopulateFields((AnimalVetAppointment)dgAppointments.SelectedItem);
                            chkSetActive.IsChecked = true;
                        }
                        else
                        {
                            throw new ApplicationException("Record not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.InnerException == null ? ex.Message :
                            ex.Message + "\n\n" + ex.InnerException.Message;
                        MessageBox.Show(error);
                    }
                }
                else
                {
                    try
                    {
                        if (_vetAppointmentManager.DeactivateVetAppointment(
                            (AnimalVetAppointment)dgAppointments.SelectedItem))
                        {
                            MessageBox.Show("Record deactivated");
                            DisableEditMode();
                            PopulateFields((AnimalVetAppointment)dgAppointments.SelectedItem);
                            chkSetActive.IsChecked = false;
                        }
                        else
                        {
                            throw new ApplicationException("Record not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.InnerException == null ? ex.Message :
                            ex.Message + "\n\n" + ex.InnerException.Message;
                        MessageBox.Show(error);
                    }
                }
            }
            else
            {
                chkSetActive.IsChecked = !chkSetActive.IsChecked;
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 5/2/2020
        /// Approver: 
        /// 
        /// Removes unneeded columns and fixes header names
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgAppointments_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgAppointments.Columns.Remove(dgAppointments.Columns[0]);
            dgAppointments.Columns.Remove(dgAppointments.Columns[0]);
            dgAppointments.Columns.Remove(dgAppointments.Columns[1]);
            dgAppointments.Columns.Remove(dgAppointments.Columns[2]);
            dgAppointments.Columns[0].Header = "Animal Name";
            dgAppointments.Columns[1].Header = "Followup Date/Time";
            dgAppointments.Columns[2].Header = "Description";
            dgAppointments.Columns[3].Header = "Appointment Date/Time";
            dgAppointments.Columns[4].Header = "Clinic Address";
            dgAppointments.Columns[5].Header = "Vet Name";

            dgAppointments.Columns[0].Width = 120;
            dgAppointments.Columns[1].Width = 170;
            dgAppointments.Columns[2].Width = 220;
            dgAppointments.Columns[3].Width = 170;
            dgAppointments.Columns[4].Width = 300;
            dgAppointments.Columns[5].Width = 200;
        }
    }
}
