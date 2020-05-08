using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.Win32;
using PresentationUtilityCode;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace WPFPresentationLayer.AdoptionsPages
{
    /// <summary>
    /// Interaction logic for pgAdoptionsAnimalProfile.xaml
    /// </summary>
    public partial class pgAdoptionsAnimalProfile : Page
    {
        private Animal _selectedAnimal;
        public pgAdoptionsAnimalProfile()
        {
            InitializeComponent();
            _animalManager = new AnimalManager();
            Animal _animal = new Animal();
        }

        private IAnimalManager _animalManager;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //refreshData();
            //canAnimalProfile.Visibility = Visibility.Hidden;
            //canViewAnimalProfileList.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Method to refresh the data grid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void refreshData()
        {
            try
            {
                dgAnimalProfiles.ItemsSource = _animalManager.RetrieveAllAnimalProfiles();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
            }

        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Method to take a user to the canvas to update the profile
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        private void DgAnimals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //canUpdateAnimal.Visibility = Visibility.Visible;
            BtnSubmitAnimalUpdate.Visibility = Visibility.Visible;
            canViewAnimalProfileList.Visibility = Visibility.Hidden;
            canAnimalProfile.Visibility = Visibility.Visible;

            _selectedAnimal = _animalManager.RetrieveAnimalByAnimalID(((Animal)dgAnimalProfiles.SelectedItem).AnimalID)[0];
            

            //var selectedItem = dgAnimalProfiles.SelectedItem;
            //string ID = (dgAnimalProfiles.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
            try
            {
                
                lblAnimalName.Content = _selectedAnimal.AnimalName;
                lblAnimalBreed.Content = _selectedAnimal.AnimalBreed;
                lblAnimalSpecies.Content = _selectedAnimal.AnimalSpeciesID;

                //int animalID = Int32.Parse(ID);
                //Animal selectedAnimal = getInitialData(animalID);
                Animal selectedAnimal = _animalManager.RetrieveOneAnimalByAnimalID(((Animal)(dgAnimalProfiles.SelectedItem)).AnimalID);
                txtAnimalProfileDescription.Text = selectedAnimal.ProfileDescription;

                if (selectedAnimal.ProfileImageData != null)
                {
                    currentPetProfile.Source = null;
                    currentPetProfile.Source = byteArrayToImage(selectedAnimal.ProfileImageData);
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Method for the user to cancel the update and take them back to the original data grid
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        private void BtnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            //canUpdateAnimal.Visibility = Visibility.Hidden;
            canViewAnimalProfileList.Visibility = Visibility.Visible;
            canAnimalProfile.Visibility = Visibility.Hidden;

            currentPetProfile.Source = null;
            
            lblAnimalBreed.Content = "";
            lblAnimalName.Content = "";
            txtAnimalProfileDescription.Clear();
            lblAnimalSpecies.Content = "";
            refreshData();
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver:  Austin Gee
        /// 
        /// Method to clear display and clear inputs
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ClearDisplay()
        {
            txtAnimalProfileDescription.Text = "";
            canViewAnimalProfileList.Visibility = Visibility.Visible;
            //canUpdateAnimal.Visibility = Visibility.Hidden;
            canAnimalProfile.Visibility = Visibility.Hidden;
            dgAnimalProfiles.Visibility = Visibility.Visible;
            
            refreshData();
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// 
        /// Method to validate that there is a description and a photo path and sends that data to the database
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompsom
        /// Updated: 4/28/2020
        /// Update: To book specifications
        /// Approver: Austin Gee
        /// </remarks>
        private void BtnSubmitAnimalUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (currentPetProfile.Source != null)
            {


                if (String.IsNullOrEmpty(txtAnimalProfileDescription.Text))
                {
                    MessageBox.Show("Please enter the animal's profile description");
                    return;
                }

                var selectedItem = dgAnimalProfiles.SelectedItem;
                string ID = (dgAnimalProfiles.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                try
                {
                    int animalID = Int32.Parse(ID);

                    string profileDescription = txtAnimalProfileDescription.Text;
                    byte[] profileImage = imgToByteArray(currentPetProfile.Source as BitmapImage);
                    string profileImageMimeType = "jpg";
                    _animalManager.UpdatePetProfile(animalID, profileDescription, profileImage, profileImageMimeType);
                    WPFErrorHandler.SuccessMessage("Animal Successfully Updated");
                    ClearDisplay();
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
                    ClearDisplay();
                }
                currentPetProfile.Source = new BitmapImage();
                lblAnimalBreed.Content = "";
                lblAnimalName.Content = "";
                txtAnimalProfileDescription.Clear();
                lblAnimalSpecies.Content = "";
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please supply an Image");
            }
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/26/2020
        /// Approver: Austin Gee
        /// Method to convert a BitMapImage to a byte array
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="imageIn"/>
        /// </remarks>
        private byte[] imgToByteArray(BitmapImage imageIn)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageIn));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/26/2020
        /// Approver: Austin Gee
        /// Method to open a file dialog and let the user pick an iamge to set as an animals profiles image
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="e"/>
        /// <param name="sender"/>
        /// </remarks>
        private void BtnLoadProfileImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select Picture";
            opFile.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            if (opFile.ShowDialog() == true)
            {
                currentPetProfile.Source = new BitmapImage(new Uri(opFile.FileName));
            }
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/26/2020
        /// Approver: Austin Gee
        /// Gets information to initial show the data for an animal if it is presetn
        /// </summary>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="id"></param>
        /// <returns>An animal Object with the sepcified ID</returns>
        private Animal getInitialData(int id)
        {
            Animal selectedAnimal = new Animal();
            try
            {
                selectedAnimal = _animalManager.RetrieveOneAnimalByAnimalID(id);
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message + "\n\n" + ex.InnerException.Message);
            }

            return selectedAnimal;

        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/26/2020
        /// Approver: Austin Gee
        /// Method to convert a myte array to a BitMap image so that it can be shown to the user
        /// </summary>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="profileImageArray"></param>
        /// <returns></returns>
        public BitmapImage byteArrayToImage(byte[] profileImageArray)
        {

            MemoryStream stream = new MemoryStream(profileImageArray);
            BitmapImage image = new BitmapImage();

            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            return image;
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 4/26/2020
        /// Approver: Austin Gee
        /// Method Clean up the animal profile datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgAnimalProfiles_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgAnimalProfiles.Columns.RemoveAt(3);
            dgAnimalProfiles.Columns.RemoveAt(3);
            dgAnimalProfiles.Columns.RemoveAt(3);
            dgAnimalProfiles.Columns.RemoveAt(3);
            dgAnimalProfiles.Columns.RemoveAt(3);
            dgAnimalProfiles.Columns.RemoveAt(3);
            dgAnimalProfiles.Columns.RemoveAt(3);

            dgAnimalProfiles.Columns[0].Header = "Animal ID";
            dgAnimalProfiles.Columns[1].Header = "Animal Name";
            dgAnimalProfiles.Columns[2].Header = "Dob";
            dgAnimalProfiles.Columns[3].Header = "Image Data";
            dgAnimalProfiles.Columns[4].Header = "Image Mime Type";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            canAnimalProfile.Visibility = Visibility.Hidden;
            canViewAnimalProfileList.Visibility = Visibility.Visible;
            dgAnimalProfiles.Visibility = Visibility.Visible;
            refreshData();
        }
    }
}
