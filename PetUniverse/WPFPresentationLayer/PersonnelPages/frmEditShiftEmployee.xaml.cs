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
using System.Windows.Shapes;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Creator: Kaleb Bachert
    /// Created: 4/28/2020
    /// Approver: 
    /// 
    /// Code for the EditShiftEmployee Window
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public partial class frmEditShiftEmployee : Window
    {
        private ShiftUserVM _shiftVm;
        private List<PetUniverseUser> _replacementUsers;
        private IShiftManager _shiftManager;
        private IUserManager _userManager;

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 4/28/2020
        /// Approver:
        /// 
        /// Constructor, initializes values that you will see
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public frmEditShiftEmployee(ShiftUserVM shiftVm, List<PetUniverseUser> replacementUsers)
        {
            _shiftVm = shiftVm;
            _replacementUsers = replacementUsers;
            _shiftManager = new ShiftManager();
            _userManager = new UserManager();

            InitializeComponent();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 4/28/2020
        /// Approver:
        /// 
        /// Sets all the on screen text for this window
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtShiftEmployeeWorking.Text = _shiftVm.EmployeeName;
            txtShiftDate.Text = _shiftVm.DateString;
            txtShiftStartTime.Text = _shiftVm.ShiftStart;
            txtShiftEndTime.Text = _shiftVm.ShiftEnd;
            txtShiftRole.Text = _shiftVm.RoleID;

            //Sets the list of Users who can take the shift, clearing it first, and setting the default value
            cmbShiftReplacementEmployees.Items.Clear();
            cmbShiftReplacementEmployees.Items.Add("-- Select a Replacement --");

            foreach (PetUniverseUser user in _replacementUsers)
            {
                cmbShiftReplacementEmployees.Items.Add(user.Email);
            }

            cmbShiftReplacementEmployees.SelectedItem = "-- Select a Replacement --";
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 4/28/2020
        /// Approver:
        /// 
        /// Closes the Window on click of the Cancel Button
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creator: Kaleb Bachert
        /// Created: 4/28/2020
        /// Approver:
        /// 
        /// Updates the Shift in the Database if a User was Selected
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //No Replacement Employee is selected
            if (cmbShiftReplacementEmployees.SelectedItem.Equals("-- Select a Replacement --"))
            {
                WPFErrorHandler.ErrorMessage("You must first select a replacement Employee. If no replacement Employees appear, none fit the criteria for replacement.", "Input");
            }
            //Replacement Employee is selected
            else
            {
                //The date, startTime and endTime of the shift, and the length of the shift in hours
                DateTime shiftDate = Convert.ToDateTime(txtShiftDate.Text);
                TimeSpan startTime = TimeSpan.Parse(txtShiftStartTime.Text);
                TimeSpan endTime = TimeSpan.Parse(txtShiftEndTime.Text);
                double shiftHours;

                //If the shift stays in a single day
                if (endTime > startTime)
                {
                    shiftHours = (endTime - startTime).TotalHours;
                }
                //The Shift starts the previous night, and ends in the morning
                else
                {
                    //Last second of the night
                    TimeSpan dayEnd = new TimeSpan(23, 59, 59);
                    //First second of the morning
                    TimeSpan dayStart = new TimeSpan(0, 0, 0);

                    //Get difference between end of shift and start of day, add it to difference between start of shift and end of night
                    shiftHours = (endTime - dayStart).TotalHours + (dayEnd - startTime).TotalHours;
                }

                try
                {
                    //Converts selected Email (replacement User) to a PetUniverseUser
                    PetUniverseUser replacementUser = _userManager.getUserByEmail(cmbShiftReplacementEmployees.SelectedItem.ToString());

                    //Gets the start and end date of the schedule the shift is in, used to determine the hours worked that week
                    ScheduleWithHoursWorked scheduleContainingTheShift = _shiftManager.RetrieveScheduleHoursByUserAndDate(replacementUser.PUUserID, shiftDate);

                    //This will be the hours worked if the Shift change is confirmed
                    double projectedHoursWorked;

                    //The week of the schedule that this shift is in, 1 or 2
                    int weekNumber;

                    //If shiftDate is before the second Sunday of the Schedule
                    if (shiftDate < scheduleContainingTheShift.ScheduleStartDate.AddDays(7))
                    {
                        projectedHoursWorked = scheduleContainingTheShift.FirstWeekHours + shiftHours;
                        weekNumber = 1;
                    }
                    //ShiftDate is on or after the second Sunday of the Schedule
                    else
                    {
                        projectedHoursWorked = scheduleContainingTheShift.SecondWeekHours + shiftHours;
                        weekNumber = 2;
                    }

                    MessageBoxResult confirmApproval;

                    //The User will have more than 40 hours that week if this is approved
                    if (projectedHoursWorked > 40)
                    {
                        confirmApproval = MessageBox.Show("This change will set " + replacementUser.FirstName.ToUpper() + " " + replacementUser.LastName.ToUpper() +
                            "'s" + Environment.NewLine + "hours for the week to: " + projectedHoursWorked + Environment.NewLine +
                            "Are you certain you want to commit this schedule change?" + Environment.NewLine + "THIS ACTION CANNOT BE UNDONE!",
                          "Confirm Approval?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    }
                    //Hours will not go over 40
                    else
                    {
                        confirmApproval = MessageBox.Show("Are you certain you want to give " + replacementUser.FirstName.ToUpper() + " " + replacementUser.LastName.ToUpper() +
                            " this shift?" + Environment.NewLine + "THIS ACTION CANNOT BE UNDONE!", "Confirm Approval?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    }

                    //Shift change Confirmed and ready to be replaced with the selected replacement Employee
                    if (confirmApproval == MessageBoxResult.Yes)
                    {
                        int originalEmployeeID = _shiftVm.EmployeeID;

                        //Decrease old employee's hours worked, increase the new employee's hours, save the new employee in the Shift's User field
                        _shiftManager.EditEmployeeHoursWorked(originalEmployeeID, scheduleContainingTheShift.ScheduleID, weekNumber, shiftHours * -1);
                        _shiftManager.EditEmployeeHoursWorked(replacementUser.PUUserID, scheduleContainingTheShift.ScheduleID, weekNumber, shiftHours);
                        _shiftManager.EditShiftUserWorking(_shiftVm.ShiftID, replacementUser.PUUserID, originalEmployeeID);

                        WPFErrorHandler.SuccessMessage("Shift Change Successful!");

                        //Return to View Schedule page
                        this.DialogResult = true;
                    }
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
                    this.Close();
                }
            }
        }
    }
}
