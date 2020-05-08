using DataTransferObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-03-31
    ///     CHECKED BY: Zoey McDonald
    ///     Class for viewing the entire volunteer schedule
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public partial class ViewAllVolunteerSchedules : Page
    {
        private VolunteerManager _volManager = new VolunteerManager();

        private VolunteerShiftManager _shiftManager = new VolunteerShiftManager();

        private List<Volunteer> volunteers = new List<Volunteer>();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-31
        ///     CHECKED BY: Zoey McDonald
        ///     Main constructor for the class
        /// </summary>
        public ViewAllVolunteerSchedules()
        {
            InitializeComponent();

            refreshVolunteers();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-31
        ///     CHECKED BY: Zoey McDonald
        ///     Event handler for when a selection is changed
        /// </summary>
        private void LvwVolunteerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int volunteerID = 0;
                if (lvwVolunteerList.SelectedIndex > -1)
                {
                    volunteerID = this.volunteers
                        [lvwVolunteerList.SelectedIndex].VolunteerID;
                }

                dgShiftInformation.ItemsSource =
                _shiftManager.ReturnAllVolunteerShiftsForAVolunteer(volunteerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-31
        ///     CHECKED BY: Zoey McDonald
        ///     Method for refreshing the volunteer listview
        /// </summary>
        private void refreshVolunteers()
        {
            try
            {
                this.volunteers = _volManager.RetrieveVolunteerListByActive();

                lvwVolunteerList.Items.Clear();
                foreach (Volunteer vol in this.volunteers)
                {
                    lvwVolunteerList.Items.Add(vol.FirstName + " " + vol.LastName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-31
        ///     CHECKED BY: Zoey McDonald
        ///     Event handler for the refresh button being clicked
        /// </summary>
        private void BtnRefreshVolunteers_Click(object sender, RoutedEventArgs e)
        {
            refreshVolunteers();
        }
    }
}
