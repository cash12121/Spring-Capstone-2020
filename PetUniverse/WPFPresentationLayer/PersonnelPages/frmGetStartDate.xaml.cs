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
using System.Windows.Shapes;

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for frmGetStartDate.xaml
    /// </summary>
    public partial class frmGetStartDate : Window
    {
        DateTime _startDate;

        public event Action<DateTime> setDate;

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver:
        /// 
        ///  get schedule start date constructor.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public frmGetStartDate()
        {
            InitializeComponent();
            _startDate = DateTime.Now.Date;
            dpkrStartDate.DisplayDate = _startDate;

        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver:
        /// 
        ///  Save click method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void btnSetStartDate_Click(object sender, RoutedEventArgs e)
        {
            if (dpkrStartDate.SelectedDate >= _startDate && _startDate.AddDays(36) >= dpkrStartDate.SelectedDate)
            {
                DateTime startDate = (DateTime)dpkrStartDate.SelectedDate;
                setDate(startDate);
                this.DialogResult = true;
            }
            else if (dpkrStartDate.SelectedDate < _startDate)
            {
                WPFErrorHandler.ErrorMessage("Please choose a date today or later.");
            }
            else if(dpkrStartDate.SelectedDate > _startDate.AddDays(36))
            {
                WPFErrorHandler.ErrorMessage("Please choose a date less than 37 days in the future.");
            }
            else
            {
                WPFErrorHandler.ErrorMessage("Please choose a date.");
            }
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver:
        /// 
        ///  method for cancel click.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
