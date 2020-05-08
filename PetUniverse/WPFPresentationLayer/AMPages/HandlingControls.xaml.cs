using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Ben Hanna
    /// Created: 2/22/2020
    /// Approver: Steven Cardona 
    /// Approver: 
    /// 
    /// Interaction logic for HandlingControls.xaml
    /// </summary>
    public partial class HandlingControls : Page
    {
        private AnimalHandlingNotes _oldNotes;
        private IAnimalHandlingManager _handlingManager;
        private IAnimalManager _animalManager;

        bool _updateMode;
        private PetUniverseUser _user;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Constructor for this page.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/2/2020
        /// Update: Added a statement to set _updateMode to false, as well as a user object to populate the UserID field.
        /// Approver: Chuck Baxter, 3/5/2020
        /// </remarks>
        public HandlingControls(PetUniverseUser user)
        {

            InitializeComponent();
            this._user = user;
            _oldNotes = new AnimalHandlingNotes();
            _handlingManager = new AnimalHandlingManager();
            _animalManager = new AnimalManager();

            _updateMode = false;
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/5/2020
        /// Approver: 
        /// Approver:Chuck Baxter, 3/5/2020
        /// 
        /// Remade original constructor so the program wont throw an error when the home page is loaded.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public HandlingControls()
        {
            InitializeComponent();
            _oldNotes = new AnimalHandlingNotes();
            _handlingManager = new AnimalHandlingManager();
            _animalManager = new AnimalManager();

            _updateMode = false;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Double click handling notes datagrid to select a set of handling notes records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgHandlingNotesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _oldNotes = (AnimalHandlingNotes)dgHandlingNotesList.SelectedItem;

            txtHandlingNotesID.Text = _oldNotes.HandlingNotesID.ToString();
            txtAnimalID.Text = _oldNotes.AnimalID.ToString();
            txtUserID.Text = _oldNotes.UserID.ToString();
            txtHandlingNotes.Text = _oldNotes.HandlingNotes;
            txtTemperment.Text = _oldNotes.TemperamentWarning;
            dpHandlingUpdateDate.SelectedDate = _oldNotes.UpdateDate;

            btnUpdateRecord.IsEnabled = true;
            btnUpdateRecord.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Search for handling notes by the animal's primary key
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna 
        /// Updated: 3/5/2020
        /// Update: Extracted the method so the code can be called Elsewhere
        /// Approver: Chuck Baxter, 3/5/2020
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchForHandling_Click(object sender, RoutedEventArgs e)
        {
            RefreshHandlingNotes();

        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/5/2020
        /// Approver:  Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Extracted method to be used elsewhere.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshHandlingNotes()
        {
            int animalID;
            if (!int.TryParse(txtSearchForHandling.Text, out animalID))
            {
                MessageBox.Show("ID fields may not contain anything but an integer number");
                return;
            }
            else
            {
                dgHandlingNotesList.ItemsSource = _handlingManager.GetAllHandlingNotesByAnimalID(animalID);
                dgHandlingNotesList.Columns[4].Visibility = Visibility.Hidden;
                dgHandlingNotesList.Columns[3].Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Locks the grid to read only
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgHandlingNotesList.IsReadOnly = true;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/01/2020
        /// Approver:  Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Enables all details fields for data entry, hides itself, 
        /// and triggers btnSubmithandlingRecords to be both visible and enabled.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddHandlingRecord_Click(object sender, RoutedEventArgs e)
        {
            txtUserID.Text = _user.PUUserID.ToString();
            _updateMode = false;
            ActivateEditingFields();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/01/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// The extracted method that does all the work for btnAddhandlingRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ActivateEditingFields()
        {

            btnAddHandlingRecord.Visibility = Visibility.Hidden;
            btnSubmitHandlingRecord.Visibility = Visibility.Visible;
            btnUpdateRecord.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Visible;

            txtAnimalID.IsEnabled = true;
            txtHandlingNotes.IsEnabled = true;
            txtTemperment.IsEnabled = true;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/2/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Does the validation, then creates a handling record object and passes it to the manager class to be added to the database. 
        /// Then, the button hides itself and unhides and reenables the original buttons
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 5/1/2020
        /// Update: Added a validation fixes to verivy the animal ID exists in the DB
        /// Approver: Ryan Morganti, 5/3/2020
        /// </remarks>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 5/6/2020
        /// Update: Made validation feedback more clear.
        /// Approver: Cash Carlson, 5/6/2020
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitHandlingRecord_Click(object sender, RoutedEventArgs e)
        {
            bool animalExists = false;
            int animalID;
            int userID;
            List<Animal> animals = _animalManager.RetrieveAllAnimalProfiles();



            if (String.IsNullOrEmpty(txtAnimalID.Text))
            {
                MessageBox.Show("Please enter the animal's ID.");
                return;
            }
            if (String.IsNullOrEmpty(txtHandlingNotes.Text))
            {
                MessageBox.Show("Please enter some handling notes for this animal.");
                return;
            }
            if (String.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("Please enter the Current User's ID.");
                return;
            }
            if (String.IsNullOrEmpty(txtTemperment.Text))
            {
                MessageBox.Show("Please describe the temperament of the animal.");
                return;
            }
            if (!int.TryParse(txtAnimalID.Text, out animalID))
            {
                MessageBox.Show("ID fields may only contain whole number values.");
                return;
            }
            else if (!int.TryParse(txtUserID.Text, out userID))
            {
                MessageBox.Show("ID fields may only contain whole number values.");
                return;
            }
            else
            {

                foreach (Animal a in animals)
                {
                    if (a.AnimalID == animalID)
                    {
                        animalExists = true;
                        break;
                    }
                }

                if (animalExists)
                {
                    try
                    {

                        AnimalHandlingNotes newNotes = new AnimalHandlingNotes()
                        {
                            AnimalID = animalID,
                            UserID = userID,
                            HandlingNotes = txtHandlingNotes.Text,
                            TemperamentWarning = txtTemperment.Text,
                            UpdateDate = DateTime.Now
                        };

                        if (_updateMode)
                        {
                            if (_handlingManager.EditAnimalHandlingNotes(_oldNotes, newNotes))
                            {
                                MessageBox.Show("Record Edited Successfully.", "Result");
                            }
                            RefreshHandlingNotes();
                        }
                        else
                        {
                            if (_handlingManager.AddAnimalHandlingNotes(newNotes))
                            {
                                MessageBox.Show("Data Added Successfully.", "Result");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                    }
                    finally
                    {
                        DeactivateEditingFields();
                    }
                }
                else
                {
                    MessageBox.Show("Specified animal does not exist in Database.");
                    return;
                }
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/2/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Unenable the editing fields for this form and set the buttons back to initial conditions
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DeactivateEditingFields()
        {
            btnAddHandlingRecord.Visibility = Visibility.Visible;
            btnSubmitHandlingRecord.Visibility = Visibility.Hidden;
            btnUpdateRecord.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Hidden;


            txtAnimalID.IsEnabled = false;
            txtHandlingNotes.IsEnabled = false;
            txtTemperment.IsEnabled = false;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/2/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Sets the page back to where it started.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _updateMode = false;
            DeactivateEditingFields();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/2/2020
        /// Approver: Chuck Baxter, 3/5/2020
        /// Approver:
        /// 
        /// Calls a method to enable the fields to be typed in, 
        /// and sets update mode to true so the program knows it's gonna update an existing record, not create a new one
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            _updateMode = true;
            ActivateEditingFields();
        }
    }
}
