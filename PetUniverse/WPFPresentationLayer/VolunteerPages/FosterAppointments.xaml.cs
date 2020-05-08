using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    /// Creator: Timothy Lickteig        
    /// Created: 04/27/2020
    /// Approver: Zoey McDonald
    /// 
    /// Partial class for foster appointments
    /// </summary>
    public partial class FosterAppointments : Page
    {
        IFosterAppointmentManager manager;

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Constructor
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        public FosterAppointments()
        {
            InitializeComponent();

            manager = new FosterAppointmentManager();

            refreshList();
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Event handler for the new appointment button
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        private void BtnScheduleAppointment_Click(object sender, RoutedEventArgs e)
        {
            frmScheduleFosterAppointment window = new frmScheduleFosterAppointment();
            window.ShowDialog();
            refreshList();
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Method for refreshing the datagrid
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        private void refreshList()
        {
            try
            {
                dgAppointmentList.ItemsSource = manager.ViewFosterAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Event handler for datagrid double clicks
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        private void DgAppointmentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (null != dgAppointmentList.SelectedItem)
            {
                frmScheduleFosterAppointment window =
                    new frmScheduleFosterAppointment(
                    (FosterAppointmentVM)dgAppointmentList.SelectedItem);
                window.ShowDialog();
                refreshList();
            }
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Event handler for the refresh button
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refreshList();
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Event handler for the delete button
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (null != dgAppointmentList.SelectedItem)
            {
                try
                {
                    manager.CancelFosterAppointment(
                        ((FosterAppointment)dgAppointmentList.SelectedItem).FosterAppointmentID);
                    refreshList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
