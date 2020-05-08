using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/07/2019
    /// Approver: Alex Diers
    /// 
    /// Interaction logic for frameShiftTime.xaml
    /// </summary>
    public partial class frameShiftTime : Page
    {
        private IShiftTimeManager _shiftTimeManager = null;
        private IDepartmentManager _departmentManager = null;
        private PetUniverseShiftTime _shiftTime = null;

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// No arg-constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public frameShiftTime()
        {
            InitializeComponent();
            _shiftTimeManager = new ShiftTimeManager();
            _departmentManager = new DepartmentManager();
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Passes shiftTimeManager Interface
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public frameShiftTime(IShiftTimeManager shiftTimeManager)
        {
            InitializeComponent();
            _departmentManager = new DepartmentManager();
            _shiftTimeManager = shiftTimeManager;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Passes shiftTimeManager and shiftTimeManager Interface
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public frameShiftTime(PetUniverseShiftTime shiftTime, IShiftTimeManager shiftTimeManager)
        {
            _shiftTime = shiftTime;
            _shiftTimeManager = shiftTimeManager;
            _departmentManager = new DepartmentManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// cancels opperations in the current window
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        private void btnShiftTimeCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetControls();
            btnShiftTimeSave.IsEnabled = false;
            
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// logic or what happens when the window loads
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateShiftTimes();
            PopulateDepartments();
            cboShiftTimeDepartment.IsEnabled = false;
            TPStartTime.IsEnabled = false;
            TPEndTime.IsEnabled = false;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Helper method for populating the Departments Drop Down
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void PopulateDepartments()
        {
            cboShiftTimeDepartment.Items.Clear();
            List<Department> departments = new List<Department>();
            try
            {
                departments = _departmentManager.RetrieveAllDepartments();
                foreach (Department department in departments)
                {
                    cboShiftTimeDepartment.Items.Add(department.DepartmentID);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
            }



        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Helper method for populating the ShiftTime DG
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void PopulateShiftTimes()
        {

            try
            {
                dgShiftTime.ItemsSource = _shiftTimeManager.RetrieveShiftTimes();
                dgShiftTime.Columns[0].Header = "DepartmentID";
                dgShiftTime.Columns[1].Header = "StartTime";
                dgShiftTime.Columns[2].Header = "EndTime";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
            }


        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Helper method for reseting the controls of the page after certain events
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void ResetControls()
        {
            PopulateShiftTimes();
            PopulateDepartments();
            cboShiftTimeDepartment.IsEnabled = false;
            TPStartTime.Value = DateTime.Parse("00:00:00");
            TPEndTime.Value = DateTime.Parse("00:00:00");
            btnShiftTimeCancel.IsEnabled = false;
            TPStartTime.IsReadOnly = true;
            TPEndTime.IsReadOnly = true;
            btnShiftTimeAdd.IsEnabled = true;
            btnShiftTimeEdit.IsEnabled = true;
            btnShiftTimeSave.IsEnabled = false;
            btnShiftTimeDelete.IsEnabled = true;
            dgShiftTime.IsReadOnly = true;
            
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// click handler for the save button
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnShiftTimeSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime startTime = (DateTime)TPStartTime.Value;
            DateTime endTime = (DateTime)TPEndTime.Value;
            MessageBoxResult result = MessageBox.Show("Are You Sure?", "Pet Universe", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (cboShiftTimeDepartment.Text.ToString() == "" || cboShiftTimeDepartment.Text.ToString() == null)
                    {
                        MessageBox.Show("Please Select a Department.");
                        return;
                    }
                    if (TPStartTime.Text.ToString() == "" || TPStartTime.Text.ToString() == null)
                    {
                        MessageBox.Show("Please Select a Shift Start Time.");
                        TPStartTime.Focus();
                        return;
                    }
                    if (TPEndTime.Text.ToString() == "" || TPEndTime.Text.ToString() == null)
                    {
                        MessageBox.Show("Please Select a Shift End Time.");
                        TPEndTime.Focus();
                        return;
                    }
                    if (TPStartTime.Text.ToString() == TPEndTime.Text.ToString())
                    {
                        MessageBox.Show("Shifts must be at least 1Hour.");
                        TPStartTime.Focus();
                        return;
                    }
                    if (endTime < startTime.AddHours(1))
                    {
                        MessageBox.Show("Shifts must be at least 1Hour.");
                        TPStartTime.Focus();
                        return;
                    }


                    PetUniverseShiftTime shiftTime = new PetUniverseShiftTime()
                    {
                        DepartmentID = cboShiftTimeDepartment.Text.ToString(),
                        StartTime = TPStartTime.Text.ToString(),
                        EndTime = TPEndTime.Text.ToString()
                    };
                    if (btnShiftTimeEdit.IsEnabled == false)
                    {
                        try
                        {
                            if (_shiftTimeManager.AddShiftTime(shiftTime))
                            {

                                PopulateShiftTimes();
                                ResetControls();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (_shiftTimeManager.EditShiftTime(_shiftTime = (PetUniverseShiftTime)dgShiftTime.SelectedItem, shiftTime))
                            {
                                PopulateShiftTimes();
                                ResetControls();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
                        }
                    }

                    PopulateShiftTimes();
                    ResetControls();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Okay", "PetUniverse");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Canceled.", "PetUniverse");
                    break;
            }
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// click handler for the add
        /// button
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnShiftTimeAdd_Click(object sender, RoutedEventArgs e)
        {
            btnShiftTimeSave.IsEnabled = true;
            btnShiftTimeEdit.IsEnabled = false;
            btnShiftTimeCancel.IsEnabled = true;
            btnShiftTimeDelete.IsEnabled = false;
            TPStartTime.IsReadOnly = false;
            TPEndTime.IsReadOnly = false;
            TPStartTime.IsEnabled = true;
            TPEndTime.IsEnabled = true;
            cboShiftTimeDepartment.IsEnabled = true;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// auto generated columns handler to get rid of the ShiftTimeID field on DGShiftTime
        /// button
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void dgShiftTime_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgShiftTime.Columns.RemoveAt(4);
            dgShiftTime.Columns.RemoveAt(0);

        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// click handler for the edit
        /// button
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: 5/6/2020
        /// Update: Disabled cboShiftTimeDepartment
        /// 
        /// </remarks>
        private void btnShiftTimeEdit_Click(object sender, RoutedEventArgs e)
        {

            string time = null;

            PetUniverseShiftTime shiftTime = (PetUniverseShiftTime)dgShiftTime.SelectedItem;

            if (shiftTime != null)
            {
                this.btnShiftTimeDelete.Visibility = Visibility.Visible;
                dgShiftTime.Focus();

                btnShiftTimeSave.IsEnabled = true;
                btnShiftTimeAdd.IsEnabled = false;
                btnShiftTimeDelete.IsEnabled = false;
                btnShiftTimeCancel.IsEnabled = true;
                cboShiftTimeDepartment.IsEnabled = false;
                TPStartTime.IsReadOnly = false;
                TPEndTime.IsReadOnly = false;
                TPStartTime.IsEnabled = true;
                TPEndTime.IsEnabled = true;
                var ShiftTimeForm = new frameShiftTime(shiftTime, _shiftTimeManager);

                cboShiftTimeDepartment.SelectedItem = shiftTime.DepartmentID;

                time = shiftTime.StartTime;
                DateTime dateTime = ParseDatetime(time);
                TPStartTime.Value = dateTime;

                time = shiftTime.EndTime;
                dateTime = ParseDatetime(time);
                TPEndTime.Value = dateTime;
            }
            else { MessageBox.Show("you must select a ShiftTime to edit!"); }
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// helper method for getting shiftTimes from string to date time to be displayed in time pickers
        /// button
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private static DateTime ParseDatetime(string time)
        {
            return DateTime.ParseExact(time, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
        }



        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/05/2019
        /// Approver: Kaleb Bachert
        ///
        /// logic for the delete button press. to delete a record
        ///
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnShiftTimeDelete_Click(object sender, RoutedEventArgs e)
        {
            PetUniverseShiftTime shiftTime = (PetUniverseShiftTime)dgShiftTime.SelectedItem;

            if (shiftTime != null)
            {
                var deleteERole = MessageBox.Show("Are you sure you want to deactivate " + shiftTime.ShiftTimeID, "Confirm Deactivate", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (deleteERole == MessageBoxResult.Yes)
                {
                    try
                    {
                        _shiftTimeManager.DeactivateShiftTime(shiftTime.ShiftTimeID);
                        PopulateShiftTimes();
                        ResetControls();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                    }
                }
            }
            else { MessageBox.Show("you must select a ShiftTime to Deactivate!"); }
        }
    }
}
