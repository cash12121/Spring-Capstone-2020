using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/21/2020
    /// Approver: Zach Behrensmeyer
    /// Approver: 
    /// 
    /// A page to perform animal prescription CRUD functions
    /// </summary>
    public partial class VetPrescriptionControls : Page
    {
        private IAnimalPrescriptionManager _animalPrescriptionManager;
        private IVetAppointmentManager _vetAppointmentManager;
        private AnimalVetAppointment _selectedAppointment;
        private bool editMode = false;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Default constructor. Initializes the prescription manager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public VetPrescriptionControls()
        {
            InitializeComponent();
            _animalPrescriptionManager = new AnimalPrescriptionsManager();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Closes the prescription creation page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            canViewPrescription.Visibility = Visibility.Hidden;
            canView.Visibility = Visibility.Visible;
            ResetFields();
            DisableAddMode();
            if (editMode)
            {
                editMode = false;
                DisableEditMode();
            }
            RefreshPrescriptionsList((bool)chkShowActive.IsChecked);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Save button click event. Saves a new animal 
        /// prescription record
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 3/15/2020
        /// Update: Added edit functionality
        /// </remarks>
        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSaveEdit.Content.Equals("Save"))
            {
                if (_selectedAppointment == null &&
                    editMode == false)
                {
                    MessageBox.Show("Please select a corresponding vet appointment " +
                        "by double clicking a record on the right");
                    return;
                }
                if (txtPrescriptionName.Text == "")
                {
                    MessageBox.Show("Prescription name can't be blank!");
                    return;
                }
                if (txtDosage.Text == "")
                {
                    MessageBox.Show("Dosage can't be blank");
                    return;
                }
                try
                {
                    Decimal.Parse(txtDosage.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid dosage entered. Please enter a number");
                    return;
                }
                if (txtInterval.Text == "")
                {
                    MessageBox.Show("Interval can't be blank");
                    return;
                }
                if (txtAdministrationMethod.Text == "")
                {
                    MessageBox.Show("Administration method can't be blank");
                    return;
                }
                if (dateStartDate.SelectedDate == null)
                {
                    MessageBox.Show("Please select a start date");
                    return;
                }
                if (dateEndDate.SelectedDate == null)
                {
                    MessageBox.Show("Please select an end date");
                    return;
                }

                AnimalPrescriptionVM animalPrescription = new AnimalPrescriptionVM()
                {
                    AnimalID = editMode == true ? ((AnimalPrescription)dgPrescriptions.SelectedItem).AnimalID
                    : _selectedAppointment.AnimalID,
                    AnimalVetAppointmentID = editMode == true ? ((AnimalPrescription)dgPrescriptions.SelectedItem)
                    .AnimalVetAppointmentID : _selectedAppointment.VetAppointmentID,
                    PrescriptionName = txtPrescriptionName.Text,
                    Dosage = Decimal.Parse(txtDosage.Text),
                    Interval = txtInterval.Text,
                    AdministrationMethod = txtAdministrationMethod.Text,
                    StartDate = (DateTime)dateStartDate.SelectedDate,
                    EndDate = (DateTime)dateEndDate.SelectedDate,
                    Description = txtDescription.Text
                };
                if (editMode)
                {
                    try
                    {
                        if (_animalPrescriptionManager.EditAnimalPrescriptionRecord(
                            (AnimalPrescriptionVM)dgPrescriptions.SelectedItem, animalPrescription))
                        {
                            MessageBox.Show("Record updated!");
                            DisableEditMode();
                            RefreshPrescriptionsList();
                            canViewPrescription.Visibility = Visibility.Hidden;
                            canView.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            throw new ApplicationException();
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex == null ? "Record failed to update" : ex.Message + " " + ex.InnerException;
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    try
                    {
                        if (_animalPrescriptionManager.AddAnimalPrescriptionRecord(animalPrescription))
                        {
                            MessageBox.Show("Record added!");
                            DisableAddMode();
                            RefreshPrescriptionsList();
                            canViewPrescription.Visibility = Visibility.Hidden;
                            canView.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            throw new ApplicationException();
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex == null ? "Record not added" : ex.Message + " " + ex.InnerException;
                        MessageBox.Show(message);
                    }
                }
            }
            else
            {
                EnableEditMode();
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets the _selectedAppointment to the selected record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgAppointmentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgAppointmentList.SelectedItem != null)
            {
                _selectedAppointment = (AnimalVetAppointment)dgAppointmentList.SelectedItem;
                txtAnimal.Text = _selectedAppointment.AnimalName;
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Opens the prescription creation page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            canViewPrescription.Visibility = Visibility.Visible;
            canView.Visibility = Visibility.Hidden;
            _vetAppointmentManager = new VetAppointmentManager();
            try
            {
                dgAppointmentList.ItemsSource = _vetAppointmentManager.RetrieveVetAppointmentsByActive(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + " " + ex.InnerException.Message);
            }
            EnableAddMode();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: 
        /// 
        /// Opens the prescription detail page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dgPrescriptions.SelectedItem == null)
            {
                return;
            }
            PopulateFields((AnimalPrescriptionVM)dgPrescriptions.SelectedItem);
            canViewPrescription.Visibility = Visibility.Visible;
            canView.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Event to retrieve the prescription list when
        /// the data grid is loaded
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgPrescriptions_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshPrescriptionsList((bool)chkShowActive.IsChecked);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Refreshes the list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshPrescriptionsList(bool active = true)
        {
            dgPrescriptions.ItemsSource = null;
            try
            {
                dgPrescriptions.ItemsSource =
                    _animalPrescriptionManager.RetrieveAnimalPrescriptionsByActive(active);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Prepares the form controls for
        /// adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableAddMode()
        {
            txtPrescriptionName.IsEnabled = true;
            txtDosage.IsEnabled = true;
            txtInterval.IsEnabled = true;
            dateStartDate.IsEnabled = true;
            dateEndDate.IsEnabled = true;
            txtAdministrationMethod.IsEnabled = true;
            txtDescription.IsEnabled = true;
            txtAnimalName.Visibility = Visibility.Visible;
            dgAppointmentList.Visibility = Visibility.Visible;
            lblSearchAnimal.Visibility = Visibility.Visible;
            btnSaveEdit.Content = "Save";
            dateStartDate.DisplayDateStart = DateTime.Now;
            dateEndDate.DisplayDateStart = DateTime.Now.AddDays(1);
            chkActive.IsChecked = true;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Sets the form controls to their default state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableAddMode()
        {
            ResetFields();
            txtPrescriptionName.IsEnabled = false;
            txtDosage.IsEnabled = false;
            txtInterval.IsEnabled = false;
            dateStartDate.IsEnabled = false;
            dateEndDate.IsEnabled = false;
            txtAdministrationMethod.IsEnabled = false;
            txtDescription.IsEnabled = false;
            dgAppointmentList.Visibility = Visibility.Hidden;
            lblSearchAnimal.Visibility = Visibility.Hidden;
            txtAnimalName.Visibility = Visibility.Hidden;
            btnSaveEdit.Content = "Edit";
            dgAppointmentList.ItemsSource = null;
            _selectedAppointment = null;
            chkActive.IsChecked = false;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Prepares form controls for editing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableEditMode()
        {
            editMode = true;
            txtPrescriptionName.IsEnabled = true;
            txtDosage.IsEnabled = true;
            txtInterval.IsEnabled = true;
            dateStartDate.IsEnabled = true;
            dateEndDate.IsEnabled = true;
            txtAdministrationMethod.IsEnabled = true;
            txtDescription.IsEnabled = true;
            btnSaveEdit.Content = "Save";
            btnDelete.Visibility = Visibility.Visible;
            chkActive.IsEnabled = true;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Sets the form controls to their default state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableEditMode()
        {
            editMode = false;
            txtPrescriptionName.IsEnabled = false;
            txtDosage.IsEnabled = false;
            txtInterval.IsEnabled = false;
            dateStartDate.IsEnabled = false;
            dateEndDate.IsEnabled = false;
            txtAdministrationMethod.IsEnabled = false;
            txtDescription.IsEnabled = false;
            btnSaveEdit.Content = "Edit";
            btnDelete.Visibility = Visibility.Hidden;
            chkActive.IsEnabled = false;
            ResetFields();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Populates the form controls when
        /// a record is opened
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PopulateFields(AnimalPrescriptionVM animalPrescription)
        {
            txtPrescriptionName.Text = animalPrescription.PrescriptionName;
            txtDosage.Text = animalPrescription.Dosage.ToString();
            txtInterval.Text = animalPrescription.Interval;
            dateStartDate.SelectedDate = animalPrescription.StartDate;
            dateEndDate.SelectedDate = animalPrescription.EndDate;
            txtAdministrationMethod.Text = animalPrescription.AdministrationMethod;
            txtDescription.Text = animalPrescription.Description;
            txtAnimal.Text = animalPrescription.AnimalName;
            chkActive.IsChecked = animalPrescription.Active;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Resets form controls to default values
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ResetFields()
        {
            txtPrescriptionName.Text = "";
            txtDosage.Text = "";
            txtInterval.Text = "";
            dateStartDate.SelectedDate = null;
            dateEndDate.SelectedDate = null;
            txtAdministrationMethod.Text = "";
            txtDescription.Text = "";
            txtAnimal.Text = "";
            chkActive.IsChecked = false;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Event that triggers when the StartDate is changed
        /// Updates the EndDate date picker to only allow for dates
        /// after the StartDate value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DateStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (btnSaveEdit.Content.ToString() == "Save" &&
                dateStartDate.SelectedDate != null)
            {
                dateEndDate.SelectedDate = null;
                dateEndDate.DisplayDateStart = dateStartDate.SelectedDate.Value.AddDays(1);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Button click event to search for records
        /// by animal name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (btnSearch.Content.Equals("Search"))
            {
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Search field is blank!");
                    return;
                }
                try
                {
                    dgPrescriptions.ItemsSource = null;
                    dgPrescriptions.ItemsSource =
                        _animalPrescriptionManager.RetrievePrescriptionsByAnimalName(txtSearch.Text);
                    btnSearch.Content = "Reset";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
                }
            }
            else
            {
                RefreshPrescriptionsList();
                btnSearch.Content = "Search";
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Clear the search field when selected
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void TxtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Event that formats the data grid when it is
        /// populated with records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgPrescriptions_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgPrescriptions.Columns.RemoveAt(8);
            dgPrescriptions.Columns.RemoveAt(9);
            dgPrescriptions.Columns.RemoveAt(9);
            dgPrescriptions.Columns[0].Header = "Animal Name";
            dgPrescriptions.Columns[1].Header = "Prescription Name";
            dgPrescriptions.Columns[4].Header = "Administration Method";
            dgPrescriptions.Columns[5].Header = "Start Date";
            dgPrescriptions.Columns[6].Header = "End Date";

            dgPrescriptions.Columns[0].Width = 120;
            dgPrescriptions.Columns[1].Width = 150;
            dgPrescriptions.Columns[2].Width = 50;
            dgPrescriptions.Columns[3].Width = 100;
            dgPrescriptions.Columns[4].Width = 200;
            dgPrescriptions.Columns[5].Width = 150;
            dgPrescriptions.Columns[6].Width = 150;
            dgPrescriptions.Columns[7].Width = 200;
            dgPrescriptions.Columns[8].Width = 70;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Event that formats the appoointment data grid when it is
        /// populated with records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgAppointmentList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgAppointmentList.Columns.RemoveAt(0);
            dgAppointmentList.Columns.RemoveAt(0);
            dgAppointmentList.Columns.RemoveAt(1);
            dgAppointmentList.Columns.RemoveAt(2);
            dgAppointmentList.Columns.RemoveAt(4);
            dgAppointmentList.Columns.RemoveAt(4);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Clears the default text from the animal name
        /// text box when the user selects it
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void TxtAnimalName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAnimalName.Text.Equals("Animal Name"))
            {
                txtAnimalName.Text = "";
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Searches for vet appointments by animal name
        /// as the user is typing it. Only begins searching
        /// when the character count is greater than two. Resets
        /// to the default list when the textbox is empty
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void TxtAnimalName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAnimalName.Text.Length < 3 &&
                txtAnimalName.Text.Length > 0 ||
                txtAnimalName.Text == "Animal Name")
            {
                return;
            }
            dgAppointmentList.ItemsSource = null;
            try
            {
                if (txtAnimalName.Text.Equals(""))
                {
                    dgAppointmentList.ItemsSource = _vetAppointmentManager.RetrieveVetAppointmentsByActive(true);
                }
                else
                {
                    dgAppointmentList.ItemsSource = _vetAppointmentManager.RetrieveAppointmentsByPartialAnimalName(
                        txtAnimalName.Text);
                }
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Click event for deleting a prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AnimalPrescriptionVM animalPrescription = (AnimalPrescriptionVM)dgPrescriptions.SelectedItem;
            if (animalPrescription == null)
            {
                return;
            }
            string message = "Are you sure you want to delete the " + animalPrescription.PrescriptionName +
                " record for " + animalPrescription.AnimalName + "? Please deactivate the record instead " +
                "unless you're sure you want to delete!";
            if (MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    if (_animalPrescriptionManager.DeleteAnimalPrescriptionRecord(animalPrescription))
                    {
                        MessageBox.Show("Record deleted");
                        DisableEditMode();
                        RefreshPrescriptionsList();
                        canViewPrescription.Visibility = Visibility.Hidden;
                        canView.Visibility = Visibility.Visible;
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
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Checkbox click event for handling
        /// activating and deactivating prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void chkActive_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chkActive.IsChecked)
            {
                if (MessageBox.Show("Are you sure you want to activate this record?", "Activate record",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        if (_animalPrescriptionManager.ActivateAnimalPrescriptionRecord(
                            (AnimalPrescription)dgPrescriptions.SelectedItem))
                        {
                            MessageBox.Show("Record activated!");
                            DisableEditMode();
                            PopulateFields((AnimalPrescriptionVM)dgPrescriptions.SelectedItem);
                            chkActive.IsChecked = true;
                        }
                        else
                        {
                            throw new ApplicationException("Record not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        chkActive.IsChecked = false;
                    }
                }
                else
                {
                    chkActive.IsChecked = false;
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to deactivate this record?", "Deactivate record",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        if (_animalPrescriptionManager.DeactivateAnimalPrescriptionRecord(
                            (AnimalPrescription)dgPrescriptions.SelectedItem))
                        {
                            MessageBox.Show("Record deactivated!");
                            DisableEditMode();
                            PopulateFields((AnimalPrescriptionVM)dgPrescriptions.SelectedItem);
                            chkActive.IsChecked = false;
                        }
                        else
                        {
                            throw new ApplicationException("Record not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        chkActive.IsChecked = true;
                    }
                }
                else
                {
                    chkActive.IsChecked = true;
                }
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/26/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Checkbox click event for switching
        /// between active/inactive records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void chkShowActive_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chkShowActive.IsChecked)
            {
                RefreshPrescriptionsList(true);
            }
            else
            {
                RefreshPrescriptionsList(false);
            }
        }
    }
}
