using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Interaction logic for frmanimals.xaml
    /// </summary>
    public partial class AnimalControls : Page
    {


        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// constructor for animal controls
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalControls()
        {
            InitializeComponent();
            _animalManager = new AnimalManager();
        }

        private IAnimalManager _animalManager;
        private Animal selectedAnimal;
        private AnimalNames an;

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// opens the add animal canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            canAddAnimal.Visibility = Visibility.Visible;
            cmbAnimalSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// When the window is loaded the data grid is also loaded with its info
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshActiveData();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// The method that calls the manager method to get the active data for the data grid
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 3/6/2020
        /// Update: Corrected the data grid column headers
        /// Approver: Carl Davis, 3/6/2020
        /// </remarks>
        private void refreshActiveData()
        {
            dgActiveAnimals.ItemsSource = _animalManager.RetrieveAnimalsByActive();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method that calls the manager method to get the inactive data for the data grid
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 3/6/2020
        /// Update: Corrected the data grid column headers
        /// Approver: Carl Davis, 3/6/2020
        /// </remarks>
        private void refreshInactiveData()
        {
            dgActiveAnimals.ItemsSource = _animalManager.RetrieveAnimalsByInactive();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method that checks if the check box is checked or not and will call the correct
        /// method to supply the data grid with the correct data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void chkActive_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chkActive.IsChecked)
            {
                refreshInactiveData();
            }
            else
            {
                refreshActiveData();
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method opens the add animal canvas
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSubmitAnimalAdd_Click(object sender, RoutedEventArgs e)
        {
            string arrival = cndArrivalDate.SelectedDate.ToString();
            string dob = cndDob.SelectedDate.ToString();
            if (String.IsNullOrEmpty(txtAnimalName.Text))
            {
                MessageBox.Show("Please enter the animal's name");
                return;
            }
            if (String.IsNullOrEmpty(txtAnimalBreed.Text))
            {
                MessageBox.Show("Please enter the animal's breed");
                return;
            }
            if (String.IsNullOrEmpty(cmbAnimalSpecies.Text))
            {
                MessageBox.Show("Please enter the animal's species");
                return;
            }
            if (String.IsNullOrEmpty(arrival))
            {
                MessageBox.Show("Please enter the animal's arrival date");
                return;
            }
            if (String.IsNullOrEmpty(dob))
            {
                cndDob.SelectedDate = DateTime.Parse("01/01/2000");
                return;
            }

            Animal newAnimal = new Animal();

            newAnimal.AnimalName = txtAnimalName.Text;
            newAnimal.AnimalSpeciesID = cmbAnimalSpecies.Text;
            newAnimal.AnimalBreed = txtAnimalBreed.Text;
            newAnimal.ArrivalDate = (DateTime)cndArrivalDate.SelectedDate;
            newAnimal.Dob = (DateTime)cndDob.SelectedDate;

            try
            {
                if (_animalManager.AddNewAnimal(newAnimal))
                {
                    WPFErrorHandler.SuccessMessage("Animal Successfully Added");

                    canViewAnimalList.Visibility = Visibility.Visible;
                    canAddAnimal.Visibility = Visibility.Hidden;
                    refreshActiveData();
                    chkActive.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canViewAnimalList.Visibility = Visibility.Visible;
                canAddAnimal.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The method that cancels the add animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCancelAnimalAdd_Click(object sender, RoutedEventArgs e)
        {
            canViewAnimalList.Visibility = Visibility.Visible;
            canAddAnimal.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/3/2020
        /// Approver: Jaeho Kim, 3/3/2020
        /// Approver: 
        /// 
        /// The method that will open a new canvas with the selected animal's information on it
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgActiveAnimals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
                selectedAnimal = (Animal)dgActiveAnimals.SelectedItem;

                lblIndividualAnimalName.Content = selectedAnimal.AnimalName;
                lblIndividualAnimalID.Content = selectedAnimal.AnimalID;
                lblIndividualAnimalSpecies.Content = selectedAnimal.AnimalSpeciesID;
                lblIndividualAnimalBreed.Content = selectedAnimal.AnimalBreed;
                lblIndividualAnimalDob.Content = selectedAnimal.Dob;
                lblIndividualAnimalArrivalDate.Content = selectedAnimal.ArrivalDate;
                chkIndvidualActive.IsChecked = selectedAnimal.Active;
                chkIndvidualAdoptable.IsChecked = selectedAnimal.Adoptable;
                chkIndvidualCurrentlyHoused.IsChecked = selectedAnimal.CurrentlyHoused;

                canIndividualAnimal.Visibility = Visibility;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/3/2020
        /// Approver: Jaeho Kim, 3/3/2020
        /// Approver: 
        /// 
        /// The method that will return to the view list of animals from the individual animal 
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnReturnViewIndividualAnimal_Click(object sender, RoutedEventArgs e)
        {
            canViewAnimalList.Visibility = Visibility.Visible;
            canIndividualAnimal.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/11/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// The method that will open a new canvas with the selected animal's information on it
        /// and can be edited.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnEditIndividualAnimal_Click(object sender, RoutedEventArgs e)
        {
            canEditAnimal.Visibility = Visibility.Visible;
            canIndividualAnimal.Visibility = Visibility.Hidden;

            Animal selectedAnimal = (Animal)dgActiveAnimals.SelectedItem;

            lblEditAnimalID.Content = selectedAnimal.AnimalID;
            txtEditAnimalName.Text = selectedAnimal.AnimalName;
            cmbEditAnimalSpecies.SelectedItem = selectedAnimal.AnimalSpeciesID;
            txtEditAnimalBreed.Text = selectedAnimal.AnimalBreed;
            cndEditDob.SelectedDate = selectedAnimal.Dob;
            cndEditDob.DisplayDate = selectedAnimal.Dob;
            cndEditArrivalDate.SelectedDate = selectedAnimal.ArrivalDate;
            cndEditArrivalDate.DisplayDate = selectedAnimal.ArrivalDate;
            chkEditActive.IsChecked = selectedAnimal.Active;
            chkEditAdoptable.IsChecked = selectedAnimal.Adoptable;
            chkEditCurrentlyHoused.IsChecked = selectedAnimal.CurrentlyHoused;
            cmbEditAnimalSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// The method that cancels the edit animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCancelAnimalEdit_Click(object sender, RoutedEventArgs e)
        {
            canEditAnimal.Visibility = Visibility.Hidden;
            canIndividualAnimal.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver: 
        /// 
        /// The method that saves the edits to the animal
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSubmitAnimalEdit_Click(object sender, RoutedEventArgs e)
        {
            string arrival = cndEditArrivalDate.SelectedDate.ToString();
            string dob = cndEditDob.SelectedDate.ToString();
            if (String.IsNullOrEmpty(txtEditAnimalName.Text))
            {
                MessageBox.Show("Please enter the animal's name");
                return;
            }
            if (String.IsNullOrEmpty(txtEditAnimalBreed.Text))
            {
                MessageBox.Show("Please enter the animal's breed");
                return;
            }
            if (String.IsNullOrEmpty(cmbEditAnimalSpecies.Text))
            {
                MessageBox.Show("Please enter the animal's species");
                return;
            }
            if (String.IsNullOrEmpty(arrival))
            {
                MessageBox.Show("Please enter the animal's arrival date");
                return;
            }
            if (String.IsNullOrEmpty(dob))
            {
                cndDob.SelectedDate = DateTime.Parse("01/01/2000");
                return;
            }

            Animal newAnimal = new Animal();

            newAnimal.AnimalName = txtEditAnimalName.Text;
            newAnimal.AnimalSpeciesID = cmbEditAnimalSpecies.Text;
            newAnimal.AnimalBreed = txtEditAnimalBreed.Text;
            newAnimal.ArrivalDate = (DateTime)cndEditArrivalDate.SelectedDate;
            newAnimal.Dob = (DateTime)cndEditDob.SelectedDate;

            try
            {
                if (_animalManager.EditAnimal(selectedAnimal, newAnimal))
                {
                    WPFErrorHandler.SuccessMessage("Animal Successfully Updated");

                    canViewAnimalList.Visibility = Visibility.Visible;
                    canEditAnimal.Visibility = Visibility.Hidden;
                    refreshActiveData();
                    chkActive.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canIndividualAnimal.Visibility = Visibility.Visible;
                canEditAnimal.Visibility = Visibility.Hidden;
                refreshActiveData();
                chkActive.IsChecked = false;
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/7/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Toggles the animal's Active state.
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkEditActive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caption = (bool)chkEditActive.IsChecked ? "Reactivate Animal" :
                    "Dectivate Animal";
                if (MessageBox.Show("Are you sure?", caption,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    chkEditActive.IsChecked = !(bool)chkEditActive.IsChecked;
                    return;
                }

                if (_animalManager.SetAnimalActiveState((bool)chkEditActive.IsChecked, (int)lblEditAnimalID.Content))
                {
                    MessageBox.Show("Record Edited Successfully.", "Result");
                }

                if ((bool)chkEditActive.IsChecked)
                {
                    refreshActiveData();
                }
                else
                {
                    refreshInactiveData();
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.ActivateDeactivateErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/7/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Toggles the animal's Housed state.
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkEditCurrentlyHoused_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caption = (bool)chkEditCurrentlyHoused.IsChecked ? "Set Housed" :
                    "Set Non-Housed";
                if (MessageBox.Show("Are you sure?", caption,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    chkEditCurrentlyHoused.IsChecked = !(bool)chkEditCurrentlyHoused.IsChecked;
                    return;
                }

                if (_animalManager.SetAnimalHousedState((bool)chkEditCurrentlyHoused.IsChecked, (int)lblEditAnimalID.Content))
                {
                    MessageBox.Show("Record Edited Successfully.", "Result");
                }

                if ((bool)chkEditActive.IsChecked)
                {
                    refreshActiveData();
                }
                else
                {
                    refreshInactiveData();
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.ActivateDeactivateErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 3/7/2020
        /// Approver: Carl Davis, 3/13/2020
        /// Approver: 
        /// 
        /// Toggles the animal's Adoptable state.
        /// detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkEditAdoptable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string caption = (bool)chkEditAdoptable.IsChecked ? "Set Adoptable" :
                    "Set Non-Adoptable";
                if (MessageBox.Show("Are you sure?", caption,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    chkEditAdoptable.IsChecked = !(bool)chkEditAdoptable.IsChecked;
                    return;
                }

                if (_animalManager.SetAnimalAdoptableState((bool)chkEditAdoptable.IsChecked, (int)lblEditAnimalID.Content))
                {
                    MessageBox.Show("Record Edited Successfully.", "Result");
                }

                if ((bool)chkEditActive.IsChecked)
                {
                    refreshActiveData();
                }
                else
                {
                    refreshInactiveData();
                }
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.ActivateDeactivateErrorMessage(ex.Message + "\n\n" + ex.InnerException);
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that shows the edit animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpecies_Click(object sender, RoutedEventArgs e)
        {
            canEditAnimalSpecies.Visibility = Visibility.Visible;
            cmbEditSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();
            cmbDeleteSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();
            lblNewAnimalSpecies.Visibility = Visibility.Hidden;
            txtNewAnimalSpecies.Visibility = Visibility.Hidden;
            lblNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblEditSpecies.Visibility = Visibility.Hidden;
            cmbEditSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesID.Visibility = Visibility.Hidden;
            txtEditAnimalSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblDeleteSpecies.Visibility = Visibility.Hidden;
            cmbDeleteSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalAddSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalEditSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalDeleteSpecies.Visibility = Visibility.Hidden;
            chkAddSpecies.IsChecked = false;
            chkEditSpecies.IsChecked = false;
            chkDeleteSpecies.IsChecked = false;
            txtNewAnimalSpecies.Text = "";
            txtNewAnimalSpeciesDescription.Text = "";
            cmbEditSpecies.Text = "";
            cmbDeleteSpecies.Text = "";
            txtEditAnimalSpecies.Text = "";
            txtEditAnimalSpeciesDescription.Text = "";

        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that cancels the edit animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelAnimalEditSpecies_Click(object sender, RoutedEventArgs e)
        {
            canEditAnimalSpecies.Visibility = Visibility.Hidden;
            txtNewAnimalSpecies.Text = "";
            txtNewAnimalSpeciesDescription.Text = "";
            cmbEditSpecies.Text = "";
            cmbDeleteSpecies.Text = "";
            txtEditAnimalSpecies.Text = "";
            txtEditAnimalSpeciesDescription.Text = "";
            chkAddSpecies.IsChecked = false;
            chkEditSpecies.IsChecked = false;
            chkDeleteSpecies.IsChecked = false;

        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that when the add species check box is checked, shows the add options and hides the edit and delete options
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAddSpecies_Checked(object sender, RoutedEventArgs e)
        {
            chkEditSpecies.IsChecked = false;
            chkDeleteSpecies.IsChecked = false;
            lblNewAnimalSpecies.Visibility = Visibility.Visible;
            txtNewAnimalSpecies.Visibility = Visibility.Visible;
            lblNewAnimalSpeciesDescription.Visibility = Visibility.Visible;
            txtNewAnimalSpeciesDescription.Visibility = Visibility.Visible;
            lblEditSpecies.Visibility = Visibility.Hidden;
            cmbEditSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesID.Visibility = Visibility.Hidden;
            txtEditAnimalSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblDeleteSpecies.Visibility = Visibility.Hidden;
            cmbDeleteSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalAddSpecies.Visibility = Visibility.Visible;
            BtnSubmitAnimalEditSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalDeleteSpecies.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that when the edit existing species check box is checked, shows the edit options and hides the add and delete options
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEditSpecies_Checked(object sender, RoutedEventArgs e)
        {
            chkAddSpecies.IsChecked = false;
            chkDeleteSpecies.IsChecked = false;
            lblNewAnimalSpecies.Visibility = Visibility.Hidden;
            txtNewAnimalSpecies.Visibility = Visibility.Hidden;
            lblNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblEditSpecies.Visibility = Visibility.Visible;
            cmbEditSpecies.Visibility = Visibility.Visible;
            lblEditAnimalSpeciesID.Visibility = Visibility.Visible;
            txtEditAnimalSpecies.Visibility = Visibility.Visible;
            lblEditAnimalSpeciesDescription.Visibility = Visibility.Visible;
            txtEditAnimalSpeciesDescription.Visibility = Visibility.Visible;
            lblDeleteSpecies.Visibility = Visibility.Hidden;
            cmbDeleteSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalAddSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalEditSpecies.Visibility = Visibility.Visible;
            BtnSubmitAnimalDeleteSpecies.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that when the delete existing species check box is checked, shows the delete options and hides the add and edit options
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDeleteSpecies_Checked(object sender, RoutedEventArgs e)
        {
            chkAddSpecies.IsChecked = false;
            chkEditSpecies.IsChecked = false;
            lblNewAnimalSpecies.Visibility = Visibility.Hidden;
            txtNewAnimalSpecies.Visibility = Visibility.Hidden;
            lblNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblEditSpecies.Visibility = Visibility.Hidden;
            cmbEditSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesID.Visibility = Visibility.Hidden;
            txtEditAnimalSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblDeleteSpecies.Visibility = Visibility.Visible;
            cmbDeleteSpecies.Visibility = Visibility.Visible;
            BtnSubmitAnimalAddSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalEditSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalDeleteSpecies.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that when the edit existing species check box is unchecked, everything is hidden
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEditSpecies_Unchecked(object sender, RoutedEventArgs e)
        {
            lblNewAnimalSpecies.Visibility = Visibility.Hidden;
            txtNewAnimalSpecies.Visibility = Visibility.Hidden;
            lblNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblEditSpecies.Visibility = Visibility.Hidden;
            cmbEditSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesID.Visibility = Visibility.Hidden;
            txtEditAnimalSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblDeleteSpecies.Visibility = Visibility.Hidden;
            cmbDeleteSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalAddSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalEditSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalDeleteSpecies.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that when the add species check box is unchecked, everything is hidden
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAddSpecies_Unchecked(object sender, RoutedEventArgs e)
        {
            lblNewAnimalSpecies.Visibility = Visibility.Hidden;
            txtNewAnimalSpecies.Visibility = Visibility.Hidden;
            lblNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblEditSpecies.Visibility = Visibility.Hidden;
            cmbEditSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesID.Visibility = Visibility.Hidden;
            txtEditAnimalSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblDeleteSpecies.Visibility = Visibility.Hidden;
            cmbDeleteSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalAddSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalEditSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalDeleteSpecies.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that when the delete species check box is unchecked, everything is hidden
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDeleteSpecies_Unchecked(object sender, RoutedEventArgs e)
        {
            lblNewAnimalSpecies.Visibility = Visibility.Hidden;
            txtNewAnimalSpecies.Visibility = Visibility.Hidden;
            lblNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtNewAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblEditSpecies.Visibility = Visibility.Hidden;
            cmbEditSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesID.Visibility = Visibility.Hidden;
            txtEditAnimalSpecies.Visibility = Visibility.Hidden;
            lblEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            txtEditAnimalSpeciesDescription.Visibility = Visibility.Hidden;
            lblDeleteSpecies.Visibility = Visibility.Hidden;
            cmbDeleteSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalAddSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalEditSpecies.Visibility = Visibility.Hidden;
            BtnSubmitAnimalDeleteSpecies.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method that populates the edit fields
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEditSpecies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbEditSpecies.SelectedItem != null)
                {
                    txtEditAnimalSpecies.Text = cmbEditSpecies.SelectedItem.ToString();
                }
                else
                {
                    txtEditAnimalSpecies.Text = "";
                }           
            }
            catch(Exception)
            {
                txtEditAnimalSpecies.Text = "";
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method when the submit add new species button is clicked, calls the animal manager
        /// to add it to the database
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitAnimalAddSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNewAnimalSpecies.Text))
            {
                MessageBox.Show("Please enter the new animal species");
                return;
            }
            if (String.IsNullOrEmpty(txtNewAnimalSpeciesDescription.Text))
            {
                MessageBox.Show("Please enter the animal species description");
                return;
            }

            try
            {
                if (_animalManager.AddNewAnimalSpecies(txtNewAnimalSpecies.Text, txtNewAnimalSpeciesDescription.Text))
                {
                    WPFErrorHandler.SuccessMessage("Animal Species Successfully Added");

                    canEditAnimalSpecies.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canEditAnimalSpecies.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method when the submit delete species button is clicked, calls the animal manager
        /// to delete it from the database
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitAnimalDeleteSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(cmbDeleteSpecies.Text))
            {
                MessageBox.Show("Please enter the animal species that you wish to delete");
                return;
            }

            try
            {
                if (_animalManager.DeleteAnimalSpecies(cmbDeleteSpecies.Text))
                {
                    WPFErrorHandler.SuccessMessage("Animal Species Successfully Deleted");

                    canEditAnimalSpecies.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + "no animals can be this species before deletion" + "\n\n" + ex.InnerException.Message);
                canEditAnimalSpecies.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        /// 
        /// The method when the submit update species button is clicked, calls the animal manager
        /// to update it in the database
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitAnimalEditSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(cmbEditSpecies.Text))
            {
                MessageBox.Show("Please enter the animal species that you wish to update");
                return;
            }
            if (String.IsNullOrEmpty(txtEditAnimalSpecies.Text))
            {
                MessageBox.Show("Please enter the animal species that you wish to update");
                return;
            }
            if (String.IsNullOrEmpty(txtEditAnimalSpeciesDescription.Text))
            {
                MessageBox.Show("Please enter the animal species' description that you wish to update");
                return;
            }

            try
            {
                if (_animalManager.EditAnimalSpecies(cmbEditSpecies.Text, txtEditAnimalSpecies.Text, txtEditAnimalSpeciesDescription.Text))
                {
                    WPFErrorHandler.SuccessMessage("Animal Species Successfully Updated");
                    canEditAnimalSpecies.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                canEditAnimalSpecies.Visibility = Visibility.Hidden;
                txtEditAnimalSpecies.Text = "";
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 5/5/2020
        /// Approver: Chuck Baxter 5/5/2020
        /// 
        /// Used for clearing the default text from the search bar
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void txtSearchAnimal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchAnimal.Text == "Animal Name")
            {
                txtSearchAnimal.Text = "";
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 5/5/2020
        /// Approver: Chuck Baxter 5/5/2020
        /// 
        /// Used to search for an animal
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnSearchAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (btnSearchAnimal.Content.ToString() == "Search")
            {
                List<Animal> list;
                btnSearchAnimal.Content = "Reset";
                try
                {
                    list = !(bool)chkActive.IsChecked ?
                    _animalManager.RetrieveAnimalsByActive() :
                    _animalManager.RetrieveAnimalsByInactive();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                dgActiveAnimals.ItemsSource = null;
                dgActiveAnimals.ItemsSource = _animalManager.RetrieveAnimalsByName(
                    txtSearchAnimal.Text, list);
            }
            else
            {
                btnSearchAnimal.Content = "Search";
                txtSearchAnimal.Text = "";
                if (!(bool)chkActive.IsChecked)
                {
                    refreshActiveData();
                }
                else
                {
                    refreshInactiveData();
                }
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 5/5/2020
        /// Approver: Chuck Baxter 5/5/2020
        /// 
        /// Changes the Reset button back to a Search button
        /// when text is re-entered into the search bar
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void txtSearchAnimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (btnSearchAnimal != null &&
                btnSearchAnimal.Content.ToString() == "Reset")
            {
                btnSearchAnimal.Content = "Search";
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 5/5/2020
        /// Approver: Ethan Murphy 5/5/2020
        /// 
        /// Fixes columns in datagrid when data is populated
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgActiveAnimals_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[0]);
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[10]);
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[9]);
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[8]);

            dgActiveAnimals.Columns[0].Header = "Name";
            dgActiveAnimals.Columns[1].Header = "Date of Birth";
            dgActiveAnimals.Columns[2].Header = "Species";
            dgActiveAnimals.Columns[3].Header = "Breed";
            dgActiveAnimals.Columns[4].Header = "Arrival Date";
            dgActiveAnimals.Columns[5].Header = "Currently Housed";
            dgActiveAnimals.Columns[6].Header = "Adoptable";
            dgActiveAnimals.Columns[7].Header = "Active";

            dgActiveAnimals.Columns[0].Width = 200;
            dgActiveAnimals.Columns[1].Width = 200;
            dgActiveAnimals.Columns[2].Width = 117.5;
            dgActiveAnimals.Columns[3].Width = 200;
            dgActiveAnimals.Columns[4].Width = 200;
            dgActiveAnimals.Columns[5].Width = 117.5;
            dgActiveAnimals.Columns[6].Width = 117.5;
            dgActiveAnimals.Columns[7].Width = 117.5;
        }
    }
}
