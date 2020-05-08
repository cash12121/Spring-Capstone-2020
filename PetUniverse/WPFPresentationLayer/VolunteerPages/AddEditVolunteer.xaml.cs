using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
	/// Creator: Josh J
	/// Created: 2020/02/28
	/// Approver Zoey M
	///
	/// Page for adding and editing volunteer records
	/// </summary>
    public partial class AddEditVolunteer : Page
    {
        private Volunteer _volunteer = null;
        private IVolunteerManager _volunteerManager = null;
        private bool _addMode = false;
        private Foster _foster = null;

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Zoey M
        /// This is the constructor which accepts an IVolunteerManager object, this should open the window in add mode
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public AddEditVolunteer(IVolunteerManager volunteerManager)
        {
            InitializeComponent();
            _volunteerManager = volunteerManager;
            _addMode = true;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Zoey M
        /// This is the constructor which accepts a Volunteer object and an IVolunteerManager object, this should open the window in edit mode
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public AddEditVolunteer(Volunteer volunteer, IVolunteerManager volunteerManager)
        {
            InitializeComponent();
            _volunteer = volunteer;
            _volunteerManager = volunteerManager;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Zoey M
        /// Some simple logic that changes input permissions based on whether the window was opened in add/edit mode
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh Jackson
        /// UPDATE DATE: 03/06/2020
        /// WHAT WAS CHANGED: Set fields in edit mode
        /// </remarks>
        private void ViewVolunteer_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_addMode == false)
                {
                    SetEditMode();
                    txtVolunteerID.Text = _volunteer.VolunteerID.ToString();
                    txtFirstName.Text = _volunteer.FirstName;
                    txtLastName.Text = _volunteer.LastName;
                    txtEmailAddress.Text = _volunteer.Email;
                    txtPhoneNumber.Text = _volunteer.PhoneNumber;
                    txtNotes.Text = _volunteer.OtherNotes;
                    chkActive.IsChecked = _volunteer.Active;
                    populateSkills();
                    if (gridFoster.Visibility == Visibility.Visible)
                    {
                        txtAdd1.Text = _foster.AddressLineOne;
                        txtAdd2.Text = _foster.AddressLineTwo;
                        txtCity.Text = _foster.City;
                        txtState.Text = _foster.State;
                        txtZip.Text = _foster.Zip;
                    }
                }
                else
                {
                    SetEditMode();
                    chkActive.IsChecked = true;
                    chkActive.IsEnabled = false;
                    lstUnassignedSkills.IsEnabled = false;
                    lstAssignedSkills.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Zoey M
        /// This method makes the Volunteer Record fields editable
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        private void SetEditMode()
        {
            txtFirstName.IsReadOnly = false;
            txtLastName.IsReadOnly = false;
            txtEmailAddress.IsReadOnly = false;
            txtPhoneNumber.IsReadOnly = false;
            txtNotes.IsReadOnly = false;
            chkActive.IsEnabled = true;
            lstUnassignedSkills.IsEnabled = true;
            lstAssignedSkills.IsEnabled = true;
            btnSave.Visibility = Visibility.Visible;
            txtFirstName.Focus();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Zoey M
        /// This method populates the lstUnassignedSKills with the skills that a volunteer could have
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        private void populateSkills()
        {
            try
            {
                var vSkills = _volunteerManager.GetVolunteerSkillsByID(_volunteer.VolunteerID);
                lstAssignedSkills.ItemsSource = vSkills;

                var skills = _volunteerManager.GetAllSkills();
                foreach (string r in vSkills)
                {
                    skills.Remove(r);
                }
                lstUnassignedSkills.ItemsSource = skills;

                if (lstAssignedSkills.Items.Contains("Foster"))
                {
                    rowSkills.Height = new GridLength(115);
                    rowFoster.Height = new GridLength(260);
                    gridFoster.Visibility = Visibility.Visible;
                    int volunteerID = _volunteer.VolunteerID;
                    _foster = _volunteerManager.GetFosterDetailsByVolunteerID(volunteerID);
                }
                else
                {
                    rowSkills.Height = new GridLength(375);
                    rowFoster.Height = new GridLength(0);
                    gridFoster.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Zoey M
        /// This validates the data entered into the Volunteer Record fields and passes the values to be added to the database upon pressing
        /// the save button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh J
        /// UPDATE DATE: 2020/03/28
        /// WHAT WAS CHANGED: Changed how the save button interacts with the Pages.
        /// </remarks>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("You must enter a first name.");
                txtFirstName.Focus();
                return;
            }
            if (txtLastName.Text == "")
            {
                MessageBox.Show("You must enter a last name.");
                txtLastName.Focus();
                return;
            }
            if (txtPhoneNumber.Text.ToString().Length > 12)
            {
                MessageBox.Show("You must enter a valid phone number.");
                txtPhoneNumber.Focus();
                return;
            }
            if (txtEmailAddress.Text.ToString().Length < 7)
            {
                MessageBox.Show("You must enter a valid email address.");
                txtEmailAddress.Focus();
                return;
            }
            if (!(txtEmailAddress.Text.ToString().Contains("@")
                  && txtEmailAddress.Text.ToString().Contains(".")))
            {
                MessageBox.Show("You must enter a valid email address.");
                txtEmailAddress.Focus();
                return;
            }
            if ((txtNotes.Text.Length >= 2000))
            {
                MessageBox.Show("Character limit reached for field: Notes - Try again");
                txtNotes.Focus();
                return;
            }

            if (gridFoster.Visibility == Visibility.Visible)
            {
                if (txtAdd1.Text.Length > 500)
                {
                    MessageBox.Show("Character limit reached for field: Address Line One - Try again");
                    txtAdd1.Focus();
                    return;
                }
                if (txtAdd1.Text.Length < 5)
                {
                    MessageBox.Show("Insufficient number of characters for field: Address Line One - Try again");
                    txtAdd1.Focus();
                    return;
                }
                if (txtAdd2.Text.Length > 100)
                {
                    MessageBox.Show("Character limit reached for field: Address Line Two - Try again");
                    txtAdd2.Focus();
                    return;
                }
                if (txtCity.Text.Length > 200)
                {
                    MessageBox.Show("Character limit reached for field: City - Try again");
                    txtCity.Focus();
                    return;
                }
                if (txtCity.Text.Length < 3)
                {
                    MessageBox.Show("Insufficient number of characters for field: City - Try again");
                    txtCity.Focus();
                    return;
                }
                if (txtState.Text.Length != 2)
                {
                    MessageBox.Show("Incorrect format for field: State - Hint: Try abbreviating (Al, IA, etc.)");
                    txtState.Focus();
                    return;
                }
                if (txtZip.Text.Length != 5)
                {
                    MessageBox.Show("Incorrect format for field: Zipcode - Try again");
                    txtZip.Focus();
                    return;
                }
            }

            Foster newFoster = null;

            Volunteer newVolunteer = new Volunteer()
            {
                FirstName = txtFirstName.Text.ToString(),
                LastName = txtLastName.Text.ToString(),
                PhoneNumber = txtPhoneNumber.Text.ToString(),
                Email = txtEmailAddress.Text.ToString(),
                OtherNotes = txtNotes.Text.ToString(),
                Active = (bool)chkActive.IsChecked
            };

            if(gridFoster.Visibility == Visibility.Visible) {
                newFoster = new Foster()
                {
                    VolunteerID = _volunteer.VolunteerID,
                    AddressLineOne = txtAdd1.Text.ToString(),
                    AddressLineTwo = txtAdd2.Text.ToString(),
                    City = txtCity.Text.ToString(),
                    State = txtState.Text.ToString(),
                    Zip = txtZip.Text.ToString(),
                };
            }
            

            if (_addMode)
            {
                try
                {
                    if (_volunteerManager.AddVolunteer(newVolunteer))
                    {
                        this.NavigationService?.Navigate(new ViewVolunteers());
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
                try
                {
                    _volunteerManager.UpdateVolunteer(_volunteer, newVolunteer);
                    if (gridFoster.Visibility == Visibility.Visible)
                    {
                        if (_foster == null)
                        {
                            _volunteerManager.CreateFoster(_volunteer, newFoster);
                        }
                        else
                        {
                            _volunteerManager.UpdateFoster(_foster, newFoster);
                        }
                    }
                    this.NavigationService?.Navigate(new ViewVolunteers());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n"
                        + ex.InnerException.Message);
                }
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Zoey M
        /// This method closes the AddEditVolunteerRecord window without passing any values upon pressing the cancel button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh Jackson
        /// UPDATE DATE: 2020/02/28
        /// WHAT WAS CHANGED: Changed the cancel implementation to work with the pages
        /// </remarks>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string warning = "You have unsaved changes that will be lost";
                if (MessageBox.Show("Are you sure?", warning,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    return;
                }
                this.NavigationService?.Navigate(new ViewVolunteers());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n"
                    + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// This method changes the value of a volunteers active status when the check box is clicked
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void chkActive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caption = (bool)chkActive.IsChecked ? "Reactivate Employee" :
                    "Deactivate Employee";
                if (MessageBox.Show("Are you sure?", caption,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    chkActive.IsChecked = !(bool)chkActive.IsChecked;
                    return;
                }

                _volunteerManager.ChangeVolunteerActiveStatus((bool)chkActive.IsChecked, _volunteer.VolunteerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n"
                    + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// This method adds a skill to a volunteers skill set when the skill is selected
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void LstUnassignedSkills_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_addMode || lstUnassignedSkills.SelectedItems.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Are you sure?", "Change Skill Assignment",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
            {
                return;
            }

            try
            {
                if (_volunteerManager.AddVolunteerSkill(_volunteer.VolunteerID,
                    (string)lstUnassignedSkills.SelectedItem))
                {
                    populateSkills();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 03/12/2020
        /// Checked By: Timothy Lickteig
        /// This method adds a skill to a volunteers skill set when the skill is selected
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void LstAssignedSkills_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_addMode || lstAssignedSkills.SelectedItems.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Are you sure?", "Change Skill Assignment",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
            {
                return;
            }
            try
            {
                if (_volunteerManager.DeleteVolunteerSkill(_volunteer.VolunteerID,
                    (string)lstAssignedSkills.SelectedItem))
                {
                    populateSkills();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }
    }
}
