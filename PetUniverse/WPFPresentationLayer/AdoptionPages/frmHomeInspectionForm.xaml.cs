using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/05
    /// Approver: Austin Gee, 2020/02/07
    ///  Interaction logic for Home Inspection Form window.
    ///  And will control what the user can see and do.
    /// </summary>
    public partial class frmHomeInspectionForm : Page
    {
        private IHomeInspectorManager _homeInspectorManager;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/05
        /// Approver: Austin Gee, 2020/02/07
        /// This This Constructor method for Home Inspector
        /// window.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        public frmHomeInspectionForm()
        {
            InitializeComponent();
            _homeInspectorManager = new HomeInspectorManager();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/05
        /// Approver: Austin Gee,  2020/02/07
        /// This is an event when the window first loads.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            populatedgAdoptionApplicationsList();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/05
        /// Approver: Austin Gee, 2020/02/07
        /// This method fills in data for Home Inspector Adoption Application
        /// Data Gird.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        private void populatedgAdoptionApplicationsList()
        {

            dgAdoptionApplicationsList.ItemsSource = _homeInspectorManager.SelectAdoptionApplicationByStatus();
            dgAdoptionApplicationsList.Columns[0].Header = "Adoption Application ID";
            dgAdoptionApplicationsList.Columns[1].Header = "Customer Email";
            dgAdoptionApplicationsList.Columns[2].Header = "Animal Name";
            dgAdoptionApplicationsList.Columns[3].Header = "Status";
            dgAdoptionApplicationsList.Columns[4].Header = "Recieved Date and Time";
            dgAdoptionApplicationsList.Columns.RemoveAt(3);
            dgAdoptionApplicationsList.Columns.RemoveAt(5);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Austin Gee, 2020/02/19
        /// This is an event on btnOpen is clicked which will open Customer Detail window.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>  
        private void BtnOpenRecord_Click(object sender, RoutedEventArgs e)
        {
            AdoptionApplication adoptionApplication = new AdoptionApplication();
            adoptionApplication = (AdoptionApplication)dgAdoptionApplicationsList.SelectedItem;

            var selectedItem = (AdoptionApplication)dgAdoptionApplicationsList.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select an Adoption Appliction to open the Customer Details.");
            }
            else
            {
                this.NavigationService?.Navigate(new CustomerDetail
                    (adoptionApplication.CustomerEmail));
                populatedgAdoptionApplicationsList();
            }
        }
    }
}


