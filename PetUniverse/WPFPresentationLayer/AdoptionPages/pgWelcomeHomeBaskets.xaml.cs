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
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Interaction logic for pgWelcomeHomeBaskets.xaml
    /// Creator: Mohamed Elamin
    /// Created: 2020/04/14
    /// Approver:  Austin Gee , 2020/04/15 
    /// </summary>
    public partial class pgWelcomeHomeBaskets : Page
    {
        private IItemManager _itemManager;
        private Item item;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/04/14
        /// Approver: Austin Gee , 2020/04/15 
        /// This is Constructor method for Welcome Home Baskets Page,
        ///  and controls what the user can see and do.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        public pgWelcomeHomeBaskets()
        {
            InitializeComponent();
            _itemManager = new ItemManager();
            item = new Item();
        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created : 2020/04/14
        /// Approver: Austin Gee , 2020/04/15 
        /// This Method fills in data for Welcome Home Baskets's Data Gird.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>      
        private void populatedgInventoryList()
        {
            try
            {
                dgInventoryList.ItemsSource = _itemManager.retrieveItems();
                dgInventoryList.Columns.RemoveAt(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't retrieve the list", ex.Message + "\n\n"
                                             + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/04/14
        /// Approved By: Austin Gee , 2020/04/15 
        /// This is an event  when the window first loads.
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
            populatedgInventoryList();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/04/14
        /// Approved By: Austin Gee , 2020/04/15 
        /// This is an event  when the Back Button is clicked.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new pgMeetAndGreets());
        }
    }
}
