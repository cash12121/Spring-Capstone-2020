using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPresentationLayer.AMPages
{

    public partial class AnimalRecords : Page
    {
        public AnimalRecords()
        {
            InitializeComponent();
            _animalManager = new AnimalManager();
            cmbAnimalSpecies.ItemsSource = _animalManager.RetrieveAnimalSpecies();
            Warning.Visibility = Visibility.Hidden;
            Warning2.Visibility = Visibility.Hidden;

            QuantityAlertManager();
            NewAnimalChecklist.Visibility = Visibility.Hidden;

            _animalManager = new AnimalManager();
            _ChecklistManager = new NewAnimalChecklistManager();
            _MHManager = new AnimalMedicalHistoryManager();
            NumberOfActiveAnimals = _ChecklistManager.RetrieveNumberOfAnimals();//Full auto

        }

        private IAnimalManager _animalManager;
        private INewAnimalChecklistManager _ChecklistManager;
        private IAnimalMedicalHistoryManager _MHManager;
        public static int page = 0;

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/3/2020
        /// Approver: Carl Davis, 3/6/2020s 
        /// Approver: 
        /// 
        /// Method to handle quantity alerts
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void QuantityAlertManager()
        {
            MedicationManager medicationManager = new MedicationManager();
            int num = medicationManager.RetrieveMedicationByLowQauntity().Count();
            int empty = medicationManager.RetrieveMedicationByEmptyQauntity().Count();
            Medication medication = new Medication();

            if (Warning.Visibility == Visibility.Hidden)
            {
                Warning2.Visibility = Visibility.Hidden;
            }

            if (Warning2.Visibility == Visibility.Visible)
            {
                Warning.Visibility = Visibility.Visible;
            }

            if (empty >= 1 && num >= 1)
            {
                if (num == 1)
                {
                    Warning2.Content = "Pet universe is currently running low on " + num + " medication";
                    Warning2.Foreground = new SolidColorBrush(Colors.DarkOrange);
                    Warning2.Visibility = Visibility.Visible;
                }
                else
                {
                    Warning2.Content = "Pet universe is currently running low on " + num + " medications";
                    Warning2.Foreground = new SolidColorBrush(Colors.DarkOrange);
                    Warning2.Visibility = Visibility.Visible;
                }

                if (empty == 1)
                {
                    Warning.Content = "Pet universe is currently out of " + empty + " medication";
                    Warning.Foreground = new SolidColorBrush(Colors.Red);
                    Warning.Visibility = Visibility.Visible;
                }
                else
                {
                    Warning.Content = "Pet universe is currently out of " + empty + " medications";
                    Warning.Foreground = new SolidColorBrush(Colors.Red);
                    Warning.Visibility = Visibility.Visible;
                }
            }
            else if (empty >= 1 && num < 1)
            {
                if (empty == 1)
                {
                    Warning.Content = "Pet universe is currently out of " + empty + " medication";
                    Warning.Foreground = new SolidColorBrush(Colors.Red);
                    Warning.Visibility = Visibility.Visible;
                    Warning2.Visibility = Visibility.Hidden;
                }
                else
                {
                    Warning.Content = "Pet universe is currently out of " + empty + " medications";
                    Warning.Foreground = new SolidColorBrush(Colors.Red);
                    Warning.Visibility = Visibility.Visible;
                    Warning2.Visibility = Visibility.Hidden;
                }
            }
            else if (num >= 1 && empty < 1)
            {
                if (num == 1)
                {
                    Warning.Content = "Pet universe is currently running low on " + num + " medication";
                    Warning.Foreground = new SolidColorBrush(Colors.DarkOrange);
                    Warning.Visibility = Visibility.Visible;
                    Warning2.Visibility = Visibility.Hidden;
                }
                else
                {
                    Warning.Content = "Pet universe is currently running low on " + num + " medications";
                    Warning.Foreground = new SolidColorBrush(Colors.DarkOrange);
                    Warning.Visibility = Visibility.Visible;
                    Warning2.Visibility = Visibility.Hidden;
                }

            }
            if (empty == 1)
            {
                Warning.Content = "Pet universe is currently out of " + empty + " medication";
                Warning.Foreground = new SolidColorBrush(Colors.Red);
                Warning.Visibility = Visibility.Visible;
                Warning2.Visibility = Visibility.Hidden;
            }
        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/22/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// ClickEvent for Animal list to view an animals entire record/checklist
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            NewAnimalChecklist.Visibility = Visibility.Visible;
            SelectAnimalMessage.Visibility = Visibility.Hidden;
            List<NewAnimalChecklist> List = null;
            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();
            object item = dgActiveAnimals.SelectedItem;
            string ID = (dgActiveAnimals.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            try
            {
                page = Int32.Parse(ID);
                List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(Int32.Parse(ID));
                Error.Visibility = Visibility.Hidden;

            }
            catch (FormatException)
            {
                Error.Visibility = Visibility.Visible;
                Error.Content = "Please enter a valid ID number";
            }
            view.ItemsSource = List;
            return;
        }

        public int NumberOfActiveAnimals { get; set; }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver:
        /// Approver:
        /// 
        /// Method to view the record for the next animal in the list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void AnimalChecklistPreviousButtonManager()
        {
            List<NewAnimalChecklist> List = null;

            if (AnimalRecords.page == 1000000)
            {
                AnimalRecords.page = NumberOfActiveAnimals + 1000000;
            }
            else
            {
                AnimalRecords.page--;
            }

            try
            {
                List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(AnimalRecords.page);
                Error.Visibility = Visibility.Hidden;
            }
            catch (FormatException)
            {
                Error.Visibility = Visibility.Visible;
                Error.Content = "Please enter a valid ID number";
            }
            view.ItemsSource = List;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver:
        /// Approver:
        /// 
        /// Method to view the record for the previous animal in the list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        public void AnimalChecklistNextButtonManager()
        {
            List<NewAnimalChecklist> List = null;
            AnimalRecords.page++;

            if (AnimalRecords.page > NumberOfActiveAnimals + 1000000)
            {
                AnimalRecords.page = 1000000;
            }

            try
            {
                List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(AnimalRecords.page);
                Error.Visibility = Visibility.Hidden;
            }
            catch (FormatException)
            {
                Error.Visibility = Visibility.Visible;
                Error.Content = "Please enter a valid ID number";
            }
            view.ItemsSource = List;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver:
        /// Approver:
        /// 
        /// Applys changes to UI when text box input changes
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void TxtChange(object sender, TextChangedEventArgs e)
        {
            List<NewAnimalChecklist> List = null;
            _ChecklistManager = new NewAnimalChecklistManager();

            try
            {
                List = _ChecklistManager.RetrieveNewAnimalChecklistByAnimalID(Int32.Parse(searchbox.Text) + 1000000);
                Error.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                Error.Visibility = Visibility.Visible;
                Error.Content = "Please enter a valid ID number";
            }
            view.ItemsSource = List;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver:
        /// Approver:
        /// 
        /// Button to view the record for the next animal in the list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            AnimalChecklistNextButtonManager();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver:
        /// Approver:
        /// 
        /// Button to view the record for the previous animal in the list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            AnimalChecklistPreviousButtonManager();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/28/2020
        /// Approver:
        /// Approver:
        /// 
        /// Hover Records for the next and back arrows on the animal control menu
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void NextArrowHoverON(object sender, MouseEventArgs e)
        {
            Black.Visibility = Visibility.Hidden;
            Red.Visibility = Visibility.Visible;
        }
        private void NextArrowHoverOFF(object sender, MouseEventArgs e)
        {
            Red.Visibility = Visibility.Hidden;
            Black.Visibility = Visibility.Visible;
        }
        private void BackArrowHoverON(object sender, MouseEventArgs e)
        {
            BackBlack.Visibility = Visibility.Hidden;
            BackRed.Visibility = Visibility.Visible;
        }
        private void BackArrowHoverOFF(object sender, MouseEventArgs e)
        {
            BackRed.Visibility = Visibility.Hidden;
            BackBlack.Visibility = Visibility.Visible;
        }

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

            dgActiveAnimals.Columns[0].IsReadOnly = true;

            dgActiveAnimals.Columns[2].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[3].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[4].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[5].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[6].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[7].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[8].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[9].Visibility = Visibility.Hidden;
            dgActiveAnimals.Columns[10].Visibility = Visibility.Hidden;

            dgActiveAnimals.Columns[1].IsReadOnly = true;
            dgActiveAnimals.Columns[2].IsReadOnly = true;
            dgActiveAnimals.Columns[3].IsReadOnly = true;
            dgActiveAnimals.Columns[4].IsReadOnly = true;
            dgActiveAnimals.Columns[8].IsReadOnly = true;

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
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void refreshActiveData()
        {
            dgActiveAnimals.ItemsSource = _animalManager.RetrieveAnimalsByActive();
            dgActiveAnimals.Columns[9].Visibility = Visibility.Hidden;

            //dgActiveAnimals.Columns[0].Header = "Name";
            //dgActiveAnimals.Columns[1].Header = "Date of Birth";
            //dgActiveAnimals.Columns[2].Header = "Breed";
            //dgActiveAnimals.Columns[3].Header = "Arrival Date";
            //dgActiveAnimals.Columns[4].Header = "Currently Housed";
            //dgActiveAnimals.Columns[6].Header = "Species";
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
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void refreshInactiveData()
        {
            dgActiveAnimals.ItemsSource = _animalManager.RetrieveAnimalsByInactive();
            dgActiveAnimals.Columns.Remove(dgActiveAnimals.Columns[0]);
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
            Animal selectedAnimal = (Animal)dgActiveAnimals.SelectedItem;

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
        /// Created: 3/3/2020
        /// Approver: Jaeho Kim, 3/3/2020
        /// Approver: 
        /// 
        /// The method that will open a new canvas with the selected animal's information on it
        /// </summary>
        /// <remarks>
        /// Updater: Daulton Schilling
        /// Updated: 3/7/2020
        /// Update: Moved click event to the 'View' datagrid. Everything is still the exact same otherwise
        /// </remarks>
        private void View_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            NewAnimalChecklist.Visibility = Visibility.Visible;
            SelectAnimalMessage.Visibility = Visibility.Hidden;
            List<MedicalHistory> List = null;
            AnimalMedicalHistoryManager _ChecklistManager = new AnimalMedicalHistoryManager();
            object item = view.SelectedItem;
            string ID = (view.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            _MHManager = new AnimalMedicalHistoryManager();

            try
            {
                page = Int32.Parse(ID);
                List = _ChecklistManager.RetrieveAnimalMedicalHistoryByAnimalID(Int32.Parse(ID));
                Error.Visibility = Visibility.Hidden;
            }
            catch (FormatException)
            {
                Error.Visibility = Visibility.Visible;
                Error.Content = "Please enter a valid ID number";
            }
            view.ItemsSource = List;
            return;
        }
    }
}

