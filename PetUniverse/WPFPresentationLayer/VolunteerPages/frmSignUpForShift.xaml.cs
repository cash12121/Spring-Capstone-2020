using DataTransferObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    /// Interaction logic for frmSignUpForShift.xaml
    /// </summary>
    public partial class frmSignUpForShift : Window
    {
        private VolunteerShiftManager _shiftManager = new VolunteerShiftManager();
        private int _volunteerID = 0;
        private List<VolunteerShiftVM> _shifts = new List<VolunteerShiftVM>();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-31
        ///     CHECKED BY: Zoey McDonald
        ///     Main constructor for the class
        /// </summary>
        public frmSignUpForShift(int volunteerID)
        {
            InitializeComponent();

            _volunteerID = volunteerID;

            refreshShifts();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-31
        ///     CHECKED BY: Zoey McDonald
        ///     Method for refreshing the available shifts
        /// </summary>
        private void refreshShifts()
        {
            try
            {
                List<VolunteerShiftVM> shifts = _shiftManager.ReturnAllVolunteerShifts().Where(x => x.VolunteerID == 0).ToList();
                dgShiftList.ItemsSource = shifts;
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
        ///     Event handler for the add shift button
        /// </summary>
        private void BtnAddShift_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VolunteerShiftVM shift = (VolunteerShiftVM)dgShiftList.SelectedItem;
                _shiftManager.SignVolunteerUpForShift(_volunteerID, shift.VolunteerShiftID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
