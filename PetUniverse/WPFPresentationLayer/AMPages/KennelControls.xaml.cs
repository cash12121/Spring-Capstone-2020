using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
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
    /// 
    /// Interaction logic for KennelControls.xaml
    /// </summary>
    public partial class KennelControls : Page
    {
        private IAnimalKennelManager _kennelManager;
        private bool addMode;
        private AnimalKennel oldKennel;
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
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public KennelControls()
        {
            InitializeComponent();
            _kennelManager = new AnimalKennelManager();

            addMode = false;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver:
        /// 
        /// Constructor for this page. Passes the user so the ID can auto-populate
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update:
        /// </remarks>
        public KennelControls(PetUniverseUser user)
        {
            InitializeComponent();
            this._user = user;
            _kennelManager = new AnimalKennelManager();

            addMode = false;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Switch to the subpage to add records.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLocationRecord_Click(object sender, RoutedEventArgs e)
        {
            canView.Visibility = Visibility.Hidden;
            canAddRecord.Visibility = Visibility.Visible;
            EnableEditingFields();
            addMode = true;
            lblTitle.Content = "Register New Kennel Record";
            txtUserID.Text = _user.PUUserID.ToString();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver:
        /// 
        /// Extracted method to enable all of the editing fields
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableEditingFields()
        {
            txtAnimalID.IsEnabled = true;
            txtKennelInfo.IsEnabled = true;
            txtUserID.IsEnabled = true;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Return to previous page.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/19/2020
        /// Update: Disables the AddDatOutButton now  
        /// Approver: Carl Davis, 3/19/2020
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelKennelAdd_Click(object sender, RoutedEventArgs e)
        {
            canViewKennelList.Visibility = Visibility.Visible;
            canAddRecord.Visibility = Visibility.Hidden;
            ResetFields();

            addMode = false;
            RefreshData();
            oldKennel = null;
            canView.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 5/06/2020
        /// Approver: Cash Carlson, 5/6/2020
        /// 
        /// Extracted method to reset all data fields between changing tabs.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// Approver: 
        /// </remarks>
        /// </summary>
        private void ResetFields()
        {
            txtAnimalID.Text = "";
            txtDateIn.Text = "";
            txtDateOut.Text = "";
            txtKennelID.Text = "";
            txtKennelInfo.Text = "";
            txtUserID.Text = "";

            txtAnimalID.IsEnabled = false;
            txtDateIn.IsEnabled = false;
            txtDateOut.IsEnabled = false;
            txtKennelInfo.IsEnabled = false;
            txtUserID.IsEnabled = false;
            btnAddDateOut.IsEnabled = false;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/22/2020
        /// Approver: Steven Cardona
        /// Approver:
        /// 
        /// Add animal kennel location record to the database 
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/17/2020
        /// Update: Added an extra code path for editing as opposed to adding.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitKennelAdd_Click(object sender, RoutedEventArgs e)
        {
            int userID;
            int animalID;

            if (String.IsNullOrEmpty(txtAnimalID.Text))
            {
                MessageBox.Show("Please enter the animal's ID");
                return;
            }
            if (String.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("Please enter the User's ID");
                return;
            }
            if (!int.TryParse(txtAnimalID.Text, out animalID))
            {
                MessageBox.Show("ID fields may only contain whole numbers.");
                return;
            }
            else if (!int.TryParse(txtUserID.Text, out userID))
            {
                MessageBox.Show("ID fields may only contain whole numbers.");
                return;
            }
            else
            {

                AnimalKennel newKennel = new AnimalKennel()
                {
                    AnimalID = animalID,
                    UserID = userID,
                    AnimalKennelInfo = txtKennelInfo.Text
                };

                try
                {
                    if (addMode)
                    {
                        newKennel.AnimalKennelDateIn = DateTime.Now;
                        _kennelManager.AddKennelRecord(newKennel);
                        WPFErrorHandler.SuccessMessage("Kennel Record Successfully Added");
                    }
                    else
                    {
                        newKennel.AnimalKennelDateIn = oldKennel.AnimalKennelDateIn;
                        newKennel.AnimalKennelDateOut = oldKennel.AnimalKennelDateOut;
                        _kennelManager.EditKennelRecord(oldKennel, newKennel);
                        WPFErrorHandler.SuccessMessage("Kennel Record Successfully Edited");
                    }

                    ResetFields();
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                }
                finally
                {
                    oldKennel = null;
                    RefreshData();

                }
                canView.Visibility = Visibility.Visible;
                canAddRecord.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// triggers the datagrid to refresh
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAllKennels_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Refreshes the datagrid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshData()
        {
            try
            {
                dgAllKennels.ItemsSource = _kennelManager.GetAllAnimalKennels();
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/13/2020
        /// Approver:  Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Selects a single kennel record for viewing.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAllKennels_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            oldKennel = (AnimalKennel)dgAllKennels.SelectedItem;

            txtAnimalID.Text = oldKennel.AnimalID.ToString();
            txtKennelID.Text = oldKennel.AnimalKennelID.ToString();
            txtUserID.Text = oldKennel.UserID.ToString();
            txtKennelInfo.Text = oldKennel.AnimalKennelInfo.ToString();
            txtDateIn.Text = oldKennel.AnimalKennelDateIn.ToString();
            txtDateOut.Text = oldKennel.AnimalKennelDateOut.ToString();

            BtnSubmitkennelAdd.Visibility = Visibility.Hidden;
            BtnEditKennelAdd.Visibility = Visibility.Visible;

            lblTitle.Content = "View Kennel Record Details";

            canAddRecord.Visibility = Visibility.Visible;
            canView.Visibility = Visibility.Hidden;
            if (oldKennel.AnimalKennelDateOut == null)
            {
                btnAddDateOut.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/17/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Edit button for enabling editing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditKennelAdd_Click(object sender, RoutedEventArgs e)
        {

            BtnSubmitkennelAdd.Visibility = Visibility.Visible;
            BtnEditKennelAdd.Visibility = Visibility.Hidden;

            lblTitle.Content = "Editing Kennel Record Details";

            EnableEditingFields();

            btnAddDateOut.IsEnabled = (null == oldKennel.AnimalKennelDateOut);
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/19/2020
        /// Approver: 
        /// 
        /// Triggers the logic to add the DateOut field to the record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDateOut_Click(object sender, RoutedEventArgs e)
        {
            oldKennel.AnimalKennelDateOut = DateTime.Now;

            try
            {
                if (_kennelManager.SetDateOut(oldKennel))
                {
                    btnAddDateOut.IsEnabled = false;
                    txtDateOut.Text = oldKennel.AnimalKennelDateOut.ToString();

                    WPFErrorHandler.SuccessMessage("Date Out successfully addded.");
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }
    }
}
