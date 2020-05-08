using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.SystemAdminPages
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/20/2020
    /// Approver: Michael Thompson
    /// 
    /// This class controls UserControls page
    /// 
    /// </summary>
    public partial class UserControls : Page
    {
        private IERoleManager _eRoleManager;
        private IPetUniverseUserERolesManager _petUniverseUserERolesManager;
        private PetUniverseUser _petUniverseUser;
        private IUserManager _userManager;
        private bool _editMode = false;
        private bool _addMode = false;
        private PetUniverseUser _originalUser = null;
        private PetUniverseUser _loggedInUser = null;
        private IEmployeeAvailabilityManager _employeeAvailabilityManager;
        private List<EmployeeAvailability> availabilities = new List<EmployeeAvailability>();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/20/2020
        /// Approver: Michael Thompson
        /// 
        /// This is a constructor for the UserControls Page
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public UserControls()
        {
            _userManager = new UserManager();
            _employeeAvailabilityManager= new EmployeeAvailabilityManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Construct for when name in status bar is clicked
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public UserControls(PetUniverseUser user)
        {
            _userManager = new UserManager();
            _loggedInUser = _userManager.getUserByUserID(user.PUUserID);
            _employeeAvailabilityManager = new EmployeeAvailabilityManager();
            InitializeComponent();
            populateStates();
            viewUserInfo(_loggedInUser);
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Enables Fields to be editable
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void editMode()
        {
            _editMode = true;
            txtFirstName.IsReadOnly = false;
            txtLastName.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtPhoneNumber.IsReadOnly = false;
            txtAddress1.IsReadOnly = false;
            txtAddress2.IsReadOnly = false;
            txtCity.IsReadOnly = false;
            cmbState.IsEnabled = true;
            txtZipcode.IsReadOnly = false;
            if (!_addMode)
            {
                chkActive.IsEnabled = true;
            }
            else
            {
                chkActive.IsEnabled = false;
            }

            if (_loggedInUser != null)
            {
                chkActive.IsEnabled = false;
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Resets all fields back to original state.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void deactivateEditMode()
        {
            _editMode = false;
            txtFirstName.IsReadOnly = true;
            txtLastName.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
            txtPhoneNumber.IsReadOnly = true;
            txtAddress1.IsReadOnly = true;
            txtAddress2.IsReadOnly = true;
            txtCity.IsReadOnly = true;
            cmbState.IsEnabled = false;
            txtZipcode.IsReadOnly = true;
            chkActive.IsEnabled = false;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/14/2020
        /// Approver: Jordan Lindo
        /// 
        /// Method of general Error handling.
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/03/2020
        /// Update: Removes all inherited ERole fields
        
        /// Updater: Chase Schulte
        /// Updated: 04/10/2020 
        /// Update: Removed remove for EROLEs and HasViewedPolAndStan
        /// Approver: Kaleb Bachert
        
        /// Updated: 04/30/2020 
        /// Update: Removed security Q&A
        /// Approver: Steven Cardona
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUserList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            //Remove Security info
            dgUserList.Columns.RemoveAt(16);
            dgUserList.Columns.RemoveAt(15);
            dgUserList.Columns.RemoveAt(14);
            dgUserList.Columns.RemoveAt(13); 

            dgUserList.Columns.RemoveAt(12); //Remove HasViewedPolAndStan
            dgUserList.Columns.RemoveAt(6); //Remove Active
            dgUserList.Columns.RemoveAt(5); //Remove PURoles
            dgUserList.Columns[0].Header = "ID";
            dgUserList.Columns[1].Header = "First Name";
            dgUserList.Columns[2].Header = "Last Name";
            dgUserList.Columns[3].Header = "Phone Number";
            dgUserList.Columns[4].Header = "Email";
            dgUserList.Columns[5].Header = "Address Line 1";
            dgUserList.Columns[6].Header = "Address Line 2";
            dgUserList.Columns[7].Header = "City";
            dgUserList.Columns[8].Header = "State";
            dgUserList.Columns[9].Header = "ZipCode";

            // this fill all availalbe space with available columns
            foreach (var column in this.dgUserList.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }

            dgUserList.Columns[0].Width = 60;
            dgUserList.Columns[3].Width = 95;
            dgUserList.Columns[8].Width = 40;
            dgUserList.Columns[9].Width = 60;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/14/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// When dgUserList is loaded. Adds items into dgUserList.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUserList_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDgUserList();
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/14/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Adds items into dgUserList.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void RefreshDgUserList()
        {
            try
            {
                dgUserList.ItemsSource = _userManager.RetrieveAllActivePetUniverseUsers();
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.DataLoadErrorMessage(ex.Message, ex.InnerException.Message);
            }

        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/20/2020
        /// Approver: Jordan Lindo
        /// 
        /// Hides dgUserList and shows new canvas for creating users. Also adds enum values to cmbState items source
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/01/2020
        /// Update: Added disability for "btnViewUserRole"
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            canUserView.Visibility = Visibility.Hidden;
            canAddUser.Visibility = Visibility.Visible;
            btnViewUserRoles.IsEnabled = false;
            populateStates();

            _addMode = true;
            chkActive.IsChecked = true;
            editMode();
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Helper method that populates all the states into the combo box
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void populateStates()
        {
            foreach (var state in Enum.GetValues(typeof(States.StatesAb)))
            {
                cmbState.Items.Add(state);
            }
        }


        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Create a new user by clicking save
        /// </summary>
        /// <remarks>
        /// Updater: Steven Cardona
        /// Updated: 03/01/2020
        /// Update: Added Address validation checks
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            bool isCreated = false;

            PetUniverseUser newUser = new PetUniverseUser();

            // Validate First Name
            if (!txtFirstName.Text.IsValidFirstName())
            {
                "First Name cannot be blank".ErrorMessage("Validation");
                //WPFErrorHandler.ErrorMessage("First name cannot be blank", "Validation");
                txtFirstName.Text = "";
                txtFirstName.Focus();
                return;
            }
            else
            {
                newUser.FirstName = txtFirstName.Text;
            }

            // Validate Last Name
            if (!txtLastName.Text.IsValidLastName())
            {
                WPFErrorHandler.ErrorMessage("Last name cannot be blank", "Validation");
                txtLastName.Text = "";
                txtLastName.Focus();
                return;
            }
            else
            {
                newUser.LastName = txtLastName.Text;
            }

            // Validate Email 
            if (!txtEmail.Text.IsValidEmail())
            {
                WPFErrorHandler.ErrorMessage("Invalid email address", "Validation");
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }
            else
            {
                newUser.Email = txtEmail.Text;
            }

            // Validate Phone Number
            try
            {
                if (!txtPhoneNumber.Value.ToString().IsValidPhoneNumber())
                {
                    WPFErrorHandler.ErrorMessage("Invalid Phone Number", "Validation");
                    txtPhoneNumber.Text = "";
                    txtPhoneNumber.Focus();
                    return;
                }
                else
                {
                    newUser.PhoneNumber = txtPhoneNumber.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
                txtPhoneNumber.Text = "";
                txtPhoneNumber.Focus();
                return;
            }

            // Validate City
            if (!txtCity.Text.IsValidCity())
            {
                string message = string.IsNullOrEmpty(txtCity.Text)
                    ? "City cannot be blank"
                    : "City must be less than 20 characters long";
                WPFErrorHandler.ErrorMessage(message, "Validation");
                txtCity.Text = "";
                txtCity.Focus();
                return;
            }
            else
            {
                newUser.City = txtCity.Text;
            }

            // Validate State
            if (cmbState.SelectedItem == null || !cmbState.SelectedItem.ToString().IsValidState())
            {
                WPFErrorHandler.ErrorMessage("Please select a state", "Validation");
                cmbState.Focus();
                return;
            }
            else
            {
                newUser.State = cmbState.SelectedItem.ToString();
            }

            // Validate Zipcode
            try
            {
                if (!txtZipcode.Text.IsValidState())
                {
                    WPFErrorHandler.ErrorMessage("Invalid Zipcode", "Validation");
                    txtZipcode.Text = "";
                    txtZipcode.Focus();
                    return;
                }
                else
                {
                    newUser.ZipCode = txtZipcode.Text;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            try
            {
                if (!txtAddress1.Text.IsValidAddress1())
                {
                    WPFErrorHandler.ErrorMessage("Invalid Address Line 1", "Validation");
                    txtAddress1.Text = "";
                    txtAddress1.Focus();
                    return;
                }
                else
                {
                    newUser.Address1 = txtAddress1.Text;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            try
            {
                if (!txtAddress1.Text.IsValidAddress2())
                {
                    WPFErrorHandler.ErrorMessage("Invalid Address Line 2", "Validation");
                    txtAddress2.Text = "";
                    txtAddress2.Focus();
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtAddress2.Text))
                    {
                        newUser.Address2 = txtAddress2.Text;
                    }
                    else
                    {
                        newUser.Address2 = null;
                    }
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            newUser.Active = (bool)chkActive.IsChecked;

            try
            {
                if (_editMode == true && _originalUser == null)
                {
                    isCreated = _userManager.CreateNewUser(newUser);
                    if (isCreated)
                    {
                        WPFErrorHandler.SuccessMessage("Create new user was successful, add starting availability.");

                        canAddUser.Visibility = Visibility.Hidden;

                        canAddAvailability.Visibility = Visibility.Visible;


                    }
                    canAddUser.Visibility = Visibility.Hidden;
                }
                else if (_editMode == true && _originalUser != null)
                {
                    bool isUpdated = _userManager.UpdateUser(_originalUser, newUser);
                    if (isUpdated)
                    {
                        WPFErrorHandler.SuccessMessage("Information was updated for " + newUser.FirstName + " " +
                                                       newUser.LastName);
                    }

                    canAddUser.Visibility = Visibility.Hidden;
                    canUserView.Visibility = Visibility.Visible;
                }

                deactivateEditMode();
                RefreshDgUserList();
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.UserCreationErrorMessage(ex.Message, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/15/2020
        /// Approver: Jordan Lindo
        /// 
        /// Hides canNewUsers and shows canViewUsers.
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/01/2020
        /// Update: Added enability for "btnViewUserRole"
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            canAddUser.Visibility = Visibility.Hidden;
            canUserView.Visibility = Visibility.Visible;
            canViewUserERoles.Visibility = Visibility.Hidden;
            btnViewUserRoles.IsEnabled = true;
            btnCreateUser.IsEnabled = true;
            _originalUser = null;
            deactivateEditMode();
            _addMode = false;
            _loggedInUser = null;
            clearFields();
            RefreshDgUserList();
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// When User is select and Edit User is clicked loads canAddUser and places info in respective fields
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            _originalUser = (PetUniverseUser)dgUserList.SelectedItem;
            if (_originalUser != null)
            {
                canAddUser.Visibility = Visibility.Visible;
                canUserView.Visibility = Visibility.Hidden;
                canViewUserERoles.Visibility = Visibility.Hidden;

                populateStates();

                viewUserInfo(_originalUser);
                editMode();
            }
            else
            {
                WPFErrorHandler.ErrorMessage("No User Selected\n\nPlease Select A User", "Error");
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Add user information to respective fields in the Add/Edit canvas
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="user"></param>
        private void viewUserInfo(PetUniverseUser user)
        {
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmail.Text = user.Email;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtAddress1.Text = user.Address1;
            txtAddress2.Text = user.Address2;
            txtCity.Text = user.City;
            cmbState.Text = user.State;
            txtZipcode.SelectedText = user.ZipCode;
            chkActive.IsChecked = user.Active;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Clear all the fields in the Add/Edit Canvas
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void clearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            cmbState.Text = "";
            txtZipcode.Text = "";
            chkActive.IsChecked = false;
        }



        /************************************ View User's ERole ********************************************/
        /// <summary>
        /// Creator: Chase Schutle
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Allows a user to view a specific user's Eroles
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 04/10/2020 
        /// Update: Restored functionality
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnViewUserRoles_Click(object sender, RoutedEventArgs e)
        {
            if (dgUserList.SelectedItem != null)
            {
                try
                {
                    //Prepare canvas
                    canUserView.Visibility = Visibility.Hidden;
                    canAddUser.Visibility = Visibility.Hidden;
                    canViewUserERoles.Visibility = Visibility.Visible;
                    btnCreateUser.IsEnabled = false;
                    //Prepare canvas functionality
                    _eRoleManager = new ERoleManager();
                    _petUniverseUserERolesManager = new PetUniverseUserERolesManager();
                    _petUniverseUser = (PetUniverseUser)dgUserList.SelectedItem;
                    refreshListBox();
                    lblUserID.Content = _petUniverseUser.PUUserID.ToString();
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message);
                }
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please select a valid user");
            }
        }

        /// <summary>
        /// Creator: Chase Schutle
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Allows a user to assign a specific user's Eroles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAssign_Click(object sender, RoutedEventArgs e)
        {
            if (lbUnassignedERoles.SelectedItems.Count == 0)
            {
                WPFErrorHandler.ErrorMessage("Please selecte an unassigned role");
                return;
            }

            try
            {
                if (_petUniverseUserERolesManager.AddPetUniverseUserERole(_petUniverseUser.PUUserID,
                    lbUnassignedERoles.SelectedItem.ToString()))
                {
                    refreshListBox();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n", ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Chase Schutle
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Allows a user to unassign a specific user's Eroles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUnassign_Click(object sender, RoutedEventArgs e)
        {
            if (lbAssignedERoles.SelectedItems.Count == 0)
            {
                WPFErrorHandler.ErrorMessage("Please selecte an assigned role");
                return;
            }

            try
            {
                if (_petUniverseUserERolesManager.DeletePetUniverseUserERole(_petUniverseUser.PUUserID,
                    lbAssignedERoles.SelectedItem.ToString()))
                {
                    refreshListBox();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n", ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Chase Schutle
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Helper method to refresh listboxes after any type of relateed to a user's ERoles update
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshListBox()
        {
            try
            {
                var activeRole =
                    _petUniverseUserERolesManager.RetrievePetUniverseUserERolesByPetUniverseUser(_petUniverseUser
                        .PUUserID);
                lbAssignedERoles.ItemsSource = activeRole;
                List<string> roles = new List<string>();
                foreach (var item in _eRoleManager.RetrieveERolesByActive())
                {
                    roles.Add(item.ERoleID.ToString());
                }

                foreach (string role in activeRole)
                {
                    roles.Remove(role);
                }

                lbUnassignedERoles.ItemsSource = roles;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n", ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Display information for the user that was double clicked
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _originalUser = (PetUniverseUser)dgUserList.SelectedItem;
            if (_originalUser != null)
            {
                canAddUser.Visibility = Visibility.Visible;
                canUserView.Visibility = Visibility.Hidden;
                canViewUserERoles.Visibility = Visibility.Hidden;

                populateStates();

                viewUserInfo(_originalUser);
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 04/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method is used when already viewing a user details
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditUser2_Click(object sender, RoutedEventArgs e)
        {
            editMode();
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 04/09/2020
        /// Approver: Jordan Lindo
        /// 
        /// loading the canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canAddAvailability_Loaded(object sender, RoutedEventArgs e)
        {
            btnSaveAvail.IsEnabled = false;
            dgAvailability.ItemsSource = availabilities;
            string[] days =
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };
            cboDayOfWeek.ItemsSource = days;

        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 04/09/2020
        /// Approver: Jordan Lindo
        /// 
        /// populates list and datagrid with created availabilities.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToDataGrid_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAvailability availability = new EmployeeAvailability();
            try
            {
                if (cboDayOfWeek.SelectedItem == null)
                {
                    WPFErrorHandler.ErrorMessage("Day cannot be blank", "Validation");
                    cboDayOfWeek.Focus();
                    return;
                }
                else
                {
                    availability.DayOfWeek = cboDayOfWeek.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            try
            {
                if (TPStartTime.Value == null || TPStartTime.Value.ToString().Equals(""))
                {
                    WPFErrorHandler.ErrorMessage("StartTime cannot be blank", "Validation");
                    TPStartTime.Focus();
                    return;
                }
                else
                {
                    DateTime time = (DateTime)TPStartTime.Value;
                    availability.StartTime = time.ToString("HH:mm:ss"); ;

                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            try
            {
                if (TPEndTime.Value == null || TPEndTime.Value.ToString().Equals(""))
                {
                    WPFErrorHandler.ErrorMessage("EndTime cannot be blank", "Validation");
                    TPEndTime.Focus();
                    return;
                }
                else
                {
                    DateTime time = (DateTime)TPEndTime.Value;
                    availability.EndTime = time.ToString("HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }
            try
            {
                DateTime startTime = (DateTime)TPStartTime.Value;
                DateTime endTime = (DateTime)TPEndTime.Value;
                if (endTime <= startTime.AddMinutes(59))
                {
                    MessageBox.Show("Shifts must be at least 1Hour.");
                    TPStartTime.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            try
            {
                availability.EmployeeID = _employeeAvailabilityManager.RetrieveLastEmployeeID();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            try
            {
                List<EmployeeAvailability> newAvailabilities = new List<EmployeeAvailability>();
                bool failed = false;
                if (availabilities.Count != 0)
                {
                    foreach (EmployeeAvailability addedAvailability in availabilities)
                    {
                        if (availability.DayOfWeek == addedAvailability.DayOfWeek &&
                            availability.StartTime == addedAvailability.StartTime &&
                            availability.EndTime == addedAvailability.EndTime)
                        {
                            WPFErrorHandler.ErrorMessage("availability " + availability.DayOfWeek.ToString() + " " + availability.StartTime.ToString() + " " + availability.EndTime.ToString() + "  was a duplicate entry", "Validation");
                            failed = true;
                        }
                        else if (availability.DayOfWeek == addedAvailability.DayOfWeek)
                        {
                            DateTime newStartTime = DateTime.Parse(availability.StartTime);
                            DateTime newEndTime = DateTime.Parse(availability.EndTime);
                            DateTime addedEndTime = DateTime.Parse(addedAvailability.EndTime);
                            DateTime addedStartTime = DateTime.Parse(addedAvailability.StartTime);

                            if (newStartTime < addedEndTime)
                            {
                                if (newEndTime < addedStartTime != true)
                                {
                                    WPFErrorHandler.ErrorMessage("current availability " + availability.DayOfWeek.ToString() + " " + availability.StartTime.ToString() + " " + availability.EndTime.ToString() + " overlaps with "
                                                + addedAvailability.DayOfWeek.ToString() + " " + addedAvailability.StartTime.ToString() + " " + addedAvailability.EndTime.ToString(), "Validation");
                                    failed = true;
                                }
                                else
                                {
                                    newAvailabilities.Add(availability);
                                }
                            }
                            else
                            {
                                newAvailabilities.Add(availability);
                            }
                        }
                        else
                        {
                            newAvailabilities.Add(availability);
                        }
                    }
                }
                else
                {
                    newAvailabilities.Add(availability);
                }
                if (failed == false)
                {
                    availabilities.Add(newAvailabilities[0]);
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            dgAvailability.Items.Refresh();

            if (btnSaveAvail.IsEnabled != true)
            {
                btnSaveAvail.IsEnabled = true;
            }
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 04/09/2020
        /// Approver: Jordan Lindo
        /// 
        /// save button creates availbilities from lasi of availabilites
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAvail_Click(object sender, RoutedEventArgs e)
        {
            bool isCreated = false;
            foreach (EmployeeAvailability availability in availabilities)
            {
                try
                {


                    isCreated = _employeeAvailabilityManager.CreateNewEmployeeAvailability(availability);

                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
                }

            }
            if (isCreated)
            {
                WPFErrorHandler.SuccessMessage("Create new user availability was successful");
            }


            canAddAvailability.Visibility = Visibility.Hidden;
            canUserView.Visibility = Visibility.Visible;
            btnViewUserRoles.IsEnabled = true;


        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 04/09/2020
        /// Approver: Jordan Lindo
        /// 
        /// gets rid of unnesecary columns
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAvailability_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgAvailability.Columns.RemoveAt(5);
            dgAvailability.Columns.RemoveAt(1);
            dgAvailability.Columns.RemoveAt(0);
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 04/09/2020
        /// Approver: Jordan Lindo
        /// 
        /// click handler for viewing employee availabilities
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewUserAvailability_Click(object sender, RoutedEventArgs e)
        {
            if (dgUserList.SelectedItem != null)
            {
                try
                {

                    canUserView.Visibility = Visibility.Hidden;
                    canAddUser.Visibility = Visibility.Hidden;
                    canViewUserERoles.Visibility = Visibility.Hidden;
                    canViewAvailability.Visibility = Visibility.Visible;
                    btnCreateUser.IsEnabled = false;
                    //Prepare canvas functionality
                    _employeeAvailabilityManager = new EmployeeAvailabilityManager();
                    _petUniverseUser = (PetUniverseUser)dgUserList.SelectedItem;
                    updateDgViewAvailability();
                    lblHeader.Content = "Availabilities for: " + _petUniverseUser.LastName + ", " + _petUniverseUser.FirstName;



                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message);
                }
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please select a valid user");
            }
        }



        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Helper method to refresh listboxes after any type of relateed to a user's ERoles update
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateDgViewAvailability()
        {
            try
            {
                var availabilites = _employeeAvailabilityManager.RetrieveAvailabilitiesByEmployeeID(_petUniverseUser.PUUserID);
                dgViewAvailability.ItemsSource = availabilites;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n", ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// autogenerated columns to get rid of non human readable information
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewAvailability_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgViewAvailability.Columns.RemoveAt(5);
            dgViewAvailability.Columns.RemoveAt(1);
            dgViewAvailability.Columns.RemoveAt(0);
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// event for the back button press
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAvailBack_Click(object sender, RoutedEventArgs e)
        {
            canAddUser.Visibility = Visibility.Hidden;
            canUserView.Visibility = Visibility.Visible;
            canViewUserERoles.Visibility = Visibility.Hidden;
            canViewAvailability.Visibility = Visibility.Hidden;
            btnViewUserRoles.IsEnabled = true;
            btnCreateUser.IsEnabled = true;
            RefreshDgUserList();
        }

    }
}
