using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Creator: Jordan Lindo
    /// Created: 4/8/2020
    /// Approver: 
    /// 
    /// Code for the page Schedule tab.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public partial class Schedule : Page
    {
        PetUniverseUser _user;
        IBaseScheduleManager _baseScheduleManager;
        IScheduleManager _scheduleManager;
        BaseScheduleVM _baseScheduleVM;
        List<ScheduleVM> _schedules;
        DateTime _startDate;
        List<string> _dateRanges;




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
        public Schedule()
        {
            InitializeComponent();
            _user = new PetUniverseUser();
            _baseScheduleManager = new BaseScheduleManager();
            _scheduleManager = new ScheduleManager();
            _startDate = DateTime.Now;
            getSchedules(true);
            setCboDateRange();
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
        public Schedule(PetUniverseUser user)
        {
            InitializeComponent();
            _user = user;
            _baseScheduleManager = new BaseScheduleManager();
            _scheduleManager = new ScheduleManager();
            _startDate = DateTime.Now;
            getSchedules(true);
            setCboDateRange();
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
        private void getSchedules(bool isLoad = false)
        {
            try
            {
                _schedules = _scheduleManager.RetrieveAllSchedules();
                if(_schedules.Count == 0)
                {
                    _schedules = null;
                }
            }
            catch (Exception)
            {
                if (!isLoad)
                {
                    WPFErrorHandler.ErrorMessage("Failed to find schedules.");
                }
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
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
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
        /// 
        /// Generates a new schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void btnNewSchedule_Click(object sender, RoutedEventArgs e)
        {
            getBaseSchedule();
            if (_baseScheduleVM != null)
            {
                try
                {
                    DateTime startDate = getStartDate();
                    ScheduleVM vM = _scheduleManager.GenerateSchedule(startDate, _baseScheduleVM.BaseScheduleLines);
                    frmConfirmNewSchedule confirm = new frmConfirmNewSchedule(_user, vM);
                    if ((bool)confirm.ShowDialog())
                    {
                        vM.ScheduleID = _scheduleManager.AddSchedule(vM);
                        _scheduleManager.AddScheduledHours(vM.ScheduleID);
                        getSchedules();
                        setCboDateRange();
                    }
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message);
                }
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
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method that attempt to get schedules when combobox has focus.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDateRange_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_schedules == null)
            {
                getSchedules();
                setCboDateRange();
            }
            if(_schedules == null || _schedules.Count == 0)
            {
                WPFErrorHandler.ErrorMessage("No schedules found.");
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Method for filling cboDateRange.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void setCboDateRange()
        {
            if (_schedules != null && _schedules.Count > 0)
            {
                _dateRanges = new List<string>();
                for (int i = 0; i < _schedules.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(_schedules[i].StartDate.ToShortDateString());
                    sb.Append(" - ");
                    sb.Append(_schedules[i].EndDate.ToShortDateString());
                    _dateRanges.Add(sb.ToString());
                }
                cboDateRange.ItemsSource = _dateRanges;
                if (_dateRanges.Count > 0)
                {
                    cboDateRange.SelectedIndex = 0;
                }

            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Method for filling dgSchedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void cboDateRange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<ShiftUserVM> lines = _schedules[cboDateRange.SelectedIndex].ScheduleLines;
            foreach (var line in lines)
            {
                line.DateString = line.ShiftDate.ToShortDateString();
            }
            dgSchedule.ItemsSource = lines;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/27/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Method for adjusting the dgSchedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void dgSchedule_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns.RemoveAt(4);
            dgSchedule.Columns[0].Header = "Date";
            dgSchedule.Columns[1].Header = "Employee Name";
            dgSchedule.Columns[2].Header = "Shift Start Time";
            dgSchedule.Columns[3].Header = "Shift End Time";
            dgSchedule.Columns[4].Header = "Role";

        }
    }
}
