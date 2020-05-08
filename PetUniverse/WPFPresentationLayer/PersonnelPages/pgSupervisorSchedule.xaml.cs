using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for SupervisorSchedule.xaml
    /// </summary>
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/8/2020
    /// Approver: Chase Schulte
    /// 
    /// Code for the page Schedule tab.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public partial class pgSupervisorSchedule : Page
    {
        PetUniverseUser _user;
        IBaseScheduleManager _baseScheduleManager;
        IScheduleManager _scheduleManager;
        IShiftManager _shiftManager;
        IERoleManager _eRoleManager;
        IDepartmentManager _departmentManager;
        IPetUniverseUserERolesManager _universeUserERolesManager;
        IShiftTimeManager _shiftTimeManager;
        IUserManager _userManager;
        BaseScheduleVM _baseScheduleVM;
        List<ScheduleVM> _schedules;
        DateTime _startDate;




        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
        /// 
        /// No argument Constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public pgSupervisorSchedule()
        {
            InitializeComponent();
            _user = new PetUniverseUser();
            _baseScheduleManager = new BaseScheduleManager();
            _scheduleManager = new ScheduleManager();
            _shiftManager = new ShiftManager();
            _eRoleManager = new ERoleManager();
            _departmentManager = new DepartmentManager();
            _universeUserERolesManager = new PetUniverseUserERolesManager();
            _shiftTimeManager = new ShiftTimeManager();
            _userManager = new UserManager();
            _startDate = DateTime.Now;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
        /// 
        /// Constructor that takes a user argument.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public pgSupervisorSchedule(PetUniverseUser user)
        {
            InitializeComponent();
            _user = user;
            _baseScheduleManager = new BaseScheduleManager();
            _shiftTimeManager = new ShiftTimeManager();
            _scheduleManager = new ScheduleManager();
            _departmentManager = new DepartmentManager();
            _eRoleManager = new ERoleManager();
            _universeUserERolesManager = new PetUniverseUserERolesManager();
            _shiftManager = new ShiftManager();
            _userManager = new UserManager();
            _startDate = DateTime.Now;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
        /// 
        /// Gets the list of schedules from the data store.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private List<String> getSchedules()
        {
            List<string> scheduleDates = new List<string>();
            try
            {
                foreach (var item in _scheduleManager.RetrieveAllSchedules())
                {
                    scheduleDates.Add(item.ScheduleID + " " + item.StartDate.ToShortDateString() + " " + item.EndDate.ToShortDateString());
                }

            }
            catch (Exception)
            {
                WPFErrorHandler.ErrorMessage("Failed to find schedules.");
            }
            return scheduleDates;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method to set the datagrid based on filters
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void setDataGrid()
        {
            List<ShiftUserVM> shiftVMs = new List<ShiftUserVM>();
            List<string> assignedRoles = _universeUserERolesManager.RetrievePetUniverseUserERolesByPetUniverseUser(_user.PUUserID).FindAll(pu => pu.Contains("Supervisor"));
            List<string> departments = new List<string>();
            foreach (var item in assignedRoles)
            {
                departments.Add(_eRoleManager.RetrieveAllERoles().Find(er => er.ERoleID == item).DepartmentID);
            }
            if (cboDate.SelectedItem == null || cboDate.SelectedItem == "All Dates")
            {
                foreach (var department in departments)
                {
                    shiftVMs.AddRange(_shiftManager.RetrieveShiftsByScheduleAndDepartmentID(Convert.ToInt32(cboDateRange.SelectedItem.ToString().Substring(0, 7)), department));
                }
            }
            else
            {
                foreach (var department in departments)
                {
                    shiftVMs.AddRange(_shiftManager.RetrieveShiftsByScheduleAndDepartmentIDWithDate(Convert.ToInt32(cboDateRange.SelectedItem.ToString().Substring(0, 7)), department, Convert.ToDateTime(cboDate.SelectedItem)));
                }
            }
            //Remove current user's records
            for (int i = 0; i < shiftVMs.Count; i++)
            {
                if (shiftVMs.ElementAt(i).EmployeeID == _user.PUUserID)
                {
                    shiftVMs.RemoveAt(i);
                }

            }
            dgSchedule.ItemsSource = shiftVMs;

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: 
        /// 
        /// Gets the current base schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void getBaseSchedule()
        {
            try
            {
                _baseScheduleVM = _baseScheduleManager.GetActiveBaseSchedule();
                if (_baseScheduleVM == null)
                {
                    throw new ApplicationException("No base schedule stored. Please set one.");
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Data not found. " + ex.Message);
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        ///  Method to get a start date.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private DateTime getStartDate()
        {
            DateTime startDate = DateTime.Now.Date;
            if (_schedules != null && _schedules.Count > 0)
            {
                var latest = _schedules.Where(s =>
                s.EndDate == _schedules.Max(m => m.EndDate)).FirstOrDefault();
                startDate = latest.EndDate.AddDays(1);
            }
            else
            {
                DialogResult dialogResult;
                do
                {
                    // A window to force this method to wait for a user response.
                    frmGetStartDate getStartDate = new frmGetStartDate();

                    // This ties a lambda expression to an event in the window
                    getStartDate.setDate += value => startDate = value;
                    bool? result = getStartDate.ShowDialog();
                    dialogResult = DialogResult.No;
                    if (result == false)
                    {
                        dialogResult = System.Windows.Forms.MessageBox.Show("Start date will be set to today." +
                            " Would you like to choose a different start date?", "Date not set", MessageBoxButtons.YesNoCancel);
                        startDate = DateTime.Now.Date;
                    }
                } while (dialogResult.Equals(DialogResult.Yes));

                if (dialogResult == DialogResult.Cancel)
                {
                    throw new ApplicationException("New schedule generation cancelled.");
                }
            }
            return startDate;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method when combo box is opened
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboDateRange_DropDownOpened(object sender, EventArgs e)
        {
            cboDateRange.ItemsSource = getSchedules();
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method when panel closes on drop down
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboDateRange_DropDownClosed(object sender, EventArgs e)
        {
            cboDate.SelectedItem = null;
            cboDate.IsEnabled = false;

            if (cboDateRange.SelectedItem != null)
            {
                //Populate date with all the dates in between schedule
                List<string> allDates = new List<string>();
                var scheduleDetails = _scheduleManager.RetrieveAllSchedules().Find(sc => sc.ScheduleID == Convert.ToInt32(cboDateRange.SelectedItem.ToString().Substring(0, 7)));
                DateTime startingDate = scheduleDetails.StartDate;
                DateTime endingDate = scheduleDetails.EndDate;
                int starting = startingDate.Day;
                int ending = endingDate.Day;

                allDates.Add("All Dates");
                for (DateTime date = startingDate; date <= endingDate; date = date.AddDays(1))
                    allDates.Add(date.ToShortDateString());

                cboDate.IsEnabled = true;
                cboDate.ItemsSource = allDates;
                cboDate.SelectedIndex = 0;
                setDataGrid();
                return;
            }
            cboDate.ItemsSource = null;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method for naming and removing columns
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgSchedule_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns[0].Header = "Date";
            dgSchedule.Columns[1].Header = "Employee Name";
            dgSchedule.Columns[2].Header = "Start";
            dgSchedule.Columns[3].Header = "End";
            dgSchedule.Columns[4].Header = "Role";

        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method when panel closes on drop down
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboDate_DropDownClosed(object sender, EventArgs e)
        {
            setDataGrid();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 4/28/2020
        /// Approver: Chase Schulte
        /// 
        /// On click of the Edit Scheduled Employee button
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditShiftEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selectedShift = (ShiftUserVM)dgSchedule.SelectedItem;

            if (dgSchedule.SelectedItem != null)
            {
                if (!(selectedShift.EmployeeName.Equals(_user.FirstName + " " + _user.LastName)))
                {
                    List<PetUniverseUser> replacementUsers;

                    try
                    {
                        replacementUsers = _userManager.RetrieveUsersAbleToWork(
                            Convert.ToDateTime(selectedShift.DateString),
                            (Convert.ToDateTime(selectedShift.DateString)).ToString("dddd"),
                            Convert.ToDateTime(selectedShift.ShiftStart),
                            Convert.ToDateTime(selectedShift.ShiftEnd),
                            selectedShift.RoleID);
                    }
                    catch (Exception ex)
                    {
                        replacementUsers = new List<PetUniverseUser>();
                        WPFErrorHandler.ErrorMessage(ex.Message);
                    }

                    //Open EditShiftEmployee window
                    frmEditShiftEmployee confirm = new frmEditShiftEmployee(selectedShift, replacementUsers);

                    if ((bool)confirm.ShowDialog())
                    {
                        setDataGrid();
                    }
                }
                else
                {
                    WPFErrorHandler.ErrorMessage("Cannot edit your own Shifts!", "Selection");
                }
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please make a selection first!", "Selection");
            }
        }
    }
}
