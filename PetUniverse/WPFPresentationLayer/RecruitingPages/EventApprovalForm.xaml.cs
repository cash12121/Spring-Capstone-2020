using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// Interaction logic for EventApprovalForm.xaml
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2\08\2020
    /// APPROVER: Ryan Morganti
    /// 
    /// This is the page for displaying the View Model of an Event
    /// It has two modes, one for Reviewing an Event (UC-619)
    /// And another for simply Viewing the Events Details
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// UPDATER: NA
    /// UPDATED: NA
    /// UPDATE: NA
    /// 
    /// </remarks>
    public partial class EventApprovalForm : Page
    {
        private PetUniverseUser _user = null;//For implementing based on the User's Role
        private IPUEventManager _eventManager = null;//For accessing Event Manager operations
        private IRequestManager _requestManager = null;//For accessing the Request Manager Operations
        private IVolunteerTaskManager _volunteerTaskManager = null;


        private EventMgmt _eventMgmt = null;//For updating the frames in the EventMgmt page if the event is updated
        private PUEvent _event = null;//For operating on the event
        private bool _approveMode = false;//To track Review vs View Mode

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2\08\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is the constructor that will load this page for Viewing an Event's details
        /// It keeps the approveMode as false
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="eventManager"></param>
        /// <param name="user"></param>
        /// <param name="puEvent"></param>
        /// <param name="eventMgmt"></param>
        public EventApprovalForm(IPUEventManager eventManager, PetUniverseUser user,
            PUEvent puEvent, EventMgmt eventMgmt)
        {
            _eventManager = eventManager;
            _requestManager = new RequestManager();
            _user = user;
            _event = puEvent;
            _eventMgmt = eventMgmt;

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2\08\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is the full argument constructor which is used for Reviewing an Event (UC-619)
        /// It will set the approveMode to true when called
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="eventManager"></param>
        /// <param name="user"></param>
        /// <param name="puEvent"></param>
        /// <param name="eventMgmt"></param>
        /// <param name="approveMode"></param>
        public EventApprovalForm(IPUEventManager eventManager, PetUniverseUser user,
            PUEvent puEvent, EventMgmt eventMgmt, bool approveMode)
        {
            _eventManager = eventManager;
            _user = user;
            _event = puEvent;
            _approveMode = approveMode;
            _eventMgmt = eventMgmt;
            _volunteerTaskManager = new VolunteerTaskManager();
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\08\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is the no-argument constructor needed for the programs initialization
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public EventApprovalForm()
        {
            _eventManager = new PUEventManager();
            _user = new PetUniverseUser();
            _event = new PUEvent();
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\08\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is the event handler for when this page loads
        /// Gets the Event's View Model through the Event Manager
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //EventID = 0 on EventMgmt startup, which loads the empty constructor
            //This block is bypassed on startup, only occurs when called from the eventMgmt button
            if (_event.EventID != 0)
            {
                try
                {
                    EventApprovalVM eventApprovalVM = _eventManager.GetEventApprovalVM(_event.EventID, _event.CreatedByID);
                    if (eventApprovalVM != null)
                    {
                        FillFieldData(eventApprovalVM);

                        if (_approveMode == true)
                        {
                            lblReviewerName.Content = _user.FirstName + " " + _user.LastName;
                            txtEventDisapprovalReason.Text = "Reason for disapproval";
                        }
                        else //If in View Mode
                        {
                            SetUpViewMode(eventApprovalVM);
                        }//End View Mode
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.InnerException.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\15\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is a helper method to Set up the EventApprovalForm as a View only Page
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="eventApprovalVM"></param>
        private void SetUpViewMode(EventApprovalVM eventApprovalVM)
        {
            txtVolunteersNeeded.IsReadOnly = true;
            btnApprove.Visibility = Visibility.Hidden;
            btnDisapprove.Visibility = Visibility.Hidden;
            lblAutogen.Visibility = Visibility.Hidden;
            chkAutoGenVolunteerTask.Visibility = Visibility.Hidden;
            //Currently, the reviewer name being returned is actually the reviewers ID
            //Therefore, this checks to see if the value is parsable to an int and != 0
            //If so it tries to find the matching ID for a user in the DB
            //All just to get the info needed for the reviewer attached to this request
            if (Int32.TryParse(eventApprovalVM.ReviewerName, out int reviewerID) && reviewerID != 0)
            {
                //Not Ideal, waiting for a retrieveUserByID method
                IUserManager _tempUserManager = new UserManager();
                foreach (var user in _tempUserManager.RetrieveAllActivePetUniverseUsers())
                {
                    if (user.PUUserID == reviewerID)
                    {
                        lblReviewerName.Content = user.FirstName + " " + user.LastName;
                    }
                }
            }
            else//this is the case for pending events
            {
                lblReviewerName.Content = "Not Applicable";
                txtVolunteersNeeded.Visibility = Visibility.Hidden;
                lblNeededVolunteers.Visibility = Visibility.Hidden;

            }
            txtEventDisapprovalReason.Visibility = Visibility.Hidden;
            lblEventStatus.Content += _event.Status;
            lblEventStatus.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\08\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is a helper method which fills the forms fields with the Event's data
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="eventApprovalVM"></param>
        private void FillFieldData(EventApprovalVM eventApprovalVM)
        {
            lblBannerPath.Content = eventApprovalVM.BannerPath;
            lblDateRequested.Content = eventApprovalVM.DateCreated.ToString();
            lblEventAddressLineOne.Content = eventApprovalVM.Address;
            lblEventAddressLineTwo.Content = eventApprovalVM.City + ", "
                                            + eventApprovalVM.State + " "
                                            + eventApprovalVM.Zipcode;
            lblEventDescription.Text = eventApprovalVM.Description;
            txtEventDisapprovalReason.Text = eventApprovalVM.DisapprovalReason;
            lblEventName.Content = eventApprovalVM.EventName;
            lblEventTime.Content = eventApprovalVM.EventDateTime.ToString();
            lblEventType.Content = eventApprovalVM.EventTypeID;
            try
            {
                Uri uri = new Uri(System.AppDomain.CurrentDomain.BaseDirectory
                            + @"..\..\images\" + _event.BannerPath, UriKind.RelativeOrAbsolute);
                picEventPicture.Source = new BitmapImage(uri);
            }
            catch (Exception ex)
            {

            }

            lblRequestedByName.Content = eventApprovalVM.RequestedByName;
            txtVolunteersNeeded.Text = eventApprovalVM.DesiredVolunteers.ToString();
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\08\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is the event handler for the Approve Event Button
        /// It will prompt a confirmation message and if the user clicks Yes
        /// It will update the Event and the Event Request in the DB
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            //Check that the number entered is a valid number
            int volunteersNeeded = -1;
            MessageBoxResult confirmed = new MessageBoxResult();
            try
            {
                //Throws exception if a non-numeric value is entered
                volunteersNeeded = Int32.Parse(txtVolunteersNeeded.Text);
                if (volunteersNeeded > 25)
                {
                    MessageBox.Show("The number of volunteers has exceeded allowed limit (25)");
                    volunteersNeeded = -1;
                }
                else if (volunteersNeeded < 0)
                {
                    throw new ApplicationException();
                }
                else
                {
                    string volunteerTaskUnchecked = "";
                    if (chkAutoGenVolunteerTask.IsChecked == false)
                    {
                        volunteerTaskUnchecked = "\nYou have opted not to generate a Volunteer task for this event.\n";
                    }

                    //Ask for confirmation that this event should be approved
                    confirmed = MessageBox.Show("You are committing " + volunteersNeeded
                        + " volunteers for this event.\n"
                        + volunteerTaskUnchecked
                        + "\nConfirm Approval for the following Event: " + _event.EventName + "\n",
                        "Approval Confirmaton", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid entry for volunteers needed", ex.Message);
            }//End Validation


            //If valid and user clicks yes on confirmation messagebox
            if (confirmed == MessageBoxResult.Yes && volunteersNeeded != -1)
            {
                UpdateEventRequestAndStatus();
            }
        }//End Approve Event Click Event Handler

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\16\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is a helper method to Update the Event's EventRequest data and Event Status in the DB
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        private void UpdateEventRequestAndStatus()
        {
            //First updates the EventRequest data
            //Then updates the actual Event's Status
            try
            {
                //get the eventRequest that belongs to this event
                EventRequest originalRequestForThisEvent = _eventManager.GetEventRequestByEventID(_event.EventID);
                //If its found...
                if (originalRequestForThisEvent != null)
                {
                    //Create a new eventRequest to hold the updated values
                    //Sets the ReviewerID == the UserID of the person who is approving this form
                    //Sets the Desired volunteers
                    //  and sets Active to false
                    EventRequest updatedEventRequest = new EventRequest()
                    {
                        EventID = originalRequestForThisEvent.EventID,
                        RequestID = originalRequestForThisEvent.RequestID,
                        ReviewerID = _user.PUUserID,
                        DesiredVolunteers = Int32.Parse(txtVolunteersNeeded.Text),
                        Active = false
                    };

                    //Attempt to update the eventRequest in the DB...
                    bool successfulEventRequestUpdate =
                        _eventManager.UpdateEventRequest(originalRequestForThisEvent, updatedEventRequest);

                    //If the update was successful... now update the actual Event record's status
                    if (successfulEventRequestUpdate)
                    {
                        UpdateEventStatus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error." + ex.Message);
            }
        }

        ///<summary>
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\16\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is a helper method to Update the events status through the event manager
        /// following a successful update of the Event's EventRequest
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        private void UpdateEventStatus()
        {
            //Attempt to update the Event with the new status
            bool successfulStatusUpdate = _eventManager.UpdateEventStatus(_event.EventID, "Approved");
            bool successfulVolunteerTaskCreation = false;
            string volunteerTaskFollowUp = "";

            if (successfulStatusUpdate)
            {
                successfulVolunteerTaskCreation = GenerateVolunteerTaskIfSelected();
            }

            if (chkAutoGenVolunteerTask.IsChecked == false)
            {
                volunteerTaskFollowUp = "\nPlease Navigate to the Volunteer Hub to schedule a \n"
                    + "volunteer task for this event at your earliest convenience.";
            }

            if (successfulStatusUpdate && successfulVolunteerTaskCreation)
            {
                MessageBox.Show("The Event : " + _event.EventName + "\nhas been approved." + volunteerTaskFollowUp);
                _eventMgmt.frAllEvents.Content = new ListAllEvents(_eventManager, _eventMgmt);
                _eventMgmt.frPendingEvents.Content = new ListPendingEvents(_eventManager, _eventMgmt);
                _eventMgmt.frApprovedEvents.Content = new ListApprovedEvents(_eventManager, _eventMgmt);
                this.Visibility = Visibility.Hidden;
                _eventMgmt.tabApprovedEvents.IsSelected = true;
            }
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\16\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is a helper method to Auto-Generate a generic Volunteer Task
        /// if the reviewer of this event has kept the check box checked
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        private bool GenerateVolunteerTaskIfSelected()
        {
            //Create a volunteer task for this event
            if (chkAutoGenVolunteerTask.IsChecked == true)
            {
                VolunteerTask newVolunteerTask = new VolunteerTask()
                {
                    TaskType = "Event Support",
                    TaskName = _event.EventName + " Event Volunteer",
                    AssignmentGroup = "EventGroup",
                    TaskDescription = "Volunteer support to assist in the operations of this event.",
                    DueDate = _event.EventDateTime
                };

                _volunteerTaskManager.CreateVolunteerTask(newVolunteerTask.TaskName,
                                                            newVolunteerTask.TaskType,
                                                            newVolunteerTask.AssignmentGroup,
                                                            newVolunteerTask.TaskDescription,
                                                            newVolunteerTask.DueDate);
            }
            return true;
        }


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 3\08\2020
        /// APPROVER: Ryan Morganti
        /// 
        /// This is the event handler for the Disapprove button
        /// It will prompt a confirmation messagebox, if yes
        /// it will update the Event's status and the Event Request data in the DB
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisapprove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmed = new MessageBoxResult();

            //Simply checks if the Reviewer entered something into the disapproval reason textbox
            if (txtEventDisapprovalReason.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must provide a disapproval reason.");
            }
            else
            {
                //Ask for confirmation that this event should be disapproved
                confirmed = MessageBox.Show("You are disapproving Event:\n " + _event.EventName
                    + "\n\n Reason: " + txtEventDisapprovalReason.Text + "\n\nAre you sure you wish to continue?",
                    "Disapproval Confirmaton", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

                if (confirmed == MessageBoxResult.Yes)
                {
                    //First updates the EventRequest data
                    //Then updates the actual Event's Status

                    try
                    {
                        //get the eventRequest that belongs to this event
                        EventRequest originalRequestForThisEvent = _eventManager.GetEventRequestByEventID(_event.EventID);
                        //If its found...
                        if (originalRequestForThisEvent != null)
                        {
                            //Create a new eventRequest to hold the updated values
                            //Sets the ReviewerID == the UserID of the person who is reviewing this form
                            //  and sets Active to false
                            EventRequest updatedEventRequest = new EventRequest()
                            {
                                EventID = originalRequestForThisEvent.EventID,
                                RequestID = originalRequestForThisEvent.RequestID,
                                ReviewerID = _user.PUUserID,
                                DisapprovalReason = txtEventDisapprovalReason.Text,
                                Active = false
                            };

                            //Attempt to update the eventRequest in the DB...
                            bool successfulEventRequestUpdate =
                                _eventManager.UpdateEventRequest(originalRequestForThisEvent, updatedEventRequest);
                            //If the update was successful... now update the actual Event record's status
                            if (successfulEventRequestUpdate)
                            {
                                //Attempt to update the Event with the new status
                                bool successfulStatusUpdate = _eventManager.UpdateEventStatus(_event.EventID, "Disapproved");

                                if (successfulStatusUpdate)
                                {
                                    MessageBox.Show("The Event : " + _event.EventName + "\nhas been disapproved.");
                                    _eventMgmt.frAllEvents.Content = new ListAllEvents(_eventManager, _eventMgmt);
                                    _eventMgmt.frPendingEvents.Content = new ListPendingEvents(_eventManager, _eventMgmt);
                                    _eventMgmt.frApprovedEvents.Content = new ListApprovedEvents(_eventManager, _eventMgmt);
                                    this.Visibility = Visibility.Hidden;
                                    _eventMgmt.tabAllEvents.IsSelected = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error." + ex.Message);
                    }
                }

            }
        }//End Disapprove Click Handler

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/03/06
        /// APPROVER: Ryan Morganti
        /// 
        /// Simple click event for the disapproval reason checkbox.
        /// it will clear the contents when the reviewer first clicks the box
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEventDisapprovalReason_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtEventDisapprovalReason.Text == "Reason for disapproval")
            {
                txtEventDisapprovalReason.Text = "";
            }
        }

    }
}
