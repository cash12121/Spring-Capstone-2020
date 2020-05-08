using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Windows;
using System.Windows.Controls;


namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Awaab Elamin, 2020/02/21
    ///  This class has interaction logic for the HomeInspectorAdoptionApplication
    ///  window.
    /// </summary>
    public partial class frmAdoptionApplictionDetails : Page
    {
        private HomeInspectorAdoptionAppointmentDecision _homeInspectionAppointmentDecision = null;
        private IInHomeInspectionAppointmentDecisionManager
            _inHomeInspectionAppointmentDecisionManager = null;
        private bool _addMode = false;


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the Constructor method for Adoption Appliction Details
        /// window.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="inHomeInspectionAppointmentDecisionManager"></param>
        public frmAdoptionApplictionDetails(IInHomeInspectionAppointmentDecisionManager
            inHomeInspectionAppointmentDecisionManager)
        {
            InitializeComponent();
            _inHomeInspectionAppointmentDecisionManager = inHomeInspectionAppointmentDecisionManager;
            _addMode = true;

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is the Constructor method for Adoption Appliction Details
        /// window.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="homeInspectorAdoptionAppointmentDecision"></param>
        /// <param name="inHomeInspectionAppointmentDecisionManager"></param>

        public frmAdoptionApplictionDetails(HomeInspectorAdoptionAppointmentDecision
            homeInspectorAdoptionAppointmentDecision, IInHomeInspectionAppointmentDecisionManager
            inHomeInspectionAppointmentDecisionManager)
        {
            InitializeComponent();
            _homeInspectionAppointmentDecision = homeInspectorAdoptionAppointmentDecision;
            _inHomeInspectionAppointmentDecisionManager = inHomeInspectionAppointmentDecisionManager;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is an event when btnCancel is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new frmInHomeInspectorDecision());

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
        /// This is an event on the window first loads.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtAppointmentID.IsReadOnly = true;

            if (_addMode == false)
            {
                txtAppointmentID.Text = _homeInspectionAppointmentDecision.AppointmentID.ToString();
                txtAdoptionApplicationID.Text = _homeInspectionAppointmentDecision
                    .AdoptionApplicationID.ToString();
                txtAppointmentTypeID.Text = _homeInspectionAppointmentDecision.AppointmentTypeID;
                DateTime.Text = _homeInspectionAppointmentDecision.DateTime.ToString();
                txtNotes.Text = _homeInspectionAppointmentDecision.Notes;
                cmbDecision.Text = _homeInspectionAppointmentDecision.Decision;
                txtLocationID.Text = _homeInspectionAppointmentDecision.LocationName;
                txtActive.Text = _homeInspectionAppointmentDecision.Active.ToString();

                txtAdoptionApplicationID.IsReadOnly = true;
                txtAppointmentTypeID.IsReadOnly = true;
                DateTime.IsReadOnly = true;
                txtNotes.IsReadOnly = true;
                cmbDecision.IsEnabled = false;
                txtLocationID.IsReadOnly = true;
                txtActive.IsReadOnly = true;



            }
            else
            {
                SetEditMode();
                txtAdoptionApplicationID.IsReadOnly = true;
                txtAppointmentTypeID.IsReadOnly = true;
                DateTime.IsReadOnly = true;
                txtNotes.IsReadOnly = true;
                cmbDecision.IsEnabled = true;
                txtLocationID.IsReadOnly = true;
                txtActive.IsReadOnly = true;
            }
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is void method will be called to set the edit mode.
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
            cmbDecision.IsEnabled = true;
            txtLocationID.IsReadOnly = true;
            txtActive.IsReadOnly = true;

            btnEdit.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// This is an Event on Save Button is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param> 
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision =
            new HomeInspectorAdoptionAppointmentDecision()
            {
                AppointmentID = Convert.ToInt32(txtAppointmentID.Text),
                Notes = txtNotes.Text.ToString(),
                Decision = cmbDecision.Text.ToString()
            };

            if (_addMode)
            {
                try
                {
                    if (_inHomeInspectionAppointmentDecisionManager.EditAppointment
                        (_homeInspectionAppointmentDecision, newHomeInspectorAdoptionAppointmentDecision))
                    {
                        this.NavigationService?.Navigate(new frmInHomeInspectorDecision());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Appointment can't be Edit", ex.Message + "\n\n"
                                               + ex.InnerException.Message);
                }

                if (Facilitator.IsSelected)
                {

                    if (_inHomeInspectionAppointmentDecisionManager.UpdateHomeInspectorDecision
                    (_homeInspectionAppointmentDecision
                        .AdoptionApplicationID, Facilitator.Content.ToString()))
                    {
                        MessageBox.Show("Adoption Application's Decision has been successfully Updated");
                    }
                }

                else if (Deny.IsSelected)
                {
                    if (_inHomeInspectionAppointmentDecisionManager.UpdateHomeInspectorDecision
                    (_homeInspectionAppointmentDecision.AdoptionApplicationID
                        , Deny.Content.ToString()))

                    {

                        MessageBox.Show("Adoption Application's Decision has been Denied!");
                    }
                }
            }
            else
            {
                throw new ApplicationException("Data not Saved.",
                    new ApplicationException("User may no longer exist."));
            }
        }
    }
}

