using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// 
    /// CREATOR: Steve Coonrod
    /// CREATED: 2\08\2020
    /// APPROVER: Ryan Morganti
    /// 
    /// This is the page which contains all Event Management operations.
    /// It is set up as a tab control which hold seperate frames each containing a datagrid
    /// which is set to retrieve a list of events with a specific status
    /// 
    /// There is a public event attribute to track which event is currently selected
    ///     Each page sets this value in its datagrid's selection_changed event handler
    ///     so that it can be referred to by the buttons on this page
    /// </summary>
    /// <remarks>
    /// UPDATER: NA
    /// UPDATED: NA
    /// UPDATE: NA
    /// 
    /// </remarks>
    public partial class EventMgmt : Page
    {

        private IPUEventManager _eventManager = null;//For using event manager methods
        private PetUniverseUser _user = null;//for tracking the current user
        public PUEvent _selectedEvent;//To track the currently selected Event on the datagrids


        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/2/08
        /// APPROVER: Ryan Morganti
        /// This is the no-argument constructor.
        ///     It is never referenced, but is necessary for the PUHome window to initialize.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public EventMgmt()
        {
            InitializeComponent();
            _eventManager = new PUEventManager();
        }

        /// <summary>
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// This is the constructor for this page which takes in a user object.
        /// This is necessary for basing functionality on the users role.
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="user"></param>
        public EventMgmt(PetUniverseUser user)
        {
            InitializeComponent();
            _eventManager = new PUEventManager();
            _user = user;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// A helper method to disable and enable the buttons 
        /// which depend on an Event being selected in one of the the datagrids
        /// 
        /// Public so the method can be used by each page connected to the EventMgmt Page
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public void ToggleEventButtons()
        {
            if (_selectedEvent == null)
            {
                btnDeleteEvent.IsEnabled = false;
                btnViewEventDetails.IsEnabled = false;
                btnEditEvent.IsEnabled = false;
                btnReviewEvent.IsEnabled = false;
            }
            else
            {
                //Viewing the event details will always be enabled
                btnViewEventDetails.IsEnabled = true;

                bool isDCAdmin = false;
                if (_user.PURoles.Contains("Administrator") || _user.PURoles.Contains("Donation Coordinator"))
                {
                    isDCAdmin = true;
                }

                if (isDCAdmin)
                {
                    if (_selectedEvent.Status == "PendingApproval")
                    {
                        btnDeleteEvent.IsEnabled = true;
                        btnEditEvent.IsEnabled = true;
                        btnReviewEvent.IsEnabled = true;
                    }
                    else if (_selectedEvent.Status == "Completed")
                    {
                        btnDeleteEvent.IsEnabled = true;
                        btnEditEvent.IsEnabled = false;
                        btnReviewEvent.IsEnabled = false;
                    }
                    else
                    {
                        btnDeleteEvent.IsEnabled = true;
                        btnEditEvent.IsEnabled = true;
                        btnReviewEvent.IsEnabled = false;
                    }
                }
                else
                {
                    //Non-DCAdmin members will only see active and approved Events...
                    if (_selectedEvent.CreatedByID == _user.PUUserID)
                    {
                        btnEditEvent.IsEnabled = true;
                    }
                    else
                    {
                        btnEditEvent.IsEnabled = false;
                    }
                }
            }//End outer-Else loop 
        }//End ToggleEventButtons()




        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// The handler for loading this page.
        /// At this point it will populate the events datagrid
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
            if (_user != null)
            {
                SetUpPageBasedOnUserRole();
            }
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// A helper method to set up the page based on the user's roles
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        private void SetUpPageBasedOnUserRole()
        {
            //Searches through the user's role list, 
            //if it finds Admin or DC it breaks and sets the page up for full priviledges
            //otherwise it sets up basic member functionality
            foreach (string role in _user.PURoles)
            {
                if (role == "Administrator" || role == "Donation Coordinator")
                {
                    frAllEvents.Content = new ListAllEvents(_eventManager, this);
                    frPendingEvents.Content = new ListPendingEvents(_eventManager, this);
                    frApprovedEvents.Content = new ListApprovedEvents(_eventManager, this);
                    tabAllEvents.IsSelected = true;
                    ToggleEventButtons();
                    break;
                }
                else
                {
                    DefaultUserSetUp();
                    ToggleEventButtons();
                }
            }
            if (_user.PURoles.Count == 0)
            {
                DefaultUserSetUp();
            }
        }

        /// <summary>
        /// 
        /// CREATED: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// A helper method to set up the basic member functionality
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        private void DefaultUserSetUp()
        {
            frApprovedEvents.Content = new ListApprovedEvents(_eventManager, this);
            tabApprovedEvents.IsSelected = true;
            tabAllEvents.Visibility = Visibility.Hidden;
            tabPendingEvents.Visibility = Visibility.Hidden;
            btnDeleteEvent.Visibility = Visibility.Hidden;
            btnReviewEvent.Visibility = Visibility.Hidden;

            btnEditEvent.IsEnabled = false;
            btnViewEventDetails.IsEnabled = false;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// The click event handler for Creating an Event (UC-606 & UC-633)
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
        private void btnCreateEvent_Click(object sender, RoutedEventArgs e)
        {
            frEventApprovalForm.Visibility = Visibility.Hidden;
            frCreateEditEvent.Visibility = Visibility.Visible;
            frCreateEditEvent.Content = new CreateEventForm(_eventManager, _user, this);
            grdCreateEditEvent.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// The click event handler for Editing an Event (UC-607)
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
        private void btnEditEvent_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frEventApprovalForm.Visibility = Visibility.Hidden;
                frCreateEditEvent.Visibility = Visibility.Visible;
                frCreateEditEvent.Content = new CreateEventForm(_eventManager, _user, this, _selectedEvent);
                grdCreateEditEvent.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// The click event handler for Deleting an Event (UC-608) ADMIN/DC ONLY
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
        private void btnDeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frmDeleteEvent deleteEventWindow = new frmDeleteEvent(_eventManager, _selectedEvent);
                deleteEventWindow.ShowDialog();
                if (deleteEventWindow.DialogResult == true)
                {
                    frAllEvents.Content = new ListAllEvents(_eventManager, this);
                    frPendingEvents.Content = new ListPendingEvents(_eventManager, this);
                    frApprovedEvents.Content = new ListApprovedEvents(_eventManager, this);
                    tabAllEvents.IsSelected = true;
                }
            }
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/3/08
        /// APPROVER: Ryan Morganti
        /// 
        /// The click event handler for Viewing an Event's details (partially UC-619)
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
        private void btnViewEventDetails_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frCreateEditEvent.Visibility = Visibility.Hidden;
                frEventApprovalForm.Visibility = Visibility.Visible;
                frEventApprovalForm.Content = new EventApprovalForm(_eventManager, _user, _selectedEvent, this);
                tabEventApprovalForm.IsSelected = true;
            }
        }

        /// <summary>
        /// 
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020\3\08
        /// APPROVER: Ryan Morganti
        /// 
        /// The click event handler for Reviewing an Event (UC-619)
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
        private void btnReviewEvent_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frCreateEditEvent.Visibility = Visibility.Hidden;
                frEventApprovalForm.Visibility = Visibility.Visible;
                frEventApprovalForm.Content = new EventApprovalForm(_eventManager, _user, _selectedEvent, this, true);
                tabEventApprovalForm.IsSelected = true;
            }
        }

        /// <summary>
        /// CREATOR: Steve Coonrod
        /// CREATED: 2020/4/23
        /// APPROVER: Matt Deaton
        ///  
        /// Display method to change the title displayed based on the active tab
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabAllEvents.IsSelected)
            {
                lblEventMgmtHeader.Content = "All Events";
            }
            else if (tabApprovedEvents.IsSelected)
            {
                lblEventMgmtHeader.Content = "Upcoming Events";
            }
            else if (tabPendingEvents.IsSelected)
            {
                lblEventMgmtHeader.Content = "Events Pending Approval";
            }
        }
    }
}
