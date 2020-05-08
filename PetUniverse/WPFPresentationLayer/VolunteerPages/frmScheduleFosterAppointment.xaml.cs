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
using System.Windows.Shapes;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    /// Creator: Timothy Lickteig        
    /// Created: 04/27/2020
    /// Approver: 
    /// 
    /// Form for new and updating foster appointments
    /// </summary>
    public partial class frmScheduleFosterAppointment : Window
    {
        private IVolunteerManager volManager = new VolunteerManager();
        private IFosterAppointmentManager fosterManager = new FosterAppointmentManager();
        private List<Volunteer> volunteers = new List<Volunteer>();
        private FosterAppointment toEdit = null;

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// New appointment constructor
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        public frmScheduleFosterAppointment()
        {
            InitializeComponent();

            populateVolunteerComboBox();
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Update appointment constructor
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        public frmScheduleFosterAppointment(FosterAppointmentVM appointment)
        {
            InitializeComponent();

            populateVolunteerComboBox();

            toEdit = appointment;

            cboVolunteerList.SelectedItem = appointment.FirstName + " " + appointment.LastName;
            txtStartTime.Text = appointment.StartTime.ToShortTimeString();
            txtEndTime.Text = appointment.EndTime.ToShortTimeString();
            txtDescription.Text = appointment.Description;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Method for populating the list of volunteers
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        public void populateVolunteerComboBox()
        {
            volunteers = volManager.RetrieveVolunteerListByActive();
            foreach (Volunteer volunteer in volunteers)
            {
                cboVolunteerList.Items.Add
                    (volunteer.FirstName + " " + volunteer.LastName);
            }

            if (volunteers.Count > 0)
            {
                cboVolunteerList.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// Submit button event handler
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Basic input validation
            if (null == cboVolunteerList.SelectedItem)
            {
                MessageBox.Show("Please select a volunteer");
            }
            else if (txtStartTime.Text == "")
            {
                MessageBox.Show("Please enter a valid start time");
            }
            else if (txtEndTime.Text == "")
            {
                MessageBox.Show("Please enter a valid end time");
            }
            else
            {
                try
                {
                    //Try to format the start and end times
                    DateTime startTime = DateTime.Parse(txtStartTime.Text);
                    DateTime endTime = DateTime.Parse(txtEndTime.Text);

                    //Get the volunteer ID
                    int volunteerID = volManager.GetVolunteerByName(
                        volunteers[cboVolunteerList.SelectedIndex].FirstName,
                        volunteers[cboVolunteerList.SelectedIndex].LastName)
                        [0].VolunteerID;

                    //Create a new foster appointment
                    FosterAppointment appointment = new FosterAppointment()
                    {
                        VolunteerID = volunteerID,
                        StartTime = startTime,
                        EndTime = endTime,
                        Description = txtDescription.Text
                    };

                    if (null == toEdit)
                    {
                        fosterManager.ScheduleFosterAppointment(appointment);
                        MessageBox.Show("Foster appointment scheduled");
                    }
                    else
                    {
                        fosterManager.UpdateFosterAppointment(toEdit, appointment);
                        MessageBox.Show("Appointment updated");
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
