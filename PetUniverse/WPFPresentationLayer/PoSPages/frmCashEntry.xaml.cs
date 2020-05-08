using DataTransferObjects;
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

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for frmNumberEntry.xaml
    /// </summary>
    public partial class frmCashEntry : Window
    {
        AmountDue _due;
        private int _rawRecieved;
        private decimal _total;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Constructor that utilizes AmountDue to persist data between windows.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="due"></param>
        public frmCashEntry(AmountDue due)
        {
            InitializeComponent();
            _rawRecieved = 0;
            _due = due;
            _total = due.Amount;
            lblTotal.Content = _total.ToString("C");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("7");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("8");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("9");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// Adds $20 to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDollar20_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("$20");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("4");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("5");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("6");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds $10 to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDollar10_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("$10");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("1");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("2");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("3");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds $5 to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDollar5_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("$5");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds a # to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("0");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds two zeros to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDouble0_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("00");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Adds $1 to the cash recieved amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDollar1_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("$1");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Clears all data entered to the cash amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("Clear");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Accepts the amound entered as the amount paid and closes the window.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Removes a number from the end of the amount recieved number.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBksp_Click(object sender, RoutedEventArgs e)
        {
            addToRecieved("Backspace");
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Does the logic required to add the selected numbers to the amount/edit the amount.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToRecieved(string amountCode)
        {
            switch (amountCode)
            {
                case "00":
                    {
                        _rawRecieved = _rawRecieved * 100;
                        break;
                    }
                case "$20":
                    {
                        _rawRecieved += 2000;
                        break;
                    }
                case "$10":
                    {
                        _rawRecieved += 1000;
                        break;
                    }
                case "$5":
                    {
                        _rawRecieved += 500;
                        break;
                    }
                case "$1":
                    {
                        _rawRecieved += 100;
                        break;
                    }
                case "Clear":
                    {
                        _rawRecieved = 0;
                        break;
                    }
                case "Backspace":
                    {
                        _rawRecieved = _rawRecieved / 10;
                        break;
                    }
                default:
                    {
                        int amount = int.Parse(amountCode);
                        _rawRecieved = _rawRecieved * 10;
                        _rawRecieved += amount;
                        break;
                    }
            }
            formatRawRecieved();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: Jaeho Kim
        /// 
        /// Makes the raw recieved amount presentable.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatRawRecieved()
        {
            decimal recieved = decimal.Parse(_rawRecieved.ToString());
            recieved = recieved / 100m;
            txtRecieved.Text = recieved.ToString("C"); 
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/20/2020
        /// Approver: 
        /// 
        /// Saves amount tendered to amount due and tells how much is still due or how much change is owed.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal recieved = decimal.Parse(_rawRecieved.ToString());
            recieved = recieved / 100m;
            string opening;
            decimal amount = 0;
            if (_total > recieved)
            {
                opening = "Customer owes: ";
                amount = _total - recieved;
                _due.Amount = amount;
            }
            else
            {
                opening = "Change due: ";
                amount = recieved - _total;
                _due.Amount = 0m;
            }

            MessageBox.Show(opening + amount.ToString("C"), "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
