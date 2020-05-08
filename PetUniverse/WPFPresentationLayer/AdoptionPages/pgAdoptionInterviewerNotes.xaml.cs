using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/29
    /// Approver: Awaab Elamin, 2020/02/21
    ///  This class has interaction logic for the Adoption Interviewer notes 
    ///  page.
    public partial class pgAdoptionInterviewerNotes : Page
    {

        private AdoptionAppointment _adoptionAppointment = null;
        private IAdoptionInterviewerManager _adoptionInterviewerManager = null;
        private bool _addMode = false;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the Constructor method for Interviewer pag.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        public pgAdoptionInterviewerNotes(IAdoptionInterviewerManager adoptionInterviewerManager)
        {
            InitializeComponent();
            _adoptionInterviewerManager = adoptionInterviewerManager;
            _addMode = true;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the Constructor method for Interviewer page 
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionAppointment"></param>
        /// <param name="adoptionInterviewerManager"></param>
        public pgAdoptionInterviewerNotes(AdoptionAppointment adoptionAppointment,
            IAdoptionInterviewerManager adoptionInterviewerManager)
        {
            InitializeComponent();
            _adoptionAppointment = adoptionAppointment;
            _adoptionInterviewerManager = adoptionInterviewerManager;

        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is an Event on Save button is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param> 
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AdoptionAppointment newAdoptionAppointment = new AdoptionAppointment()
            {
                AppointmentID = Convert.ToInt32(txtAppointmentID.Text),
                Notes = txtNotes.Text,
            };

            if (_addMode)
            {
                try
                {
                    if (_adoptionInterviewerManager.EditAppointment(_adoptionAppointment,
                        newAdoptionAppointment))
                    {
                        this.NavigationService?.Navigate(new pgAdoptionInterviewer());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n"
                        + ex.InnerException.Message);
                }
            }
            else
            {
                throw new ApplicationException("Data not Saved.",
                     new ApplicationException("User may no longer exist."));
            }
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is an event when Cancel button is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param> 
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new pgAdoptionInterviewer());

        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is an event when Edit button is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SetEditMode();
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is void method will be called to whene the edit button is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>

        private void SetEditMode()
        {
            _addMode = true;
            txtAdoptionApplicationID.IsReadOnly = true;
            txtAppointmentTypeID.IsReadOnly = true;
            DateTime.IsReadOnly = true;
            txtNotes.IsReadOnly = false;
            cmbDecision.IsReadOnly = true;
            txtLocationName.IsReadOnly = true;


            btnEdit.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is an event on the page first loads.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            txtAppointmentID.IsReadOnly = true;

            if (_addMode == false)
            {
                txtAppointmentID.Text = _adoptionAppointment.AppointmentID.ToString();
                txtAdoptionApplicationID.Text = _adoptionAppointment
                    .AdoptionApplicationID.ToString();
                txtAppointmentTypeID.Text = _adoptionAppointment.AppointmentTypeID;
                DateTime.Text = _adoptionAppointment.AppointmentDateTime.ToString();
                txtNotes.Text = _adoptionAppointment.Notes;
                cmbDecision.Text = _adoptionAppointment.Decision;
                txtLocationName.Text = _adoptionAppointment.LocationName.ToString();


                txtAdoptionApplicationID.IsReadOnly = true;
                txtAppointmentTypeID.IsReadOnly = true;
                DateTime.IsReadOnly = true;
                txtNotes.IsReadOnly = true;
                cmbDecision.IsReadOnly = true;
                txtLocationName.IsReadOnly = true;
            }
            else
            {
                SetEditMode();
                txtAdoptionApplicationID.IsReadOnly = true;
                txtAppointmentTypeID.IsReadOnly = true;
                DateTime.IsReadOnly = true;
                txtNotes.IsReadOnly = true;
                cmbDecision.IsReadOnly = true;
                txtLocationName.IsReadOnly = true;

            }
        }
    }
}



