using DataTransferObjects;
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
using static WPFPresentationLayer.PoSPages.pgOpenTransaction;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for frmPayment.xaml
    /// </summary>
    public partial class frmPayment : Window
    {
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Default Constructor.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public frmPayment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Initializes a window with the amount due and payment type (defaults to Cancel).
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="paymentType"></param>
        /// <param name="due"></param>
        public frmPayment(PaymentType paymentType, AmountDue due)
        {
            InitializeComponent();
            this.PaymentType = paymentType;
            lblRemaining.Content = "Amount Remaining: " + due.Amount.ToString("C");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Opens a window to handle paying with cash.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            this.PaymentType = PaymentType.Cash;
            this.Close();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Opens a window to handle paying with a card.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            this.PaymentType = PaymentType.Card;
            this.Close();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Closes the window.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.PaymentType = PaymentType.Cancel;
            this.Close();
        }
    }
}
