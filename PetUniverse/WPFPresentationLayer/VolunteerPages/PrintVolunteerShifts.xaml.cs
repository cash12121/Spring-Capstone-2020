using DataTransferObjects;
using LogicLayer;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-03-11
    ///     CHECKED BY: Zoey McDonald
    ///     Class for printing volunteer shifts to the screen
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public partial class PrintVolunteerShifts : Page
    {
        private VolunteerShiftVM _shiftBeingEdited = null;

        VolunteerShiftManager manager = new VolunteerShiftManager();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-11
        ///     CHECKED BY: Zoey McDonald
        ///     Main constructor for the class
        /// </summary>
        public PrintVolunteerShifts()
        {
            InitializeComponent();

            refreshList();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-04-07
        ///     CHECKED BY: Zoey McDonald
        ///     Event handler for when editing of the datagrid has begun
        /// </summary>
        private void DgShiftList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (((VolunteerShiftVM)dgShiftList.Items[dgShiftList.SelectedIndex]).VolunteerShiftID != 0)
            {
                _shiftBeingEdited = (VolunteerShiftVM)dgShiftList.Items[dgShiftList.SelectedIndex];
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-04-07
        ///     CHECKED BY: Zoey McDonald
        ///     Event handler the save button
        /// </summary>
        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (_shiftBeingEdited != null)
            {
                try
                {
                    manager.EditVolunteerShift(_shiftBeingEdited, (VolunteerShiftVM)dgShiftList.SelectedItem);
                    refreshList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-04-07
        ///     CHECKED BY: Zoey McDonald
        ///     Event handler for the selection being changed
        /// </summary>
        private void DgShiftList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _shiftBeingEdited = null;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-04-07
        ///     CHECKED BY: Zoey McDonald
        ///     Event handler for when the refresh button is clicked
        /// </summary>
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refreshList();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-04-07
        ///     CHECKED BY: Zoey McDonald
        ///     Event handler for when the checkbox is clicked
        /// </summary>
        private void ChkAvailable_Click(object sender, RoutedEventArgs e)
        {
            refreshList();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-04-07
        ///     CHECKED BY: Zoey McDonald
        ///     Helper method for refreshing the datagrid
        /// </summary>
        private void refreshList()
        {
            try
            {
                if (!(bool)chkAvailable.IsChecked)
                {
                    dgShiftList.ItemsSource = manager.ReturnAllVolunteerShifts();
                }
                else
                {
                    dgShiftList.ItemsSource = manager.ReturnAllVolunteerShifts().
                        Where(x => x.VolunteerID == 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error loading the shift: " + ex.Message);
            }
        }
    }
}
