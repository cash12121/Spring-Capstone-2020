using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-02-06
    ///     CHECKED BY: Zoey McDonald
    ///     Class for frmCreateEditShift logic
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public partial class CreateEditShift : Page
    {
        private IVolunteerShiftManager _volunteerShiftAccessor = new VolunteerShiftManager();
        private VolunteerShiftVM _volunteerShift = new VolunteerShiftVM();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-06
        ///     CHECKED BY: Zoey McDonald
        ///     DESCRIPTION: Constructor for the class
        /// </summary>
        public CreateEditShift()
        {
            InitializeComponent();
            populateComboBoxes();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-06
        ///     CHECKED BY: Zoey McDonald
        ///     DESCRIPTION: Editing constructor for the class
        /// </summary>
        public CreateEditShift(VolunteerShiftVM shift)
        {
            InitializeComponent();

            populateComboBoxes();
            _volunteerShift = shift;

            txtShiftTitle.Text = _volunteerShift.ShiftTitle;
            chkIsSpecialEvent.IsChecked = _volunteerShift.IsSpecialEvent;
            dteShiftDate.SelectedDate = _volunteerShift.VolunteerShiftDate;
            txtShiftNotes.Text = _volunteerShift.ShiftNotes;
            cboRecurrance.SelectedItem = _volunteerShift.Recurrance;
            txtShiftDescription.Text = _volunteerShift.ShiftDescription;

            cboShiftStartAMorPM.SelectedIndex =
                _volunteerShift.ShiftStartTime.Hours >= 12 ? 1 : 0;
            cboShiftStartHour.SelectedIndex = twentyFourToTwelveHour(
                _volunteerShift.ShiftStartTime.Hours) - 1;
            cboShiftStartMinute.SelectedIndex =
                _volunteerShift.ShiftStartTime.Minutes;

            cboShiftEndAMorPM.SelectedIndex =
                _volunteerShift.ShiftEndTime.Hours >= 12 ? 1 : 0;
            cboShiftEndHour.SelectedIndex = twentyFourToTwelveHour(
                _volunteerShift.ShiftEndTime.Hours) - 1;
            cboShiftStartMinute.SelectedIndex =
                _volunteerShift.ShiftEndTime.Minutes;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-06
        ///     CHECKED BY: Zoey McDonald
        ///     DESCRIPTION: Method for populating all the combo boxes in the form
        /// </summary>
        private void populateComboBoxes()
        {
            cboNeededRole.Items.Add("Role 1");
            cboNeededRole.Items.Add("Role 2");
            cboNeededRole.Items.Add("Role 3");
            cboNeededRole.Items.Add("Role 4");
            cboNeededRole.SelectedIndex = 0;

            cboRecurrance.Items.Add("Daily");
            cboRecurrance.Items.Add("Weekly");
            cboRecurrance.Items.Add("Bi-Weekly");
            cboRecurrance.Items.Add("Monthly");
            cboRecurrance.SelectedIndex = 0;

            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    cboShiftStartHour.Items.Add("0" + i.ToString());
                    cboShiftEndHour.Items.Add("0" + i.ToString());
                }
                else
                {
                    cboShiftStartHour.Items.Add(i.ToString());
                    cboShiftEndHour.Items.Add(i.ToString());
                }
            }
            cboShiftStartHour.SelectedIndex = 0;
            cboShiftEndHour.SelectedIndex = 0;

            for (int i = 0; i < 60; i++)
            {
                if (i < 10)
                {
                    cboShiftStartMinute.Items.Add("0" + i.ToString());
                    cboShiftEndMinute.Items.Add("0" + i.ToString());
                }
                else
                {
                    cboShiftStartMinute.Items.Add(i.ToString());
                    cboShiftEndMinute.Items.Add(i.ToString());
                }
            }
            cboShiftStartMinute.SelectedIndex = 0;
            cboShiftEndMinute.SelectedIndex = 0;

            cboShiftStartAMorPM.Items.Add("AM");
            cboShiftStartAMorPM.Items.Add("PM");

            cboShiftEndAMorPM.Items.Add("AM");
            cboShiftEndAMorPM.Items.Add("PM");

            cboShiftStartAMorPM.SelectedIndex = 0;
            cboShiftEndAMorPM.SelectedIndex = 0;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-06
        ///     CHECKED BY: Zoey McDonald
        ///     DESCRIPTION: Event handler for the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelButton_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = false;
            //this.Close();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-06
        ///     DESCRIPTION: Event handler for the submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtShiftTitle.Text == "Shift Title" || this.txtShiftTitle.Text == "")
            {
                MessageBox.Show("Shift Title Cannot be Blank");
            }
            else if (null == this.dteShiftDate.SelectedDate)
            {
                MessageBox.Show("Shift Date Cannot be Blank");
            }
            else if (this.txtShiftDescription.Text == "Shift Description" || this.txtShiftDescription.Text == "")
            {
                MessageBox.Show("Shift Description Cannot be Blank");
            }
            else if ((DateTime.Compare((DateTime)dteShiftDate.SelectedDate, DateTime.Now.Date)) < 0)
            {
                MessageBox.Show("Shift Date cannot be before today");
            }
            else
            {
                if (this.txtShiftNotes.Text == "Shift Notes")
                {
                    this.txtShiftNotes.Text = "";
                }

                int startHour = Convert.ToInt32(this.cboShiftStartHour.SelectedItem);
                int startMinute = Convert.ToInt32(this.cboShiftStartMinute.SelectedItem);
                if ((string)this.cboShiftStartAMorPM.SelectedItem == "PM")
                {
                    startHour = startHour + 12;
                }
                if (startHour == 24)
                {
                    startHour = 12;
                }
                else if (startHour == 12)
                {
                    startHour = 0;
                }

                int endHour = Convert.ToInt32(this.cboShiftEndHour.SelectedItem);
                int endMinute = Convert.ToInt32(this.cboShiftEndMinute.SelectedItem);
                if ((string)this.cboShiftEndAMorPM.SelectedItem == "PM")
                {
                    endHour = endHour + 12;
                }
                if (endHour == 24)
                {
                    endHour = 12;
                }
                else if (endHour == 12)
                {
                    endHour = 0;
                }

                _volunteerShift.IsSpecialEvent = (bool)chkIsSpecialEvent.IsChecked;
                _volunteerShift.Recurrance = (string)cboRecurrance.SelectedItem;
                _volunteerShift.ShiftDescription = txtShiftDescription.Text;
                _volunteerShift.ShiftStartTime = new TimeSpan(startHour, startMinute, 0);
                _volunteerShift.ShiftEndTime = new TimeSpan(endHour, endMinute, 0);
                _volunteerShift.ShiftNotes = txtShiftNotes.Text;
                _volunteerShift.ShiftTitle = txtShiftTitle.Text;
                _volunteerShift.VolunteerShiftDate = (DateTime)dteShiftDate.SelectedDate;

                try
                {
                    if ((_volunteerShiftAccessor.AddVolunteerShift(_volunteerShift)) == 1)
                    {
                        WPFErrorHandler.SuccessMessage("Shift Added");
                    }
                    else
                    {
                        MessageBox.Show("Shift Failed to Add");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-06
        ///     CHECKED BY: Zoey McDonald
        ///     DESCRIPTION: Method for converting 24hr time to 12hr time
        /// </summary>
        /// <param name="twentyFour">Hour in 24 hour time</param>
        /// <returns>12 hour representation of the time</returns>
        private int twentyFourToTwelveHour(int twentyFour)
        {
            int twelveHour = twentyFour;

            if (twentyFour > 12)
            {
                twelveHour = twentyFour - 12;
            }
            else if (twentyFour == 0)
            {
                twelveHour = 12;
            }

            return twelveHour;
        }
    }
}
