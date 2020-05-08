using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFPresentationLayer.AMPages;
using WPFPresentationLayer.FMPages;
using WPFPresentationLayer.PoSPages;
using WPFPresentationLayer.RecruitingPages;
using WPFPresentationLayer.SystemAdminPages;

namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/5/2020
    /// Approver: Steven Cardona
    /// 
    /// This class has interaction logic for the PetUniverseHome window
    /// 
    /// </summary>
    public partial class PetUniverseHome : Window
    {
        private string desiredScreen;
        private string userRoles;
        private PetUniverseUser _user;
        private IUserManager _userManager;
        private ILogManager _logManager = new LogManager();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This constructor should only be used for testing. We do not want 
        /// to create this without someone properly being logged in.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public PetUniverseHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This constructor is passed a userid and roles and will control what the user can see and do
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: Steven Cardona
        /// Updated: 02/14/2020
        /// Update: Initialized new UserManger to private _userManager variable
        /// Approver: Zach Behrensmeyer
        /// 
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="userRoles"></param>
        public PetUniverseHome(PetUniverseUser user, string userRoles)
        {
            this._user = user;
            this.userRoles = userRoles;
            InitializeComponent();
            bool isASupervisor = userIsASupervisor();
            bool isAManager = _user.PURoles.Contains("Manager");
            if (isASupervisor || isAManager)
            {
                btnPersonnelManagement.Visibility = Visibility.Visible;
            }
            this.ShowDialog();
            _userManager = new UserManager();

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 5/6/2020
        /// Approver: Kaleb Bachert
        /// 
        /// This method tests if the user is a supervisor.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// 
        /// </remarks>
        private bool userIsASupervisor()
        {
            bool result = false;
            for (int i = 0; i < _user.PURoles.Count && !result; i++)
            {
                string roleId = _user.PURoles[i];
                if (roleId.Contains("Supervisor"))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the inventory content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Inventory";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the animnal management content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/1/2020
        /// Update: Now calls a constructor so the user can be tracked.
        /// Approver: Chuck Baxter, 3/5/2020
        /// 
        /// Updater: Ben Hanna
        /// Updated: 3/19/2020
        /// Update Added constructor for the kennel records frame for passing the user.
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAM_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Animal Management";
            switchScreen(desiredScreen);
            frameViewKennelRecords.Content = new KennelControls(_user);
            frameViewHandlingNotes.Content = new HandlingControls(_user);
            frameViewVetAppointments.Content = new VetAppointmentControls(_user);
            frameViewAnimalActivities.Content = new AnimalActivityRecords(_user);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the point of sale content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPoS_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Point of Sale";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the volunteer hub content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolHub_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Volunteer Hub";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the system admin content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSysAdmin_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "System Admin";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for logging the user out
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LogHelper.log.Info("User : " + _user.FirstName + " " + _user.LastName + " has logged out.");
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();

        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This is a helper method to decide which canvas should be shown.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: Steven Cardona
        /// Updated: 02/15/2020
        /// Update: Added canViewUsers.Visibility = Visibility.Visible; to SysAdmin Case
        /// 
        /// Updater: Carl Davis
        /// Updated: 02/21/2020
        /// Update: Added facility maintenance switch case
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="screenName"></param>
        private void switchScreen(string screenName)
        {
            switch (screenName)
            {
                case "Inventory":
                    canInventory.Visibility = Visibility.Visible;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Animal Management":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Visible;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Facility Management":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Visible;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Point of Sale":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Visible;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Volunteer Hub":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Visible;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "System Admin":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Visible;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Requests":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Visible;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Adoptions":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Visible;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Donations":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Visible;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Personnel":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Visible;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
                case "Messages":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Visible;
                    break;
                default:
                    canInventory.Visibility = Visibility.Visible;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    canMessages.Visibility = Visibility.Hidden;
                    break;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is called when the request button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            //frNewRequestList.Content = new RecruitingPages.ListNewRequests(_user);
            //frActiveRequestList.Content = new RecruitingPages.ListActiveRequests(_user);
            //frCompleteRequestList.Content = new RecruitingPages.ListCompleteRequests(_user);
            frListRequests.Content = new RecruitingPages.ListRequests(_user);

            desiredScreen = "Requests";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is called when the window loads
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblStatusBar.Content = "Welcome " + _user.LastName + ", " + _user.FirstName;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/20/2020
        /// Approver: Michael Thompson
        /// 
        /// This is a method to show the adoptions canvas
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="screenName"></param>
        private void BtnAdoptions_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Adoptions";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Steven Coonrod
        /// Created: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method is called when the donations button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDonRec_Click(object sender, RoutedEventArgs e)
        {
            //Added to allow the user object to be passed to the EventMgmt page
            fEventMgmt.Content = new EventMgmt(_user);
            if (_user.PURoles.Contains("Administrator") || _user.PURoles.Contains("Manager"))
            {
                tabSocialMediaRequest.Visibility = Visibility.Visible;
                frRequestSocialMedia.Content = new RecruitingPages.SocialMediaRequestForm(this, _user);
            }
            else
            {
                tabSocialMediaRequest.Visibility = Visibility.Hidden;
            }
            desiredScreen = "Donations";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Creaed: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method is called when the Personnel button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: 3/27/2020
        /// Update: Added base schedule frame
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPersonnelManagement_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Personnel";
            switchScreen(desiredScreen);
            if (_user.PURoles.Contains("Manager"))
            {
                frBaseSchedule.Content = new PersonnelPages.BaseScheduleControls(_user);
                frSchedule.Content = new PersonnelPages.Schedule(_user);
                tabSchedule.Visibility = Visibility.Visible;
                tabBaseSchedule.Visibility = Visibility.Visible;
                tabShiftTimeManager.Visibility = Visibility.Visible;
                tabViewAllERoles.Visibility = Visibility.Visible;
                tabDepartment.Visibility = Visibility.Visible;
            }
            else if (userIsASupervisor())
            {
                frSupervisorSchedule.Content = new PersonnelPages.pgSupervisorSchedule(_user);
                tabSupervisorSchedule.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson 
        /// 
        /// Loads check out page into the frame.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabCheckOut_Loaded(object sender, RoutedEventArgs e)
        {
            if (frmCheckOut == null)
            {
                frmCheckOut = new Frame();
                tabCheckOut.Content = frmCheckOut;
            }
            if (frmCheckOut.Content == null)
            {
                frmCheckOut.Navigate(new pgCheckOut());
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Chuck Baxter
        /// 
        /// This method is called when the Facility Management button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: Carl Davis
        /// Updated: 3/4/2020
        /// Update: Passed the logged in user through the constructor
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// Updater: Ben Hanna 
        /// Updated: 4/2/2020
        /// Update: Added the cleaning records tab.
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Updater: Carl Davis
        /// Updated: 4/2/2020
        /// Update: Added the inspection items tab.
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFm_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Facility Management";
            switchScreen(desiredScreen);
            frameViewFacilityInspection.Content = new FacilityInspectionControls(_user);
            frameViewFacilityMaintenance.Content = new FacilityMaintenanceControls(_user);
            frameViewKennelCleaningRecords.Content = new pgAnimalKennelCleaningControls(_user);
            frameViewFacilityInspectionItem.Content = new FacilityInspectionItemControls(_user);
            frameViewFacilityTask.Content = new FacilityTaskControls(_user);
        }


        /// <summary>
        /// Creator : Kaleb Bachert
        /// Created: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method is called when the PersonnelRequests Tab is loaded
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tabViewPersonnelRequests_Loaded(object sender, RoutedEventArgs e)
        {
            frmViewPersonnelRequests.Content = new PersonnelPages.ViewPersonnelRequests(_user);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: 
        /// 
        /// Method to load the promotions page into the frame.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPromotions_Loaded(object sender, RoutedEventArgs e)
        {
            if (frmPromotions == null)
            {
                frmPromotions = new Frame();
                tabPromotions.Content = frmPromotions;
            }
            if (frmPromotions.Content == null)
            {
                frmPromotions.Navigate(new pgPromotion(frmPromotions));
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Method to load the Messages page into the frame.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 

        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessages_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Messages";
            switchScreen(desiredScreen);

            FrameMessages.Content = new pgMessages(_user);
        }

        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Loads data into the frame in a way that allows navigation.
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryItems_Loaded(object sender, RoutedEventArgs e)
        {
            if (frmInventoryItems == null)
            {
                frmInventoryItems = new Frame();
                InventoryItems.Content = frmInventoryItems;
            }
            if (frmInventoryItems.Content == null)
            {
                frmInventoryItems.Navigate(new PoSPages.pgInventoryItems(frmInventoryItems));
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/03/26
        /// Approver: Rasha Mohammed
        /// 
        /// Method to load the open transaction page into the frame.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabOpenTransaction_Loaded(object sender, RoutedEventArgs e)
        {
            frmOpenTransaction.Content = new pgOpenTransaction(_user);
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver:
        /// 
        /// When mouse up on lblStatusBar will bring up canAdduser to view logged in user Information
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatusBar_MouseUp(object sender, MouseButtonEventArgs e)
        {

            canInventory.Visibility = Visibility.Hidden;
            canAM.Visibility = Visibility.Hidden;
            canFM.Visibility = Visibility.Hidden;
            canPoS.Visibility = Visibility.Hidden;
            canVolHub.Visibility = Visibility.Hidden;
            canRequests.Visibility = Visibility.Hidden;
            canSysAd.Visibility = Visibility.Visible;
            canAdoptions.Visibility = Visibility.Hidden;
            canDonRec.Visibility = Visibility.Hidden;
            canPersonnel.Visibility = Visibility.Hidden;
            txtWelcome.Visibility = Visibility.Hidden;
            canMessages.Visibility = Visibility.Hidden;
            tabViewUsers.Focus();
            UserControls userControls = new UserControls(_user);
            userControls.canViewUserERoles.Visibility = Visibility.Hidden;
            userControls.canUserView.Visibility = Visibility.Hidden;
            userControls.canAddUser.Visibility = Visibility.Visible;
            frmUserControls.Content = userControls;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver:
        /// 
        /// Changes Cursor when hovered over label
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatusBar_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Changes Cursor when not hovering over label
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblStatusBar_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/29/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Closes program
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
